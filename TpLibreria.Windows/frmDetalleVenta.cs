using TpLibreria.Servicios.DTOs.Venta;

namespace TpLibreria.Windows
{
    public partial class frmDetalleVenta : Form
    {
        private BindingSource _bindingSource = new BindingSource();

        public frmDetalleVenta()
        {
            InitializeComponent();
            dgvDetalle.DataSource = _bindingSource;
        }

        public void SetVenta(VentaDetailDto venta)
        {
            lblCliente.Text = venta.Cliente;
            lblFecha.Text = venta.Fecha.ToString("dd/MM/yyyy HH:mm");
            lblTipoVenta.Text = venta.TipoVenta;
            lblEstado.Text = venta.Estado;
            lblTotal.Text = venta.ImporteTotal.ToString("C2");
            _bindingSource.DataSource = venta.DetalleVentas;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
