using AppTerminal.BaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal
{
    class RepocitorioCliente
    {
        private List<Cliente> iLista;

        public RepocitorioCliente()
        {
            this.iLista = new List<Cliente>();
        }

        public void AgregarCliente (Cliente pCliente)
        {
            this.iLista.Add(pCliente);
        }


    }
}
