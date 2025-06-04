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
    public partial class FrmCrudTemas : Form
    {
        // Fuentes Raleway
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;
        public FrmCrudTemas()
        {
            InitializeComponent();
            // Asociar eventos de botones
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnSalir.Click += btnSalir_Click;
            this.dgvTemas.CellDoubleClick += dgvTemas_CellDoubleClick;
        }

        // Cadena de conexión (ajústala si tu servidor/cadena cambian)
        private string cadenaConexion =
            "Server=DESKTOP-KIRL4P4;Database=FlashcardsDB;Trusted_Connection=True;TrustServerCertificate=True;";
        // ID del tema seleccionado (0 = insertar; >0 = editar)
        private int idTemaSeleccionado = 0;
        private void FrmCrudTemas_Load(object sender, EventArgs e)
        {


            // 2) Asignar las fuentes a los controles
            txtTema.Font = ralewayRegular;
            btnGuardar.Font = ralewaySemiBold;
            btnSalir.Font = ralewaySemiBold;
            lblMateria.Font = ralewaySemiBold;
            lbTemas.Font = ralewaySemiBold;
            lblTema.Font = ralewaySemiBold;

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
            dgvTemas.ReadOnly = true;
            dgvTemas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemas.AllowUserToAddRows = false;
            dgvTemas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            CargarMateriasEnCombo();
            CargarTemas();
        }

        #region == Insertar / Editar Materia ==
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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region == Cargar datos en ComboBox y DataGridView ==
        private void CargarMateriasEnCombo()
        {
            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("SELECT Id, Nombre FROM Materias ORDER BY Nombre", cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbMaterias.DisplayMember = "Nombre";
                cmbMaterias.ValueMember = "Id";
                cmbMaterias.DataSource = dt;
            }
        }

        private void CargarTemas()
        {
            string sql = @"
                SELECT t.Id,
                       t.Nombre AS Tema,
                       m.Nombre AS Materia
                  FROM Temas t
                  INNER JOIN Materias m ON t.MateriaId = m.Id
              ORDER BY m.Nombre, t.Nombre";

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTemas.DataSource = dt;
                dgvTemas.Columns["Id"].Visible = false;
                dgvTemas.Columns["Tema"].HeaderText = "Tema";
                dgvTemas.Columns["Materia"].HeaderText = "Materia";
            }
        }
        #endregion



        #region == Doble‐clic en grilla (modo edición) ==
        private void dgvTemas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow fila = dgvTemas.Rows[e.RowIndex];
            idTemaSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
            txtTema.Text = fila.Cells["Tema"].Value.ToString();

            // Seleccionar en el ComboBox la materia que corresponda
            string nombreMateria = fila.Cells["Materia"].Value.ToString();
            cmbMaterias.SelectedIndex = cmbMaterias.FindStringExact(nombreMateria);

            // Cambiar texto del botón a “Actualizar”
            btnGuardar.Text = "Actualizar";
        }
        #endregion



        private void dgvTemas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #region == Insertar / Editar Tema usando el SP usp_InsertarEditarTema ==
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreTema = txtTema.Text.Trim();
            if (string.IsNullOrEmpty(nombreTema))
            {
                MessageBox.Show("Debe ingresar el nombre del tema.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            if (cmbMaterias.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar la materia asociada al tema.",
                                "Validación",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            int materiaId = Convert.ToInt32(cmbMaterias.SelectedValue);

            using (SqlConnection cn = new SqlConnection(cadenaConexion))
            using (SqlCommand cmd = new SqlCommand("usp_InsertarEditarTema", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTema", idTemaSeleccionado);
                cmd.Parameters.AddWithValue("@Nombre", nombreTema);
                cmd.Parameters.AddWithValue("@MateriaId", materiaId);

                cn.Open();
                object resultado = cmd.ExecuteScalar();  // devuelve el NuevoId o Id editado
                cn.Close();

                int nuevoId = Convert.ToInt32(resultado);
                if (idTemaSeleccionado == 0)
                    MessageBox.Show($"Tema insertado con ID = {nuevoId}.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Tema (ID = {nuevoId}) actualizado.",
                                    "Éxito",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
            }

            // Volver a modo “insertar”
            idTemaSeleccionado = 0;
            txtTema.Clear();
            cmbMaterias.SelectedIndex = 0;
            btnGuardar.Text = "Guardar";

            // Refrescar grilla
            CargarTemas();
        }
        #endregion


        private void dgvTemas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
