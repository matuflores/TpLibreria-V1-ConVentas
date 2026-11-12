namespace TpLibreria.Windows
{
    partial class frmSeleccionarAutor
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
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            dgvDatos = new DataGridView();
            colApellido = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colNacionalidad = new DataGridViewTextBoxColumn();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            lblPaginas = new Label();
            lblCantidad = new Label();
            btnOK = new Button();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            SuspendLayout();
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(17, 18);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(49, 15);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(80, 15);
            txtBuscar.MaxLength = 50;
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(330, 23);
            txtBuscar.TabIndex = 0;
            txtBuscar.KeyDown += txtBuscar_KeyDown;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(420, 13);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 27);
            btnBuscar.TabIndex = 1;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(503, 13);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(75, 27);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colApellido, colNombre, colNacionalidad });
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.AutoGenerateColumns = false;
            dgvDatos.ColumnHeadersHeight = 30;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.RowHeadersVisible = false;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Location = new Point(17, 52);
            dgvDatos.Size = new Size(566, 300);
            dgvDatos.TabIndex = 3;
            dgvDatos.BorderStyle = BorderStyle.FixedSingle;
            dgvDatos.CellDoubleClick += dgvDatos_CellDoubleClick;
            // 
            // colApellido
            // 
            colApellido.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colApellido.DataPropertyName = "Apellido";
            colApellido.FillWeight = 40F;
            colApellido.HeaderText = "Apellido";
            colApellido.MinimumWidth = 60;
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombre.DataPropertyName = "Nombre";
            colNombre.FillWeight = 40F;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 60;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colNacionalidad
            // 
            colNacionalidad.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNacionalidad.DataPropertyName = "Nacionalidad";
            colNacionalidad.FillWeight = 30F;
            colNacionalidad.HeaderText = "Nacionalidad";
            colNacionalidad.MinimumWidth = 60;
            colNacionalidad.Name = "colNacionalidad";
            colNacionalidad.ReadOnly = true;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.first_24px;
            btnPrimero.Location = new Point(17, 362);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(41, 38);
            btnPrimero.TabIndex = 4;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.previous_24px;
            btnAnterior.Location = new Point(64, 362);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(41, 38);
            btnAnterior.TabIndex = 5;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.next_24px;
            btnSiguiente.Location = new Point(111, 362);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(41, 38);
            btnSiguiente.TabIndex = 6;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.last_24px;
            btnUltimo.Location = new Point(158, 362);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(41, 38);
            btnUltimo.TabIndex = 7;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // lblPaginas
            // 
            lblPaginas.AutoSize = true;
            lblPaginas.Location = new Point(225, 373);
            lblPaginas.Name = "lblPaginas";
            lblPaginas.Size = new Size(42, 15);
            lblPaginas.TabIndex = 0;
            lblPaginas.Text = "1 de 1";
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(330, 373);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(98, 15);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Del 0 a 0 de 0";
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(420, 412);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(75, 60);
            btnOK.TabIndex = 8;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(503, 412);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 60);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmSeleccionarAutor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            CancelButton = btnCancelar;
            ClientSize = new Size(600, 484);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Seleccionar autor";
            Load += frmSeleccionarAutor_Load;
            Controls.Add(lblBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(btnBuscar);
            Controls.Add(btnLimpiar);
            Controls.Add(dgvDatos);
            Controls.Add(btnPrimero);
            Controls.Add(btnAnterior);
            Controls.Add(btnSiguiente);
            Controls.Add(btnUltimo);
            Controls.Add(lblPaginas);
            Controls.Add(lblCantidad);
            Controls.Add(btnOK);
            Controls.Add(btnCancelar);
            Name = "frmSeleccionarAutor";
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private Button btnLimpiar;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colNacionalidad;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltimo;
        private Label lblPaginas;
        private Label lblCantidad;
        private Button btnOK;
        private Button btnCancelar;
    }
}
