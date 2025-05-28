using AppFlashCard.DAL;
using AppFlashCard.EL.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFlashCard
{
    public partial class FrmTemasMaterias : Form
    {
        private readonly string _connectionString;
        private readonly FlashcardDAL _flashcardDAL;

        public FrmTemasMaterias()
        {
            InitializeComponent();

            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _flashcardDAL = new FlashcardDAL(_connectionString);
        }

        private async void FrmTemasMaterias_Load(object sender, EventArgs e)
        {
            AplicarEstiloTabla();
            var listaTemasMaterias = await _flashcardDAL.ObtenerInfoTemaFlashcardsAsync();
            dgvTemasMaterias.DataSource = listaTemasMaterias;

            if (!dgvTemasMaterias.Columns.Contains("Accion"))
            {
                var btnCol = new DataGridViewButtonColumn
                {
                    HeaderText = "Acción",
                    Name = "Accion",
                    Text = "Ver Flashcards relacionadas",
                    UseColumnTextForButtonValue = true,
                    Width = 200
                };
                dgvTemasMaterias.Columns.Add(btnCol);
            }

            dgvTemasMaterias.Columns["TemaId"].Visible = false;
            dgvTemasMaterias.Columns["UsuarioId"].Visible = false;
        }

        private async void dgvTemasMaterias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTemasMaterias.Columns[e.ColumnIndex].Name == "Accion")
            {
                var fila = dgvTemasMaterias.Rows[e.RowIndex].DataBoundItem as InfoTemaFlashcard;

                if (fila != null)
                {
                    var flashcards = await _flashcardDAL.ObtenerFlashcardsPorTemaUsuarioAsync(fila.TemaId, fila.UsuarioId);

                    if (flashcards.Count > 0)
                    {
                        FrmFlashcardEstudio estudio = new FrmFlashcardEstudio(flashcards, fila.Tema);
                        estudio.Show();
                    }
                    else
                    {
                        MessageBox.Show("No hay flashcards disponibles para este tema.");
                    }
                }
            }
        }

        private void AplicarEstiloTabla()
        {
            // Bordes y colores generales
            dgvTemasMaterias.BorderStyle = BorderStyle.None;
            dgvTemasMaterias.BackgroundColor = Color.White;
            dgvTemasMaterias.EnableHeadersVisualStyles = false;
            dgvTemasMaterias.RowHeadersVisible = false;
            dgvTemasMaterias.AllowUserToAddRows = false;
            dgvTemasMaterias.AllowUserToResizeRows = false;
            dgvTemasMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Cabecera
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.BackColor = Color.MediumPurple;
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvTemasMaterias.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTemasMaterias.ColumnHeadersHeight = 40;

            // Filas
            dgvTemasMaterias.DefaultCellStyle.BackColor = Color.White;
            dgvTemasMaterias.DefaultCellStyle.ForeColor = Color.Black;
            dgvTemasMaterias.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvTemasMaterias.DefaultCellStyle.SelectionBackColor = Color.MediumPurple;
            dgvTemasMaterias.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvTemasMaterias.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Alternancia de color
            dgvTemasMaterias.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

    }
}
