namespace AppFlashCard
{
    partial class FrmFlashcardEstudio
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
            panel1 = new Panel();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(24, 50);
            panel1.Name = "panel1";
            panel1.Size = new Size(871, 369);
            panel1.TabIndex = 0;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(24, 440);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(262, 29);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(659, 440);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(236, 29);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(409, 440);
            label1.Name = "label1";
            label1.Size = new Size(31, 20);
            label1.TabIndex = 3;
            label1.Text = "1/2";
            // 
            // FrmFlashcardEstudio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 519);
            Controls.Add(label1);
            Controls.Add(btnSiguiente);
            Controls.Add(btnAnterior);
            Controls.Add(panel1);
            Name = "FrmFlashcardEstudio";
            Text = "FrmFlashcardEstudio";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Label label1;
    }
}