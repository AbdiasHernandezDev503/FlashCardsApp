using AppFlashCard.DAL;
using AppFlashCard.EL;
using AppFlashCard.Utils;
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
    public partial class FrmEstudiar : Form
    {
        public FrmEstudiar()
        {
            InitializeComponent();

            panelArbol.AutoScroll = true; // Habilitar el desplazamiento automático
            panelArbol.Dock = DockStyle.Fill; // Ajustar el panel al tamaño del formulario
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


            var listaMaterias = await new MateriaDAL("Data Source=LAPTOP-CN5T4MQA\\SQLEXPRESS;Initial Catalog=FlashcardsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False").ObtenerMateriasConTemasAsync();
            DibujarArbol(listaMaterias);

        }

        private void DibujarArbol(List<Materia> materias)
        {
            int startX = 50;
            int startY = 50;
            int nodoAncho = 120;
            int nodoAlto = 40;
            int espacioHorizontal = 50;
            int espacioVertical = 80;

            int totalMaterias = materias.Count;
            int nodoEspaciadoX = nodoAncho + espacioHorizontal;

            int totalAncho = (totalMaterias * nodoEspaciadoX) + startX;
            int totalAlto = 300 + (materias.Max(m => m.Temas.Count) * (nodoAlto + espacioVertical));

            Bitmap bmp = new Bitmap(totalAncho, totalAlto);
            using Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);

            Font font = new Font("Arial", 10, FontStyle.Regular);
            StringFormat formatoCentro = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            Pen pen = new Pen(Color.Black, 1.5f);
            Brush brushRaiz = Brushes.SkyBlue;
            Brush brushMateria = Brushes.MediumSeaGreen;
            Brush brushTema = Brushes.LightYellow;
            Brush textBrush = Brushes.Black;

            // Nodo raíz centrado
            int centroX = totalAncho / 2;
            Rectangle nodoRaiz = new Rectangle(centroX - nodoAncho / 2, 20, nodoAncho, nodoAlto);
            g.FillEllipse(brushRaiz, nodoRaiz);
            g.DrawEllipse(pen, nodoRaiz);
            g.DrawString("Materias", font, textBrush, nodoRaiz, formatoCentro);

            // Posicionar materias
            int materiaStartX = startX;
            int nivelMateriaY = nodoRaiz.Bottom + espacioVertical;

            foreach (var materia in materias)
            {
                Rectangle nodoMateria = new Rectangle(materiaStartX, nivelMateriaY, nodoAncho, nodoAlto);
                g.FillEllipse(brushMateria, nodoMateria);
                g.DrawEllipse(pen, nodoMateria);
                g.DrawString(materia.Nombre, font, textBrush, nodoMateria, formatoCentro);

                // Línea desde raíz
                g.DrawLine(pen, nodoRaiz.X + nodoRaiz.Width / 2, nodoRaiz.Bottom,
                                nodoMateria.X + nodoMateria.Width / 2, nodoMateria.Y);

                // Calcular temas centrados bajo la materia
                int totalTemas = materia.Temas.Count;
                int totalTemasWidth = totalTemas * nodoEspaciadoX;
                int temaStartX = nodoMateria.X + nodoAncho / 2 - totalTemasWidth / 2;

                int temaY = nodoMateria.Bottom + espacioVertical;

                foreach (var tema in materia.Temas)
                {
                    Rectangle nodoTema = new Rectangle(temaStartX, temaY, nodoAncho, nodoAlto);
                    g.FillEllipse(brushTema, nodoTema);
                    g.DrawEllipse(pen, nodoTema);
                    g.DrawString(tema.Nombre, font, textBrush, nodoTema, formatoCentro);

                    // Línea desde materia a tema
                    g.DrawLine(pen, nodoMateria.X + nodoMateria.Width / 2, nodoMateria.Bottom,
                                    nodoTema.X + nodoTema.Width / 2, nodoTema.Y);

                    temaStartX += nodoEspaciadoX;
                }

                materiaStartX += nodoEspaciadoX;
            }

            pbArbol.Image = bmp;
            pbArbol.Width = bmp.Width;
            pbArbol.Height = bmp.Height;
            pbArbol.Location = new Point(0, 0); 

        }

    }
}
