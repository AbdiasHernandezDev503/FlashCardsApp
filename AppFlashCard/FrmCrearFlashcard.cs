using AppFlashCard.DAL;
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
    public partial class FrmCrearFlashcard : Form
    {
        public FrmCrearFlashcard()
        {
            InitializeComponent();
            lblContador.Text = "0/20 Flashcards para este tema"; // Inicializa el contador de flashcards
        }

        private async void FrmCrearFlashcard_Load(object sender, EventArgs e)
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

            await CargarMateriasAsync();
        }

        private async Task CargarMateriasAsync()
        {
            var materiaDAL = new MateriaDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            var materias = await materiaDAL.ObtenerMateriasAsync();

            cbMaterias.DataSource = materias;
            cbMaterias.DisplayMember = "Nombre";
            cbMaterias.ValueMember = "Id";
            cbMaterias.SelectedIndex = -1;
        }

        private async Task CargarTemasAsync(int materiaId)
        {
            var temaDAL = new TemaDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            var temas = await temaDAL.ObtenerTemasPorMateriaIdAsync(materiaId);

            cbTemas.DataSource = temas;
            cbTemas.DisplayMember = "Nombre";
            cbTemas.ValueMember = "Id";
            cbTemas.SelectedIndex = -1;
        }

        private async void btnCrearFlashcard_Click(object sender, EventArgs e)
        {
            if (cbTemas.SelectedItem is not Tema temaSeleccionado)
            {
                MessageBox.Show("Debes seleccionar un tema.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPregunta.Text) || string.IsNullOrWhiteSpace(txtRespuesta.Text))
            {
                MessageBox.Show("La pregunta y la respuesta no pueden estar vacías.");
                return;
            }

            var flashcard = new Flashcard
            {
                UsuarioId = SesionActiva.Usuario.Id,
                TemaId = temaSeleccionado.Id,
                Pregunta = txtPregunta.Text.Trim(),
                Respuesta = txtRespuesta.Text.Trim()
            };


            var resultado = await new FlashcardDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").CrearFlashcardAsync(flashcard);

            if (resultado.Exito)
            {
                MessageBox.Show("Flashcard creada correctamente.");
                txtPregunta.Clear();
                txtRespuesta.Clear();
            }
            else
            {
                MessageBox.Show("Error: " + resultado.Mensaje, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
        }

        private async void cbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaterias.SelectedItem is Materia materiaSeleccionada)
            {
                await CargarTemasAsync(materiaSeleccionada.Id);
            }
        }

        private async void cbTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTemas.SelectedItem is Tema temaSeleccionado)
            {
                int usuarioId = SesionActiva.Usuario.Id;
                var flashcardDAL = new FlashcardDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

                int cantidad = await flashcardDAL.ContarFlashcardAsync(usuarioId, temaSeleccionado.Id);

                lblContador.Text = $"{cantidad} / 20 flashcards usadas";

                btnGuardar.Enabled = cantidad < 20;
            }
            else
            {
                lblContador.Text = "";
                btnGuardar.Enabled = false;
            }
        }
    }
}
