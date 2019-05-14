using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal.BaseDeDatos
{
    class Cliente
    {
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public IList<Accion> Acciones { get; set; }

        public Cliente()
        {

        }

        public Cliente(int pDocumento, string pNombre)
        {
            this.Documento = pDocumento;
            this.Nombre = pNombre;
            this.Acciones = new List<Accion>();
        }
    }
}
