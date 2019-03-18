using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Metro;
using Microsoft.Reporting.WinForms;
using System.Drawing.Printing;

namespace CapaPresentacion.Informes
{
    public partial class frmInformeAperturasCierres : MetroForm
    {
        public int IdAperturaCierre;
        public frmInformeAperturasCierres()
        {
            InitializeComponent();
        }

        private void frmInformeAperutrasCierres_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsInformes.spMostrarInformeAperturasCierres' Puede moverla o quitarla según sea necesario.
            try
            {
                this.spMostrarInformeAperturasCierresTableAdapter.Fill(this.dsInformes.spMostrarInformeAperturasCierres, IdAperturaCierre);
            }
            catch { }

            this.rvAperturasCierres.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(rptDetalles_SubreportProcessing);
            ConfigurarPagina();
            this.rvAperturasCierres.RefreshReport();
        }

        //#region INSTANCIACION
        //private static frmInformeAperturasCierres _Instancia = null;

        //public static frmInformeAperturasCierres Instancia
        //{
        //    get
        //    {
        //        return _Instancia;
        //    }

        //    set
        //    {
        //        _Instancia = value;
        //    }
        //}

        //public static frmInformeAperturasCierres GetInstancia()
        //{
        //    if (Instancia == null)
        //    {
        //        Instancia = new frmInformeAperturasCierres();
        //    }
        //    return Instancia;
        //}
        //private void frmInformeAperturasCierres_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    Instancia = null;
        //}
        //#endregion

        void rptDetalles_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (e.ReportPath == "rptDetallesAperturas")
            {
                int parIdApertura = Convert.ToInt32(e.Parameters["IdApertura"].Values[0]);
                ReportDataSource dsDetallesAperturas = new ReportDataSource("dsDetallesAperturas", ObtenerDetallesApertura(parIdApertura));
                e.DataSources.Add(dsDetallesAperturas);
            }
            else if (e.ReportPath == "rptDetallesCierres")
            {
                int parIdCierre = Convert.ToInt32(e.Parameters["IdCierre"].Values[0]);
                ReportDataSource dsDetallesCierres = new ReportDataSource("dsDetallesCierres", ObtenerDetallesCierre(parIdCierre));
                e.DataSources.Add(dsDetallesCierres);
            }
            else if (e.ReportPath == "rptCalcularGastos")
            {
                DateTime parDesde = Convert.ToDateTime(e.Parameters["parDesde"].Values[0]);
                DateTime parHasta = Convert.ToDateTime(e.Parameters["parHasta"].Values[0]);
                ReportDataSource dsCalcularGastos = new ReportDataSource("dsCalcularGastos", ObtenerGastos(parDesde, parHasta));
                e.DataSources.Add(dsCalcularGastos);
            }
        }

        private DataTable ObtenerDetallesApertura(int parIdApertura)
        {
            DataTable dtDetallesApertura = spMostrarDetallesAperturaTableAdapter.GetData(parIdApertura);
            return dtDetallesApertura;
        }

        private DataTable ObtenerDetallesCierre(int parIdCierre)
        {
            DataTable dtDetallesCierre = spMostrarDetallesCierreTableAdapter.GetData(parIdCierre);
            return dtDetallesCierre;
        }

        private DataTable ObtenerGastos(DateTime parDesde, DateTime parHasta)
        {
            DataTable dtGastos = spCalcularGastosTableAdapter.GetData(parDesde, parHasta);
            return dtGastos;
        }

        private void ConfigurarPagina()
        {
            Margins margenes = new Margins();
            margenes.Left = 0;
            margenes.Right = 0;
            margenes.Top = 0;
            margenes.Bottom = 0;

            rvAperturasCierres.SetPageSettings(new PageSettings()
            {
                Margins = margenes
            });
        }
    }
}