using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace AppFlashCard
{
    public partial class FrmCrudMaterias : Form
    {
        private Panel panelContenedor;

        // Cadena de conexión: Colocar servidor
        private string cadenaConexion =
            "Server=DESKTOP-L2CUOSF\\MSSQLSERVER01;Database=FlashcardsDB;Trusted_Connection=True;TrustServerCertificate=True;";

        // ID de la materia seleccionada (0 = insertar; >0 = editar)
        private int idMateriaSeleccionada = 0;

        // Fuentes Raleway
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;

        public FrmCrudMaterias()
        {
            InitializeComponent();

            this.MinimumSize = new Size(600 + (this.Width - this.ClientSize.Width),
                            350 + (this.Height - this.ClientSize.Height));

            this.ClientSize = new Size(600, 350);
            CargarFuenteRaleway();
            this.Load += FrmCrudMaterias_Load;
            this.btnGuardar.Click += btnGuardar_Click_1;
            this.btnSalir.Click += btnSalir_Click;
        }

        // Carga las fuentes Raleway desde recursos embebidos
        private void CargarFuenteRaleway()
        {
            var assembly = Assembly.GetExecutingAssembly();

            void CargarTTF(string resourceName)
            {
                using Stream stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    MessageBox.Show($"No se encontró el recurso embebido:\n{resourceName}",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] fontData = new byte[stream.Length];
                stream.Read(fontData, 0, fontData.Length);
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

        private GraphicsPath CrearRegionRedondeada(Rectangle bounds, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.X, bounds.Y, radio, radio, 180, 90);
            path.AddArc(bounds.Right - radio, bounds.Y, radio, radio, 270, 90);
            path.AddArc(bounds.Right - radio, bounds.Bottom - radio, radio, radio, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radio, radio, radio, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void AplicarEstiloBoton(Button boton, string colorHex, string colorHoverHex)
        {
            Color colorNormal = ColorTranslator.FromHtml(colorHex);
            Color colorHover = ColorTranslator.FromHtml(colorHoverHex);

            boton.BackColor = colorNormal;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.Region = new Region(CrearRegionRedondeada(boton.ClientRectangle, 8));

            boton.MouseEnter += (s, e) => boton.BackColor = colorHover;
            boton.MouseLeave += (s, e) => boton.BackColor = colorNormal;
        }

        private void FrmCrudMaterias_Load(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml("#2D3250");
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Aplicar fuente Raleway a todos los controles recursivamente
            void AplicarFuente(Control ctrl)
            {
                if (ctrl is Label || ctrl is TextBox || ctrl is ComboBox || ctrl is Button)
                    ctrl.Font = ralewayRegular;

                foreach (Control child in ctrl.Controls)
                    AplicarFuente(child);
            }
            AplicarFuente(this);

            // Encabezado “Agregar Materia”
            lblAgregarMateria.AutoSize = false;
            lblAgregarMateria.Text = "Agregar Materia";
            lblAgregarMateria.ForeColor = Color.White;
            lblAgregarMateria.Font = ralewaySemiBold;
            lblAgregarMateria.Size = new Size(250, 36);
            lblAgregarMateria.Location = new Point(50, 20);   // Alineado a la izquierda en x=50
            lblAgregarMateria.TextAlign = ContentAlignment.MiddleLeft;

            // Label “Materia:” y TextBox
            lblMateria.AutoSize = false;
            lblMateria.Text = "Materia:";
            lblMateria.ForeColor = Color.White;
            lblMateria.Font = ralewaySemiBold;
            lblMateria.Size = new Size(100, 24);
            lblMateria.Location = new Point(50, 64);

            txtMateria.BorderStyle = BorderStyle.None;
            txtMateria.BackColor = ColorTranslator.FromHtml("#333A56");
            txtMateria.ForeColor = Color.White;
            txtMateria.Font = ralewayRegular;
            txtMateria.Size = new Size(220, 28);
            txtMateria.Location = new Point(150, 64);
            txtMateria.SizeChanged += (s, ev) =>
            {
                txtMateria.Region = new Region(CrearRegionRedondeada(txtMateria.ClientRectangle, 6));
            };

            panelContenedor = new Panel
            {
                Location = new Point(300, 20),     
                Size = new Size(260, 360),      
                BorderStyle = BorderStyle.None  
            };
            this.Controls.Add(panelContenedor);

            // Botón “Guardar”
            btnGuardar.Text = "Guardar";
            btnGuardar.Font = ralewaySemiBold;
            btnGuardar.MinimumSize = new Size(100, 40);
            btnGuardar.Padding = new Padding(8, 4, 8, 4);
            btnGuardar.Location = new Point(50, 110);
            AplicarEstiloBoton(btnGuardar, "#B76F9D", "#a45c8c");

            // Botón “Salir”
            btnSalir.Text = "Salir";
            btnSalir.Font = ralewaySemiBold;
            btnSalir.MinimumSize = new Size(100, 40);
            btnSalir.Padding = new Padding(8, 4, 4, 4);
            btnSalir.Location = new Point(180, 110);
            AplicarEstiloBoton(btnSalir, "#F9B17A", "#e59e65");
            panelContenedor = new Panel
            {
                Location = new Point(400, 20),
                Size = new Size(380, 360),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(panelContenedor);

            // DataGridView en la parte derecha
            dgvMaterias.Location = new Point(320, 20);
            dgvMaterias.Size = new Size(260, 260);
            dgvMaterias.Anchor = AnchorStyles.Top
                                 | AnchorStyles.Bottom
                                 | AnchorStyles.Left
                                 | AnchorStyles.Right;

      
            dgvMaterias.BackgroundColor = ColorTranslator.FromHtml("#2D3250");
            dgvMaterias.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2D3250");
            dgvMaterias.DefaultCellStyle.ForeColor = Color.White;
            dgvMaterias.DefaultCellStyle.Font = ralewayRegular;
            dgvMaterias.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#B76F9D");
            dgvMaterias.DefaultCellStyle.SelectionForeColor = Color.White;


            dgvMaterias.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B76F9D");
            dgvMaterias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterias.ColumnHeadersDefaultCellStyle.Font = ralewaySemiBold;
            dgvMaterias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMaterias.EnableHeadersVisualStyles = false;

            dgvMaterias.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B76F9D");
            dgvMaterias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvMaterias.ColumnHeadersDefaultCellStyle.Font = ralewaySemiBold;
            dgvMaterias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMaterias.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgvMaterias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvMaterias.ReadOnly = true;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.CellDoubleClick += dgvMaterias_CellDoubleClick;

            // Cargar datos en la grilla
            CargarMaterias();
        }

        #region == Cargar y Listar Materias ==
        private void CargarMaterias()
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Materias ORDER BY Nombre", cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvMaterias.DataSource = dt;

                dgvMaterias.Columns["Id"].HeaderText = "ID";
                dgvMaterias.Columns["Nombre"].HeaderText = "Materia";
                dgvMaterias.Columns["Id"].Visible = false;
            }
        }
        #endregion

        #region == Doble‐clic en grilla (modo edición) ==
        private void dgvMaterias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvMaterias.Rows[e.RowIndex];
            idMateriaSeleccionada = Convert.ToInt32(fila.Cells["Id"].Value);
            txtMateria.Text = fila.Cells["Nombre"].Value.ToString();

            btnGuardar.Text = "Actualizar";
        }
        #endregion

        #region == Insertar / Editar Materia ==
        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            string nombre = txtMateria.Text.Trim();
            if (string.IsNullOrEmpty(nombre))
            {
                MessageBox.Show("Debe ingresar el nombre de la materia.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("usp_InsertarEditarMateria", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMateria", idMateriaSeleccionada);
                cmd.Parameters.AddWithValue("@Nombre", nombre);

                cn.Open();
                object resultado = cmd.ExecuteScalar();
                cn.Close();

                int nuevoId = Convert.ToInt32(resultado);
                if (idMateriaSeleccionada == 0)
                    MessageBox.Show($"Materia insertada con ID = {nuevoId}.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Materia (ID = {nuevoId}) actualizada.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }

            idMateriaSeleccionada = 0;
            txtMateria.Clear();
            btnGuardar.Text = "Guardar";
            CargarMaterias();
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close(); //ultima modificacion
        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
