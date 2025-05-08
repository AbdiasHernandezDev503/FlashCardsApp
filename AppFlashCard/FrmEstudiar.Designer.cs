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
            pbArbol = new PictureBox();
            panelArbol = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbArbol).BeginInit();
            panelArbol.SuspendLayout();
            SuspendLayout();
            // 
            // pbArbol
            // 
            pbArbol.Location = new Point(3, 10);
            pbArbol.Name = "pbArbol";
            pbArbol.Size = new Size(1011, 371);
            pbArbol.SizeMode = PictureBoxSizeMode.AutoSize;
            pbArbol.TabIndex = 0;
            pbArbol.TabStop = false;
            // 
            // panelArbol
            // 
            panelArbol.Controls.Add(pbArbol);
            panelArbol.Location = new Point(0, 2);
            panelArbol.Name = "panelArbol";
            panelArbol.Size = new Size(1023, 455);
            panelArbol.TabIndex = 1;
            // 
            // FrmEstudiar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 570);
            Controls.Add(panelArbol);
            Name = "FrmEstudiar";
            Text = "FrmEstudiar";
            Load += FrmEstudiar_Load;
            ((System.ComponentModel.ISupportInitialize)pbArbol).EndInit();
            panelArbol.ResumeLayout(false);
            panelArbol.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbArbol;
        private Panel panelArbol;
    }
}