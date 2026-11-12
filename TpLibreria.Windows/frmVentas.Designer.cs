namespace TpLibreria.Windows
{
    partial class frmVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle estiloFecha = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloCantidadLibros = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloImporteTotal = new DataGridViewCellStyle();
            scContenedor = new SplitContainer();
            dgvDatos = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colCliente = new DataGridViewTextBoxColumn();
            colTipoVenta = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            colCantidadLibros = new DataGridViewTextBoxColumn();
            colImporteTotal = new DataGridViewTextBoxColumn();
            lblCantidadDeRegistros = new Label();
            lblCantidadDePaginas = new Label();
            lblCantidad = new Label();
            lblPaginas = new Label();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            tsHerramientas = new ToolStrip();
            tsbNuevo = new ToolStripButton();
            tsbFacturar = new ToolStripButton();
            tsbAnular = new ToolStripButton();
            tssSeparador1 = new ToolStripSeparator();
            tsbDetalles = new ToolStripButton();
            tssSeparador2 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripDropDownButton();
            tsmiPendientes = new ToolStripMenuItem();
            tsmiFacturadas = new ToolStripMenuItem();
            tsmiAnuladas = new ToolStripMenuItem();
            tslBuscar = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            tssSeparador3 = new ToolStripSeparator();
            tsbCerrar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)scContenedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            scContenedor.Panel1.SuspendLayout();
            scContenedor.Panel2.SuspendLayout();
            scContenedor.SuspendLayout();
            tsHerramientas.SuspendLayout();
            SuspendLayout();
            // 
            // scContenedor
            // 
            scContenedor.Panel1.Controls.Add(dgvDatos);
            scContenedor.Panel2.Controls.Add(lblCantidadDeRegistros);
            scContenedor.Panel2.Controls.Add(lblCantidadDePaginas);
            scContenedor.Panel2.Controls.Add(lblCantidad);
            scContenedor.Panel2.Controls.Add(lblPaginas);
            scContenedor.Panel2.Controls.Add(btnPrimero);
            scContenedor.Panel2.Controls.Add(btnAnterior);
            scContenedor.Panel2.Controls.Add(btnSiguiente);
            scContenedor.Panel2.Controls.Add(btnUltimo);
            scContenedor.Dock = DockStyle.Fill;
            scContenedor.FixedPanel = FixedPanel.Panel2;
            scContenedor.IsSplitterFixed = true;
            scContenedor.Location = new Point(0, 70);
            scContenedor.Name = "scContenedor";
            scContenedor.Orientation = Orientation.Horizontal;
            scContenedor.Size = new Size(960, 530);
            scContenedor.SplitterDistance = 464;
            scContenedor.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colFecha, colCliente, colTipoVenta, colEstado, colCantidadLibros, colImporteTotal });
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.ColumnHeadersHeight = 30;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(960, 464);
            dgvDatos.TabIndex = 0;
            dgvDatos.CellFormatting += dgvDatos_CellFormatting;
            // 
            // colFecha
            // 
            estiloFecha.Alignment = DataGridViewContentAlignment.MiddleCenter;
            estiloFecha.Format = "dd/MM/yyyy HH:mm";
            colFecha.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colFecha.DataPropertyName = "Fecha";
            colFecha.DefaultCellStyle = estiloFecha;
            colFecha.HeaderText = "Fecha";
            colFecha.MinimumWidth = 60;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 130;
            // 
            // colCliente
            // 
            colCliente.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colCliente.DataPropertyName = "Cliente";
            colCliente.FillWeight = 40F;
            colCliente.HeaderText = "Cliente";
            colCliente.MinimumWidth = 60;
            colCliente.Name = "colCliente";
            colCliente.ReadOnly = true;
            // 
            // colTipoVenta
            // 
            colTipoVenta.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTipoVenta.DataPropertyName = "TipoVenta";
            colTipoVenta.HeaderText = "Tipo";
            colTipoVenta.MinimumWidth = 60;
            colTipoVenta.Name = "colTipoVenta";
            colTipoVenta.ReadOnly = true;
            colTipoVenta.Width = 90;
            // 
            // colEstado
            // 
            colEstado.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colEstado.DataPropertyName = "Estado";
            colEstado.HeaderText = "Estado";
            colEstado.MinimumWidth = 60;
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            colEstado.Width = 100;
            // 
            // colCantidadLibros
            // 
            estiloCantidadLibros.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCantidadLibros.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCantidadLibros.DataPropertyName = "CantidadLibros";
            colCantidadLibros.DefaultCellStyle = estiloCantidadLibros;
            colCantidadLibros.HeaderText = "Libros";
            colCantidadLibros.MinimumWidth = 60;
            colCantidadLibros.Name = "colCantidadLibros";
            colCantidadLibros.ReadOnly = true;
            colCantidadLibros.Width = 70;
            // 
            // colImporteTotal
            // 
            estiloImporteTotal.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloImporteTotal.Format = "C2";
            colImporteTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colImporteTotal.DataPropertyName = "ImporteTotal";
            colImporteTotal.DefaultCellStyle = estiloImporteTotal;
            colImporteTotal.HeaderText = "Total";
            colImporteTotal.MinimumWidth = 60;
            colImporteTotal.Name = "colImporteTotal";
            colImporteTotal.ReadOnly = true;
            colImporteTotal.Width = 120;
            // 
            // lblCantidadDeRegistros
            // 
            lblCantidadDeRegistros.AutoSize = true;
            lblCantidadDeRegistros.Location = new Point(20, 12);
            lblCantidadDeRegistros.Name = "lblCantidadDeRegistros";
            lblCantidadDeRegistros.Size = new Size(125, 15);
            lblCantidadDeRegistros.TabIndex = 0;
            lblCantidadDeRegistros.Text = "Cantidad de Registros:";
            // 
            // lblCantidadDePaginas
            // 
            lblCantidadDePaginas.AutoSize = true;
            lblCantidadDePaginas.Location = new Point(20, 34);
            lblCantidadDePaginas.Name = "lblCantidadDePaginas";
            lblCantidadDePaginas.Size = new Size(112, 15);
            lblCantidadDePaginas.TabIndex = 1;
            lblCantidadDePaginas.Text = "Cantidad de Páginas:";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCantidad.Location = new Point(160, 12);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(14, 15);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "0";
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPaginas.Location = new Point(160, 34);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(14, 15);
            lblPaginas.TabIndex = 3;
            lblPaginas.Text = "0";
            // 
            // btnPrimero
            // 
            btnPrimero.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(756, 10);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(41, 38);
            btnPrimero.TabIndex = 4;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(803, 10);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(41, 38);
            btnAnterior.TabIndex = 5;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSiguiente.Image = Properties.Resources.next_24px;
            btnSiguiente.Location = new Point(850, 10);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(41, 38);
            btnSiguiente.TabIndex = 6;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUltimo.Image = Properties.Resources.last_24px;
            btnUltimo.Location = new Point(897, 10);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(41, 38);
            btnUltimo.TabIndex = 7;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // tsHerramientas
            // 
            tsHerramientas.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbFacturar, tsbAnular, tssSeparador1, tsbDetalles, tssSeparador2, tsbFiltrar, tslBuscar, txtBuscar, tsbBuscar, tsbActualizar, tssSeparador3, tsbCerrar });
            tsHerramientas.GripStyle = ToolStripGripStyle.Hidden;
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Size = new Size(960, 70);
            tsHerramientas.TabIndex = 0;
            tsHerramientas.Text = "tsHerramientas";
            // 
            // tsbNuevo
            // 
            tsbNuevo.Image = Properties.Resources.new_file_48px;
            tsbNuevo.ImageScaling = ToolStripItemImageScaling.None;
            tsbNuevo.ImageTransparentColor = Color.Magenta;
            tsbNuevo.Name = "tsbNuevo";
            tsbNuevo.Size = new Size(52, 67);
            tsbNuevo.Text = "&Nueva";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbFacturar
            // 
            tsbFacturar.Image = Properties.Resources.edit_file_48px;
            tsbFacturar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFacturar.ImageTransparentColor = Color.Magenta;
            tsbFacturar.Name = "tsbFacturar";
            tsbFacturar.Size = new Size(52, 67);
            tsbFacturar.Text = "&Facturar";
            tsbFacturar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbFacturar.Click += tsbFacturar_Click;
            // 
            // tsbAnular
            // 
            tsbAnular.Image = Properties.Resources.delete_file_48px;
            tsbAnular.ImageScaling = ToolStripItemImageScaling.None;
            tsbAnular.ImageTransparentColor = Color.Magenta;
            tsbAnular.Name = "tsbAnular";
            tsbAnular.Size = new Size(52, 67);
            tsbAnular.Text = "&Anular";
            tsbAnular.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbAnular.Click += tsbAnular_Click;
            // 
            // tssSeparador1
            // 
            tssSeparador1.Name = "tssSeparador1";
            tssSeparador1.Size = new Size(6, 70);
            // 
            // tsbDetalles
            // 
            tsbDetalles.Image = Properties.Resources.details_48px;
            tsbDetalles.ImageScaling = ToolStripItemImageScaling.None;
            tsbDetalles.ImageTransparentColor = Color.Magenta;
            tsbDetalles.Name = "tsbDetalles";
            tsbDetalles.Size = new Size(52, 67);
            tsbDetalles.Text = "&Detalles";
            tsbDetalles.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbDetalles.Click += tsbDetalles_Click;
            // 
            // tssSeparador2
            // 
            tssSeparador2.Name = "tssSeparador2";
            tssSeparador2.Size = new Size(6, 70);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { tsmiPendientes, tsmiFacturadas, tsmiAnuladas });
            tsbFiltrar.Image = Properties.Resources.filled_filter_48px;
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(61, 67);
            tsbFiltrar.Text = "&Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsmiPendientes
            // 
            tsmiPendientes.Name = "tsmiPendientes";
            tsmiPendientes.Size = new Size(140, 22);
            tsmiPendientes.Text = "Pendientes";
            tsmiPendientes.Click += tsmiPendientes_Click;
            // 
            // tsmiFacturadas
            // 
            tsmiFacturadas.Name = "tsmiFacturadas";
            tsmiFacturadas.Size = new Size(140, 22);
            tsmiFacturadas.Text = "Facturadas";
            tsmiFacturadas.Click += tsmiFacturadas_Click;
            // 
            // tsmiAnuladas
            // 
            tsmiAnuladas.Name = "tsmiAnuladas";
            tsmiAnuladas.Size = new Size(140, 22);
            tsmiAnuladas.Text = "Anuladas";
            tsmiAnuladas.Click += tsmiAnuladas_Click;
            // 
            // tslBuscar
            // 
            tslBuscar.Name = "tslBuscar";
            tslBuscar.Size = new Size(45, 67);
            tslBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(160, 70);
            // 
            // tsbBuscar
            // 
            tsbBuscar.Image = Properties.Resources.search_property_48px;
            tsbBuscar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBuscar.ImageTransparentColor = Color.Magenta;
            tsbBuscar.Name = "tsbBuscar";
            tsbBuscar.Size = new Size(52, 67);
            tsbBuscar.Text = "B&uscar";
            tsbBuscar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBuscar.Click += tsbBuscar_Click;
            // 
            // tsbActualizar
            // 
            tsbActualizar.Image = Properties.Resources.restart_48px;
            tsbActualizar.ImageScaling = ToolStripItemImageScaling.None;
            tsbActualizar.ImageTransparentColor = Color.Magenta;
            tsbActualizar.Name = "tsbActualizar";
            tsbActualizar.Size = new Size(63, 67);
            tsbActualizar.Text = "&Actualizar";
            tsbActualizar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbActualizar.Click += tsbActualizar_Click;
            // 
            // tssSeparador3
            // 
            tssSeparador3.Name = "tssSeparador3";
            tssSeparador3.Size = new Size(6, 70);
            // 
            // tsbCerrar
            // 
            tsbCerrar.Image = Properties.Resources.close_pane_48px;
            tsbCerrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbCerrar.ImageTransparentColor = Color.Magenta;
            tsbCerrar.Name = "tsbCerrar";
            tsbCerrar.Size = new Size(52, 67);
            tsbCerrar.Text = "&Cerrar";
            tsbCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbCerrar.Click += tsbCerrar_Click;
            // 
            // frmVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            ClientSize = new Size(960, 600);
            MinimumSize = new Size(800, 420);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Ventas";
            Controls.Add(scContenedor);
            Controls.Add(tsHerramientas);
            Name = "frmVentas";
            Load += frmVentas_Load;
            tsHerramientas.ResumeLayout(false);
            tsHerramientas.PerformLayout();
            scContenedor.Panel1.ResumeLayout(false);
            scContenedor.Panel2.ResumeLayout(false);
            scContenedor.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)scContenedor).EndInit();
            scContenedor.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer scContenedor;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colCliente;
        private DataGridViewTextBoxColumn colTipoVenta;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridViewTextBoxColumn colCantidadLibros;
        private DataGridViewTextBoxColumn colImporteTotal;
        private Label lblCantidadDeRegistros;
        private Label lblCantidadDePaginas;
        private Label lblCantidad;
        private Label lblPaginas;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltimo;
        private ToolStrip tsHerramientas;
        private ToolStripButton tsbNuevo;
        private ToolStripButton tsbFacturar;
        private ToolStripButton tsbAnular;
        private ToolStripSeparator tssSeparador1;
        private ToolStripButton tsbDetalles;
        private ToolStripSeparator tssSeparador2;
        private ToolStripDropDownButton tsbFiltrar;
        private ToolStripMenuItem tsmiPendientes;
        private ToolStripMenuItem tsmiFacturadas;
        private ToolStripMenuItem tsmiAnuladas;
        private ToolStripLabel tslBuscar;
        private ToolStripTextBox txtBuscar;
        private ToolStripButton tsbBuscar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator tssSeparador3;
        private ToolStripButton tsbCerrar;
    }
}
