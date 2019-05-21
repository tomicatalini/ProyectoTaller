using System;
using System.Windows.Forms;

namespace AppTerminal.Vista
{
    public partial class VentanaSaldo : Form
    {
        public VentanaSaldo(double pSaldo)
        {
            InitializeComponent();
            textBox1.Text = pSaldo.ToString();
        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VentanaSaldo_Load(object sender, EventArgs e)
        {

        }
    }
}
