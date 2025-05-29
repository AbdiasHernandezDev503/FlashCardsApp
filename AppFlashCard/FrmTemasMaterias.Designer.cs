namespace AppFlashCard
{
    partial class FrmTemasMaterias
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvTemasMaterias = new DataGridView();
            label1 = new Label();
            cbFiltros = new ComboBox();
            txtBusqueda = new TextBox();
            btnBuscar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTemasMaterias).BeginInit();
            SuspendLayout();
            // 
            // dgvTemasMaterias
            // 
            dgvTemasMaterias.AllowUserToAddRows = false;
            dgvTemasMaterias.AllowUserToDeleteRows = false;
            dgvTemasMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemasMaterias.Location = new Point(12, 170);
            dgvTemasMaterias.Name = "dgvTemasMaterias";
            dgvTemasMaterias.ReadOnly = true;
            dgvTemasMaterias.RowHeadersWidth = 51;
            dgvTemasMaterias.RowTemplate.Height = 29;
            dgvTemasMaterias.Size = new Size(760, 306);
            dgvTemasMaterias.TabIndex = 0;
            dgvTemasMaterias.CellContentClick += dgvTemasMaterias_CellContentClick;
            // 
            // label1
            // 
            label1.Location = new Point(34, 22);
            label1.Name = "label1";
            label1.Size = new Size(110, 30);
            label1.TabIndex = 1;
            label1.Text = "Buscar por:";
            // 
            // cbFiltros
            // 
            cbFiltros.FormattingEnabled = true;
            cbFiltros.Items.AddRange(new object[] { "Materia", "Tema", "Usuario" });
            cbFiltros.Location = new Point(159, 22);
            cbFiltros.Name = "cbFiltros";
            cbFiltros.Size = new Size(213, 28);
            cbFiltros.TabIndex = 2;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(442, 23);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(330, 27);
            txtBusqueda.TabIndex = 3;
            txtBusqueda.TextChanged += txtBusqueda_TextChanged;
            txtBusqueda.Enter += txtBusqueda_Enter;
            txtBusqueda.Leave += txtBusqueda_Leave;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(159, 92);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(142, 38);
            btnBuscar.TabIndex = 4;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            btnBuscar.KeyDown += btnBuscar_KeyDown;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(442, 92);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(146, 38);
            btnLimpiar.TabIndex = 5;
            btnLimpiar.Text = "Limpiar filtros";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(183, 496);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(144, 42);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmTemasMaterias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(831, 591);
            Controls.Add(btnSalir);
            Controls.Add(btnLimpiar);
            Controls.Add(btnBuscar);
            Controls.Add(txtBusqueda);
            Controls.Add(cbFiltros);
            Controls.Add(label1);
            Controls.Add(dgvTemasMaterias);
            Name = "FrmTemasMaterias";
            Text = "FrmTemasMaterias";
            Load += FrmTemasMaterias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTemasMaterias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvTemasMaterias;
        private Label label1;
        private ComboBox cbFiltros;
        private TextBox txtBusqueda;
        private Button btnBuscar;
        private Button btnLimpiar;
        private Button btnSalir;
    }
}