namespace AppFlashCard
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            //Contenedor de todos los controles
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.picPerfil = new System.Windows.Forms.PictureBox();
            this.table = new System.Windows.Forms.TableLayoutPanel();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.picLock = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkMostrarPassword = new System.Windows.Forms.CheckBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.picDecoracion = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDecoracion)).BeginInit();

            this.panelLogin.SuspendLayout();
            this.table.SuspendLayout();
            this.SuspendLayout();

            // panelLogin
            this.panelLogin.Controls.Add(this.lblTitulo);
            this.panelLogin.Controls.Add(this.picPerfil);
            this.panelLogin.Controls.Add(this.table);
            this.panelLogin.Controls.Add(this.chkMostrarPassword);
            this.panelLogin.Controls.Add(this.btnRegistrar);
            this.panelLogin.Controls.Add(this.btnIniciarSesion);
            this.panelLogin.Controls.Add(this.btnSalir);
            this.panelLogin.Location = new System.Drawing.Point(0, 0);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(400, 360);
            this.panelLogin.TabIndex = 0;

            // Etiqueta lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(120, 90);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(160, 30);
            this.lblTitulo.Text = "Iniciar Sesión";
            this.lblTitulo.TabIndex = 1;

            // Imagen del Perfil
            this.picPerfil.Image = System.Drawing.Image.FromFile("Images/user_login.png");
            this.picPerfil.Location = new System.Drawing.Point(165, 10);
            this.picPerfil.Name = "picPerfil";
            this.picPerfil.Size = new System.Drawing.Size(70, 70);
            this.picPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPerfil.TabIndex = 2;

            // tabla con iconos, cajas de textos usuario y contraseña 
            this.table.ColumnCount = 2;
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table.Controls.Add(this.picUser, 0, 0);
            this.table.Controls.Add(this.txtUsername, 1, 0);
            this.table.Controls.Add(this.picLock, 0, 1);
            this.table.Controls.Add(this.txtPassword, 1, 1);
            this.table.Location = new System.Drawing.Point(45, 140);
            this.table.Name = "table";
            this.table.RowCount = 2;
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.table.Size = new System.Drawing.Size(310, 60);
            this.table.TabIndex = 3;

            // icono de usuario 
            this.picUser.Image = System.Drawing.Image.FromFile("Images/icon_user1.png");
            this.picUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUser.Size = new System.Drawing.Size(24, 24);
            this.picUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picUser.TabIndex = 4;

            // Caja de texto de usuario 
            this.txtUsername.PlaceholderText = "Escribe tu usuario";
            this.txtUsername.Size = new System.Drawing.Size(200, 25);
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtUsername.TabIndex = 7;

            // Icono de candado
            this.picLock.Image = System.Drawing.Image.FromFile("Images/icon_lock.png");
            this.picLock.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLock.Size = new System.Drawing.Size(24, 24);
            this.picLock.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picLock.TabIndex = 4;

            // Caja de texto de contraseña
            this.txtPassword.PlaceholderText = "Escribe tu contraseña";
            this.txtPassword.Size = new System.Drawing.Size(200, 27);
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPassword.TabIndex = 7;

            // Checkbox mostrar/ocultar contraseña
            this.chkMostrarPassword.AutoSize = true;
            this.chkMostrarPassword.Location = new System.Drawing.Point(70, 205);
            this.chkMostrarPassword.Text = "Mostrar contraseña";
            this.chkMostrarPassword.CheckedChanged += new System.EventHandler(this.chkMostrarPassword_CheckedChanged);
            this.chkMostrarPassword.TabIndex = 8;

            // btnRegistrar
            this.btnRegistrar.Location = new System.Drawing.Point(30, 260);
            this.btnRegistrar.Size = new System.Drawing.Size(100, 30);
            this.btnRegistrar.Text = "Registrarse";
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.FlatAppearance.BorderSize = 0;
            this.btnRegistrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRegistrar_MouseClick);
            this.btnRegistrar.TabIndex = 9;

            // btnIniciarSesion
            this.btnIniciarSesion.Location = new System.Drawing.Point(145, 260);
            this.btnIniciarSesion.Size = new System.Drawing.Size(105, 30);
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciarSesion.FlatAppearance.BorderSize = 0;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            this.btnIniciarSesion.TabIndex = 10;

            // btnSalir
            this.btnSalir.Location = new System.Drawing.Point(270, 260);
            this.btnSalir.Size = new System.Drawing.Size(70, 30);
            this.btnSalir.Text = "Salir";
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSalir_MouseClick);
            this.btnSalir.TabIndex = 11;


            // Propiedades de FrmLogin
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.picDecoracion);
            this.Controls.Add(this.panelLogin);
            this.Name = "FrmLogin";
            this.Text = "Inicio de Sesión";
            this.Resize += new System.EventHandler(this.FrmLogin_Resize);
            this.Load += new System.EventHandler(this.FrmLogin_Load);

            // Libera recursos utilizados por PictureBox y Panel
            ((System.ComponentModel.ISupportInitialize)(this.picPerfil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDecoracion)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout(); // Aplica diseño de los controles contenidos
            this.table.ResumeLayout(false);
            this.table.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox picPerfil;
        private System.Windows.Forms.TableLayoutPanel table;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.PictureBox picLock;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkMostrarPassword;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.PictureBox picDecoracion;
    }
}













