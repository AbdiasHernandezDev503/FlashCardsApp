namespace AppFlashCard
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnRegistrar_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            using (FrmRegistro registro = new FrmRegistro())
            {
                registro.ShowDialog();
            }
        }

        private void btnSalir_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
    }
}
