using TpLibreria.Entidades;
using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.Autor;
using TpLibreria.Servicios.DTOs.Editorial;
using TpLibreria.Servicios.DTOs.Libro;
using TpLibreria.Servicios.DTOs.Tema;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;

namespace TpLibreria.Windows
{
    public partial class frmLibroAe : Form
    {
        private LibroUpdateDto? _libroUpdateDto;
        private readonly IServiceProvider _serviceProvider;
        //aca implemento los dos nuevos frm que uso para buscar autores y temas cuando quiero agregar en caso de que ubiera muchos datos frmSeleccionar...
        private readonly BindingList<AutorComboDto> _autores = new();
        private readonly BindingList<TemaComboDto> _temas = new();
        private readonly ILibroServicio _libroServicio;
        private readonly IEditorialServicio _editorialServicio;
        private readonly IAutorServicio _autorServicio;
        private readonly ITemaServicio _temaServicio;
        private bool _esEdicion = false;
        private ServicioMensajes _servicioMensajes = new();
        public frmLibroAe(IServiceProvider serviceProvider,
            ILibroServicio libroServicio,
            IEditorialServicio editorialServicio,
            IAutorServicio autorServicio,
            ITemaServicio temaServicio)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _libroServicio = libroServicio;
            _editorialServicio = editorialServicio;
            _autorServicio = autorServicio;
            _temaServicio = temaServicio;
            dgvAutores.DataSource = _autores;
            dgvTemas.DataSource = _temas;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//Agregado para informar de conflicto de concurrencia
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            nudAnioPublicacion.Maximum = DateTime.Today.Year;
            if (_libroUpdateDto is null)
            {
                CargarComboEditoriales(null);
                cboTipo.SelectedIndex = 0;
                nudAnioPublicacion.Value = DateTime.Today.Year;
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                CargarComboEditoriales(_libroUpdateDto.EditorialId);
                CargarListaAutores(_libroUpdateDto.AutoresIds);
                CargarListaTemas(_libroUpdateDto.TemasIds);
                cboTipo.SelectedIndex = _libroUpdateDto.Tipo == TipoLibro.Fisico ? 0 : 1;
                cboTipo.Enabled = false;
                txtTitulo.Text = _libroUpdateDto.Titulo;
                txtDescripcion.Text = _libroUpdateDto.Descripcion;
                nudAnioPublicacion.Value = _libroUpdateDto.AnioPublicacion;
                nudPrecio.Value = _libroUpdateDto.Precio;
                cboEditorial.SelectedValue = _libroUpdateDto.EditorialId;
                if (_libroUpdateDto.Tipo == TipoLibro.Fisico)
                {
                    txtIsbn.Text = _libroUpdateDto.Isbn;
                    nudStock.Value = _libroUpdateDto.Stock;
                }
                else
                {
                    txtIdentificador.Text = _libroUpdateDto.Identificador;
                    txtFormato.Text = _libroUpdateDto.Formato;
                    nudTamanoArchivo.Value = _libroUpdateDto.TamanoArchivo;
                    txtUrlDescarga.Text = _libroUpdateDto.UrlDescarga;
                }
                chkActivo.Checked = _libroUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
        }

        // Según el tipo de libro se habilitan los datos que le corresponden esto es polimorfismo de comportamiento, el mismo formulario se comporta distinto según el tipo de libro
        private void cboTipo_SelectedIndexChanged(object? sender, EventArgs e)
        {
            bool esFisico = cboTipo.SelectedIndex == 0;
            gpbLibroFisico.Enabled = esFisico;
            gpbLibroDigital.Enabled = !esFisico;
        }

        private void CargarComboEditoriales(int? editorialIdActual)
        {
            var respuesta = _editorialServicio
                .ObtenerDatosCombo(true, editorialIdActual);
            if (respuesta.IsFailure)
            {
                _servicioMensajes.Errores(respuesta.Errors);
                return;
            }
            var lista = respuesta.Value!;
            lista.Insert(0, new EditorialComboDto { EditorialId = 0, Nombre = "<Seleccione una editorial>" });
            cboEditorial.DataSource = lista;
            cboEditorial.DisplayMember = "Nombre";
            cboEditorial.ValueMember = "EditorialId";
            cboEditorial.SelectedIndex = 0;
        }

        private void CargarListaAutores(IEnumerable<int> ids)
        {
            var respuesta = _autorServicio.ObtenerPorIds(ids.ToList());
            if (respuesta.IsFailure)
            {
                _servicioMensajes.Errores(respuesta.Errors);
                return;
            }
            _autores.Clear();
            foreach (var autor in respuesta.Value!) _autores.Add(autor);
        }

        private void CargarListaTemas(IEnumerable<int> ids)
        {
            var respuesta = _temaServicio.ObtenerPorIds(ids.ToList());
            if (respuesta.IsFailure)
            {
                _servicioMensajes.Errores(respuesta.Errors);
                return;
            }
            _temas.Clear();
            foreach (var tema in respuesta.Value!) _temas.Add(tema);
        }

        private void btnAgregarAutor_Click(object sender, EventArgs e)
        {
            using (frmSeleccionarAutor frm = _serviceProvider.GetRequiredService<frmSeleccionarAutor>())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var autor = frm.GetAutor();
                if (autor is null) return;
                if (_autores.Any(a => a.AutorId == autor.AutorId))
                {
                    _servicioMensajes.Advertencia("Ese autor ya fue agregado al libro");
                    return;
                }
                _autores.Add(autor);
            }
        }

        private void btnQuitarAutor_Click(object sender, EventArgs e)
        {
            if (dgvAutores.CurrentRow?.DataBoundItem is AutorComboDto autor)
            {
                _autores.Remove(autor);
            }
        }

        private void btnAgregarTema_Click(object sender, EventArgs e)
        {
            using (frmSeleccionarTema frm = _serviceProvider.GetRequiredService<frmSeleccionarTema>())
            {
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                var tema = frm.GetTema();
                if (tema is null) return;
                //no se puede repetir un tema en un libro
                if (_temas.Any(t => t.TemaId == tema.TemaId))
                {
                    _servicioMensajes.Advertencia("Ese tema ya fue agregado al libro");
                    return;
                }
                _temas.Add(tema);
            }
        }

        private void btnQuitarTema_Click(object sender, EventArgs e)
        {
            if (dgvTemas.CurrentRow?.DataBoundItem is TemaComboDto tema)
            {
                _temas.Remove(tema);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    var autoresIds = _autores.Select(a => a.AutorId).ToList();
                    var temasIds = _temas.Select(t => t.TemaId).ToList();
                    bool esFisico = cboTipo.SelectedIndex == 0;
                    if (!_esEdicion)
                    {

                        var _libroCreateDto = new LibroCreateDto();
                        _libroCreateDto.Tipo = esFisico ? TipoLibro.Fisico : TipoLibro.Digital;
                        _libroCreateDto.Titulo = txtTitulo.Text.Trim();
                        _libroCreateDto.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                        _libroCreateDto.AnioPublicacion = (int)nudAnioPublicacion.Value;
                        _libroCreateDto.Precio = nudPrecio.Value;
                        _libroCreateDto.EditorialId = (int)cboEditorial.SelectedValue!;
                        _libroCreateDto.AutoresIds = autoresIds;
                        _libroCreateDto.TemasIds = temasIds;
                        if (esFisico)
                        {
                            _libroCreateDto.Isbn = LibroFisico.NormalizarIsbn(txtIsbn.Text);
                            _libroCreateDto.Stock = (int)nudStock.Value;
                        }
                        else
                        {
                            _libroCreateDto.Identificador = txtIdentificador.Text.Trim();
                            _libroCreateDto.Formato = txtFormato.Text.Trim();
                            _libroCreateDto.TamanoArchivo = (long)nudTamanoArchivo.Value;
                            _libroCreateDto.UrlDescarga = txtUrlDescarga.Text.Trim();
                        }
                        var resultadoAgregar = _libroServicio.Agregar(_libroCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        if (_servicioMensajes.Confirmar("Registro agregado ¿Desea agregar otro?"))
                        {
                            InicializarControles();
                        }
                        else
                        {
                            DialogResult = DialogResult.OK;
                        }

                    }
                    else
                    {
                        if (_libroUpdateDto is null)
                        {
                            _libroUpdateDto = new LibroUpdateDto();
                        }
                        _libroUpdateDto.Titulo = txtTitulo.Text.Trim();
                        _libroUpdateDto.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                        _libroUpdateDto.AnioPublicacion = (int)nudAnioPublicacion.Value;
                        _libroUpdateDto.Precio = nudPrecio.Value;
                        _libroUpdateDto.EditorialId = (int)cboEditorial.SelectedValue!;
                        _libroUpdateDto.AutoresIds = autoresIds;
                        _libroUpdateDto.TemasIds = temasIds;
                        _libroUpdateDto.Activo = chkActivo.Checked;
                        if (esFisico)
                        {
                            _libroUpdateDto.Isbn = LibroFisico.NormalizarIsbn(txtIsbn.Text);
                            _libroUpdateDto.Stock = (int)nudStock.Value;
                        }
                        else
                        {
                            _libroUpdateDto.Identificador = txtIdentificador.Text.Trim();
                            _libroUpdateDto.Formato = txtFormato.Text.Trim();
                            _libroUpdateDto.TamanoArchivo = (long)nudTamanoArchivo.Value;
                            _libroUpdateDto.UrlDescarga = txtUrlDescarga.Text.Trim();
                        }

                        var resultadoEditar = _libroServicio
                            .Editar(_libroUpdateDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            _servicioMensajes.Errores(resultadoEditar.Errors);

                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;
                        }
                        if (resultadoEditar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        _servicioMensajes.Informacion("Registro editado correctamente");
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void InicializarControles()
        {
            txtTitulo.Clear();
            txtDescripcion.Clear();
            nudAnioPublicacion.Value = DateTime.Today.Year;
            nudPrecio.Value = 0;
            cboEditorial.SelectedIndex = 0;
            txtIsbn.Clear();
            nudStock.Value = 0;
            txtIdentificador.Clear();
            txtFormato.Clear();
            nudTamanoArchivo.Value = 1;
            txtUrlDescarga.Clear();
            _autores.Clear();
            _temas.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            txtTitulo.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                valido = false;
                errorProvider.SetError(txtTitulo, "El titulo es requerido");
            }
            else if (txtTitulo.Text.Length > 100)
            {
                valido = false;
                errorProvider.SetError(txtTitulo, "El titulo no puede tener más de 100 caracteres");
            }
            if (txtDescripcion.Text.Length > 250)
            {
                valido = false;
                errorProvider.SetError(txtDescripcion, "La descripcion no puede tener mas de 250 caracteres");
            }
            if (nudPrecio.Value <= 0)
            {
                valido = false;
                errorProvider.SetError(nudPrecio, "El precio debe ser mayor que cero");
            }
            if (cboEditorial.SelectedIndex <= 0)
            {
                valido = false;
                errorProvider.SetError(cboEditorial, "Debe seleccionar una editorial");
            }
            if (_autores.Count == 0)
            {
                valido = false;
                errorProvider.SetError(dgvAutores, "Debe seleccionar al menos un autor");
            }
            if (_temas.Count == 0)
            {
                valido = false;
                errorProvider.SetError(dgvTemas, "Debe seleccionar al menos un tema");
            }
            if (cboTipo.SelectedIndex == 0)
            {
                // libro fisico
                if (string.IsNullOrWhiteSpace(txtIsbn.Text))
                {
                    valido = false;
                    errorProvider.SetError(txtIsbn, "El ISBN es requerido");
                }
                else if (!LibroFisico.EsIsbnValido(LibroFisico.NormalizarIsbn(txtIsbn.Text)))
                {
                    valido = false;
                    errorProvider.SetError(txtIsbn, "El ISBN debe tener 10 o 13 digitos");
                }
            }
            else
            {
                // libro digital
                if (string.IsNullOrWhiteSpace(txtIdentificador.Text))
                {
                    valido = false;
                    errorProvider.SetError(txtIdentificador, "El identificador es requerido");
                }
                if (string.IsNullOrWhiteSpace(txtFormato.Text))
                {
                    valido = false;
                    errorProvider.SetError(txtFormato, "El formato es requerido");
                }
                if (string.IsNullOrWhiteSpace(txtUrlDescarga.Text))
                {
                    valido = false;
                    errorProvider.SetError(txtUrlDescarga, "La URL de descarga es necesaria");
                }
                else if (!Uri.TryCreate(txtUrlDescarga.Text.Trim(), UriKind.Absolute, out var uri) ||
                    (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps))
                {
                    valido = false;
                    errorProvider.SetError(txtUrlDescarga, "La URL de descarga no es válida (debe empezar con http:// o https://)");
                }
            }
            return valido;
        }

        public void SetLibro(LibroUpdateDto? libroEditDto)
        {
            _libroUpdateDto = libroEditDto;
        }
        public LibroUpdateDto? GetLibro()
        {
            return _libroUpdateDto;
        }
    }
}
