using TpLibreria.Servicios.Common;
using TpLibreria.Servicios.DTOs.Autor;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;

namespace TpLibreria.Windows
{
    public partial class frmAutores : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        //para paginar
        private EstadoNavegacion _estado = new(10);
        //para ordenar
        private string campoOrdenar = "Apellido";
        private bool esAscendente = true;
        //para filtrar
        private string? textoBuscar = null;

        public frmAutores(IServiceProvider provider)
        {
            InitializeComponent();
            _serviceProvider = provider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAutores_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var servicio = scope.ServiceProvider
                    .GetRequiredService<IAutorServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = servicio
                        .ObtenerPagina(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
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

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            textoBuscar = null;
            txtBuscar.Clear();
            tsbBuscar.BackColor = tsHerramientas.BackColor;

            ActualizarInformacion();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            AutorListDto? listDto = _bindingSource
                .ObtenerSeleccionado<AutorListDto>(_servicioMensajes);
            if (listDto is null) return;
            using (var scope = _serviceProvider.CreateScope())
            {
                var servicio = scope.ServiceProvider
                        .GetRequiredService<IAutorServicio>();
                var resultadoConsulta = servicio.ObtenerParaBorrar(listDto.AutorId);
                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    return;

                }
                var deleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar al autor {listDto.NombreCompleto}?")) return;
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
                using (frmAutorAe frm = scope.ServiceProvider.GetRequiredService<frmAutorAe>())
                {
                    frm.Text = "Nuevo Autor";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = true;
                        if (sePuedeVer)
                        {
                            var servicio = scope.ServiceProvider
                                .GetRequiredService<IAutorServicio>();
                            var resultado = servicio.ObtenerPaginaRegistro(nuevoId,
                                _estado.RegistrosPorPagina, textoBuscar);
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
                                .Cast<AutorListDto>()
                                .FirstOrDefault(x => x.AutorId == nuevoId);
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
            AutorListDto? listDto = _bindingSource
                .ObtenerSeleccionado<AutorListDto>(_servicioMensajes);
            if (listDto is null) return;
            var seleccionadoId = listDto.AutorId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var servicio = scope.ServiceProvider
                        .GetRequiredService<IAutorServicio>();
                    var resultadoConsulta = servicio
                        .ObtenerParaEditar(seleccionadoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        _servicioMensajes.Errores(resultadoConsulta.Errors);
                        return;
                    }
                    var editDto = resultadoConsulta.Value;
                    using (frmAutorAe frm = scope.ServiceProvider
                        .GetRequiredService<frmAutorAe>())
                    {
                        frm.Text = "Editar Autor";
                        frm.SetAutor(editDto);
                        frm.ShowDialog();
                        var editado = frm.GetAutor();
                        if (editado is null) return;
                        //si no cambió nada ni hubo conflicto de concurrencia no hace falta recargar
                        if (!frm.DataChanged && !frm.ConcurrencyConflict) return;
                        bool sePuedeVer = true;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = servicio
                                .ObtenerPaginaRegistro(seleccionadoId, _estado.RegistrosPorPagina,
                                textoBuscar);
                            if (resultadoPagina.IsFailure)
                            {
                                _servicioMensajes.Errores(resultadoPagina.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultadoPagina.Value;
                        }

                        //si cambiaron los datos o hubo concurrencia se recarga la grilla
                        RecargarGrilla();
                        if (sePuedeVer)
                        {
                            var registroEditado = _bindingSource.List
                                .Cast<AutorListDto>()
                                .FirstOrDefault(x => x.AutorId == seleccionadoId);
                            if (registroEditado is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(registroEditado);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("El registro editado no se puede mostrar" +
                                "\npor condición de filtro o búsqueda");

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
                _servicioMensajes.Advertencia("Debe poner un texto para efectuar la búsqueda");
                return;
            }
            textoBuscar = txtBuscar.Text.Trim();
            tsbBuscar.BackColor = Color.FromArgb(255, 213, 79);
            _estado.PaginaActual = 1;
            RecargarGrilla();

        }
    }
}
