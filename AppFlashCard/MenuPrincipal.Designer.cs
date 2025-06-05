namespace AppFlashCard
{
    partial class MenuPrincipal
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblBienvenida = new Label();
            btnEstudiar = new Button();
            btnCrearFlashcards = new Button();
            btnCerrarSesion = new Button();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.FromArgb(45, 50, 80);
            panelMain.Controls.Add(lblBienvenida);
            panelMain.Controls.Add(btnEstudiar);
            panelMain.Controls.Add(btnCrearFlashcards);
            panelMain.Controls.Add(btnCerrarSesion);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(743, 562);
            panelMain.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(190, 79);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(326, 45);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido/a al App";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Click += lblBienvenida_Click;
            // 
            // btnEstudiar
            // 
            btnEstudiar.BackColor = Color.FromArgb(103, 111, 128);
            btnEstudiar.FlatAppearance.BorderSize = 0;
            btnEstudiar.FlatStyle = FlatStyle.Flat;
            btnEstudiar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEstudiar.ForeColor = Color.White;
            btnEstudiar.Location = new Point(390, 212);
            btnEstudiar.Name = "btnEstudiar";
            btnEstudiar.Size = new Size(211, 50);
            btnEstudiar.TabIndex = 1;
            btnEstudiar.Text = "Estudiar Flashcards";
            btnEstudiar.UseVisualStyleBackColor = false;
            btnEstudiar.Click += btnEstudiar_Click;
            // 
            // btnCrearFlashcards
            // 
            btnCrearFlashcards.BackColor = Color.FromArgb(103, 111, 157);
            btnCrearFlashcards.FlatAppearance.BorderSize = 0;
            btnCrearFlashcards.FlatStyle = FlatStyle.Flat;
            btnCrearFlashcards.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCrearFlashcards.ForeColor = Color.White;
            btnCrearFlashcards.Location = new Point(121, 212);
            btnCrearFlashcards.Name = "btnCrearFlashcards";
            btnCrearFlashcards.Size = new Size(211, 50);
            btnCrearFlashcards.TabIndex = 2;
            btnCrearFlashcards.Text = "Crear Flashcards";
            btnCrearFlashcards.UseVisualStyleBackColor = true;
            btnCrearFlashcards.Click += btnCrearFlashcards_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(255, 177, 122);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(252, 378);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(211, 50);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(743, 562);
            Controls.Add(panelMain);
            Name = "MenuPrincipal";
            Text = "Menú Principal";
            Load += MenuPrincipal_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelMain;
        private Label lblBienvenida;
        private Button btnEstudiar;
        private Button btnCrearFlashcards;
        private Button btnCerrarSesion;
    }
}
