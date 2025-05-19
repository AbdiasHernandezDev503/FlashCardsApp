using AppFlashCard.EL;
using AppFlashCard.DAL;
using System.Configuration;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace AppFlashCard
{
    public partial class FrmRegistro : Form
    {
        private readonly string _connectionString;
        private readonly UsuarioDAL _usuarioDAL;

        //Fuentes 
        private PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        private Font ralewayRegular;
        private Font ralewaySemiBold;

        public FrmRegistro()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _usuarioDAL = new UsuarioDAL(_connectionString);

            // Asociar eventos al formulario
            this.Load += FrmRegistro_Load;
            this.Resize += FrmRegistro_Resize;
            this.WindowState = FormWindowState.Maximized;

        }

        //Estiliza el formulario
        private void FrmRegistro_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#2D3250"); // Fondo general
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            CargarFuenteRaleway();

            lblTitulo.Font = new Font(fuentesPersonalizadas.Families[0], 20F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;

            // Aplica estilo uniforme a los campos
            var campos = new[]
            {
                txtNombres, txtApellidos, txtCorreo, txtTelefono,
                txtUsername, txtPassword, txtConfirmPassword, txtCarnet
            };

            foreach (var txt in campos)
            {
                txt.Font = ralewayRegular;
                txt.BackColor = Color.White;
                txt.ForeColor = ColorTranslator.FromHtml("#2D3250");
                txt.BorderStyle = BorderStyle.FixedSingle;
            }

            // Oculta contraseñas
            txtPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.UseSystemPasswordChar = true;

            // Estilo de los botones
            btnResgistrar.Font = ralewaySemiBold;
            btnSalir.Font = ralewaySemiBold;

            btnResgistrar.Region = new Region(CrearRegionRedondeada(btnResgistrar.ClientRectangle, 7));
            btnSalir.Region = new Region(CrearRegionRedondeada(btnSalir.ClientRectangle, 7));

            AgregarHoverConSombra(btnResgistrar, ColorTranslator.FromHtml("#F9B17A"));
            AgregarHover(btnSalir, ColorTranslator.FromHtml("#2D3250"));
            btnSalir.ForeColor = Color.White;
        }

        private void FrmRegistro_Resize(object sender, EventArgs e) //Centra el panel en la ventana
        {
            panelRegistro.Left = (this.ClientSize.Width - panelRegistro.Width) / 2;
            panelRegistro.Top = (this.ClientSize.Height - panelRegistro.Height) / 2;
        }

        private void CargarFuenteRaleway()
        {
            var assembly = Assembly.GetExecutingAssembly();

            void CargarTTF(string resourceName)
            {
                Stream stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    MessageBox.Show($"No se encontró el recurso embebido:\n{resourceName}", "Error al cargar fuente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] fontData = new byte[stream.Length];
                stream.Read(fontData, 0, (int)stream.Length);
                IntPtr data = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, data, fontData.Length);
                fuentesPersonalizadas.AddMemoryFont(data, fontData.Length);
            }

            CargarTTF("AppFlashCard.Fonts.Raleway-Regular.ttf");
            CargarTTF("AppFlashCard.Fonts.Raleway-SemiBold.ttf");

            ralewayRegular = new Font(fuentesPersonalizadas.Families[0], 12f, FontStyle.Regular);
            ralewaySemiBold = new Font(fuentesPersonalizadas.Families[0], 11f, FontStyle.Bold);
        }

        private GraphicsPath CrearRegionRedondeada(Rectangle rect, int radio)
        {
            int diameter = radio * 1;
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void AgregarHover(Button boton, Color originalColor) // Crea botón con esquinas redondeadas
        {
            boton.BackColor = originalColor;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;
            boton.MouseEnter += (s, e) => boton.BackColor = ControlPaint.Light(originalColor);
            boton.MouseLeave += (s, e) => boton.BackColor = originalColor;
        }

        private void AgregarHoverConSombra(Button boton, Color originalColor) //Efecto hover con sombra/borde
        {
            boton.BackColor = originalColor;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;

            boton.MouseEnter += (s, e) =>
            {
                boton.BackColor = ControlPaint.Light(originalColor);
                boton.FlatAppearance.MouseOverBackColor = ControlPaint.LightLight(originalColor);
                boton.FlatAppearance.BorderColor = Color.Gray;
                boton.FlatAppearance.BorderSize = 1;
            };

            boton.MouseLeave += (s, e) =>
            {
                boton.BackColor = originalColor;
                boton.FlatAppearance.BorderSize = 0;
            };
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e) // Cerrar formulario y volver al login
        {
            this.Close();
            new FrmLogin().Show();
        }

        private async void btnResgistrar_Click(object sender, EventArgs e) // Registrar nuevo usuario
        {
            Usuario nuevoUsuario = new Usuario
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Clave = txtPassword.Text,
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                CarnetEstudiante = string.IsNullOrWhiteSpace(txtCarnet.Text) ? null : txtCarnet.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date
            };

            btnResgistrar.Enabled = false;
            var (exito, mensaje) = await _usuarioDAL.RegistrarUsuarioAsync(nuevoUsuario);
            btnResgistrar.Enabled = true;

            if (exito)
            {
                MessageBox.Show("¡Usuario registrado exitosamente!");
                new FrmLogin().Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: " + mensaje);
            }
        }
    }
}






