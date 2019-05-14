using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using AppTerminal.DTO;
using AppTerminal.BaseDeDatos;

namespace AppTerminal.Controlador
{
    public class ControladorDeAcceso
    {
        public bool Acceso(ClienteDTO pCliente)
        {
            var mUrl = string.Format("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db/clients?id={0}&pass={1}", pCliente.Documento, pCliente.Contraseña);
            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            // Se ejecuta la consulta
            WebResponse mResponse = mRequest.GetResponse();

            // Se obtiene los datos de respuesta
            using (Stream responseStream = mResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());


                if (mResponseJSON.Count >= 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
