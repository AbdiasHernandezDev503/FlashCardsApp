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
            components = new System.ComponentModel.Container();
            menuEstudiar = new MenuStrip();
            btnSalir = new Button();
            panelSlider = new Panel();
            btnIzquierda = new Button();
            btnDerecha = new Button();
            animTimer = new System.Windows.Forms.Timer(components);
            timerAutoSlider = new System.Windows.Forms.Timer(components);
            timerDelayReinicio = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            SuspendLayout();
            // 
            // menuEstudiar
            // 
            menuEstudiar.ImageScalingSize = new Size(20, 20);
            menuEstudiar.Location = new Point(0, 0);
            menuEstudiar.Name = "menuEstudiar";
            menuEstudiar.Size = new Size(1035, 24);
            menuEstudiar.TabIndex = 0;
            menuEstudiar.Text = "menuEstudiar";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(37, 446);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(142, 36);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // panelSlider
            // 
            panelSlider.BorderStyle = BorderStyle.Fixed3D;
            panelSlider.Location = new Point(124, 111);
            panelSlider.Name = "panelSlider";
            panelSlider.Size = new Size(798, 250);
            panelSlider.TabIndex = 2;
            // 
            // btnIzquierda
            // 
            btnIzquierda.Location = new Point(124, 381);
            btnIzquierda.Name = "btnIzquierda";
            btnIzquierda.Size = new Size(213, 29);
            btnIzquierda.TabIndex = 3;
            btnIzquierda.Text = "<- Atrás";
            btnIzquierda.UseVisualStyleBackColor = true;
            btnIzquierda.Click += btnIzquierda_Click;
            // 
            // btnDerecha
            // 
            btnDerecha.Location = new Point(699, 381);
            btnDerecha.Name = "btnDerecha";
            btnDerecha.Size = new Size(189, 29);
            btnDerecha.TabIndex = 4;
            btnDerecha.Text = "Siguiente ->";
            btnDerecha.UseVisualStyleBackColor = true;
            btnDerecha.Click += btnDerecha_Click;
            // 
            // animTimer
            // 
            animTimer.Interval = 10;
            animTimer.Tick += animTimer_Tick;
            // 
            // timerAutoSlider
            // 
            timerAutoSlider.Enabled = true;
            timerAutoSlider.Interval = 20000;
            timerAutoSlider.Tick += timerAutoSlider_Tick;
            // 
            // timerDelayReinicio
            // 
            timerDelayReinicio.Tick += timerDelayReinicio_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(152, 76);
            label1.Name = "label1";
            label1.Size = new Size(748, 32);
            label1.TabIndex = 5;
            label1.Text = "FLASHCARDS CREADAS POR NUESTROS USUARIOS";
            // 
            // FrmEstudiar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 570);
            Controls.Add(label1);
            Controls.Add(btnDerecha);
            Controls.Add(btnIzquierda);
            Controls.Add(panelSlider);
            Controls.Add(btnSalir);
            Controls.Add(menuEstudiar);
            MainMenuStrip = menuEstudiar;
            Name = "FrmEstudiar";
            Text = "FrmEstudiar";
            Load += FrmEstudiar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuEstudiar;
        private Button btnSalir;
        private Panel panelSlider;
        private Button btnIzquierda;
        private Button btnDerecha;
        private System.Windows.Forms.Timer animTimer;
        private System.Windows.Forms.Timer timerAutoSlider;
        private System.Windows.Forms.Timer timerDelayReinicio;
        private Label label1;
    }
}