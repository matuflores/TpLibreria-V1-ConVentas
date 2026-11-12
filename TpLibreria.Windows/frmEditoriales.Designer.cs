namespace TpLibreria.Windows
{
    partial class frmEditoriales
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
            scContenedor = new SplitContainer();
            dgvDatos = new DataGridView();
            colNombre = new DataGridViewTextBoxColumn();
            colPaisOrigen = new DataGridViewTextBoxColumn();
            colActivo = new DataGridViewCheckBoxColumn();
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
            tsbBorrar = new ToolStripButton();
            tsbEditar = new ToolStripButton();
            tssSeparador1 = new ToolStripSeparator();
            tsbFiltrar = new ToolStripDropDownButton();
            tsmiActivos = new ToolStripMenuItem();
            tsmiNoActivos = new ToolStripMenuItem();
            tslBuscar = new ToolStripLabel();
            txtBuscar = new ToolStripTextBox();
            tsbBuscar = new ToolStripButton();
            tsbActualizar = new ToolStripButton();
            tssSeparador2 = new ToolStripSeparator();
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
            scContenedor.Size = new Size(900, 530);
            scContenedor.SplitterDistance = 464;
            scContenedor.TabIndex = 1;
            // 
            // dgvDatos
            // 
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colNombre, colPaisOrigen, colActivo });
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
            dgvDatos.Size = new Size(900, 464);
            dgvDatos.TabIndex = 0;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.FillWeight = 60F;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 60;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colPaisOrigen
            // 
            colPaisOrigen.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPaisOrigen.DataPropertyName = "PaisOrigen";
            colPaisOrigen.FillWeight = 40F;
            colPaisOrigen.HeaderText = "País de origen";
            colPaisOrigen.MinimumWidth = 60;
            colPaisOrigen.Name = "colPaisOrigen";
            colPaisOrigen.ReadOnly = true;
            // 
            // colActivo
            // 
            colActivo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colActivo.DataPropertyName = "Activo";
            colActivo.HeaderText = "Activo";
            colActivo.MinimumWidth = 60;
            colActivo.Name = "colActivo";
            colActivo.ReadOnly = true;
            colActivo.Width = 70;
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
            btnPrimero.Location = new Point(696, 10);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(41, 38);
            btnPrimero.TabIndex = 4;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(743, 10);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(41, 38);
            btnAnterior.TabIndex = 5;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSiguiente.Image = Properties.Resources.next_24px;
            btnSiguiente.Location = new Point(790, 10);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(41, 38);
            btnSiguiente.TabIndex = 6;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnUltimo.Image = Properties.Resources.last_24px;
            btnUltimo.Location = new Point(837, 10);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(41, 38);
            btnUltimo.TabIndex = 7;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // tsHerramientas
            // 
            tsHerramientas.Items.AddRange(new ToolStripItem[] { tsbNuevo, tsbBorrar, tsbEditar, tssSeparador1, tsbFiltrar, tslBuscar, txtBuscar, tsbBuscar, tsbActualizar, tssSeparador2, tsbCerrar });
            tsHerramientas.GripStyle = ToolStripGripStyle.Hidden;
            tsHerramientas.Location = new Point(0, 0);
            tsHerramientas.Name = "tsHerramientas";
            tsHerramientas.Size = new Size(900, 70);
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
            tsbNuevo.Text = "&Nuevo";
            tsbNuevo.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbNuevo.Click += tsbNuevo_Click;
            // 
            // tsbBorrar
            // 
            tsbBorrar.Image = Properties.Resources.delete_file_48px;
            tsbBorrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbBorrar.ImageTransparentColor = Color.Magenta;
            tsbBorrar.Name = "tsbBorrar";
            tsbBorrar.Size = new Size(52, 67);
            tsbBorrar.Text = "&Borrar";
            tsbBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbBorrar.Click += tsbBorrar_Click;
            // 
            // tsbEditar
            // 
            tsbEditar.Image = Properties.Resources.edit_file_48px;
            tsbEditar.ImageScaling = ToolStripItemImageScaling.None;
            tsbEditar.ImageTransparentColor = Color.Magenta;
            tsbEditar.Name = "tsbEditar";
            tsbEditar.Size = new Size(52, 67);
            tsbEditar.Text = "&Editar";
            tsbEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            tsbEditar.Click += tsbEditar_Click;
            // 
            // tssSeparador1
            // 
            tssSeparador1.Name = "tssSeparador1";
            tssSeparador1.Size = new Size(6, 70);
            // 
            // tsbFiltrar
            // 
            tsbFiltrar.DropDownItems.AddRange(new ToolStripItem[] { tsmiActivos, tsmiNoActivos });
            tsbFiltrar.Image = Properties.Resources.filled_filter_48px;
            tsbFiltrar.ImageScaling = ToolStripItemImageScaling.None;
            tsbFiltrar.ImageTransparentColor = Color.Magenta;
            tsbFiltrar.Name = "tsbFiltrar";
            tsbFiltrar.Size = new Size(61, 67);
            tsbFiltrar.Text = "&Filtrar";
            tsbFiltrar.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // tsmiActivos
            // 
            tsmiActivos.Name = "tsmiActivos";
            tsmiActivos.Size = new Size(140, 22);
            tsmiActivos.Text = "Activos";
            tsmiActivos.Click += tsmiActivos_Click;
            // 
            // tsmiNoActivos
            // 
            tsmiNoActivos.Name = "tsmiNoActivos";
            tsmiNoActivos.Size = new Size(140, 22);
            tsmiNoActivos.Text = "No activos";
            tsmiNoActivos.Click += tsmiNoActivos_Click;
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
            // tssSeparador2
            // 
            tssSeparador2.Name = "tssSeparador2";
            tssSeparador2.Size = new Size(6, 70);
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
            // frmEditoriales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            ClientSize = new Size(900, 600);
            MinimumSize = new Size(740, 420);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Editoriales";
            Controls.Add(scContenedor);
            Controls.Add(tsHerramientas);
            Name = "frmEditoriales";
            Load += frmEditoriales_Load;
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
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colPaisOrigen;
        private DataGridViewCheckBoxColumn colActivo;
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
        private ToolStripButton tsbBorrar;
        private ToolStripButton tsbEditar;
        private ToolStripSeparator tssSeparador1;
        private ToolStripDropDownButton tsbFiltrar;
        private ToolStripMenuItem tsmiActivos;
        private ToolStripMenuItem tsmiNoActivos;
        private ToolStripLabel tslBuscar;
        private ToolStripTextBox txtBuscar;
        private ToolStripButton tsbBuscar;
        private ToolStripButton tsbActualizar;
        private ToolStripSeparator tssSeparador2;
        private ToolStripButton tsbCerrar;
    }
}
