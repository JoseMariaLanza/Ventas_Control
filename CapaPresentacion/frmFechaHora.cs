using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaPresentacion.Properties;

namespace CapaPresentacion
{
    public partial class frmFechaHora : DevComponents.DotNetBar.Metro.MetroForm
    {
        //Settings Configuracion = new Settings();
        public int IdCaja;
        public int IdAperturaPredefinida;
        bool EstablecerPorDefecto;

        public frmFechaHora()
        {
            InitializeComponent();
            dtpFechaHoraApertura.Format = DateTimePickerFormat.Custom;
            dtpFechaHoraApertura.CustomFormat = "dd/MM/yyyy HH:mm:ss";
        }

        private void frmFechaHora_Load(object sender, EventArgs e)
        {
            EstablecerFechaAperturaValida();
        }

        #region INSTANCIACION
        private static frmFechaHora _Instancia = null;

        public static frmFechaHora Instancia
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

        public static frmFechaHora GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmFechaHora();
            }
            return Instancia;
        }
        private void frmFechaHora_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show(
                "La apertura se configurar� para el d�a " + dtpFechaHoraApertura.Value.ToLongDateString() + " a las " + dtpFechaHoraApertura.Value.ToLongTimeString() + " hs. �Est� seguro que desea proceder con esta configuraci�n?", 
                "CONFIGURANDO APERTURA AUTOM�TICA", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (opcion == DialogResult.Yes)
            {
                frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
                formPrincipal.IdCaja = IdCaja;
                formPrincipal.IdAperturaPredefinida = IdAperturaPredefinida;
                formPrincipal.FechaHoraApertura = dtpFechaHoraApertura.Value;
                formPrincipal.AbrirCaja = true;
                formPrincipal.AbrirCajaSiempre = EstablecerPorDefecto;
                formPrincipal.GuardarConfiguracion();
                Close();
            }
            //Configuracion.Save(); //////// IMPORTANTE USAR LAS VARIABLES DEL SISTEMA EN EL FORMULARIO PRINCIPAL; LUEGO GUARDAR EL VALOR DE ESTAS EN
            /////// LAS CONFIGURACIONES PARA PODER TRABAJAR CON UNA �NICA INSTANCIA; DE OTRA MANERA NO SE PUEDE YA QUE Settings ES UNA CLASE NO ACCESIBLE P�BLICAMENTE
        }

        private void chkAperturaPorDefecto_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAperturaPorDefecto.Checked)
            {
                EstablecerPorDefecto = true;
            }
            else
            {
                EstablecerPorDefecto = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dtpFechaHoraApertura_ValueChanged(object sender, EventArgs e)
        {
            EstablecerFechaAperturaValida();
        }

        private void EstablecerFechaAperturaValida()
        {
            if (dtpFechaHoraApertura.Value.Day <= DateTime.Now.Day)
            {
                dtpFechaHoraApertura.Value = DateTime.Now.AddDays(1);
            }
        }
    }
}