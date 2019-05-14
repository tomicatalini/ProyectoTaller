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


using System.Threading.Tasks;

namespace AppTerminal.Controlador
{
    public class ControladorDeOperaciones
    {
        private Cliente iCliente;

        public ControladorDeOperaciones()
        {

        }
        public ControladorDeOperaciones(int pDocumento, string pNombre)
        {
            this.iCliente = new Cliente(pDocumento, pNombre);
        }

        public List<TarjetaDTO> ObtenerProductos(int pDocumento)
        {
            List<TarjetaDTO> productos = new List<TarjetaDTO>();
            Stopwatch mCronometro = Stopwatch.StartNew();
            var mUrl = string.Format("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db/products?id={0}", pDocumento);

            try
            {
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
                        //Recorre todos los productos (tarjetas) del cliente y los guarda en una lista
                        for (int i = 0; i < mResponseJSON[0].response.product.Count; i++)
                        {
                            var name = mResponseJSON[0].response.product[i].name.ToString();
                            var number = mResponseJSON[0].response.product[i].number.ToString();
                            var type = mResponseJSON[0].response.product[i].type.ToString();

                            productos.Add
                                (
                                    new TarjetaDTO(number, name, type)
                                );
                        }
                        return productos;
                    }
                    else
                    {
                        throw new Exception("No contiene tarjetas disponibles");
                    }
                }
            }
            finally
            {
                mCronometro.Stop();
                Accion mAccion = new Accion(DateTime.Now.Date, mCronometro.Elapsed, "Solicitud de productos.");

                this.iCliente.Acciones.Add(mAccion);
            }

        }


        public bool BlanquearPIN(string pNumeroTarjeta)
        {
            var mUrl = string.Format("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db/product-reset?number={0}", pNumeroTarjeta);
            Stopwatch mCronometro = Stopwatch.StartNew();

            try
            {
                //Se crea el request http
                HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(mUrl);

                //Se ejecuta la consulta
                WebResponse mResponse = mRequest.GetResponse();

                //Se obtiene los datos de respuesta
                using (Stream responseStream = mResponse.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);

                    //Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mResponseJSON = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    if (mResponseJSON.Count >= 1)
                    {
                        if (mResponseJSON[0].response.error == "0")
                        {
                            return true;
                        }
                        else
                        {
                            throw new Exception($"{mResponseJSON[0].response.error} {mResponseJSON[0].response.error_description}");
                        }
                    }
                }
            }
            finally
            {
                mCronometro.Stop();
                Accion mAccion = new Accion(DateTime.Now.Date, mCronometro.Elapsed, "Solicitud de blanqueo de PIN.");

                this.iCliente.Acciones.Add(mAccion);
            }
            return false;
        }

        public double ConsultarSaldo(int pDocumento)
        {

            var mUrl = string.Format("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db/account-balance?id={0}", pDocumento);
            Stopwatch mCronometro = Stopwatch.StartNew();

            try
            {
                HttpWebRequest mPedido = (HttpWebRequest)WebRequest.Create(mUrl);

                WebResponse mRespuesta = mPedido.GetResponse();

                using (Stream mRespuestaStream = mRespuesta.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(mRespuestaStream, Encoding.UTF8);

                    //Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mRespuestaJson = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    if (mRespuestaJson.Count >= 1)
                    {

                        return Convert.ToDouble(mRespuestaJson[0].response.balance);
                    }
                    else
                    {
                        throw new Exception("Hubo un fallo en la ejecucion de la consulta");
                    }

                }
            }
            finally
            {
                mCronometro.Stop();
                Accion mAccion = new Accion(DateTime.Now.Date, mCronometro.Elapsed, "Solicitud de saldo de la cuenta corriente.");

                this.iCliente.Acciones.Add(mAccion);
            }
        }

        public List<MovimientoDTO> ObtenerUltimosMovimientos(int pDocumento)
        {
            List<MovimientoDTO> lista = new List<MovimientoDTO>();
            Stopwatch mCronometro = Stopwatch.StartNew();

            try
            {
                var mUrl = string.Format("https://my-json-server.typicode.com/utn-frcu-isi-tdp/tas-db/account-movements?id={0}", pDocumento);

                HttpWebRequest mPedido = (HttpWebRequest)WebRequest.Create(mUrl);

                WebResponse mRespuesta = mPedido.GetResponse();

                using (Stream mRespuestaStream = mRespuesta.GetResponseStream())
                {

                    StreamReader reader = new StreamReader(mRespuestaStream, Encoding.UTF8);

                    //Se parsea la respuesta y se serializa a JSON a un objeto dynamic
                    dynamic mRespuestaJson = JsonConvert.DeserializeObject(reader.ReadToEnd());

                    if (mRespuestaJson.Count >= 1)
                    {
                        dynamic mMovimientos = mRespuestaJson[0].response.movements;

                        foreach (var movimiento in mMovimientos)
                        {
                            lista.Add(new MovimientoDTO(movimiento.date.ToString(), Convert.ToInt32(movimiento.ammount)));
                        }


                        return lista;
                    }
                    else
                    {
                        throw new Exception("No se pudo acceder al servicio");
                    }
                }
            }
            finally
            {
                mCronometro.Stop();
                Accion mAccion = new Accion(DateTime.Now.Date, mCronometro.Elapsed, "Solicitud de los moviemientos del cliente.");

                this.iCliente.Acciones.Add(mAccion);
            }
        }
    }
}
