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
    public partial class FrmEstudiar : Form
    {
        public FrmEstudiar()
        {
            InitializeComponent();
        }

        private void FrmEstudiar_Load(object sender, EventArgs e)
        {
            dgvMaterias.DataSource = null;
            dgvMaterias.DataSource = DatosEnMemoria.Materias
                .Select(m => new { Materia = m.Nombre })
                .ToList();

            // Agregar botón "Ver temas"
            DataGridViewButtonColumn colBoton = new DataGridViewButtonColumn();
            colBoton.Name = "btnTemas";
            colBoton.HeaderText = "Temas";
            colBoton.Text = "📂 Ver temas";
            colBoton.UseColumnTextForButtonValue = true;
            dgvMaterias.Columns.Add(colBoton);
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvMaterias.Columns["btnTemas"].Index)
            {
                string nombreMateria = dgvMaterias.Rows[e.RowIndex].Cells[0].Value.ToString();
                var materiaSeleccionada = DatosEnMemoria.Materias.FirstOrDefault(m => m.Nombre == nombreMateria);

                if (materiaSeleccionada != null)
                {
                    dgvTemas.Visible = true;
                    dgvTemas.DataSource = materiaSeleccionada.Temas.Select(t => new { Tema = t.Nombre }).ToList();
                }
            }
        }

        private void dgvTemas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmFlashcardEstudio flashcardEstudio = new FrmFlashcardEstudio();
            flashcardEstudio.Show();
        }
    }
}
