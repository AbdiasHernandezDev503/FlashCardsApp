namespace AppFlashCard
{
    partial class FrmLogin
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

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
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(298, 120);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(300, 27);
            txtUsername.TabIndex = 1;
            // 
            // lblPasword
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

        private Label lblUsuario;
        private TextBox txtUsername;
        private Label lblPasword;
        private TextBox txtPassword;
        private Button btnIniciarSesion;
        private Button btnRegistrar;
        private Button btnSalir;
    }
}
