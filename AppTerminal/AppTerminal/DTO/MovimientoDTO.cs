using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal.DTO
{
    public class MovimientoDTO
    {
        public string Fecha { get; set; }
        public int Monto { get; set; }

        public MovimientoDTO()
        {

        }

        public MovimientoDTO(string pFecha, int pMonto)
        {

            this.Fecha = pFecha;
            this.Monto = pMonto;
        }
    }
}
