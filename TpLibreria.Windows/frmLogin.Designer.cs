namespace TpLibreria.Windows
{
    partial class frmLogin
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
            picLogo = new PictureBox();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblClave = new Label();
            txtClave = new TextBox();
            btnSalir = new Button();
            btnLogin = new Button();
            errorProvider = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            SuspendLayout();
            // 
            // picLogo
            // 
            picLogo.Image = Properties.Resources.key_2_200px;
            picLogo.Location = new Point(40, 32);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(129, 150);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 0;
            picLogo.TabStop = false;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(190, 37);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(56, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(262, 34);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(204, 23);
            txtUsuario.TabIndex = 0;
            txtUsuario.Text = "admin";
            // 
            // lblClave
            // 
            lblClave.AutoSize = true;
            lblClave.Location = new Point(190, 78);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(42, 15);
            lblClave.TabIndex = 0;
            lblClave.Text = "Clave:";
            // 
            // txtClave
            // 
            txtClave.Location = new Point(262, 75);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(204, 23);
            txtClave.TabIndex = 1;
            txtClave.PasswordChar = '*';
            txtClave.Text = "123456";
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.cancel_24px;
            btnSalir.Location = new Point(359, 122);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(107, 60);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Cerrar";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnLogin
            // 
            btnLogin.Image = Properties.Resources.ok_24px;
            btnLogin.Location = new Point(190, 122);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(107, 60);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "Login";
            btnLogin.TextImageRelation = TextImageRelation.ImageAboveText;
            btnLogin.Click += btnLogin_Click;
            // 
            // errorProvider
            // 
            errorProvider.ContainerControl = this;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            ClientSize = new Size(536, 228);
            ControlBox = false;
            MaximumSize = new Size(552, 267);
            MinimumSize = new Size(552, 267);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ingreso al sistema";
            Controls.Add(picLogo);
            Controls.Add(lblUsuario);
            Controls.Add(txtUsuario);
            Controls.Add(lblClave);
            Controls.Add(txtClave);
            Controls.Add(btnSalir);
            Controls.Add(btnLogin);
            Name = "frmLogin";
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblClave;
        private TextBox txtClave;
        private Button btnSalir;
        private Button btnLogin;
        private ErrorProvider errorProvider;
    }
}
