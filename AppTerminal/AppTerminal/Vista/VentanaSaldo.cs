using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
