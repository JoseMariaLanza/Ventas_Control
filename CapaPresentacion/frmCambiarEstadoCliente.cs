using CapaNegocio;
using CapaPresentacion.Modulos.Notificaciones;
using CapaPresentacion.Properties;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmCambiarEstadoCliente : MetroForm
    {
        string Estado;
        Notificaciones Notificacion = new Notificaciones();

        public frmCambiarEstadoCliente()
        {
            InitializeComponent();
        }

        private void frmCambiarEstadoCliente_Load(object sender, EventArgs e)
        {

        }

        #region INSTANCIACION
        private static frmCambiarEstadoCliente _Instancia = null;

        public static frmCambiarEstadoCliente Instancia
        {
            get
            {
                return _Instancia;
            }

            set
            {
                _Instancia = value;
            }
        }

        public static frmCambiarEstadoCliente GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmCambiarEstadoCliente();
            }
            return Instancia;
        }

        private void frmCambiarEstadoCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }

        #endregion

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                EditarEstado();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrío un error no esperado, tome una captura de pantalla, anote los pasos que realizó antes que le saliera este error e informe al administrador del sistema." +
                    " Mensaje para el administrador: " + ex.Message + " Traza: " + ex.StackTrace);
            }
        }

        private void EditarEstado()
        {
            string respuesta = "";
            Estado = cmbEstado.Text;
            frmDeudores formDeudores = frmDeudores.GetInstancia();
            respuesta = NegocioCliente.Editar(formDeudores.IdCliente, Estado);
            if (respuesta.Equals("OK"))
            {
                Notificacion.NotificacionOk("El estado del cliente es ahora: " + Estado, "Actualizando estado del cliente.");
                formDeudores.MostrarClientesConDeudas();
                Close();
            }
            else
            {
                Notificacion.NotificacionError("No se pudo cambiar el estado del cliente.", "Error");
            }
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            DescripcionCategoriasDeudores();
        }

        private void DescripcionCategoriasDeudores()
        {
            //string[] categoriasDeudores = new string[6];
            //categoriasDeudores[0] = Resources.SITUACIÓN_NORMAL;
            //categoriasDeudores[1] = Resources.SEGUIMIENTO_ESPECIAL;
            //categoriasDeudores[2] = Resources.CON_PROBLEMAS;
            //categoriasDeudores[3] = Resources.ALTO_RIESGO_DE_INSOLVENCIA;
            //categoriasDeudores[4] = Resources.IRRECUPERABLE;
            //categoriasDeudores[5] = Resources.IRRECUPERABLE_POR_DISPOSICIÓN_TÉCNICA;

            //for (int i = 0; i < 6; i++)
            //{
            //    if (FormatearNombreCategoriaDeudor(cmbEstado.Text) == categoriasDeudores[i])
            //    {
            //        MessageBox.Show(categoriasDeudores[i]);
            //    }
            //}

            /*
            SITUACIÓN NORMAL
            SEGUIMIENTO ESPECIAL
            CON PROBLEMAS
            ALTO RIESGO DE INSOLVENCIA
            IRRECUPERABLE
            IRRECUPERABLE POR DISPOSICIÓN TÉCNICA
             */
        }

        private string FormatearNombreCategoriaDeudor(string nombre)
        {
            string nombreFormateado;
            char[] array = nombre.ToCharArray();
            for (int i = 0; i < nombre.Length; i++)
            {
                if (array[i] == ' ')
                {
                    array[i] = '_';
                }
            }
            nombreFormateado = array.ToString();
            return nombreFormateado;
        }
    }
}
