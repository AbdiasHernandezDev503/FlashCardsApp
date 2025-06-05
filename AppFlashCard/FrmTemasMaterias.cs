using AppFlashCard.DAL;
using AppFlashCard.EL;
using AppFlashCard.EL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFlashCard
{
    public partial class FrmTemasMaterias : Form
    {
        private readonly Materia _materiaSeleccionada;
        private readonly string _temaSeleccionado;
        private readonly string _connectionString;
        private readonly FlashcardDAL _flashcardDAL;

        private List<InfoTemaFlashcard> listaTemasMaterias = new();

        //Fuentes que utilizamos 
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;

        public FrmTemasMaterias(Materia materia, string temaSeleccionado)
        {
            InitializeComponent();
            txtBusqueda.Text = "Escribe el valor de la búsqueda";

            _materiaSeleccionada = materia;
            _temaSeleccionado = temaSeleccionado;
            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _flashcardDAL = new FlashcardDAL(_connectionString);
            CargarFuenteRaleway();
            this.Load += FrmTemasMaterias_Load;
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

        private async void FrmTemasMaterias_Load(object sender, EventArgs e)
        {
            AplicarEstiloTabla();
            listaTemasMaterias = await _flashcardDAL.ObtenerInfoTemaFlashcardsAsync();

            if (_materiaSeleccionada != null)
            {
                listaTemasMaterias = listaTemasMaterias
                    .Where(x => x.Materia.Equals(_materiaSeleccionada.Nombre, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                Text = $"Flashcards de la materia: {_materiaSeleccionada.Nombre}";
            }
            else if (!string.IsNullOrEmpty(_temaSeleccionado))
            {
                listaTemasMaterias = listaTemasMaterias
                    .Where(x => x.Tema.Equals(_temaSeleccionado, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                Text = $"Flashcards del tema: {_temaSeleccionado}";
            }


            dgvTemasMaterias.DataSource = listaTemasMaterias;
            dgvTemasMaterias.Width = this.ClientSize.Width - 100;
            CentrarTabla();

            if (!dgvTemasMaterias.Columns.Contains("Accion"))
            {
                var btnCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Acción",
                    Name = "Accion",
                    Text = "Ver Flashcards relacionadas",
                    UseColumnTextForButtonValue = true,
                    Width = 200
                };
                dgvTemasMaterias.Columns.Add(btnCol);
            }

            dgvTemasMaterias.Columns["TemaId"].Visible = false;
            dgvTemasMaterias.Columns["UsuarioId"].Visible = false;
            AplicarFuenteRalewayGeneral();

            // Paleta de colores
            Color colorFondoFormulario = ColorTranslator.FromHtml("#424769");   
            Color colorBotonBuscar = ColorTranslator.FromHtml("#b76f9d");       // Rosa
            Color colorBotonLimpiar = ColorTranslator.FromHtml("#f9b17a");      // Naranja pastel
            Color colorBotonSalir = ColorTranslator.FromHtml("#2d3250");        // Azul oscuro
            Color colorTextoBotones = Color.White;
            Color colorTextoInputs = ColorTranslator.FromHtml("#2d3250");
            Color colorComboBoxFondo = Color.White;
            Color colorComboBoxTexto = ColorTranslator.FromHtml("#2d3250");

            // Fondo del formulario
            this.BackColor = colorFondoFormulario;

            // Estilo botones
            void EstiloBoton(Button boton, Color colorFondo, Color colorHover)
            {
                boton.BackColor = colorFondo;
                boton.ForeColor = colorTextoBotones;
                boton.FlatStyle = FlatStyle.Flat;
                boton.FlatAppearance.BorderSize = 0;
                boton.Region = CrearRegionRedondeada(boton.ClientRectangle, 8);
                boton.Padding = new Padding(1);

                boton.MouseEnter += (s, e) => boton.BackColor = colorHover;
                boton.MouseLeave += (s, e) => boton.BackColor = colorFondo;
            }

            EstiloBoton(btnBuscar, colorBotonBuscar, ColorTranslator.FromHtml("#a45c8c"));
            EstiloBoton(btnLimpiar, colorBotonLimpiar, ColorTranslator.FromHtml("#e59e65"));
            EstiloBoton(btnSalir, colorBotonSalir, ColorTranslator.FromHtml("#424769"));

            // Hover visual
            btnSalir.MouseEnter += (s, e) => btnSalir.BackColor = ColorTranslator.FromHtml("#424769");
            btnSalir.MouseLeave += (s, e) => btnSalir.BackColor = ColorTranslator.FromHtml("#2d3250");

            btnBuscar.MouseEnter += (s, e) => btnBuscar.BackColor = ColorTranslator.FromHtml("#a45c8c");
            btnBuscar.MouseLeave += (s, e) => btnBuscar.BackColor = ColorTranslator.FromHtml("#b76f9d");

            btnLimpiar.MouseEnter += (s, e) => btnLimpiar.BackColor = ColorTranslator.FromHtml("#e59e65");
            btnLimpiar.MouseLeave += (s, e) => btnLimpiar.BackColor = ColorTranslator.FromHtml("#f9b17a");

            // Estilo ComboBox
            cbFiltros.Font = ralewayRegular;
            cbFiltros.BackColor = colorComboBoxFondo;
            cbFiltros.ForeColor = colorComboBoxTexto;
            cbFiltros.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFiltros.FlatStyle = FlatStyle.Flat;
            cbFiltros.Region = CrearRegionRedondeada(cbFiltros.ClientRectangle, 8);

            // Estilo TextBox
            txtBusqueda.Font = ralewayRegular;
            txtBusqueda.ForeColor = colorTextoInputs;
            txtBusqueda.BackColor = Color.White;
            txtBusqueda.BorderStyle = BorderStyle.FixedSingle;
            label1.ForeColor = Color.White;


            // Centrado de tabla
            this.Resize += FrmTemasMaterias_Resize;
            CentrarTabla();
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

        private async void dgvTemasMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTemasMaterias.Columns[e.ColumnIndex].Name == "Accion")
            {
                var fila = dgvTemasMaterias.Rows[e.RowIndex].DataBoundItem as InfoTemaFlashcard;

                if (fila != null)
                {
                    var flashcards = await _flashcardDAL.ObtenerFlashcardsPorTemaUsuarioAsync(fila.TemaId, fila.UsuarioId);

                    if (flashcards.Count > 0)
                    {
                        FrmFlashcardEstudio estudio = new FrmFlashcardEstudio(flashcards, fila.Tema);
                        estudio.Show();
                    }
                    else
                    {
                        MessageBox.Show("No hay flashcards disponibles para este tema.");
                    }
                }
            }
        }

        private void AplicarEstiloTabla()
        {
            Color fondoFormulario = ColorTranslator.FromHtml("#424769");    // Fondo principal
            Color encabezado = ColorTranslator.FromHtml("#b76f9d");         // Encabezado tabla
            Color alternado = ColorTranslator.FromHtml("#2d3250");          // Alternancia filas
            Color texto = Color.White;

            dgvTemasMaterias.BorderStyle = BorderStyle.None;
            dgvTemasMaterias.BackgroundColor = fondoFormulario; // Aquí se corrige el fondo general
            dgvTemasMaterias.EnableHeadersVisualStyles = false;
            dgvTemasMaterias.RowHeadersVisible = false;
            dgvTemasMaterias.AllowUserToAddRows = false;
            dgvTemasMaterias.AllowUserToResizeRows = false;
            dgvTemasMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Encabezado
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.BackColor = encabezado;
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.ForeColor = texto;
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.Font = ralewaySemiBold;
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTemasMaterias.ColumnHeadersHeight = 40;

            // Celdas normales
            dgvTemasMaterias.DefaultCellStyle.BackColor = fondoFormulario;
            dgvTemasMaterias.DefaultCellStyle.ForeColor = texto;
            dgvTemasMaterias.DefaultCellStyle.Font = ralewayRegular;
            dgvTemasMaterias.DefaultCellStyle.SelectionBackColor = encabezado;
            dgvTemasMaterias.DefaultCellStyle.SelectionForeColor = texto;
            dgvTemasMaterias.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alternar filas
            dgvTemasMaterias.AlternatingRowsDefaultCellStyle.BackColor = alternado;

            // Tamaño y visibilidad de botones
            btnBuscar.Width = 110;
            btnLimpiar.Width = 110;
            btnSalir.Width = 90;

            btnBuscar.Height = 32;
            btnLimpiar.Height = 32;
            btnSalir.Height = 32;

            btnBuscar.Padding = new Padding(0, 4, 0, 4);
            btnLimpiar.Padding = new Padding(0, 4, 0, 4);
            btnSalir.Padding = new Padding(0, 4, 0, 4);

            btnBuscar.Font = new Font(ralewaySemiBold.FontFamily, 10f, FontStyle.Bold);
            btnLimpiar.Font = new Font(ralewaySemiBold.FontFamily, 10f, FontStyle.Bold);
            btnSalir.Font = new Font(ralewaySemiBold.FontFamily, 10f, FontStyle.Bold);

            // ComboBox ajustes
            cbFiltros.Width = 160;
            cbFiltros.Height = 30;
            cbFiltros.Invalidate();

            cbFiltros.Margin = new Padding(3);
            txtBusqueda.Margin = new Padding(3);
        }



        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBusqueda.Text.Trim().ToLower();
            string filtro = cbFiltros.SelectedItem?.ToString();

            var filtrado = listaTemasMaterias;

            if (!string.IsNullOrEmpty(texto))
            {
                switch (filtro)
                {
                    case "Materia":
                        filtrado = listaTemasMaterias
                            .Where(d => d.Materia.ToLower().Contains(texto))
                            .ToList();
                        break;

                    case "Tema":
                        filtrado = listaTemasMaterias
                            .Where(d => d.Tema.ToLower().Contains(texto))
                            .ToList();
                        break;

                    case "Usuario":
                        filtrado = listaTemasMaterias
                            .Where(d => d.Usuario.ToLower().Contains(texto))
                            .ToList();
                        break;
                }
            }

            dgvTemasMaterias.DataSource = null;
            dgvTemasMaterias.Columns.Clear();
            dgvTemasMaterias.DataSource = filtrado;

            // Vuelve a agregar la columna de botón
            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Accion",
                Text = "Ver Flashcards relacionadas",
                UseColumnTextForButtonValue = true,
                Width = 200
            };
            dgvTemasMaterias.Columns.Add(btnCol);

            dgvTemasMaterias.Columns["TemaId"].Visible = false;
            dgvTemasMaterias.Columns["UsuarioId"].Visible = false;

        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cbFiltros.SelectedIndex = -1; 
            dgvTemasMaterias.DataSource = null;
            dgvTemasMaterias.Columns.Clear();
            dgvTemasMaterias.DataSource = listaTemasMaterias;

            // Agrega de nuevo la columna de botón
            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Accion",
                Text = "Ver Flashcards relacionadas",
                UseColumnTextForButtonValue = true,
                Width = 200
            };
            dgvTemasMaterias.Columns.Add(btnCol);

            dgvTemasMaterias.Columns["TemaId"].Visible = false;
            dgvTemasMaterias.Columns["UsuarioId"].Visible = false;

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                // btnLimpiar.PerformClick();
            }
        }

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "Escribe el valor de la búsqueda")
            {
                txtBusqueda.Text = "";
                txtBusqueda.ForeColor = Color.Black;
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                txtBusqueda.Text = "Escribe el valor de la búsqueda";
                txtBusqueda.ForeColor = Color.Gray;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmEstudiar frmEstudiar = new FrmEstudiar();
            frmEstudiar.Show();
        }
        private void AplicarFuenteRalewayGeneral()
        {
            void Aplicar(Control control)
            {
                if (control is Label or TextBox or Button or ComboBox)
                {
                    control.Font = ralewayRegular;
                }

                if (control.HasChildren)
                {
                    foreach (Control hijo in control.Controls)
                    {
                        Aplicar(hijo);
                    }
                }
            }

            Aplicar(this);

            // Excepciones específicas
            btnSalir.Font = ralewaySemiBold;
            btnBuscar.Font = ralewaySemiBold;
            btnLimpiar.Font = ralewaySemiBold;

            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.Font = new Font(ralewaySemiBold.FontFamily, 10f, FontStyle.Bold);
            dgvTemasMaterias.DefaultCellStyle.Font = new Font(ralewayRegular.FontFamily, 10f, FontStyle.Regular);

        }

        private void FrmTemasMaterias_Resize(object sender, EventArgs e)
        {
            CentrarTabla();
        }

        private void CentrarTabla()
        {
            if (dgvTemasMaterias != null && dgvTemasMaterias.Visible)
            {
                int x = (this.ClientSize.Width - dgvTemasMaterias.Width) / 2;
                dgvTemasMaterias.Location = new Point(Math.Max(x, 10), dgvTemasMaterias.Location.Y);
            }
        }
    }
 }

