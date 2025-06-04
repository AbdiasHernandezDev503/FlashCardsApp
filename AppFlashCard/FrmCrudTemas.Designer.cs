namespace AppFlashCard
{
    partial class FrmCrudTemas
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
            lbTemas = new Label();
            lblMateria = new Label();
            lblTema = new Label();
            cmbMaterias = new ComboBox();
            txtTema = new TextBox();
            btnGuardar = new Button();
            btnSalir = new Button();
            dgvTemas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvTemas).BeginInit();
            SuspendLayout();
            // 
            // lbTemas
            // 
            lbTemas.AutoSize = true;
            lbTemas.ForeColor = SystemColors.ControlLightLight;
            lbTemas.Location = new Point(68, 53);
            lbTemas.Name = "lbTemas";
            lbTemas.Size = new Size(85, 15);
            lbTemas.TabIndex = 0;
            lbTemas.Text = "Agregar Temas";
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.ForeColor = SystemColors.ControlLightLight;
            lblMateria.Location = new Point(12, 115);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(50, 15);
            lblMateria.TabIndex = 1;
            lblMateria.Text = "Materia:";
            // 
            // lblTema
            // 
            lblTema.AutoSize = true;
            lblTema.ForeColor = SystemColors.ControlLightLight;
            lblTema.Location = new Point(17, 161);
            lblTema.Name = "lblTema";
            lblTema.Size = new Size(38, 15);
            lblTema.TabIndex = 2;
            lblTema.Text = "Tema:";
            // 
            // cmbMaterias
            // 
            cmbMaterias.FormattingEnabled = true;
            cmbMaterias.Location = new Point(68, 112);
            cmbMaterias.Name = "cmbMaterias";
            cmbMaterias.Size = new Size(141, 23);
            cmbMaterias.TabIndex = 3;
            // 
            // txtTema
            // 
            txtTema.Location = new Point(61, 158);
            txtTema.Name = "txtTema";
            txtTema.Size = new Size(148, 23);
            txtTema.TabIndex = 4;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 230);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(134, 230);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // dgvTemas
            // 
            dgvTemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemas.Location = new Point(261, 31);
            dgvTemas.Name = "dgvTemas";
            dgvTemas.ReadOnly = true;
            dgvTemas.RowTemplate.Height = 25;
            dgvTemas.Size = new Size(407, 212);
            dgvTemas.TabIndex = 7;
            dgvTemas.CellContentClick += dgvTemas_CellContentClick_1;
            // 
            // FrmCrudTemas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(680, 277);
            Controls.Add(dgvTemas);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Controls.Add(txtTema);
            Controls.Add(cmbMaterias);
            Controls.Add(lblTema);
            Controls.Add(lblMateria);
            Controls.Add(lbTemas);
            Name = "FrmCrudTemas";
            Text = "FrmCrudTemas";
            Load += FrmCrudTemas_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTemas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTemas;
        private Label lblMateria;
        private Label lblTema;
        private ComboBox cmbMaterias;
        private TextBox txtTema;
        private Button btnGuardar;
        private Button btnSalir;
        private DataGridView dgvTemas;
    }
}