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
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

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

        //Fuentes que utilizamos 
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;

        public FrmEstudiar()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _materiaDAL = new MateriaDAL(_connectionString);
            _flashcardDAL = new FlashcardDAL(_connectionString);
            CargarFuenteRaleway();
            this.Resize += FrmEstudiar_Resize;
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
            ralewaySemiBold = new Font(
                fuentesPersonalizadas.Families.Length > 1
                    ? fuentesPersonalizadas.Families[1]
                    : fuentesPersonalizadas.Families[0],
                12f, FontStyle.Bold);
        }

        private Region CrearRegionRedondeada(Rectangle bounds, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
            path.AddArc(bounds.Right - radio, bounds.Y, radio, radio, 270, 90);
            path.AddArc(bounds.Right - radio, bounds.Bottom - radio, radio, radio, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radio, radio, radio, 90, 90);
            path.CloseFigure();
            return new Region(path);
        }

        private async void FrmEstudiar_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#2D3250");
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

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

            // Aplicar paleta de colores armoniosa
            this.BackColor = ColorTranslator.FromHtml("#424769");
            panelSlider.BackColor = ColorTranslator.FromHtml("#424769");

            // Menú superior
            menuEstudiar.BackColor = ColorTranslator.FromHtml("#f9b17a");
            menuEstudiar.ForeColor = Color.White;
            menuEstudiar.Renderer = new ToolStripProfessionalRenderer(new ColorTablePersonalizado());

            foreach (ToolStripMenuItem item in menuEstudiar.Items)
            {
                item.ForeColor = Color.White;
                item.BackColor = ColorTranslator.FromHtml("#f9b17a");
                item.Font = ralewaySemiBold;

                foreach (ToolStripItem subItem in item.DropDownItems)
                {
                    subItem.ForeColor = ColorTranslator.FromHtml("#f9b17a");
                    subItem.BackColor = ColorTranslator.FromHtml("#2d3250");
                    subItem.Font = ralewayRegular;
                }
            }

            // Estilo para el título
            label1.Font = new Font(ralewaySemiBold.FontFamily, 14f, FontStyle.Bold);
            label1.ForeColor = ColorTranslator.FromHtml("#ffffff");
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.AutoSize = true; 
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;

            // Botones
            btnIzquierda.Font = ralewaySemiBold;
            btnDerecha.Font = ralewaySemiBold;
            btnSalir.Font = ralewaySemiBold;

            btnIzquierda.ForeColor = Color.White;
            btnDerecha.ForeColor = Color.White;
            btnSalir.ForeColor = Color.White;

            btnIzquierda.BackColor = ColorTranslator.FromHtml("#b76f9d");
            btnDerecha.BackColor = ColorTranslator.FromHtml("#f9b17a");
            btnSalir.BackColor = ColorTranslator.FromHtml("#2d3250");

            btnIzquierda.FlatStyle = FlatStyle.Flat;
            btnDerecha.FlatStyle = FlatStyle.Flat;
            btnSalir.FlatStyle = FlatStyle.Flat;

            btnIzquierda.FlatAppearance.BorderSize = 0;
            btnDerecha.FlatAppearance.BorderSize = 0;
            btnSalir.FlatAppearance.BorderSize = 0;

            btnIzquierda.Region = CrearRegionRedondeada(btnIzquierda.ClientRectangle, 14);
            btnDerecha.Region = CrearRegionRedondeada(btnDerecha.ClientRectangle, 14);
            btnSalir.Region = CrearRegionRedondeada(btnSalir.ClientRectangle, 14);

            // Estilo del botón Salir
            btnSalir.Font = ralewaySemiBold;
            btnSalir.ForeColor = Color.White;
            btnSalir.BackColor = ColorTranslator.FromHtml("#2d3250");
            btnSalir.FlatStyle = FlatStyle.Flat;   
            btnSalir.Region = CrearRegionRedondeada(btnSalir.ClientRectangle, 13);

            // Centrado vertical 
            btnSalir.Top = this.ClientSize.Height - btnSalir.Height - 40;

            // Alinear a la derecha
            btnSalir.Left = this.ClientSize.Width - btnSalir.Width - 40;



        }

        private void FrmEstudiar_Resize(object sender, EventArgs e)
        {
            label1.AutoSize = true;
            label1.Left = (this.ClientSize.Width - label1.Width) / 2;
            // Mantener el botón alineado a la derecha en tiempo real
            btnSalir.Left = this.ClientSize.Width - btnSalir.Width - 40;

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

        private async void Card_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is InfoTemaFlashcard info)
            {
                this.Hide();
                var flashcards = await _flashcardDAL.ObtenerFlashcardsPorTemaUsuarioAsync(info.TemaId, info.UsuarioId);

                if (flashcards.Any())
                {
                    FrmFlashcardEstudio estudio = new FrmFlashcardEstudio(flashcards, info.Tema);
                    estudio.Show();
                }
                else
                {
                    MessageBox.Show("Este usuario aún no ha creado flashcards para este tema.");
                }
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

                FrmTemasMaterias frmTemasMaterias = new FrmTemasMaterias(null, tema.Nombre);
                this.Hide();
                frmTemasMaterias.Show();
            }
        }

        private void VerTodasMaterias_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is List<Materia> materias)
            {
                FrmTemasMaterias frmTemasMaterias = new FrmTemasMaterias(null, null); 
                this.Hide();
                frmTemasMaterias.Show();
            }
        }

        private void VerTodosTemas_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem item && item.Tag is Materia materia)
            {
                FrmTemasMaterias frmTemasMaterias = new FrmTemasMaterias(materia, null);
                this.Hide();
                frmTemasMaterias.Show();
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
        public class ColorTablePersonalizado : ProfessionalColorTable
        {
            public override Color MenuItemSelected => ColorTranslator.FromHtml("#424769");
            public override Color MenuItemSelectedGradientBegin => ColorTranslator.FromHtml("#424769");
            public override Color MenuItemSelectedGradientEnd => ColorTranslator.FromHtml("#424769");
            public override Color MenuItemBorder => ColorTranslator.FromHtml("#424769");

            public override Color ToolStripDropDownBackground => ColorTranslator.FromHtml("#2d3250");
            public override Color ImageMarginGradientBegin => ColorTranslator.FromHtml("#2d3250");
            public override Color ImageMarginGradientMiddle => ColorTranslator.FromHtml("#2d3250");
            public override Color ImageMarginGradientEnd => ColorTranslator.FromHtml("#2d3250");

            public override Color MenuItemPressedGradientBegin => ColorTranslator.FromHtml("#424769");
            public override Color MenuItemPressedGradientEnd => ColorTranslator.FromHtml("#424769");
        }


    }
}
