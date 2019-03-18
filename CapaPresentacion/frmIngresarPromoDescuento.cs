using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using CapaNegocio;
using System.Globalization;

using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmIngresarPromoDescuento : MaterialForm
    {
        frmSeleccionarArticulo formSeleccionarArticulo = frmSeleccionarArticulo.GetInstancia();
        public int ctrlSeleccionado = 0;
        public int IdDescuento;
        public int IdArticulo;
        public string Codigo;
        public string Articulo;
        public decimal Cantidad;
        public decimal PrecioCompra;
        public decimal PrecioVenta;
        public string Descripcion;

        public decimal PorcentajeGanancia;
        public decimal MontoInversion;
        public decimal PrecioVentaDescuento;
        public bool Actualizar;

        DataTable dtDetallesDescuento = new DataTable();

        ControlTeclado controlTeclado = new ControlTeclado();

        public frmIngresarPromoDescuento()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        #region INSTANCIACION
        private static frmIngresarPromoDescuento _Instancia;

        public static frmIngresarPromoDescuento Instancia
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

        public static frmIngresarPromoDescuento GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarPromoDescuento();
            }
            return Instancia;
        }
        private void frmIngresarPromoDescuento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void frmIngresarPromoDescuento_Load(object sender, EventArgs e)
        {
            CrearDetalleDescuento();
            HabilitarBotones();
            NombreColumnas();
            OcultarColumnas();
        }
        
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

        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            txtIdDescuento.Text = string.Empty;
            IdArticulo = 0;
            Codigo = string.Empty;
            txtArticulo.Text = string.Empty;
            txtCantidad.Text = "0.00";
            txtPrecioVentaDescuento.Text = "0.00";
            txtDescripcion.Text = string.Empty;
        }

        #region HABILITAR

        //HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtNombreDescuento.Enabled = !valor;
            txtCantidad.Enabled = !valor;
            chkEstablecerPorcentajeGanancia.Enabled = !valor;
            //txtPrecioInversion.Enabled = !valor;
            txtPrecioVentaDescuento.Enabled = !valor;
            chkActualizacionAutomatica.Enabled = !valor;
            txtDescripcion.Enabled = !valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(false);
                    btnBuscarArticulo.Enabled = true;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnCancelar.Visible = false;
                    lblDescuento.Text = "Nueva Promo";
                    btnBuscarArticulo.Focus();
                    dtDetallesDescuento.Clear();
                    CrearDetalleDescuento();
                    break;
                case 1: //EDITAR
                    Habilitar(false);
                    btnBuscarArticulo.Enabled = true;
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    lblDescuento.Text = "Detalles";
                    btnBuscarArticulo.Focus();
                    break;
                case 2: //CONSULTAR
                    Habilitar(true);
                    btnBuscarArticulo.Enabled = false;
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    lblDescuento.Text = "Detalles";
                    txtIdDescuento.Text = Convert.ToString(IdDescuento);
                    txtArticulo.Text = Articulo;
                    txtCantidad.Text = Cantidad.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtMontoInversion.Text = MontoInversion.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtPorcentajeGanancia.Text = PorcentajeGanancia.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtPrecioVentaDescuento.Text = PrecioVentaDescuento.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtDescripcion.Text = Descripcion;
                    Mostrar();
                    break;
                case 3: //CANCELAR
                    Habilitar(true);
                    btnBuscarArticulo.Enabled = false;
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    txtArticulo.Text = Articulo;
                    txtCantidad.Text = Cantidad.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtMontoInversion.Text = MontoInversion.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtPorcentajeGanancia.Text = PorcentajeGanancia.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtPrecioVentaDescuento.Text = PrecioVentaDescuento.ToString("#0.##", CultureInfo.InvariantCulture);
                    txtDescripcion.Text = Descripcion;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblDescuento.Text = "Detalles";
                    Mostrar();
                    //NombreColumnas();
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
            txtIdDescuento.Text = Convert.ToString(IdDescuento);
            txtArticulo.Text = Articulo;
            txtCantidad.Text = Convert.ToString(Cantidad);
            txtPrecioVentaDescuento.Text = Convert.ToString(PrecioVentaDescuento);
            txtDescripcion.Text = Descripcion;
            HabilitarBotones();
        }
        #endregion

        #region INSERTAR - EDITAR

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {
            string agregarActualizar = "";
            if (txtNombreDescuento.Text == string.Empty)
            {
                errorIcono.SetError(txtNombreDescuento, "Ingrese el nombre de la promoción");
            }
            else if (txtArticulo.Text == string.Empty || IdArticulo == 0)
            {
                errorIcono.SetError(txtArticulo, "Ingrese un artículo.");
                txtArticulo.SelectAll();
            }
            else if (txtCantidad.Text == string.Empty)
            {
                errorIcono.SetError(txtCantidad, "Ingrese la cantidad del producto a la cual se le realizará el descuento");
                txtCantidad.SelectAll();
            }
            else if (txtPrecioVentaDescuento.Text == string.Empty)
            {
                errorIcono.SetError(txtPrecioVentaDescuento, "Ingrese el precio del descuento");
                txtPrecioVentaDescuento.SelectAll();
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            agregarActualizar = NegocioDescuento.Insertar(txtNombreDescuento.Text.ToUpper().Trim(), txtDescripcion.Text, dtDetallesDescuento);
                            if (agregarActualizar.Equals("OK"))
                            {
                                NotificacionOk("Descuento guardado correctamente", "Guardando");
                            }
                            else
                            {
                                MessageBox.Show(agregarActualizar);
                            }
                            HabilitarBotones();
                            txtArticulo.SelectAll();
                            Limpiar();
                            break;
                        case 1://EDITAR
                            agregarActualizar = NegocioDescuento.Editar(IdDescuento, txtNombreDescuento.Text.ToUpper().Trim(), txtDescripcion.Text, dtDetallesDescuento);
                            if (agregarActualizar.Equals("OK"))
                            {
                                NotificacionOk("Descuento editado correctamente", "Editando");
                                txtArticulo.Enabled = false;
                                txtDescripcion.Enabled = false;
                                btnEditar.Visible = true;
                                btnInsertar.Visible = false;
                                btnCancelar.Visible = false;
                                btnNuevo.Visible = true;
                            }
                            else
                            {
                                MessageBox.Show(agregarActualizar);
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

        #region BOTÓN GUARDAR
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarEditar();
        }
        #endregion

        #endregion

        #region MOSTRAR

        #region BOTON BUSCAR ARTICULO
        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            formSeleccionarArticulo.dgvListado.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(formSeleccionarArticulo_dgvListadoDobleClick);
            formSeleccionarArticulo.ShowDialog();
        }
        #endregion

        #region SELECCIONAR ARTICULO
        private void formSeleccionarArticulo_dgvListadoDobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdArticulo = formSeleccionarArticulo.IdArticulo;
            Codigo = formSeleccionarArticulo.Codigo;
            Articulo = formSeleccionarArticulo.Articulo;
            txtArticulo.Text = Articulo;
            PrecioCompra = formSeleccionarArticulo.PrecioCompra;
            PrecioVenta = formSeleccionarArticulo.PrecioVenta;
            CalculoPromo();
        }
        #endregion
        #endregion

        #region ASIGNACIÓN DE VARIABLES - CALCULO DE LA PROMOCIÓN
        private void CalculoPromo()
        {
            try
            {
                Cantidad = Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture);
                PorcentajeGanancia = Convert.ToDecimal(txtPorcentajeGanancia.Text, CultureInfo.InvariantCulture);
                MontoInversion = PrecioCompra * Cantidad;
                txtMontoInversion.Text = MontoInversion.ToString("#0.##", CultureInfo.InvariantCulture);
                PrecioVentaDescuento = ((MontoInversion * PorcentajeGanancia) / 100) + MontoInversion;
                txtPrecioVentaDescuento.Text = PrecioVentaDescuento.ToString("#0.##", CultureInfo.InvariantCulture);
                Descripcion = txtDescripcion.Text;
            }
            catch { }
        }
        #endregion

        private void chkEstablecerPorcentajeGanancia_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstablecerPorcentajeGanancia.Checked)
            {
                txtPorcentajeGanancia.Enabled = true;
                txtPorcentajeGanancia.SelectAll();
                txtPrecioVentaDescuento.Enabled = false;
            }
            else
            {
                txtPorcentajeGanancia.Enabled = false;
                txtPorcentajeGanancia.Text = "0";
                txtPrecioVentaDescuento.Enabled = true;
                CalculoPromo();
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CalculoPromo();
        }

        #region ELIMINAR

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ctrlSeleccionado == 1 || ctrlSeleccionado == 0)
                {
                    btnQuitar.Enabled = true;
                    if (e.ColumnIndex == dgvListado.Columns[0].Index)
                    {
                        DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                        chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
                    }
                    if (e.ColumnIndex == dgvListado.Columns[9].Index)
                    {
                        DataGridViewCheckBoxCell chkActualizar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[9];
                        chkActualizar.Value = !Convert.ToBoolean(chkActualizar.Value);
                    }
                }
            }
            catch { }
        }

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
                btnQuitar.Enabled = false;
                foreach (DataGridViewRow row in dgvListado.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
        }

        #region AGREGAR DETALLE
        private void AgregarDetalle()
        {
            
            if (chkActualizacionAutomatica.Checked)
            {
                Actualizar = true;
            }
            else
            {
                Actualizar = false;
            }
            if (txtArticulo.Text == string.Empty)
            {
                errorIcono.SetError(txtArticulo, "Seleccione un artículo.");
                btnBuscarArticulo.PerformClick();
            }
            else if (txtCantidad.Text == string.Empty)
            {
                errorIcono.SetError(txtCantidad, "Ingrese la cantidad.");
                txtCantidad.SelectAll();
            }
            else if (txtPrecioVentaDescuento.Text == string.Empty)
            {
                errorIcono.SetError(txtPrecioVentaDescuento, "Ingrese el precio de venta de la promoción.");
                txtPrecioVentaDescuento.SelectAll();
            }
            else if (Convert.ToDecimal(txtPrecioVentaDescuento.Text, CultureInfo.InvariantCulture) <= MontoInversion)
            {
                errorIcono.SetError(txtPrecioVentaDescuento, "El precio de venta no puede ser menor o igual al precio de la inversión.");
            }
            else
            {
                Cantidad = Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture);
                PorcentajeGanancia = Convert.ToDecimal(txtPorcentajeGanancia.Text, CultureInfo.InvariantCulture);
                MontoInversion = Convert.ToDecimal(txtMontoInversion.Text, CultureInfo.InvariantCulture);
                PrecioVentaDescuento = Convert.ToDecimal(txtPrecioVentaDescuento.Text, CultureInfo.InvariantCulture);
                bool insertarDetalle = true;
                foreach (DataRow row in dtDetallesDescuento.Rows)
                {
                    if (Convert.ToInt32(row["IdArticulo"]) == IdArticulo)
                    {
                        insertarDetalle = false;
                        MessageBox.Show("El producto ya está en la lista, si desea modificarlo primero deberá quitarlo, realizar las modificaciones correspondientes y luego volver a agregarlo.", 
                            "Acción no permitida.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (insertarDetalle)
                {
                    DataRow row = dtDetallesDescuento.NewRow();
                    row["IdArticulo"] = IdArticulo;
                    row["Articulo"] = Articulo;
                    row["Cantidad"] = Cantidad;
                    row["PorcentajeGanancia"] = PorcentajeGanancia;
                    row["MontoInversion"] = MontoInversion;
                    row["PrecioVentaDescuento"] = PrecioVentaDescuento;
                    row["Actualizar"] = Actualizar;
                    dtDetallesDescuento.Rows.Add(row);
                }
            }
        }

        #endregion

        #region QUITAR DETALLE
        private void QuitarDetalle()
        {
            try
            {
                switch (ctrlSeleccionado)
                {
                    case 0:
                        {
                            int indiceFila = dgvListado.CurrentCell.RowIndex;
                            DataRow row = dtDetallesDescuento.Rows[indiceFila];
                            dtDetallesDescuento.Rows.Remove(row);
                            break;
                        }
                    case 1:
                        {
                            int idDetalleDescuento;
                            string respuesta = "";
                            DialogResult Opcion;
                            Opcion = MessageBox.Show(
                                "¿Realmente desea eliminar el item seleccionado?",
                                "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.Yes)
                            {
                                idDetalleDescuento = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdDetalleDescuento"].Value);
                                respuesta = NegocioDetalleDescuento.Eliminar(idDetalleDescuento);
                                if (respuesta.Equals("OK"))
                                {
                                    NotificacionOk("El item se eliminó correctamente", "Eliminando");
                                    Mostrar();
                                }
                                else
                                {
                                    NotificacionError("El registro no se eliminó", "Error");
                                }
                            }
                            if (dgvListado.RowCount == 0)
                            {
                                int idDescuento;
                                idDescuento = IdDescuento;
                                respuesta = NegocioDescuento.Eliminar(idDescuento);
                                if (respuesta.Equals("OK"))
                                {
                                    NotificacionOk("Se eliminó la promoción correctamente", "Eliminando");
                                    Close();
                                }
                                else
                                {
                                    NotificacionError("La promoción no se eliminó", "Error");
                                }
                            }
                                break;
                        }
                }
            }
            catch
            {
                NotificacionError("No hay ningún item añadido.", "Error");
            }
        }
        #endregion

        #region DETALLE DEL DESCUENTO

        #region MOSTRAR DETALLE DEL DESCUENTO
        public void Mostrar()
        {
            dtDetallesDescuento = NegocioDetalleDescuento.Mostrar(IdDescuento);
            dgvListado.DataSource = dtDetallesDescuento;
        }
        #endregion

        #region DATATABLE DETALLE DEL DESCUENTO
        private void CrearDetalleDescuento()
        {
            dtDetallesDescuento = new DataTable("DetallesDescuento");
            dtDetallesDescuento.Columns.Add("IdDetalleDescuento", Type.GetType("System.Int32"));
            dtDetallesDescuento.Columns.Add("IdDescuento", Type.GetType("System.Int32"));
            dtDetallesDescuento.Columns.Add("IdArticulo", Type.GetType("System.Int32"));
            dtDetallesDescuento.Columns.Add("Articulo", Type.GetType("System.String"));
            dtDetallesDescuento.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dtDetallesDescuento.Columns.Add("PorcentajeGanancia", Type.GetType("System.Decimal"));
            dtDetallesDescuento.Columns.Add("MontoInversion", Type.GetType("System.Decimal"));
            dtDetallesDescuento.Columns.Add("PrecioVentaDescuento", Type.GetType("System.Decimal"));
            dtDetallesDescuento.Columns.Add("Actualizar", Type.GetType("System.Boolean"));
            dgvListado.DataSource = dtDetallesDescuento;
        }
        #endregion

        #region NOMBRE COLUMNAS
        private void NombreColumnas()
        {
            dgvListado.Columns["Articulo"].HeaderText = "Artículo";
            dgvListado.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvListado.Columns["PorcentajeGanancia"].HeaderText = "Porcentaje de ganancia";
            dgvListado.Columns["MontoInversion"].HeaderText = "Costo";
            dgvListado.Columns["PrecioVentaDescuento"].HeaderText = "Venta";
            dgvListado.Columns["Actualizar"].HeaderText = "Actualizar";
        }
        #endregion

        #region CÓDIGO PARA AGREGAR UN CHECKBOX (O CUALQUIER OTRO TIPO DE COLUMNA) EN UN DATAGRID EN TIEMPO DE EJECUCIÓN
        /*
         
            //DataGridViewColumn textColumna = dgvListado.Columns["actualizacion_automatica"];
            DataGridViewColumn textColumna = dgvListado.Columns[9];
            DataGridViewCheckBoxColumn checkColumna = new DataGridViewCheckBoxColumn();
            //checkColumna.HeaderText = textColumna.HeaderText;
            checkColumna.HeaderText = "Actualizar";
            dgvListado.Columns.Remove(textColumna);
            //dgvListado.Columns.Remove(dgvListado.Columns["actualizacion_automatica"]);
            dgvListado.Columns.Insert(9, checkColumna);
             */
        #endregion

        #region OCULTAR COLUMNAS
        private void OcultarColumnas()
        {
            dgvListado.Columns[0].Visible = false;
            dgvListado.Columns["IdDetalleDescuento"].Visible = false;
            dgvListado.Columns["IdDescuento"].Visible = false;
            dgvListado.Columns["IdArticulo"].Visible = false;
            //dgvListado.Columns["Actualizar"].Visible = false;
        }
        #endregion

        #endregion

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            QuitarDetalle();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtNombreDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void btnBuscarArticulo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void chkEstablecerPorcentajeGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void txtPorcentajeGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void chkActualizacionAutomatica_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void frmIngresarPromoDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }
    }
}