using AppFlashCard.EL;
using AppFlashCard.DAL;
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
        public FrmRegistro()
        {
            InitializeComponent();
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

            // Conexion temporal se buscara otra forma de obtener la cadena de conexion
            var dal = new UsuarioDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

            var (exito, mensaje) = await dal.RegistrarUsuarioAsync(nuevoUsuario);

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
