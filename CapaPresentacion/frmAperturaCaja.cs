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
using System.Globalization;
using CapaPresentacion.Properties;
using CapaPresentacion.Modulos.Facturacion;

namespace CapaPresentacion
{
    public partial class frmAperturaCaja : MetroForm
    {
        Settings Configuracion = new Settings();
        public int ctrlSeleccionado = 0;
        public int IdEmpleado;
        public string Empleado;
        public int IdCaja;
        //public bool AperturaAutomatica;
        public string FormaCobro;
        public string Estado;

        //Detalle de apertura
        public int IdApertura;
        string Moneda;
        string Denominacion;
        int Cantidad;
        decimal Subtotal;
        decimal MontoInicial; // Este es el monto total que resulta de la suma de los subtotales en el detalle de la apertura de caja

        // APERTURAS PREDEFINIDAS
        Apertura Aperturas = new Apertura();
        //int IdAperturaPorDefecto;
        int IdAperturaPredefinida;
        string Descripcion;
        public bool EstablecerPorDefecto;
        public bool ProgramacionApertura;

        public int IdAperturaCierre;

        DataTable dtDetalleApertura;

        frmAperturaCierreCaja formAperturaCierre = frmAperturaCierreCaja.GetInstancia();

        frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
        public frmAperturaCaja()
        {
            InitializeComponent();
            dtpFechaHoraApertura.Format = DateTimePickerFormat.Custom;
            dtpFechaHoraApertura.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpFechaHoraApertura.Enabled = false;
        }

        private void frmAperturaCaja_Load(object sender, EventArgs e)
        {
            DefinirTipoApertura();
            ObtenerCajero();
            HabilitarBotones();
            ListaCajas();
            cmbCaja.SelectedValue = IdCaja;
            cmbMoneda.SelectedIndex = 0;
            cmbDenominacion.SelectedIndex = 7;
            if (!ProgramacionApertura)
            {
                if (ctrlSeleccionado == 2)
                {
                    Mostrar();
                }
                else
                {
                    CrearDetalleApertura();
                }
            }
            else
            {
                lblFechaHoraApertura.Text = "Fecha de creación.";
                if (ctrlSeleccionado != 2)
                {
                    MostrarDetallesAperturaPredefinida();
                    Aperturas.dgvDetallesAperturasPredefinidas(dgvListado);
                }
                else
                {
                    dtDetalleApertura = Aperturas.LlenarDetallesAperturasPredefinidas(IdApertura);
                    dgvListado.DataSource = dtDetalleApertura;
                    Aperturas.dgvDetallesAperturasPredefinidas(dgvListado);
                    //dgvListado.DataSource = NegocioDetalleApertura.MostrarDetallesAperturaPredefinida(IdApertura);
                }
            }
        }

        #region INSTANCIACION
        private static frmAperturaCaja _Instancia = null;

        public static frmAperturaCaja Instancia
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

        public static frmAperturaCaja GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmAperturaCaja();
            }
            return Instancia;
        }
        private void frmAperturaCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            formAperturaCierre.ProgramacionApertura = false;
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

        #region DEFINIR TIPO DE APERTURA
        private void DefinirTipoApertura()
        {
            if (ProgramacionApertura)
            {
                cmbCaja.Enabled = true;
                chkAperturaPorDefecto.Visible = true;
                lblDescripcion.Visible = true;
                txtDescripcion.Visible = true;
                lblEstado.Visible = false;
                txtEstado.Visible = false;
                lblCajero.Visible = false;
                txtEmpleado.Visible = false;
                //dtpFechaHoraApertura.Enabled = true;
            }
            else
            {
                cmbCaja.Enabled = false;
                chkAperturaPorDefecto.Visible = false;
                lblDescripcion.Visible = false;
                txtDescripcion.Visible = false;
                lblEstado.Visible = true;
                txtEstado.Visible = true;
                lblCajero.Visible = true;
                txtEmpleado.Visible = true;
            }
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
            CrearDetalleApertura();
            dtDetalleApertura = NegocioApertura.Mostrar(IdApertura);
            dgvListado.DataSource = dtDetalleApertura;
            NombreColumnas();
            OcultarColumnas();
        }

        private void MostrarDetallesAperturaPredefinida()
        {
            Aperturas.CrearDetallesAperturaPredefinida();
            dtDetalleApertura = Aperturas.dtDetallesAperturaPredefinida;
            dgvListado.DataSource = dtDetalleApertura;
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
        public void CrearDetalleApertura()
        {
            dtDetalleApertura = new DataTable("DetalleApertura");
            dtDetalleApertura.Columns.Add("IdDetalleApertura", Type.GetType("System.Int32"));
            dtDetalleApertura.Columns.Add("IdApertura", Type.GetType("System.Int32"));
            dtDetalleApertura.Columns.Add("Moneda", Type.GetType("System.String"));
            dtDetalleApertura.Columns.Add("Denominacion", Type.GetType("System.String"));
            dtDetalleApertura.Columns.Add("Cantidad", Type.GetType("System.Int32"));
            dtDetalleApertura.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
            dgvListado.DataSource = dtDetalleApertura;
            NombreColumnas();
            OcultarColumnas();
        }

        //public void CrearDetalleApertura(DataTable dtDetalleApertura)
        //{
        //    dtDetalleApertura = new DataTable("DetalleApertura");
        //    dtDetalleApertura.Columns.Add("IdDetalleApertura", Type.GetType("System.Int32"));
        //    dtDetalleApertura.Columns.Add("IdApertura", Type.GetType("System.Int32"));
        //    dtDetalleApertura.Columns.Add("Moneda", Type.GetType("System.String"));
        //    dtDetalleApertura.Columns.Add("Denominacion", Type.GetType("System.String"));
        //    dtDetalleApertura.Columns.Add("Cantidad", Type.GetType("System.Int32"));
        //    dtDetalleApertura.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
        //    dgvListado.DataSource = dtDetalleApertura;
        //    NombreColumnas();
        //    OcultarColumnas();
        //}

        private void NombreColumnas()
        {
            dgvListado.Columns["Denominacion"].HeaderText = "Denominación";
        }

        private void OcultarColumnas()
        {
            dgvListado.Columns["IdDetalleApertura"].Visible = false;
            dgvListado.Columns["IdApertura"].Visible = false;
        }
        #endregion

        #region BOTONES Y FUNCIONALIDAD
        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            cmbCaja.SelectedIndex = IdCaja;
            dtDetalleApertura.Clear();
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
            chkAperturaPorDefecto.Checked = EstablecerPorDefecto;
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
            decimal montoDenominacion = Convert.ToDecimal(denominacion.Substring(1, denominacion.Length-1));
            subtotal = montoDenominacion * cantidad;
            return subtotal;
        }

        private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (DataRow row in dtDetalleApertura.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }
            return total;
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
                foreach (DataRow row in dtDetalleApertura.Rows)
                {
                    if (Convert.ToString(row["Denominacion"]) == Denominacion)
                    {
                        insertarDetalle = false;
                    }
                }
                if (insertarDetalle)
                {
                    //Agregar detalle a dtDetalleApertura
                    DataRow row = dtDetalleApertura.NewRow();
                    row["Moneda"] = Moneda;
                    row["Denominacion"] = Denominacion;
                    row["Cantidad"] = Cantidad;
                    row["Subtotal"] = Subtotal;
                    dtDetalleApertura.Rows.Add(row);
                }
            }
            VerificarRegistros();
            MontoInicial = CalcularTotal();
            txtMontoInicial.Text = MontoInicial.ToString("$#0.#0", CultureInfo.InvariantCulture);
        }

        #region ELIMINACION DE DETALLE
        private void Eliminar()
        {
            DialogResult Opcion;
            try
            {
                int idDetalleApertura;
                string Respuesta = "";
                switch (ctrlSeleccionado)
                {
                    case 0://INSERTAR
                        int indiceFila = dgvListado.CurrentCell.RowIndex;
                        DataRow row = dtDetalleApertura.Rows[indiceFila];
                        dtDetalleApertura.Rows.Remove(row);
                        dgvListado.DataSource = dtDetalleApertura;
                        break;
                    case 1://EDITAR
                           //SELECCION DE UN REGISTRO
                        Opcion = MessageBox.Show(
                            "¿Realmente desea eliminar el registro seleccionado?",
                            "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Opcion == DialogResult.Yes)
                        {
                            idDetalleApertura = Convert.ToInt32(dgvListado.CurrentRow.Cells[0].Value);
                            if (ProgramacionApertura)
                            {
                                Respuesta = NegocioDetalleApertura.EliminarDetalleAperturaPredefinida(idDetalleApertura);
                            }
                            else
                            {
                                Respuesta = NegocioDetalleApertura.Eliminar(idDetalleApertura);
                            }
                            if (Respuesta.Equals("OK"))
                            {
                                NotificacionOk("Registro eliminado", "Eliminando");
                            }
                            else
                            {
                                NotificacionError("El registro no se eliminó.", "Error");
                            }
                            if (ProgramacionApertura)
                            {
                                MostrarDetallesAperturaPredefinida();
                            }
                            else
                            {
                                Mostrar();
                            }
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
            MontoInicial = CalcularTotal();
            txtMontoInicial.Text = MontoInicial.ToString("$#0.#0", CultureInfo.InvariantCulture);
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
            Descripcion = txtDescripcion.Text;
            //formPrincipal.IdCaja = IdCaja; Ya está esta línea más abajo
            string agregarActualizar = "";
            if (IdCaja <= 0)
            {
                errorIcono.SetError(cmbCaja, "Seleccione una caja.");
                cmbCaja.SelectAll();
            }
            else if (dtDetalleApertura.Rows.Count < 1)
            {
                MessageBox.Show("Debe ingresar los detalles de la apertura de la caja para poder calcular el monto inicial de la caja", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            //else if (ProgramacionApertura && dtpFechaHoraApertura.Value <= DateTime.Now)
            //{
            //    errorIcono.SetError(dtpFechaHoraApertura, "Horario de apertura no válido");
            //    dtpFechaHoraApertura.Focus();
            //}
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            string mensaje;
                            if (ProgramacionApertura)
                            {
                                agregarActualizar = NegocioApertura.InsertarAperturaPredefinida(IdCaja, IdEmpleado, dtpFechaHoraApertura.Value,
                                    MontoInicial, dtDetalleApertura, Descripcion, ref IdAperturaPredefinida);
                                mensaje = "La apertura se guardó correctamente para el día: " + dtpFechaHoraApertura.Value.ToString();
                            }
                            else
                            {
                                agregarActualizar = NegocioApertura.Insertar(IdCaja, IdEmpleado, dtpFechaHoraApertura.Value, MontoInicial,
                                    dtDetalleApertura, "ABIERTA", ref IdAperturaCierre);
                                mensaje = "La caja se abrió correctamente";
                            }
                            if (agregarActualizar.Equals("OK"))
                            {
                                NotificacionOk(mensaje, "Guardando");
                                //if (EstablecerPorDefecto)
                                //{
                                    frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
                                    formPrincipal.IdCaja = IdCaja;
                                    formPrincipal.IdAperturaPredefinida = IdAperturaPredefinida;
                                    formPrincipal.IdAperturaCierre = IdAperturaCierre;
                                    if (ProgramacionApertura)
                                    {
                                        formPrincipal.AbrirCaja = true;
                                        //formPrincipal.CajaAbierta = false;
                                    }
                                    else
                                    {
                                        formPrincipal.CajaAbierta = true;
                                    }
                                    formPrincipal.GuardarConfiguracion();
                                    //Configuracion.IdAperturaPredefinida = IdAperturaPredefinida;
                                    //Configuracion.CajaAbierta = true;
                                    ////Configuracion.AbrirCaja = true; // IMPORTANTE!! ESTAS DOS LÍNEAS (LA DE ARRIBA Y ESTA) VAN EN LA PESTAÑA CONFIGURACIÓN!! LÍNEA 565 frmAperturaCaja.cs
                                    //Configuracion.Save();
                                //}
                                //Configuracion.FechaHoraApertura = true;
                                //formPrincipal.IdCaja = IdCaja;
                                //formPrincipal.CajaAbierta = true;
                                HabilitarBotones();
                                //txtCaja.SelectAll();
                                //Limpiar();
                                Close();
                            }
                            else
                            {
                                NotificacionError("Error al intentar guardar la apertura", "Error");
                                MessageBox.Show(agregarActualizar, "Error");
                            }
                            break;
                        case 1://EDITAR
                            if (ProgramacionApertura)
                            {
                                agregarActualizar = NegocioApertura.EditarAperturaPredefinida(IdAperturaPredefinida, IdCaja, IdEmpleado,
                                    dtpFechaHoraApertura.Value, MontoInicial, dtDetalleApertura, Descripcion);
                                mensaje = "La apertura se editó correctamente";
                            }
                            else
                            {
                                agregarActualizar = NegocioApertura.Editar(IdApertura, IdCaja, IdEmpleado, dtpFechaHoraApertura.Value, MontoInicial,
                                    dtDetalleApertura);
                                mensaje = "Caja editada correctamente";
                            }
                            if (agregarActualizar.Equals("OK"))
                            {
                                //(txtCaja.Enabled = false;
                                //(cmbCategoria.Enabled = false;
                                //(btnEditar.Visible = true;
                                //(btnInsertar.Visible = false;
                                //(btnCancelar.Visible = false;
                                //(btnNuevo.Visible = true;
                                NotificacionOk(mensaje, "Editando");
                            }
                            else
                            {
                                NotificacionError("Error al intentar editar la caja", "Error");
                                MessageBox.Show(agregarActualizar, "Error");
                            }
                            break;
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

        #region COMPROBAR CAJA ABIERTA
        private void ComprobarCajaAbierta()
        {
            if (formPrincipal.CajaAbierta)
            {

            }
        }
        #endregion

        #region BOTÓN GUARDAR
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            //ComprobarCajaAbierta();
            InsertarEditar();
        }

        #endregion

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
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
            //if (!ProgramacionApertura)
            dtpFechaHoraApertura.Value = DateTime.Now;
        }

        private void chkAperturaAutomatica_CheckedChanged(object sender, EventArgs e)
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
    }
}