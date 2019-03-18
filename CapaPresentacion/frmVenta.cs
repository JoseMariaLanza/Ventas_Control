using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

using MaterialSkin;
using MaterialSkin.Controls;
using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmVenta : MetroForm
    {
        public int IdVenta;
        DataTable dtDetalles;
        public frmVenta()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void frmVenta_Load(object sender, EventArgs e)
        {
            Mostrar();
            NombreColumnas();
            OcultarColumnas();
        }

        #region INSTANCIACION
        private static frmVenta _Instancia = null;

        public static frmVenta Instancia
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

        public static frmVenta GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmVenta();
            }
            return Instancia;
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region NOTIFICACIONES
        public void NotificacionOk(string mensaje, string titulo)
        {
            iconoNotificacion.Visible = false;
            iconoNotificacion.Visible = true;
            iconoNotificacion.BalloonTipText = mensaje;
            iconoNotificacion.BalloonTipTitle = titulo;
            iconoNotificacion.Icon = SystemIcons.Information;
            iconoNotificacion.ShowBalloonTip(1000);
        }

        public void NotificacionError(string mensaje, string titulo)
        {
            iconoNotificacion.Visible = false;
            iconoNotificacion.Visible = true;
            iconoNotificacion.BalloonTipText = mensaje;
            iconoNotificacion.BalloonTipTitle = titulo;
            iconoNotificacion.Icon = SystemIcons.Error;
            iconoNotificacion.ShowBalloonTip(1000);
        }
        #endregion

        #region MOSTRAR
        private void Mostrar()
        {
            dgvListado.DataSource = NegocioVenta.Mostrar();
        }
   
        private void Limpiar()
        {
            dtpDesde.Text = DateTime.Now.ToString();
            dtpHasta.Text = DateTime.Now.ToString();
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            Limpiar();
            Mostrar();
            btnLimpiarBusqueda.Visible = false;
        }
        #endregion

        #region DATAGRIDVIEW

        #region CLICK EN CELDA - SIRVE PARA ELIMINAR
        private void dgvListado_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEliminar.Enabled = true;
                if (e.ColumnIndex == dgvListado.Columns[0].Index)
                {
                    DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region NOMBRE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns["Fecha"].HeaderText = "Fecha";
                dgvListado.Columns["TipoComprobante"].HeaderText = "Comprobante";
                dgvListado.Columns["Serie"].HeaderText = "Serie";
                dgvListado.Columns["Correlativo"].HeaderText = "Correlativo";
                dgvListado.Columns["IVA"].HeaderText = "IVA (%)";
                dgvListado.Columns["IVA"].DefaultCellStyle.Format = "#0.##";
                dgvListado.Columns["Total"].HeaderText = "Total";
                dgvListado.Columns["Total"].DefaultCellStyle.Format = "#0.##";
                dgvListado.Columns["Estado"].HeaderText = "Estado";
            }
            catch { }
        }
        #endregion

        #region OCULTAR COLUMNAS
        private void OcultarColumnas()
        {
            dgvListado.Columns["chkEliminar"].Visible = false;
            dgvListado.Columns["IdVenta"].Visible = false;
        }
        #endregion

        #endregion

        #region BUSQUEDA
        private void Buscar()
        {
            DateTime desde = new DateTime(dtpDesde.Value.Year, dtpDesde.Value.Month, dtpDesde.Value.Day, 00, 00, 00);
            DateTime hasta = new DateTime(dtpHasta.Value.Year, dtpHasta.Value.Month, dtpHasta.Value.Day, 23, 59, 59);
            /*dgvListado.DataSource = NegocioVenta.Buscar(dtpDesde.Value, dtpHasta.Value);*/ //(dtpDesde.Value.ToString("dd/MM/yyyy"), dtpHasta.Value.ToString("dd/MM/yyyy"));
            dgvListado.DataSource = NegocioVenta.Buscar(desde, hasta);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            btnLimpiarBusqueda.Visible = true;
        }
        #endregion

        #region BOTON AGREGAR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
            if (formPrincipal.CajaAbierta)//(Configuracion.IdCaja)//(Configuracion.IdApertura > 0)
            {
                frmIngresarVenta formIngresarVenta = frmIngresarVenta.GetInstancia();
                formIngresarVenta.Show();
                formIngresarVenta.BringToFront();
            }
            else
            {
                MessageBox.Show("Debe abrir una caja antes de poder empezar a vender.", "AVISO:", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        #endregion

        #region ELIMINAR VENTA
        private void chkEliminarVarios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminarVarios.Checked)
            {
                dgvListado.Columns[0].Visible = true;
                dgvListado.Select();
            }
            else
            {
                dgvListado.Columns[0].Visible = false;
                btnEliminar.Enabled = false;
                foreach (DataGridViewRow row in dgvListado.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idVenta;
            string Respuesta = "";
            DialogResult Opcion;
            try
            {
                //SELECCION DE VARIOS REGISTROS
                if (chkEliminarVarios.Checked)
                {
                    Opcion = MessageBox.Show(
                        "¿Realmente desea eliminar las ventas seleccionadas?. Tenga en cuenta que al eliminar estas ventas el stock actual de los artículos relacionados se restablecerá.",
                        "Eliminando registro. ¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvListado.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                idVenta = Convert.ToInt32(row.Cells[1].Value);
                                dtDetalles = NegocioVenta.Mostrar(idVenta);
                                Respuesta = NegocioVenta.Eliminar(idVenta, dtDetalles);
                                //foreach (DataRow det in dtDetalles.Rows)
                                //{
                                //    Respuesta = NegocioVenta.Eliminar(idVenta, dtDetalles);
                                //}
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("Los registros no se eliminaron.", "Error");
                        }
                        Mostrar();
                    }
                }
                else
                {
                    //SELECCION DE UN REGISTRO
                    Opcion = MessageBox.Show(
                        "¿Realmente desea eliminar la venta seleccionada?. Tenga en cuenta que al eliminar esta venta el stock actual de los artículos relacionados se restablecerá.",
                        "Eliminando registro. ¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.Yes)
                    {
                        idVenta = Convert.ToInt32(dgvListado.CurrentRow.Cells[1].Value);
                        dtDetalles = NegocioVenta.Mostrar(idVenta);
                        Respuesta = NegocioVenta.Eliminar(idVenta, dtDetalles);
                        //foreach (DataRow det in dtDetalles.Rows)
                        //{
                        //    Respuesta = NegocioVenta.Eliminar(idVenta, dtDetalles);
                        //}
                        if (Respuesta.Equals("OK"))
                        {
                            NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("El registro no se eliminó", "Error");
                            MessageBox.Show(Respuesta);
                        }
                        Mostrar();
                    }
                }
                chkEliminarVarios.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region BOTON SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        private void btnComprobante_Click(object sender, EventArgs e)
        {
            try
            {
                IdVenta = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdVenta"].Value);
                Informes.frmInformeFactura formInformeFactura = Informes.frmInformeFactura.GetInstancia();
                formInformeFactura.IdVenta = IdVenta;
                formInformeFactura.ShowDialog();
                formInformeFactura.BringToFront();
            }
            catch { }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime desde = new DateTime(dtpDesde.Value.Year, dtpDesde.Value.Month, dtpDesde.Value.Day, 00, 00, 00);
                DateTime hasta = new DateTime(dtpHasta.Value.Year, dtpHasta.Value.Month, dtpHasta.Value.Day, 23, 59, 59);
                Informes.frmInformeVentaArticulos formInformeVentaArticulos = Informes.frmInformeVentaArticulos.GetInstancia();
                formInformeVentaArticulos.Desde = desde;
                formInformeVentaArticulos.Hasta = hasta;
                formInformeVentaArticulos.ShowDialog();
                formInformeVentaArticulos.BringToFront();
            }
            catch { }
        }
    }
}