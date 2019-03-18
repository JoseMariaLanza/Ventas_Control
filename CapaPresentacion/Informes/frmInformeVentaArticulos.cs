using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Informes
{
    public partial class frmInformeVentaArticulos : MetroForm
    {
        public DateTime Desde = DateTime.Now;
        public DateTime Hasta = DateTime.Now;
        public frmInformeVentaArticulos()
        {
            InitializeComponent();
        }

        private void frmInformeVentaArticulos_Load(object sender, EventArgs e)
        {
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsInformes.spArticulosVendidos' Puede moverla o quitarla según sea necesario.
                this.spArticulosVendidosTableAdapter.Fill(this.dsInformes.spArticulosVendidos, Desde, Hasta);
                rvVentaArticulos.LocalReport.EnableExternalImages = true;
                this.rvVentaArticulos.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                this.rvVentaArticulos.RefreshReport();
            }
            ConfigurarPagina();
            this.rvVentaArticulos.RefreshReport();
        }

        #region INSTANCIACION
        private static Informes.frmInformeVentaArticulos _Instancia = null;

        public static Informes.frmInformeVentaArticulos Instancia
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

        public static Informes.frmInformeVentaArticulos GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Informes.frmInformeVentaArticulos();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmInformeVentaArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void ConfigurarPagina()
        {
            Margins margenes = new Margins();
            margenes.Left = 0;
            margenes.Right = 0;
            margenes.Top = 0;
            margenes.Bottom = 0;

            rvVentaArticulos.SetPageSettings(new PageSettings()
            {
                Margins = margenes
            });
        }
    }
}
