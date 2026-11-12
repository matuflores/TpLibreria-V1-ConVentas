using TpLibreria.Entidades;
using TpLibreria.Windows.Classes;
using TpLibreria.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Windows
{
    public partial class frmLogin : Form
    {
        private readonly IServiceProvider _provider;
        private ServicioMensajes _servicioMensajes = new();
        public frmLogin(IServiceProvider provider)
        {
            InitializeComponent();
            _provider = provider;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                Usuario? usuario = UsuariosSistema.Usuarios
                    .FirstOrDefault(u => u.UserName == txtUsuario.Text &&
                        u.Password == txtClave.Text);
                if (usuario is null)
                {
                    _servicioMensajes.Advertencia("Usuario inexistente o datos no validos");
                    txtUsuario.SelectAll();
                    txtUsuario.Select();
                    return;
                }
                Sesion.UsuarioActual=usuario;
                this.Hide();
                frmPrincipal frm=_provider.GetRequiredService<frmPrincipal>();
                frm.ShowDialog();
                InicializarControles();
                this.Show();
            }
        }

        private void InicializarControles()
        {
            txtClave.Clear();
            txtUsuario.Clear();
            txtUsuario.Select();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider.Clear();
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                valido = false;
                errorProvider.SetError(txtUsuario, "El usuario es requerido");
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                valido = false;
                errorProvider.SetError(txtClave, "La clave es requerida");
            }
            return valido;
        }
    }
}
