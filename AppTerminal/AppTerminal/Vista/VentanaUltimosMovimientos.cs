using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AppTerminal.DTO;

namespace AppTerminal.Vista
{
    public partial class VentanaUltimosMovimientos : Form
    {
        public VentanaUltimosMovimientos(List<MovimientoDTO> pLista)
        {
            InitializeComponent();
            foreach (MovimientoDTO movimiento in pLista)
            {
                TreeNode nodo = new TreeNode();
                nodo.Text = movimiento.Fecha.ToString();

                TreeNode subNodo = new TreeNode();
                subNodo.Text = movimiento.Monto.ToString();
                nodo.Nodes.Add(subNodo);

                treeView1.Nodes.Add(nodo);
            }
        }

        private void VentanaUltimosMovimientos_Load(object sender, EventArgs e)
        {

        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
