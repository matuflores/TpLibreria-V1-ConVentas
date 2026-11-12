using TpLibreria.Servicios.DTOs.Autor;
using TpLibreria.Servicios.Interfaces;
using TpLibreria.Windows.Helpers;

namespace TpLibreria.Windows
{
    // Solucioin a la misma problematica del Tema
    public partial class frmSeleccionarAutor : Form
    {
        private readonly IAutorServicio _autorServicio;
        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new();
        // 15 registros por pag
        private EstadoNavegacion _estado = new(15);
        private string? _textoBuscar = null;
        private AutorComboDto? _autor;

        public frmSeleccionarAutor(IAutorServicio autorServicio)
        {
            InitializeComponent();
            _autorServicio = autorServicio;
            dgvDatos.DataSource = _bindingSource;
        }

        public AutorComboDto? GetAutor()
        {
            return _autor;
        }

        private void frmSeleccionarAutor_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            try
            {
                int paginaSolicitada = _estado.PaginaActual;

                var resultadoConsulta = _autorServicio.ObtenerPagina(
                    paginaSolicitada,
                    _estado.RegistrosPorPagina,
                    "Apellido",
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
                    resultadoConsulta = _autorServicio.ObtenerPagina(
                        _estado.PaginaActual,
                        _estado.RegistrosPorPagina,
                        "Apellido",
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
                btnBuscar_Click(sender, e);
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
                .ObtenerSeleccionado<AutorListDto>(_servicioMensajes);
            if (listDto is null) return;
            _autor = new AutorComboDto
            {
                AutorId = listDto.AutorId,
                NombreCompleto = listDto.NombreCompleto
            };
            DialogResult = DialogResult.OK;
        }
    }
}
