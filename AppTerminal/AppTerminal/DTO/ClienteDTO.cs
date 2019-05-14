using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTerminal.DTO
{
    public class ClienteDTO
    {
        public int Documento { get; set; }
        public int Contraseña { get; set; }

        public ClienteDTO(int pDocumento, int pContraseña)
        {
            this.Documento = pDocumento;
            this.Contraseña = pContraseña;
        }
    }
}
