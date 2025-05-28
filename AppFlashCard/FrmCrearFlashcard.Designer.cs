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
            btnGuardar.BackColor = Color.FromArgb(248, 187, 132);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGuardar.Location = new Point(116, 308);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(194, 53);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar Flashcard";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnCrearFlashcard_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(248, 187, 132);
            btnSalir.FlatAppearance.BorderColor = Color.FromArgb(248, 187, 132);
            btnSalir.FlatAppearance.BorderSize = 0;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnSalir.Location = new Point(344, 308);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(185, 53);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semilight", 18F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(415, 18);
            label1.Name = "label1";
            label1.Size = new Size(302, 32);
            label1.TabIndex = 2;
            label1.Text = "Crear FlashCards de estudio";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(41, 137);
            label2.Name = "label2";
            label2.Size = new Size(70, 21);
            label2.TabIndex = 3;
            label2.Text = "Materia: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = Color.White;
            label3.Location = new Point(58, 192);
            label3.Name = "label3";
            label3.Size = new Size(53, 21);
            label3.TabIndex = 4;
            label3.Text = "Tema: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.ForeColor = Color.White;
            label4.Location = new Point(629, 77);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 5;
            label4.Text = "Pregunta:";
            label4.Click += label4_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semilight", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.ForeColor = Color.White;
            label5.Location = new Point(629, 237);
            label5.Name = "label5";
            label5.Size = new Size(88, 21);
            label5.TabIndex = 6;
            label5.Text = "Respuesta: ";
            // 
            // txtRespuesta
            // 
            txtRespuesta.BackColor = Color.FromArgb(77, 79, 117);
            txtRespuesta.BorderStyle = BorderStyle.None;
            txtRespuesta.Location = new Point(629, 269);
            txtRespuesta.Margin = new Padding(3, 2, 3, 2);
            txtRespuesta.Name = "txtRespuesta";
            txtRespuesta.Size = new Size(373, 113);
            txtRespuesta.TabIndex = 7;
            txtRespuesta.Text = "";
            // 
            // txtPregunta
            // 
            txtPregunta.BackColor = Color.FromArgb(77, 79, 117);
            txtPregunta.BorderStyle = BorderStyle.None;
            txtPregunta.ForeColor = SystemColors.ActiveCaptionText;
            txtPregunta.Location = new Point(629, 111);
            txtPregunta.Margin = new Padding(3, 2, 3, 2);
            txtPregunta.Name = "txtPregunta";
            txtPregunta.Size = new Size(373, 113);
            txtPregunta.TabIndex = 8;
            txtPregunta.Text = "";
            // 
            // cbMaterias
            // 
            cbMaterias.BackColor = Color.FromArgb(77, 79, 117);
            cbMaterias.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMaterias.FormattingEnabled = true;
            cbMaterias.Location = new Point(136, 137);
            cbMaterias.Margin = new Padding(3, 2, 3, 2);
            cbMaterias.Name = "cbMaterias";
            cbMaterias.Size = new Size(393, 23);
            cbMaterias.TabIndex = 9;
            cbMaterias.SelectedIndexChanged += cbMaterias_SelectedIndexChanged;
            // 
            // cbTemas
            // 
            cbTemas.BackColor = Color.FromArgb(77, 79, 117);
            cbTemas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTemas.FormattingEnabled = true;
            cbTemas.Location = new Point(136, 192);
            cbTemas.Margin = new Padding(3, 2, 3, 2);
            cbTemas.Name = "cbTemas";
            cbTemas.Size = new Size(393, 23);
            cbTemas.TabIndex = 10;
            cbTemas.SelectedIndexChanged += cbTemas_SelectedIndexChanged;
            // 
            // lblContador
            // 
            lblContador.AutoSize = true;
            lblContador.Location = new Point(58, 329);
            lblContador.Name = "lblContador";
            lblContador.Size = new Size(0, 15);
            lblContador.TabIndex = 11;
            // 
            // FrmCrearFlashcard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(53, 56, 89);
            ClientSize = new Size(1067, 440);
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
            Margin = new Padding(3, 2, 3, 2);
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