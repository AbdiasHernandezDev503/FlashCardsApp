namespace AppFlashCard
{
    partial class FrmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblUsuario = new Label();
            textBox1 = new TextBox();
            lblPasword = new Label();
            textBox2 = new TextBox();
            btnIniciarSesion = new Button();
            btnRegistrar = new Button();
            btnSalir = new Button();
            SuspendLayout();
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(185, 127);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(62, 20);
            lblUsuario.TabIndex = 0;
            lblUsuario.Text = "Usuario:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(298, 120);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(300, 27);
            textBox1.TabIndex = 1;
            // 
            // lblPasword
            // 
            lblPasword.AutoSize = true;
            lblPasword.Location = new Point(185, 195);
            lblPasword.Name = "lblPasword";
            lblPasword.Size = new Size(83, 20);
            lblPasword.TabIndex = 3;
            lblPasword.Text = "Contraseña";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(298, 188);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(300, 27);
            textBox2.TabIndex = 4;
            textBox2.UseSystemPasswordChar = true;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(95, 293);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(152, 35);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(298, 293);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(185, 35);
            btnRegistrar.TabIndex = 6;
            btnRegistrar.Text = "Registrarse";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.MouseClick += btnRegistrar_MouseClick;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(533, 293);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(165, 35);
            btnSalir.TabIndex = 7;
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
            Controls.Add(textBox2);
            Controls.Add(lblPasword);
            Controls.Add(textBox1);
            Controls.Add(lblUsuario);
            Name = "FrmLogin";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsuario;
        private TextBox textBox1;
        private Label lblPasword;
        private TextBox textBox2;
        private Button btnIniciarSesion;
        private Button btnRegistrar;
        private Button btnSalir;
    }
}
