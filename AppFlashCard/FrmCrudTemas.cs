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
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
        }

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
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvTemas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
#endregion