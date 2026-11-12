namespace TpLibreria.Windows
{
    partial class frmAgregarLibroDetalle
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
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle estiloStock = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloPrecio = new DataGridViewCellStyle();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            lblTipo = new Label();
            cboTipo = new ComboBox();
            scContenedor = new SplitContainer();
            dgvDatos = new DataGridView();
            colTipo = new DataGridViewTextBoxColumn();
            colTitulo = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            gpbSeleccion = new GroupBox();
            lblLibro = new Label();
            txtLibro = new TextBox();
            lblPrecioUnitario = new Label();
            txtPrecioUnitario = new TextBox();
            lblCantidad = new Label();
            nudCantidad = new NumericUpDown();
            lblPrecioTotal = new Label();
            txtPrecioTotal = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)scContenedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            scContenedor.Panel1.SuspendLayout();
            scContenedor.Panel2.SuspendLayout();
            scContenedor.SuspendLayout();
            gpbSeleccion.SuspendLayout();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(17, 13);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(42, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Libro:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(117, 10);
            txtBuscar.MaxLength = 100;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(305, 23);
            txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(472, 12);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 27);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(21, 49);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(98, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de libro:";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(117, 47);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(305, 23);
            cboTipo.TabIndex = 2;
            cboTipo.Items.AddRange(new object[] { "Todos", "Físico", "Digital" });
            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;
            // 
            // scContenedor
            // 
            scContenedor.Panel1.Controls.Add(dgvDatos);
            scContenedor.Panel2.Controls.Add(gpbSeleccion);
            scContenedor.FixedPanel = FixedPanel.Panel2;
            scContenedor.IsSplitterFixed = true;
            scContenedor.Location = new Point(0, 91);
            scContenedor.Name = "scContenedor";
            scContenedor.Orientation = Orientation.Horizontal;
            scContenedor.Size = new Size(800, 513);
            scContenedor.SplitterDistance = 367;
            scContenedor.TabIndex = 3;
            // 
            // dgvDatos
            // 
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colTipo, colTitulo, colStock, colPrecio });
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
            dgvDatos.Size = new Size(800, 367);
            dgvDatos.TabIndex = 0;
            dgvDatos.SelectionChanged += dgvDatos_SelectionChanged;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 60;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 90;
            // 
            // colTitulo
            // 
            colTitulo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTitulo.DataPropertyName = "Titulo";
            colTitulo.FillWeight = 100F;
            colTitulo.HeaderText = "Libro";
            colTitulo.MinimumWidth = 60;
            colTitulo.Name = "colTitulo";
            colTitulo.ReadOnly = true;
            // 
            // colStock
            // 
            estiloStock.Alignment = DataGridViewContentAlignment.MiddleRight;
            colStock.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colStock.DataPropertyName = "Stock";
            colStock.DefaultCellStyle = estiloStock;
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 60;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            colStock.Width = 80;
            // 
            // colPrecio
            // 
            estiloPrecio.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloPrecio.Format = "C2";
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPrecio.DataPropertyName = "Precio";
            colPrecio.DefaultCellStyle = estiloPrecio;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 60;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 110;
            // 
            // gpbSeleccion
            // 
            gpbSeleccion.Controls.Add(lblLibro);
            gpbSeleccion.Controls.Add(txtLibro);
            gpbSeleccion.Controls.Add(lblPrecioUnitario);
            gpbSeleccion.Controls.Add(txtPrecioUnitario);
            gpbSeleccion.Controls.Add(lblCantidad);
            gpbSeleccion.Controls.Add(nudCantidad);
            gpbSeleccion.Controls.Add(lblPrecioTotal);
            gpbSeleccion.Controls.Add(txtPrecioTotal);
            gpbSeleccion.Controls.Add(btnOK);
            gpbSeleccion.Controls.Add(btnCancelar);
            gpbSeleccion.Location = new Point(17, 6);
            gpbSeleccion.Name = "gpbSeleccion";
            gpbSeleccion.Size = new Size(776, 129);
            gpbSeleccion.TabIndex = 0;
            gpbSeleccion.TabStop = false;
            gpbSeleccion.Text = " Selección ";
            // 
            // lblLibro
            // 
            lblLibro.AutoSize = true;
            lblLibro.Location = new Point(13, 26);
            lblLibro.Name = "lblLibro";
            lblLibro.Size = new Size(42, 15);
            lblLibro.TabIndex = 0;
            lblLibro.Text = "Libro:";
            // 
            // txtLibro
            // 
            txtLibro.Enabled = false;
            txtLibro.Location = new Point(90, 22);
            txtLibro.Name = "txtLibro";
            txtLibro.Size = new Size(298, 23);
            txtLibro.TabIndex = 0;
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(13, 55);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(91, 15);
            lblPrecioUnitario.TabIndex = 0;
            lblPrecioUnitario.Text = "Precio Unit.:";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Enabled = false;
            txtPrecioUnitario.Location = new Point(90, 51);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(84, 23);
            txtPrecioUnitario.TabIndex = 1;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(227, 56);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(63, 15);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            nudCantidad.Location = new Point(293, 55);
            nudCantidad.Maximum = new decimal(new int[] { 100, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(95, 23);
            nudCantidad.TabIndex = 2;
            nudCantidad.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPrecioTotal
            // 
            lblPrecioTotal.AutoSize = true;
            lblPrecioTotal.Location = new Point(13, 84);
            lblPrecioTotal.Name = "lblPrecioTotal";
            lblPrecioTotal.Size = new Size(91, 15);
            lblPrecioTotal.TabIndex = 0;
            lblPrecioTotal.Text = "Precio Total:";
            // 
            // txtPrecioTotal
            // 
            txtPrecioTotal.Enabled = false;
            txtPrecioTotal.Location = new Point(90, 80);
            txtPrecioTotal.Name = "txtPrecioTotal";
            txtPrecioTotal.Size = new Size(84, 23);
            txtPrecioTotal.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(424, 26);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 4;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(525, 26);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmAgregarLibroDetalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            CancelButton = btnCancelar;
            ClientSize = new Size(800, 604);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Agregar Libro";
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(lblTipo);
            Controls.Add(cboTipo);
            Controls.Add(scContenedor);
            Name = "frmAgregarLibroDetalle";
            gpbSeleccion.ResumeLayout(false);
            gpbSeleccion.PerformLayout();
            scContenedor.Panel1.ResumeLayout(false);
            scContenedor.Panel2.ResumeLayout(false);
            scContenedor.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)scContenedor).EndInit();
            scContenedor.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Label lblTipo;
        private ComboBox cboTipo;
        private SplitContainer scContenedor;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colTitulo;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colPrecio;
        private GroupBox gpbSeleccion;
        private Label lblLibro;
        private TextBox txtLibro;
        private Label lblPrecioUnitario;
        private TextBox txtPrecioUnitario;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Label lblPrecioTotal;
        private TextBox txtPrecioTotal;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider;
    }
}
