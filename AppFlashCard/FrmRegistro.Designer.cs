namespace AppFlashCard
{
    partial class FrmRegistro
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            txtNombres = new TextBox();
            txtApellidos = new TextBox();
            txtCorreo = new TextBox();
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            txtConfirmPassword = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            btnResgistrar = new Button();
            btnSalir = new Button();
            label5 = new Label();
            txtTelefono = new TextBox();
            label9 = new Label();
            txtCarnet = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 52);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombres:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(590, 52);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Apellidos:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 117);
            label3.Name = "label3";
            label3.Size = new Size(149, 20);
            label3.TabIndex = 2;
            label3.Text = "Fecha de Nacimiento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 205);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(590, 205);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 5;
            label6.Text = "Username";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 280);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 6;
            label7.Text = "Contraseña";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(579, 280);
            label8.Name = "label8";
            label8.Size = new Size(151, 20);
            label8.TabIndex = 7;
            label8.Text = "Confirmar contraseña";
            // 
            // txtNombres
            // 
            txtNombres.Location = new Point(218, 49);
            txtNombres.Name = "txtNombres";
            txtNombres.Size = new Size(295, 27);
            txtNombres.TabIndex = 8;
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(738, 52);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(351, 27);
            txtApellidos.TabIndex = 9;
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(153, 202);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(321, 27);
            txtCorreo.TabIndex = 10;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(794, 202);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(295, 27);
            txtUsername.TabIndex = 11;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(153, 277);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(321, 27);
            txtPassword.TabIndex = 12;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(794, 277);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(295, 27);
            txtConfirmPassword.TabIndex = 13;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(218, 117);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(295, 27);
            dtpFechaNacimiento.TabIndex = 15;
            dtpFechaNacimiento.Value = new DateTime(2025, 4, 20, 0, 0, 0, 0);
            // 
            // btnResgistrar
            // 
            btnResgistrar.Location = new Point(366, 447);
            btnResgistrar.Name = "btnResgistrar";
            btnResgistrar.Size = new Size(201, 41);
            btnResgistrar.TabIndex = 16;
            btnResgistrar.Text = "Registrarse";
            btnResgistrar.UseVisualStyleBackColor = true;
            btnResgistrar.Click += btnResgistrar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(653, 447);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(199, 41);
            btnSalir.TabIndex = 17;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.MouseClick += btnSalir_MouseClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(590, 117);
            label5.Name = "label5";
            label5.Size = new Size(67, 20);
            label5.TabIndex = 18;
            label5.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(738, 114);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(351, 27);
            txtTelefono.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(46, 359);
            label9.Name = "label9";
            label9.Size = new Size(218, 20);
            label9.TabIndex = 20;
            label9.Text = "Carnet de estudiante (opcional)";
            // 
            // txtCarnet
            // 
            txtCarnet.Location = new Point(270, 356);
            txtCarnet.Name = "txtCarnet";
            txtCarnet.Size = new Size(204, 27);
            txtCarnet.TabIndex = 21;
            // 
            // FrmRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1203, 535);
            Controls.Add(txtCarnet);
            Controls.Add(label9);
            Controls.Add(txtTelefono);
            Controls.Add(label5);
            Controls.Add(btnSalir);
            Controls.Add(btnResgistrar);
            Controls.Add(dtpFechaNacimiento);
            Controls.Add(txtConfirmPassword);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(txtCorreo);
            Controls.Add(txtApellidos);
            Controls.Add(txtNombres);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FrmRegistro";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label7;
        private Label label8;
        private TextBox txtNombres;
        private TextBox txtApellidos;
        private TextBox txtCorreo;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private DateTimePicker dtpFechaNacimiento;
        private Button btnResgistrar;
        private Button btnSalir;
        private Label label5;
        private TextBox txtTelefono;
        private Label label9;
        private TextBox txtCarnet;
    }
}