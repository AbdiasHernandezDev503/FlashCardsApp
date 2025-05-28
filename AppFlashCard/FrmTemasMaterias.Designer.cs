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
            ((System.ComponentModel.ISupportInitialize)dgvTemasMaterias).BeginInit();
            SuspendLayout();
            // 
            // dgvTemasMaterias
            // 
            dgvTemasMaterias.AllowUserToAddRows = false;
            dgvTemasMaterias.AllowUserToDeleteRows = false;
            dgvTemasMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemasMaterias.Location = new Point(12, 81);
            dgvTemasMaterias.Name = "dgvTemasMaterias";
            dgvTemasMaterias.ReadOnly = true;
            dgvTemasMaterias.RowHeadersWidth = 51;
            dgvTemasMaterias.RowTemplate.Height = 29;
            dgvTemasMaterias.Size = new Size(760, 306);
            dgvTemasMaterias.TabIndex = 0;
            dgvTemasMaterias.CellContentClick += dgvTemasMaterias_CellContentClick;
            // 
            // FrmTemasMaterias
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvTemasMaterias);
            Name = "FrmTemasMaterias";
            Text = "FrmTemasMaterias";
            Load += FrmTemasMaterias_Load;
            ((System.ComponentModel.ISupportInitialize)dgvTemasMaterias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTemasMaterias;
    }
}