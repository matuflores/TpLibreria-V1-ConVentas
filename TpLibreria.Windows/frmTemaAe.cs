using TpLibreria.Servicios.DTOs.Tema;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    public partial class frmTemaAe : Form
    {
        private TemaUpdateDto? _temaUpdateDto;
        private readonly ITemaServicio _temaServicio;
        private bool _esEdicion = false;
        private ServicioMensajes _servicioMensajes = new();
        public frmTemaAe(ITemaServicio temaServicio)
        {
            InitializeComponent();
            _temaServicio = temaServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }//Agregado para informar de conflicto de concurrencia
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_temaUpdateDto is null)
            {
            }
            else
            {
                txtNombre.Text = _temaUpdateDto.Nombre;
                txtDescripcion.Text = _temaUpdateDto.Descripcion;
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

                        var _temaCreateDto = new TemaCreateDto();
                        _temaCreateDto.Nombre = txtNombre.Text.Trim();
                        _temaCreateDto.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();
                        var resultadoAgregar = _temaServicio.Agregar(_temaCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        if (_servicioMensajes.Confirmar("Registro agregado\n¿Desea agregar otro?"))
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
                        if (_temaUpdateDto is null)
                        {
                            _temaUpdateDto = new TemaUpdateDto();
                        }
                        _temaUpdateDto.Nombre = txtNombre.Text.Trim();
                        _temaUpdateDto.Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim();

                        var resultadoEditar = _temaServicio
                            .Editar(_temaUpdateDto);
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
                        _servicioMensajes.Informacion("Registro editado satisfactoriamente");
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
            txtDescripcion.Clear();
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
            else if (txtNombre.Text.Length > 50)
            {
                valido = false;
                errorProvider.SetError(txtNombre, "El nombre no puede tener más de 50 caracteres");
            }
            if (txtDescripcion.Text.Length > 150)
            {
                valido = false;
                errorProvider.SetError(txtDescripcion, "La descripción no puede tener más de 150 caracteres");
            }

            return valido;
        }

        public void SetTema(TemaUpdateDto? temaEditDto)
        {
            _temaUpdateDto = temaEditDto;
        }
        public TemaUpdateDto? GetTema()
        {
            return _temaUpdateDto;
        }
    }
}
