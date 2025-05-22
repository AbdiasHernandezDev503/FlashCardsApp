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
            panelMain.BackColor = ColorTranslator.FromHtml("#2D3250");
            panelMain.Controls.Add(lblBienvenida);
            panelMain.Controls.Add(btnEstudiar);
            panelMain.Controls.Add(btnCrearFlashcards);
            panelMain.Controls.Add(btnMiUsuario);
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
            lblBienvenida.Location = new Point(122, 64);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(326, 45);
            lblBienvenida.TabIndex = 0;
            lblBienvenida.Text = "Bienvenido/a al App";
            lblBienvenida.TextAlign = ContentAlignment.MiddleCenter;
            lblBienvenida.Click += lblBienvenida_Click;
            lblBienvenida.ForeColor = Color.White;
            // 
            // btnEstudiar
            // 
            btnEstudiar.BackColor = ColorTranslator.FromHtml("#676f80"); 
            btnEstudiar.FlatAppearance.BorderSize = 0;
            btnEstudiar.FlatStyle = FlatStyle.Flat;
            btnEstudiar.ForeColor = Color.White;
            btnEstudiar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEstudiar.Location = new Point(237, 172);
            btnEstudiar.Name = "btnEstudiar";
            btnEstudiar.Size = new Size(211, 50);
            btnEstudiar.TabIndex = 1;
            btnEstudiar.Text = "Estudiar Flashcards";
            btnEstudiar.UseVisualStyleBackColor = false;
            btnEstudiar.Click += btnEstudiar_Click;

            // 
            // btnCrearFlashcards
            //
            btnCrearFlashcards.BackColor = ColorTranslator.FromHtml("#676f9d");
            btnCrearFlashcards.FlatAppearance.BorderSize = 0;
            btnCrearFlashcards.FlatStyle = FlatStyle.Flat;
            btnCrearFlashcards.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCrearFlashcards.Location = new Point(237, 246);
            btnCrearFlashcards.Name = "btnCrearFlashcards";
            btnCrearFlashcards.Size = new Size(211, 50);
            btnCrearFlashcards.TabIndex = 2;
            btnCrearFlashcards.Text = "Crear Flashcards";
            btnCrearFlashcards.UseVisualStyleBackColor = true;
            btnCrearFlashcards.Click += btnCrearFlashcards_Click;
            btnCrearFlashcards.ForeColor = Color.White;
            // 
            // btnMiUsuario
            // 
            btnMiUsuario.BackColor = ColorTranslator.FromHtml("#464769");
            btnMiUsuario.FlatAppearance.BorderSize = 0;
            btnMiUsuario.FlatStyle = FlatStyle.Flat;
            btnMiUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnMiUsuario.Location = new Point(237, 334);
            btnMiUsuario.Name = "btnMiUsuario";
            btnMiUsuario.Size = new Size(211, 50);
            btnMiUsuario.TabIndex = 3;
            btnMiUsuario.Text = "Mi Usuario";
            btnMiUsuario.UseVisualStyleBackColor = true;
            btnMiUsuario.ForeColor = Color.White;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = ColorTranslator.FromHtml("#ffb17a");
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnCerrarSesion.Location = new Point(237, 427);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Size = new Size(211, 50);
            btnCerrarSesion.TabIndex = 4;
            btnCerrarSesion.Text = "Cerrar Sesión";
            btnCerrarSesion.UseVisualStyleBackColor = true;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            btnCerrarSesion.ForeColor = Color.White;
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
        private Button btnMiUsuario;
        private Button btnCerrarSesion;
    }
}
