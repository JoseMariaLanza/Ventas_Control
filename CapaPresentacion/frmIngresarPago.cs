using CapaNegocio;
using CapaPresentacion.Modulos.Notificaciones;
using CapaPresentacion.Scripts.Formateo;
using CapaPresentacion.Teclado;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmIngresarPago : MaterialForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();

        Formatear Formatear = new Formatear();
        DataTable dtDetallesDeuda;

        int IdDetalleDeuda;
        public int IdDeuda;
        public int IdCliente;
        public string Cliente;
        decimal Monto;
        int NumeroPago;
        public string Descripcion;
        public bool Pagado;
        Notificaciones Notificacion = new Notificaciones();

        public frmIngresarPago()
        {
            InitializeComponent();
        }

        private void frmIngresarPago_Load(object sender, EventArgs e)
        {
            CrearEstructuraDataTableDetallesDeuda();
            Mostrar();
        }

        #region INSTANCIACION
        private static frmIngresarPago _Instancia;

        public static frmIngresarPago Instancia
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

        public static frmIngresarPago GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarPago();
            }
            return Instancia;
        }
        private void frmIngresarPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region MOSTRAR

        private void CrearEstructuraDataTableDetallesDeuda()
        {
            dtDetallesDeuda = new DataTable("DetallesDeuda");
            dtDetallesDeuda.Columns.Add("IdDetalleDeuda", Type.GetType("System.Int32"));
            dtDetallesDeuda.Columns.Add("IdDeuda", Type.GetType("System.Int32"));
            dtDetallesDeuda.Columns.Add("NumeroPago", Type.GetType("System.Int32"));
            dtDetallesDeuda.Columns.Add("Monto", Type.GetType("System.Decimal"));
            dtDetallesDeuda.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
            dtDetallesDeuda.Columns.Add("Pagado", Type.GetType("System.Boolean"));
        }
        private void Mostrar()
        {
            dtDetallesDeuda = NegocioDetalleDeuda.Mostrar(IdDeuda);
            dgvListado.DataSource = dtDetallesDeuda; //NegocioDetalleDeuda.Mostrar(IdDeuda);
            //FormatearColumnas();
            NombresColumnas();
            OcultarColumnas();
            txtCliente.Text = Cliente;
            txtDescripcion.Text = Descripcion;
        }

        private void Mostrar(DataGridView listadoDetalles)
        {
            txtIdDetalleDeuda.Text = IdDetalleDeuda.ToString();
            txtNumeroPago.Text = NumeroPago.ToString();
            txtMonto.Text = Monto.ToString("$0#.0#", CultureInfo.InvariantCulture);
            txtDescripcion.Text = Descripcion;
            txtEstado.Text = EstadoCuota();
        }

        //private void NombresColumnas()
        //{
        //    string[] nombres = { "IdDetalleDeuda", "IdDeuda", "Cuota", "Monto", "Fecha de pago", "Estado" };
        //    Formatear.NombreColumnas(dgvListado, nombres);
        //}

        //private void OcultarColumnas()
        //{
        //    string[] nombres = { "IdDetalleDeuda", "IdDeuda" };
        //    Formatear.OcultarColumnas(dgvListado, nombres);
        //}

        private void NombresColumnas()
        {
            dgvListado.Columns["NumeroPago"].HeaderText = "Cuota";
            dgvListado.Columns["FechaPago"].HeaderText = "Fecha de pago";
        }

        private void OcultarColumnas()
        {
            dgvListado.Columns["Pagado"].Visible = false;
            dgvListado.Columns["IdDetalleDeuda"].Visible = false;
            dgvListado.Columns["IdDeuda"].Visible = false;
            dgvListado.Columns["Pagado"].Visible = false;
        }

        //private void FormatearColumnas()
        //{
        //    DataTable dtFormatear = Formatear.CrearDtFormatear();
        //    DataRow row = dtFormatear.NewRow();
        //    row
        //    Formatear.FormatearDataGridView(dgvListado, dtFormatear);
        //    //ColumnasMoneda();
        //}

        //private void ColumnasMoneda()
        //{
        //    string[] campos = { "Monto" };
        //    Formatear.FormatearAMoneda(dgvListado, campos);
        //}

        private string EstadoCuota()
        {
            string estado;
            return estado = (Pagado == true) ? "PAGADA" : "PENDIENTE";
        }

        private void dgvListado_Click(object sender, EventArgs e)
        {
            try
            {
                AsignacionDeValoresAVariablesGlobales();
                HabilitarPagoCuota(ObtenerIndiceFilaSeleccionada());
            }
            catch { }
        }

        private int ObtenerIndiceFilaSeleccionada()
        {
            return dgvListado.CurrentRow.Index;
        }

        #endregion

        #region HABILITAR
        public void HabilitarControles(bool habilitar)
        {
            //txtMonto.Enabled = habilitar;
            //txtDescripcion.Enabled = habilitar;
            btnInsertar.Enabled = habilitar;
        }

        private void HabilitarPagoCuota(int indiceFila)
        {
            if (!Pagado && (NumeroPago - 1 == Convert.ToInt32(dgvListado.Rows[indiceFila - 1].Cells["NumeroPago"].Value)) && Convert.ToBoolean(dgvListado.Rows[indiceFila - 1].Cells["Pagado"].Value) == true)
                HabilitarControles(true);
            else
                HabilitarControles(false);
        }
        #endregion

        #region ASIGNACION DE VALORES A VARIABLES GLOBALES
        private void AsignacionDeValoresAVariablesGlobales()
        {
            IdDetalleDeuda = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdDetalleDeuda"].Value);
            Monto = Formatear.DevolverDecimal(dgvListado.CurrentRow.Cells["Monto"].Value.ToString(), "Moneda");
            //Monto = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Monto"].Value);
            NumeroPago = Convert.ToInt32(dgvListado.CurrentRow.Cells["NumeroPago"].Value);
            Pagado = Convert.ToBoolean(dgvListado.CurrentRow.Cells["Pagado"].Value);
            Mostrar(dgvListado);
        }
        #endregion

        #region INGRESAR PAGO
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                Insertar();
                Mostrar();
                ActualizarEstadoDeuda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió una excepción, tome una captura de pantalla y contacte con el administrador del sistema. Mensaje para el administrador: "
                    + ex.Message + " Traza: " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ActualizarEstadoDeuda()
        {
            if (ComprobarDeudaSaldada())
            {
                CancelarDeuda();
            }
            else
            {
                ActualizarMontoPagado();
            }
        }

        private bool ComprobarDeudaSaldada()
        {
            bool deudaSaldada = false;
            foreach (DataRow row in dtDetallesDeuda.Rows)
            {
                if (Convert.ToBoolean(row["Pagado"]))
                {
                    deudaSaldada = true;
                }
                else
                {
                    deudaSaldada = false;
                    break;
                }
            }
            return deudaSaldada;
        }

        private void CancelarDeuda()
        {
            string respuesta = "";
            respuesta = NegocioDeuda.Editar(IdDeuda, MontoCancelacion(), "PAGADA", IdCliente, DefinirEstado()); // HACER MÉTODO PARA SABER SI EL CLIENTE TIENE OTRAS DEUDAS. si registra más deudas;
            // el estado será REGISTRA DEUDAS. En el caso que esté clasificado como MOROSO el estado cambiará a REGISTRA DEUDAS. Hacer también método para cambiar
            // el estado manualmente
            if (respuesta.Equals("OK"))
            {
                Notificacion.NotificacionOk("Deuda cancelada exitosamente.", "Cancelando deuda");
            }
            else
            {
                Notificacion.NotificacionError("No se pudo cancelar la deuda.", "Error");
            }
        }

        private decimal MontoCancelacion()
        {
            decimal totalCancelacion = 0;
            foreach (DataRow row in dtDetallesDeuda.Rows)
            {
                totalCancelacion += Convert.ToDecimal(row["Monto"]);
            }
            return totalCancelacion;
        }

        private string DefinirEstado()
        {
            int cantidadDeudas = 0;
            DataTable deudores = NegocioDeuda.Mostrar();
            foreach (DataRow row in deudores.Rows)
            {
                if (IdDeuda != Convert.ToInt32(row["IdDeuda"]) && IdCliente == Convert.ToInt32(row["IdCliente"]))
                {
                    cantidadDeudas++;
                }
            }
            return CategorizarEstado(cantidadDeudas);
        }

        private string CategorizarEstado(int cantidadDeudas)
        {
            string clasificacion;
            switch (cantidadDeudas)
            {
                case 0:
                    clasificacion = "NO REGISTRA DEUDAS";
                    break;
                case 1:
                    clasificacion = "REGISTRA " + cantidadDeudas + "DEUDA";
                    break;
                default:
                    clasificacion = "REGISTRA " + cantidadDeudas + "DEUDAS";
                    break;
            }
            return clasificacion;
        }

        private void ActualizarMontoPagado()
        {
            string respuesta = "";
            respuesta = NegocioDeuda.Editar(IdDeuda, CalcularMontoPagado(), "PENDIENTE");
            if (respuesta.Equals("OK"))
            {
                Notificacion.NotificacionOk("Deuda actualizada exitosamente.", "Actualizando deuda");
            }
            else
            {
                Notificacion.NotificacionError("No se pudo actualizar la deuda.", "Actualizando deuda");
            }
        }

        private decimal CalcularMontoPagado()
        {
            decimal totalPagado = 0;
            foreach (DataRow row in dtDetallesDeuda.Rows)
            {
                if (Convert.ToBoolean(row["Pagado"]))
                {
                    totalPagado += Convert.ToDecimal(row["Monto"]);
                }
            }
            return totalPagado;
        }

        private void Insertar()
        {
            if (ComprobarCamposObligatorios())
            {
                string respuesta;
                //Monto = Convert.ToDecimal(txtMonto.Text);
                DataRow pago = CrearDataTableConFilaUnica().NewRow();
                pago["IdDetalleDeuda"] = IdDetalleDeuda;
                pago["NumeroPago"] = NumeroPago;
                pago["Monto"] = Monto;
                pago["FechaPago"] = DateTime.Now;
                respuesta = NegocioDeuda.AgregarPago(pago);
                if (respuesta.Equals("OK"))
                {
                    Notificacion.NotificacionOk("El pago se registró correctamente", "Guardando pago");
                }
                else
                {
                    Notificacion.NotificacionError("Error al intentar registrar el pago", "Error");
                    MessageBox.Show(respuesta, "Error");
                }
                Mostrar();
            }
            // LLAMAR MÉTODO PARA MODIFICAR ESTADO DE DEUDA Y ESTADO DEL CLIENTE
        }

        //private bool ComprobarEstadoDeDeuda()
        //{
        //    bool pagado = true;
        //    foreach (DataGridViewRow row in dgvListado.Rows)
        //    {
        //        if (!Convert.ToBoolean(row.Cells["Pagado"]))
        //        {
        //            pagado = false;
        //            break;
        //        }
        //    }
        //    return pagado;
        //}

        private DataTable CrearDataTableConFilaUnica()
        {
            DataTable pago = new DataTable();
            pago.Columns.Add("IdDetalleDeuda", Type.GetType("System.Int32"));
            pago.Columns.Add("NumeroPago", Type.GetType("System.Int32"));
            pago.Columns.Add("Monto", Type.GetType("System.Decimal"));
            pago.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
            return pago;
        }

        private bool ComprobarCamposObligatorios()
        {
            bool proceder = false;
            if (txtMonto.Text == string.Empty || Monto == 0)
            {
                errorIcono.SetError(txtMonto, "Ingrese el monto a pagar.");
                txtMonto.SelectAll();
                proceder = false;
            }
            else if (txtNumeroPago.Text == string.Empty)
            {
                errorIcono.SetError(txtNumeroPago, "Seleccione la cuota a pagar.");
                proceder = false;
            }
            else
            {
                proceder = true;
            }
            return proceder;
        }
        #endregion



        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (controlTeclado.DireccionarEventoDeControl(sender, e))
            {
                btnInsertar.Focus();
            }
        }

        private void frmIngresarPago_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void dgvListado_KeyUp(object sender, KeyEventArgs e)
        {
            AsignacionDeValoresAVariablesGlobales();
        }
    }
}
