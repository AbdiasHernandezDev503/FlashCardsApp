namespace AppFlashCard
{
    partial class FrmCrudMaterias
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
            btnGuardar = new Button();
            btnSalir = new Button();
            txtMateria = new TextBox();
            lblMateria = new Label();
            sqlCommandBuilder1 = new Microsoft.Data.SqlClient.SqlCommandBuilder();
            lblAgregarMateria = new Label();
            dgvMaterias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(12, 236);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(104, 29);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.TopCenter;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(171, 236);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(107, 29);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // txtMateria
            // 
            txtMateria.Location = new Point(74, 146);
            txtMateria.Name = "txtMateria";
            txtMateria.Size = new Size(181, 23);
            txtMateria.TabIndex = 2;
            // 
            // lblMateria
            // 
            lblMateria.AutoSize = true;
            lblMateria.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            lblMateria.ForeColor = SystemColors.ControlLightLight;
            lblMateria.Location = new Point(12, 146);
            lblMateria.Name = "lblMateria";
            lblMateria.Size = new Size(56, 17);
            lblMateria.TabIndex = 3;
            lblMateria.Text = "Materia:";
            lblMateria.Click += label1_Click;
            // 
            // lblAgregarMateria
            // 
            lblAgregarMateria.AutoSize = true;
            lblAgregarMateria.BackColor = Color.Transparent;
            lblAgregarMateria.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblAgregarMateria.ForeColor = Color.FromArgb(251, 185, 135);
            lblAgregarMateria.Location = new Point(89, 68);
            lblAgregarMateria.Name = "lblAgregarMateria";
            lblAgregarMateria.Size = new Size(150, 25);
            lblAgregarMateria.TabIndex = 4;
            lblAgregarMateria.Text = "Agregar Materia";
            // 
            // dgvMaterias
            // 
            dgvMaterias.AllowUserToAddRows = false;
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Location = new Point(332, 30);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.ReadOnly = true;
            dgvMaterias.RowTemplate.Height = 25;
            dgvMaterias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMaterias.Size = new Size(323, 264);
            dgvMaterias.TabIndex = 5;
            dgvMaterias.CellContentClick += dgvMaterias_CellContentClick;
            // 
            // FrmCrudMaterias
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(660, 305);
            Controls.Add(dgvMaterias);
            Controls.Add(lblAgregarMateria);
            Controls.Add(lblMateria);
            Controls.Add(txtMateria);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Name = "FrmCrudMaterias";
            Text = "FrmCrudMaterias";
            Load += FrmCrudMaterias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button btnSalir;
        private TextBox txtMateria;
        private Label lblMateria;
        private Microsoft.Data.SqlClient.SqlCommandBuilder sqlCommandBuilder1;
        private Label lblAgregarMateria;
        private DataGridView dgvMaterias;
    }
}