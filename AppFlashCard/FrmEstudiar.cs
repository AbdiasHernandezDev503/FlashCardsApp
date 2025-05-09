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
            DibujarArbolJerarquico(listaMaterias);

        }

        private void DibujarArbolJerarquico(List<Materia> materias)
        {
            int nodoAncho = 100;
            int nodoAlto = 40;
            int espacioHorizontal = 80;
            int espacioVertical = 80;
            int margen = 50;

            int totalMaterias = materias.Count;
            int anchoTotal = (totalMaterias * (nodoAncho + espacioHorizontal)) + margen * 2;
            int altoTotal = 300 + materias.Max(m => m.Temas.Count) * (nodoAlto + espacioVertical);

            Bitmap bmp = new Bitmap(anchoTotal, altoTotal);
            using Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.Clear(Color.White);

            Font font = new Font("Arial", 10);
            Pen pen = new Pen(Color.Black, 1.5f);
            Brush brushRaiz = Brushes.SkyBlue;
            Brush brushMateria = Brushes.LightGreen;
            Brush brushTema = Brushes.LightYellow;
            Brush textBrush = Brushes.Black;
            StringFormat sf = new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            // Dibujo nodo raíz "Materias"
            int centroX = anchoTotal / 2;
            int raizX = centroX - nodoAncho / 2;
            int raizY = 20;
            Rectangle nodoRaiz = new Rectangle(raizX, raizY, nodoAncho, nodoAlto);
            g.FillEllipse(brushRaiz, nodoRaiz);
            g.DrawEllipse(pen, nodoRaiz);
            g.DrawString("Materias", font, textBrush, nodoRaiz, sf);

            // Materias nivel 1
            int xActual = margen;
            int nivelMateriaY = raizY + nodoAlto + espacioVertical;

            foreach (var materia in materias)
            {
                Rectangle rectMateria = new Rectangle(xActual, nivelMateriaY, nodoAncho, nodoAlto);
                g.FillEllipse(brushMateria, rectMateria);
                g.DrawEllipse(pen, rectMateria);
                g.DrawString(materia.Nombre, font, textBrush, rectMateria, sf);

                // Línea desde raíz a materia
                g.DrawLine(pen, nodoRaiz.X + nodoAncho / 2, nodoRaiz.Bottom,
                                rectMateria.X + nodoAncho / 2, rectMateria.Y);

                // Dibujar temas (nivel 2)
                int temaY = rectMateria.Bottom + espacioVertical;
                int temaXStart = rectMateria.X - ((materia.Temas.Count - 1) * (nodoAncho + espacioHorizontal)) / 2;

                foreach (var tema in materia.Temas)
                {
                    Rectangle rectTema = new Rectangle(temaXStart, temaY, nodoAncho, nodoAlto);
                    g.FillEllipse(brushTema, rectTema);
                    g.DrawEllipse(pen, rectTema);
                    g.DrawString(tema.Nombre, font, textBrush, rectTema, sf);

                    // Línea desde materia a tema
                    g.DrawLine(pen, rectMateria.X + nodoAncho / 2, rectMateria.Bottom,
                                    rectTema.X + nodoAncho / 2, rectTema.Y);

                    temaXStart += nodoAncho + espacioHorizontal;
                }

                xActual += nodoAncho + espacioHorizontal;
            }

            pbArbol.Image = bmp;
            pbArbol.Width = bmp.Width;
            pbArbol.Height = bmp.Height;
            pbArbol.Location = new Point(0, 0);
            panelArbol.AutoScrollPosition = new Point(0, 0); 
        }


    }
}
