using AppFlashCard.EL;
using AppFlashCard.DAL;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFlashCard
{
    public partial class FrmRegistro : Form
    {
        private readonly string _connectionString;
        private readonly UsuarioDAL _usuarioDAL;

        public FrmRegistro()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _usuarioDAL = new UsuarioDAL(_connectionString);
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
            new FrmLogin().Show();
        }

        private async void btnResgistrar_Click(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario
            {
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Username = txtUsername.Text.Trim(),
                Clave = txtPassword.Text, // será hasheada internamente
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                CarnetEstudiante = string.IsNullOrWhiteSpace(txtCarnet.Text)
                            ? null
                            : txtCarnet.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value.Date
            };

            btnResgistrar.Enabled = false;
            var (exito, mensaje) = await _usuarioDAL.RegistrarUsuarioAsync(nuevoUsuario);
            btnResgistrar.Enabled = true;

            if (exito)
            {
                MessageBox.Show("¡Usuario registrado exitosamente!");
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error: " + mensaje);
            }
        }
    }
}
