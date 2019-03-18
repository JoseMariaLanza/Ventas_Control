using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaNegocio;
using System.Windows.Forms;
using CapaPresentacion.Properties;

namespace CapaPresentacion.Modulos.Facturacion
{
    class Apertura
    {
        #region APERTURAS PREDEFINIDAS
        public DataTable dtAperturasPredefinidas;
        public DataTable dtDetallesAperturaPredefinida;

        public void CrearAperturasPredefinidas()
        {
            dtAperturasPredefinidas = new DataTable("AperturasPredefinidas");
            dtAperturasPredefinidas.Columns.Add("IdAperturaPredefinida", Type.GetType("System.Int32"));
            //dtAperturasPredefinidas.Columns.Add("IdApertura", Type.GetType("System.Int32"));
            dtAperturasPredefinidas.Columns.Add("IdCaja", Type.GetType("System.Int32"));
            dtAperturasPredefinidas.Columns.Add("IdEmpleado", Type.GetType("System.Int32"));
            dtAperturasPredefinidas.Columns.Add("FechaHora", Type.GetType("System.DateTime"));
            dtAperturasPredefinidas.Columns.Add("MontoInicial", Type.GetType("System.Decimal"));
            dtAperturasPredefinidas.Columns.Add("Descripcion", Type.GetType("System.String"));
        }

        public void dgvAperturasPredefinidas(object sender)
        {
            DataGridView dgvAperturasPredefinidas = (DataGridView)sender;
            dgvAperturasPredefinidas.Columns["IdAperturaPredefinida"].Visible = false;
            dgvAperturasPredefinidas.Columns["IdCaja"].Visible = false;
            dgvAperturasPredefinidas.Columns["IdEmpleado"].Visible = false;
            dgvAperturasPredefinidas.Columns["FechaHora"].HeaderText = "Fecha-Hora apertura";
            dgvAperturasPredefinidas.Columns["MontoInicial"].HeaderText = "Monto";
            dgvAperturasPredefinidas.Columns["MontoInicial"].DefaultCellStyle.Format = "$#0.#0";
            dgvAperturasPredefinidas.Columns["Descripcion"].HeaderText = "Descripción";
        }

        public void CrearDetallesAperturaPredefinida()
        {
            dtDetallesAperturaPredefinida = new DataTable("DetallesAperturaPredefinida");
            dtDetallesAperturaPredefinida.Columns.Add("IdDetalleAperturaPredefinida", Type.GetType("System.Int32"));
            dtDetallesAperturaPredefinida.Columns.Add("IdAperturaPredefinida", Type.GetType("System.Int32"));
            dtDetallesAperturaPredefinida.Columns.Add("Moneda", Type.GetType("System.String"));
            dtDetallesAperturaPredefinida.Columns.Add("Denominacion", Type.GetType("System.String"));
            dtDetallesAperturaPredefinida.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            dtDetallesAperturaPredefinida.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
        }

        public void dgvDetallesAperturasPredefinidas(object sender)
        {
            DataGridView dgvDetallesAperturasPredefinidas = (DataGridView)sender;
            dgvDetallesAperturasPredefinidas.Columns["IdDetalleAperturaPredefinida"].Visible = false;
            dgvDetallesAperturasPredefinidas.Columns["IdAperturaPredefinida"].Visible = false;
            dgvDetallesAperturasPredefinidas.Columns["Denominacion"].HeaderText = "Denominación";
            dgvDetallesAperturasPredefinidas.Columns["Subtotal"].DefaultCellStyle.Format = "$#0.#0";
        }

        public DataTable LlenarAperturaPredefinida()
        {
            CrearAperturasPredefinidas();
            return dtAperturasPredefinidas = NegocioApertura.MostrarAperturasPredefinidas();
        }

        public DataTable LlenarAperturaPredefinida(int idAperturaPredefinida)
        {
            CrearAperturasPredefinidas();
            return dtAperturasPredefinidas = NegocioApertura.BuscarAperturaPredefinida(idAperturaPredefinida);
        }

        public DataTable LlenarDetallesAperturasPredefinidas(int idAperturaPredefinida)
        {
            CrearDetallesAperturaPredefinida();
            return dtDetallesAperturaPredefinida = NegocioDetalleApertura.MostrarDetallesAperturaPredefinida(idAperturaPredefinida);
        }
        #endregion

        #region ADMINISTRACION DE APERTURAS

        #region COMPROBAR APERTURA PENDIENTE

        //frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
        public void ComprobarAperturaPendiente(Settings Configuracion, DateTime fechaHoraApertura)
        {
            if (Configuracion.AbrirCaja)
            {
                CargarAperturaPredefinida(Configuracion.IdAperturaPredefinida);
                if (dtAperturasPredefinidas.Rows.Count == 1)
                {
                    //MessageBox.Show("Apertura cargada con éxito");
                    frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
                    frmCierreCaja formCierreCaja = frmCierreCaja.GetInstancia();
                    DialogResult opcion;
                    if (formPrincipal.CajaAbierta && DateTime.Now.Day - fechaHoraApertura.Date.Day >= 1)// - formPrincipal.FechaHoraApertura.Date.Day >= 1)
                    {
                        MessageBox.Show("La caja está abierta. Debe cerrarla para poder llevar un mejor control de las estadísticas de venta.",
                            "NO SE PUEDE CONTINUAR CON LA APERTURA AUTOMÁTICA", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        formPrincipal.AdministrarCierreCaja = true;
                        formPrincipal.ForzarCierreCaja(formCierreCaja);
                        opcion = MessageBox.Show("Hay una apertura programada para el día " + Convert.ToDateTime(Configuracion.FechaHoraApertura).ToLongDateString() + " a las " + Convert.ToDateTime(Configuracion.FechaHoraApertura).ToLongTimeString() + ". ¿Desea cancelarla?."
                            , "CANCELANDO APERTURA AUTOMÁTICA.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (opcion == DialogResult.Yes)
                        {
                            formPrincipal.CancelarAperturaAutomatica();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error al cargar la apertura.");
                }
            }
        }
        #endregion

        #region CARGA DE APERTURA PREDEFINIDA
        private void CargarAperturaPredefinida(int idAperturaPredefinida)
        {
            LlenarAperturaPredefinida(idAperturaPredefinida);
            LlenarDetallesAperturasPredefinidas(idAperturaPredefinida);
        }
        #endregion
        #endregion
    }
}