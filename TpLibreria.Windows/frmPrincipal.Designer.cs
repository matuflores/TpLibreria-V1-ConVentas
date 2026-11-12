namespace TpLibreria.Windows
{
    partial class frmPrincipal
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
            pnlContenido = new Panel();
            lblBienvenida = new Label();
            pnlMenu = new Panel();
            btnLogout = new Button();
            btnVentas = new Button();
            btnClientes = new Button();
            btnLibros = new Button();
            btnTemas = new Button();
            btnAutores = new Button();
            btnEditoriales = new Button();
            pnlSuperior = new Panel();
            lblTitulo = new Label();
            lblUsuarioTitulo = new Label();
            lblUsuario = new Label();
            lblFechaTitulo = new Label();
            lblFecha = new Label();
            pnlContenido.SuspendLayout();
            pnlMenu.SuspendLayout();
            pnlSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(lblBienvenida);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(210, 70);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Size = new Size(750, 530);
            pnlContenido.TabIndex = 2;
            // 
            // lblBienvenida
            // 
            lblBienvenida.Dock = DockStyle.Fill;
            lblBienvenida.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblBienvenida.Location = new Point(0, 0);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(750, 530);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido al sistema de gestión de la librería";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlMenu
            // 
            pnlMenu.Controls.Add(btnLogout);
            pnlMenu.Controls.Add(btnVentas);
            pnlMenu.Controls.Add(btnClientes);
            pnlMenu.Controls.Add(btnLibros);
            pnlMenu.Controls.Add(btnTemas);
            pnlMenu.Controls.Add(btnAutores);
            pnlMenu.Controls.Add(btnEditoriales);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 70);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(210, 530);
            pnlMenu.TabIndex = 1;
            // 
            // btnLogout
            // 
            btnLogout.Dock = DockStyle.Bottom;
            btnLogout.Font = new Font("Segoe UI", 11F);
            btnLogout.Location = new Point(0, 510);
            btnLogout.Name = "btnLogout";
            btnLogout.Padding = new Padding(20, 0, 0, 0);
            btnLogout.Size = new Size(210, 52);
            btnLogout.TabIndex = 6;
            btnLogout.Text = "Cerrar sesión";
            btnLogout.TextAlign = ContentAlignment.MiddleLeft;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.Font = new Font("Segoe UI", 11F);
            btnVentas.Location = new Point(0, 0);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(20, 0, 0, 0);
            btnVentas.Size = new Size(210, 52);
            btnVentas.TabIndex = 5;
            btnVentas.Text = "Ventas";
            btnVentas.TextAlign = ContentAlignment.MiddleLeft;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnClientes
            // 
            btnClientes.Dock = DockStyle.Top;
            btnClientes.Font = new Font("Segoe UI", 11F);
            btnClientes.Location = new Point(0, 0);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(20, 0, 0, 0);
            btnClientes.Size = new Size(210, 52);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "Clientes";
            btnClientes.TextAlign = ContentAlignment.MiddleLeft;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnLibros
            // 
            btnLibros.Dock = DockStyle.Top;
            btnLibros.Font = new Font("Segoe UI", 11F);
            btnLibros.Location = new Point(0, 0);
            btnLibros.Name = "btnLibros";
            btnLibros.Padding = new Padding(20, 0, 0, 0);
            btnLibros.Size = new Size(210, 52);
            btnLibros.TabIndex = 3;
            btnLibros.Text = "Libros";
            btnLibros.TextAlign = ContentAlignment.MiddleLeft;
            btnLibros.Click += btnLibros_Click;
            // 
            // btnTemas
            // 
            btnTemas.Dock = DockStyle.Top;
            btnTemas.Font = new Font("Segoe UI", 11F);
            btnTemas.Location = new Point(0, 0);
            btnTemas.Name = "btnTemas";
            btnTemas.Padding = new Padding(20, 0, 0, 0);
            btnTemas.Size = new Size(210, 52);
            btnTemas.TabIndex = 2;
            btnTemas.Text = "Temas";
            btnTemas.TextAlign = ContentAlignment.MiddleLeft;
            btnTemas.Click += btnTemas_Click;
            // 
            // btnAutores
            // 
            btnAutores.Dock = DockStyle.Top;
            btnAutores.Font = new Font("Segoe UI", 11F);
            btnAutores.Location = new Point(0, 0);
            btnAutores.Name = "btnAutores";
            btnAutores.Padding = new Padding(20, 0, 0, 0);
            btnAutores.Size = new Size(210, 52);
            btnAutores.TabIndex = 1;
            btnAutores.Text = "Autores";
            btnAutores.TextAlign = ContentAlignment.MiddleLeft;
            btnAutores.Click += btnAutores_Click;
            // 
            // btnEditoriales
            // 
            btnEditoriales.Dock = DockStyle.Top;
            btnEditoriales.Font = new Font("Segoe UI", 11F);
            btnEditoriales.Location = new Point(0, 0);
            btnEditoriales.Name = "btnEditoriales";
            btnEditoriales.Padding = new Padding(20, 0, 0, 0);
            btnEditoriales.Size = new Size(210, 52);
            btnEditoriales.TabIndex = 0;
            btnEditoriales.Text = "Editoriales";
            btnEditoriales.TextAlign = ContentAlignment.MiddleLeft;
            btnEditoriales.Click += btnEditoriales_Click;
            // 
            // pnlSuperior
            // 
            pnlSuperior.Controls.Add(lblTitulo);
            pnlSuperior.Controls.Add(lblUsuarioTitulo);
            pnlSuperior.Controls.Add(lblUsuario);
            pnlSuperior.Controls.Add(lblFechaTitulo);
            pnlSuperior.Controls.Add(lblFecha);
            pnlSuperior.Dock = DockStyle.Top;
            pnlSuperior.Location = new Point(0, 0);
            pnlSuperior.Name = "pnlSuperior";
            pnlSuperior.Size = new Size(960, 70);
            pnlSuperior.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(300, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Librería - Sistema de Gestión";
            // 
            // lblUsuarioTitulo
            // 
            lblUsuarioTitulo.AutoSize = true;
            lblUsuarioTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuarioTitulo.Location = new Point(760, 14);
            lblUsuarioTitulo.Name = "lblUsuarioTitulo";
            lblUsuarioTitulo.Size = new Size(60, 15);
            lblUsuarioTitulo.TabIndex = 0;
            lblUsuarioTitulo.Text = "Usuario:";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblUsuario.Location = new Point(820, 14);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(60, 15);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "-";
            lblUsuario.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // 
            // lblFechaTitulo
            // 
            lblFechaTitulo.AutoSize = true;
            lblFechaTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFechaTitulo.Location = new Point(760, 40);
            lblFechaTitulo.Name = "lblFechaTitulo";
            lblFechaTitulo.Size = new Size(60, 15);
            lblFechaTitulo.TabIndex = 0;
            lblFechaTitulo.Text = "Fecha:";
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFecha.Location = new Point(820, 40);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(60, 15);
            lblFecha.TabIndex = 0;
            lblFecha.Text = "-";
            lblFecha.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 242, 241);
            ClientSize = new Size(960, 600);
            MinimumSize = new Size(800, 500);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Librería";
            Controls.Add(pnlContenido);
            Controls.Add(pnlMenu);
            Controls.Add(pnlSuperior);
            Name = "frmPrincipal";
            Load += frmPrincipal_Load;
            pnlSuperior.ResumeLayout(false);
            pnlMenu.ResumeLayout(false);
            pnlContenido.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlContenido;
        private Label lblBienvenida;
        private Panel pnlMenu;
        private Button btnLogout;
        private Button btnVentas;
        private Button btnClientes;
        private Button btnLibros;
        private Button btnTemas;
        private Button btnAutores;
        private Button btnEditoriales;
        private Panel pnlSuperior;
        private Label lblTitulo;
        private Label lblUsuarioTitulo;
        private Label lblUsuario;
        private Label lblFechaTitulo;
        private Label lblFecha;
    }
}
