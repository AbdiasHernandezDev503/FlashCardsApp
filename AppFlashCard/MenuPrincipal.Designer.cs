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
            btnMiUsuario = new Button();
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
            panelMain.Controls.Add(btnMiUsuario);
            panelMain.Controls.Add(btnCerrarSesion);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Margin = new Padding(2, 2, 2, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(520, 337);
            panelMain.TabIndex = 0;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(85, 38);
            lblBienvenida.Margin = new Padding(2, 0, 2, 0);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(223, 30);
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
            btnEstudiar.Location = new Point(166, 103);
            btnEstudiar.Margin = new Padding(2, 2, 2, 2);
            btnEstudiar.Name = "btnEstudiar";
            btnEstudiar.Size = new Size(148, 30);
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
            btnCrearFlashcards.Location = new Point(166, 148);
            btnCrearFlashcards.Margin = new Padding(2, 2, 2, 2);
            btnCrearFlashcards.Name = "btnCrearFlashcards";
            btnCrearFlashcards.Size = new Size(148, 30);
            btnCrearFlashcards.TabIndex = 2;
            btnCrearFlashcards.Text = "Crear Flashcards";
            btnCrearFlashcards.UseVisualStyleBackColor = true;
            btnCrearFlashcards.Click += btnCrearFlashcards_Click;
            // 
            // btnMiUsuario
            // 
            btnMiUsuario.BackColor = Color.FromArgb(70, 71, 105);
            btnMiUsuario.FlatAppearance.BorderSize = 0;
            btnMiUsuario.FlatStyle = FlatStyle.Flat;
            btnMiUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMiUsuario.ForeColor = Color.White;
            btnMiUsuario.Location = new Point(166, 200);
            btnMiUsuario.Margin = new Padding(2, 2, 2, 2);
            btnMiUsuario.Name = "btnMiUsuario";
            btnMiUsuario.Size = new Size(148, 30);
            btnMiUsuario.TabIndex = 3;
            btnMiUsuario.Text = "Mi Usuario";
            btnMiUsuario.UseVisualStyleBackColor = true;
            btnMiUsuario.Click += btnMiUsuario_Click;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(255, 177, 122);
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(166, 256);
            btnCerrarSesion.Margin = new Padding(2, 2, 2, 2);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(148, 30);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(520, 337);
            Controls.Add(panelMain);
            Margin = new Padding(2, 2, 2, 2);
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
        private Button btnMiUsuario;
        private Button btnCerrarSesion;
    }
}
