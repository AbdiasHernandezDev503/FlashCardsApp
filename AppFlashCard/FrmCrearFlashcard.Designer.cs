namespace AppFlashCard
{
    partial class FrmCrearFlashcard
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtRespuesta = new RichTextBox();
            txtPregunta = new RichTextBox();
            cbMaterias = new ComboBox();
            cbTemas = new ComboBox();
            lblContador = new Label();
            SuspendLayout();
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(155, 515);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(192, 39);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Flashcard";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnCrearFlashcard_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(775, 515);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(179, 39);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Engravers MT", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(341, 9);
            label1.Name = "label1";
            label1.Size = new Size(528, 27);
            label1.TabIndex = 2;
            label1.Text = "CREAR FLASHCARD DE ESTUDIO";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(64, 92);
            label2.Name = "label2";
            label2.Size = new Size(67, 20);
            label2.TabIndex = 3;
            label2.Text = "Materia: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(611, 92);
            label3.Name = "label3";
            label3.Size = new Size(52, 20);
            label3.TabIndex = 4;
            label3.Text = "Tema: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(64, 178);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 5;
            label4.Text = "Pregunta:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(611, 178);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 6;
            label5.Text = "Respuesta: ";
            // 
            // txtRespuesta
            // 
            txtRespuesta.Location = new Point(719, 178);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(424, 233);
            txtRespuesta.TabIndex = 7;
            txtRespuesta.Text = "";
            // 
            // txtPregunta
            // 
            txtPregunta.Location = new Point(155, 178);
            txtPregunta.Name = "txtPregunta";
            txtPregunta.Size = new Size(426, 233);
            txtPregunta.TabIndex = 8;
            txtPregunta.Text = "";
            // 
            // cbMaterias
            // 
            cbMaterias.FormattingEnabled = true;
            cbMaterias.Location = new Point(155, 89);
            cbMaterias.Name = "cbMaterias";
            cbMaterias.Size = new Size(426, 28);
            cbMaterias.TabIndex = 9;
            cbMaterias.SelectedIndexChanged += cbMaterias_SelectedIndexChanged;
            // 
            // cbTemas
            // 
            cbTemas.FormattingEnabled = true;
            cbTemas.Location = new Point(719, 89);
            cbTemas.Name = "cbTemas";
            cbTemas.Size = new Size(424, 28);
            cbTemas.TabIndex = 10;
            cbTemas.SelectedIndexChanged += cbTemas_SelectedIndexChanged;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(66, 439);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(0, 20);
            lblContador.TabIndex = 11;
            // 
            // FrmCrearFlashcard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1219, 586);
            Controls.Add(lblContador);
            Controls.Add(cbTemas);
            Controls.Add(cbMaterias);
            Controls.Add(txtPregunta);
            Controls.Add(txtRespuesta);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(btnGuardar);
            Name = "FrmCrearFlashcard";
            Text = "FrmCrearFlashcard";
            Load += FrmCrearFlashcard_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGuardar;
        private Button btnSalir;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private RichTextBox txtRespuesta;
        private RichTextBox txtPregunta;
        private ComboBox cbMaterias;
        private ComboBox cbTemas;
        private Label lblContador;
    }
}