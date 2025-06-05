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

        // Cadena de conexión (ajústala si tu servidor/cadena cambian)
        private string cadenaConexion = "Data Source=KIKE-PC\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;";
        // ID del tema seleccionado (0 = insertar; >0 = editar)
        private int idTemaSeleccionado = 0;

        // Fuentes Raleway
        PrivateFontCollection fuentesPersonalizadas = new PrivateFontCollection();
        Font ralewayRegular;
        Font ralewaySemiBold;

        public FrmCrudTemas()
        {
            InitializeComponent();

           

            // Fijo un tamaño mínimo al formulario
            this.MinimumSize = new Size(800, 400);
            // También podrías asignar el tamaño inicial:
            this.Size = new Size(800, 400);

            // Asociar eventos de botones
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnSalir.Click += btnSalir_Click;
            this.dgvTemas.CellDoubleClick += dgvTemas_CellDoubleClick;
            this.Load += FrmCrudTemas_Load;

            this.btnGuardar.SizeChanged += (s, e) =>
            {
                btnGuardar.Region = new Region(CrearRegionRedondeada(btnGuardar.ClientRectangle,8));
            };
            this.btnSalir.SizeChanged += (s, e) =>
            {
                btnSalir.Region = new Region(CrearRegionRedondeada(btnSalir.ClientRectangle, 8));
            };
        }

        private void CargarFuenteRaleway()
        {
            var assembly = Assembly.GetExecutingAssembly();

            void CargarTTF(string resourceName)
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                {
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
            }

            CargarTTF("AppFlashCard.Fonts.Raleway-Regular.ttf");
            CargarTTF("AppFlashCard.Fonts.Raleway-SemiBold.ttf");

            ralewayRegular = new Font(fuentesPersonalizadas.Families[0], 12f, FontStyle.Regular);
            ralewaySemiBold = new Font(
                fuentesPersonalizadas.Families.Length > 1
                    ? fuentesPersonalizadas.Families[1]
                    : fuentesPersonalizadas.Families[0],
                12f,
                FontStyle.Bold);
        }

        private GraphicsPath CrearRegionRedondeada(Rectangle rect, int radio)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radio, radio, 180, 90);
            path.AddArc(rect.Right - radio, rect.Y, radio, radio, 270, 90);
            path.AddArc(rect.Right - radio, rect.Bottom - radio, radio, radio, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radio, radio, radio, 90, 90);
            path.CloseFigure();
            return path;
        }

        // Asigna a un botón un color de fondo y otro color al hacer hover
        private void AplicarEstiloBoton(Button boton, string colorHex, string colorHoverHex)
        {
            Color colorNormal = ColorTranslator.FromHtml(colorHex);
            Color colorHover = ColorTranslator.FromHtml(colorHoverHex);

            boton.BackColor = colorNormal;
            boton.ForeColor = Color.White;
            boton.FlatStyle = FlatStyle.Flat;
            boton.FlatAppearance.BorderSize = 0;
            

            boton.MouseEnter += (s, e) => boton.BackColor = colorHover;
            boton.MouseLeave += (s, e) => boton.BackColor = colorNormal;
        }
        private void FrmCrudTemas_Load(object sender, EventArgs e)
        {
            
            CargarFuenteRaleway();

            

            cmbMaterias.Size = new Size(230, 32);  // ancho, alto
            cmbMaterias.Location = new Point(80, 115);

            txtTema.Size = new Size(230, 28);  // ancho, alto
            txtTema.Location = new Point(80, 160);

            dgvTemas.Location = new Point(320, 40);
            dgvTemas.Size = new Size(450, 420);

            btnGuardar.MinimumSize = new Size(100, 40);
            btnSalir.MinimumSize = new Size(100, 40);
            btnGuardar.Padding = new Padding(8, 4, 8, 4); // {izquierda, arriba, derecha, abajo}
            btnSalir.Padding = new Padding(8, 4, 8, 4);

            void AplicarFuente(Control ctrl)
            {
                if (ctrl is Label || ctrl is TextBox || ctrl is ComboBox || ctrl is Button || ctrl is DataGridView)
                {
                    ctrl.Font = ralewayRegular;
                }

                foreach (Control hijo in ctrl.Controls)
                {
                    AplicarFuente(hijo);
                }
            }
            AplicarFuente(this);

            lblMateria.Font = ralewaySemiBold;
            lbTemas.Font = ralewaySemiBold;
            lblTema.Font = ralewaySemiBold;
            btnGuardar.Font = ralewaySemiBold;
            btnSalir.Font = ralewaySemiBold;

            lblMateria.ForeColor = Color.White;
            lblTema.ForeColor = Color.White;
            lbTemas.ForeColor = Color.White;

            this.BackColor = ColorTranslator.FromHtml("#2D3250");
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.StartPosition = FormStartPosition.CenterScreen;

            
            AplicarEstiloBoton(btnGuardar, "#B76F9D", "#a45c8c");
            AplicarEstiloBoton(btnSalir, "#B76F9D", "#a45c8c");

            btnSalir.ForeColor = Color.White;

            dgvTemas.Anchor = AnchorStyles.Top
                    | AnchorStyles.Bottom
                    | AnchorStyles.Left
                    | AnchorStyles.Right;

            // Configuración del DataGridView
            dgvTemas.ReadOnly = true;
            dgvTemas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTemas.AllowUserToAddRows = false;
            dgvTemas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvTemas.BackgroundColor = ColorTranslator.FromHtml("#2D3250");
            dgvTemas.DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2D3250");
            dgvTemas.DefaultCellStyle.ForeColor = Color.White;
            dgvTemas.DefaultCellStyle.Font = ralewayRegular;
            dgvTemas.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#424769");
            dgvTemas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTemas.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#333A56");

            dgvTemas.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#B76F9D");
            dgvTemas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTemas.ColumnHeadersDefaultCellStyle.Font = ralewaySemiBold;
            dgvTemas.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTemas.ColumnHeadersDefaultCellStyle.SelectionBackColor = dgvTemas.ColumnHeadersDefaultCellStyle.BackColor;
            dgvTemas.ColumnHeadersDefaultCellStyle.SelectionForeColor = dgvTemas.ColumnHeadersDefaultCellStyle.ForeColor;
            dgvTemas.EnableHeadersVisualStyles = false;


            //  Cargar datos en combo y grilla
            CargarMateriasEnCombo();
            CargarTemas();
        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombreTema = txtTema.Text.Trim();
            if (string.IsNullOrEmpty(nombreTema))
            {
                MessageBox.Show("Debe ingresar el nombre del tema.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbMaterias.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar la materia asociada al tema.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                object resultado = cmd.ExecuteScalar();
                cn.Close();

                int nuevoId = Convert.ToInt32(resultado);
                if (idTemaSeleccionado == 0)
                    MessageBox.Show($"Tema insertado con ID = {nuevoId}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Tema (ID = {nuevoId}) actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Volver a modo “insertar”
            idTemaSeleccionado = 0;
            txtTema.Clear();
            cmbMaterias.SelectedIndex = 0;
            btnGuardar.Text = "Guardar";

            // Refrescar la grilla
            CargarTemas();
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
            string nombreMateria = fila.Cells["Materia"].Value.ToString();
            cmbMaterias.SelectedIndex = cmbMaterias.FindStringExact(nombreMateria);
            btnGuardar.Text = "Actualizar";
        }

        #endregion



        private void dgvTemas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void dgvTemas_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
