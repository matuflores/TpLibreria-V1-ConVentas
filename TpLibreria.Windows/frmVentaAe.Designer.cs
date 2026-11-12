namespace TpLibreria.Windows
{
    partial class frmVentaAe
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
            DataGridViewCellStyle estiloPrecio = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloCantidad = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloSubtotal = new DataGridViewCellStyle();
            lblCliente = new Label();
            cboClientes = new ComboBox();
            gpbCliente = new GroupBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblFecha = new Label();
            txtFechaVta = new TextBox();
            lblEstado = new Label();
            txtEstado = new TextBox();
            lblTipoVenta = new Label();
            cboTipoVenta = new ComboBox();
            scContenedor = new SplitContainer();
            dgvDatos = new DataGridView();
            colTipo = new DataGridViewTextBoxColumn();
            colLibro = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            btnAgregarLibro = new Button();
            btnEditarLibro = new Button();
            btnQuitarLibro = new Button();
            lblTotal = new Label();
            txtTotal = new TextBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)scContenedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            gpbCliente.SuspendLayout();
            scContenedor.Panel1.SuspendLayout();
            scContenedor.Panel2.SuspendLayout();
            scContenedor.SuspendLayout();
            SuspendLayout();
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(32, 15);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(56, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente:";
            // 
            // cboClientes
            // 
            cboClientes.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClientes.FormattingEnabled = true;
            cboClientes.Location = new Point(85, 12);
            cboClientes.Name = "cboClientes";
            cboClientes.Size = new Size(432, 23);
            cboClientes.TabIndex = 0;
            cboClientes.SelectedIndexChanged += cboClientes_SelectedIndexChanged;
            // 
            // gpbCliente
            // 
            gpbCliente.Controls.Add(lblEmail);
            gpbCliente.Controls.Add(txtEmail);
            gpbCliente.Controls.Add(lblTelefono);
            gpbCliente.Controls.Add(txtTelefono);
            gpbCliente.Location = new Point(32, 42);
            gpbCliente.Name = "gpbCliente";
            gpbCliente.Size = new Size(486, 85);
            gpbCliente.TabIndex = 1;
            gpbCliente.TabStop = false;
            gpbCliente.Text = " Datos del cliente ";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(14, 25);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(42, 15);
            lblEmail.TabIndex = 0;
            lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            txtEmail.ReadOnly = true;
            txtEmail.Location = new Point(90, 22);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(380, 23);
            txtEmail.TabIndex = 0;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(14, 54);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(63, 15);
            lblTelefono.TabIndex = 0;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            txtTelefono.ReadOnly = true;
            txtTelefono.Location = new Point(90, 51);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(380, 23);
            txtTelefono.TabIndex = 1;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(666, 15);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(42, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "Fecha:";
            // 
            // txtFechaVta
            // 
            txtFechaVta.ReadOnly = true;
            txtFechaVta.Location = new Point(731, 12);
            txtFechaVta.Name = "txtFechaVta";
            txtFechaVta.Size = new Size(130, 23);
            txtFechaVta.TabIndex = 2;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(666, 45);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(49, 15);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            txtEstado.ReadOnly = true;
            txtEstado.Location = new Point(731, 42);
            txtEstado.Name = "txtEstado";
            txtEstado.Size = new Size(130, 23);
            txtEstado.TabIndex = 3;
            // 
            // lblTipoVenta
            // 
            lblTipoVenta.AutoSize = true;
            lblTipoVenta.Location = new Point(640, 69);
            lblTipoVenta.Name = "lblTipoVenta";
            lblTipoVenta.Size = new Size(98, 15);
            lblTipoVenta.TabIndex = 0;
            lblTipoVenta.Text = "Tipo de venta:";
            // 
            // cboTipoVenta
            // 
            cboTipoVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cboTipoVenta.FormattingEnabled = true;
            cboTipoVenta.Location = new Point(731, 66);
            cboTipoVenta.Name = "cboTipoVenta";
            cboTipoVenta.Size = new Size(130, 23);
            cboTipoVenta.TabIndex = 3;
            cboTipoVenta.Items.AddRange(new object[] { "Presencial", "Online" });
            // 
            // scContenedor
            // 
            scContenedor.Panel1.Controls.Add(dgvDatos);
            scContenedor.Panel2.Controls.Add(btnAgregarLibro);
            scContenedor.Panel2.Controls.Add(btnEditarLibro);
            scContenedor.Panel2.Controls.Add(btnQuitarLibro);
            scContenedor.FixedPanel = FixedPanel.Panel2;
            scContenedor.Location = new Point(0, 133);
            scContenedor.Name = "scContenedor";
            scContenedor.Size = new Size(889, 304);
            scContenedor.SplitterDistance = 686;
            scContenedor.TabIndex = 5;
            // 
            // dgvDatos
            // 
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colTipo, colLibro, colPrecio, colCantidad, colSubtotal });
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
            dgvDatos.Size = new Size(686, 304);
            dgvDatos.TabIndex = 0;
            // 
            // colTipo
            // 
            colTipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colTipo.DataPropertyName = "Tipo";
            colTipo.HeaderText = "Tipo";
            colTipo.MinimumWidth = 60;
            colTipo.Name = "colTipo";
            colTipo.ReadOnly = true;
            colTipo.Width = 80;
            // 
            // colLibro
            // 
            colLibro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLibro.DataPropertyName = "Libro";
            colLibro.FillWeight = 100F;
            colLibro.HeaderText = "Libro";
            colLibro.MinimumWidth = 60;
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
            // 
            // colPrecio
            // 
            estiloPrecio.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloPrecio.Format = "C2";
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPrecio.DataPropertyName = "PrecioUnitario";
            colPrecio.DefaultCellStyle = estiloPrecio;
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 60;
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            colPrecio.Width = 100;
            // 
            // colCantidad
            // 
            estiloCantidad.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.DefaultCellStyle = estiloCantidad;
            colCantidad.HeaderText = "Cant.";
            colCantidad.MinimumWidth = 60;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 60;
            // 
            // colSubtotal
            // 
            estiloSubtotal.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloSubtotal.Format = "C2";
            colSubtotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colSubtotal.DataPropertyName = "Subtotal";
            colSubtotal.DefaultCellStyle = estiloSubtotal;
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.MinimumWidth = 60;
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            colSubtotal.Width = 110;
            // 
            // btnAgregarLibro
            // 
            btnAgregarLibro.Image = Properties.Resources.new_file_48px;
            btnAgregarLibro.Location = new Point(32, 26);
            btnAgregarLibro.Name = "btnAgregarLibro";
            btnAgregarLibro.Size = new Size(134, 60);
            btnAgregarLibro.TabIndex = 0;
            btnAgregarLibro.Text = "Agregar libro";
            btnAgregarLibro.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAgregarLibro.UseVisualStyleBackColor = true;
            btnAgregarLibro.Click += btnAgregarLibro_Click;
            // 
            // btnEditarLibro
            // 
            btnEditarLibro.Image = Properties.Resources.edit_file_48px;
            btnEditarLibro.Location = new Point(32, 101);
            btnEditarLibro.Name = "btnEditarLibro";
            btnEditarLibro.Size = new Size(134, 60);
            btnEditarLibro.TabIndex = 1;
            btnEditarLibro.Text = "Cambiar cantidad";
            btnEditarLibro.TextImageRelation = TextImageRelation.ImageAboveText;
            btnEditarLibro.UseVisualStyleBackColor = true;
            btnEditarLibro.Click += btnEditarLibro_Click;
            // 
            // btnQuitarLibro
            // 
            btnQuitarLibro.Image = Properties.Resources.delete_file_48px;
            btnQuitarLibro.Location = new Point(32, 176);
            btnQuitarLibro.Name = "btnQuitarLibro";
            btnQuitarLibro.Size = new Size(134, 60);
            btnQuitarLibro.TabIndex = 2;
            btnQuitarLibro.Text = "Quitar libro";
            btnQuitarLibro.TextImageRelation = TextImageRelation.ImageAboveText;
            btnQuitarLibro.UseVisualStyleBackColor = true;
            btnQuitarLibro.Click += btnQuitarLibro_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(535, 446);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(42, 15);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total:";
            // 
            // txtTotal
            // 
            txtTotal.ReadOnly = true;
            txtTotal.Location = new Point(585, 443);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(120, 23);
            txtTotal.TabIndex = 6;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(28, 486);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 7;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(759, 486);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmVentaAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            CancelButton = btnCancelar;
            ClientSize = new Size(889, 595);
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nueva Venta";
            Load += frmVentaAe_Load;
            Controls.Add(lblCliente);
            Controls.Add(cboClientes);
            Controls.Add(gpbCliente);
            Controls.Add(lblFecha);
            Controls.Add(txtFechaVta);
            Controls.Add(lblEstado);
            Controls.Add(txtEstado);
            Controls.Add(lblTipoVenta);
            Controls.Add(cboTipoVenta);
            Controls.Add(scContenedor);
            Controls.Add(lblTotal);
            Controls.Add(txtTotal);
            Controls.Add(btnOK);
            Controls.Add(btnCancelar);
            Name = "frmVentaAe";
            scContenedor.Panel1.ResumeLayout(false);
            scContenedor.Panel2.ResumeLayout(false);
            scContenedor.Panel2.PerformLayout();
            gpbCliente.ResumeLayout(false);
            gpbCliente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ((System.ComponentModel.ISupportInitialize)scContenedor).EndInit();
            scContenedor.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCliente;
        private ComboBox cboClientes;
        private GroupBox gpbCliente;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblFecha;
        private TextBox txtFechaVta;
        private Label lblEstado;
        private TextBox txtEstado;
        private Label lblTipoVenta;
        private ComboBox cboTipoVenta;
        private SplitContainer scContenedor;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colSubtotal;
        private Button btnAgregarLibro;
        private Button btnEditarLibro;
        private Button btnQuitarLibro;
        private Label lblTotal;
        private TextBox txtTotal;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider;
    }
}
