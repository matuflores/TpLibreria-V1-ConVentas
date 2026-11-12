using TpLibreria.Windows.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Windows
{
    public partial class frmPrincipal : Form
    {
        private readonly IServiceProvider _serviceProvider;
        public frmPrincipal(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = $"{Sesion.UsuarioActual!.UserName}";
            lblFecha.Text = DateTime.Today.ToShortDateString();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditoriales_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmEditoriales>())
            {
                frm.Text = "Lista de Editoriales";
                frm.ShowDialog();
            }
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmAutores>())
            {
                frm.Text = "Lista de Autores";
                frm.ShowDialog();
            }
        }

        private void btnTemas_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmTemas>())
            {
                frm.Text = "Lista de Temas";
                frm.ShowDialog();
            }
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmLibros>())
            {
                frm.Text = "Lista de Libors";
                frm.ShowDialog();
            }
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmClientes>())
            {
                frm.Text = "Lista de Clientes";
                frm.ShowDialog();
            }
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmVentas>())
            {
                frm.Text = "Lista de Ventas";
                frm.ShowDialog();
            }
        }
    }
}
