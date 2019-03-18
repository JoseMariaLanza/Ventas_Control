using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CapaNegocio;
using System.Globalization;
using MaterialSkin.Controls;
using CapaPresentacion.Validacion;
using CapaPresentacion.Properties;

namespace CapaPresentacion
{
    public partial class frmCierreCaja : DevComponents.DotNetBar.Metro.MetroForm
    {
        Settings Configuracion = new Settings();
        Validacion.Validacion Validar = new Validacion.Validacion();
        public int ctrlSeleccionado = 0;
        public int IdEmpleado;
        public string Empleado;
        public int IdCaja;
        public string FormaCobro;
        public string Estado;
        public DateTime FechaHoraApertura;
        public decimal MontoInicial = 0.00m;
        
        public int IdCierre;
        public DateTime FechaHoraCierre;
        string Moneda;
        string Denominacion;
        int Cantidad;
        decimal Subtotal = 0.00m;
        decimal MontoFinalSistema = 0.00m;
        decimal MontoFinalReal = 0.00m;

        public int IdAperturaCierre;
        public decimal Diferencia;

        DataTable dtDetalleCierre;


        frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
        public frmCierreCaja()
        {
            InitializeComponent();
            dtpFechaHoraCierre.Format = DateTimePickerFormat.Custom;
            dtpFechaHoraCierre.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpFechaHoraCierre.Enabled = false;
        }

        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            ObtenerCajero();
            HabilitarBotones();
            ListaCajas();
            cmbCaja.SelectedValue = IdCaja;
            cmbMoneda.SelectedIndex = 0;
            cmbDenominacion.SelectedIndex = 7;
            if (ctrlSeleccionado == 2)
            {
                Mostrar();
            }
            else
            {
                CrearDetalleCierre();
            }
            FechaHoraCierre = DateTime.Now; // Por ahora; Después se pondrá en ctrlSeleccionado == 2 nuevamente cuando esté finalizado el formulario de detalles de aperturas/cierres
            CalcularVentas();
        }

        #region INSTANCIACION
        private static frmCierreCaja _Instancia = null;

        public static frmCierreCaja Instancia
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

        public static frmCierreCaja GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmCierreCaja();
            }
            return Instancia;
        }
        private void frmCierreCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region NOTIFICACIONES
        //ICONO DE NOTIFICACIÓN
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

        #region OBTENER EMPLEADO
        private void ObtenerCajero()
        {
            frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
            IdEmpleado = formPrincipal.IdEmpleado;
            txtEmpleado.Text = formPrincipal.Apellido + ", " + formPrincipal.Nombre;

        }
        #endregion

        #region OBTENER DETALLES CAJA
        private void DetallesCaja()
        {

        }
        #endregion

        #region MOSTRAR
        private void Mostrar()
        {
            CrearDetalleCierre();
            dtDetalleCierre = NegocioCierre.Mostrar(IdCierre);
            dgvListado.DataSource = dtDetalleCierre;
            NombreColumnas();
            OcultarColumnas();
        }

        private void CalcularVentas()
        {
            try
            {
                DataTable dtTotalVentas = new DataTable("TotalVentas");
                dtTotalVentas = NegocioVenta.CalcularVentas(FechaHoraApertura, FechaHoraCierre);
                DataRow row = dtTotalVentas.Rows[0];
                MontoFinalSistema = Convert.ToDecimal(row[0]);
                txtMontoFinalSistema.Text = MontoFinalSistema.ToString("$#0.#0", CultureInfo.InvariantCulture);
            }
            catch { }
        }

        #region LLENADO DE COMBOBOX CAJAS
        private void ListaCajas()
        {
            cmbCaja.DataSource = NegocioCaja.Mostrar();
            cmbCaja.ValueMember = "IdCaja";
            cmbCaja.DisplayMember = "Caja";
            cmbCaja.SelectedValue = 0;
        }
        #endregion

        #region CREACION DE DATATABLE dtDetalleApertura
        public void CrearDetalleCierre()
        {
            dtDetalleCierre = new DataTable("DetallesCierre");
            dtDetalleCierre.Columns.Add("IdDetalleCierre", Type.GetType("System.Int32"));
            dtDetalleCierre.Columns.Add("IdCierre", Type.GetType("System.Int32"));
            dtDetalleCierre.Columns.Add("Moneda", Type.GetType("System.String"));
            dtDetalleCierre.Columns.Add("Denominacion", Type.GetType("System.String"));
            dtDetalleCierre.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            dtDetalleCierre.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
            dgvListado.DataSource = dtDetalleCierre;
            NombreColumnas();
            OcultarColumnas();
        }

        public void CrearDetalleCierre(DataTable dtDetalleCierre)
        {
            dtDetalleCierre = new DataTable("DetallesCierre");
            dtDetalleCierre.Columns.Add("IdDetalleCierre", Type.GetType("System.Int32"));
            dtDetalleCierre.Columns.Add("IdCierre", Type.GetType("System.Int32"));
            dtDetalleCierre.Columns.Add("Moneda", Type.GetType("System.String"));
            dtDetalleCierre.Columns.Add("Denominacion", Type.GetType("System.String"));
            dtDetalleCierre.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            dtDetalleCierre.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
            dgvListado.DataSource = dtDetalleCierre;
            NombreColumnas();
            OcultarColumnas();
        }

        private void NombreColumnas()
        {
            dgvListado.Columns["Denominacion"].HeaderText = "Denominación";
        }

        private void OcultarColumnas()
        {
            dgvListado.Columns["IdDetalleCierre"].Visible = false;
            dgvListado.Columns["IdCierre"].Visible = false;
        }
        #endregion

        #region BOTONES Y FUNCIONALIDAD
        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            cmbCaja.SelectedIndex = IdCaja;
            dtDetalleCierre.Clear();
            cmbFormaCobro.SelectedIndex = 0;
            cmbMoneda.SelectedIndex = 0;
            cmbDenominacion.SelectedIndex = 7;
            VerificarRegistros();
        }

        #region HABILITAR

        //HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            btnIngresar.Enabled = !valor;
            dgvListado.Enabled = !valor;
            btnEliminar.Enabled = !valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(false);
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = false;
                    cmbFormaCobro.Text = FormaCobro;
                    txtEstado.Text = Estado;
                    //IdCaja = Convert.ToInt32(txtIdCaja.Text);
                    //Caja = txtCaja.Text;
                    //IdCategoria = cmbCategoria.SelectedIndex;
                    //lblCaja.Text = "Nueva Caja";
                    //txtCaja.SelectAll();
                    break;
                case 1: //EDITAR
                    Habilitar(false);
                    btnInsertar.Enabled = false;
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    //lblCaja.Text = "Detalles";
                    //txtCaja.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(true);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    //lblCaja.Text = "Detalles";
                    //txtIdCaja.Text = IdCaja.ToString();
                    //txtCaja.Text = Caja;
                    //cmbCategoria.SelectedValue = IdCategoria;
                    break;
                case 3: //CANCELAR
                    Habilitar(true);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    //txtCaja.Text = Caja;
                    //cmbCategoria.SelectedValue = IdCategoria;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    //lblCaja.Text = "Detalles";
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            HabilitarBotones();
            btnCancelar.Visible = true;
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }

        #endregion

        #region BOTÓN CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            //txtIdCaja.Text = IdCaja.ToString();
            //txtCaja.Text = Caja;
            cmbCaja.SelectedIndex = IdCaja;
            HabilitarBotones();
        }
        #endregion

        #endregion
        #endregion

        #region AGREGAR DETALLE DE APERTURA A DATATABLE

        #region ASIGNACION DE VARIABLES PARA EL DETALLE DE LA APERTURA - FUNCIONA PERO NO SE PUEDE APLICAR
        private void SustitucionColumnas()
        {
            string[] vector = { "Efectivo", "Cheque", "Tarjeta", "Todas" };
            DataGridViewComboBoxColumn ComboBox = new DataGridViewComboBoxColumn();
            ComboBox.DataSource = vector;
            dgvListado.Columns.Add(ComboBox);
            dgvListado.ReadOnly = false;
        }
        #endregion

        private decimal CalcularSubtotal(string denominacion, int cantidad)
        {
            decimal subtotal;
            decimal montoDenominacion = Convert.ToDecimal(denominacion.Substring(1, denominacion.Length - 1));
            subtotal = montoDenominacion * cantidad;
            return subtotal;
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtDetalleCierre.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            return total;
        }

        private decimal CalcularDiferencia(decimal montoFinalReal, decimal montoFinalSistema)
        {
            decimal diferencia = 0.00m;
            diferencia = montoFinalReal - montoFinalSistema;
            return diferencia;
        }

        private void AgregarDetalle()
        {
            IdCaja = Convert.ToInt32(cmbCaja.SelectedValue);
            Moneda = cmbMoneda.Text;
            Denominacion = cmbDenominacion.Text;
            Cantidad = Convert.ToInt32(nudCantidad.Value);
            Subtotal = CalcularSubtotal(Denominacion, Cantidad);
            if (IdCaja < 0)
            {
                errorIcono.SetError(cmbCaja, "Seleccione una caja");
                cmbCaja.Focus();
            }
            else
            {
                bool insertarDetalle = true;
                foreach (DataRow row in dtDetalleCierre.Rows)
                {
                    if (Convert.ToString(row["Denominacion"]) == Denominacion)
                    {
                        insertarDetalle = false;
                    }
                }
                if (insertarDetalle)
                {
                    //Agregar detalle a dtDetalleApertura
                    DataRow row = dtDetalleCierre.NewRow();
                    row["Moneda"] = Moneda;
                    row["Denominacion"] = Denominacion;
                    row["Cantidad"] = Cantidad;
                    row["Subtotal"] = Subtotal;
                    dtDetalleCierre.Rows.Add(row);
                }
            }
            VerificarRegistros();
            MontoFinalReal = CalcularTotal();
            txtMontoFinalReal.Text = MontoFinalReal.ToString("$#0.#0", CultureInfo.InvariantCulture);
            //MontoFinalSistema = CalcularTotal();
            //txtMontoFinalSistema.Text = MontoFinalSistema.ToString("$#0.#0", CultureInfo.InvariantCulture);
        }

        #region ELIMINACION DE DETALLE
        private void Eliminar()
        {
            DialogResult Opcion;
            try
            {
                int idDetalleCierre;
                string Respuesta = "";
                switch (ctrlSeleccionado)
                {
                    case 0://INSERTAR
                        int indiceFila = dgvListado.CurrentCell.RowIndex;
                        DataRow row = dtDetalleCierre.Rows[indiceFila];
                        dtDetalleCierre.Rows.Remove(row);
                        dgvListado.DataSource = dtDetalleCierre;
                        break;
                    case 1://EDITAR
                           //SELECCION DE UN REGISTRO
                        Opcion = MessageBox.Show(
                            "¿Realmente desea eliminar el registro seleccionado?",
                            "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Opcion == DialogResult.Yes)
                        {
                            idDetalleCierre = Convert.ToInt32(dgvListado.CurrentRow.Cells[0].Value);
                            Respuesta = NegocioDetalleApertura.Eliminar(idDetalleCierre);
                            if (Respuesta.Equals("OK"))
                            {
                                NotificacionOk("Registro eliminado", "Eliminando");
                            }
                            else
                            {
                                NotificacionError("El registro no se eliminó.", "Error");
                            }
                            Mostrar();
                        }
                        break;
                    default:
                        NotificacionError(Respuesta, "Error");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            VerificarRegistros();
            //MontoFinalSistema = CalcularTotal();
            //txtMontoFinalSistema.Text = MontoFinalSistema.ToString("$#0.#0", CultureInfo.InvariantCulture);
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Eliminar();
        }
        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }
        #endregion

        #region INSERTAR - EDITAR

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {
            string agregarActualizar = "";
            if (IdCaja <= 0)
            {
                errorIcono.SetError(cmbCaja, "Seleccione una caja.");
                cmbCaja.SelectAll();
            }
            else if (dtDetalleCierre.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar los detalles de la apertura de la caja para poder calcular el monto inicial de la caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else if (txtMontoFinalReal.Text == string.Empty)
            {
                errorIcono.SetError(txtMontoFinalReal, "Ingrese el monto contado manualmente.");
                txtMontoFinalReal.SelectAll();
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            if (formPrincipal.ForzarCierre)
                            {
                                agregarActualizar = NegocioCierre.Insertar(formPrincipal.IdAperturaCierre, IdCaja, IdEmpleado, dtpFechaHoraCierre.Value, MontoFinalSistema, MontoFinalReal, dtDetalleCierre, Diferencia, "CERRADA");
                            }
                            else
                            {
                                agregarActualizar = NegocioCierre.Insertar(IdAperturaCierre, IdCaja, IdEmpleado, dtpFechaHoraCierre.Value, MontoFinalSistema, MontoFinalReal, dtDetalleCierre, Diferencia, "CERRADA");
                            }
                            if (agregarActualizar.Equals("OK"))
                            {
                                NotificacionOk("La caja se cerró correctamente", "Guardando");
                                //formPrincipal.IdCaja = 0;
                                //frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
                                //if (formPrincipal.ForzarCierre)
                                //{
                                //    formPrincipal.IdAperturaCierre = 0;
                                //    formPrincipal.ForzarCierre = false;
                                //}
                                formPrincipal.CajaAbierta = false;
                                formPrincipal.GuardarConfiguracion();
                                //Configuracion.CajaAbierta = false;
                                //Configuracion.Save();
                                //formPrincipal.CargarConfiguracion();
                                HabilitarBotones();
                                //txtCaja.SelectAll();
                                //Limpiar();
                                Close();
                            }
                            else
                            {
                                NotificacionError("Error al intentar guardar el cierre.", "Error");
                                MessageBox.Show(agregarActualizar, "Error");
                            }
                            break;
                        //case 1://EDITAR
                        //    agregarActualizar = NegocioApertura.Editar(IdCierre, IdCaja, IdEmpleado, dtpFechaHoraApertura.Value, MontoFinalSistema, dtDetalleCierre);
                        //    if (agregarActualizar.Equals("OK"))
                        //    {
                        //        //(txtCaja.Enabled = false;
                        //        //(cmbCategoria.Enabled = false;
                        //        //(btnEditar.Visible = true;
                        //        //(btnInsertar.Visible = false;
                        //        //(btnCancelar.Visible = false;
                        //        //(btnNuevo.Visible = true;
                        //        NotificacionOk("Caja editada correctamente", "Editando");
                        //    }
                        //    else
                        //    {
                        //        NotificacionError("Error al intentar editar la caja", "Error");
                        //        MessageBox.Show(agregarActualizar, "Error");
                        //    }
                        //    break;
                        default:
                            NotificacionError(agregarActualizar, "Error");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
        #endregion

        #region BOTÓN GUARDAR
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (formPrincipal.AdministrarCierreCaja)
            {
                formPrincipal.ForzarCierre = true;
            }
            Diferencia = CalcularDiferencia(MontoFinalReal, MontoFinalSistema);
            InsertarEditar();
        }

        #endregion

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //if (formPrincipal.AdministrarCierreCaja)
            //{
            //    if (!formPrincipal.ForzarCierre)
            //    {
            //        DialogResult opcion;
            //        opcion = MessageBox.Show("¿Realmente desea salir sin cerrar la caja?.", "CANCELANDO CIERRE DE CAJA", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //        if (opcion == DialogResult.No)
            //        {
            //            formPrincipal.ForzarCierre = false;//e.Cancel = true;
            //        }
            //    }
            //}
            Close();
        }

        private void dgvListado_Leave(object sender, EventArgs e)
        {
            VerificarRegistros();
        }

        private void dgvListado_Enter(object sender, EventArgs e)
        {
            VerificarRegistros();
        }

        private void VerificarRegistros()
        {
            if (dgvListado.RowCount > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
        }

        private void tFechaHora_Tick(object sender, EventArgs e)
        {
            dtpFechaHoraCierre.Value = DateTime.Now;
        }

        bool validado = false;
        private void txtMontoFinalReal_TextChanged(object sender, EventArgs e)
        {
            if (validado)
            {
                MontoFinalReal = Validar.FormatearDecimal(sender, "Moneda");
                Diferencia = CalcularDiferencia(MontoFinalReal, MontoFinalSistema);
                txtDiferencia.Text = Diferencia.ToString("$#0.#0", CultureInfo.InvariantCulture);
            }
        }

        private void txtMontoFinalReal_KeyPress(object sender, KeyPressEventArgs e)
        {
            validado = Validar.ValidarDecimal(sender, e);
        }

        private void txtMontoFinalReal_KeyDown(object sender, KeyEventArgs e)
        {
            Validar.DesactivarTeclasDireccionales(e);
            Validar.DesactivarTeclasEdicion(e);
            Validar.DesactivarCopiadoPegado(e);
        }

        private void txtMontoFinalReal_Click(object sender, EventArgs e)
        {
            Validar.DefaultPosition(sender, MontoFinalReal, 2);
        }

        private void txtMontoFinalReal_DoubleClick(object sender, EventArgs e)
        {
            Validar.DefaultPosition(sender, MontoFinalReal, 2);
        }
    }
}