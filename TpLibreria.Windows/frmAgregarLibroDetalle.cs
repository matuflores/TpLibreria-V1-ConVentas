using TpLibreria.Servicios.DTOs.DetalleVenta;
using TpLibreria.Servicios.DTOs.Libro;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    public partial class frmAgregarLibroDetalle : Form
    {
        private List<LibroComboDto>? _listaLibros;
        private BindingSource _bindingSource = new BindingSource();
        private LibroComboDto? _libroSeleccionado;
        private DetalleVentaDto? _detalleVenta;
        private ServicioMensajes _servicioMensajes = new();

        public frmAgregarLibroDetalle()
        {
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
            cboTipo.SelectedIndex = 0;
        }

        internal void SetDatos(List<LibroComboDto>? librosParaVentas)
        {
            _listaLibros = librosParaVentas;
            Filtrar();
        }
        private void Filtrar()//carlos no lo desarrollo
        {
            if (_listaLibros is null) return;
            IEnumerable<LibroComboDto> libros = _listaLibros;
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                libros = libros.Where(l => l.Titulo.Contains(txtBuscar.Text.Trim(),
                    StringComparison.CurrentCultureIgnoreCase));
            }
            if (cboTipo.SelectedIndex == 1)
            {
                libros = libros.Where(l => l.EsFisico);
            }
            else if (cboTipo.SelectedIndex == 2)
            {
                libros = libros.Where(l => !l.EsFisico);
            }
            _bindingSource.DataSource = libros.ToList();
        }

        private void MostrarDatos(LibroComboDto libroDto)
        {
            txtLibro.Text = libroDto.Titulo;
            txtPrecioUnitario.Text = libroDto.Precio.ToString("C2");
            // Solo los libros físicos tienen stock. Carlos pone nudCantidad.Maximum = Stock y no cambia el mínimo (que es 0), así se podía "comprar" 0 unidades. Acá el mínimo es 1
            nudCantidad.Maximum = libroDto.EsFisico ? Math.Max(1, libroDto.Stock) : 100;//esto quiere decir que si es fisico el maximo es el stock y si no es fisico el maximo es 100
            nudCantidad.Value = 1; //aca pone el valor minimo en 1, para que no se pueda poner 0
            txtPrecioTotal.Text = libroDto.Precio.ToString("C2");
        }

        private void LimpiarDatos()
        {
            txtLibro.Clear();
            txtPrecioUnitario.Clear();
            txtPrecioTotal.Clear();
            nudCantidad.Value = 1;
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            if (_libroSeleccionado is null) return;
            txtPrecioTotal.Text = (_libroSeleccionado.Precio * nudCantidad.Value).ToString("C2");//C2 quiere decir que es un formato de moneda con 2 decimales, por ejemplo $100.00
        }

        private void dgvDatos_SelectionChanged(object sender, EventArgs e)
        {
            _libroSeleccionado = _bindingSource.Current as LibroComboDto;
            if (_libroSeleccionado is null)
            {
                LimpiarDatos();
                return;
            }
            MostrarDatos(_libroSeleccionado);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void cboTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _detalleVenta = new DetalleVentaDto
                {
                    LibroId = _libroSeleccionado!.LibroId,
                    Libro = _libroSeleccionado.Titulo,
                    Tipo = _libroSeleccionado.Tipo,
                    PrecioUnitario = _libroSeleccionado.Precio,
                    Cantidad = (int)nudCantidad.Value,
                    Stock = _libroSeleccionado.Stock
                };
                DialogResult = DialogResult.OK;
            }
        }

        public DetalleVentaDto? GetDetalleVenta()
        {
            return _detalleVenta;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider.Clear();
            if (_libroSeleccionado is null)
            {
                valido = false;
                errorProvider.SetError(txtLibro, "Debe seleccionar un libro de la grilla");
            }
            else if (_libroSeleccionado.EsFisico && (_libroSeleccionado.Stock) < nudCantidad.Value)
            {
                valido = false;
                errorProvider.SetError(nudCantidad, "No hay stock suficiente de este libro");
            }
            return valido;
        }
    }
}
