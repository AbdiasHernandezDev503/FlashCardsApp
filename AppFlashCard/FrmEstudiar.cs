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
            
        }

        private void dgvMaterias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvTemas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmFlashcardEstudio flashcardEstudio = new FrmFlashcardEstudio();
            flashcardEstudio.Show();
        }
    }
}
