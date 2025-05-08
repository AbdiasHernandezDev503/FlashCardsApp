using AppFlashCard.DAL;
using AppFlashCard.Utils;
using System.Windows.Forms;

namespace AppFlashCard
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
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

            var dal = new UsuarioDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            try
            {
                var usuario = await dal.LoginUsuarioAsync(username, clave);

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
