using TpLibreria.Servicios.DTOs.Editorial;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    public partial class frmEditorialAe : Form
    {
        private EditorialUpdateDto? _editorialUpdateDto;
        private readonly IEditorialServicio _editorialServicio;
        private bool _esEdicion = false;
        private ServicioMensajes _servicioMensajes = new();
        public frmEditorialAe(IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _editorialServicio = editorialServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_editorialUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
            }
            else
            {
                txtNombre.Text = _editorialUpdateDto.Nombre;
                txtPaisOrigen.Text = _editorialUpdateDto.PaisOrigen;
                chkActivo.Checked = _editorialUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
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
                    if (!_esEdicion)
                    {

                        var _editorialCreateDto = new EditorialCreateDto();
                        _editorialCreateDto.Nombre = txtNombre.Text.Trim();
                        _editorialCreateDto.PaisOrigen = txtPaisOrigen.Text.Trim();
                        var resultadoAgregar = _editorialServicio.Agregar(_editorialCreateDto);
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
                        if (_editorialUpdateDto is null)
                        {
                            _editorialUpdateDto = new EditorialUpdateDto();
                        }
                        _editorialUpdateDto.Nombre = txtNombre.Text.Trim();
                        _editorialUpdateDto.PaisOrigen = txtPaisOrigen.Text.Trim();
                        _editorialUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _editorialServicio
                            .Editar(_editorialUpdateDto);
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
            txtNombre.Clear();
            txtPaisOrigen.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
            txtNombre.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider.Clear();
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                valido = false;
                errorProvider.SetError(txtNombre, "El nombre es requerido");
            }
            else if (txtNombre.Text.Length > 100)
            {
                valido = false;
                errorProvider.SetError(txtNombre, "El nombre no puede tener más de 100 caracteres");
            }
            if (string.IsNullOrWhiteSpace(txtPaisOrigen.Text))
            {
                valido = false;
                errorProvider.SetError(txtPaisOrigen, "El pais de origen es requerido");
            }
            else if (txtPaisOrigen.Text.Length > 50)
            {
                valido = false;
                errorProvider.SetError(txtPaisOrigen, "El pais de origen no puede tener más de 50 caracteres");
            }

            return valido;
        }

        public void SetEditorial(EditorialUpdateDto? editorialEditDto)
        {
            _editorialUpdateDto = editorialEditDto;
        }
        public EditorialUpdateDto? GetEditorial()
        {
            return _editorialUpdateDto;
        }
    }
}
