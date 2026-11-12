using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.Cliente;
using TpLibreria.Servicios.DTOs.DetalleVenta;
using TpLibreria.Servicios.DTOs.Libro;
using TpLibreria.Servicios.DTOs.Venta;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Classes;
using TpLibreria.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Windows
{
    //el formulario me arma el createDto con la EditorialVenta. Lo guardo con servicio.agregar del ventas
    public partial class frmVentaAe : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILibroServicio _libroServicio;
        private readonly IClienteServicio _clienteServicio;
        private ServicioMensajes _servicioMensajes = new();
        private VentaCreateDto? _ventaDto;
        private EditorVenta _editorVenta = null!;
        private List<LibroComboDto>? _librosParaVentas;
        private BindingSource _bindingSource = new BindingSource();

        public bool DataChanged { get; private set; }

        public frmVentaAe(IServiceProvider serviceProvider,
            ILibroServicio libroServicio,
            IClienteServicio clienteServicio)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _libroServicio = libroServicio;
            _clienteServicio = clienteServicio;
            dgvDatos.DataSource = _bindingSource;
        }

        internal VentaCreateDto? GetVenta()
        {
            return _ventaDto;
        }

        private void frmVentaAe_Load(object sender, EventArgs e)
        {
            try
            {
                _ventaDto = new VentaCreateDto();
                _editorVenta = new EditorVenta(_ventaDto);

                // Solo vienen los libros que se pueden vender (activos y de una editorial activa)
                var resultadoConsulta = _libroServicio.ObtenerDatosCombo();
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    Close();
                    return;
                }
                _librosParaVentas = resultadoConsulta.Value;
                CargarComboClientes(cboClientes);
                cboTipoVenta.SelectedIndex = 0;
                txtFechaVta.Text = DateTime.Today.ToShortDateString();
                //aca como Carlos, nacen pendientes y después se facturan o se anulan
                txtEstado.Text = EstadoVenta.Pendiente.ToString();
                txtTotal.Text = 0m.ToString("C2");
            }
            catch (Exception ex)
            {
                _servicioMensajes.Error(ex.Message);
            }
        }

        private void CargarComboClientes(ComboBox cbo)
        {
            var resultado = _clienteServicio
                .ObtenerDatosCombo(ClienteDefault.Seleccione);
            if (resultado.IsFailure)
            {
                _servicioMensajes.Errores(resultado.Errors);
                return;
            }
            cbo.DataSource = resultado.Value;
            cbo.DisplayMember = "NombreCompleto";
            cbo.ValueMember = "ClienteId";
            cbo.SelectedIndex = 0;
        }

        private void cboClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboClientes.SelectedIndex > 0)
            {
                var clienteSeleccionado = (ClienteComboDto)cboClientes.SelectedItem!;
                txtEmail.Text = clienteSeleccionado.Email;
                txtTelefono.Text = clienteSeleccionado.Telefono;
            }
            else
            {
                txtEmail.Clear();
                txtTelefono.Clear();
            }
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            using (frmAgregarLibroDetalle frm = _serviceProvider
                .GetRequiredService<frmAgregarLibroDetalle>())
            {
                frm.Text = "Agregar Libro";
                frm.SetDatos(_librosParaVentas);
                if (frm.ShowDialog(this) != DialogResult.OK) return;
                DetalleVentaDto? detalleDto = frm.GetDetalleVenta();
                if (detalleDto is null) return;
                try
                {
                    _editorVenta.AgregarLibro(detalleDto);
                    MostrarDetalles(_editorVenta.ObtenerResumen());
                }
                catch (Exception ex)
                {
                    //aca carlos dejo solo un throw, pero si lo hago asi el programa se cae y no muestra el mensaje a la persona.
                    //throw;

                    // aca se muestra el mensaje al usuario.
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void MostrarDetalles((IReadOnlyCollection<DetalleVentaDto> Detalles,
            decimal Total) resumen)
        {
            _bindingSource.DataSource = resumen.Detalles.ToList();
            _bindingSource.ResetBindings(false);
            txtTotal.Text = resumen.Total.ToString("C2");
        }

        private void btnQuitarLibro_Click(object sender, EventArgs e)
        {
            var detalleDto = _bindingSource.ObtenerSeleccionado<DetalleVentaDto>(_servicioMensajes);
            if (detalleDto is null) return;
            if (!_servicioMensajes
                    .Confirmar($"¿Desea eliminar el detalle de {detalleDto.Libro}?")) return;
            try
            {
                _editorVenta.EliminarLibro(detalleDto.LibroId);
                MostrarDetalles(_editorVenta.ObtenerResumen());
            }
            catch (Exception ex)
            {
                _servicioMensajes.Error(ex.Message);
            }
        }

        private void btnEditarLibro_Click(object sender, EventArgs e)
        {
            // 1. Obtener el detalle seleccionado de la grilla
            var detalleDto = _bindingSource.ObtenerSeleccionado<DetalleVentaDto>(_servicioMensajes);
            if (detalleDto is null) return;
            bool esFisico = detalleDto.Tipo == "Físico";
            // 2. Mostrar el InputBox de Visual Basic (igual que el profe)
            string mensaje = esFisico
                ? $"Ingrese la nueva cantidad para el libro '{detalleDto.Libro}':\n(Stock disponible: {detalleDto.Stock})"
                : $"Ingrese la nueva cantidad para el libro '{detalleDto.Libro}':";
            string input = Microsoft.VisualBasic.Interaction.InputBox(
                mensaje,
                "Modificar Cantidad",
                detalleDto.Cantidad.ToString());

            // Si el usuario canceló o dejó el cuadro vacío, no hacemos nada
            if (string.IsNullOrWhiteSpace(input)) return;

            // 3. Validar que sea un número entero válido
            if (!int.TryParse(input, out int nuevaCantidad))
            {
                _servicioMensajes.Error("Debe ingresar un número entero válido.", "Error de formato");
                return;
            }

            // 4. Validar cantidad mayor a 0
            if (nuevaCantidad <= 0)
            {
                _servicioMensajes.Error("La cantidad debe ser mayor a cero.", "Validación");
                return;
            }
            // 5. Validar cantidad menor o igual al stock disponible.
            //cambio con Carlos: controla siempre contra el stock; aca solo se controla en los libros fisicos, porque los libros digitales no tienen stock (Stock = 0).
            if (esFisico && nuevaCantidad > detalleDto.Stock)//esto se usa mediante el uso del polimorfismo, ya que el detalleDto es de tipo DetalleVentaDto, pero en realidad es un DetalleVentaFisicoDto, que tiene la propiedad Stock. Si fuera un DetalleVentaDigitalDto, no tendria Stock y no se haría esta validacion.
            {
                _servicioMensajes.Advertencia($"La cantidad ingresada supera el stock disponible ({detalleDto.Stock}).", "Stock Insuficiente");
                return;
            }

            // 6. Actualizar en el editor de ventas y refrescar la grilla
            try
            {
                _editorVenta.ModificarCantidadDetalle(detalleDto.LibroId, nuevaCantidad);
                MostrarDetalles(_editorVenta.ObtenerResumen());
            }
            catch (Exception ex)
            {
                _servicioMensajes.Error(ex.Message, "Error al actualizar");
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
                _ventaDto!.ClienteId = ((ClienteComboDto)cboClientes.SelectedItem!).ClienteId;
                //tipo de venta (Presencial / Online), lo pide la consigna en el TP v1
                _ventaDto.TipoVenta = cboTipoVenta.SelectedIndex == 0
                    ? TipoVenta.Presencial : TipoVenta.Online;
                _ventaDto.Detalle = _editorVenta.ObtenerDetalles();
                _ventaDto.Total = _editorVenta.ObtenerResumen().Total;
                DataChanged = true;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider.Clear();
            if (cboClientes.SelectedIndex <= 0)
            {
                errorProvider.SetError(cboClientes, "Debe seleccionar un cliente");
                valido = false;
            }
            if (dgvDatos.Rows.Count == 0)
            {
                errorProvider.SetError(dgvDatos, "Debe agregar al mens un libro");
                valido = false;
            }
            return valido;
        }
    }
}
