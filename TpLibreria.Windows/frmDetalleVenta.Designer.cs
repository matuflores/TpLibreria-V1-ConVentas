namespace TpLibreria.Windows
{
    partial class frmDetalleVenta
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
            DataGridViewCellStyle estiloCantidad = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloPrecioUnitario = new DataGridViewCellStyle();
            DataGridViewCellStyle estiloSubtotal = new DataGridViewCellStyle();
            lblClienteTitulo = new Label();
            lblCliente = new Label();
            lblFechaTitulo = new Label();
            lblFecha = new Label();
            lblTipoVentaTitulo = new Label();
            lblTipoVenta = new Label();
            lblEstadoTitulo = new Label();
            lblEstado = new Label();
            dgvDetalle = new DataGridView();
            colLibro = new DataGridViewTextBoxColumn();
            colTipo = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            lblTotalTitulo = new Label();
            lblTotal = new Label();
            btnCerrar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).BeginInit();
            SuspendLayout();
            // 
            // lblClienteTitulo
            // 
            lblClienteTitulo.AutoSize = true;
            lblClienteTitulo.Location = new Point(20, 20);
            lblClienteTitulo.Name = "lblClienteTitulo";
            lblClienteTitulo.Size = new Size(56, 15);
            lblClienteTitulo.TabIndex = 0;
            lblClienteTitulo.Text = "Cliente:";
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCliente.Location = new Point(100, 20);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(10, 15);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "-";
            // 
            // lblFechaTitulo
            // 
            lblFechaTitulo.AutoSize = true;
            lblFechaTitulo.Location = new Point(20, 48);
            lblFechaTitulo.Name = "lblFechaTitulo";
            lblFechaTitulo.Size = new Size(42, 15);
            lblFechaTitulo.TabIndex = 0;
            lblFechaTitulo.Text = "Fecha:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFecha.Location = new Point(100, 48);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(10, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "-";
            // 
            // lblTipoVentaTitulo
            // 
            lblTipoVentaTitulo.AutoSize = true;
            lblTipoVentaTitulo.Location = new Point(400, 20);
            lblTipoVentaTitulo.Name = "lblTipoVentaTitulo";
            lblTipoVentaTitulo.Size = new Size(98, 15);
            lblTipoVentaTitulo.TabIndex = 0;
            lblTipoVentaTitulo.Text = "Tipo de venta:";
            // 
            // lblTipoVenta
            // 
            lblTipoVenta.AutoSize = true;
            lblTipoVenta.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoVenta.Location = new Point(500, 20);
            lblTipoVenta.Name = "lblTipoVenta";
            lblTipoVenta.Size = new Size(10, 15);
            lblTipoVenta.TabIndex = 0;
            lblTipoVenta.Text = "-";
            // 
            // lblEstadoTitulo
            // 
            lblEstadoTitulo.AutoSize = true;
            lblEstadoTitulo.Location = new Point(400, 48);
            lblEstadoTitulo.Name = "lblEstadoTitulo";
            lblEstadoTitulo.Size = new Size(49, 15);
            lblEstadoTitulo.TabIndex = 0;
            lblEstadoTitulo.Text = "Estado:";
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEstado.Location = new Point(500, 48);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(10, 15);
            lblEstado.TabIndex = 0;
            lblEstado.Text = "-";
            // 
            // dgvDetalle
            // 
            dgvDetalle.Columns.AddRange(new DataGridViewColumn[] { colLibro, colTipo, colCantidad, colPrecioUnitario, colSubtotal });
            dgvDetalle.AllowUserToAddRows = false;
            dgvDetalle.AllowUserToDeleteRows = false;
            dgvDetalle.AllowUserToResizeRows = false;
            dgvDetalle.AutoGenerateColumns = false;
            dgvDetalle.ColumnHeadersHeight = 30;
            dgvDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDetalle.MultiSelect = false;
            dgvDetalle.Name = "dgvDetalle";
            dgvDetalle.ReadOnly = true;
            dgvDetalle.RowHeadersVisible = false;
            dgvDetalle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalle.Size = new Size(680, 260);
            dgvDetalle.TabIndex = 0;
            dgvDetalle.Location = new Point(20, 85);
            dgvDetalle.BorderStyle = BorderStyle.FixedSingle;
            // 
            // colLibro
            // 
            colLibro.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colLibro.DataPropertyName = "Libro";
            colLibro.FillWeight = 50F;
            colLibro.HeaderText = "Libro";
            colLibro.MinimumWidth = 60;
            colLibro.Name = "colLibro";
            colLibro.ReadOnly = true;
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
            // colCantidad
            // 
            estiloCantidad.Alignment = DataGridViewContentAlignment.MiddleRight;
            colCantidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colCantidad.DataPropertyName = "Cantidad";
            colCantidad.DefaultCellStyle = estiloCantidad;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 60;
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            colCantidad.Width = 80;
            // 
            // colPrecioUnitario
            // 
            estiloPrecioUnitario.Alignment = DataGridViewContentAlignment.MiddleRight;
            estiloPrecioUnitario.Format = "C2";
            colPrecioUnitario.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPrecioUnitario.DataPropertyName = "PrecioUnitario";
            colPrecioUnitario.DefaultCellStyle = estiloPrecioUnitario;
            colPrecioUnitario.HeaderText = "Precio unitario";
            colPrecioUnitario.MinimumWidth = 60;
            colPrecioUnitario.Name = "colPrecioUnitario";
            colPrecioUnitario.ReadOnly = true;
            colPrecioUnitario.Width = 110;
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
            // lblTotalTitulo
            // 
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Location = new Point(500, 360);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(42, 15);
            lblTotalTitulo.TabIndex = 0;
            lblTotalTitulo.Text = "Total:";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotal.Location = new Point(555, 352);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(40, 25);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "$0,00";
            // 
            // btnCerrar
            // 
            btnCerrar.Image = Properties.Resources.cancel_24px;
            btnCerrar.Location = new Point(300, 395);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(110, 58);
            btnCerrar.TabIndex = 2;
            btnCerrar.Text = "Cerrar";
            btnCerrar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // frmDetalleVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            CancelButton = btnCerrar;
            ClientSize = new Size(720, 470);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Detalle de la venta";
            Controls.Add(lblClienteTitulo);
            Controls.Add(lblCliente);
            Controls.Add(lblFechaTitulo);
            Controls.Add(lblFecha);
            Controls.Add(lblTipoVentaTitulo);
            Controls.Add(lblTipoVenta);
            Controls.Add(lblEstadoTitulo);
            Controls.Add(lblEstado);
            Controls.Add(dgvDetalle);
            Controls.Add(lblTotalTitulo);
            Controls.Add(lblTotal);
            Controls.Add(btnCerrar);
            Name = "frmDetalleVenta";
            ((System.ComponentModel.ISupportInitialize)dgvDetalle).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblClienteTitulo;
        private Label lblCliente;
        private Label lblFechaTitulo;
        private Label lblFecha;
        private Label lblTipoVentaTitulo;
        private Label lblTipoVenta;
        private Label lblEstadoTitulo;
        private Label lblEstado;
        private DataGridView dgvDetalle;
        private DataGridViewTextBoxColumn colLibro;
        private DataGridViewTextBoxColumn colTipo;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colSubtotal;
        private Label lblTotalTitulo;
        private Label lblTotal;
        private Button btnCerrar;
    }
}
