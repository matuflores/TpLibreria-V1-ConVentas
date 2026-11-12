using TpLibreria.Servicios.DTOs.Cliente;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    public partial class frmClienteAe : Form
    {
        private ClienteUpdateDto? _clienteUpdateDto;
        private readonly IClienteServicio _clienteServicio;
        private bool _esEdicion = false;
        private ServicioMensajes _servicioMensajes = new();
        public frmClienteAe(IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _clienteServicio = clienteServicio;
        }
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_clienteUpdateDto is null)
            {
            }
            else
            {
                txtNombre.Text = _clienteUpdateDto.Nombre;
                txtApellido.Text = _clienteUpdateDto.Apellido;
                txtEmail.Text = _clienteUpdateDto.Email;
                txtTelefono.Text = _clienteUpdateDto.Telefono;
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

                        var _clienteCreateDto = new ClienteCreateDto();
                        _clienteCreateDto.Nombre = txtNombre.Text.Trim();
                        _clienteCreateDto.Apellido = txtApellido.Text.Trim();
                        _clienteCreateDto.Email = txtEmail.Text.Trim();
                        _clienteCreateDto.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();
                        var resultadoAgregar = _clienteServicio.Agregar(_clienteCreateDto);
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
                        if (_clienteUpdateDto is null)
                        {
                            _clienteUpdateDto = new ClienteUpdateDto();
                        }
                        _clienteUpdateDto.Nombre = txtNombre.Text.Trim();
                        _clienteUpdateDto.Apellido = txtApellido.Text.Trim();
                        _clienteUpdateDto.Email = txtEmail.Text.Trim();
                        _clienteUpdateDto.Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim();

                        var resultadoEditar = _clienteServicio
                            .Editar(_clienteUpdateDto);
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
                        _servicioMensajes.Informacion("Registro editado correctamentre");
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
            txtEmail.Clear();
            txtTelefono.Clear();
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
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                valido = false;
                errorProvider.SetError(txtEmail, "El email es requerido");
            }
            else if (txtEmail.Text.Length > 100)
            {
                valido = false;
                errorProvider.SetError(txtEmail, "El email no puede tener más de 100 caracteres");
            }
            else if (!EsEmailValido(txtEmail.Text.Trim()))
            {
                valido = false;
                errorProvider.SetError(txtEmail, "El email no tiene un formato valido");
            }
            if (txtTelefono.Text.Length > 20)
            {
                valido = false;
                errorProvider.SetError(txtTelefono, "El telefono no puede tener más de 20 caracteres");
            }

            return valido;
        }

        private static bool EsEmailValido(string email)
        {
            try
            {
                var direccion = new System.Net.Mail.MailAddress(email);
                return direccion.Address == email;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void SetCliente(ClienteUpdateDto? clienteEditDto)
        {
            _clienteUpdateDto = clienteEditDto;
        }
        public ClienteUpdateDto? GetCliente()
        {
            return _clienteUpdateDto;
        }
    }
}
