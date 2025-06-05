using AppFlashCard.DAL;
using AppFlashCard.EL;
using AppFlashCard.Utils;
using System;
using System.Configuration;
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

            // Leer la cadena de conexión desde App.config
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _flashcardDAL = new FlashcardDAL(_connectionString);
            _materiaDAL = new MateriaDAL(_connectionString);
            _temaDAL = new TemaDAL(_connectionString);
        }

        /// <summary>
        /// Al cargar el formulario, recargamos la lista de materias.
        /// </summary>
        private async void FrmCrearFlashcard_Load(object sender, EventArgs e)
        {
            // Verificar sesión activa
            if (SesionActiva.Usuario == null)
            {
                MessageBox.Show(
                    "Sesión no válida. Por favor inicia sesión.",
                    "Acceso denegado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                this.Hide();
                FrmLogin login = new FrmLogin();
                login.Show();
                this.Close();
                return;
            }

            // Cargar el combo de materias
            await CargarMateriasAsync();

            // Dejar los combobox sin selección inicial
            cbMaterias.SelectedIndex = -1;
            cbTemas.DataSource = null;
            lblContador.Text = "";
            btnGuardar.Enabled = false;
        }

        /// <summary>
        /// Trae todas las materias desde la base de datos y las asigna al ComboBox.
        /// </summary>
        private async Task CargarMateriasAsync()
        {
            var materias = await _materiaDAL.ObtenerMateriasAsync();
            cbMaterias.DataSource = materias;
            cbMaterias.DisplayMember = "Nombre";
            cbMaterias.ValueMember = "Id";
            cbMaterias.SelectedIndex = -1;
        }

        /// <summary>
        /// Trae todos los temas de la materia indicada y los asigna al ComboBox de temas.
        /// </summary>
        private async Task CargarTemasAsync(int materiaId)
        {
            var temas = await _temaDAL.ObtenerTemasPorMateriaIdAsync(materiaId);
            cbTemas.DataSource = temas;
            cbTemas.DisplayMember = "Nombre";
            cbTemas.ValueMember = "Id";
            cbTemas.SelectedIndex = -1;
        }

        /// <summary>
        /// Cuando el usuario selecciona una materia distinta, recargamos los temas de esa materia.
        /// </summary>
        private async void cbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaterias.SelectedItem is Materia materiaSeleccionada)
            {
                // Cargar los temas de la materia seleccionada
                await CargarTemasAsync(materiaSeleccionada.Id);
            }
            else
            {
                cbTemas.DataSource = null;
                lblContador.Text = "";
                btnGuardar.Enabled = false;
            }
        }

        /// <summary>
        /// Cuando el usuario cambia el tema, actualizamos el contador de flashcards usadas para este tema.
        /// </summary>
        private async void cbTemas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTemas.SelectedItem is Tema temaSeleccionado)
            {
                int usuarioId = SesionActiva.Usuario.Id;
                int cantidad = await _flashcardDAL.ContarFlashcardAsync(usuarioId, temaSeleccionado.Id);
                lblContador.Text = $"{cantidad} / 20 flashcards usadas";
                btnGuardar.Enabled = (cantidad < 20);
            }
            else
            {
                lblContador.Text = "";
                btnGuardar.Enabled = false;
            }
        }

        /// <summary>
        /// Guardar la nueva flashcard. Se dispara al hacer clic en "Guardar Flashcard".
        /// </summary>
        private async void btnCrearFlashcard_Click(object sender, EventArgs e)
        {
            if (cbMaterias.SelectedItem is not Materia materiaSeleccionada)
            {
                MessageBox.Show("Debes seleccionar una materia.");
                return;
            }

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

            var nuevaFlashcard = new Flashcard
            {
                UsuarioId = SesionActiva.Usuario.Id,
                TemaId = temaSeleccionado.Id,
                Pregunta = txtPregunta.Text.Trim(),
                Respuesta = txtRespuesta.Text.Trim()
            };

            var resultado = await _flashcardDAL.CrearFlashcardAsync(nuevaFlashcard);
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
                MessageBox.Show(
                    "Error: " + resultado.Mensaje,
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        /// <summary>
        /// Cierra esta ventana y regresa al Menú Principal.
        /// </summary>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
        }
    }
}


