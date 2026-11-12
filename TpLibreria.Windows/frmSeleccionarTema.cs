using TpLibreria.Servicios.DTOs.Tema;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    //agregado para solucionar el futuro problemas de muchos datos y no poder seleccionar el tema que se quiere agregar a un libro
    
    //En este frm busca por texto y pagina, igual que las listas del sistema,
    // y devuelve el tema elegido. Lo abre frmLibroAe con el botón "Agregar".
    public partial class frmSeleccionarTema : Form
    {
        private readonly ITemaServicio _temaServicio;
        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new();
        // 15 registros por pag
        private EstadoNavegacion _estado = new(15);
        private string? _textoBuscar = null;
        private TemaComboDto? _tema;

        public frmSeleccionarTema(ITemaServicio temaServicio)
        {
            InitializeComponent();
            _temaServicio = temaServicio;
            dgvDatos.DataSource = _bindingSource;
        }

        public TemaComboDto? GetTema()
        {
            return _tema;
        }

        private void frmSeleccionarTema_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
                int paginaSolicitada = _estado.PaginaActual;

                var resultadoConsulta = _temaServicio.ObtenerPagina(
                    paginaSolicitada,
                    _estado.RegistrosPorPagina,
                    "Nombre",
                    true,
                    _textoBuscar);

                if (resultadoConsulta.IsFailure)
                {
                    _servicioMensajes.Errores(resultadoConsulta.Errors);
                    return;
                }

                var resultado = resultadoConsulta.Value!;

                _estado.Actualizar(resultado.CantidadRegistros);

                if (_estado.PaginaActual != paginaSolicitada)
                {
                    resultadoConsulta = _temaServicio.ObtenerPagina(
                        _estado.PaginaActual,
                        _estado.RegistrosPorPagina,
                        "Nombre",
                        true,
                        _textoBuscar);

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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _textoBuscar = string.IsNullOrWhiteSpace(txtBuscar.Text) ? null : txtBuscar.Text.Trim();
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            _textoBuscar = null;
            _estado.PaginaActual = 1;
            RecargarGrilla();
            txtBuscar.Focus();
        }

        // Con Enter en el cuadro de texto se busca (no hace falta tocar el btn)
        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnBuscar_Click(sender, e);//
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

        private void dgvDatos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            btnOK_Click(sender, e);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            var listDto = _bindingSource
                .ObtenerSeleccionado<TemaListDto>(_servicioMensajes);
            if (listDto is null) return;
            _tema = new TemaComboDto
            {
                TemaId = listDto.TemaId,
                Nombre = listDto.Nombre
            };
            DialogResult = DialogResult.OK;
        }
    }
}
