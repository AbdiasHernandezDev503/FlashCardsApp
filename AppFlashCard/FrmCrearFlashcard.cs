using AppFlashCard.DAL;
using AppFlashCard.EL;
using AppFlashCard.Utils;
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
    public partial class FrmCrearFlashcard : Form
    {
        private readonly string _connectionString;
        private readonly FlashcardDAL _flashcardDAL;
        private readonly MateriaDAL _materiaDAL;
        private readonly TemaDAL _temaDAL;

        public FrmCrearFlashcard()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _flashcardDAL = new FlashcardDAL(_connectionString);
            _materiaDAL = new MateriaDAL(_connectionString);
            _temaDAL = new TemaDAL(_connectionString);
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
            var materias = await _materiaDAL.ObtenerMateriasAsync();

            cbMaterias.DataSource = materias;
            cbMaterias.DisplayMember = "Nombre";
            cbMaterias.ValueMember = "Id";
            cbMaterias.SelectedIndex = -1;
        }

        private async Task CargarTemasAsync(int materiaId)
        {
            var temas = await _temaDAL.ObtenerTemasPorMateriaIdAsync(materiaId);

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


            var resultado = await _flashcardDAL.CrearFlashcardAsync(flashcard);

            if (resultado.Exito)
            {
                MessageBox.Show("Flashcard creada correctamente.");
                txtPregunta.Clear();
                txtRespuesta.Clear();
                cbMaterias.SelectedIndex = -1;
                cbTemas.SelectedIndex = -1; 
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

                int cantidad = await _flashcardDAL.ContarFlashcardAsync(usuarioId, temaSeleccionado.Id);

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
