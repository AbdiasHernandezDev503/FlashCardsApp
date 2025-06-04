using System.Configuration;
using System.Drawing;

namespace AppFlashCard
{
    partial class FrmRegistro
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
            this.picVerPassword = new System.Windows.Forms.PictureBox();
            this.picVerConfirmPassword = new System.Windows.Forms.PictureBox();

            this.panelRegistro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNombres)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picApellidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCorreo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTelefono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picConfirmPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCarnet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerConfirmPassword)).BeginInit();

            this.SuspendLayout();

            // Panel
            this.panelRegistro.Location = new System.Drawing.Point(60, 20);
            this.panelRegistro.Size = new System.Drawing.Size(900, 505);
            this.panelRegistro.BackColor = System.Drawing.Color.FromArgb(66, 71, 105);

            // Título
            this.lblTitulo.Text = "Crear Cuenta";
            this.lblTitulo.Font = new System.Drawing.Font("ralewaySemiBold", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(370, 20);
            this.panelRegistro.Controls.Add(this.lblTitulo);

            // Campo Nombres
            this.picNombres.Location = new System.Drawing.Point(60, 80);
            this.picNombres.Size = new System.Drawing.Size(24, 24);
            this.picNombres.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picNombres.Image = Image.FromFile("Images/user.png");
            this.txtNombres.Location = new System.Drawing.Point(90, 80);
            this.txtNombres.Size = new System.Drawing.Size(260, 27);
            this.txtNombres.PlaceholderText = "Nombres";
            this.panelRegistro.Controls.Add(this.picNombres);
            this.panelRegistro.Controls.Add(this.txtNombres);

            // Campo Apellidos
            this.picApellidos.Location = new System.Drawing.Point(500, 80);
            this.picApellidos.Size = new System.Drawing.Size(24, 24);
            this.picApellidos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picApellidos.Image = Image.FromFile("Images/apellido.png");
            this.txtApellidos.Location = new System.Drawing.Point(530, 80);
            this.txtApellidos.Size = new System.Drawing.Size(260, 27);
            this.txtApellidos.PlaceholderText = "Apellidos";
            this.panelRegistro.Controls.Add(this.picApellidos);
            this.panelRegistro.Controls.Add(this.txtApellidos);

            // Fecha nacimiento
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(90, 130);
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(260, 27);
            this.panelRegistro.Controls.Add(this.dtpFechaNacimiento);

            // Campo Teléfono
            this.picTelefono.Location = new System.Drawing.Point(500, 130);
            this.picTelefono.Size = new System.Drawing.Size(24, 24);
            this.picTelefono.SizeMode = PictureBoxSizeMode.Zoom;
            this.picTelefono.Image = Image.FromFile("Images/phone.png");
            this.txtTelefono.Location = new System.Drawing.Point(530, 130);
            this.txtTelefono.Size = new System.Drawing.Size(260, 27);
            this.txtTelefono.PlaceholderText = "Teléfono";
            this.panelRegistro.Controls.Add(this.picTelefono);
            this.panelRegistro.Controls.Add(this.txtTelefono);

            // Campo Correo
            this.picCorreo.Location = new System.Drawing.Point(60, 180);
            this.picCorreo.Size = new System.Drawing.Size(24, 24);
            this.picCorreo.SizeMode = PictureBoxSizeMode.Zoom;
            this.picCorreo.Image = Image.FromFile("Images/email.png");
            this.txtCorreo.Location = new System.Drawing.Point(90, 180);
            this.txtCorreo.Size = new System.Drawing.Size(260, 27);
            this.txtCorreo.PlaceholderText = "Correo";
            this.panelRegistro.Controls.Add(this.picCorreo);
            this.panelRegistro.Controls.Add(this.txtCorreo);

            // Campo Username
            this.picUsername.Location = new System.Drawing.Point(500, 180);
            this.picUsername.Size = new System.Drawing.Size(24, 24);
            this.picUsername.SizeMode = PictureBoxSizeMode.Zoom;
            this.picUsername.Image = Image.FromFile("Images/username.png");
            this.txtUsername.Location = new System.Drawing.Point(530, 180);
            this.txtUsername.Size = new System.Drawing.Size(260, 27);
            this.txtUsername.PlaceholderText = "Usuario";
            this.panelRegistro.Controls.Add(this.picUsername);
            this.panelRegistro.Controls.Add(this.txtUsername);

            // Campo Password
            this.picPassword.Location = new System.Drawing.Point(60, 230);
            this.picPassword.Size = new System.Drawing.Size(24, 24);
            this.picPassword.SizeMode = PictureBoxSizeMode.Zoom;
            this.picPassword.Image = Image.FromFile("Images/icono_password.png");
            this.txtPassword.Location = new System.Drawing.Point(90, 230);
            this.txtPassword.Size = new System.Drawing.Size(260, 27);
            this.txtPassword.PlaceholderText = "Contraseña";
            this.txtPassword.UseSystemPasswordChar = true;
            this.panelRegistro.Controls.Add(this.picPassword);
            this.panelRegistro.Controls.Add(this.txtPassword);

            // Icono mostrar Password 
            this.picVerPassword = new System.Windows.Forms.PictureBox();
            this.picVerPassword.Size = new System.Drawing.Size(20, 20);
            this.picVerPassword.SizeMode = PictureBoxSizeMode.Zoom;
            this.picVerPassword.Image = Image.FromFile("Images/view.png");
            this.picVerPassword.BackColor = Color.White; 
            this.picVerPassword.Cursor = Cursors.Hand;
            this.picVerPassword.Click += new System.EventHandler(this.picVerPassword_Click);
            this.picVerPassword.Location = new Point(txtPassword.Right - 22, txtPassword.Top + 3);
            this.picVerPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.panelRegistro.Controls.Add(this.picVerPassword);
            this.picVerPassword.BringToFront();

            // Campo Confirmar Password
            this.picConfirmPassword.Location = new System.Drawing.Point(500, 230);
            this.picConfirmPassword.Size = new System.Drawing.Size(24, 24);
            this.picConfirmPassword.SizeMode = PictureBoxSizeMode.Zoom;
            this.picConfirmPassword.Image = Image.FromFile("Images/confirm.png");
            this.txtConfirmPassword.Location = new System.Drawing.Point(530, 230);
            this.txtConfirmPassword.Size = new System.Drawing.Size(260, 27);
            this.txtConfirmPassword.PlaceholderText = "Confirmar";
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            this.panelRegistro.Controls.Add(this.picConfirmPassword);
            this.panelRegistro.Controls.Add(this.txtConfirmPassword);

            // Icono mostrar Confirm Password
            this.picVerConfirmPassword = new System.Windows.Forms.PictureBox();
            this.picVerConfirmPassword.Size = new System.Drawing.Size(20, 20);
            this.picVerConfirmPassword.SizeMode = PictureBoxSizeMode.Zoom;
            this.picVerConfirmPassword.Image = Image.FromFile("Images/view.png");
            this.picVerConfirmPassword.BackColor = Color.White; 
            this.picVerConfirmPassword.Cursor = Cursors.Hand;
            this.picVerConfirmPassword.Click += new System.EventHandler(this.picVerConfirmPassword_Click);
            this.picVerConfirmPassword.Location = new Point(txtConfirmPassword.Right - 22, txtConfirmPassword.Top + 3);
            this.picVerConfirmPassword.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.panelRegistro.Controls.Add(this.picVerConfirmPassword);
            this.picVerConfirmPassword.BringToFront();

            // Campo Carnet
            this.picCarnet.Location = new System.Drawing.Point(60, 280);
            this.picCarnet.Size = new System.Drawing.Size(24, 24);
            this.picCarnet.SizeMode = PictureBoxSizeMode.Zoom;
            this.picCarnet.Image = Image.FromFile("Images/card.png");
            this.txtCarnet.Location = new System.Drawing.Point(90, 280);
            this.txtCarnet.Size = new System.Drawing.Size(260, 27);
            this.txtCarnet.PlaceholderText = "Carnet";
            this.panelRegistro.Controls.Add(this.picCarnet);
            this.panelRegistro.Controls.Add(this.txtCarnet);

            // Botón Registrar
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

            // Form
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
            ((System.ComponentModel.ISupportInitialize)(this.picVerPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picVerConfirmPassword)).EndInit();
            this.ResumeLayout(false);
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private System.Windows.Forms.Panel panelRegistro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtNombres, txtApellidos, txtCorreo, txtTelefono, txtUsername, txtPassword, txtConfirmPassword, txtCarnet;
        private System.Windows.Forms.PictureBox picNombres, picApellidos, picCorreo, picTelefono, picUsername, picPassword, picConfirmPassword, picCarnet;
        private System.Windows.Forms.PictureBox picVerPassword, picVerConfirmPassword;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Button btnResgistrar, btnSalir;
    }
}

