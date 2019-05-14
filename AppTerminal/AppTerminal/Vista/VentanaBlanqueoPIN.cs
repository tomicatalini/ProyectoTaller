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
    public partial class VentanaBlanqueoPIN : Form
    {
        private List<TarjetaDTO> iLista;
        private ControladorDeOperaciones iControlador;
        public VentanaBlanqueoPIN(List<TarjetaDTO> pLista, ControladorDeOperaciones pControlador)
        {
            InitializeComponent();
            this.iControlador = pControlador;
            this.iLista = pLista;
            foreach (var tarjeta in iLista)
            {
                string infoTarjeta = $"{tarjeta.Numero} - {tarjeta.Nombre} - {tarjeta.Tipo}";
                listBox.Items.Add(infoTarjeta);
            }
        }

        private void VentanaBlanqueoPIN_Load(object sender, EventArgs e)
        {

        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void ButtonBlanquear_Click(object sender, EventArgs e)
        {
            try
            {
                TarjetaDTO tarjeta = iLista[listBox.SelectedIndex];
                if (iControlador.BlanquearPIN(tarjeta.Numero))
                {
                    MessageBox.Show("Tarjeta blanqueada correctamente");
                }
                else
                {
                    MessageBox.Show($"Error: No se pudo blanquear la tarjeta");
                }
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
    }
}
