using AppFlashCard.DAL;
using AppFlashCard.Utils;
using System.Configuration;
using System.Windows.Forms;

namespace AppFlashCard
{
    public partial class FrmLogin : Form
    {
        private readonly string _connectionString;
        private readonly UsuarioDAL _usuarioDAL;    

        public FrmLogin()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _usuarioDAL = new UsuarioDAL(_connectionString);
        }

        private void btnRegistrar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            using (FrmRegistro registro = new FrmRegistro())
            {
                registro.ShowDialog();
            }
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
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
                    MessageBox.Show("¡Inicio de sesión exitoso!", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
