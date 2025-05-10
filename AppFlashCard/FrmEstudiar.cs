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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppFlashCard.EL.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace AppFlashCard
{
    public partial class FrmEstudiar : Form
    {
        private readonly string _connectionString;
        private readonly MateriaDAL _materiaDAL;
        private readonly FlashcardDAL _flashcardDAL;

        List<InfoTemaFlashcard> datos = new(); // Lista de datos a  de ejemplo hasta conectar con la DAL
        List<Panel> cards = new();
        int currentIndex = 0;
        int cardsVisible = 3;
        int animationStep = 20;
        int animationOffset = 0;
        int animationDirection = 0; // 1 = derecha, -1 = izquierda
        private bool esperandoReinicio = false;

        public FrmEstudiar()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _materiaDAL = new MateriaDAL(_connectionString);
            _flashcardDAL = new FlashcardDAL(_connectionString);
        }

        private async void FrmEstudiar_Load(object sender, EventArgs e)
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

            datos = await _flashcardDAL.ObtenerInfoTemaFlashcardsAsync();

            // Datos para probar
            //datos = new List<InfoTemaFlashcard>
            //{
            //    new InfoTemaFlashcard { Materia = "Matemática", Tema = "Cálculo Diferencial: Derivadas", Usuario = "Juan" },
            //    new InfoTemaFlashcard { Materia = "Historia", Tema = "Edad Media", Usuario = "Ana" },
            //    new InfoTemaFlashcard { Materia = "Ciencias", Tema = "Física Básica", Usuario = "Pedro" },
            //    new InfoTemaFlashcard { Materia = "Inglés", Tema = "Tiempos Verbales", Usuario = "Laura" },
            //    new InfoTemaFlashcard { Materia = "Programación", Tema = "POO en C#", Usuario = "Sofía" },
            //    new InfoTemaFlashcard { Materia = "Matemática", Tema = "Álgebra Lineal", Usuario = "Carlos" },
            //    new InfoTemaFlashcard { Materia = "Historia", Tema = "Revolución Francesa", Usuario = "Luis" },
            //    new InfoTemaFlashcard { Materia = "Ciencias", Tema = "Biología Celular", Usuario = "María" },
            //    new InfoTemaFlashcard { Materia = "Inglés", Tema = "Vocabulario básico", Usuario = "Elena" },
            //    new InfoTemaFlashcard { Materia = "Programación", Tema = "Estructuras de datos usando un lenguaje de programacion en C# como lengujae", Usuario = "José" }
            //};

            GenerarCards();
            MostrarCards();

            if (cards.Count <= cardsVisible)
            {
                timerAutoSlider.Stop();
                btnIzquierda.Visible = false;
                btnDerecha.Visible = false;
            }
            else
            {
                timerAutoSlider.Start();
                btnIzquierda.Visible = true;
                btnDerecha.Visible = true;
            }

            var listaMaterias = await _materiaDAL.ObtenerMateriasConTemasAsync();
            menuEstudiar.Items.Clear();

            int maximoTemas = 5;
            int maximoMaterias = 7;
            int contadorMaterias = 0;

            foreach (var materia in listaMaterias)
            {
                if (contadorMaterias >= maximoMaterias)
                    break;

                var materiaItem = new ToolStripMenuItem(materia.Nombre);
                int contadorTemas = 0;

                foreach (var tema in materia.Temas)
                {
                    if (contadorTemas >= maximoTemas)
                        break;

                    var temaItem = new ToolStripMenuItem(tema.Nombre)
                    {
                        Tag = tema
                    };
                    temaItem.Click += TemaItem_Click;

                    materiaItem.DropDownItems.Add(temaItem);
                    contadorTemas++;
                }

                if (materia.Temas.Count > maximoTemas)
                {
                    var verTodosTemasItem = new ToolStripMenuItem("Ver Todos")
                    {
                        Tag = materia
                    };
                    verTodosTemasItem.Click += VerTodosTemas_Click;
                    materiaItem.DropDownItems.Add(verTodosTemasItem);
                }

                menuEstudiar.Items.Add(materiaItem);
                contadorMaterias++;
            }

            if (listaMaterias.Count > maximoMaterias)
            {
                var verTodasMateriasItem = new ToolStripMenuItem("Ver Todas las Materias")
                {
                    Tag = listaMaterias
                };
                verTodasMateriasItem.Click += VerTodasMaterias_Click;
                menuEstudiar.Items.Add(verTodasMateriasItem);
            }
        }

        private void GenerarCards()
        {
            cards.Clear();
            ToolTip toolTip = new ToolTip();

            foreach (var item in datos)
            {
                Panel card = new Panel
                {
                    Width = 250,
                    Height = 200,
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.White
                };

                Label lblTema = new Label
                {
                    Text = item.Tema,
                    Font = new Font("Segoe UI", 11, FontStyle.Bold),
                    AutoSize = false,
                    Width = 200,
                    Height = 40,
                    MaximumSize = new Size(160, 40),
                    Location = new Point(10, 10),
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoEllipsis = true
                };
                toolTip.SetToolTip(lblTema, item.Tema);

                Label lblMateria = new Label
                {
                    Text = item.Materia,
                    BackColor = Color.MediumPurple,
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    AutoSize = false,
                    Width = 125,
                    Height = 25,
                    Location = new Point(40, 60)
                };
                toolTip.SetToolTip(lblMateria, item.Materia);

                Label lblUsuario = new Label
                {
                    Text = $"por {item.Usuario}",
                    Font = new Font("Segoe UI", 8, FontStyle.Italic),
                    AutoSize = false,
                    Width = 160,
                    Height = 20,
                    MaximumSize = new Size(160, 20),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(10, 100),
                    AutoEllipsis = true
                };
                toolTip.SetToolTip(lblUsuario, item.Usuario);

                card.Controls.Add(lblTema);
                card.Controls.Add(lblMateria);
                card.Controls.Add(lblUsuario);
                card.Tag = item;
                card.Click += Card_Click;
                card.Cursor = Cursors.Hand;
                cards.Add(card);
            }
        }

        private void Card_CursorChanged(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Card_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is InfoTemaFlashcard info)
            {
                this.Hide();
                FrmFlashcardEstudio frmFlashcardEstudio = new FrmFlashcardEstudio();
                frmFlashcardEstudio.ShowDialog();
            }
        }


        private void MostrarCards()
        {
            panelSlider.Controls.Clear();

            if (cards.Count == 0)
                return;

            if (currentIndex < 0)
                currentIndex = 0;

            if (currentIndex > cards.Count - 1)
                currentIndex = Math.Max(0, cards.Count - cardsVisible);

            int x = 0;

            for (int i = currentIndex; i < currentIndex + cardsVisible && i < cards.Count; i++)
            {
                var card = cards[i];
                card.Location = new Point(x, 10);
                panelSlider.Controls.Add(card);
                x += card.Width + 10;
            }
        }




        private void TemaItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is Tema tema)
            {
                MessageBox.Show($"Seleccionaste el tema: {tema.Nombre} (ID: {tema.Id})");

                // Aquí podés abrir el formulario de estudio o cargar las flashcards del tema
                // new FrmEstudiarTema(tema).Show(); por ejemplo
            }
        }

        private void VerTodasMaterias_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is List<Materia> materias)
            {
                MessageBox.Show($"Ver todas las materias ({materias.Count})");
                // Aquí podrías abrir una vista tipo grid o lista
            }
        }

        private void VerTodosTemas_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is Materia materia)
            {
                MessageBox.Show($"Mostrar todos los temas de: {materia.Nombre}");

                // Aquí podrías abrir una ventana que muestre todos los temas de esa materia
                // Ejemplo:
                // new FrmTodosLosTemas(materia).Show();
            }
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
        }

        private void btnDerecha_Click(object sender, EventArgs e)
        {
            if (currentIndex + cardsVisible < cards.Count)
            {
                animationDirection = -1;
                animTimer.Start();
                timerAutoSlider.Stop();
                timerAutoSlider.Start(); // reinicia el tiempo

            }
        }

        private void btnIzquierda_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                animationDirection = 1;
                animTimer.Start();
                timerAutoSlider.Stop();
                timerAutoSlider.Start(); // reinicia el tiempo
            }
        }

        private void animTimer_Tick(object sender, EventArgs e)
        {
            animationOffset += animationStep;

            foreach (Control card in panelSlider.Controls)
            {
                card.Left += animationStep * animationDirection;
            }

            if (animationOffset >= 180 + 10) // ancho del card + separación
            {
                animTimer.Stop();
                animationOffset = 0;

                currentIndex = currentIndex - animationDirection;
                MostrarCards();
            }
        }

        private void timerAutoSlider_Tick(object sender, EventArgs e)
        {
            if (esperandoReinicio)
                return;

            if (currentIndex + cardsVisible < cards.Count)
            {
                animationDirection = -1;
                animTimer.Start();
            }
            else
            {
                esperandoReinicio = true;
                timerDelayReinicio.Start();
            }

        }

        private void timerDelayReinicio_Tick(object sender, EventArgs e)
        {
            timerDelayReinicio.Stop();
            esperandoReinicio = false;

            currentIndex = -1; 
            animationDirection = -1;
            animTimer.Start();
        }
    }
}
