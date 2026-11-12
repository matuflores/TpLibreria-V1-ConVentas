using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Editorial;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Windows
{
    public partial class frmEditoriales : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        private EstadoNavegacion _estado = new(10);
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;

        public frmEditoriales(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEditoriales_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var servicio = scope.ServiceProvider
                    .GetRequiredService<IEditorialServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = servicio
                        .ObtenerPagina(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo, textoBuscar);

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
                                filtroActivo, textoBuscar);

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

        private void tsmiActivos_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            tsbFiltrar.BackColor = Color.FromArgb(255, 213, 79);
            ActualizarInformacion();

        }


        private void tsmiNoActivos_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
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
            filtroActivo = null;
            tsbFiltrar.BackColor = tsHerramientas.BackColor;
            textoBuscar = null;
            txtBuscar.Clear();
            tsbBuscar.BackColor = tsHerramientas.BackColor;

            ActualizarInformacion();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            EditorialListDto? listDto = _bindingSource
                .ObtenerSeleccionado<EditorialListDto>(_servicioMensajes);
            if (listDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var servicio = scope.ServiceProvider
                        .GetRequiredService<IEditorialServicio>();
                var resultadoConsulta = servicio.ObtenerParaBorrar(listDto.EditorialId);
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    return;

                }
                var deleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar la editorial {listDto.Nombre}?")) return;
                if (deleteDto is null) return;
                try
                {
                    var resultadoEliminacion = servicio
                        .Borrar(deleteDto);
                    if (resultadoEliminacion.IsConcurrencyConflict)
                    {
                        _servicioMensajes.Errores(resultadoEliminacion.Errors);
                        RecargarGrilla();
                        return;

                    }
                    if (resultadoEliminacion.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoEliminacion.Errors);
                        return;

                    }
                    _servicioMensajes.Informacion("Registro eliminado correctamente");
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmEditorialAe frm = scope.ServiceProvider.GetRequiredService<frmEditorialAe>())
                {
                    frm.Text = "Nueva Editorial";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var servicio = scope.ServiceProvider
                                .GetRequiredService<IEditorialServicio>();
                            var resultado = servicio.ObtenerPaginaRegistro(nuevoId,
                                _estado.RegistrosPorPagina, filtroActivo, textoBuscar);
                            if (resultado.IsFailure)
                            {
                                _servicioMensajes.Errores(resultado.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultado.Value;
                        }
                        RecargarGrilla();
                        if (sePuedeVer)
                        {
                            var nuevoRegistro = _bindingSource.List
                                .Cast<EditorialListDto>()
                                .FirstOrDefault(x => x.EditorialId == nuevoId);
                            if (nuevoRegistro is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(nuevoRegistro);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("Los registros agregados no se pueden mostrar por condicion de filtro o busqueda");
                        }
                    }

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            EditorialListDto? listDto = _bindingSource
                .ObtenerSeleccionado<EditorialListDto>(_servicioMensajes);
            if (listDto is null) return;
            var seleccionadoId = listDto.EditorialId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var servicio = scope.ServiceProvider
                        .GetRequiredService<IEditorialServicio>();
                    var resultadoConsulta = servicio
                        .ObtenerParaEditar(seleccionadoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var editDto = resultadoConsulta.Value;
                    using (frmEditorialAe frm = scope.ServiceProvider
                        .GetRequiredService<frmEditorialAe>())
                    {
                        frm.Text = "Editar Editorial";
                        frm.SetEditorial(editDto);
                        frm.ShowDialog();
                        var editado = frm.GetEditorial();
                        if (editado is null) return;
                        if (!frm.DataChanged && !frm.ConcurrencyConflict) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == editado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = servicio
                                .ObtenerPaginaRegistro(seleccionadoId, _estado.RegistrosPorPagina,
                                filtroActivo, textoBuscar);
                            if (resultadoPagina.IsFailure)
                            {
                                _servicioMensajes.Errores(resultadoPagina.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultadoPagina.Value;
                        }

                        RecargarGrilla();
                        if (sePuedeVer)
                        {
                            var registroEditado = _bindingSource.List
                                .Cast<EditorialListDto>()
                                .FirstOrDefault(x => x.EditorialId == seleccionadoId);
                            if (registroEditado is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(registroEditado);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("El registro editado no se puede mostrar por condicion de filtro o busqueda");

                        }
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
                _servicioMensajes.Advertencia("Debe poner un texto para efectuar la busqueda");
                return;
            }
            textoBuscar = txtBuscar.Text.Trim();
            tsbBuscar.BackColor = Color.FromArgb(255, 213, 79);
            _estado.PaginaActual = 1;
            RecargarGrilla();

        }
    }
}
