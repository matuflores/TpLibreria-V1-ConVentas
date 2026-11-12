using TpLibreria.Servicios.DTOs.Autor;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    public partial class frmAutorAe : Form
    {
        private AutorUpdateDto? _autorUpdateDto;
        private readonly IAutorServicio _autorServicio;
        private bool _esEdicion = false;
        private ServicioMensajes _servicioMensajes = new();
        public frmAutorAe(IAutorServicio autorServicio)
        {
            InitializeComponent();
            _autorServicio = autorServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dtpFechaNacimiento.MaxDate = DateTime.Today;
            if (_autorUpdateDto is null)
            {
                dtpFechaNacimiento.Value = DateTime.Today;
            }
            else
            {
                txtNombre.Text = _autorUpdateDto.Nombre;
                txtApellido.Text = _autorUpdateDto.Apellido;
                dtpFechaNacimiento.Value = _autorUpdateDto.FechaNacimiento;
                txtNacionalidad.Text = _autorUpdateDto.Nacionalidad;
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

                        var _autorCreateDto = new AutorCreateDto();
                        _autorCreateDto.Nombre = txtNombre.Text.Trim();
                        _autorCreateDto.Apellido = txtApellido.Text.Trim();
                        _autorCreateDto.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        _autorCreateDto.Nacionalidad = txtNacionalidad.Text.Trim();
                        var resultadoAgregar = _autorServicio.Agregar(_autorCreateDto);
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
                        if (_autorUpdateDto is null)
                        {
                            _autorUpdateDto = new AutorUpdateDto();
                        }
                        _autorUpdateDto.Nombre = txtNombre.Text.Trim();
                        _autorUpdateDto.Apellido = txtApellido.Text.Trim();
                        _autorUpdateDto.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        _autorUpdateDto.Nacionalidad = txtNacionalidad.Text.Trim();

                        var resultadoEditar = _autorServicio
                            .Editar(_autorUpdateDto);
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
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtNacionalidad.Clear();
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
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                valido = false;
                errorProvider.SetError(txtApellido, "El apellido es requerido");
            }
            else if (txtApellido.Text.Length > 50)
            {
                valido = false;
                errorProvider.SetError(txtApellido, "El apellido no puede tener más de 50 caracteres");
            }
            if (dtpFechaNacimiento.Value.Date > DateTime.Today)
            {
                valido = false;
                errorProvider.SetError(dtpFechaNacimiento, "La fecha de nacimiento no puede ser futura");
            }
            if (string.IsNullOrWhiteSpace(txtNacionalidad.Text))
            {
                valido = false;
                errorProvider.SetError(txtNacionalidad, "La nacionalidad es requerida");
            }
            else if (txtNacionalidad.Text.Length > 50)
            {
                valido = false;
                errorProvider.SetError(txtNacionalidad, "La nacionalidad no puede tener mas de 50 caracteres");
            }

            return valido;
        }

        public void SetAutor(AutorUpdateDto? autorEditDto)
        {
            _autorUpdateDto = autorEditDto;
        }
        public AutorUpdateDto? GetAutor()
        {
            return _autorUpdateDto;
        }
    }
}
