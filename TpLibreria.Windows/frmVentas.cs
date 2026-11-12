using TpLibreria.Entidades.Enums;
using TpLibreria.Servicios.DTOs.Venta;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Windows
{
    public partial class frmVentas : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        //para paginar
        private EstadoNavegacion _estado = new(10);
        //para ordenar (las ventas se muestran de la mas nueva a la mas vieja)
        private string campoOrdenar = "Fecha";
        private bool esAscendente = false;
        //para filtrar
        private EstadoVenta? filtroEstado = null;
        private string? textoBuscar = null;

        public frmVentas(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmVentas_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var servicio = scope.ServiceProvider
                    .GetRequiredService<IVentaServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = servicio
                        .ObtenerPagina(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroEstado,
                            textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = servicio
                            .ObtenerPagina(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroEstado,
                                textoBuscar);

                        if (resultadoConsulta.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;

                        _estado.Actualizar(resultado.CantidadRegistros);
                    }

                    _bindingSource.DataSource = resultado.Items;

                    lblCantidad.Text = _estado.TextoRegistros();
                    lblPaginas.Text = _estado.TextoPaginas();

                    btnPrimero.Enabled = _estado.PuedeIrAnterior();
                    btnAnterior.Enabled = _estado.PuedeIrAnterior();
                    btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
                    btnUltimo.Enabled = _estado.PuedeIrSiguiente();
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        // Las ventas anuladas se muestran en gris tachado para distinguirlas
        private void dgvDatos_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgvDatos.Rows.Count) return;
            if (dgvDatos.Rows[e.RowIndex].DataBoundItem is VentaListDto venta &&
                venta.Estado == EstadoVenta.Anulada.ToString())
            {
                e.CellStyle!.ForeColor = Color.Gray;
                e.CellStyle.Font = new Font(dgvDatos.Font, FontStyle.Strikeout);
            }
        }

        private void tsmiPendientes_Click(object sender, EventArgs e)
        {
            filtroEstado = EstadoVenta.Pendiente;
            tsbFiltrar.BackColor = Color.FromArgb(255, 213, 79);
            ActualizarInformacion();
        }

        private void tsmiFacturadas_Click(object sender, EventArgs e)
        {
            filtroEstado = EstadoVenta.Facturada;
            tsbFiltrar.BackColor = Color.FromArgb(255, 213, 79);
            ActualizarInformacion();
        }

        private void tsmiAnuladas_Click(object sender, EventArgs e)
        {
            filtroEstado = EstadoVenta.Anulada;
            tsbFiltrar.BackColor = Color.FromArgb(255, 213, 79);
            ActualizarInformacion();
        }

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroEstado = null;
            textoBuscar = null;
            txtBuscar.Clear();
            tsbFiltrar.BackColor = tsHerramientas.BackColor;
            tsbBuscar.BackColor = tsHerramientas.BackColor;

            ActualizarInformacion();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmVentaAe frm = scope.ServiceProvider.GetRequiredService<frmVentaAe>())
                {
                    frm.Text = "Nueva Venta";
                    if (frm.ShowDialog(this) != DialogResult.OK) return;
                    VentaCreateDto? ventaDto = frm.GetVenta();
                    if (ventaDto is null) return;
                    try
                    {
                        var servicio = scope.ServiceProvider
                            .GetRequiredService<IVentaServicio>();
                        var resultadoAgregar = servicio.Agregar(ventaDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            _servicioMensajes.Errores(resultadoAgregar.Errors);
                            return;
                        }
                        var nuevoId = resultadoAgregar.Value;
                        // una venta nueva siempre está pendiente
                        bool sePuedeVer = filtroEstado is null || filtroEstado == EstadoVenta.Pendiente;
                        if (sePuedeVer)
                        {
                            var resultado = servicio.ObtenerPaginaRegistro(nuevoId,
                                _estado.RegistrosPorPagina, filtroEstado, textoBuscar);
                            if (resultado.IsFailure)
                            {
                                _servicioMensajes.Errores(resultado.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultado.Value;
                        }
                        RecargarGrilla();
                        _servicioMensajes.Informacion("Venta registrada correctamente");
                        if (sePuedeVer)
                        {
                            var nuevoRegistro = _bindingSource.List
                                .Cast<VentaListDto>()
                                .FirstOrDefault(x => x.VentaId == nuevoId);
                            if (nuevoRegistro is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(nuevoRegistro);
                        }
                        else
                        {
                            _servicioMensajes.Advertencia("Los registros agregados no se pueden mostrar por condicion de filtro o busqueda");
                        }
                    }
                    catch (Exception ex)
                    {
                        _servicioMensajes.Error(ex.Message);
                    }
                }
            }
        }

        private void tsbFacturar_Click(object sender, EventArgs e)
        {
            VentaListDto? listDto = _bindingSource
                .ObtenerSeleccionado<VentaListDto>(_servicioMensajes);
            if (listDto is null) return;
            if (listDto.Estado != EstadoVenta.Pendiente.ToString())
            {
                _servicioMensajes.Advertencia("Solamente se pueden facturar ventas pendientes");
                return;
            }
            if (!_servicioMensajes.Confirmar($"¿Confirma la facturacion de la venta de {listDto.Cliente} del {listDto.Fecha:dd/MM/yyyy HH:mm}?")) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var servicio = scope.ServiceProvider
                        .GetRequiredService<IVentaServicio>();
                    var resultado = servicio.Facturar(listDto.VentaId);
                    if (resultado.IsConcurrencyConflict)
                    {
                        _servicioMensajes.Errores(resultado.Errors);
                        RecargarGrilla();
                        return;
                    }
                    if (resultado.IsFailure)
                    {
                        _servicioMensajes.Errores(resultado.Errors);
                        return;
                    }
                    _servicioMensajes.Informacion("Venta faturada satisfactoriamente");
                    RecargarGrilla();
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void tsbAnular_Click(object sender, EventArgs e)
        {
            VentaListDto? listDto = _bindingSource
                .ObtenerSeleccionado<VentaListDto>(_servicioMensajes);
            if (listDto is null) return;
            if (listDto.Estado != EstadoVenta.Pendiente.ToString())
            {
                _servicioMensajes.Advertencia("Solamnte se pueden anular ventas pendientes");
                return;
            }
            using (var scope = _serviceProvider.CreateScope())
            {
                var servicio = scope.ServiceProvider
                        .GetRequiredService<IVentaServicio>();
                if (!_servicioMensajes.Confirmar($"¿Desea anular la venta de {listDto.Cliente} del {listDto.Fecha:dd/MM/yyyy HH:mm}? Se devolverá el stock de los libros fisicos")) return;
                try
                {
                    var resultadoAnulacion = servicio.AnularVenta(listDto.VentaId);
                    if (resultadoAnulacion.IsConcurrencyConflict)
                    {
                        _servicioMensajes.Errores(resultadoAnulacion.Errors);
                        RecargarGrilla();
                        return;
                    }
                    if (resultadoAnulacion.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoAnulacion.Errors);
                        return;
                    }
                    _servicioMensajes.Informacion("Venta anulada correctamente");
                    RecargarGrilla();
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            VentaListDto? listDto = _bindingSource
                .ObtenerSeleccionado<VentaListDto>(_servicioMensajes);
            if (listDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var servicio = scope.ServiceProvider
                        .GetRequiredService<IVentaServicio>();
                    var resultadoConsulta = servicio.ObtenerPorId(listDto.VentaId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    using (frmDetalleVenta frm = scope.ServiceProvider
                        .GetRequiredService<frmDetalleVenta>())
                    {
                        frm.SetVenta(resultadoConsulta.Value!);
                        frm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _estado.PrimeraPagina();
            RecargarGrilla();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _estado.PaginaAnterior();
            RecargarGrilla();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _estado.PaginaSiguiente();
            RecargarGrilla();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _estado.UltimaPagina();
            RecargarGrilla();
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                _servicioMensajes.Advertencia("Debe ingresar datos para hacer la busqueda");
                return;
            }
            textoBuscar = txtBuscar.Text.Trim();
            tsbBuscar.BackColor = Color.FromArgb(255, 213, 79);
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }
    }
}
