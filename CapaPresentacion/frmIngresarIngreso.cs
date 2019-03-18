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
using System.Globalization; // Sirve para acceder al formato de la region

using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

using CapaPresentacion.Validacion;

namespace CapaPresentacion
{
    public partial class frmIngresarIngreso : MetroForm
    {
        frmIngresarProveedor formIngresarProveedor = frmIngresarProveedor.GetInstancia();
        frmSeleccionarArticulo formSeleccionarProducto = frmSeleccionarArticulo.GetInstancia();

        Validacion.Validacion validar = new Validacion.Validacion();

        public int ctrlSeleccionado;
        public int IdIngreso;
        public int IdDetalleIngreso;
        public decimal IVA;
        public int IdEmpleado;
        public string Empleado;
        public int IdProveedor;
        public string Proveedor;
        public DateTime Fecha;
        public string TipoComprobante;
        public string Serie;
        public string Correlativo;
        public int IdArticulo;
        public string Articulo;
        public decimal Stock;
        public decimal Cantidad = 1;
        public decimal PrecioCompra;
        public decimal PrecioVenta;
        public DateTime FechaProduccion;
        public DateTime FechaVencimiento;
        public string Estado;
        public decimal Total;
        DataTable dtDetalles;
        DataTable dtArticulos;
        CultureInfo miCultureInfo = new CultureInfo("en"); /* Sirve para establecer el uso del . (punto) en vez de la , (coma) 
        para números decimales*/

        #region VARIABLES QUE SE INSERTARÁN EN LA TABLA "Articulos"
        public string Codigo;
        public int IdCategoria;
        public int IdPresentacion;
        public string Descripcion;
        public string RutaImagen;
        #endregion

        #region VARIABLES PARA EL MANEJO DEL TAMAÑO
        int Limite;
        bool Expandir = false;
        #endregion

        bool IngresoRapido;

        public frmIngresarIngreso()
        {
            InitializeComponent();
            NotificacionCampos();
            listaProveedor();
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            formIngresarProveedor.btnInsertar.Click += new EventHandler(btnInsertarProveedor_Click);
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpFecha.Enabled = false;
            Limite = tableLayoutPanel7.Width / 2;
        }

        private void frmIngresarIngreso_Load(object sender, EventArgs e)
        {
            if (ctrlSeleccionado == 2)
            {
                MostrarDetalle();
            }
            else
            {
                CrearListaDetalles();
                CrearListaProductos();
            }
            MostrarArticulos();
            HabilitarBotones();
            //cmbProveedor.Select();
            cmbProveedor.SelectedIndex = 0;
            txtIngresoRapido.SelectAll();
        }

        #region INSTANCIACIÓN
        private static frmIngresarIngreso _Instancia = null;

        public static frmIngresarIngreso Instancia
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

        public static frmIngresarIngreso GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarIngreso();
            }
            return Instancia;
        }

        private void frmIngresarIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region MOSTRAR

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

        private void NotificacionCampos()
        {
            ttMensaje.SetToolTip(txtIdIngreso, "Código del ingreso");
            ttMensaje.SetToolTip(txtIVA, "Ingrese el porcentaje de I.V.A.");
            ttMensaje.SetToolTip(cmbProveedor, "Seleccione un proveedor");
            ttMensaje.SetToolTip(btnAgregarProveedor, "Agregar proveedor");
            ttMensaje.SetToolTip(dtpFecha, "Seleccione la fecha del ingreso");
            ttMensaje.SetToolTip(cmbComprobante, "Seleccione un tipo de comprobante");
            ttMensaje.SetToolTip(txtSerie, "Ingrese el número de serie del comprobante");
            ttMensaje.SetToolTip(txtCorrelativo, "Ingrese el número de correlativo del comprobante");
            ttMensaje.SetToolTip(txtArticulo, "Seleccione un artículo");
            ttMensaje.SetToolTip(btnBuscarArticulo, "Seleecione un artículo");
            ttMensaje.SetToolTip(txtCantidad, "Ingrese la cantidad de producto comprado");
            ttMensaje.SetToolTip(txtPorcentajeGanancia, "Ingrese el porcentaje que desea tener de ganancia para este prodcuto");
            ttMensaje.SetToolTip(txtPrecioCompra, "Ingrese el precio de compra del artículo");
            ttMensaje.SetToolTip(txtPrecioVenta, "Ingrese el precio de venta del artículo");
            ttMensaje.SetToolTip(dtpFechaProduccion, "Ingrese la fecha de producción del artículo");
            ttMensaje.SetToolTip(dtpFechaVencimiento, "Ingrese la fecha de vencimiento del artículo");
            ttMensaje.SetToolTip(btnAgregar, "Agregar artículo");
            ttMensaje.SetToolTip(btnQuitar, "Quitar artículo");
            ttMensaje.SetToolTip(btnInsertar, "Guardar ingreso");
        }
        #endregion

        #region DETALLE DEL INGRESO

        #region COLUMNAS DE DATAGRID "dgvDetalle"
        private void NombreColumnas()
        {
            dgvDetalle.Columns["Articulo"].HeaderText = "Artículo";
            dgvDetalle.Columns["PrecioCompra"].HeaderText = "Precio de compra";
            dgvDetalle.Columns["PrecioCompra"].DefaultCellStyle.Format = "$#0.##";
            dgvDetalle.Columns["PrecioVenta"].HeaderText = "Precio de venta";
            dgvDetalle.Columns["PrecioVenta"].DefaultCellStyle.Format = "$#0.##";
            dgvDetalle.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetalle.Columns["Cantidad"].DefaultCellStyle.Format = "#0.###";
            dgvDetalle.Columns["FechaProduccion"].HeaderText = "Fecha de producción";
            dgvDetalle.Columns["FechaVencimiento"].HeaderText = "Fecha de vencimiento";
            dgvDetalle.Columns["Subtotal"].HeaderText = "Subtotal";
            dgvDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "$#0.##";
        }

        private void OcultarColumnas()
        {
            dgvDetalle.Columns[0].Visible = false;
            dgvDetalle.Columns[1].Visible = false;
            dgvDetalle.Columns[2].Visible = false;
        }
        #endregion

        #region MOSTRAR DETALLE
        public void MostrarDetalle()
        {
            dgvDetalle.DataSource = NegocioIngreso.Mostrar(IdIngreso);
            HabilitarBotones();
            NombreColumnas();
            OcultarColumnas();
        }
        #endregion

        #region CREAR DETALLE
        private void CrearListaDetalles()
        {
            dtDetalles = new DataTable("Detalles");
            dtDetalles.Locale = miCultureInfo;
            dtDetalles.Columns.Add("IdDetalleIngreso", Type.GetType("System.Int32"));
            dtDetalles.Columns.Add("IdArticulo", System.Type.GetType("System.Int32"));
            dtDetalles.Columns.Add("Articulo", System.Type.GetType("System.String"));
            dtDetalles.Columns.Add("PrecioCompra", System.Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("Cantidad", System.Type.GetType("System.Decimal"));
            dtDetalles.Columns.Add("FechaProduccion", System.Type.GetType("System.DateTime"));
            dtDetalles.Columns.Add("FechaVencimiento", System.Type.GetType("System.DateTime"));
            dtDetalles.Columns.Add("Subtotal", System.Type.GetType("System.Decimal"));
            // Relacionar DataGridView con DataTable dtDetalle
            dgvDetalle.DataSource = dtDetalles;
            NombreColumnas();
            OcultarColumnas();
        }
        #endregion
        #endregion

        #region PRODUCTOS

        #region COLUMNAS DE DATAGRID "dgvArticulo"
        private void NombreColumnasArticulo()
        {
            dgvArticulo.Columns[1].HeaderText = "Código";
            dgvArticulo.Columns[2].HeaderText = "Artículo";
            dgvArticulo.Columns[4].HeaderText = "Categoría";
            dgvArticulo.Columns[5].HeaderText = "Precio de compra";
            dgvArticulo.Columns[5].DefaultCellStyle.Format = "#0.##";
            dgvArticulo.Columns[6].HeaderText = "Precio de venta";
            dgvArticulo.Columns[6].DefaultCellStyle.Format = "#0.##";
            dgvArticulo.Columns[7].HeaderText = "Stock";
            dgvArticulo.Columns[7].DefaultCellStyle.Format = "#0.###";
            dgvArticulo.Columns[9].HeaderText = "Presentación";
        }

        private void OcultarColumnasArticulo()
        {
            dgvArticulo.Columns[0].Visible = false;
            //dgvArticulo.Columns[1].Visible = false;
            dgvArticulo.Columns[3].Visible = false;
            dgvArticulo.Columns[8].Visible = false;
            dgvArticulo.Columns[10].Visible = false;
            dgvArticulo.Columns[11].Visible = false;
        }
        #endregion

        private void CrearListaProductos()
        {
            dtArticulos = new DataTable("Articulos");
            dtArticulos.Locale = miCultureInfo;
            dtArticulos.Columns.Add("IdArticulo", Type.GetType("System.Int32"));
            dtArticulos.Columns.Add("Codigo", Type.GetType("System.String"));
            dtArticulos.Columns.Add("Articulo", Type.GetType("System.String"));
            dtArticulos.Columns.Add("IdCategoria", Type.GetType("System.Int32"));
            dtArticulos.Columns.Add("PrecioCompra", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("PrecioVenta", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("Stock", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("IdPresentacion", Type.GetType("System.Int32"));
            dtArticulos.Columns.Add("Descripcion", Type.GetType("System.String"));
            dtArticulos.Columns.Add("RutaImagen", Type.GetType("System.String"));
        }

        #region MOSTRAR PRODUCTOS
        private void MostrarArticulos()
        {
            dgvArticulo.DataSource = NegocioArticulo.Mostrar();
            NombreColumnasArticulo();
            OcultarColumnasArticulo();
            frmArticulo formArticulos = frmArticulo.GetInstancia();
            formArticulos.Mostrar();
            frmIngresarVenta formIngresarVenta = frmIngresarVenta.GetInstancia();
            formIngresarVenta.Mostrar();
        }
        #endregion

        #region AGREGAR PRODUCTO (NO FUNCIONA BIEN) - DESCRIPCION DEL PROBLEMA DENTRO DE LA REGIÓN
        // AL GUARDAR EL INGRESO SE REEMPLAZAN LOS NOMBRES Y OTROS DATOS QUE NO DEBERÍAN EN LA TABLA "producto"
        //private void AgregarProducto()
        //{
        //    bool insertarDetalleProducto = true;
        //    foreach (DataRow row in dtProducto.Rows)
        //    {
        //        if (Convert.ToInt32(row["idproducto"]) == IdArticulo)
        //        {
        //            insertarDetalleProducto = false;
        //        }
        //    }
        //    if (insertarDetalleProducto)
        //    {
        //        //Agregar detalle a dtProducto
        //        DataRow row = dtProducto.NewRow();
        //        row["idproducto"] = formSeleccionarProducto.IdArticulo;
        //        row["codigo"] = formSeleccionarProducto.Codigo;
        //        row["nombre"] = formSeleccionarProducto.Articulo;
        //        row["idcategoria"] = formSeleccionarProducto.IdCategoria;
        //        row["precio_compra"] = formSeleccionarProducto.Precio_Compra;
        //        row["precio_venta"] = formSeleccionarProducto.Precio_Venta;
        //        row["stock"] = formSeleccionarProducto.Stock;
        //        row["idpresentacion"] = formSeleccionarProducto.IdPresentacion;
        //        row["descripcion"] = formSeleccionarProducto.Descripcion;
        //        row["ruta_imagen"] = formSeleccionarProducto.Ruta_Imagen;
        //        dtProducto.Rows.Add(row);
        //    }
        //    dgvArticulo.DataSource = dtProducto;
        //}
        #endregion
        #endregion

        #region MOSTRAR PROVEEDOR

        #region CARGA DE ITEMS EN LISTA
        // CARGA DE ITEMS AUTOCOMPLETE EN FUENTE - PROVEEDOR
        private AutoCompleteStringCollection itemsProveedor()
        {
            DataTable listaItems = NegocioProveedor.Buscar(cmbProveedor.Text);
            AutoCompleteStringCollection cadenaProveedor = new AutoCompleteStringCollection();
            foreach (DataRow row in listaItems.Rows)
            {
                cadenaProveedor.Add(Convert.ToString(row["RazonSocial"]));
            }
            return cadenaProveedor;
        }
        #endregion

        #region COMBOBOX
        //COMBOBOX CMBPROVEEDOR
        private void listaProveedor()
        {
            cmbProveedor.ValueMember = "IdProveedor";
            cmbProveedor.DisplayMember = "RazonSocial";
            cmbProveedor.DataSource = NegocioProveedor.Mostrar();
            cmbProveedor.SelectedValue = 0;
            autocompletarPoveedor();
        }
        #endregion

        #region METODO AUTOCOMPLETAR COMBOBOX
        //METODO PARA AUTOCOMPLETAR COMBOBOX PROVEEDOR
        private void autocompletarPoveedor()
        {
            try
            {
                cmbProveedor.AutoCompleteCustomSource = itemsProveedor();
                cmbProveedor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                cmbProveedor.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion
        #endregion

        #region SELECCIONAR ARTICULO
        private void formIngresarIngreso_dgvListadoDobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            IdArticulo = formSeleccionarProducto.IdArticulo;
            Codigo = formSeleccionarProducto.Codigo;
            Articulo = formSeleccionarProducto.Articulo;
            txtArticulo.Text = Articulo;
            IdCategoria = formSeleccionarProducto.IdCategoria;
            PrecioCompra = formSeleccionarProducto.PrecioCompra;
            txtPrecioCompra.Text = PrecioCompra.ToString("#0.###", CultureInfo.InvariantCulture);
            PrecioVenta = formSeleccionarProducto.PrecioVenta;
            txtPrecioVenta.Text = PrecioVenta.ToString("#0.###", CultureInfo.InvariantCulture);
            Stock = formSeleccionarProducto.Stock;
            txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
            IdPresentacion = formSeleccionarProducto.IdPresentacion;
            Descripcion = formSeleccionarProducto.Descripcion;
            RutaImagen = formSeleccionarProducto.RutaImagen;
        }
        #endregion

        #endregion

        #region LIMPIAR
        public void Limpiar()
        {
            IdProveedor = 0;
            txtIdIngreso.Text = string.Empty;
            txtIVA.Text = "21";
            cmbProveedor.SelectedValue = 0;
            dtpFecha.Text = DateTime.Now.ToString();
            cmbComprobante.SelectedIndex = 0;
            txtSerie.Text = string.Empty;
            txtCorrelativo.Text = string.Empty;
            IdArticulo = 0;
            txtArticulo.Text = string.Empty;
            txtStock.Text = "0";
            txtCantidad.Text = "1";
            txtPrecioCompra.Text = "0.00";
            txtPrecioVenta.Text = "0.00";
            dtpFechaProduccion.Text = DateTime.Now.ToString();
            dtpFechaVencimiento.Text = DateTime.Now.ToString();
            Total = 0;
            lblTotal.Text = string.Empty;
            txtPorcentajeGanancia.Text = "0";
            CrearListaDetalles();
            CrearListaProductos();
        }
        #endregion

        #region HABILITAR

        #region HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            cmbProveedor.Enabled = valor;
            dtpFecha.Enabled = valor;
            cmbComprobante.Enabled = valor;
            txtSerie.Enabled = valor;
            txtCorrelativo.Enabled = valor;
            txtStock.Enabled = false;
            txtCantidad.Enabled = valor;
            //Las dos líneas siguientes las maneja el control chkModificarPrecios
            //txtPrecio_Compra.Enabled = valor;
            //txtPrecio_Venta.Enabled = valor;
            dtpFechaProduccion.Enabled = valor;
            dtpFechaVencimiento.Enabled = valor;
        }
        #endregion

        #region HABILITAR BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(true);
                    chkPorcentajeGanancia.Enabled = true;
                    btnQuitar.Enabled = true;
                    btnAgregar.Enabled = true;
                    dtpFecha.Enabled = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = false;
                    btnAgregarProveedor.Enabled = true;
                    btnBuscarArticulo.Enabled = true;
                    lblABMIngreso.Text = "Nuevo ingreso";
                    cmbProveedor.Focus();
                    break;
                case 1: //EDITAR
                    Habilitar(true);
                    chkPorcentajeGanancia.Enabled = true;
                    btnQuitar.Enabled = true;
                    btnAgregar.Enabled = true;
                    btnInsertar.Enabled = false;
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    btnAgregarProveedor.Enabled = true;
                    btnBuscarArticulo.Enabled = true;
                    lblABMIngreso.Text = "Detalles";
                    cmbProveedor.Focus();
                    break;
                case 2: //CONSULTAR
                    Habilitar(false);
                    chkPorcentajeGanancia.Enabled = false;
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    btnInsertar.Visible = false;
                    btnAgregarProveedor.Enabled = false;
                    btnBuscarArticulo.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnAgregar.Enabled = false;
                    txtIdIngreso.Text = Convert.ToString(IdIngreso);
                    cmbProveedor.Text = Proveedor;
                    dtpFecha.Value = Fecha;
                    cmbComprobante.Text = TipoComprobante;
                    txtArticulo.Text = Articulo;
                    txtStock.Text = Convert.ToString(Stock);
                    txtCantidad.Text = Convert.ToString(Cantidad);
                    txtPrecioCompra.Text = Convert.ToString(PrecioCompra);
                    txtPrecioVenta.Text = Convert.ToString(PrecioVenta);
                    dtpFechaProduccion.Text = DateTime.Now.ToString();
                    dtpFechaVencimiento.Text = DateTime.Now.ToString();
                    lblTotal.Text = Convert.ToString(Total);
                    dgvDetalle.Select();
                    lblABMIngreso.Text = "Detalles";
                    break;
                case 3: //CANCELAR
                    Habilitar(false);
                    chkPorcentajeGanancia.Enabled = false;
                    btnQuitar.Enabled = false;
                    btnAgregar.Enabled = false;
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    btnAgregarProveedor.Enabled = false;
                    btnBuscarArticulo.Enabled = false;
                    txtIdIngreso.Text = Convert.ToString(IdIngreso);
                    cmbProveedor.Text = Proveedor;
                    dtpFecha.Value = Fecha;
                    cmbComprobante.Text = TipoComprobante;
                    txtArticulo.Text = Articulo;
                    txtStock.Text = Convert.ToString(Stock);
                    txtCantidad.Text = Convert.ToString(Cantidad);
                    txtPrecioCompra.Text = Convert.ToString(PrecioCompra);
                    txtPrecioVenta.Text = Convert.ToString(PrecioVenta);
                    dtpFechaProduccion.Text = DateTime.Now.ToString();
                    dtpFechaVencimiento.Text = DateTime.Now.ToString();
                    lblTotal.Text = Convert.ToString(Total);
                    btnEditar.Visible = true;
                    lblABMIngreso.Text = "Detalles";
                    break;
            }
        }

        #endregion

        #region BOTON NUEVO
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            HabilitarBotones();
            btnCancelar.Visible = true;
            Limpiar();
        }
        #endregion

        #region BOTON EDITAR
        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }
        #endregion

        #region BOTON CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            HabilitarBotones();
        }
        #endregion
        #endregion

        #region BUSCAR
        private void btnBuscarArticulo_Click(object sender, EventArgs e)
        {
            formSeleccionarProducto.dgvListado.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(formIngresarIngreso_dgvListadoDobleClick);
            formSeleccionarProducto.ShowDialog();
        }
        #endregion

        #region INSERTAR INGRESO

        #region METODO INSERTAR REGISTRO
        private void InsertarIngreso()
        {
            frmIngreso formIngreso = frmIngreso.GetInstancia();
            IdEmpleado = formIngreso.IdEmpleado;
            IVA = Convert.ToDecimal(txtIVA.Text);
            Fecha = dtpFecha.Value;
            TipoComprobante = cmbComprobante.Text;
            if (TipoComprobante != "NINGUNO")
            {
                Serie = txtSerie.Text;
                Correlativo = txtCorrelativo.Text;
            }
            else
            {
                Serie = string.Empty;
                Correlativo = string.Empty;
            }
            Cantidad = Convert.ToDecimal(txtCantidad.Text);
            PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text, miCultureInfo);
            PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text, miCultureInfo);
            FechaProduccion = dtpFechaProduccion.Value;
            FechaVencimiento = dtpFechaVencimiento.Value;
            string agregarActualizar = "";
            if (IdProveedor <= 0)
            {
                errorIcono.SetError(cmbProveedor, "Seleccione un proveedor");
            }
            else if (txtArticulo.Text == string.Empty)
            {
                errorIcono.SetError(txtArticulo, "Ingrese un artículo");
            }
            else if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                errorIcono.SetError(txtCantidad, "El stock final no puede ser 0 (cero)");
            }
            else if (PrecioVenta < PrecioCompra)
            {
                errorIcono.SetError(txtPrecioCompra, "El precio de venta no puede ser menor al precio de compra");
            }
            else if (PrecioVenta == 0)
            {
                errorIcono.SetError(txtPrecioVenta, "El precio de venta no puede ser 0 (cero)");
            }
            else if (dtpFechaVencimiento.Text == DateTime.Now.ToString())
            {
                errorIcono.SetError(dtpFechaVencimiento, "¡Atención!. El producto está vencido o bien debe ingresar la fecha de vencimiento correcta para que el sistema pueda informarle con exactitud que productos están próximos a expirar");
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            agregarActualizar = NegocioIngreso.Insertar(IdEmpleado, IdProveedor, Fecha, TipoComprobante, Serie.Trim().ToUpper(),
                                Correlativo.Trim().ToUpper(), IVA, "EMITIDO", Total, dtDetalles, dtArticulos);
                            NotificacionOk("Ingreso guardado correctamente", "Guardando");
                            cmbProveedor.Focus();
                            Limpiar();
                            break;
                        case 1://Editar
                            agregarActualizar = NegocioIngreso.Editar(IdIngreso, IdEmpleado, IdProveedor, Fecha, TipoComprobante, Serie.Trim().ToUpper(),
                                Correlativo.Trim().ToUpper(), IVA, "EMITIDO", Total, dtDetalles, dtArticulos);
                            NotificacionOk("Ingreso editado correctamente", "Editando");
                            Limpiar();
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
                HabilitarBotones();
            }
        }
        #endregion

        #region BOTON INSERTAR
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarIngreso();
            MostrarArticulos();
        }
        #endregion

        #region METODO AGREGAR DETALLE
        private void AgregarDetalle()
        {
            Cantidad = Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture);
            PrecioCompra = Convert.ToDecimal(txtPrecioCompra.Text, CultureInfo.InvariantCulture);
            PrecioVenta = Convert.ToDecimal(txtPrecioVenta.Text, CultureInfo.InvariantCulture);
            FechaProduccion = dtpFechaProduccion.Value;
            FechaVencimiento = dtpFechaVencimiento.Value;
            if (cmbComprobante.Text == "")
            {
                errorIcono.SetError(cmbComprobante, "Seleccione un comprobante de la lista");
            }
            else if (txtArticulo.Text == string.Empty || IdArticulo == 0)
            {
                errorIcono.SetError(txtArticulo, "Ingrese un artículo");
            }
            else if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                errorIcono.SetError(txtCantidad, "El stock ingresado no puede ser 0 (cero)");
            }
            else if (PrecioCompra == 0)
            {
                errorIcono.SetError(txtPrecioCompra, "Ingrese el precio de compra del artículo");
            }
            else if (PrecioVenta < PrecioCompra)
            {
                errorIcono.SetError(txtPrecioVenta, "El precio de venta no puede ser menor al precio de compra");
            }
            else if (PrecioVenta == 0)
            {
                errorIcono.SetError(txtPrecioVenta, "El precio de venta no puede ser 0 (cero)");
            }
            else if (FechaVencimiento.Date < DateTime.Now.Date)
            {
                errorIcono.SetError(dtpFechaVencimiento, "¡Atención!. El producto está vencido o bien debe ingresar la fecha de vencimiento correcta para que el sistema pueda informarle con exactitud que productos están próximos a expirar");
            }
            else
            {
                try
                {
                    bool insertarDetalle = true;
                    bool insertarDetalleProducto = true;
                    foreach (DataRow row in dtDetalles.Rows)
                    {
                        if (Convert.ToInt32(row["IdArticulo"]) == IdArticulo)
                        {
                            insertarDetalle = false;
                            //NotificacionError("El artículo ya se encuentra ingresado.Si éste pertenece a otro 
                            //proveedor selecciónelo en la lista de la esquina superior izquierda de ésta ventana", "Error");
                            //Total = Total - Convert.ToDecimal(row["subtotal"]);
                            decimal subTotal = Cantidad * PrecioCompra;
                            Total = Total + subTotal;
                            row["IdDetalleIngreso"] = IdDetalleIngreso;
                            row["IdArticulo"] = IdArticulo;
                            row["Articulo"] = Articulo;
                            row["PrecioCompra"] = PrecioCompra;
                            row["PrecioVenta"] = PrecioVenta;
                            row["Cantidad"] = Convert.ToDecimal(row["Cantidad"]) + Cantidad;
                            row["FechaProduccion"] = FechaProduccion;
                            row["FechaVencimiento"] = FechaVencimiento;
                            row["Subtotal"] = Convert.ToDecimal(row["Cantidad"]) * Convert.ToDecimal(row["PrecioCompra"]);
                        }
                    }
                    if (insertarDetalle)
                    {
                        decimal subTotal = Cantidad * PrecioCompra;
                        Total = Total + subTotal;
                        //Agregar detalle a dtDetalle
                        DataRow row = dtDetalles.NewRow();
                        row["IdDetalleIngreso"] = IdDetalleIngreso;
                        row["IdArticulo"] = IdArticulo;
                        row["Articulo"] = Articulo;
                        row["PrecioCompra"] = PrecioCompra;
                        row["PrecioVenta"] = PrecioVenta;
                        row["Cantidad"] = Cantidad;
                        row["FechaProduccion"] = FechaProduccion;
                        row["FechaVencimiento"] = FechaVencimiento;
                        row["Subtotal"] = subTotal;
                        dtDetalles.Rows.Add(row);
                    }
                    // SE LLENA EL DATATABLE dtProducto PARA PODER ACTUALIZAR SUS VALORES
                    foreach (DataRow row in dtArticulos.Rows)
                    {
                        if (Convert.ToInt32(row["IdArticulo"]) == IdArticulo)
                        {
                            insertarDetalleProducto = false;
                            row["IdArticulo"] = IdArticulo;
                            row["Codigo"] = Codigo;
                            row["Articulo"] = Articulo;
                            row["IdCategoria"] = IdCategoria;
                            row["PrecioCompra"] = PrecioCompra;
                            row["PrecioVenta"] = PrecioVenta;
                            row["Stock"] = Convert.ToDecimal(row["stock"]) + Cantidad;
                            row["IdPresentacion"] = IdPresentacion;
                            row["Descripcion"] = Descripcion;
                            row["RutaImagen"] = RutaImagen;
                        }
                    }
                    if (insertarDetalleProducto)
                    {
                        //Agregar detalle a dtProducto
                        DataRow row = dtArticulos.NewRow();
                        row["IdArticulo"] = IdArticulo;
                        row["Codigo"] = Codigo;
                        row["Articulo"] = Articulo;
                        row["IdCategoria"] = IdCategoria;
                        row["PrecioCompra"] = PrecioCompra;
                        row["PrecioVenta"] = PrecioVenta;
                        row["Stock"] = Stock + Cantidad;
                        row["IdPresentacion"] = IdPresentacion;
                        row["Descripcion"] = Descripcion;
                        row["RutaImagen"] = RutaImagen;
                        dtArticulos.Rows.Add(row);
                    }
                    lblTotal.Text = Total.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                HabilitarBotones();
            }
        }
        #endregion

        #endregion

        #region BOTON AGREGAR
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
            dgvArticulo.Focus();
            dgvDetalle.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
        #endregion

        #region BOTON QUITAR
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (ctrlSeleccionado)
                {
                    case 0:
                        {
                            #region FUNCA MAL
                            //int indiceFila = dgvDetalle.CurrentCell.RowIndex;
                            //DataRow row = dtDetalles.Rows[indiceFila];
                            ////Disminuir el total pagado
                            //Total = Total - Convert.ToDecimal(row["Subtotal"].ToString());
                            //lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                            ////foreach (DataRow rowDetalle in dtDetalle.Rows)
                            //foreach (DataGridViewRow rowDetalle in dgvDetalle.Rows)
                            //{
                            //    foreach (DataRow rowArticulo in dtArticulos.Rows)
                            //    {
                            //        //if (rowDetalle["idproducto"] == rowProducto["idproducto"])
                            //        if (Convert.ToInt32(rowDetalle.Cells["IdArticulo"].Value) == Convert.ToInt32(rowArticulo["IdArticulo"]))
                            //        {
                            //            dtArticulos.Rows.Remove(rowArticulo);
                            //        }
                            //    }
                            //}
                            //dtDetalles.Rows.Remove(row);
                            //break;
                            #endregion
                            foreach (DataRow row in dtDetalles.Rows)
                            {

                                while (Convert.ToInt32(row["IdArticulo"]) == IdArticulo)
                                {
                                    Total = Total - Convert.ToDecimal(row["Subtotal"].ToString());
                                    lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                                    dtDetalles.Rows.Remove(row);
                                }
                            }
                            break;
                        }
                    case 2:
                        {
                            int idDetalleIngreso;
                            string Respuesta = "";
                            DialogResult Opcion;
                            Opcion = MessageBox.Show(
                                "¿Realmente desea eliminar el item seleccionado?",
                                "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.Yes)
                            {
                                idDetalleIngreso = Convert.ToInt32(dgvDetalle.CurrentRow.Cells[1].Value);
                                Respuesta = NegocioIngreso.Eliminar(Convert.ToInt32(idDetalleIngreso));
                                if (Respuesta.Equals("OK"))
                                {
                                    NotificacionOk("El item se eliminó correctamente", "Eliminando");
                                    MostrarDetalle();
                                }
                                else
                                {
                                    NotificacionError("El registro no se puede eliminar, debe anular el ingreso completo y volver a ingresar los artículos.", "Error");
                                }
                                //Mostrar();
                            }
                            break;
                        }
                }
            }
            catch //(Exception ex)
            {
                NotificacionError("No hay ningún item añadido.", "Error");
            }
        }
        #endregion

        #region DATETIMEPICKER
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            Fecha = dtpFecha.Value;
        }
        #endregion

        #region COMBOBOX COMPROBANTE
        private void cmbComprobante_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbComprobante.SelectedIndex == 0)
            {
                txtSerie.Visible = false;
                txtSerie.Text = string.Empty;
                Serie = string.Empty;
                txtCorrelativo.Visible = false;
                txtCorrelativo.Text = string.Empty;
                Correlativo = string.Empty;
            }
            else
            {
                txtSerie.Visible = true;
                txtCorrelativo.Visible = true;
            }
        }
        #endregion

        #region TEXTBOX PORCENTAJE DE GANANCIA
        private void txtPorcentajeGanancia_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal precioCompra = 0.00m, precioVenta = 0.00m, porcentajeGanancia = 0.00m;
                precioCompra = Convert.ToDecimal(txtPrecioCompra.Text, CultureInfo.InvariantCulture);
                porcentajeGanancia = Convert.ToDecimal(txtPorcentajeGanancia.Text, CultureInfo.InvariantCulture);
                precioVenta = precioCompra * (1 + porcentajeGanancia / 100);
                txtPrecioVenta.Text = precioVenta.ToString("#0.##", CultureInfo.InvariantCulture);
            }
            catch { }
        }
        #endregion

        #region TEXTBOX PRECIO DE COMPRA
        private void txtPrecio_Compra_TextChanged(object sender, EventArgs e)
        {
            if (chkPorcentajeGanancia.Checked)
            {
                try
                {
                    decimal precioCompra = 0.00m, precioVenta = 0.00m, porcentajeGanancia = 0.00m;
                    precioCompra = Convert.ToDecimal(txtPrecioCompra.Text, CultureInfo.InvariantCulture);
                    porcentajeGanancia = Convert.ToDecimal(txtPorcentajeGanancia.Text, CultureInfo.InvariantCulture);
                    precioVenta = precioCompra * (1 + porcentajeGanancia / 100);
                    txtPrecioVenta.Text = precioVenta.ToString("#0.##", CultureInfo.InvariantCulture);
                }
                catch { }
            }
        }
        #endregion

        #region COMBOBOX PROVEEDOR
        private void cmbProveedor_SelectedValueChanged(object sender, EventArgs e)
        {
            IdProveedor = Convert.ToInt32(cmbProveedor.SelectedValue);
            DataTable IngresoProveedor = NegocioIngreso.Buscar(null, null, IdProveedor);
        }
        #endregion

        #region BOTON AGREGAR PROVEEDOR
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            formIngresarProveedor.ShowDialog();
        }
        #endregion

        #region BOTON INSERTAR PROVEEDOR DEL FORMULARIO "frmIngresarProveedor"
        private void btnInsertarProveedor_Click(object sender, EventArgs e)
        {
            listaProveedor();
        }
        #endregion

        #region TEXBOX PORCENTAJE DE GANANCIA - EVENTO LEAVE
        private void txtPorcentajeGanancia_Leave(object sender, EventArgs e)
        {
            if (txtPorcentajeGanancia.Text == "" || txtPorcentajeGanancia.Text == string.Empty || txtPorcentajeGanancia.Text == "0")
            {
                txtPorcentajeGanancia.Text = "0.00";
            }
        }
        #endregion

        #region TEXTBOX PRECIO DE COMPRA - EVENTO LEAVE
        private void txtPrecioCompra_Leave(object sender, EventArgs e)
        {
            if (txtPrecioCompra.Text == "" || txtPrecioCompra.Text == string.Empty || txtPrecioCompra.Text == "0")
            {
                txtPrecioCompra.Text = "0.00";
            }
        }
        #endregion

        #region TEXTBOX PRECIO DE VENTA - EVENTO LEAVE
        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            if (txtPrecioVenta.Text == "" || txtPrecioVenta.Text == string.Empty || txtPrecioVenta.Text == "0")
            {
                txtPrecioVenta.Text = "0.00";
            }
        }
        #endregion

        #region DATAGRIDVIEW "dgvDetalle" - EVENTO CLICK
        private void dgvDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDetalleClick();
            }
            catch { }
        }
        #endregion

        #region CLICK EN DGVDETALLE
        private void dgvDetalleClick()
        {
            try
            {
                IdDetalleIngreso = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["IdDetalleIngreso"].Value);
                IdArticulo = Convert.ToInt32(dgvDetalle.CurrentRow.Cells["IdArticulo"].Value);
                DataTable dtArticulo = NegocioArticulo.Buscar(IdArticulo); // Busco id del articulo y almaceno
                DataRow row = dtArticulo.Rows[0];
                Stock = Convert.ToInt32(row["Stock"]);
                Articulo = Convert.ToString(dgvDetalle.CurrentRow.Cells["Articulo"].Value);
                PrecioCompra = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["PrecioCompra"].Value);
                PrecioVenta = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["PrecioVenta"].Value);
                Cantidad = Convert.ToDecimal(dgvDetalle.CurrentRow.Cells["Cantidad"].Value);
                FechaProduccion = Convert.ToDateTime(dgvDetalle.CurrentRow.Cells["FechaProduccion"].Value);
                FechaVencimiento = Convert.ToDateTime(dgvDetalle.CurrentRow.Cells["FechaVencimiento"].Value);

                txtArticulo.Text = Convert.ToString(Articulo);
                txtPrecioCompra.Text = Convert.ToString(PrecioCompra, CultureInfo.InvariantCulture);
                txtPrecioVenta.Text = Convert.ToString(PrecioVenta, CultureInfo.InvariantCulture);
                txtStock.Text = Convert.ToString(Stock);
                txtCantidad.Text = Convert.ToString(Cantidad, CultureInfo.InvariantCulture);
                dtpFechaProduccion.Value = Convert.ToDateTime(FechaProduccion);
                dtpFechaVencimiento.Value = Convert.ToDateTime(FechaVencimiento);
                btnQuitar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region EVENTOS TECLADO

        #region KEYDOWN TECLA ESCAPE
        //EVENTO QUE SE EJECUTARÁ AL PRESIONAR LA TECLA ESCAPE
        private void cerrarForm(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (cmbProveedor.Focused || !cmbProveedor.Enabled)
                {
                    Close();
                }
                else
                {
                    e.Handled = true;
                    cmbProveedor.Focus();
                }
            }
        }
        #endregion

        #region TECLA ENTER EN CONTROL
        private void pasarControlSiguiente(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }
        #endregion

        #region CERRRAR FORMULARIO
        private void frmIngresarIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion
        #endregion

        #region VALIDADION DE CONTROLES

        #region METODO QUE VALIDA UN CONTROL DE TIPO MATERIALSINGLELINETEXTFIELD
        private void validarLongitud(MaterialSingleLineTextField control, int maxCaracteres, KeyPressEventArgs e)
        {
            //VALIDANDO LONGITUD DE CAMPO
            if (control.TextLength > maxCaracteres)
            {
                errorIcono.SetError(control, "Sólo puede ingresar un máximo de " + maxCaracteres + " carateres en este campo.");
                if (Char.IsControl(e.KeyChar) || control.SelectedText.Length > 0)
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
                control.SelectionStart = control.TextLength;
            }
            pasarControlSiguiente(e);
        }
        #endregion

        /*
        #region PASAR TEXT A MAYÚSCULAS - ESTA SIN USAR
        private void pasarAMayuscula(MaterialSingleLineTextField control)
        {
            if (!String.IsNullOrEmpty(control.Text))
            {
                control.Text = control.Text.ToUpper();
                control.SelectionStart = control.TextLength;
            }
        }
        #endregion
        */

        #region VALIDACION DE TIPO DE DATOS QUE SE INGRESARAN EN TEXTBOX

        #region SOLO TEXTO
        private void ingresarTexto(KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region SOLO NUMEROS
        private void ingresarNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (e.KeyChar == '.')
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion
        #endregion

        #region TEXTBOX IVA
        private void txtIVA_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region COMBOBOX PROVEEDOR
        private void cmbProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion

        #region DATETIMEPICKER FECHA
        private void dtpFecha_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
        }
        #endregion

        #region COMBOBOX COMPROBANTE
        private void cmbComprobante_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
        #endregion

        #region TEXTBOX SERIE
        private void txtSerie_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLongitud(txtSerie, 4, e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX CORRELATIVO
        private void txtCorrelativo_KeyPress(object sender, KeyPressEventArgs e)
        {
            validarLongitud(txtCorrelativo, 7, e);
            if (e.KeyChar == (char)(Keys.Enter))
            {
                e.Handled = true;
                txtCorrelativo.SelectNextControl(btnBuscarArticulo, false, true, false, false);
            }
        }
        #endregion

        #region TEXTBOX STOCK
        private void txtStock_Final_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region DATAGRIDVIEW's
        private void dgvEnter(DataGridView control, KeyEventArgs e)
        {
            if (control == dgvArticulo)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    control.Focus();
                    control.CurrentRow.Selected = true;
                    clickCeldadgvArticulo();
                    txtCantidad.Text = "1";
                    if (!IngresoRapido)
                    {
                        txtCantidad.SelectAll();
                    }
                    else
                    {
                        btnAgregar.PerformClick();
                        txtIngresoRapido.SelectAll();
                    }
                }
                else if (e.KeyCode == Keys.Right)
                {
                    dgvDetalle.Focus();
                }
            }
            else if (control == dgvDetalle)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    e.Handled = true;
                    control.CurrentRow.Selected = true;
                    dgvDetalleClick();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    dgvArticulo.Focus();
                }
            }
        }
        #endregion

        #region CHECKBOX PORCENTAJE DE GANANCIA
        private void chkPorcentajeGanancia_CheckedChanged(object sender, EventArgs e)
        {

            if (chkModificarPrecios.Checked)
            {
                if (chkPorcentajeGanancia.Checked)
                {
                    txtPorcentajeGanancia.Visible = true;
                    lblPorcentaje.Visible = true;
                    txtPorcentajeGanancia.SelectAll();
                }
                else
                {
                    txtPorcentajeGanancia.Visible = false;
                    lblPorcentaje.Visible = false;
                    txtPrecioCompra.SelectAll();
                }
            }
        }
        #endregion

        #region TEXTBOX PORCENTAJE DE GANANCIA
        private void txtPorcentajeGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX PRECIO DE COMPRA
        private void txtPrecio_Compra_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region TEXTBOX PRECIO DE VENTA
        private void txtPrecio_Venta_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            pasarControlSiguiente(e);
        }
        #endregion

        #region DATETIMEPICKER FECHA DE PRODUCCION
        private void dtpFechaProduccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
        }
        #endregion

        #region DATETIMEPICKER FECHA DE VENCIMIENTO
        private void dtpFechaVencimiento_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
        }
        #endregion

        #endregion

        #region BOTON SALIR
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region TIMER
        private void tFechaHora_Tick(object sender, EventArgs e)
        {
            if (ctrlSeleccionado == 0 || ctrlSeleccionado == 1)
            {
                dtpFecha.Value = DateTime.Now;
            }
        }
        #endregion

        #region ACTUALIZAR DATAGRIDVIEW ARTÍCULO
        private void frmIngresarArticulo_btnInsertar_Click(object sender, EventArgs e)
        {
            MostrarArticulos();
        }
        #endregion

        #region BOTON AGREGAR ARTÍCULO
        private void btnAgregarArtículo_Click(object sender, EventArgs e)
        {
            frmIngresarArticulo formIngresarArticulo = frmIngresarArticulo.GetInstancia();
            formIngresarArticulo.btnInsertar.Click += new EventHandler(frmIngresarArticulo_btnInsertar_Click);
            formIngresarArticulo.Show();
            formIngresarArticulo.BringToFront();
        }
        #endregion

        #region CLICK EN "dgvArticulo"
        private void clickCeldadgvArticulo()
        {
            try
            {
                IdArticulo = Convert.ToInt32(dgvArticulo.CurrentRow.Cells["IdArticulo"].Value);
                Codigo = Convert.ToString(dgvArticulo.CurrentRow.Cells["Codigo"].Value);
                Articulo = Convert.ToString(dgvArticulo.CurrentRow.Cells["Articulo"].Value);
                txtArticulo.Text = Articulo;
                IdCategoria = Convert.ToInt32(dgvArticulo.CurrentRow.Cells["IdCategoria"].Value);
                PrecioCompra = Convert.ToDecimal(dgvArticulo.CurrentRow.Cells["PrecioCompra"].Value);
                txtPrecioCompra.Text = PrecioCompra.ToString("0#.0#", CultureInfo.InvariantCulture);
                PrecioVenta = Convert.ToDecimal(dgvArticulo.CurrentRow.Cells["PrecioVenta"].Value);
                txtPrecioVenta.Text = PrecioVenta.ToString("0#.0#", CultureInfo.InvariantCulture);
                Stock = Convert.ToDecimal(dgvArticulo.CurrentRow.Cells["Stock"].Value);
                txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
                IdPresentacion = Convert.ToInt32(dgvArticulo.CurrentRow.Cells["IdPresentacion"].Value);
                Descripcion = Convert.ToString(dgvArticulo.CurrentRow.Cells["Descripcion"].Value);
                RutaImagen = Convert.ToString(dgvArticulo.CurrentRow.Cells["RutaImagen"].Value);
            }
            catch { }
        }
        #endregion

        #region DATAGRIDVIEW "dgvArticulo"
        private void dgvArticulo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickCeldadgvArticulo();
        }
        #endregion

        #region TEXTBOX INGRESO RÁPIDO
        #region EVENTO TEXTCHANGED
        private void txtIngresoRapido_TextChanged(object sender, EventArgs e)
        {
            if (txtIngresoRapido.TextLength > 0)
            {
                dgvArticulo.DataSource = NegocioArticulo.Buscar(txtIngresoRapido.Text);
            }
            else
            {
                MostrarArticulos();
            }
        }
        #endregion

        #region EVENTO KEYDOWN
        private void txtIngresoRapido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvArticulo.Focus();
                if (dgvArticulo.Rows.Count == 1)
                {
                    dgvArticulo.Rows[0].Selected = true;
                    clickCeldadgvArticulo();
                    txtCantidad.Text = "1";
                    if (!IngresoRapido)
                    {
                        txtCantidad.SelectAll();
                    }
                    else
                    {
                        btnAgregar.PerformClick();
                        txtIngresoRapido.SelectAll();
                    }
                }
            }
        }
        #endregion
        #endregion

        #region CHECKS PORCENTAJE DE GANANCIAS

        private void chkPorcentajeGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            pasarControlSiguiente(e);
            pasarControlSiguiente(e);
        }

        private void chkPorcentajeGanancia_Enter(object sender, EventArgs e)
        {
            if (chkPorcentajeGanancia.Focused)
                chkPorcentajeGanancia.ForeColor = Color.Red;
            else
                chkPorcentajeGanancia.ForeColor = Color.Black;
        }
        #endregion

        #region CHECK INGRESO RÁPIDO
        private void chkIngresoRapido_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIngresoRapido.CheckState == CheckState.Checked)
            {
                IngresoRapido = true;
            }
            else
            {
                IngresoRapido = false;
            }
            txtIngresoRapido.SelectAll();
        }
        #endregion

        #region ENTER EN DATAGRIDVIEW ARTÍCULOS
        private void dgvArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            dgvEnter(dgvArticulo, e);
        }
        #endregion

        #region ENTER EN DATAGRIDVIEW DETALLE
        private void dgvDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            dgvEnter(dgvDetalle, e);
        }
        #endregion

        #region PINTAR CELDAS DE TABLE LAYOUTPANEL
        private void pintarCeldas_CellPaint(TableLayoutPanel control, TableLayoutCellPaintEventArgs e)
        {
            for (int i = 0; i <= control.ColumnCount; i++)
            {
                for (int j = 0; j <= control.RowCount; j++)
                {
                    using (SolidBrush brush = new SolidBrush(Color.WhiteSmoke))
                        e.Graphics.FillRectangle(brush, e.ClipRectangle);
                }
            }
        }

        // EVENTO CELLPAINT DE TABLE LAYOUTPANEL
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutPanel tlPanel = sender as TableLayoutPanel;
            pintarCeldas_CellPaint(tlPanel, e);
        }
        #endregion

        #region CHECKBOX MODIFICAR PRECIOS - EVENTO CHECKEDCHANGED
        private void chkModificarPrecios_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModificarPrecios.Checked)
            {
                chkPorcentajeGanancia.Visible = true;
                txtPrecioCompra.Enabled = true;
                txtPrecioVenta.Enabled = true;
                chkPorcentajeGanancia.Focus();
            }
            else
            {
                chkPorcentajeGanancia.Visible = false;
                chkPorcentajeGanancia.CheckState = CheckState.Unchecked;
                txtPorcentajeGanancia.Visible = false;
                txtPorcentajeGanancia.Text = "0.00";
                lblPorcentaje.Visible = false;
                txtPrecioCompra.Enabled = false;
                txtPrecioCompra.Text = PrecioCompra.ToString("#0.###", CultureInfo.InvariantCulture); //Convert.ToString(Precio_Compra);
                txtPrecioVenta.Enabled = false;
                txtPrecioVenta.Text = PrecioVenta.ToString("#0.###", CultureInfo.InvariantCulture); //Convert.ToString(Precio_Venta);
            }
        }
        #endregion

        #region EXPANDIR Y CONTRAER FORMULARIO
        private void btnExpandirContraer_Click(object sender, EventArgs e)
        {
            if (!Expandir)
            {
                Width = 760;
                Expandir = true;
            }
            else
            {
                Width = 1140;
                Expandir = false;
            }
        }

        private void frmIngresarIngreso_ResizeEnd(object sender, EventArgs e)
        {
            if (tableLayoutPanel7.Width < Limite)
            {
                Width = 760;
                Expandir = true;
            }
            else
            {
                Width = 1140;
                Expandir = false;
            }
        }
        #endregion

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            validar.CantidadMinima((TextBox)sender, e);
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.IngresarNumeroDecimal(e);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.IngresarNumeroDecimal(e);
        }
    }
}