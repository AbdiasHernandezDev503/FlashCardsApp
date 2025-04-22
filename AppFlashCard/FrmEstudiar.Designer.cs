namespace AppFlashCard
{
    partial class FrmEstudiar
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
            dgvMaterias = new DataGridView();
            dgvTemas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTemas).BeginInit();
            SuspendLayout();
            // 
            // dgvMaterias
            // 
            dgvMaterias.AllowUserToDeleteRows = false;
            dgvMaterias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMaterias.Location = new Point(76, 35);
            dgvMaterias.Name = "dgvMaterias";
            dgvMaterias.RowHeadersWidth = 51;
            dgvMaterias.RowTemplate.Height = 29;
            dgvMaterias.Size = new Size(561, 223);
            dgvMaterias.TabIndex = 0;
            dgvMaterias.CellClick += dgvMaterias_CellClick;
            // 
            // dgvTemas
            // 
            dgvTemas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTemas.Location = new Point(76, 264);
            dgvTemas.Name = "dgvTemas";
            dgvTemas.RowHeadersWidth = 51;
            dgvTemas.RowTemplate.Height = 29;
            dgvTemas.Size = new Size(561, 130);
            dgvTemas.TabIndex = 1;
            dgvTemas.Visible = false;
            // 
            // FrmEstudiar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 450);
            Controls.Add(dgvTemas);
            Controls.Add(dgvMaterias);
            Name = "FrmEstudiar";
            Text = "FrmEstudiar";
            Load += FrmEstudiar_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMaterias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTemas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMaterias;
        private DataGridView dgvTemas;
    }
}