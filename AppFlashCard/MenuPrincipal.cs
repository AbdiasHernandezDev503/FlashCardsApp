using AppFlashCard.EL;
using AppFlashCard.Utils;
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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            if (SesionActiva.Usuario == null)
            {
                MessageBox.Show("Sesión no válida. Por favor inicia sesión.", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();

                this.Close(); // Cierra el acceso no autorizado
                return;
            }
            else
                lblBienvenida.Text = $"Bienvenido, {SesionActiva.Usuario.Nombres} {SesionActiva.Usuario.Apellidos}";
        }

        private void btnEstudiar_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmEstudiar estudiar = new FrmEstudiar();
            estudiar.Show();

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cerrar sesión
            SesionActiva.Usuario = null;

            // Voolver al formulario de inicio de sesión
            FrmLogin login = new FrmLogin();
            login.Show();

            this.Hide();
        }

        private void btnCrearFlashcards_Click(object sender, EventArgs e)
        {
            this.Hide();

            FrmCrearFlashcard frmCrearFlashcard = new FrmCrearFlashcard();
            frmCrearFlashcard.Show();
        }

        private void lblBienvenida_Click(object sender, EventArgs e)
        {

        }

        private void btnMiUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}