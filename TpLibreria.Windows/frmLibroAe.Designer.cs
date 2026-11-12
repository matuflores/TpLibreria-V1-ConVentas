namespace TpLibreria.Windows
{
    partial class frmLibroAe
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
            lblTipo = new Label();
            cboTipo = new ComboBox();
            lblTitulo = new Label();
            txtTitulo = new TextBox();
            lblDescripcion = new Label();
            txtDescripcion = new TextBox();
            lblAnioPublicacion = new Label();
            nudAnioPublicacion = new NumericUpDown();
            lblPrecio = new Label();
            nudPrecio = new NumericUpDown();
            lblEditorial = new Label();
            cboEditorial = new ComboBox();
            chkActivo = new CheckBox();
            gpbLibroFisico = new GroupBox();
            lblIsbn = new Label();
            txtIsbn = new TextBox();
            lblStock = new Label();
            nudStock = new NumericUpDown();
            gpbLibroDigital = new GroupBox();
            lblIdentificador = new Label();
            txtIdentificador = new TextBox();
            lblFormato = new Label();
            txtFormato = new TextBox();
            lblTamanoArchivo = new Label();
            nudTamanoArchivo = new NumericUpDown();
            lblUrlDescarga = new Label();
            txtUrlDescarga = new TextBox();
            lblAutores = new Label();
            dgvAutores = new DataGridView();
            colAutor = new DataGridViewTextBoxColumn();
            btnAgregarAutor = new Button();
            btnQuitarAutor = new Button();
            lblTemas = new Label();
            dgvTemas = new DataGridView();
            colTema = new DataGridViewTextBoxColumn();
            btnAgregarTema = new Button();
            btnQuitarTema = new Button();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)nudAnioPublicacion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTamanoArchivo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTemas).BeginInit();
            gpbLibroFisico.SuspendLayout();
            gpbLibroDigital.SuspendLayout();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Location = new Point(20, 23);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(98, 15);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Tipo de libro:";
            // 
            // cboTipo
            // 
            cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipo.FormattingEnabled = true;
            cboTipo.Location = new Point(150, 20);
            cboTipo.Name = "cboTipo";
            cboTipo.Size = new Size(250, 23);
            cboTipo.TabIndex = 0;
            cboTipo.Items.AddRange(new object[] { "Libro físico", "Libro digital" });
            cboTipo.SelectedIndexChanged += cboTipo_SelectedIndexChanged;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(20, 58);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(49, 15);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Título:";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(150, 55);
            txtTitulo.MaxLength = 100;
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(250, 23);
            txtTitulo.TabIndex = 1;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(20, 93);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(84, 15);
            lblDescripcion.TabIndex = 0;
            lblDescripcion.Text = "Descripción:";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(150, 90);
            txtDescripcion.MaxLength = 250;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(250, 60);
            txtDescripcion.TabIndex = 2;
            txtDescripcion.Multiline = true;
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            // 
            // lblAnioPublicacion
            // 
            lblAnioPublicacion.AutoSize = true;
            lblAnioPublicacion.Location = new Point(20, 168);
            lblAnioPublicacion.Name = "lblAnioPublicacion";
            lblAnioPublicacion.Size = new Size(133, 15);
            lblAnioPublicacion.TabIndex = 0;
            lblAnioPublicacion.Text = "Año de publicación:";
            // 
            // nudAnioPublicacion
            // 
            nudAnioPublicacion.Location = new Point(150, 165);
            nudAnioPublicacion.Maximum = new decimal(new int[] { 9999, 0, 0, 0 });
            nudAnioPublicacion.Minimum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudAnioPublicacion.Name = "nudAnioPublicacion";
            nudAnioPublicacion.Size = new Size(100, 23);
            nudAnioPublicacion.TabIndex = 3;
            nudAnioPublicacion.TextAlign = HorizontalAlignment.Right;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(20, 203);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(49, 15);
            lblPrecio.TabIndex = 0;
            lblPrecio.Text = "Precio:";
            // 
            // nudPrecio
            // 
            nudPrecio.Location = new Point(150, 200);
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Increment = new decimal(new int[] { 1, 0, 0, 0 });
            nudPrecio.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(100, 23);
            nudPrecio.TabIndex = 4;
            nudPrecio.TextAlign = HorizontalAlignment.Right;
            // 
            // lblEditorial
            // 
            lblEditorial.AutoSize = true;
            lblEditorial.Location = new Point(20, 238);
            lblEditorial.Name = "lblEditorial";
            lblEditorial.Size = new Size(70, 15);
            lblEditorial.TabIndex = 0;
            lblEditorial.Text = "Editorial:";
            // 
            // cboEditorial
            // 
            cboEditorial.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEditorial.FormattingEnabled = true;
            cboEditorial.Location = new Point(150, 235);
            cboEditorial.Name = "cboEditorial";
            cboEditorial.Size = new Size(250, 23);
            cboEditorial.TabIndex = 5;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(150, 272);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(80, 19);
            chkActivo.TabIndex = 6;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // gpbLibroFisico
            // 
            gpbLibroFisico.Controls.Add(lblIsbn);
            gpbLibroFisico.Controls.Add(txtIsbn);
            gpbLibroFisico.Controls.Add(lblStock);
            gpbLibroFisico.Controls.Add(nudStock);
            gpbLibroFisico.Location = new Point(20, 305);
            gpbLibroFisico.Name = "gpbLibroFisico";
            gpbLibroFisico.Size = new Size(380, 95);
            gpbLibroFisico.TabIndex = 7;
            gpbLibroFisico.TabStop = false;
            gpbLibroFisico.Text = "Datos del libro físico";
            // 
            // lblIsbn
            // 
            lblIsbn.AutoSize = true;
            lblIsbn.Location = new Point(15, 33);
            lblIsbn.Name = "lblIsbn";
            lblIsbn.Size = new Size(35, 15);
            lblIsbn.TabIndex = 0;
            lblIsbn.Text = "ISBN:";
            // 
            // txtIsbn
            // 
            txtIsbn.Location = new Point(130, 30);
            txtIsbn.MaxLength = 17;
            txtIsbn.Name = "txtIsbn";
            txtIsbn.Size = new Size(230, 23);
            txtIsbn.TabIndex = 0;
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(15, 63);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(42, 15);
            lblStock.TabIndex = 0;
            lblStock.Text = "Stock:";
            // 
            // nudStock
            // 
            nudStock.Location = new Point(130, 60);
            nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(100, 23);
            nudStock.TabIndex = 1;
            nudStock.TextAlign = HorizontalAlignment.Right;
            // 
            // gpbLibroDigital
            // 
            gpbLibroDigital.Controls.Add(lblIdentificador);
            gpbLibroDigital.Controls.Add(txtIdentificador);
            gpbLibroDigital.Controls.Add(lblFormato);
            gpbLibroDigital.Controls.Add(txtFormato);
            gpbLibroDigital.Controls.Add(lblTamanoArchivo);
            gpbLibroDigital.Controls.Add(nudTamanoArchivo);
            gpbLibroDigital.Controls.Add(lblUrlDescarga);
            gpbLibroDigital.Controls.Add(txtUrlDescarga);
            gpbLibroDigital.Location = new Point(20, 410);
            gpbLibroDigital.Name = "gpbLibroDigital";
            gpbLibroDigital.Size = new Size(380, 190);
            gpbLibroDigital.TabIndex = 8;
            gpbLibroDigital.TabStop = false;
            gpbLibroDigital.Text = "Datos del libro digital";
            // 
            // lblIdentificador
            // 
            lblIdentificador.AutoSize = true;
            lblIdentificador.Location = new Point(15, 33);
            lblIdentificador.Name = "lblIdentificador";
            lblIdentificador.Size = new Size(98, 15);
            lblIdentificador.TabIndex = 0;
            lblIdentificador.Text = "Identificador:";
            // 
            // txtIdentificador
            // 
            txtIdentificador.Location = new Point(130, 30);
            txtIdentificador.MaxLength = 50;
            txtIdentificador.Name = "txtIdentificador";
            txtIdentificador.Size = new Size(230, 23);
            txtIdentificador.TabIndex = 0;
            // 
            // lblFormato
            // 
            lblFormato.AutoSize = true;
            lblFormato.Location = new Point(15, 68);
            lblFormato.Name = "lblFormato";
            lblFormato.Size = new Size(56, 15);
            lblFormato.TabIndex = 0;
            lblFormato.Text = "Formato:";
            // 
            // txtFormato
            // 
            txtFormato.Location = new Point(130, 65);
            txtFormato.MaxLength = 20;
            txtFormato.Name = "txtFormato";
            txtFormato.Size = new Size(120, 23);
            txtFormato.TabIndex = 1;
            // 
            // lblTamanoArchivo
            // 
            lblTamanoArchivo.AutoSize = true;
            lblTamanoArchivo.Location = new Point(15, 103);
            lblTamanoArchivo.Name = "lblTamanoArchivo";
            lblTamanoArchivo.Size = new Size(84, 15);
            lblTamanoArchivo.TabIndex = 0;
            lblTamanoArchivo.Text = "Tamaño (KB):";
            // 
            // nudTamanoArchivo
            // 
            nudTamanoArchivo.Location = new Point(130, 100);
            nudTamanoArchivo.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            nudTamanoArchivo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudTamanoArchivo.Name = "nudTamanoArchivo";
            nudTamanoArchivo.Size = new Size(120, 23);
            nudTamanoArchivo.TabIndex = 2;
            nudTamanoArchivo.TextAlign = HorizontalAlignment.Right;
            // 
            // lblUrlDescarga
            // 
            lblUrlDescarga.AutoSize = true;
            lblUrlDescarga.Location = new Point(15, 138);
            lblUrlDescarga.Name = "lblUrlDescarga";
            lblUrlDescarga.Size = new Size(112, 15);
            lblUrlDescarga.TabIndex = 0;
            lblUrlDescarga.Text = "URL de descarga:";
            // 
            // txtUrlDescarga
            // 
            txtUrlDescarga.Location = new Point(130, 135);
            txtUrlDescarga.MaxLength = 250;
            txtUrlDescarga.Name = "txtUrlDescarga";
            txtUrlDescarga.Size = new Size(230, 23);
            txtUrlDescarga.TabIndex = 3;
            // 
            // lblAutores
            // 
            lblAutores.AutoSize = true;
            lblAutores.Location = new Point(440, 20);
            lblAutores.Name = "lblAutores";
            lblAutores.Size = new Size(140, 15);
            lblAutores.TabIndex = 0;
            lblAutores.Text = "Autores (uno o más):";
            // 
            // dgvAutores
            // 
            dgvAutores.Columns.AddRange(new DataGridViewColumn[] { colAutor });
            dgvAutores.AllowUserToAddRows = false;
            dgvAutores.AllowUserToDeleteRows = false;
            dgvAutores.AllowUserToResizeRows = false;
            dgvAutores.AutoGenerateColumns = false;
            dgvAutores.ColumnHeadersHeight = 30;
            dgvAutores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAutores.MultiSelect = false;
            dgvAutores.Name = "dgvAutores";
            dgvAutores.ReadOnly = true;
            dgvAutores.RowHeadersVisible = false;
            dgvAutores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAutores.Location = new Point(440, 45);
            dgvAutores.Size = new Size(380, 170);
            dgvAutores.TabIndex = 9;
            dgvAutores.BorderStyle = BorderStyle.FixedSingle;
            // 
            // colAutor
            // 
            colAutor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colAutor.DataPropertyName = "NombreCompleto";
            colAutor.FillWeight = 100F;
            colAutor.HeaderText = "Autor";
            colAutor.MinimumWidth = 60;
            colAutor.Name = "colAutor";
            colAutor.ReadOnly = true;
            // 
            // btnAgregarAutor
            // 
            btnAgregarAutor.Location = new Point(440, 222);
            btnAgregarAutor.Name = "btnAgregarAutor";
            btnAgregarAutor.Size = new Size(90, 28);
            btnAgregarAutor.TabIndex = 10;
            btnAgregarAutor.Text = "Agregar";
            btnAgregarAutor.UseVisualStyleBackColor = true;
            btnAgregarAutor.Click += btnAgregarAutor_Click;
            // 
            // btnQuitarAutor
            // 
            btnQuitarAutor.Location = new Point(540, 222);
            btnQuitarAutor.Name = "btnQuitarAutor";
            btnQuitarAutor.Size = new Size(90, 28);
            btnQuitarAutor.TabIndex = 11;
            btnQuitarAutor.Text = "Quitar";
            btnQuitarAutor.UseVisualStyleBackColor = true;
            btnQuitarAutor.Click += btnQuitarAutor_Click;
            // 
            // lblTemas
            // 
            lblTemas.AutoSize = true;
            lblTemas.Location = new Point(440, 265);
            lblTemas.Name = "lblTemas";
            lblTemas.Size = new Size(126, 15);
            lblTemas.TabIndex = 0;
            lblTemas.Text = "Temas (uno o más):";
            // 
            // dgvTemas
            // 
            dgvTemas.Columns.AddRange(new DataGridViewColumn[] { colTema });
            dgvTemas.AllowUserToAddRows = false;
            dgvTemas.AllowUserToDeleteRows = false;
            dgvTemas.AllowUserToResizeRows = false;
            dgvTemas.AutoGenerateColumns = false;
            dgvTemas.ColumnHeadersHeight = 30;
            dgvTemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTemas.MultiSelect = false;
            dgvTemas.Name = "dgvTemas";
            dgvTemas.ReadOnly = true;
            dgvTemas.RowHeadersVisible = false;
            dgvTemas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemas.Location = new Point(440, 290);
            dgvTemas.Size = new Size(380, 150);
            dgvTemas.TabIndex = 12;
            dgvTemas.BorderStyle = BorderStyle.FixedSingle;
            // 
            // colTema
            // 
            colTema.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colTema.DataPropertyName = "Nombre";
            colTema.FillWeight = 100F;
            colTema.HeaderText = "Tema";
            colTema.MinimumWidth = 60;
            colTema.Name = "colTema";
            colTema.ReadOnly = true;
            // 
            // btnAgregarTema
            // 
            btnAgregarTema.Location = new Point(440, 447);
            btnAgregarTema.Name = "btnAgregarTema";
            btnAgregarTema.Size = new Size(90, 28);
            btnAgregarTema.TabIndex = 13;
            btnAgregarTema.Text = "Agregar";
            btnAgregarTema.UseVisualStyleBackColor = true;
            btnAgregarTema.Click += btnAgregarTema_Click;
            // 
            // btnQuitarTema
            // 
            btnQuitarTema.Location = new Point(540, 447);
            btnQuitarTema.Name = "btnQuitarTema";
            btnQuitarTema.Size = new Size(90, 28);
            btnQuitarTema.TabIndex = 14;
            btnQuitarTema.Text = "Quitar";
            btnQuitarTema.UseVisualStyleBackColor = true;
            btnQuitarTema.Click += btnQuitarTema_Click;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(300, 625);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 58);
            btnOK.TabIndex = 15;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(420, 625);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 58);
            btnCancelar.TabIndex = 16;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmLibroAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            CancelButton = btnCancelar;
            ClientSize = new Size(840, 705);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Libro";
            Controls.Add(lblTipo);
            Controls.Add(cboTipo);
            Controls.Add(lblTitulo);
            Controls.Add(txtTitulo);
            Controls.Add(lblDescripcion);
            Controls.Add(txtDescripcion);
            Controls.Add(lblAnioPublicacion);
            Controls.Add(nudAnioPublicacion);
            Controls.Add(lblPrecio);
            Controls.Add(nudPrecio);
            Controls.Add(lblEditorial);
            Controls.Add(cboEditorial);
            Controls.Add(chkActivo);
            Controls.Add(gpbLibroFisico);
            Controls.Add(gpbLibroDigital);
            Controls.Add(lblAutores);
            Controls.Add(dgvAutores);
            Controls.Add(btnAgregarAutor);
            Controls.Add(btnQuitarAutor);
            Controls.Add(lblTemas);
            Controls.Add(dgvTemas);
            Controls.Add(btnAgregarTema);
            Controls.Add(btnQuitarTema);
            Controls.Add(btnOK);
            Controls.Add(btnCancelar);
            Name = "frmLibroAe";
            gpbLibroDigital.ResumeLayout(false);
            gpbLibroFisico.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTemas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAutores).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTamanoArchivo).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudAnioPublicacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipo;
        private ComboBox cboTipo;
        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblDescripcion;
        private TextBox txtDescripcion;
        private Label lblAnioPublicacion;
        private NumericUpDown nudAnioPublicacion;
        private Label lblPrecio;
        private NumericUpDown nudPrecio;
        private Label lblEditorial;
        private ComboBox cboEditorial;
        private CheckBox chkActivo;
        private GroupBox gpbLibroFisico;
        private Label lblIsbn;
        private TextBox txtIsbn;
        private Label lblStock;
        private NumericUpDown nudStock;
        private GroupBox gpbLibroDigital;
        private Label lblIdentificador;
        private TextBox txtIdentificador;
        private Label lblFormato;
        private TextBox txtFormato;
        private Label lblTamanoArchivo;
        private NumericUpDown nudTamanoArchivo;
        private Label lblUrlDescarga;
        private TextBox txtUrlDescarga;
        private Label lblAutores;
        private DataGridView dgvAutores;
        private DataGridViewTextBoxColumn colAutor;
        private Button btnAgregarAutor;
        private Button btnQuitarAutor;
        private Label lblTemas;
        private DataGridView dgvTemas;
        private DataGridViewTextBoxColumn colTema;
        private Button btnAgregarTema;
        private Button btnQuitarTema;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider;
    }
}
