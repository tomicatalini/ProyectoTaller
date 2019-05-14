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
using System.Windows.Forms;
using AppTerminal.Controlador;

namespace AppTerminal.Vista
{
    public partial class FormPrincipal : Form
    {
        private int iDocumento;
        private ControladorDeOperaciones iControlador;
        public FormPrincipal(int pDocumento)
        {
            InitializeComponent();
            this.iDocumento = pDocumento;
            this.iControlador = new ControladorDeOperaciones();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void ButtonSalir_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void ButtonBlanqueoPIN_Click(object sender, EventArgs e)
        {
            try
            {
                List<TarjetaDTO> lista = iControlador.ObtenerProductos(iDocumento);
                VentanaBlanqueoPIN blanqueo = new VentanaBlanqueoPIN(lista, iControlador);
                blanqueo.Show(this);
                this.Hide();
            }
            catch (WebException ex)
            {
                if (!(ex.Response is null))
                {
                    WebResponse mErrorResponse = ex.Response;
                    using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                    {
                        StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                        String mErrorText = mReader.ReadToEnd();
                        MessageBox.Show(String.Format("Error: {0}", mErrorText));
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo tener acceso al servidor remoto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }
        }

        private void ButtonSaldo_Click(object sender, EventArgs e)
        {
            try
            {
                double saldo = iControlador.ConsultarSaldo(iDocumento);
                VentanaSaldo ventanaSaldo = new VentanaSaldo(saldo);
                ventanaSaldo.ShowDialog();
            }
            catch (WebException ex)
            {
                if (!(ex.Response is null))
                {
                    WebResponse mErrorResponse = ex.Response;
                    using (Stream mResponseStream = mErrorResponse.GetResponseStream())
                    {
                        StreamReader mReader = new StreamReader(mResponseStream, Encoding.GetEncoding("utf-8"));
                        String mErrorText = mReader.ReadToEnd();
                        MessageBox.Show(String.Format("Error: {0}", mErrorText));
                    }
                }
                else
                {
                    MessageBox.Show("No se pudo tener acceso al servidor remoto");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Error: {0}", ex.Message));
            }
        }

        private void ButtonUltimosMovimientos_Click(object sender, EventArgs e)
        {
            List<MovimientoDTO> lista = iControlador.ObtenerUltimosMovimientos(iDocumento);
            VentanaUltimosMovimientos ventana = new VentanaUltimosMovimientos(lista);
            ventana.ShowDialog(this);
        }
    }
}
