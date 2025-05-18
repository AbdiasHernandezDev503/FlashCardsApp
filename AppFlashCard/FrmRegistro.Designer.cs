using System.Configuration;

namespace AppFlashCard
{
    partial class FrmRegistro
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
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
            this.panelRegistro = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.picNombres = new System.Windows.Forms.PictureBox();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.picApellidos = new System.Windows.Forms.PictureBox();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.picCorreo = new System.Windows.Forms.PictureBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.picTelefono = new System.Windows.Forms.PictureBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.picUsername = new System.Windows.Forms.PictureBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picPassword = new System.Windows.Forms.PictureBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.picConfirmPassword = new System.Windows.Forms.PictureBox();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.picCarnet = new System.Windows.Forms.PictureBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.btnResgistrar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNombres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApellidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarnet)).BeginInit();
            this.SuspendLayout();

            
            this.panelRegistro.Location = new System.Drawing.Point(50, 30);
            this.panelRegistro.Size = new System.Drawing.Size(900, 580);
            this.panelRegistro.BackColor = System.Drawing.Color.FromArgb(66, 71, 105);
           // this.panelRegistro.Anchor = System.Windows.Forms.AnchorStyles.None;

            //Titulo principal
            this.lblTitulo.Text = "Crear Cuenta";
            this.lblTitulo.Font = new System.Drawing.Font("ralewaySemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(370, 20);
            this.panelRegistro.Controls.Add(this.lblTitulo);

            // Label: Nombres
            Label lblNombres = new Label();
            lblNombres.Text = "Nombres:";
            lblNombres.ForeColor = Color.White;
            lblNombres.AutoSize = true;
            lblNombres.Location = new Point(95, 60);
            this.panelRegistro.Controls.Add(lblNombres);

            // Campo: Nombres
            this.picNombres.Location = new System.Drawing.Point(60, 80);
            this.picNombres.Size = new System.Drawing.Size(24, 24);
            this.picNombres.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNombres.Image = System.Drawing.Image.FromFile("Images/user.png"); 
            this.txtNombres.Location = new System.Drawing.Point(90, 80);
            this.txtNombres.Size = new System.Drawing.Size(260, 27);
            this.txtNombres.PlaceholderText = "Nombres";
            this.panelRegistro.Controls.Add(this.picNombres);
            this.panelRegistro.Controls.Add(this.txtNombres);

            // Label: Apellidos
            Label lblApellidos = new Label();
            lblApellidos.Text = "Apellidos:";
            lblApellidos.ForeColor = Color.White;
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(530, 60);
            this.panelRegistro.Controls.Add(lblApellidos);

            // Campo: Apellidos
            this.picApellidos.Location = new System.Drawing.Point(500, 80);
            this.picApellidos.Size = new System.Drawing.Size(24, 24);
            this.picApellidos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picApellidos.Image = System.Drawing.Image.FromFile("Images/apellido.png");
            this.txtApellidos.Location = new System.Drawing.Point(530, 80);
            this.txtApellidos.Size = new System.Drawing.Size(260, 27);
            this.txtApellidos.PlaceholderText = "Apellidos";
            this.panelRegistro.Controls.Add(this.picApellidos);
            this.panelRegistro.Controls.Add(this.txtApellidos);

            // Label: Correo
            Label lblCorreo = new Label();
            lblCorreo.Text = "Correo:";
            lblCorreo.ForeColor = Color.White;
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(90, 110);
            this.panelRegistro.Controls.Add(lblCorreo);

            // Campo: Correo
            this.picCorreo.Location = new System.Drawing.Point(60, 130);
            this.picCorreo.Size = new System.Drawing.Size(24, 24);
            this.picCorreo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCorreo.Image = System.Drawing.Image.FromFile("Images/email.png");
            this.txtCorreo.Location = new System.Drawing.Point(90, 130);
            this.txtCorreo.Size = new System.Drawing.Size(260, 27);
            this.txtCorreo.PlaceholderText = "Correo";
            this.panelRegistro.Controls.Add(this.picCorreo);
            this.panelRegistro.Controls.Add(this.txtCorreo);

            // Label: Teléfono
            Label lblTelefono = new Label();
            lblTelefono.Text = "Teléfono:";
            lblTelefono.ForeColor = Color.White;
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(530, 110);
            this.panelRegistro.Controls.Add(lblTelefono);

            // Campo: Teléfono
            this.picTelefono.Location = new System.Drawing.Point(500, 130);
            this.picTelefono.Size = new System.Drawing.Size(24, 24);
            this.picTelefono.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picTelefono.Image = System.Drawing.Image.FromFile("Images/phone.png"); 
            this.txtTelefono.Location = new System.Drawing.Point(530, 130);
            this.txtTelefono.Size = new System.Drawing.Size(260, 27);
            this.txtTelefono.PlaceholderText = "Teléfono";
            this.panelRegistro.Controls.Add(this.picTelefono);
            this.panelRegistro.Controls.Add(this.txtTelefono);

            // Label: Usuario
            Label lblUsuario = new Label();
            lblUsuario.Text = "Usuario:";
            lblUsuario.ForeColor = Color.White;
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(90, 160);
            this.panelRegistro.Controls.Add(lblUsuario);

            // Campo: Username
            this.picUsername.Location = new System.Drawing.Point(60, 180);
            this.picUsername.Size = new System.Drawing.Size(24, 24);
            this.picUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picUsername.Image = System.Drawing.Image.FromFile("Images/username.png");
            this.txtUsername.Location = new System.Drawing.Point(90, 180);
            this.txtUsername.Size = new System.Drawing.Size(260, 27);
            this.txtUsername.PlaceholderText = "Usuario";
            this.panelRegistro.Controls.Add(this.picUsername);
            this.panelRegistro.Controls.Add(this.txtUsername);

            // Label: Contraseña
            Label lblPassword = new Label();
            lblPassword.Text = "Contraseña:";
            lblPassword.ForeColor = Color.White;
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(530, 160);
            this.panelRegistro.Controls.Add(lblPassword);

            // Campo: Contraseña
            this.picPassword.Location = new System.Drawing.Point(500, 180);
            this.picPassword.Size = new System.Drawing.Size(24, 24);
            this.picPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPassword.Image = System.Drawing.Image.FromFile("Images/icono_password.png"); 
            this.txtPassword.Location = new System.Drawing.Point(530, 180);
            this.txtPassword.Size = new System.Drawing.Size(260, 27);
            this.txtPassword.PlaceholderText = "Contraseña";
            this.txtPassword.UseSystemPasswordChar = true;
            this.panelRegistro.Controls.Add(this.picPassword);
            this.panelRegistro.Controls.Add(this.txtPassword);

            // Label: Confirmar Contraseña
            Label lblConfirmar = new Label();
            lblConfirmar.Text = "Confirmar contraseña:";
            lblConfirmar.ForeColor = Color.White;
            lblConfirmar.AutoSize = true;
            lblConfirmar.Location = new Point(90, 210);
            this.panelRegistro.Controls.Add(lblConfirmar);

            // Campo: Confirmar contraseña
            this.picConfirmPassword.Location = new System.Drawing.Point(60, 230);
            this.picConfirmPassword.Size = new System.Drawing.Size(24, 24);
            this.picConfirmPassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picConfirmPassword.Image = System.Drawing.Image.FromFile("Images/confirm.png");
            this.txtConfirmPassword.Location = new System.Drawing.Point(90, 230);
            this.txtConfirmPassword.Size = new System.Drawing.Size(260, 27);
            this.txtConfirmPassword.PlaceholderText = "Confirmar";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.panelRegistro.Controls.Add(this.picConfirmPassword);
            this.panelRegistro.Controls.Add(this.txtConfirmPassword);

            // Label: Carnet
            Label lblCarnet = new Label();
            lblCarnet.Text = "Carnet de estudiante:";
            lblCarnet.ForeColor = Color.White;
            lblCarnet.AutoSize = true;
            lblCarnet.Location = new Point(530, 210);
            this.panelRegistro.Controls.Add(lblCarnet);

            // Campo: Carnet
            this.picCarnet.Location = new System.Drawing.Point(500, 230);
            this.picCarnet.Size = new System.Drawing.Size(24, 24);
            this.picCarnet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCarnet.Image = System.Drawing.Image.FromFile("Images/card.png"); 
            this.txtCarnet.Location = new System.Drawing.Point(530, 230);
            this.txtCarnet.Size = new System.Drawing.Size(260, 27);
            this.txtCarnet.PlaceholderText = "Carnet";
            this.panelRegistro.Controls.Add(this.picCarnet);
            this.panelRegistro.Controls.Add(this.txtCarnet);

            // Label: Fecha de Nacimiento
            Label lblFecha = new Label();
            lblFecha.Text = "Fecha de Nacimiento:";
            lblFecha.ForeColor = Color.White;
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(90, 260);
            this.panelRegistro.Controls.Add(lblFecha);

            // FechaNacimiento
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(90, 280);
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(300, 27);
            this.panelRegistro.Controls.Add(this.dtpFechaNacimiento);

            // Botón Registrarse
            this.btnResgistrar.Text = "Registrarse";
            this.btnResgistrar.Location = new System.Drawing.Point(250, 350);
            this.btnResgistrar.Size = new System.Drawing.Size(150, 40);
            this.btnResgistrar.Click += new System.EventHandler(this.btnResgistrar_Click);
            this.panelRegistro.Controls.Add(this.btnResgistrar);

            // Botón Salir
            this.btnSalir.Text = "Salir";
            this.btnSalir.Location = new System.Drawing.Point(450, 350);
            this.btnSalir.Size = new System.Drawing.Size(150, 40);
            this.btnSalir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSalir_MouseClick);
            this.panelRegistro.Controls.Add(this.btnSalir);

            //Configuración final del formulario
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.panelRegistro);
            this.Name = "FrmRegistro";
            this.Text = "Registro de Usuario";
            this.Load += new System.EventHandler(this.FrmRegistro_Load);
            this.Resize += new System.EventHandler(this.FrmRegistro_Resize);

            this.panelRegistro.ResumeLayout(false);
            this.panelRegistro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNombres)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApellidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCorreo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelefono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConfirmPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarnet)).EndInit();
            this.ResumeLayout(false);
        }

        //Declaración de campos del formulario
        private System.Windows.Forms.Panel panelRegistro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtNombres, txtApellidos, txtCorreo, txtTelefono, txtUsername, txtPassword, txtConfirmPassword, txtCarnet;
        private System.Windows.Forms.PictureBox picNombres, picApellidos, picCorreo, picTelefono, picUsername, picPassword, picConfirmPassword, picCarnet;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnResgistrar;
        private System.Windows.Forms.Button btnSalir;
    }
}






