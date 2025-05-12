using AppFlashCard.EL;
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
    public partial class FrmFlashcardEstudio : Form
    {
        private readonly List<Flashcard> _flashcards;
        private int _index = 0;

        // Animaciòn flip
        private bool mostrandoPregunta = true;
        private int flipStep = 30;
        private int originalWidth;

        // Animacion slide
        private Panel panelActual;
        private Panel panelNuevo;
        private int animOffset = 0;
        private int animStep = 20;
        private int animDirection = 1; // 1 = siguiente, -1 = anterior
        private bool animEnCurso = false;


        private bool enContraccion = true;

        private readonly string _nombreTema;

        public FrmFlashcardEstudio(List<Flashcard> flashcards, string nombreTema)
        {
            InitializeComponent();
            _flashcards = flashcards;
            _nombreTema = nombreTema;
        }

        private void FrmFlashcardEstudio_Load(object sender, EventArgs e)
        {
            lblNombreTema.Text = _nombreTema;
            originalWidth = pnlPregunta.Width;
            pnlPregunta.Visible = true;
            pnlRespuesta.Visible = false;
            pnlPregunta.BringToFront();
            pnlPregunta.Width = originalWidth;
            pnlRespuesta.Width = originalWidth;

            if (_flashcards.Count == 0)
                return;

            MostrarActual();

            enContraccion = true;
        }

        private void lblVoltear_Click(object sender, EventArgs e)
        {
            timerFlip.Start();
        }

        private void pnlRespuesta_Click(object sender, EventArgs e)
        {
            lblVoltear_Click(sender, e);
        }

        private void pnlPregunta_Click(object sender, EventArgs e)
        {
            lblVoltear_Click(sender, e);
        }

        private void lblRespuesta_Click(object sender, EventArgs e)
        {
            lblVoltear_Click(sender, e);
        }

        private void lblPregunta_Click(object sender, EventArgs e)
        {
            lblVoltear_Click(sender, e);
        }

        private void timerFlip_Tick(object sender, EventArgs e)
        {
            if (enContraccion)
            {
                Panel actual = mostrandoPregunta ? pnlPregunta : pnlRespuesta;
                if (actual.Width > 0)
                {
                    actual.Width -= flipStep;
                }
                else
                {
                    actual.Visible = false;
                    mostrandoPregunta = !mostrandoPregunta;

                    Panel siguiente = mostrandoPregunta ? pnlPregunta : pnlRespuesta;
                    siguiente.Width = 0;
                    siguiente.Visible = true;
                    siguiente.BringToFront();

                    enContraccion = false; // pasar a fase de expansión
                }
            }
            else
            {
                Panel activo = mostrandoPregunta ? pnlPregunta : pnlRespuesta;
                if (activo.Width < originalWidth)
                {
                    activo.Width += flipStep;
                }
                else
                {
                    activo.Width = originalWidth;
                    enContraccion = true;
                    timerFlip.Stop();
                }
            }
        }

        private void MostrarActual()
        {
            if (_index >= 0 && _index < _flashcards.Count)
            {
                lblPregunta.Text = _flashcards[_index].Pregunta;
                lblRespuesta.Text = _flashcards[_index].Respuesta;

                pnlRespuesta.Visible = false;
                pnlPregunta.Visible = true;
                pnlPregunta.BringToFront();
                mostrandoPregunta = true;
                pnlPregunta.Width = originalWidth;
                pnlRespuesta.Width = originalWidth;

                btnAnterior.Enabled = _index > 0;  // Deshabilitar el boton cuando se encuentre en la primera flashcard
                btnSiguiente.Enabled = _index < _flashcards.Count - 1; // Deshabilitar el boton cuando se encuentre en la ultima flashcard

                lblContador.Text = $"{_index + 1}/{_flashcards.Count}"; // Actualizar el contador
            }
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_index > 0)
            {
                _index--;
                IniciarAnimacion(false);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (_index < _flashcards.Count - 1)
            {
                _index++;
                IniciarAnimacion(true);
            }
        }

        private void IniciarAnimacion(bool haciaAdelante)
        {
            if (animEnCurso || _flashcards.Count == 0)
                return;

            animEnCurso = true;
            animDirection = haciaAdelante ? 1 : -1;

            // Crear panel nuevo temporal
            panelNuevo = new Panel
            {
                Width = pnlPregunta.Width,
                Height = pnlPregunta.Height,
                Location = new Point(animDirection * pnlPregunta.Width, pnlPregunta.Top),
                BackColor = Color.White
            };



            this.Controls.Add(panelNuevo);
            panelNuevo.BringToFront();
            panelActual = mostrandoPregunta ? pnlPregunta : pnlRespuesta;

            animOffset = 0;
            timerSlide.Start();
        }


        private void timerSlide_Tick(object sender, EventArgs e)
        {
            animOffset += animStep;
            panelActual.Left -= animStep * animDirection;
            panelNuevo.Left -= animStep * animDirection;

            if (animOffset >= pnlPregunta.Width)
            {
                timerSlide.Stop();
                animEnCurso = false;

                // Reemplazar contenido
                panelActual.Left = 0;
                panelActual.Visible = true;
                panelNuevo.Visible = false;
                panelNuevo.Dispose();

                MostrarActual(); // refresca los datos reales
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();   
            FrmEstudiar frmEstudiar = new FrmEstudiar();
            frmEstudiar.Show();

        }
    }
}
