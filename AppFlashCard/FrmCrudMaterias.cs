using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Microsoft.Data.SqlClient;

namespace AppFlashCard
{
    public partial class FrmCrudMaterias : Form
    {// Fuentes Raleway
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;

        // Cadena de conexión: AJÚSTALA a tu servidor y credenciales
        private string cadenaConexion =
        "Server=DESKTOP-KIRL4P4;Database=FlashcardsDB;Trusted_Connection=True;TrustServerCertificate=True;";


        // ID de la materia seleccionada (0 = insertar; >0 = editar)
        private int idMateriaSeleccionada = 0;

        public FrmCrudMaterias()
        {
            InitializeComponent();
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
        }

        private void FrmCrudMaterias_Load(object sender, EventArgs e)
        {
            // 1) Cargar las fuentes Raleway desde recursos embebidos
            CargarFuenteRaleway();

            // 2) Asignar las fuentes a los controles
            txtMateria.Font = ralewayRegular;
            btnGuardar.Font = ralewaySemiBold;
            btnSalir.Font = ralewaySemiBold;
            lblAgregarMateria.Font = ralewaySemiBold;

            // 3) Configurar estilo del formulario
            this.BackColor = ColorTranslator.FromHtml("#2D3250");
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            // 4) Bordes redondeados y hover en botones
            btnGuardar.Region = new Region(CrearRegionRedondeada(btnGuardar.ClientRectangle, 7));
            btnSalir.Region = new Region(CrearRegionRedondeada(btnSalir.ClientRectangle, 7));
            AgregarHover(btnGuardar, ColorTranslator.FromHtml("#B76F9D"));
            AgregarHover(btnSalir, ColorTranslator.FromHtml("#B76F9D"));
            btnSalir.ForeColor = Color.White;

            // 5) Configurar DataGridView
            dgvMaterias.ReadOnly = true;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.CellDoubleClick += dgvMaterias_CellDoubleClick;

            // 6) Cargar la lista de materias al iniciar
            CargarMaterias();
        }

        #region == Métodos de UI y Estética ==
        private void AgregarHover(Button boton, Color originalColor)
        {
            boton.BackColor = originalColor;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            boton.ForeColor = Color.White;

            boton.MouseEnter += (s, e) => boton.BackColor = ControlPaint.Light(originalColor);
            boton.MouseLeave += (s, e) => boton.BackColor = originalColor;
        }

        private GraphicsPath CrearRegionRedondeada(Rectangle rect, int radio)
        {
            int diameter = radio;
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void CargarFuenteRaleway()
        {
            var assembly = Assembly.GetExecutingAssembly();

            void CargarTTF(string resourceName)
            {
                Stream stream = assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                {
                    MessageBox.Show($"No se encontró el recurso embebido:\n{resourceName}",
                                    "Error al cargar fuente",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
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
                12f,
                FontStyle.Bold
            );
        }
        #endregion

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

                // Ajustar encabezados
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

            // Cambiar texto del botón para indicar “Actualizar”
            btnGuardar.Text = "Actualizar";
        }
        #endregion

        #region == Insertar / Editar Materia ==
        private void btnGuardar_Click(object sender, EventArgs e)
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
                object resultado = cmd.ExecuteScalar();  // devuelve el NuevoId o Id editado
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

            // Volver a modo “insertar”
            idMateriaSeleccionada = 0;
            txtMateria.Clear();
            btnGuardar.Text = "Guardar";

            // Refrescar grilla
            CargarMaterias();
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
