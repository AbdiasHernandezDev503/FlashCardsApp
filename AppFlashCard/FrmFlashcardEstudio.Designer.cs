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
            components = new System.ComponentModel.Container();
            pnlRespuesta = new Panel();
            lblRespuesta = new Label();
            pnlPregunta = new Panel();
            lblPregunta = new Label();
            lblVoltear = new Label();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            lblContador = new Label();
            timerFlip = new System.Windows.Forms.Timer(components);
            lblNombreTema = new Label();
            panel1 = new Panel();
            timerSlide = new System.Windows.Forms.Timer(components);
            btnSalir = new Button();
            pnlRespuesta.SuspendLayout();
            pnlPregunta.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRespuesta
            // 
            pnlRespuesta.BorderStyle = BorderStyle.FixedSingle;
            pnlRespuesta.Controls.Add(lblRespuesta);
            pnlRespuesta.Cursor = Cursors.Hand;
            pnlRespuesta.Location = new Point(3, 77);
            pnlRespuesta.Name = "pnlRespuesta";
            pnlRespuesta.Size = new Size(917, 387);
            pnlRespuesta.TabIndex = 0;
            pnlRespuesta.Visible = false;
            pnlRespuesta.Click += pnlRespuesta_Click;
            // 
            // lblRespuesta
            // 
            lblRespuesta.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            lblRespuesta.Location = new Point(-1, 0);
            lblRespuesta.Name = "lblRespuesta";
            lblRespuesta.Size = new Size(917, 376);
            lblRespuesta.TabIndex = 1;
            lblRespuesta.Text = "RESPUESTA";
            lblRespuesta.TextAlign = ContentAlignment.MiddleCenter;
            lblRespuesta.Click += lblRespuesta_Click;
            // 
            // pnlPregunta
            // 
            pnlPregunta.BorderStyle = BorderStyle.FixedSingle;
            pnlPregunta.Controls.Add(lblPregunta);
            pnlPregunta.Cursor = Cursors.Hand;
            pnlPregunta.Location = new Point(3, 67);
            pnlPregunta.Name = "pnlPregunta";
            pnlPregunta.Size = new Size(920, 397);
            pnlPregunta.TabIndex = 0;
            pnlPregunta.Click += pnlPregunta_Click;
            // 
            // lblPregunta
            // 
            lblPregunta.Font = new Font("Segoe UI Symbol", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            lblPregunta.Location = new Point(-1, 21);
            lblPregunta.Name = "lblPregunta";
            lblPregunta.Size = new Size(916, 374);
            lblPregunta.TabIndex = 1;
            lblPregunta.Text = "PREGUNTA";
            lblPregunta.TextAlign = ContentAlignment.MiddleCenter;
            lblPregunta.Click += lblPregunta_Click;
            // 
            // lblVoltear
            // 
            lblVoltear.BackColor = Color.RoyalBlue;
            lblVoltear.Cursor = Cursors.Hand;
            lblVoltear.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblVoltear.ForeColor = SystemColors.ButtonHighlight;
            lblVoltear.Location = new Point(3, 467);
            lblVoltear.Name = "lblVoltear";
            lblVoltear.Size = new Size(920, 43);
            lblVoltear.TabIndex = 0;
            lblVoltear.Text = "¡Haz clic en la ficha para voltear!";
            lblVoltear.TextAlign = ContentAlignment.MiddleCenter;
            lblVoltear.Click += lblVoltear_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Location = new Point(17, 526);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(262, 38);
            btnAnterior.TabIndex = 1;
            btnAnterior.Text = "Anterior";
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Location = new Point(646, 526);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(236, 38);
            btnSiguiente.TabIndex = 2;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(403, 530);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(31, 20);
            lblContador.TabIndex = 3;
            lblContador.Text = "0/0";
            // 
            // timerFlip
            // 
            timerFlip.Interval = 1;
            timerFlip.Tick += timerFlip_Tick;
            // 
            // lblNombreTema
            // 
            lblNombreTema.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNombreTema.Location = new Point(3, 9);
            lblNombreTema.Name = "lblNombreTema";
            lblNombreTema.Size = new Size(920, 42);
            lblNombreTema.TabIndex = 4;
            lblNombreTema.Text = "Tema";
            lblNombreTema.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Location = new Point(3, 570);
            panel1.Name = "panel1";
            panel1.Size = new Size(917, 2);
            panel1.TabIndex = 5;
            // 
            // timerSlide
            // 
            timerSlide.Interval = 10;
            timerSlide.Tick += timerSlide_Tick;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(367, 603);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(133, 43);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmFlashcardEstudio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(926, 694);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Controls.Add(pnlPregunta);
            Controls.Add(lblNombreTema);
            Controls.Add(lblContador);
            Controls.Add(lblVoltear);
            Controls.Add(btnSiguiente);
            Controls.Add(btnAnterior);
            Controls.Add(pnlRespuesta);
            Name = "FrmFlashcardEstudio";
            Text = "FrmFlashcardEstudio";
            Load += FrmFlashcardEstudio_Load;
            pnlRespuesta.ResumeLayout(false);
            pnlPregunta.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlRespuesta;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Label lblContador;
        private Panel pnlPregunta;
        private Label lblRespuesta;
        private Label lblVoltear;
        private Label lblPregunta;
        private System.Windows.Forms.Timer timerFlip;
        private Label lblNombreTema;
        private Panel panel1;
        private System.Windows.Forms.Timer timerSlide;
        private Button btnSalir;
    }
}