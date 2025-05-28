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

        private List<InfoTemaFlashcard> listaTemasMaterias = new();

        public FrmTemasMaterias()
        {
            InitializeComponent();
            txtBusqueda.Text = "Escribe el valor de la búsqueda";

            _connectionString = ConfigurationManager.ConnectionStrings["FlashcardsDB"].ConnectionString;
            _flashcardDAL = new FlashcardDAL(_connectionString);
        }

        private async void FrmTemasMaterias_Load(object sender, EventArgs e)
        {
            AplicarEstiloTabla();
            listaTemasMaterias = await _flashcardDAL.ObtenerInfoTemaFlashcardsAsync();
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string texto = txtBusqueda.Text.Trim().ToLower();
            string filtro = cbFiltros.SelectedItem?.ToString();

            var filtrado = listaTemasMaterias;

            if (!string.IsNullOrEmpty(texto))
            {
                switch (filtro)
                {
                    case "Materia":
                        filtrado = listaTemasMaterias
                            .Where(d => d.Materia.ToLower().Contains(texto))
                            .ToList();
                        break;

                    case "Tema":
                        filtrado = listaTemasMaterias
                            .Where(d => d.Tema.ToLower().Contains(texto))
                            .ToList();
                        break;

                    case "Usuario":
                        filtrado = listaTemasMaterias
                            .Where(d => d.Usuario.ToLower().Contains(texto))
                            .ToList();
                        break;
                }
            }

            dgvTemasMaterias.DataSource = null;
            dgvTemasMaterias.Columns.Clear();
            dgvTemasMaterias.DataSource = filtrado;

            // Vuelve a agregar la columna de botón
            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Accion",
                Text = "Ver Flashcards relacionadas",
                UseColumnTextForButtonValue = true,
                Width = 200
            };
            dgvTemasMaterias.Columns.Add(btnCol);

            dgvTemasMaterias.Columns["TemaId"].Visible = false;
            dgvTemasMaterias.Columns["UsuarioId"].Visible = false;

        }

        private void btnBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Clear();
            cbFiltros.SelectedIndex = -1; // O selecciona "Materia" por defecto si querés
            dgvTemasMaterias.DataSource = null;
            dgvTemasMaterias.Columns.Clear();
            dgvTemasMaterias.DataSource = listaTemasMaterias;

            // Agrega de nuevo la columna de botón
            var btnCol = new DataGridViewButtonColumn
            {
                HeaderText = "Acción",
                Name = "Accion",
                Text = "Ver Flashcards relacionadas",
                UseColumnTextForButtonValue = true,
                Width = 200
            };
            dgvTemasMaterias.Columns.Add(btnCol);

            dgvTemasMaterias.Columns["TemaId"].Visible = false;
            dgvTemasMaterias.Columns["UsuarioId"].Visible = false;

        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                btnLimpiar.PerformClick();
            }
        }

        private void txtBusqueda_Enter(object sender, EventArgs e)
        {
            if (txtBusqueda.Text == "Escribe el valor de la búsqueda")
            {
                txtBusqueda.Text = "";
                txtBusqueda.ForeColor = Color.Black;
            }
        }

        private void txtBusqueda_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBusqueda.Text))
            {
                txtBusqueda.Text = "Escribe el valor de la búsqueda";
                txtBusqueda.ForeColor = Color.Gray;
            }
        }
    }
}
