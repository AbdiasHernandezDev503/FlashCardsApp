namespace AppFlashCard
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblUsuario = new Label();
            txtUsername = new TextBox();
            lblPasword = new Label();
            txtPassword = new TextBox();
            btnIniciarSesion = new Button();
            btnRegistrar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblUsuario
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(185, 127);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(298, 120);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPasword
            lblPasword.AutoSize = true;
            lblPasword.Location = new Point(185, 195);
            lblPasword.Name = "lblPasword";
            lblPasword.Size = new Size(83, 20);
            lblPasword.TabIndex = 3;
            lblPasword.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(298, 188);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(300, 27);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(350, 293);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(177, 35);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnRegistrar
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.MouseClick += btnRegistrar_MouseClick;
            // 
            // btnSalir
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.MouseClick += btnSalir_MouseClick;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(959, 510);
            Controls.Add(btnSalir);
            Controls.Add(btnRegistrar);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtPassword);
            Controls.Add(lblPasword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsuario);
            Name = "FrmLogin";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Label lblUsuario;
        private TextBox txtUsername;
        private Label lblPasword;
        private TextBox txtPassword;
        private Button btnIniciarSesion;
        private Button btnRegistrar;
        private Button btnSalir;
    }
}
