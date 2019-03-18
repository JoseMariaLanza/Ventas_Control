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
using System.IO;
using System.Globalization;

using DevComponents.DotNetBar.Metro;

using CapaPresentacion.Properties;

namespace CapaPresentacion
{
    public partial class frmIngresarVentaCopiaOriginal : MetroForm
    {
        public int ctrlSeleccionado; // ver luego si es mejor eliminar esta variable y mostrar el detalle de la venta en un fomulario aparte
        #region variables venta general
        public int IdVenta;
        public int IdTrabajador;
        public string Trabajador;
        public int IdCliente;
        public string Cliente;
        public DateTime Fecha;
        public string Tipo_Comprobante;
        public string Serie;
        public string Correlativo;
        public decimal IVA;

        #region variables articulo
        //public int IdPromo;
        public string Promo;

        public int IdDetalle_Venta;
        public int IdArticulo;
        public string Codigo;
        public string Articulo;
        public string Presentacion;
        public decimal Stock;
        public decimal Precio_Venta;
        public string Ruta_Imagen;

        DataTable dtInfoProducto; // variable para almacenar el resultado de la búsqueda del producto y 
                                  // mostrar la información adicional en el cuadro desplegable

        //ingreso rápido
        //DataTable dtArticulo = new DataTable();

        public decimal Cantidad;
        public decimal Descuento;
        #endregion

        #region VENTA DE PROMOCIONES
        DataTable dtVenta_Descuento;
        int IdDescuento;
        int Cantidad_Descuentos;
        bool VenderPromo = false;
        //DataTable dtArticulos_Descuento;
        #endregion

        DataTable dtDetalleVenta; // variable para almacenar los items que se vayan agregando a la venta

        public decimal Total; // Total general de la venta

        #region VARIABLES DEUDA
        DataTable dtDeuda;
        public int Cantidad_Pagos;
        public decimal Total_Pagado;
        public decimal Interes;
        public string Descripcion;
        #endregion

        #region VARIABLES DETALLE DE LA DEUDA
        DataTable dtDetalle_Deuda;
        public int Numero_Pago;
        public decimal Monto;
        public DateTime Fecha_Pago;
        #endregion

        #endregion

        CultureInfo miCultureInfo = new CultureInfo("en"); // Sirve para establecer el uso del . (punto) 
        // en vez de la , (coma) para números decimales

        public frmIngresarVentaCopiaOriginal()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            dtpFecha.Format = DateTimePickerFormat.Custom;
            dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm:ss";
            dtpFecha.Enabled = false;
            txtPromo.Hint = "Promoción";
            //MouseDown += new MouseEventHandler(ClickDerecho);
            //foreach (Control ctrl in this.Controls)
            //{
            //    //ctrl.ContextMenuStrip = cmsMenuContextual;
            //    //cmsMenuContextual.Enabled = false;
            //    //ctrl.MouseDown += new MouseEventHandler(ClickDerecho);
            //}
        }

        //private void atajos(object sender, KeyPressEventArgs e)
        //{
        //    TextBox txtBox = (TextBox)sender;
        //    MaterialSingleLineTextField materialTxtBox = (MaterialSingleLineTextField)sender;
        //    ComboBox cmbBox = (ComboBox)sender;
        //    txtBox.ShortcutsEnabled = false; // sólo sirve para deshabilitar los atajos en un textbox (pero desactiva ctrl + c, ctrl + v, etc sin hacer distinción)
        //    //materialTxtBox.KeyDown
        //    if (cmbBox.button == MouseButtons.Right)
        //    {
        //
        //    }
        //}

        private void frmVenta_Load(object sender, EventArgs e)
        {
            cargarClienteGral();
            DeudaCliente();
            //CrearDetalleArticulos();
            CrearDetalleVenta();
            OcultarColumnasDetalle();
            CrearDeuda();
            CrearDetalleDeuda();
            CrearVenta_Descuento();
            Mostrar();
            txtCodigoBarras.SelectAll();
        }

        #region INSTANCIACION

        private static frmIngresarVenta _Instancia;

        public static frmIngresarVenta Instancia
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

        public static frmIngresarVenta GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarVenta();
            }
            return Instancia;
        }

        private void frmIngresar_Venta_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region EVENTO CLICK DERECHO CONTROLES FORMULARIO - DESHABILITAR MENU CONTEXTUAL
        private void ClickDerecho(object sender, MouseEventArgs e)
        {
            Control ctrl = (Control)sender;
            if (e.Button == MouseButtons.Right)
            {
                ctrl.ContextMenuStrip = cmsMenuContextual;
                //MessageBox.Show("El botón derecho del mouse está deshabilitado por motivos de seguridad.", "Acción no permitida.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region METODO ANULAR CTRL + V
        private void DeshabilitarPegado(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) && e.KeyChar == 22) // 22 = tecla v, es decir si se presiona la tecla ctrl + v, la función
                                                              // de pegado se deshabilitará
            {
                e.Handled = true;
            }
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

        #region DATAGRIDVIEW ARTÍCULOS

        #region MOSTRAR ARTÍCULOS

        #region CARGAR PRODUCTOS EN GRILLA
        private void Mostrar()
        {
            dgvArticulos.DataSource = NegocioProducto.Mostrar();
            OcultarColumnas();
            NombreColumnas();
        }
        #endregion

        #region BUSQUEDA

        #region BUSCAR ARTICULO POR NOMBRE
        private void MostrarArticuloVentaNombre()
        {
            dgvArticulos.DataSource = NegocioProducto.BuscarNombre(txtBuscar.Text);
            // Método ocultar columnas
        }
        #endregion

        #region BUSCAR ARTICULO POR CODIGO
        private void MostrarArticuloVentaCodigo()
        {
            dgvArticulos.DataSource = NegocioProducto.BuscarCodigo(txtBuscarCodigo.Text);
            // Método ocultar Columnas
        }
        #endregion

        #region BUSCAR ARTICULO POR CATEGORIAS
        private void MostrarArticuloVentaCategoria()
        {
            dgvArticulos.DataSource = NegocioProducto.BuscarProductoCategoria(txtBuscar.Text, txtBuscarCategoria.Text);
            // Método ocultar columnas
        }
        #endregion

        #region CONTROLES BUSQUEDA
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarArticuloVentaNombre();
                if (txtBuscar.TextLength > 0)
                {
                    btnLimpiarBusquedaNombre.Visible = true;
                    txtBuscar.Width = 168;
                }
                else
                {
                    btnLimpiarBusquedaNombre.Visible = false;
                    txtBuscar.Width = 190;
                }
            }
            catch { }
        }

        private void txtBuscarCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarArticuloVentaCodigo();
                if (txtBuscarCodigo.TextLength > 0)
                {
                    btnLimpiarCodigo.Visible = true;
                    txtBuscar.Width = 196;
                }
                else
                {
                    btnLimpiarCodigo.Visible = false;
                    txtBuscar.Width = 175;
                }
            }
            catch { }
        }

        private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        {
            try
            {
                MostrarArticuloVentaCategoria();
                if (txtBuscarCategoria.TextLength > 0)
                {
                    btnLimpiarBusquedaCategoria.Visible = true;
                    txtBuscar.Width = 132;
                }
                else
                {
                    btnLimpiarBusquedaCategoria.Visible = false;
                    txtBuscar.Width = 154;
                }
            }
            catch { }
        }

        private void btnLimpiarBusquedaNombre_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtBuscar.SelectAll();
        }

        private void btnLimpiarCodigo_Click(object sender, EventArgs e)
        {
            txtBuscarCodigo.Text = "";
            txtBuscarCodigo.SelectAll();
            Mostrar();
        }

        private void btnLimpiarBusquedaCategoria_Click(object sender, EventArgs e)
        {
            txtBuscarCategoria.Text = "";
            txtBuscarCategoria.SelectAll();
        }
        #endregion

        #endregion

        #region NOMBRAR COLUMNAS
        private void NombreColumnas()
        {
            dgvArticulos.Columns["codigo"].HeaderText = "Código";
            dgvArticulos.Columns["nombre"].HeaderText = "Artículo";
            dgvArticulos.Columns["Categoria"].HeaderText = "Categoría";
            dgvArticulos.Columns["Presentacion"].HeaderText = "";
            //dgvArticulos.Columns["precio_compra"].HeaderText = "Precio de compra";
            //dgvArticulos.Columns["precio_compra"].DefaultCellStyle.Format = "#0.##";
            dgvArticulos.Columns["precio_venta"].HeaderText = "Precio";
            dgvArticulos.Columns["precio_venta"].DefaultCellStyle.Format = "#0.##";
            dgvArticulos.Columns["stock"].HeaderText = "Stock";
            dgvArticulos.Columns["stock"].DefaultCellStyle.Format = "#0.###";
        }
        #endregion

        #region OCULTAR COLUMNAS
        private void OcultarColumnas()
        {
            dgvArticulos.Columns["idproducto"].Visible = false;
            dgvArticulos.Columns["idcategoria"].Visible = false;
            dgvArticulos.Columns["precio_compra"].Visible = false;
            dgvArticulos.Columns["idpresentacion"].Visible = false;
            dgvArticulos.Columns["descripcion"].Visible = false;
            dgvArticulos.Columns["ruta_imagen"].Visible = false;
        }
        #endregion

        #region CREAR LISTA ARTICULO
        //private void CrearListaVenta()
        //{
        //    dtVenta = new DataTable("DetalleVenta");
        //    dtVenta.Locale = miCultureInfo;
        //    dtVenta.Columns.Add("iddetalle_ingreso", System.Type.GetType("System.Int32"));
        //    dtVenta.Columns.Add("idproducto", System.Type.GetType("System.Int32"));
        //    dtVenta.Columns.Add("articulo", System.Type.GetType("System.String"));
        //    dtVenta.Columns.Add("cantidad", System.Type.GetType("System.Decimal"));
        //    dtVenta.Columns.Add("precio_venta", System.Type.GetType("System.Decimal"));
        //    dtVenta.Columns.Add("descuento", System.Type.GetType("System.Decimal"));
        //    dtVenta.Columns.Add("subtotal", System.Type.GetType("System.Decimal"));
        //    // Relacionar DataGridView con DataTable dtDetalle
        //    dgvVenta.DataSource = dtVenta;
        //    NombreColumnas();
        //    OcultarColumnas();
        //}
        #endregion

        #endregion

        #region INFORMACIÓN DEL ARTÍCULO
        private void LlenarDetalleProducto()
        {
            try
            {
                //decimal precio_compra, precio_venta, stock;
                decimal stock;
                dtInfoProducto = NegocioProducto.BuscarProductoId(Convert.ToInt32(dgvArticulos.CurrentRow.Cells[0].Value));
                DataRow row = dtInfoProducto.Rows[0];
                frmInfo formInfo = frmInfo.GetInstancia();
                formInfo.lblIdProducto.Text = Convert.ToString(row["idproducto"]);
                formInfo.lblCodigo.Text = Convert.ToString(row["codigo"]);
                formInfo.lblNombre.Text = Convert.ToString(row["nombre"]);
                //precio_compra = Convert.ToDecimal
                formInfo.lblPrecioCompra.Text = Convert.ToString(row["precio_compra"]);
                formInfo.lblPrecioVenta.Text = Convert.ToString(row["precio_venta"]);
                stock = Convert.ToDecimal(row["stock"]);
                formInfo.lblStock.Text = stock.ToString("#0.###", CultureInfo.InvariantCulture);
                formInfo.pbxImagenProducto.ImageLocation = Convert.ToString(row["ruta_imagen"]);
                formInfo.txtDescripcion.Text = Convert.ToString(row["descripcion"]);
                formInfo.lblCategoria.Text = Convert.ToString(row["Categoria"]);
                formInfo.lblPresentacion.Text = Convert.ToString(row["Presentacion"]);
            }
            catch { }
        }
        #endregion

        #region CLICK DERECHO - MUESTRA INFORMACIÓN ADICIONAL DEL PRODUCTO
        private void dgvArticulos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo ClickDerecho = dgvArticulos.HitTest(e.X, e.Y);
                if (ClickDerecho.Type == DataGridViewHitTestType.Cell)
                {
                    dgvArticulos.CurrentCell = dgvArticulos.Rows[ClickDerecho.RowIndex].Cells[ClickDerecho.ColumnIndex];
                    LlenarDetalleProducto();
                    frmInfo formInfo = frmInfo.GetInstancia();
                    formInfo.StartPosition = FormStartPosition.Manual;
                    formInfo.Location = MousePosition;
                    formInfo.Show();
                    formInfo.BringToFront();
                }
            }
        }
        #endregion

        #region CLICK EN CELDA DGVARTICULO
        private void ClickCeldaDgvArticulo()
        {
            try
            {
                IdDescuento = 0;
                VenderPromo = false;
                txtPromo.Text = string.Empty;
                IdArticulo = Convert.ToInt32(dgvArticulos.CurrentRow.Cells["idproducto"].Value);
                Codigo = Convert.ToString(dgvArticulos.CurrentRow.Cells["codigo"].Value);
                txtCodigoBarras.Text = Codigo;
                Articulo = Convert.ToString(dgvArticulos.CurrentRow.Cells["nombre"].Value);
                txtArticulo.Text = Articulo;
                Precio_Venta = Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["precio_venta"].Value);
                txtPrecio_Venta.Text = Precio_Venta.ToString("#0.###", CultureInfo.InvariantCulture);
                Stock = Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["stock"].Value);
                txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
                //Recalcular Stock si el producto ya está ingresado en el detalle
                if (dgvVenta.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in dgvVenta.Rows)
                    {
                        if (Convert.ToString(row.Cells["codigo"].Value) == Codigo)
                        {
                            txtStock.Text = (Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["stock"].Value) - Convert.ToDecimal(row.Cells["cantidad"].Value)).ToString("#0.###", CultureInfo.InvariantCulture);
                        }
                    }
                }
                Presentacion = Convert.ToString(dgvArticulos.CurrentRow.Cells["Presentacion"].Value);
                lblPresentacion.Text = Presentacion;
                Ruta_Imagen = Convert.ToString(dgvArticulos.CurrentRow.Cells["ruta_imagen"].Value);
                pbxImagen.ImageLocation = Ruta_Imagen;
                txtCantidad.Enabled = true;
                //txtCantidad.SelectAll();
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Mensaje: " + ex.Message + "/nTrace: " + ex.StackTrace);
            }
        }
        #endregion

        #region CLICK IZQUIERDO EN DATAGRDVIEW ARTICULOS
        private void dgvArticulos_Click(object sender, EventArgs e)
        {
            ClickCeldaDgvArticulo();
        }
        #endregion

        #endregion

        #region LIMPIAR
        private void Limpiar()
        {
            #region LIMPIEZA DE VARIABLES
            //IdVenta;
            //IdTrabajador;
            //Trabajador;
            //IdCliente;
            //Cliente;
            Fecha = DateTime.Now;
            Tipo_Comprobante = string.Empty;
            Serie = string.Empty;
            Correlativo = string.Empty;
            IVA = 21;

            Promo = string.Empty;

            //IdDetalle_Venta;
            IdArticulo = 0;
            Codigo = string.Empty;
            Articulo = string.Empty;
            Presentacion = string.Empty;
            Stock = 0;
            Precio_Venta = 0;
            Ruta_Imagen = string.Empty;

            //dtInfoProducto.Dispose();

            //dtArticulo.Dispose();

            Cantidad = 1;
            Descuento = 0;

            dtDetalleVenta.Clear();

            Total = 0;

            dtDeuda.Dispose();
            Cantidad_Pagos = 0;
            Total_Pagado = 0;
            Interes = 0;
            Descripcion = string.Empty;

            dtDetalle_Deuda.Clear();
            Numero_Pago = 0;
            Monto = 0;
            Fecha_Pago = DateTime.Now;
            #endregion

            #region LIMPIEZA DE CONTROLES
            cmbComprobante.SelectedIndex = 0;
            txtSerie.Text = string.Empty;
            txtCorrelativo.Text = string.Empty;
            //por defecto debe estar el cliente "venta al público en general" y su id respectiva
            cargarClienteGral(); // LISTO!
            txtCliente.Text = Cliente;
            lblDeudaPendiente.Text = "NINGUNA";
            btnCobrar.Enabled = false;
            lblEstado.Text = "En emisión";
            txtPromo.Text = Promo;
            txtDescuento.Text = Convert.ToString(Descuento);
            txtCodigoBarras.Text = Codigo;
            txtArticulo.Text = Articulo;
            txtPrecio_Venta.Text = Convert.ToString(Precio_Venta);
            txtStock.Text = Convert.ToString(Stock);
            txtCantidad.Text = Convert.ToString(Cantidad);

            //Deuda
            cmbModoPago.SelectedIndex = 0;
            txtInteres.Text = Convert.ToString(Interes);
            nudCantidadPagos.Value = Cantidad_Pagos;
            txtMontoPagado.Text = Convert.ToString(Monto);
            txtMontoPorCuota.Text = "0";
            txtMontoRestante.Text = "0";
            txtDescripcion.Text = Descripcion;
            dgvVenta.DataSource = dtDetalleVenta;
            lblTotal.Text = Convert.ToString(Total, CultureInfo.InvariantCulture);

            //Descuento
            dtVenta_Descuento.Clear();
            #endregion
        }
        #endregion

        #region ADMINISTRAR VENTA

        // EL TRABAJADOR ES CAPTURADO DEL SISTEMA

        #region CLIENTE

        #region COMPRBAR DEUDA CLIENTE
        private void DeudaCliente()
        {
            if (IdCliente == 1)
            {
                cmbModoPago.Enabled = false;
            }
            else
            {
                cmbModoPago.Enabled = true;
            }
        }
        #endregion

        #region CARGAR CLIENTE POR DEFECTO
        private void cargarClienteGral()
        {
            DataTable cliente = new DataTable("cliente");
            cliente = NegocioCliente.TomarClienteGral();
            foreach (DataRow row in cliente.Rows)
            {
                IdCliente = Convert.ToInt32(row["idcliente"]);
                txtCliente.Text = Convert.ToString(row["nombre"]);
            }
        }
        #endregion

        #region SELECCIONAR CLIENTE

        private void SetCliente()
        {
            frmSeleccionarCliente formSeleccionarCliente = frmSeleccionarCliente.GetInstancia();
            IdCliente = formSeleccionarCliente.IdCliente;
            Cliente = formSeleccionarCliente.Cliente;
            txtCliente.Text = Cliente;
        }

        //MÉTODO PARA CAPTURAR EL EVENTO CUANDO SE HACE DOBLE CLIC EN EL DATAGRIDVIEW DE SELECCIÓN DE CLIENTE
        private void frmSeleccionarCliente_dgvListadoDobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetCliente();
            DeudaCliente();
        }

        //MÉTODO PARA CAPTURAR EL EVENTO CUANDO SE PRESIONA LA TECLA ENTER EN EL DATAGRIDVIEW DE SELECCIÓN DE CLIENTE
        private void frmSeleccionarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            SetCliente();
            DeudaCliente();
        }
        #endregion

        #region BUSCAR DEUDA CLIENTE
        private void BuscarDeuda()
        {
            DataTable dtAdeuda = new DataTable();
            //Escribir código en capaNegocio y capaDatos para verificar si el cliente tiene alguna deuda pendiente
        }
        #endregion

        #region BOTON BUSCAR CLIENTE
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmSeleccionarCliente formSeleccionarCliente = frmSeleccionarCliente.GetInstancia();
            formSeleccionarCliente.dgvListado.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(frmSeleccionarCliente_dgvListadoDobleClick);
            formSeleccionarCliente.dgvListado.KeyDown += new KeyEventHandler(frmSeleccionarCliente_KeyDown);
            formSeleccionarCliente.ShowDialog();
        }
        #endregion

        #region AGREGAR CLIENTE NUEVO
        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmIngresarCliente formIngresarCliente = new frmIngresarCliente();
            formIngresarCliente.ShowDialog();
        }
        #endregion

        #endregion

        #region ARTICULOS EN DESCUENTO/PROMOCIÓN

        #region TEMP PRUEBA COMMENT
        /*
         DataTable dtDetalle_Descuento = NegocioDetalle_Descuento.MostrarDetalle_Descuento(iddescuento);

            DataTable dtArticulos;
            dtArticulos = new DataTable("Detalle_Articulos");
            dtArticulos.Columns.Add("idproducto", Type.GetType("System.Int32"));
            dtArticulos.Columns.Add("codigo", Type.GetType("System.String"));
            dtArticulos.Columns.Add("articulo", Type.GetType("System.String"));
            dtArticulos.Columns.Add("precio_compra", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("precio_venta", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("stock", Type.GetType("System.Decimal"));

            DataTable dtArticulosTemp = NegocioProducto.BuscarArticuloId(IdArticulo);
            DataRow row = dtArticulos.NewRow();
            foreach (DataRow rowTemp in dtArticulosTemp.Rows)
            {
                row["idproducto"] = rowTemp["idproducto"];
                row["codigo"] = rowTemp["codigo"];
                row["articulo"] = rowTemp["nombre"];
                row["precio_compra"] = rowTemp["precio_compra"];
                row["precio_venta"] = rowTemp["precio_venta"];
                row["stock"] = rowTemp["stock"];
            }
            dtArticulos.Rows.Add(row);

            foreach (DataRow rowDetalle_Descuento in dtDetalle_Descuento.Rows)
            {
                foreach (DataRow rowArticulos in dtArticulos.Rows)
                {
                    if (Convert.ToInt32(rowDetalle_Descuento["idproducto"]) == Convert.ToInt32(rowArticulos["idproducto"]))
                    {
                        IdArticulo = Convert.ToInt32(rowDetalle_Descuento["idproducto"]);
                        Codigo = Convert.ToString(rowArticulos["codigo"]);
                        Articulo = Convert.ToString(rowDetalle_Descuento["nombre"]);
                        Cantidad = Convert.ToDecimal(rowDetalle_Descuento["cantidad"]);
                        Precio_Venta = Convert.ToDecimal(rowDetalle_Descuento["precio_venta_descuento"]);
                        //Precio_Venta = Convert.ToDecimal(rowArticulos["precio_venta"]);
                        //Precio_Venta_Descuento = Convert.ToDecimal(row["precio_venta_descuento"]);
                        Stock = Convert.ToDecimal(rowArticulos["stock"]);
                    }
                }
            }
         */
        #endregion

        #region COLUMNAS DATATABLE ARTICULOS - BORRAR SI NO ES NECESARIO
        //private void CrearDetalleArticulos()
        //{
        //    dtArticulos = new DataTable("Detalle_Articulos");
        //    //dtArticulos.Locale = CultureInfo.InvariantCulture;
        //    dtArticulos.Columns.Add("idproducto", Type.GetType("System.Int32"));
        //    dtArticulos.Columns.Add("codigo", Type.GetType("System.String"));
        //    dtArticulos.Columns.Add("articulo", Type.GetType("System.String"));
        //    dtArticulos.Columns.Add("cantidad", Type.GetType("System.Decimal"));
        //    dtArticulos.Columns.Add("precio_compra", Type.GetType("System.Decimal"));
        //    dtArticulos.Columns.Add("precio_venta", Type.GetType("System.Decimal"));
        //    dtArticulos.Columns.Add("precio_venta_descuento", Type.GetType("System.Decimal"));
        //    dtArticulos.Columns.Add("stock", Type.GetType("System.Decimal"));
        //}
        #endregion

        #region SELECCIONAR PROMO EN FORMULARIO "frmSeleccionarPromoDescuento"
        public void SetPromo(DataTable dtDetalle_Descuento_Articulos)
        {
            try
            {
                frmSeleccionarPromoDescuento formSeleccionarPromoDescuento = frmSeleccionarPromoDescuento.GetInstancia();
                txtPromo.Text = formSeleccionarPromoDescuento.NombreDescuento.ToString();
                //foreach (DataRow row in dtArt.Rows)
                foreach (DataRow row in dtDetalle_Descuento_Articulos.Rows)
                {
                    VenderPromo = true;
                    IdDescuento = Convert.ToInt32(row["iddescuento"]);
                    IdArticulo = Convert.ToInt32(row["idproducto"]);
                    Codigo = Convert.ToString(row["codigo"]);
                    //txtCodigoBarras.Text = Codigo;
                    Articulo = Convert.ToString(row["articulo"]);
                    txtArticulo.Text = Articulo;
                    Stock = Convert.ToDecimal(row["stock"]);
                    txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
                    Cantidad_Descuentos = formSeleccionarPromoDescuento.Cantidad_Descuentos;
                    Cantidad = Convert.ToDecimal(row["cantidad"]) * Cantidad_Descuentos;
                    txtCantidad.Text = Cantidad.ToString("#0.###", CultureInfo.InvariantCulture);
                    Precio_Venta = Convert.ToDecimal(row["precio_venta"]);
                    decimal descuento = (Precio_Venta * Cantidad) - Convert.ToDecimal(row["precio_venta_descuento"]);
                    txtDescuento.Text = descuento.ToString("#0.###", CultureInfo.InvariantCulture);
                    //Precio_Venta = Convert.ToDecimal(row["precio_venta_descuento"]);
                    txtPrecio_Venta.Text = Precio_Venta.ToString("#0.###", CultureInfo.InvariantCulture);
                    if (ValidarStockDescuento())
                    {
                        AgregarVenta_Descuento();
                        AgregarDetalle();
                    }
                    else
                    {
                        MessageBox.Show("Stock insuficiente para vender la promo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        foreach (DataRow quitarFila in dtVenta_Descuento.Rows)
                        {
                            if (Convert.ToInt32(quitarFila["iddescuento"]) == IdDescuento)
                            {
                                dtVenta_Descuento.Rows.Remove(quitarFila);
                            }
                            if (!validarVentaDescuento())
                            {
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo una excepción. Contacte con el administrador del sistema. Mensaje para el administradoe: " + ex.Message + " Trace: " + ex.StackTrace);
            }
            #region ANTIGÜO FORMULARIO DE DESCUENTOS
            /*
            int iddescuento;
            iddescuento = formSeleccionarPromoDescuento.IdDescuento;
            IdArticulo = formSeleccionarPromoDescuento.IdArticulo; // Asigno id del articulo
            DataTable dtArticuloPromo = NegocioProducto.BuscarArticuloId(IdArticulo); // Busco id del articulo y almaceno 
            // la fila en un datatable
            if (dtArticuloPromo.Rows.Count == 1) // Pregunto si el datatable tiene 1 columna
            {// Asignación de variables
                DataRow row = dtArticuloPromo.Rows[0];
                if (Convert.ToInt32(row["idproducto"]) == IdArticulo)
                {
                    Promo = formSeleccionarPromoDescuento.Descripcion;
                    Codigo = formSeleccionarPromoDescuento.Codigo;
                    txtCodigoBarras.Text = Codigo;
                    Cantidad = formSeleccionarPromoDescuento.Cantidad;
                    if (Convert.ToDecimal(row["stock"]) >= Cantidad)
                    {
                        txtPromo.Text = Promo;
                        Articulo = formSeleccionarPromoDescuento.Articulo;
                        txtArticulo.Text = Articulo;
                        Precio_Venta = formSeleccionarPromoDescuento.Precio;

                        decimal precioSinDescuento, descuento;
                        precioSinDescuento = Convert.ToDecimal(row["precio_venta"]);
                        txtCantidad.Text = Cantidad.ToString("#0.####", CultureInfo.InvariantCulture);
                        txtCantidad.Enabled = false;
                        descuento = (precioSinDescuento * Cantidad) - Precio_Venta;
                        txtDescuento.Text = descuento.ToString("#0.##", CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        MessageBox.Show("No dispone del stock suficiento para la promoción: " + Promo.Trim().ToUpper(),
                            "¡Stock insuficiente!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        IdArticulo = 0;
                        Promo = string.Empty;
                        Cantidad = 0;
                    }
                }
            }
            else
            {
                MessageBox.Show("No hay ingresos para el artículo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IdArticulo = 0;
                Promo = string.Empty;
                Cantidad = 0;
            }
            */
            #endregion
        }

        private void CrearVenta_Descuento()
        {
            dtVenta_Descuento = new DataTable("Venta_Descuento");
            dtVenta_Descuento.Columns.Add("iddescuento", Type.GetType("System.Int32"));
            dtVenta_Descuento.Columns.Add("idarticulo", Type.GetType("System.Int32"));
            dtVenta_Descuento.Columns.Add("cantidad_descuentos", Type.GetType("System.Int32"));
        }

        private void AgregarVenta_Descuento()
        {
            bool insertarVentaDescuento = true;
            foreach (DataRow row in dtVenta_Descuento.Rows)
            {
                if (Convert.ToInt32(row["iddescuento"]) == IdDescuento)
                {
                    insertarVentaDescuento = false;
                    row["iddescuento"] = IdDescuento;
                    if (Convert.ToInt32(row["idarticulo"]) == IdArticulo)
                    {
                        row["cantidad_descuentos"] = Convert.ToInt32(row["cantidad_descuentos"]) + Cantidad_Descuentos;
                    }
                    else
                    {
                        row["cantidad_descuentos"] = Convert.ToInt32(row["cantidad_descuentos"]);
                    }
                }
            }
            if (insertarVentaDescuento)
            {
                DataRow row = dtVenta_Descuento.NewRow();
                row["iddescuento"] = IdDescuento;
                row["idarticulo"] = IdArticulo;
                row["cantidad_descuentos"] = Cantidad_Descuentos;
                dtVenta_Descuento.Rows.Add(row);
            }
        }

        private bool ValidarStockDescuento()
        {
            bool valor = false;
            if (validarVentaDescuento())
            {
                foreach (DataRow row in dtVenta_Descuento.Rows)
                {
                    if (Stock > Cantidad)
                    {
                        valor = true;
                    }
                    else
                    {
                        valor = false;
                    }
                }
            }
            else
            {
                valor = true;
            }
            return valor;
        }

        private void frmSeleccionarPromoDescuento_dgvListadoDobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmSeleccionarPromoDescuento formSeleccionarPromoDescuento = frmSeleccionarPromoDescuento.GetInstancia();
            //dtArticulos_Descuento = formSeleccionarPromoDescuento.LlenarDetalle_Descuento();
            SetPromo(formSeleccionarPromoDescuento.LlenarDetalle_Descuento());
        }
        #endregion

        #region SELECCIONAR ARTICULO EN DESCUENTO
        private void btnPromoDescuento_Click(object sender, EventArgs e)
        {
            frmSeleccionarPromoDescuento formSeleccionarPromoDescuento = frmSeleccionarPromoDescuento.GetInstancia();
            formSeleccionarPromoDescuento.dgvListado.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(frmSeleccionarPromoDescuento_dgvListadoDobleClick);
            formSeleccionarPromoDescuento.ShowDialog();
        }
        #endregion

        // NO HAY ACCESO AL FORMULARIO PARA AGREGAR PROMOCIONES YA QUE LOS ÚNICOS QUE PUEDEN HACERLO SON EL AMINISTRADOR DEL SISTEMA
        // Y EL ENCARGADO

        #endregion

        #region BOTON ADMINISTRAR VENTAS
        private void btnAdministrarVentas_Click(object sender, EventArgs e)
        {
            frmVenta formVenta = frmVenta.GetInstancia();
            frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
            formVenta.MdiParent = formPrincipal;
            formPrincipal.BringToFront();
            formVenta.Show();
            formVenta.BringToFront();
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

        #region ESTADO DE LA VENTA
        private bool FijarPlanPago()
        {
            //Escribir código para actualizar el estado de la venta
            if (cmbModoPago.SelectedIndex == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region MODO DE PAGO

        #region COMBOBOX MODO DE PAGO
        private void cmbModoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbModoPago.SelectedIndex == 0)
            {
                txtInteres.Enabled = false;
                txtInteres.Text = "0";
                nudCantidadPagos.Enabled = false;
                nudCantidadPagos.Value = 2;
                txtMontoPagado.Enabled = false;
                txtMontoPagado.Text = "0";
                txtDescripcion.Enabled = false;
                txtMontoPorCuota.Text = "0";
                txtMontoRestante.Text = "0";
            }
            else
            {
                txtInteres.Enabled = true;
                nudCantidadPagos.Enabled = true;
                nudCantidadPagos.Focus();
                txtMontoPagado.Enabled = true;
                txtMontoPagado.Text = "0";
                txtDescripcion.Enabled = true;
                CalculoDeuda();
            }
        }
        #endregion

        #region NUMERICUPDOWN CANTIDAD DE CUOTAS
        private void nudCantidadPagos_Leave(object sender, EventArgs e)
        {
            if (nudCantidadPagos.Text == string.Empty)
            {
                nudCantidadPagos.Value = 2;
            }
        }
        #endregion

        #region DEUDA

        #region CREAR DEUDA
        private void CrearDeuda()
        {
            dtDeuda = new DataTable("Deuda");
            dtDeuda.Columns.Add("iddeuda", Type.GetType("System.Int32"));
            // El idventa no es necesario ponerlo ya que en la capadatos DatosVenta.InsertarVentaDeuda() se asignará este valor
            dtDeuda.Columns.Add("cantidad_pagos", Type.GetType("System.Int32"));
            dtDeuda.Columns.Add("total_pagado", Type.GetType("System.Decimal"));
            dtDeuda.Columns.Add("interes", Type.GetType("System.Decimal"));
            dtDeuda.Columns.Add("descripcion", Type.GetType("System.String"));
        }
        #endregion

        #region CREAR DETALLE DE LA DEUDA
        private void CrearDetalleDeuda()
        {
            dtDetalle_Deuda = new DataTable("Detalle_Deuda");
            dtDetalle_Deuda.Columns.Add("iddetalle_deuda", Type.GetType("System.Int32"));
            // El iddeuda se asignara en datosdeuda
            dtDetalle_Deuda.Columns.Add("numero_pago", Type.GetType("System.Int32"));
            dtDetalle_Deuda.Columns.Add("monto", Type.GetType("System.Decimal"));
            dtDetalle_Deuda.Columns.Add("fecha_pago", Type.GetType("System.DateTime"));
        }
        #endregion

        #endregion

        #endregion

        #region DATAGRIDVIEW VENTA

        #region DETALLE DE LA VENTA
        private void CrearDetalleVenta()
        {
            dtDetalleVenta = new DataTable("Detalle_Venta");
            //dtDetalleVenta.Locale = miCultureInfo;
            dtDetalleVenta.Columns.Add("iddescuento", Type.GetType("System.Int32"));
            dtDetalleVenta.Columns.Add("iddetalle_venta", Type.GetType("System.Int32"));
            dtDetalleVenta.Columns.Add("idproducto", Type.GetType("System.Int32"));
            dtDetalleVenta.Columns.Add("codigo", Type.GetType("System.String"));
            dtDetalleVenta.Columns.Add("articulo", Type.GetType("System.String"));
            dtDetalleVenta.Columns.Add("cantidad", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("precio_venta", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("descuento", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("subtotal", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("en_promo", Type.GetType("System.Boolean"));
            dtDetalleVenta.Columns.Add("cantidad_descuentos", Type.GetType("System.Int32"));
            dgvVenta.DataSource = dtDetalleVenta;
            NombreColumnasDetalle();
        }
        #endregion

        #region NOMBRE COLUMNAS
        private void NombreColumnasDetalle()
        {
            dgvVenta.Columns["iddescuento"].HeaderText = "Id Descuento";
            dgvVenta.Columns["codigo"].HeaderText = "Código de barras";
            dgvVenta.Columns["articulo"].HeaderText = "Artículo";
            dgvVenta.Columns["cantidad"].HeaderText = "Cantidad";
            dgvVenta.Columns["cantidad"].DefaultCellStyle.Format = "#0.###";
            dgvVenta.Columns["precio_venta"].HeaderText = "Precio";
            dgvVenta.Columns["precio_venta"].DefaultCellStyle.Format = "#0.##";
            dgvVenta.Columns["descuento"].HeaderText = "Descuento";
            dgvVenta.Columns["descuento"].DefaultCellStyle.Format = "#0.##";
            dgvVenta.Columns["subtotal"].HeaderText = "Subtotal";
            dgvVenta.Columns["subtotal"].DefaultCellStyle.Format = "#0.##";
            dgvVenta.Columns["en_promo"].HeaderText = "Promo";
            dgvVenta.Columns["cantidad_descuentos"].HeaderText = "Cantidad Promos";
        }
        #endregion

        #region OCULTAR COLUMNAS
        private void OcultarColumnasDetalle()
        {
            dgvVenta.Columns["iddescuento"].Visible = false;
            dgvVenta.Columns["codigo"].Visible = false;
            dgvVenta.Columns["chkEliminar"].Visible = false;
            dgvVenta.Columns["iddetalle_venta"].Visible = false;
            dgvVenta.Columns["idproducto"].Visible = false;
            dgvVenta.Columns["en_promo"].Visible = false;
            dgvVenta.Columns["cantidad_descuentos"].Visible = false;
        }
        #endregion

        #endregion

        #region AGREGAR ARTICULO AL DETALLE

        #region INGRESO RÁPIDO

        #region EVENTO TEXTCHANGED
        private void txtCodigoBarras_TextChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                if (txtCodigoBarras.Text == Convert.ToString(row.Cells["codigo"].Value))
                {
                    dgvArticulos.Rows[row.Index].Selected = true;
                    dgvArticulos.CurrentCell = dgvArticulos.Rows[row.Index].Cells[1];
                    ClickCeldaDgvArticulo();
                    //txtCodigoBarras.SelectAll();
                }
            }
        }
        #endregion

        #region EVENTO KEYDOWN
        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAgregar.PerformClick();
                txtCodigoBarras.SelectAll();
            }
        }
        #endregion

        #endregion

        #region AGREGAR DETALLE
        private void AgregarDetalle()
        {
            Cantidad = Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture);
            Descuento = Convert.ToDecimal(txtDescuento.Text, CultureInfo.InvariantCulture);
            //Stock = Convert.ToDecimal(txtStock.Text, CultureInfo.InvariantCulture);
            //Precio_Venta = Convert.ToDecimal(txtPrecio_Venta.Text, CultureInfo.InvariantCulture);
            Fecha = dtpFecha.Value;
            frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
            Settings Configuracion = new Settings();
            if (formPrincipal.chkEstablecerMinimo.Checked)
            {
                if (Stock > 0 && Stock <= Convert.ToInt32(Configuracion.StockMinimo))
                {
                     MessageBox.Show("¡Atención!: El producto se está terminando", "¡Advertencia!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            if (cmbComprobante.Text == "")
            {
                errorIcono.SetError(cmbComprobante, "Seleccione un comprobante de la lista");
            }
            else if (txtArticulo.Text == string.Empty || IdArticulo == 0)
            {
                errorIcono.SetError(txtArticulo, "Ingrese un artículo");
            }
            else if (Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture) <= 0)
            {
                errorIcono.SetError(txtCantidad, "La cantidad ingresada no puede ser 0 (cero)");
            }
            else if (Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture) > Convert.ToDecimal(txtStock.Text, CultureInfo.InvariantCulture))
            {
                MessageBox.Show("No dispone del stock suficiente para vender la cantidad ingresada", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    if (Convert.ToInt32(dgvVenta.Columns["idarticulo"]) == IdArticulo && Convert.ToBoolean(dgvVenta.Columns["en_promo"]) == true)
                    {
                        dgvVenta.Rows.Remove(dgvVenta.CurrentRow);
                    }
                }
            }
            else if (Convert.ToDecimal(txtStock.Text, CultureInfo.InvariantCulture) <= 0)
            {
                MessageBox.Show("No dispone de stock para realizar la venta", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (Precio_Venta == 0)
            {
                errorIcono.SetError(txtPrecio_Venta, "El precio de venta no puede ser 0 (cero)");
            }
            else
            {
                try
                {
                    bool insertarDetalle = true;
                    //bool insertarDetalleProducto = true;
                    foreach (DataRow row in dtDetalleVenta.Rows)
                    {
                        if (Convert.ToInt32(row["idproducto"]) == IdArticulo && Convert.ToInt32(row["iddescuento"]) == IdDescuento)
                        {
                            insertarDetalle = false;
                            //NotificacionError("El artículo ya se encuentra ingresado.Si éste pertenece a otro 
                            //proveedor selecciónelo en la lista de la esquina superior izquierda de ésta ventana", "Error");
                            decimal subTotal = (Cantidad * Precio_Venta) - Descuento;
                            Total = Total + subTotal;
                            row["iddescuento"] = IdDescuento;
                            row["iddetalle_venta"] = IdDetalle_Venta;
                            row["idproducto"] = IdArticulo;
                            row["codigo"] = Codigo;
                            row["articulo"] = Articulo;
                            row["cantidad"] = Convert.ToDecimal(row["cantidad"]) + Cantidad;
                            row["precio_venta"] = Precio_Venta;
                            row["descuento"] = Convert.ToDecimal(row["descuento"]) + Convert.ToDecimal(Descuento);
                            row["subtotal"] = Convert.ToDecimal(row["subtotal"]) + subTotal; //Convert.ToDecimal(row["cantidad"]) * Convert.ToDecimal(row["precio_venta"]);
                            row["en_promo"] = VenderPromo;
                            row["cantidad_descuentos"] = Convert.ToInt32(row["cantidad_descuentos"]) + Cantidad_Descuentos;
                            decimal stockRestante = Stock - Convert.ToDecimal(row["cantidad"], CultureInfo.InvariantCulture);
                            txtStock.Text = stockRestante.ToString("#0.####", CultureInfo.InvariantCulture);
                        }
                    }
                    if (insertarDetalle)
                    {
                        decimal subTotal = (Cantidad * Precio_Venta) - Descuento;
                        Total = Total + subTotal;
                        //Agregar detalle a dtDetalle
                        DataRow row = dtDetalleVenta.NewRow();
                        row["iddescuento"] = IdDescuento;
                        row["iddetalle_venta"] = IdDetalle_Venta;
                        row["idproducto"] = IdArticulo;
                        row["codigo"] = Codigo;
                        row["articulo"] = Articulo;
                        row["cantidad"] = Cantidad;
                        row["descuento"] = Descuento;
                        row["precio_venta"] = Precio_Venta;
                        row["subtotal"] = subTotal; // - Descuento;
                        row["en_promo"] = VenderPromo;
                        row["cantidad_descuentos"] = Cantidad_Descuentos;
                        dtDetalleVenta.Rows.Add(row);
                        decimal stockRestante = Stock - Convert.ToDecimal(row["cantidad"], CultureInfo.InvariantCulture);
                        txtStock.Text = stockRestante.ToString("#0.####", CultureInfo.InvariantCulture);
                    }
                    lblTotal.Text = Total.ToString("#0.##", miCultureInfo);
                    ColorFilas();
                    txtCodigoBarras.Text = Codigo;
                    Descuento = 0.00m;
                    txtDescuento.Text = Descuento.ToString("#0.###", CultureInfo.InvariantCulture);
                    Cantidad = 1.00m;
                    txtCantidad.Text = Cantidad.ToString("#0.###", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
            }
        }
        #endregion

        #region BOTON AGREGAR ARTICULO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarDetalle();
            if (cmbModoPago.SelectedIndex != 0)
            {
                CalculoDeuda();
            }
        }
        #endregion

        #endregion

        #region QUITAR ARTICULO DEL DETALLE

        #region QUITAR DETALLE
        private void QuitarDetalle()
        {
            try
            {
                switch (ctrlSeleccionado)
                {
                    case 0:
                        {
                            if (IdDescuento > 0 && VenderPromo)
                            {
                                for (int i = 0; i <= dgvVenta.Rows.Count; i++)
                                {
                                    foreach (DataGridViewRow row in dgvVenta.Rows)
                                    {
                                        row.Selected = true;
                                        if (IdDescuento == Convert.ToInt32(row.Cells["iddescuento"].Value))
                                        {
                                            int indiceFila = row.Index;
                                            DataRow rowDtDetalleVenta = dtDetalleVenta.Rows[indiceFila];
                                            //Disminuir el total pagado
                                            Total = Total - Convert.ToDecimal(rowDtDetalleVenta["subtotal"].ToString());
                                            lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                                            for (int j = 0; j < dtVenta_Descuento.Rows.Count; j++)
                                            {
                                                DataRow rowVentaDescuento = dtVenta_Descuento.Rows[j];
                                                if (IdDescuento == Convert.ToInt32(rowVentaDescuento["iddescuento"]))
                                                {
                                                    dtVenta_Descuento.Rows.Remove(rowVentaDescuento);
                                                }
                                            }
                                            dtDetalleVenta.Rows.Remove(rowDtDetalleVenta);
                                            txtStock.Text = Stock.ToString("#0.####", CultureInfo.InvariantCulture);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                int indiceFila = dgvVenta.CurrentCell.RowIndex;
                                DataRow row = dtDetalleVenta.Rows[indiceFila];
                                //Disminuir el total pagado
                                Total = Total - Convert.ToDecimal(row["subtotal"].ToString());
                                lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                                //foreach (DataRow rowDetalle in dtDetalleVenta.Rows)
                                //{
                                //    foreach (DataRow rowProducto in dtProducto.Rows)
                                //    {
                                //        if (rowDetalle["idproducto"] == rowProducto["idproducto"])
                                //        {
                                //            dtProducto.Rows.Remove(rowProducto);
                                //        }
                                //    }
                                //}
                                dtDetalleVenta.Rows.Remove(row);
                                txtStock.Text = Stock.ToString("#0.####", CultureInfo.InvariantCulture);
                            }
                            break;
                        }
                    case 2: // Comprobar si es mejor quitar o no
                        {
                            int iddetalle_venta;
                            string Respuesta = "";
                            DialogResult Opcion;
                            Opcion = MessageBox.Show(
                                "¿Realmente desea eliminar el item seleccionado?",
                                "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.Yes)
                            {
                                iddetalle_venta = Convert.ToInt32(dgvVenta.CurrentRow.Cells["iddetalle_venta"].Value);
                                Respuesta = NegocioIngreso.EliminarDetalle(Convert.ToInt32(iddetalle_venta));
                                if (Respuesta.Equals("OK"))
                                {
                                    NotificacionOk("El item se eliminó correctamente", "Eliminando");
                                    //MostrarDetalle();
                                }
                                else
                                {
                                    NotificacionError("El registro no se eliminó", "Error");
                                }
                                //Mostrar();
                            }
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje: " + ex.Message + " Traza: " + ex.StackTrace);
                NotificacionError("No hay ningún item añadido.", "Error");
            }
        }
        #endregion

        #region QUITAR DETALLE VENTA_DESCUENTO
        private void QuitarDetalleDescuento()
        {
            try
            {
                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    row.Selected = true;
                    if (IdDescuento == Convert.ToInt32(row.Cells["iddescuento"].Value) && VenderPromo)
                    {
                        IdDescuento = Convert.ToInt32(row.Cells["iddescuento"].Value);
                        int indiceFila = dgvVenta.CurrentRow.Index;
                        DataRow rowDtVenta = dtDetalleVenta.Rows[row.Index];
                        //Disminuir el total pagado
                        Total = Total - Convert.ToDecimal(rowDtVenta["subtotal"].ToString());
                        lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                        dtDetalleVenta.Rows.Remove(rowDtVenta);
                        txtStock.Text = Stock.ToString("#0.####", CultureInfo.InvariantCulture);
                    }
                }
            }
            catch { }
        }
        #endregion

        #region BOTON QUITAR DETALLE
        private void btnQuitar_Click(object sender, EventArgs e)
        {
            ColorFilasEnSeleccion();
            QuitarDetalle();
            if (cmbModoPago.SelectedIndex != 0)
            {
                CalculoDeuda();
            }
        }
        #endregion

        #endregion

        #endregion

        private void tFechaHora_Tick(object sender, EventArgs e)
        {
            dtpFecha.Value = DateTime.Now;
        }

        #region VALIDAR VENTA
        private void validarFormaDePago()
        {
            if (cmbModoPago.SelectedIndex != 0)
            {
                if (txtMontoPagado.Text == string.Empty || txtMontoPagado.Text == "0")
                {
                    txtMontoPagado.Text = txtMontoPorCuota.Text;
                }
                CalculoDeuda();
            }
        }
        #endregion

        #region VALIDAR VENTA_DESCUENTO
        private bool validarVentaDescuento()
        {
            if (dtVenta_Descuento.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        private void btnVender_Click(object sender, EventArgs e)
        {
            // CÓDIGO PARA VALIDAR QUE EL MONTO PAGADO SEA IGUAL AL MÍNIMO ESPECIFICADO EN EL TXTMONTOPORCUOTA
            //if (Convert.ToDecimal(txtMontoPagado.Text) < Convert.ToDecimal(txtMontoPorCuota.Text))
            //{
            //    txtMontoPagado.Text = txtMontoPorCuota.Text;
            //}
            // LLAMDO AL MÉTODO PARA VALIDAR SI SE PAGARÁ EN PARTES
            validarFormaDePago();
            validarVentaDescuento();
            InsertarVenta();
            Mostrar();
        }

        private void InsertarVenta()
        {
            string agregarActualizar = "";
            frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
            IdTrabajador = formPrincipal.IdTrabajador;
            Fecha = dtpFecha.Value;
            Tipo_Comprobante = cmbComprobante.Text;
            Serie = txtSerie.Text;
            Correlativo = txtCorrelativo.Text;
            IVA = Convert.ToDecimal(txtIVA.Text);
            Total = Convert.ToDecimal(lblTotal.Text, CultureInfo.InvariantCulture);
            if (Tipo_Comprobante != "NINGUNO")
            {
                Serie = txtSerie.Text;
                Correlativo = txtCorrelativo.Text;
            }
            else
            {
                Serie = string.Empty;
                Correlativo = string.Empty;
            }
            if (txtArticulo.Text == string.Empty)
            {
                errorIcono.SetError(txtArticulo, "Ingrese un artículo");
            }
            else if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                errorIcono.SetError(txtCantidad, "El stock final no puede ser 0 (cero)");
            }
            else if (Precio_Venta == 0)
            {
                errorIcono.SetError(txtPrecio_Venta, "No hay establecido un precio para la venta al público de este artículo");
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            if (cmbModoPago.SelectedIndex != 0)
                            {
                                Cantidad_Pagos = nudCantidadPagos.Value;
                                Total_Pagado = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                                Interes = Convert.ToDecimal(txtInteres.Text, CultureInfo.InvariantCulture);
                                Descripcion = txtDescripcion.Text;

                                //Agregar deuda a dtDeuda
                                DataRow rowDeuda = dtDeuda.NewRow();
                                rowDeuda["cantidad_pagos"] = Cantidad_Pagos;
                                rowDeuda["total_pagado"] = Total_Pagado;
                                rowDeuda["interes"] = Interes;
                                rowDeuda["descripcion"] = Descripcion;
                                dtDeuda.Rows.Add(rowDeuda);

                                for (int i = 1; i <= Cantidad_Pagos; i++)
                                {
                                    // Agregar detalle a dtDetalle_Deuda
                                    DataRow rowDetalleDeuda = dtDetalle_Deuda.NewRow();
                                    rowDetalleDeuda["numero_pago"] = i;
                                    if (i == 1)
                                    {
                                        Monto = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                                        Fecha_Pago = dtpFecha.Value + DateTime.Now.TimeOfDay;
                                        rowDetalleDeuda["monto"] = Monto;
                                        rowDetalleDeuda["fecha_pago"] = Fecha_Pago;
                                    }
                                    else
                                    {
                                        rowDetalleDeuda["monto"] = 0;
                                        rowDetalleDeuda["fecha_pago"] = DateTime.Now + DateTime.Now.TimeOfDay;
                                    }
                                    dtDetalle_Deuda.Rows.Add(rowDetalleDeuda);
                                }
                                if (validarVentaDescuento())
                                {
                                    agregarActualizar = NegocioVenta.Insertar(IdCliente, IdTrabajador, Fecha, Tipo_Comprobante, Serie.Trim().ToUpper(),
                                    Correlativo.Trim().ToUpper(), IVA, Total, cmbModoPago.Text, dtDetalleVenta, dtDeuda, dtDetalle_Deuda, dtVenta_Descuento);
                                }
                                else
                                {
                                    agregarActualizar = NegocioVenta.Insertar(IdCliente, IdTrabajador, Fecha, Tipo_Comprobante, Serie.Trim().ToUpper(),
                                    Correlativo.Trim().ToUpper(), IVA, Total, cmbModoPago.Text, dtDetalleVenta, dtDeuda, dtDetalle_Deuda);
                                }
                                if (agregarActualizar.Equals("OK"))
                                {
                                    NotificacionOk("Venta guardada correctamente", "Guardando");
                                    Limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("La venta no se guardó debido a que ocurrió un error en la base de datos. Por favor tome una captura de pantalla y contacte con el administrador del sistema." + " Mensaje para el administrador: " + agregarActualizar, "¡ATENCIÓN! LEA ESTE MENSAJE ATENTAMENTE.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                dtDeuda.Dispose();
                                dtDetalle_Deuda.Dispose();
                                //dtDeuda.Clear();
                                //dtDetalle_Deuda.Clear();
                                if (validarVentaDescuento())
                                {
                                    agregarActualizar = NegocioVenta.Insertar(IdCliente, IdTrabajador, Fecha, Tipo_Comprobante, Serie.Trim().ToUpper(),
                                        Correlativo.Trim().ToUpper(), IVA, Total, "PAGADA", dtDetalleVenta, dtVenta_Descuento);
                                }
                                else
                                {
                                    agregarActualizar = NegocioVenta.Insertar(IdCliente, IdTrabajador, Fecha, Tipo_Comprobante, Serie.Trim().ToUpper(),
                                        Correlativo.Trim().ToUpper(), IVA, Total, "PAGADA", dtDetalleVenta);
                                    MessageBox.Show(Fecha.ToString());
                                }
                                if (agregarActualizar.Equals("OK"))
                                {
                                    NotificacionOk("Ingreso guardado correctamente", "Guardando");
                                    Limpiar();
                                }
                                else
                                {
                                    MessageBox.Show("El ingreso no se guardó debido a que ocurrió un error en la base de datos. Por favor tome una captura de pantalla y contacte con el administrador del sistema." + " Mensaje para el administrador: " + agregarActualizar, "¡ATENCIÓN! LEA ESTE MENSAJE ATENTAMENTE.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            break;
                        case 1://Editar
                            //agregarActualizar = NegocioIngreso.Editar(IdIngreso, IdTrabajador, IdProveedor, Fecha, Tipo_Comprobante, Serie.Trim().ToUpper(),
                            //    Correlativo.Trim().ToUpper(), IVA, "EMITIDO", Total, dtDetalle, dtProducto);
                            //NotificacionOk("Ingreso editado correctamente", "Editando");
                            //Limpiar();
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
                //HabilitarBotones();
            }
        }

        #region DEUDA

        #region LIMPIAR VARIABLES DEUDA
        private void LimpiarDeuda()
        {
            Interes = 0;
        }
        #endregion

        #region CALCULO DE LA DEUDA
        private void CalculoDeuda()
        {
            if (Interes > 0)
            {
                decimal TotalConInteres = Total + ((Total * Interes) / 100);
                lblTotalConInteres.Text = TotalConInteres.ToString("#0.##", CultureInfo.InvariantCulture);
                decimal MontoPorCuota = TotalConInteres / nudCantidadPagos.Value;
                txtMontoPorCuota.Text = MontoPorCuota.ToString("#0.##", CultureInfo.InvariantCulture);
                decimal MontoPagado = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                decimal MontoRestante = TotalConInteres - MontoPagado;
                txtMontoRestante.Text = MontoRestante.ToString("#0.##", CultureInfo.InvariantCulture);
            }
            else if (Interes == 0)
            {
                lblTotalConInteres.Text = "0,00";
                decimal MontoPorCuota = Total / nudCantidadPagos.Value;
                txtMontoPorCuota.Text = MontoPorCuota.ToString("#0.##", CultureInfo.InvariantCulture);
                decimal MontoPagado = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                decimal MontoRestante = Total - MontoPagado;
                txtMontoRestante.Text = MontoRestante.ToString("#0.##", CultureInfo.InvariantCulture);
            }
        }
        #endregion

        #endregion

        private void nudCantidadPagos_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                CalculoDeuda();
            }
            catch
            { }
        }

        private void txtMontoPagado_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculoDeuda();
            }
            catch
            { }
        }

        private void txtInteres_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Interes = Convert.ToDecimal(txtInteres.Text, CultureInfo.InvariantCulture);
                //if (Interes < 0 || txtInteres.Text == string.Empty)
                //{
                //    txtInteres.Text = "0";
                //    txtInteres.SelectAll();
                //}
                CalculoDeuda();
            }
            catch
            { }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //DataTable dtDescuento = new DataTable("Descuento");
                //dtDescuento = NegocioDescuento.BuscarIdArticulo(IdArticulo);
                //foreach (DataRow row in dtDescuento.Rows)
                //{
                //    if (IdArticulo == Convert.ToInt32(row["idproducto"]) && Convert.ToInt32(txtCantidad.Text) >= Convert.ToInt32(row["cantidad"]))
                //    {
                //        MessageBox.Show("El ártículo está en promoción");
                //    }
                //}
            }
            catch { }
        }

        #region EVENTOS LEAVE - VALIDACION

        private void validarTextBox(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            if (control.Text == string.Empty || control.Text == "")
            {
                control.Text = "0";
            }
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            TextBox control = (TextBox)sender;
            if (control.Text == string.Empty || control.Text == "" || Convert.ToDecimal(control.Text) < 1)
            {
                control.Text = "1.00";
            }
        }

        private void txtMontoRestante_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(txtMontoRestante.Text) <= 0)
            {
                txtMontoPagado.Text = "0";
            }
        }

        private void dgvVenta_Click(object sender, EventArgs e)
        {
            ColorFilasEnSeleccion();
        }
        #endregion

        private void ColorFilasEnSeleccion()
        {
            try
            {
                IdDescuento = Convert.ToInt32(dgvVenta.CurrentRow.Cells["iddescuento"].Value);
                VenderPromo = Convert.ToBoolean(dgvVenta.CurrentRow.Cells["en_promo"].Value);
                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    if (IdDescuento > 0 && IdDescuento == Convert.ToInt32(row.Cells["iddescuento"].Value) && VenderPromo)
                    {
                        row.Selected = true;
                    }
                }
            }
            catch { }
        }

        private void ColorFilas()
        {
            foreach (DataGridViewRow row in dgvVenta.Rows)
            {
                IdDescuento = Convert.ToInt32(row.Cells["iddescuento"].Value);
                VenderPromo = Convert.ToBoolean(row.Cells["en_promo"].Value);
                if (IdDescuento > 0 && IdDescuento == Convert.ToInt32(row.Cells["iddescuento"].Value) && VenderPromo)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }
    }
}
