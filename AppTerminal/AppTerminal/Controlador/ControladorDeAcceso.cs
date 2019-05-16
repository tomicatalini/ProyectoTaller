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
using NLog;

namespace AppTerminal.Controlador
{
    public class ControladorDeAcceso
    {
        private static Logger iLog = LogManager.GetCurrentClassLogger();
        public bool Acceso(ClienteDTO pCliente)
        {
            iLog.Info("Se inicia la operacion de validacion de acceso del cliente");
            var mUrl = string.Format("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db/clients?id={0}&pass={1}", pCliente.Documento, pCliente.Contraseña);

            iLog.Info("Se realiza el pedido correspondiente al servidor");
            // Se crea el request http
            HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

            iLog.Info("Se obtiene una respuesta del servidor");
            // Se ejecuta la consulta
            WebResponse mResponse = mRequest.GetResponse();

            // Se obtiene los datos de respuesta
            using (Stream responseStream = mResponse.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                iLog.Info("Se deserializa la respuesta para su analisis");
                // Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());


                if (mResponseJSON.Count >= 1)
                {
                    iLog.Info("El cliente ha ingresado correctamente");
                    return true;
                }
            }
            iLog.Warn("Error al ingresar el documento y/o contraseña.");
            return false;
        }
    }
}
