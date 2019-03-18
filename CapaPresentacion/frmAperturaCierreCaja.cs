using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using CapaNegocio;
//using CapaPresentacion.EstilosPresentacion;
using CapaPresentacion.Properties;
using CapaPresentacion.Modulos.Facturacion;
using CapaPresentacion.Informes;

namespace CapaPresentacion
{
    public partial class frmAperturaCierreCaja : MetroForm
    {
        #region Estilos
        //Estilos Estilo = new Estilos();
        #endregion

        int ctrlSeleccionado;
        bool EstablecerPorDefecto;

        public int IdAperturaCierre;
        public decimal MontoInicial;

        public int IdApertura;
        public int IdCaja;
        public string Caja;
        public DateTime FechaHoraApertura;
        public string FormaCobro;
        public string Estado;
        //public bool AperturaAutomatica;

        // APERTURAS PREDEFINIDAS
        int IdAperturaPredefinida;
        public bool ProgramacionApertura;
        Apertura Aperturas = new Apertura();

        frmPrincipal formPrincipal = frmPrincipal.GetInstancia();

        public frmAperturaCierreCaja()
        {
            InitializeComponent();
        }

        private void frmAperturaCierreCaja_Load(object sender, EventArgs e)
        {
            lblInfo.Text = "Seleccione un registro para mostrar la informaci�n r�pida o haga doble clic para ver m�s detalles";
            Mostrar();
            MostrarAperturasCierres();
        }

        #region INSTANCIACION
        private static frmAperturaCierreCaja _Instancia = null;

        public static frmAperturaCierreCaja Instancia
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

        public static frmAperturaCierreCaja GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmAperturaCierreCaja();
            }
            return Instancia;
        }
        private void frmAperturaCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region NOTIFICACIONES
        //ICONO DE NOTIFICACI�N
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

        #region MOSTRAR CAJAS
        private void Mostrar()
        {
            dgvCajas.DataSource = NegocioCaja.Mostrar();
            OcultarColumnasCaja();
        }
        #endregion

        #region DATAGRIDVIEW CAJA
        private void dgvCajas_Click(object sender, EventArgs e)
        {
            try
            {
                DgvCajaClic();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgvCajaClic()
        {
            IdCaja = Convert.ToInt32(dgvCajas.CurrentRow.Cells["IdCaja"].Value);
            Caja = dgvCajas.CurrentRow.Cells["Caja"].Value.ToString();
            FormaCobro = dgvCajas.CurrentRow.Cells["FormaCobro"].Value.ToString();
            Estado = dgvCajas.CurrentRow.Cells["Estado"].Value.ToString();
            //AperturaAutomatica = Convert.ToBoolean(dgvCajas.CurrentRow.Cells["AperturaAutomatica"].Value);
            foreach (DataGridViewRow row in dgvListado.Rows)
            {
                if (IdCaja == Convert.ToInt32(row.Cells["IdCaja"].Value) && row.Cells["Estado"].Value.ToString().Equals(Estado))
                {
                    row.Selected = true;
                    IdAperturaCierre = Convert.ToInt32(row.Cells["IdAperturaCierre"].Value);
                    FechaHoraApertura = Convert.ToDateTime(row.Cells["FechaHoraApertura"].Value);
                    MontoInicial = Convert.ToDecimal(row.Cells["MontoInicial"].Value);
                }
                else
                {
                    row.Selected = false;
                }
            }
        }

        #region OCULTAR COLUMNAS DATAGRIDVIEW CAJA
        private void OcultarColumnasCaja()
        {
            dgvCajas.Columns["IdCaja"].Visible = false;
        }
        #endregion

        #endregion

        #region MOSTRAR APERTURAS CIERRES
        private void MostrarAperturasCierres()
        {
            dgvListado.DataSource = NegocioAperturaCierre.Mostrar();
            NombreColumnas();
            OcultarColumnas();
        }
        #endregion

        #region DATAGRIDVIEW APERTURACIERRE
        #region NOMBRE COLUMNAS
        private void NombreColumnas()
        {
            dgvListado.Columns["FechaHoraApertura"].HeaderText = "Fecha y hora de apertura";
            dgvListado.Columns["MontoInicial"].HeaderText = "Monto inicial";
            dgvListado.Columns["FechaHoraCierre"].HeaderText = "Fecha y hora de cierre";
            dgvListado.Columns["MontoFinalSistema"].HeaderText = "Monto sistema";
            dgvListado.Columns["MontoFinalReal"].HeaderText = "Monto real";
        }
        #endregion

        #region OCULTAR COLUMNAS
        private void OcultarColumnas()
        {
            dgvListado.Columns["IdAperturaCierre"].Visible = false;
            dgvListado.Columns["IdApertura"].Visible = false;
            dgvListado.Columns["IdCierre"].Visible = false;
            dgvListado.Columns["IdCaja"].Visible = false;
        }
        #endregion

        #endregion

        private void formCierreCaja_btnInsertarClick(object sender, EventArgs e)
        {
            Mostrar();
            MostrarAperturasCierres();
        }

        #region APERTURAS CIERRES

        #region APERTURA CAJA

        #region COMPROBAR ESTADO DE CAJA EN TERMINAL
        private void ComprobarCajaAbierta()
        {
            if (formPrincipal.CajaAbierta) // antes se hizo con IdCaja > 0
            {
                MessageBox.Show("Ya hay una caja abierta en esta terminal. Para abrir una nueva caja primero debe cerrar la actual.", "AVISO:", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                IngresarApertura();
            }
        }
        #endregion

        private void IngresarApertura()
        {
            if (IdCaja < 1)
            {
                errorIcono.SetError(dgvCajas, "Seleccione una caja.");
            }
            else if (Estado.Equals("ABIERTA"))
            {
                MessageBox.Show("Esta caja ya se encuentra abierta. Seleccione otra caja de la lista.", "No puede realizar esta operaci�n.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                ctrlSeleccionado = 0;
                frmAperturaCaja formAperturaCaja = frmAperturaCaja.GetInstancia();
                formAperturaCaja.IdApertura = IdApertura;
                formAperturaCaja.IdCaja = IdCaja;
                formAperturaCaja.FormaCobro = FormaCobro;
                formAperturaCaja.Estado = Estado;
                //formAperturaCaja.AperturaAutomatica = AperturaAutomatica;
                formAperturaCaja.btnInsertar.Click += new EventHandler(formCierreCaja_btnInsertarClick);
                formAperturaCaja.ShowDialog();
            }
        }
        
        private void btnIngresarAperturaCaja_Click(object sender, EventArgs e)
        {
            ComprobarCajaAbierta();
        }
        #endregion

        #region CIERRE CAJA

        #region COMPROBAR ID DE CAJA ABIERTA EN TERMINAL
        private void ComprobarIdCaja()
        {
            if (IdCaja != formPrincipal.IdCaja)
            {
                MessageBox.Show("No puede cerrar una caja de otra terminal", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                IngresarCierre();
            }
        }
        #endregion

        private void IngresarCierre()
        {
            if (IdCaja < 1)
            {
                errorIcono.SetError(dgvCajas, "Seleccione una caja o un registro de apertura.");
                errorIcono.SetError(dgvListado, "Seleccione una caja o un registro de apertura.");
            }
            else if (Estado.Equals("CERRADA"))
            {
                MessageBox.Show("Esta caja ya se encuentra cerrada. Seleccione otra caja o registro de apertura de una las listas.", 
                    "No puede realizar esta operaci�n.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmCierreCaja formCierreCaja = frmCierreCaja.GetInstancia();
                formCierreCaja.IdAperturaCierre = IdAperturaCierre;
                formCierreCaja.IdCaja = IdCaja;
                formCierreCaja.FormaCobro = FormaCobro;
                formCierreCaja.Estado = Estado;
                formCierreCaja.FechaHoraApertura = FechaHoraApertura;
                formCierreCaja.MontoInicial = MontoInicial;
                formCierreCaja.btnInsertar.Click += new EventHandler(formCierreCaja_btnInsertarClick);
                formCierreCaja.ShowDialog();
            }
        }
        private void btnIngresarCierreCaja_Click(object sender, EventArgs e)
        {
            ComprobarIdCaja();
        }
        #endregion
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListado_Click(object sender, EventArgs e)
        {
            try
            {
                DgvListadoClick();
            }
            catch { }
        }

        private void DgvListadoClick()
        {
            IdAperturaCierre = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdAperturaCierre"].Value);
            IdCaja = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCaja"].Value);
            Caja = dgvListado.CurrentRow.Cells["Caja"].Value.ToString();
            FechaHoraApertura = Convert.ToDateTime(dgvListado.CurrentRow.Cells["FechaHoraApertura"].Value);
            MontoInicial = Convert.ToDecimal(dgvListado.CurrentRow.Cells["MontoInicial"].Value);
            Estado = dgvListado.CurrentRow.Cells["Estado"].Value.ToString();
            //FormaCobro = dgvCajas.CurrentRow.Cells["FormaCobro"].Value.ToString();
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //Estilo.tableLayoutPanel1_CellPaint(sender, e);
        }
        
        #region APERTURAS PREDEFINIDAS
        private void ProgramarAperturaPredefinida()
        {
            ProgramacionApertura = true;
            frmAperturaCaja formAperturaCaja = frmAperturaCaja.GetInstancia();
            //formAperturaCaja.IdApertura = IdApertura;
            formAperturaCaja.IdCaja = IdCaja;
            formAperturaCaja.FormaCobro = FormaCobro;
            formAperturaCaja.ProgramacionApertura = ProgramacionApertura;
            //formAperturaCaja.Estado = Estado;
            //formAperturaCaja.AperturaAutomatica = AperturaAutomatica;
            formAperturaCaja.btnInsertar.Click += new EventHandler(formCierreCaja_btnInsertarClick);
            formAperturaCaja.ShowDialog();
        }

        private void btnProgramarApertura_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            ProgramarAperturaPredefinida();
        }

        private void tpAperturasPredefinidas_Click(object sender, EventArgs e)
        {
            dgvListadoAperturasPredefinidas.DataSource = NegocioApertura.MostrarAperturasPredefinidas();//Aperturas.LlenarAperturaPredefinida();
            Aperturas.dgvAperturasPredefinidas(dgvListadoAperturasPredefinidas);
        }

        private void dgvListadoAperturasPredefinidas_Click(object sender, EventArgs e)
        {
            try
            {
                IdCaja = Convert.ToInt32(dgvListadoAperturasPredefinidas.CurrentRow.Cells["IdCaja"].Value);
                IdAperturaPredefinida = Convert.ToInt32(dgvListadoAperturasPredefinidas.CurrentRow.Cells["IdAperturaPredefinida"].Value);
                if (formPrincipal.IdAperturaPredefinida == IdApertura)
                {
                    EstablecerPorDefecto = true;
                }
                else
                {
                    EstablecerPorDefecto = false;
                }
            }
            catch { }
        }

        private void dgvListadoAperturasPredefinidas_DoubleClick(object sender, EventArgs e)
        {
            ProgramacionApertura = true;
            frmAperturaCaja formAperturaCaja = frmAperturaCaja.GetInstancia();
            formAperturaCaja.ProgramacionApertura = ProgramacionApertura;
            formAperturaCaja.ctrlSeleccionado = 2;
            formAperturaCaja.IdApertura = IdAperturaPredefinida;
            formAperturaCaja.IdCaja = IdCaja;
            formAperturaCaja.FormaCobro = FormaCobro;
            formAperturaCaja.EstablecerPorDefecto = EstablecerPorDefecto;
            //formAperturaCaja.CrearDetalleApertura(Aperturas.LlenarDetallesAperturasPredefinidas(IdApertura));
            //formAperturaCaja.dgvListado.DataSource = Aperturas.LlenarDetallesAperturasPredefinidas(IdApertura);
            formAperturaCaja.ShowDialog();
            formAperturaCaja.BringToFront();
        }
        #endregion

        private void btnProgramarApertura_Click_1(object sender, EventArgs e)
        {
            if (IdAperturaPredefinida < 1)
            {
                MessageBox.Show("Seleccione una apertura predefinida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                frmFechaHora formFechaHora = frmFechaHora.GetInstancia();
                formFechaHora.IdCaja = IdCaja;
                formFechaHora.IdAperturaPredefinida = IdAperturaPredefinida;
                formFechaHora.ShowDialog();
                formFechaHora.BringToFront();
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CargarInforme();
        }

        private void CargarInforme()
        {
            frmInformeAperturasCierres formInformeAperturasCierres = new frmInformeAperturasCierres();//.GetInstancia();
            formInformeAperturasCierres.IdAperturaCierre = IdAperturaCierre;
            formInformeAperturasCierres.Show();
            formInformeAperturasCierres.BringToFront();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            CargarInforme();
        }
    }
}