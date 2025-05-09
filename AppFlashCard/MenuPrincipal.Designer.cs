namespace AppFlashCard
{
    partial class MenuPrincipal
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
            btnEstudiar = new Button();
            btnCrearFlashcards = new Button();
            button3 = new Button();
            btnCerrarSesion = new Button();
            lblBienvenida = new Label();
            SuspendLayout();
            // 
            // btnEstudiar
            // 
            btnEstudiar.Location = new Point(72, 118);
            btnEstudiar.Name = "btnEstudiar";
            btnEstudiar.Size = new Size(169, 44);
            btnEstudiar.TabIndex = 0;
            btnEstudiar.Text = "Estudiar flashcards";
            btnEstudiar.UseVisualStyleBackColor = true;
            btnEstudiar.Click += btnEstudiar_Click;
            // 
            // btnCrearFlashcards
            // 
            btnCrearFlashcards.Location = new Point(321, 118);
            btnCrearFlashcards.Name = "btnCrearFlashcards";
            btnCrearFlashcards.Size = new Size(159, 44);
            btnCrearFlashcards.TabIndex = 1;
            btnCrearFlashcards.Text = "Crear Flashcards";
            btnCrearFlashcards.UseVisualStyleBackColor = true;
            btnCrearFlashcards.Click += btnCrearFlashcards_Click;
            // 
            // button3
            // 
            button3.Location = new Point(72, 215);
            button3.Name = "button3";
            button3.Size = new Size(169, 44);
            button3.TabIndex = 2;
            button3.Text = "Mi Usuario";
            button3.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.Location = new Point(321, 215);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(159, 44);
            btnCerrarSesion.TabIndex = 3;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Location = new Point(173, 29);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(0, 20);
            lblBienvenida.TabIndex = 4;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(708, 450);
            Controls.Add(lblBienvenida);
            Controls.Add(btnCerrarSesion);
            Controls.Add(button3);
            Controls.Add(btnCrearFlashcards);
            Controls.Add(btnEstudiar);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEstudiar;
        private Button btnCrearFlashcards;
        private Button button3;
        private Button btnCerrarSesion;
        private Label lblBienvenida;
    }
}