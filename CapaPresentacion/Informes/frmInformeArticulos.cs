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
    public partial class frmInformeArticulos : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmInformeArticulos()
        {
            InitializeComponent();
        }

        private void frmInformeArticulos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsInformes.spMostrarArticulos' Puede moverla o quitarla según sea necesario.
            this.spMostrarArticulosTableAdapter.Fill(this.dsInformes.spMostrarArticulos);
            try
            {
                // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.mostrar_producto' Puede moverla o quitarla según sea necesario.
                this.spMostrarArticulosTableAdapter.Fill(this.dsInformes.spMostrarArticulos);
                rvArticulos.LocalReport.EnableExternalImages = true;
                this.rvArticulos.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                this.rvArticulos.RefreshReport();
            }
            this.rvArticulos.RefreshReport();
        }

        #region INSTANCIACION
        private static Informes.frmInformeArticulos _Instancia = null;

        public static Informes.frmInformeArticulos Instancia
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

        public static Informes.frmInformeArticulos GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Informes.frmInformeArticulos();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmInformeArticulos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion
    }
}