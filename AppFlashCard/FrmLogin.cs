using AppFlashCard.DAL;
using AppFlashCard.Utils;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AppFlashCard
{
    public partial class FrmLogin : Form
    {
        private readonly string _connectionString;
        private readonly UsuarioDAL _usuarioDAL;

        private Timer animacionEntrada; // Temporizador para la animación de entrada del panel
        private int targetLeft; // Posición final horizontal del panelLogin

        //Fuentes que utilizamos 
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;

        public FrmLogin()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _usuarioDAL = new UsuarioDAL(_connectionString);

            this.Load += FrmLogin_Load;
            this.Resize += FrmLogin_Resize;
            this.WindowState = FormWindowState.Maximized; // Abre la ventana maximizada
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#2D3250");
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;



            CargarFuenteRaleway();

            // Asignación de fuentes a los controles
            lblTitulo.Font = new Font(fuentesPersonalizadas.Families[0], 20F, FontStyle.Bold);
            txtUsername.Font = ralewayRegular;
            txtPassword.Font = ralewayRegular;
            chkMostrarPassword.Font = ralewayRegular;
            btnRegistrar.Font = ralewaySemiBold;
            btnIniciarSesion.Font = ralewaySemiBold;
            btnSalir.Font = ralewaySemiBold;

            // Estilo visual de los controles
            panelLogin.BackColor = ColorTranslator.FromHtml("#424769");
            lblTitulo.ForeColor = Color.White;
            chkMostrarPassword.ForeColor = Color.White;
            txtUsername.BackColor = Color.White;
            txtUsername.ForeColor = ColorTranslator.FromHtml("#2D3250");
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = ColorTranslator.FromHtml("#2D3250");
            txtPassword.BorderStyle = BorderStyle.FixedSingle;

            // Bordes redondeados
            btnRegistrar.Region = new Region(CrearRegionRedondeada(btnRegistrar.ClientRectangle, 7));
            btnIniciarSesion.Region = new Region(CrearRegionRedondeada(btnIniciarSesion.ClientRectangle, 7));
            btnSalir.Region = new Region(CrearRegionRedondeada(btnSalir.ClientRectangle, 7));

            // Efectos de hover
            AgregarHover(btnRegistrar, ColorTranslator.FromHtml("#B76F9D"));
            AgregarHover(btnIniciarSesion, ColorTranslator.FromHtml("#F9B17A"));
            AgregarHover(btnSalir, ColorTranslator.FromHtml("#2D3250"));
            btnSalir.ForeColor = Color.White;

            //Tamaño del panelLogin
            panelLogin.Width = 400;
            panelLogin.Height = 360;
            FrmLogin_Resize(this, EventArgs.Empty);

            //Animación de entrada del panel 
            animacionEntrada = new Timer();
            animacionEntrada.Interval = 10;
            animacionEntrada.Tick += AnimarEntrada;
            animacionEntrada.Start();
        }

        //Fuentes 
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
            ralewaySemiBold = new Font(fuentesPersonalizadas.Families[1], 11f, FontStyle.Bold);
        }

        private void AnimarEntrada(object sender, EventArgs e)
        {
            if (panelLogin.Left < targetLeft)
            {
                panelLogin.Left += 20; // Mueve el panel a la derecha
            }
            else
            {
                panelLogin.Left = targetLeft;
                animacionEntrada.Stop();
            }
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

        private void AgregarHover(Button boton, Color originalColor)
        {
            boton.BackColor = originalColor;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;

            boton.MouseEnter += (s, e) => boton.BackColor = ControlPaint.Light(originalColor);
            boton.MouseLeave += (s, e) => boton.BackColor = originalColor;
        }

        private void chkMostrarPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkMostrarPassword.Checked;
        }

        private void btnRegistrar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            using (FrmRegistro registro = new FrmRegistro())
            {
                registro.ShowDialog();
            }
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            targetLeft = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
             CentrarPanelLogin();
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void CentrarPanelLogin()
        {
            panelLogin.Left = (this.ClientSize.Width - panelLogin.Width) / 2;
            panelLogin.Top = (this.ClientSize.Height - panelLogin.Height) / 2;
        }

        

        private async void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string clave = txtPassword.Text;

            try
            {
                var usuario = await _usuarioDAL.LoginUsuarioAsync(username, clave);

                if (usuario != null)
                {
                    SesionActiva.Usuario = usuario;
                    MessageBox.Show("\u00a1Inicio de sesión exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();

                    this.Hide();
                    menu.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al iniciar sesión: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}




