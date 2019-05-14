using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal.DTO
{
    public class TarjetaDTO
    {
        public string Numero { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; }

        public TarjetaDTO(string pNumero, string pNombre, string pTipo)
        {
            this.Numero = pNumero;
            this.Nombre = pNombre;
            this.Tipo = pTipo;
        }
    }
}
