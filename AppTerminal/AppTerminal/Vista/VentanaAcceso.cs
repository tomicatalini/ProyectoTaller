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
    public partial class FormAcceso : Form
    {

        private ControladorDeAcceso iControlador;

        public FormAcceso()
        {
            InitializeComponent();
            this.iControlador = new ControladorDeAcceso();
        }

        private void FormAcceso_Load(object sender, EventArgs e)
        {

        }

        private void ButtonAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                // Creamos el dto del cliente y se lo enviamos al controlador de acceso.
                ClienteDTO cliente = new ClienteDTO(Convert.ToInt32(textBoxDocumento.Text), Convert.ToInt32(textBoxContraseña.Text));

                // Recibimos la respuesta del controlador, si es true pudimos acceder al usuario.
                if (iControlador.Acceso(cliente))
                {
                    FormPrincipal ventanaPrincipal = new FormPrincipal(cliente.Documento);
                    ventanaPrincipal.Show(this);

                    //En caso de salir de la cuenta borramos el documento y la contraseña para retornar.
                    textBoxDocumento.Text = "";
                    textBoxContraseña.Text = "";
                    textBoxDocumento.Focus();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Documento o contraseña erronea");
                    textBoxContraseña.Text = "";
                    textBoxContraseña.Focus();
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

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
