namespace TpLibreria.Windows
{
    partial class frmEditorialAe
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
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblPaisOrigen = new Label();
            txtPaisOrigen = new TextBox();
            chkActivo = new CheckBox();
            btnOK = new Button();
            btnCancelar = new Button();
            errorProvider = new ErrorProvider(components);
            SuspendLayout();
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(20, 28);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(49, 15);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(150, 25);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(280, 23);
            txtNombre.TabIndex = 0;
            // 
            // lblPaisOrigen
            // 
            lblPaisOrigen.AutoSize = true;
            lblPaisOrigen.Location = new Point(20, 66);
            lblPaisOrigen.Name = "lblPaisOrigen";
            lblPaisOrigen.Size = new Size(105, 15);
            lblPaisOrigen.TabIndex = 0;
            lblPaisOrigen.Text = "País de origen:";
            // 
            // txtPaisOrigen
            // 
            txtPaisOrigen.Location = new Point(150, 63);
            txtPaisOrigen.MaxLength = 50;
            txtPaisOrigen.Name = "txtPaisOrigen";
            txtPaisOrigen.Size = new Size(280, 23);
            txtPaisOrigen.TabIndex = 1;
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Location = new Point(150, 101);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(80, 19);
            chkActivo.TabIndex = 2;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            btnOK.Image = Properties.Resources.ok_24px;
            btnOK.Location = new Point(120, 149);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 58);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.TextImageRelation = TextImageRelation.ImageAboveText;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_24px;
            btnCancelar.Location = new Point(240, 149);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(100, 58);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmEditorialAe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            AcceptButton = btnOK;
            CancelButton = btnCancelar;
            ClientSize = new Size(460, 229);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editorial";
            Controls.Add(lblNombre);
            Controls.Add(txtNombre);
            Controls.Add(lblPaisOrigen);
            Controls.Add(txtPaisOrigen);
            Controls.Add(chkActivo);
            Controls.Add(btnOK);
            Controls.Add(btnCancelar);
            Name = "frmEditorialAe";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblPaisOrigen;
        private TextBox txtPaisOrigen;
        private CheckBox chkActivo;
        private Button btnOK;
        private Button btnCancelar;
        private ErrorProvider errorProvider;
    }
}
