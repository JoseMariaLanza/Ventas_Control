using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using Microsoft.Reporting.WinForms;

namespace CapaPresentacion.Informes
{
    public partial class frmInformeFactura : DevComponents.DotNetBar.Metro.MetroForm
    {
        private int _IdVenta;

        public int IdVenta
        {
            get
            {
                return _IdVenta;
            }

            set
            {
                _IdVenta = value;
            }
        }

        public frmInformeFactura()
        {
            InitializeComponent();
        }

        private void frmInformeFactura_Load(object sender, EventArgs e)
        {
            try
            {
                //frmVenta formVenta = frmVenta.GetInstancia();
                //IdVenta = formVenta.IdVenta;
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spreporte_factura' Puede moverla o quitarla según sea necesario.
                this.spFacturaTableAdapter.Fill(this.dsInformes.spFactura, IdVenta);
                this.rvFactura.RefreshReport();
            }
            catch
            {
                this.rvFactura.RefreshReport();
            }
        }

        #region INSTANCIACION
        private static Informes.frmInformeFactura _Instancia = null;

        public static Informes.frmInformeFactura Instancia
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

        public static Informes.frmInformeFactura GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Informes.frmInformeFactura();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmInformeFactura_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion
    }
}