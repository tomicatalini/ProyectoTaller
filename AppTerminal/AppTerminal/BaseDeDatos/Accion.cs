using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal.BaseDeDatos
{
    class Accion
    {
        public DateTime Fecha { get; set; }        
        public string Descripcion { get; set; }
        public TimeSpan TiempoOperacion { get; set; }

        public Accion()
        {

        }

        public Accion(DateTime pFecha)
        {
            this.Fecha = pFecha;
        }

        public Accion(DateTime pFecha, TimeSpan pTiempoOperacion, string pDescripcion)
        {

            this.Fecha = pFecha;
            this.TiempoOperacion = pTiempoOperacion;
            this.Descripcion = pDescripcion;
        }
    }
}
