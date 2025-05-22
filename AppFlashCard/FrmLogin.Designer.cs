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
            panelLogin = new Panel();
            lblTitulo = new Label();
            picPerfil = new PictureBox();
            table = new TableLayoutPanel();
            picUser = new PictureBox();
            txtUsername = new TextBox();
            picLock = new PictureBox();
            txtPassword = new TextBox();
            chkMostrarPassword = new CheckBox();
            btnRegistrar = new Button();
            btnIniciarSesion = new Button();
            btnSalir = new Button();
            picDecoracion = new PictureBox();
            panelLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPerfil).BeginInit();
            table.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picLock).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picDecoracion).BeginInit();
            SuspendLayout();
            // 
            // panelLogin
            // 
            panelLogin.Controls.Add(lblTitulo);
            panelLogin.Controls.Add(picPerfil);
            panelLogin.Controls.Add(table);
            panelLogin.Controls.Add(chkMostrarPassword);
            panelLogin.Controls.Add(btnRegistrar);
            panelLogin.Controls.Add(btnIniciarSesion);
            panelLogin.Controls.Add(btnSalir);
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(400, 360);
            panelLogin.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(120, 90);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(115, 25);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Iniciar Sesión";
            // 
            // picPerfil
            // 
            picPerfil.Location = new Point(165, 10);
            picPerfil.Name = "picPerfil";
            picPerfil.Size = new Size(70, 70);
            picPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            picPerfil.TabIndex = 2;
            picPerfil.TabStop = false;
            // 
            // table
            // 
            table.ColumnCount = 2;
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 40F));
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            table.Controls.Add(picUser, 0, 0);
            table.Controls.Add(txtUsername, 1, 0);
            table.Controls.Add(picLock, 0, 1);
            table.Controls.Add(txtPassword, 1, 1);
            table.Location = new Point(45, 140);
            table.Name = "table";
            table.RowCount = 2;
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            table.Size = new Size(310, 60);
            table.TabIndex = 3;
            // 
            // picUser
            // 
            picUser.Anchor = AnchorStyles.Right;
            picUser.Location = new Point(13, 3);
            picUser.Name = "picUser";
            picUser.Size = new Size(24, 24);
            picUser.SizeMode = PictureBoxSizeMode.Zoom;
            picUser.TabIndex = 4;
            picUser.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Anchor = AnchorStyles.Left;
            txtUsername.Location = new Point(43, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.PlaceholderText = "Escribe tu usuario";
            txtUsername.Size = new Size(200, 31);
            txtUsername.TabIndex = 7;
            // 
            // picLock
            // 
            picLock.Anchor = AnchorStyles.Right;
            picLock.Location = new Point(13, 33);
            picLock.Name = "picLock";
            picLock.Size = new Size(24, 24);
            picLock.SizeMode = PictureBoxSizeMode.Zoom;
            picLock.TabIndex = 4;
            picLock.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left;
            txtPassword.Location = new Point(43, 33);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Escribe tu contraseña";
            txtPassword.Size = new Size(200, 31);
            txtPassword.TabIndex = 7;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // chkMostrarPassword
            // 
            chkMostrarPassword.AutoSize = true;
            chkMostrarPassword.Location = new Point(70, 205);
            chkMostrarPassword.Name = "chkMostrarPassword";
            chkMostrarPassword.Size = new Size(191, 29);
            chkMostrarPassword.TabIndex = 8;
            chkMostrarPassword.Text = "Mostrar contraseña";
            chkMostrarPassword.CheckedChanged += chkMostrarPassword_CheckedChanged;
            // 
            // btnRegistrar
            // 
            btnRegistrar.FlatAppearance.BorderSize = 0;
            btnRegistrar.FlatStyle = FlatStyle.Flat;
            btnRegistrar.Location = new Point(35, 260);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(106, 30);
            btnRegistrar.TabIndex = 9;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.MouseClick += btnRegistrar_MouseClick;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.FlatAppearance.BorderSize = 0;
            btnIniciarSesion.FlatStyle = FlatStyle.Flat;
            btnIniciarSesion.Location = new Point(155, 260);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(105, 30);
            btnIniciarSesion.TabIndex = 10;
            btnIniciarSesion.Text = "Iniciar sesión";
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(275, 260);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(70, 30);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.MouseClick += btnSalir_MouseClick;
            // 
            // picDecoracion
            // 
            picDecoracion.Location = new Point(0, 0);
            picDecoracion.Name = "picDecoracion";
            picDecoracion.Size = new Size(100, 50);
            picDecoracion.TabIndex = 0;
            picDecoracion.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(picDecoracion);
            Controls.Add(panelLogin);
            Name = "FrmLogin";
            Text = "Inicio de Sesión";
            Load += FrmLogin_Load;
            Resize += FrmLogin_Resize;
            panelLogin.ResumeLayout(false);
            panelLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPerfil).EndInit();
            table.ResumeLayout(false);
            table.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)picLock).EndInit();
            ((System.ComponentModel.ISupportInitialize)picDecoracion).EndInit();
            ResumeLayout(false);
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













