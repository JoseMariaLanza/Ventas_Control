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
using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmIngresarVenta : MetroForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();
        Validacion.Validacion validacionesCantidad = new Validacion.Validacion();
        Validacion.Validacion validacionesDescuentoPorArticulo = new Validacion.Validacion();
        Validacion.Validacion validacionesDescuentoGeneral = new Validacion.Validacion();
        public int ctrlSeleccionado; // ver luego si es mejor eliminar esta variable y mostrar el detalle de la venta en un fomulario aparte
        #region variables venta general
        public int IdVenta;
        public int IdCaja;
        public int IdEmpleado;
        public string Empleado;
        public int IdCliente;
        public string Cliente;
        public string EstadoCliente;
        public DateTime Fecha;
        public string TipoComprobante;
        public string Serie;
        public string Correlativo;
        public decimal IVA;

        #region variables articulo
        //public int IdPromo;
        public string Promo;

        public int IdDetalleVenta;
        public int IdArticulo;
        public string Codigo;
        public string Articulo;
        public string Presentacion;
        public decimal Stock;
        public decimal PrecioVenta;
        public string RutaImagen;

        DataTable dtInfoArticulo; // variable para almacenar el resultado de la búsqueda del producto y 
                                  // mostrar la información adicional en el cuadro desplegable

        //ingreso rápido
        //DataTable dtArticulo = new DataTable();

        public decimal Cantidad;
        public decimal Descuento;
        #endregion

        #region VENTA DE PROMOCIONES
        DataTable dtVentaDescuento;
        public int IdDescuento;
        public string NombreDescuento;
        int CantidadDescuentos;
        bool VenderPromo = false;
        //DataTable dtArticulos_Descuento;
        #endregion

        DataTable dtDetalleVenta; // variable para almacenar los items que se vayan agregando a la venta

        public decimal Total; // Total parcial de la venta; es decir; sin descuentos ni intereses aplicados

        #region VARIABLES DEUDA
        DataTable dtDeuda;
        public int CantidadPagos;
        public decimal TotalPagado;
        public decimal Interes;
        public string Descripcion;
        #endregion

        #region VARIABLES DETALLE DE LA DEUDA
        DataTable dtDetalleDeuda;
        public int NumeroPago;
        public decimal Monto;
        public DateTime FechaPago;
        #endregion

        #endregion

        CultureInfo miCultureInfo = new CultureInfo("en"); // Sirve para establecer el uso del . (punto) 
        // en vez de la , (coma) para números decimales

        public frmIngresarVenta()
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
            ClienteDefault();
            HabilitarFormasDePago();
            CrearDetalleVenta();
            OcultarColumnasDetalle();
            CrearDeuda();
            CrearDetalleDeuda();
            CrearVentaDescuento();
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

        #region AJUSTES TECLAS
        private void DeshabilitarPegado(object sender, KeyPressEventArgs e)
        {
            //validaciones.ValidarDecimal(sender, e);
            //validaciones.IngresarNumeroDecimal(e);
            controlTeclado.DeshabilitarPegado(sender, e);
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
        public void Mostrar()
        {
            dgvArticulos.DataSource = NegocioArticulo.Mostrar();
            NombreColumnas();
            OcultarColumnas();
        }
        #endregion

        #region BUSQUEDA
        
        private void BuscarArticulo()
        {
            dgvArticulos.DataSource = NegocioArticulo.Buscar(txtBuscar.Text);
        }

        #region CONTROLES BUSQUEDA
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarArticulo();
            if (txtBuscar.TextLength > 0)
            {
                btnLimpiarBusqueda.Visible = true;
                //txtBuscar.Width = 565;
            }
            else
            {
                btnLimpiarBusqueda.Visible = false;
                //txtBuscar.Width = 595;
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtBuscar.SelectAll();
        }
        #endregion

        #endregion
        
        private void NombreColumnas()
        {
            dgvArticulos.Columns["Codigo"].HeaderText = "Código";
            dgvArticulos.Columns["Articulo"].HeaderText = "Artículo";
            dgvArticulos.Columns["Categoria"].HeaderText = "Categoría";
            dgvArticulos.Columns["Presentacion"].HeaderText = "";
            dgvArticulos.Columns["PrecioVenta"].HeaderText = "Precio";
            dgvArticulos.Columns["PrecioCompra"].DefaultCellStyle.Format = "$#0.##";
            dgvArticulos.Columns["Stock"].HeaderText = "Stock";
            dgvArticulos.Columns["Stock"].DefaultCellStyle.Format = "#0.###";
        }
        
        private void OcultarColumnas()
        {
            dgvArticulos.Columns["IdArticulo"].Visible = false;
            dgvArticulos.Columns["IdCategoria"].Visible = false;
            dgvArticulos.Columns["PrecioCompra"].Visible = false;
            dgvArticulos.Columns["IdPresentacion"].Visible = false;
            dgvArticulos.Columns["Descripcion"].Visible = false;
            dgvArticulos.Columns["RutaImagen"].Visible = false;
        }

        #endregion

        #region INFORMACIÓN DEL ARTÍCULO
        private void InfoArticulo()
        {
            dtInfoArticulo = NegocioArticulo.Buscar(Convert.ToInt32(dgvArticulos.CurrentRow.Cells["IdArticulo"].Value));
            DataRow row = dtInfoArticulo.Rows[0];
            frmInfo formInfo = frmInfo.GetInstancia();
            formInfo.lblIdProducto.Text = Convert.ToString(row["IdArticulo"]);
            formInfo.lblCodigo.Text = Convert.ToString(row["Codigo"]);
            formInfo.lblArticulo.Text = Convert.ToString(row["Articulo"]);
            formInfo.lblPrecioCompra.Text = Convert.ToString(row["PrecioCompra"]);
            formInfo.lblPrecioVenta.Text = Convert.ToString(row["PrecioVenta"]);
            formInfo.lblStock.Text = Convert.ToDecimal(row["Stock"]).ToString("#0.###", CultureInfo.InvariantCulture);
            formInfo.pbxImagenArticulo.ImageLocation = Convert.ToString(row["RutaImagen"]);
            formInfo.txtDescripcion.Text = Convert.ToString(row["Descripcion"]);
            formInfo.lblCategoria.Text = Convert.ToString(row["Categoria"]);
            formInfo.lblPresentacion.Text = Convert.ToString(row["Presentacion"]);
        }

        #region CLICK DERECHO - MUESTRA INFORMACIÓN ADICIONAL DEL PRODUCTO
        private void dgvArticulos_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView.HitTestInfo ClickDerecho = dgvArticulos.HitTest(e.X, e.Y);
                if (ClickDerecho.Type == DataGridViewHitTestType.Cell)
                {
                    dgvArticulos.CurrentCell = dgvArticulos.Rows[ClickDerecho.RowIndex].Cells[ClickDerecho.ColumnIndex];
                    InfoArticulo();
                    frmInfo formInfo = frmInfo.GetInstancia();
                    formInfo.StartPosition = FormStartPosition.Manual;
                    formInfo.Location = MousePosition;
                    formInfo.Show();
                    formInfo.BringToFront();
                }
            }
        }
        #endregion
        #endregion
        
        #region CLICK EN CELDA DGVARTICULO
        private void DgvArticulos_Click()
        {
            IdDescuento = 0;
            VenderPromo = false;
            txtPromo.Text = string.Empty;
            IdArticulo = Convert.ToInt32(dgvArticulos.CurrentRow.Cells["IdArticulo"].Value);
            Codigo = Convert.ToString(dgvArticulos.CurrentRow.Cells["Codigo"].Value);
            txtCodigoBarras.Text = Codigo;
            Articulo = Convert.ToString(dgvArticulos.CurrentRow.Cells["Articulo"].Value);
            txtArticulo.Text = Articulo;
            PrecioVenta = Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["PrecioVenta"].Value);
            txtPrecio_Venta.Text = PrecioVenta.ToString("#0.###", CultureInfo.InvariantCulture);
            //txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
            //Recalcular Stock si el producto ya está ingresado en el detalle
            //CalcularStockRestante();
            if (dtDetalleVenta.Rows.Count > 0)
            {
                Stock = CalcularStockRestanteArticuloEspecifico(IdArticulo);
            }
            else
            {
                Stock = Convert.ToDecimal(dgvArticulos.CurrentRow.Cells["Stock"].Value);
            }
            txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
            Presentacion = Convert.ToString(dgvArticulos.CurrentRow.Cells["Presentacion"].Value);
            lblPresentacion.Text = Presentacion;
            RutaImagen = Convert.ToString(dgvArticulos.CurrentRow.Cells["RutaImagen"].Value);
            pbxImagen.ImageLocation = RutaImagen;
            txtCantidad.Enabled = true;
        }
        #endregion

        #region CALCULAR STOCK

        private void CalcularStockRestante()
        {
            foreach (DataRow row in dtDetalleVenta.Rows)
            {
                if (IdArticulo == Convert.ToInt32(row["IdArticulo"]))
                {
                    Stock = Stock - Cantidad;
                    txtStock.Text = Stock.ToString("0#.0#", miCultureInfo);
                }
            }
        }

        private decimal CalcularStockRestanteArticuloEspecifico(int idArticulo)
        {
            decimal stockRestante = 0;
            decimal cantidadArticuloEnDetalleVenta = 0;
            decimal stockArticulo = 0;
            if (dtDetalleVenta.Rows.Count > 0)
            {
                foreach (DataRow rowDetalleVenta in dtDetalleVenta.Rows)
                {
                    if (Convert.ToInt32(rowDetalleVenta["IdArticulo"]) == idArticulo)
                    {
                        cantidadArticuloEnDetalleVenta += Convert.ToDecimal(rowDetalleVenta["Cantidad"]);
                    }
                }
                foreach (DataGridViewRow rowArticulo in dgvArticulos.Rows)
                {
                    if (Convert.ToInt32(rowArticulo.Cells["IdArticulo"].Value) == idArticulo)
                    {
                        stockArticulo += Convert.ToDecimal(rowArticulo.Cells["Stock"].Value);
                    }
                }
                stockRestante = stockArticulo - cantidadArticuloEnDetalleVenta;
            }
            else
            {
                foreach (DataGridViewRow rowArticulo in dgvArticulos.Rows)
                {
                    if (Convert.ToInt32(rowArticulo.Cells["IdArticulo"].Value) == idArticulo)
                    {
                        stockRestante = Convert.ToDecimal(rowArticulo.Cells["Stock"].Value);
                    }
                }
            }
            return stockRestante;
        }

        //private decimal ValidarStockDeArticulosEnDescuento(DataTable dtListaArticulosDescuento)
        //{
        //    bool validado = false;
        //    decimal cantidadTotalArticulosEnDescuento = 0;
        //    decimal stockTotalArticulosEnDescuento = 0;
        //    foreach (DataGridViewRow row in dgvArticulos.Rows)
        //    {
        //        foreach (DataRow dtRow in dtListaArticulosDescuento.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["IdArticulo"].Value) == Convert.ToInt32(dtRow["IdArticulo"]))
        //            {
        //                cantidadTotalArticulosEnDescuento += Cantidad;
        //                stockTotalArticulosEnDescuento += Stock;
        //                if (stockTotalArticulosEnDescuento >= cantidadTotalArticulosEnDescuento)
        //                {
        //                    validado = true;
        //                }
        //                else
        //                {
        //                    validado = false;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return validado;
        //}

        public bool CompararListas(DataGridView[] listas, string nombreCampo)
        {
            bool procederConComparacion = false;
            bool camposIguales = false;
            for (int i = 0; i < listas.Length; i++)
            {
                procederConComparacion = (HayFilasEnListaAComparar(listas[i]) && i > 0) ? true : false;
                if (procederConComparacion)
                    camposIguales = CamposIguales(listas[0], listas[i], nombreCampo);
                else
                    camposIguales = false;
            }
            return camposIguales;
        }

        private bool CamposIguales(DataGridView listaOrigen, DataGridView listaAComparar, string nombreCampo)
        {
            bool sonIguales = false;
            foreach (DataGridViewRow rowOrigen in listaOrigen.Rows)
            {
                foreach(DataGridViewRow rowAComparar in listaAComparar.Rows)
                {
                    if (rowOrigen.Cells[nombreCampo] == rowAComparar.Cells[nombreCampo])
                    {
                        sonIguales = true;
                    }
                }
            }
            return sonIguales;
        }

        public bool HayFilasEnListaAComparar(DataGridView lista)//, int indiceLista)//, ref int numeroLista)
        {
            bool registrosEnLista = (lista.Rows != null) ? true : false;
            return registrosEnLista;
        }

        #endregion

        #region CLICK IZQUIERDO EN DATAGRDVIEW ARTICULOS
        private void dgvArticulos_Click(object sender, EventArgs e)
        {
            try
            {
                DgvArticulos_Click();
            }
            catch { }
        }
        #endregion

        #endregion

        #region LIMPIAR
        private void Limpiar()
        {
            #region LIMPIEZA DE VARIABLES
            Fecha = DateTime.Now;
            TipoComprobante = string.Empty;
            Serie = string.Empty;
            Correlativo = string.Empty;
            IVA = 21;

            Promo = string.Empty;
            
            IdArticulo = 0;
            Codigo = string.Empty;
            Articulo = string.Empty;
            Presentacion = string.Empty;
            Stock = 0;
            PrecioVenta = 0;
            RutaImagen = string.Empty;

            Cantidad = 1;
            Descuento = 0;

            dtDetalleVenta.Clear();

            Total = 0;
            TotalFinal = 0;

            dtDeuda.Dispose();
            CantidadPagos = 0;
            TotalPagado = 0;
            Interes = 0;
            Descripcion = string.Empty;

            dtDetalleDeuda.Clear();
            NumeroPago = 0;
            Monto = 0;
            FechaPago = DateTime.Now;
            #endregion

            #region LIMPIEZA DE CONTROLES
            cmbComprobante.SelectedIndex = 0;
            txtSerie.Text = string.Empty;
            txtCorrelativo.Text = string.Empty;
            //por defecto debe estar el cliente "venta al público en general" y su id respectiva (o sea 1)
            ClienteDefault(); // LISTO!
            txtCliente.Text = Cliente;
            lblDeudaPendiente.Text = "NINGUNA";
            btnCobrar.Enabled = false;
            lblEstado.Text = "En emisión";
            txtPromo.Text = Promo;
            txtDescuento.Text = Descuento.ToString("$#0.#0", CultureInfo.InvariantCulture);
            txtDescuentoGeneral.Text = DescuentoGeneral.ToString("$#0.#0", CultureInfo.InvariantCulture);
            txtCodigoBarras.Text = Codigo;
            txtArticulo.Text = Articulo;
            txtPrecio_Venta.Text = Convert.ToString(PrecioVenta);
            txtStock.Text = Convert.ToString(Stock);
            txtCantidad.Text = Cantidad.ToString("##0.#0", CultureInfo.InvariantCulture);

            //Deuda
            cmbModoPago.SelectedIndex = 0;
            cmbModoPago.Enabled = false;
            TotalConInteres = 0;
            lblTotalConInteres.Text = TotalConInteres.ToString("$#0.#0", CultureInfo.InvariantCulture);
            txtInteres.Text = Convert.ToString(Interes);
            nudCantidadPagos.Value = CantidadPagos;
            txtMontoPagado.Text = Convert.ToString(Monto);
            txtMontoPorCuota.Text = "0";
            txtMontoRestante.Text = "0";
            txtDescripcion.Text = Descripcion;
            dgvVenta.DataSource = dtDetalleVenta;
            lblTotal.Text = Convert.ToString(Total, CultureInfo.InvariantCulture);

            //Descuento
            dtVentaDescuento.Clear();
            #endregion
        }
        #endregion

        #region ADMINISTRAR VENTA

        // EL TRABAJADOR ES CAPTURADO DEL SISTEMA

        #region CLIENTE

        private bool ComprobarClientePuedeContraerDeuda()
        {
            bool puedeAdeudar;
            puedeAdeudar = (IdCliente > 1) ? true : false;
            return puedeAdeudar;
        }

        private void HabilitarFormasDePago()
        {
            cmbModoPago.Enabled = ComprobarClientePuedeContraerDeuda();
        }

        private void ClienteDefault()
        {
            DataTable cliente = new DataTable("Cliente");
            cliente = NegocioCliente.ClienteDefault();
            foreach (DataRow row in cliente.Rows)
            {
                IdCliente = Convert.ToInt32(row["IdCliente"]);
                Cliente = Convert.ToString(row["RazonSocial"]);
                txtCliente.Text = Cliente;
            }
        }
        
        public void SetCliente()
        {
            txtCliente.Text = Cliente;
        }

        private void frmSeleccionarCliente_dgvListadoDobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SetCliente();
            HabilitarFormasDePago();
        }
        
        private void frmSeleccionarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            SetCliente();
            HabilitarFormasDePago();
        }
        #endregion
        
        //private bool ClienteAdeuda()
        //{
        //    DataTable dtAdeuda = new DataTable();
        //    //Escribir código en capaNegocio y capaDatos para verificar si el cliente tiene alguna deuda pendiente
        //    //Buscar deuda y preguntar si el datatable devuelto tiene filas
        //}
        
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            frmSeleccionarCliente formSeleccionarCliente = frmSeleccionarCliente.GetInstancia();
            formSeleccionarCliente.dgvListado.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(frmSeleccionarCliente_dgvListadoDobleClick);
            formSeleccionarCliente.dgvListado.KeyDown += new KeyEventHandler(frmSeleccionarCliente_KeyDown);
            formSeleccionarCliente.ShowDialog();
        }
        #endregion

        private void btnAgregarCliente_Click(object sender, EventArgs e)
        {
            frmIngresarCliente formIngresarCliente = new frmIngresarCliente();
            formIngresarCliente.ShowDialog();
        }

        #region ARTICULOS EN DESCUENTO/PROMOCIÓN

        #region SELECCIONAR PROMO EN FORMULARIO "frmSeleccionarPromoDescuento"

        public void SetPromo(DataTable dtDetallesDescuentosArticulos)
        {
            try
            {
                frmSeleccionarPromoDescuento formSeleccionarPromoDescuento = frmSeleccionarPromoDescuento.GetInstancia();
                txtPromo.Text = NombreDescuento;
                bool insertar = false;
                if (ValidarVentaDescuento(dtDetallesDescuentosArticulos))
                {
                    foreach (DataRow row in dtDetallesDescuentosArticulos.Rows)
                    {
                        Stock = CalcularStockRestanteArticuloEspecifico(Convert.ToInt32(row["IdArticulo"]));
                        decimal cantidad = formSeleccionarPromoDescuento.CantidadDescuentos * Convert.ToDecimal(row["Cantidad"]);
                        if (Stock > 0 && cantidad <= Stock)
                        {
                            insertar = true;
                        }
                        else
                        {
                            insertar = false;
                            break;
                        }
                    }
                }
                if (insertar)
                {
                    foreach (DataRow row in dtDetallesDescuentosArticulos.Rows)
                    {
                        VenderPromo = true;
                        IdDescuento = Convert.ToInt32(row["IdDescuento"]);
                        IdArticulo = Convert.ToInt32(row["IdArticulo"]);
                        Codigo = Convert.ToString(row["Codigo"]);
                        //txtCodigoBarras.Text = Codigo;
                        Articulo = Convert.ToString(row["Articulo"]);
                        txtArticulo.Text = Articulo;
                        //Stock = Convert.ToDecimal(row["Stock"]);
                        //txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
                        Stock = CalcularStockRestanteArticuloEspecifico(IdArticulo);
                        txtStock.Text = Stock.ToString("0#.0#", miCultureInfo);
                        CantidadDescuentos = formSeleccionarPromoDescuento.CantidadDescuentos;
                        Cantidad = Convert.ToDecimal(row["Cantidad"]) * CantidadDescuentos;
                        txtCantidad.Text = Cantidad.ToString("#0.###", CultureInfo.InvariantCulture);
                        //CalcularStockRestante();
                        PrecioVenta = Convert.ToDecimal(row["PrecioVenta"]);
                        decimal descuento = (PrecioVenta * Cantidad) - Convert.ToDecimal(row["PrecioVentaDescuento"]);
                        txtDescuento.Text = descuento.ToString("#0.###", CultureInfo.InvariantCulture);
                        //Precio_Venta = Convert.ToDecimal(row["precio_venta_descuento"]);
                        txtPrecio_Venta.Text = PrecioVenta.ToString("#0.###", CultureInfo.InvariantCulture);
                        AgregarVentaDescuento();
                        AgregarDetalle();
                    }
                }
                else
                {
                    MessageBox.Show("Stock insuficiente para vender la promo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se produjo una excepción. Contacte con el administrador del sistema. Mensaje para el administradoe: " + ex.Message + " Trace: " + ex.StackTrace);
            }
        }

        //public void SetPromo(DataTable dtDetallesDescuentosArticulos)
        //{
        //    try
        //    {
        //        frmSeleccionarPromoDescuento formSeleccionarPromoDescuento = frmSeleccionarPromoDescuento.GetInstancia();
        //        txtPromo.Text = NombreDescuento; // formSeleccionarPromoDescuento.NombreDescuento.ToString();
        //        //foreach (DataRow row in dtArt.Rows)
        //        //bool quitarFilasRelacionadas = false;
        //        //int idDescuentoFilasRelacionadas = 0;
        //        foreach (DataRow row in dtDetallesDescuentosArticulos.Rows)
        //        {
        //            VenderPromo = true;
        //            IdDescuento = Convert.ToInt32(row["IdDescuento"]);
        //            IdArticulo = Convert.ToInt32(row["IdArticulo"]);
        //            Codigo = Convert.ToString(row["Codigo"]);
        //            //txtCodigoBarras.Text = Codigo;
        //            Articulo = Convert.ToString(row["Articulo"]);
        //            txtArticulo.Text = Articulo;
        //            Stock = Convert.ToDecimal(row["Stock"]);
        //            txtStock.Text = Stock.ToString("#0.###", CultureInfo.InvariantCulture);
        //            CantidadDescuentos = formSeleccionarPromoDescuento.CantidadDescuentos;
        //            Cantidad = Convert.ToDecimal(row["Cantidad"]) * CantidadDescuentos;
        //            txtCantidad.Text = Cantidad.ToString("#0.###", CultureInfo.InvariantCulture);
        //            //CalcularStockRestante();
        //            PrecioVenta = Convert.ToDecimal(row["PrecioVenta"]);
        //            decimal descuento = (PrecioVenta * Cantidad) - Convert.ToDecimal(row["PrecioVentaDescuento"]);
        //            txtDescuento.Text = descuento.ToString("#0.###", CultureInfo.InvariantCulture);
        //            //Precio_Venta = Convert.ToDecimal(row["precio_venta_descuento"]);
        //            txtPrecio_Venta.Text = PrecioVenta.ToString("#0.###", CultureInfo.InvariantCulture);
        //            if (ValidarVentaDescuento(dtDetallesDescuentosArticulos))
        //            {
        //                AgregarVentaDescuento();
        //                AgregarDetalle();
        //            }
        //            else
        //            {
        //                MessageBox.Show("Stock insuficiente para vender la promo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                break;
        //            }
        //            ////if (dgvVenta.Rows.Count > 0) // ListaCantidadDataTable(dtDetallesDescuentosArticulos, IdDescuento, IdArticulo)) // && Stock >= ListaCantidadDataGridView(dgvVenta, IdArticulo))//ValidarStockDescuento())
        //            ////{
        //            ////    CalcularStockRestante();
        //            ////}
        //            ////if (Stock >= Cantidad)
        //            ////{
        //            ////    AgregarVentaDescuento();
        //            ////    AgregarDetalle();
        //            ////}
        //            ////else
        //            ////{
        //            ////    MessageBox.Show("Stock insuficiente para vender la promo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            ////    break;
        //            ////}
        //            //else
        //            //{
        //            //    //MessageBox.Show("Stock insuficiente para vender la promo.", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            //    decimal menor = 0;
        //            //    //foreach (DataRow quitarFila in dtVentaDescuento.Rows)
        //            //    //{
        //            //    //    if (Convert.ToInt32(quitarFila["IdDescuento"]) == IdDescuento)
        //            //    //    {
        //            //    //        dtVentaDescuento.Rows.Remove(quitarFila);
        //            //    //    }
        //            //    //    if (!validarVentaDescuento())
        //            //    //    {
        //            //    //        break;
        //            //    //    }
        //            //    //}
        //            //    // IMPORTANTE!: SEGUIR AQUÍ, SE AGREGAN LOS PRODUCTOS QUE HAY EN STOCK AUNQUE NO SE TENGA LO SUFICIENTE EN STOCK
        //            //    // EL PROBLEMA ESTÁ EN EL MÉTODO ValidarVentaDescuento()!!!!!!!!!!!!!! Probar: hacer control con foreach
        //            //    //foreach (DataRow quitarDescuentos in dtDetalleVenta.Rows)
        //            //    //{
        //            //    //    if (dtVentaDescuento.Rows.Count < dtDetallesDescuentosArticulos.Rows.Count)
        //            //    //    {
        //            //    //        if (Convert.ToInt32(quitarDescuentos["IdDescuento"]) == IdDescuento)
        //            //    //        {
        //            //    //            //dgvVenta.Rows.Remove(quitarDescuentos);
        //            //    //            //if (dgvVenta.Rows == null)
        //            //    //            //{
        //            //    //            //    dtDetalleVenta.Dispose();dfggs
        //            //    //            //}
        //            //    //            ////QuitarDetalle();
        //            //    //            dtDetalleVenta.Rows.Remove(quitarDescuentos);
        //            //    //            foreach (DataRow quitarFila in dtVentaDescuento.Rows)
        //            //    //            {
        //            //    //                if (Convert.ToInt32(quitarFila["IdDescuento"]) == IdDescuento)
        //            //    //                {
        //            //    //                    dtVentaDescuento.Rows.Remove(quitarFila);
        //            //    //                }
        //            //    //                if (!validarVentaDescuento())
        //            //    //                {
        //            //    //                    dtVentaDescuento.Dispose();
        //            //    //                    break;
        //            //    //                }
        //            //    //            }
        //            //    //        }
        //            //    //    }
        //            //    //    if (dtDetalleVenta.Rows.Count <= 0)
        //            //    //    {
        //            //    //        dtDetalleVenta.Dispose();
        //            //    //        break;
        //            //    //    }
        //            //    //}
        //            //    //foreach (DataGridViewRow restar in dgvVenta.Rows)
        //            //    //{
        //            //    //    if (Convert.ToInt32(restar.Cells["IdDescuento"].Value) == IdDescuento)
        //            //    //    {
        //            //    //        foreach (DataGridViewRow restarCantidad in dgvVenta.Rows)
        //            //    //        {
        //            //    //            if (Convert.ToDecimal(restar.Cells["CantidadDescuentos"].Value) <= Convert.ToDecimal(restarCantidad.Cells["CantidadDescuentos"].Value))
        //            //    //            {   
        //            //    //                menor = Convert.ToDecimal(restar.Cells["CantidadDescuentos"].Value);
        //            //    //            }
        //            //    //        }
        //            //    //    }
        //            //    //}
        //            //    //foreach (DataGridViewRow restar in dgvVenta.Rows)
        //            //    //{
        //            //    //    if (Convert.ToInt32(restar.Cells["IdDescuento"].Value) == IdDescuento)
        //            //    //    {
        //            //    //        restar.Cells["Cantidad"].Value = menor;
        //            //    //    }
        //            //    //}
        //            //    break;
        //            //}
        //        }
        //        txtDescuento.Text = string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Se produjo una excepción. Contacte con el administrador del sistema. Mensaje para el administradoe: " + ex.Message + " Trace: " + ex.StackTrace);
        //    }
        //}

        public bool ValidarVentaDescuento(DataTable dtDetallesDescuentosArticulos)
        {
            bool validacion = false;
            decimal cantidadTotalDetalleDescuento = CalcularCantidadArticulosEnPromo(dtDetallesDescuentosArticulos);
            decimal stockDisponibleParaDescuento = CalcularStockDisponibleParaDescuento(dtDetallesDescuentosArticulos);
            if (stockDisponibleParaDescuento >= cantidadTotalDetalleDescuento)
            {
                validacion = true;
            }
            else
            {
                validacion = false;
            }
            return validacion;
        }

        

        private decimal CalcularCantidadArticulosEnPromo(DataTable dtDetallesDescuentosArticulos)
        {
            decimal cantidadTotalDetalleDescuento = 0;
            foreach (DataRow row in dtDetallesDescuentosArticulos.Rows)
            {
                if (Convert.ToDecimal(row["IdDescuento"]) == IdDescuento) // && Convert.ToDecimal(row["IdArticulo"]) == IdArticulo)
                {
                    cantidadTotalDetalleDescuento += Convert.ToDecimal(row["Cantidad"]) * Convert.ToDecimal(row["CantidadDescuentos"]);
                }
            }
            return cantidadTotalDetalleDescuento;
        }

        private decimal CalcularStockDisponibleParaDescuento(DataTable dtDetallesDescuentosArticulos)
        {
            decimal stockDisponibleParaDescuento = 0;
            decimal cantidadEnDetalleVenta = 0;
            if (dtDetalleVenta.Rows.Count > 0)
            {
                foreach (DataRow rowDetalleDescuento in dtDetallesDescuentosArticulos.Rows)
                {
                    if (IdDescuento == Convert.ToInt32(rowDetalleDescuento["IdDescuento"]))
                    {
                        cantidadEnDetalleVenta += Convert.ToDecimal(rowDetalleDescuento["Cantidad"]) * Convert.ToDecimal(rowDetalleDescuento["CantidadDescuentos"]);
                    }
                }
                stockDisponibleParaDescuento = CalcularStockGrupoDeArticulos(dtDetallesDescuentosArticulos) - cantidadEnDetalleVenta;
            }
            else
            {
                stockDisponibleParaDescuento = CalcularStockGrupoDeArticulos(dtDetallesDescuentosArticulos);
            }
            return stockDisponibleParaDescuento;
        }
        /*
         IdArticulo = Convert.ToInt32(rowDetalleDescuento["IdArticulo"]);
                    Cantidad = Convert.ToDecimal(rowDetalleDescuento["CantidadDescuentos"]) * Convert.ToDecimal(rowDetalleDescuento["Cantidad"]);
                    CalcularStockRestante();
             */

        private decimal CalcularStockGrupoDeArticulos(DataTable dtDetallesDescuentosArticulos)
        {
            decimal stock = 0;
            foreach (DataGridViewRow row in dgvArticulos.Rows)
            {
                foreach (DataRow rowDetalleDescuento in dtDetallesDescuentosArticulos.Rows)
                {
                    if (Convert.ToInt32(row.Cells["IdArticulo"].Value) == Convert.ToInt32(rowDetalleDescuento["IdArticulo"]))
                    {
                        stock += Convert.ToDecimal(row.Cells["Stock"].Value);
                    }
                }
            }
            return stock;
        }

        public bool ValidarDetalleVenta()
        {
            if (dtDetalleVenta.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void CrearVentaDescuento()
        {
            dtVentaDescuento = new DataTable("VentaDescuento");
            dtVentaDescuento.Columns.Add("IdDescuento", Type.GetType("System.Int32"));
            dtVentaDescuento.Columns.Add("IdArticulo", Type.GetType("System.Int32"));
            dtVentaDescuento.Columns.Add("CantidadDescuentos", Type.GetType("System.Int32"));
        }

        private void AgregarVentaDescuento()
        {
            bool insertarVentaDescuento = true;
            foreach (DataRow row in dtVentaDescuento.Rows)
            {
                if (Convert.ToInt32(row["IdDescuento"]) == IdDescuento && IdDescuento > 0)
                {
                    insertarVentaDescuento = false;
                    row["IdDescuento"] = IdDescuento;
                    foreach (DataGridViewRow rowDGVDescuento in dgvVenta.Rows)
                    {
                        if (Convert.ToInt32(row["IdDescuento"]) == Convert.ToInt32(rowDGVDescuento.Cells["IdDescuento"].Value) && Convert.ToInt32(row["IdArticulo"]) == Convert.ToInt32(rowDGVDescuento.Cells["IdArticulo"].Value))
                        {
                            row["CantidadDescuentos"] = Convert.ToDecimal(rowDGVDescuento.Cells["Cantidad"].Value);
                            break;
                        }
                    }
                    //if (Convert.ToInt32(row["IdArticulo"]) == IdArticulo)
                    //{
                    //    row["CantidadDescuentos"] = Convert.ToInt32(row["CantidadDescuentos"]) + Cantidad; // CantidadDescuentos;
                    //}
                    //else
                    //{
                    //    row["CantidadDescuentos"] = Convert.ToInt32(row["CantidadDescuentos"]);
                    //}
                }
            }
            if (insertarVentaDescuento)
            {
                DataRow row = dtVentaDescuento.NewRow();
                row["IdDescuento"] = IdDescuento;
                row["IdArticulo"] = IdArticulo;
                row["CantidadDescuentos"] = CantidadDescuentos;
                dtVentaDescuento.Rows.Add(row);
            }
        }

        private void frmSeleccionarPromoDescuento_dgvListadoDobleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            frmSeleccionarPromoDescuento formSeleccionarPromoDescuento = frmSeleccionarPromoDescuento.GetInstancia();
            //dtArticulos_Descuento = formSeleccionarPromoDescuento.LlenarDetalle_Descuento();
            //Stock = 0;
            SetPromo(formSeleccionarPromoDescuento.LlenarDetalleDescuento());
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
            //else // DESACTIVADO YA QUE EL NRO DE FACTURA SE DEBE GENERAR AUTOMÁTICAMENTE
            //{
            //    txtSerie.Visible = true;
            //    txtCorrelativo.Visible = true;
            //}
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
            dtDeuda = new DataTable("Deudas");
            dtDeuda.Columns.Add("IdDeuda", Type.GetType("System.Int32"));
            // El idventa no es necesario ponerlo ya que en la capadatos DatosVenta.InsertarVentaDeuda() se asignará este valor
            dtDeuda.Columns.Add("CantidadPagos", Type.GetType("System.Int32"));
            dtDeuda.Columns.Add("TotalPagado", Type.GetType("System.Decimal"));
            dtDeuda.Columns.Add("Interes", Type.GetType("System.Decimal"));
            dtDeuda.Columns.Add("Descripcion", Type.GetType("System.String"));
        }
        #endregion

        #region CREAR DETALLE DE LA DEUDA
        private void CrearDetalleDeuda()
        {
            dtDetalleDeuda = new DataTable("DetallesDeuda");
            dtDetalleDeuda.Columns.Add("IdDetalleDeuda", Type.GetType("System.Int32"));
            // El iddeuda se asignara en datosdeuda
            dtDetalleDeuda.Columns.Add("NumeroPago", Type.GetType("System.Int32"));
            dtDetalleDeuda.Columns.Add("Monto", Type.GetType("System.Decimal"));
            dtDetalleDeuda.Columns.Add("FechaPago", Type.GetType("System.DateTime"));
        }
        #endregion

        #endregion

        #endregion

        #region DATAGRIDVIEW VENTA

        #region DETALLE DE LA VENTA
        private void CrearDetalleVenta()
        {
            dtDetalleVenta = new DataTable("DetallesVenta");
            //dtDetalleVenta.Locale = miCultureInfo;
            dtDetalleVenta.Columns.Add("IdDescuento", Type.GetType("System.Int32"));
            dtDetalleVenta.Columns.Add("IdDetalleVenta", Type.GetType("System.Int32"));
            dtDetalleVenta.Columns.Add("IdArticulo", Type.GetType("System.Int32"));
            dtDetalleVenta.Columns.Add("Codigo", Type.GetType("System.String"));
            dtDetalleVenta.Columns.Add("Articulo", Type.GetType("System.String"));
            dtDetalleVenta.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("PrecioVenta", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("Descuento", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("Subtotal", Type.GetType("System.Decimal"));
            dtDetalleVenta.Columns.Add("InsertarDescuento", Type.GetType("System.Boolean"));
            dtDetalleVenta.Columns.Add("CantidadDescuentos", Type.GetType("System.Int32"));
            dgvVenta.DataSource = dtDetalleVenta;
            NombreColumnasDetalle();
        }
        #endregion

        #region NOMBRE COLUMNAS
        private void NombreColumnasDetalle()
        {
            dgvVenta.Columns["IdDescuento"].HeaderText = "Id Descuento";
            dgvVenta.Columns["Codigo"].HeaderText = "Código de barras";
            dgvVenta.Columns["Articulo"].HeaderText = "Artículo";
            dgvVenta.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvVenta.Columns["Cantidad"].DefaultCellStyle.Format = "#0.###";
            dgvVenta.Columns["PrecioVenta"].HeaderText = "Precio";
            dgvVenta.Columns["PrecioVenta"].DefaultCellStyle.Format = "$#0.##";
            dgvVenta.Columns["Descuento"].HeaderText = "Descuento";
            dgvVenta.Columns["Descuento"].DefaultCellStyle.Format = "$#0.##";
            dgvVenta.Columns["Subtotal"].HeaderText = "Subtotal";
            dgvVenta.Columns["Subtotal"].DefaultCellStyle.Format = "$#0.##";
            dgvVenta.Columns["InsertarDescuento"].HeaderText = "Promo";
            dgvVenta.Columns["CantidadDescuentos"].HeaderText = "Cantidad Promos";
        }
        #endregion

        #region OCULTAR COLUMNAS
        private void OcultarColumnasDetalle()
        {
            dgvVenta.Columns["IdDescuento"].Visible = false;
            dgvVenta.Columns["Codigo"].Visible = false;
            dgvVenta.Columns["chkEliminar"].Visible = false;
            dgvVenta.Columns["IdDetalleVenta"].Visible = false;
            dgvVenta.Columns["IdArticulo"].Visible = false;
            dgvVenta.Columns["InsertarDescuento"].Visible = false;
            dgvVenta.Columns["CantidadDescuentos"].Visible = false;
            DeshabilitarOrdenamientoColumnas();
        }
        #endregion

        #region DESHABILITAR ORDENAMIENTO DE REGISTROS POR COLUMNA ESPECIFICADA
        private void DeshabilitarOrdenamientoColumnas()
        {
            foreach (DataGridViewColumn columna in dgvVenta.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
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
                if (txtCodigoBarras.Text == Convert.ToString(row.Cells["Codigo"].Value) && txtCodigoBarras.Text != string.Empty)
                {
                    dgvArticulos.Rows[row.Index].Selected = true;
                    dgvArticulos.CurrentCell = dgvArticulos.Rows[row.Index].Cells[1];
                    DgvArticulos_Click();
                    //txtCodigoBarras.SelectAll();
                }
            }
        }
        #endregion

        #region EVENTO KEYDOWN
        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)// && txtCodigoBarras.Text != string.Empty)
            {
                e.SuppressKeyPress = true;
                if (lblPresentacion.Text.ToUpper() == "KG")
                {
                    txtCantidad.SelectAll();
                }
                else
                {
                    btnAgregar.PerformClick();
                    txtCodigoBarras.SelectAll();
                }
            }
        }
        #endregion

        #endregion

        #region AGREGAR DETALLE
        private void AgregarDetalle()
        {
            Cantidad = Convert.ToDecimal(txtCantidad.Text, CultureInfo.InvariantCulture);
            //Descuento = Convert.ToDecimal(txtDescuento.Text, CultureInfo.InvariantCulture);
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
                //foreach (DataGridViewRow row in dgvVenta.Rows)
                //{
                //    if (Convert.ToInt32(row.Cells["IdArticulo"].Value) == IdArticulo && Convert.ToBoolean(row.Cells["InsertarDescuento"].Value) == true)
                //    {
                //        dgvVenta.Rows.Remove(dgvVenta.CurrentRow);
                //    }
                //}
            }
            else if (Stock <= 0) // (Convert.ToDecimal(txtStock.Text, CultureInfo.InvariantCulture) <= 0)
            {
                MessageBox.Show("No dispone de stock para realizar la venta", "Stock insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (PrecioVenta == 0)
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
                        if (Convert.ToInt32(row["IdArticulo"]) == IdArticulo && Convert.ToInt32(row["IdDescuento"]) == IdDescuento)// && Convert.ToInt32(row["IdDescuento"]) == IdDescuento)
                        {
                            insertarDetalle = false;
                            //NotificacionError("El artículo ya se encuentra ingresado.Si éste pertenece a otro 
                            //proveedor selecciónelo en la lista de la esquina superior izquierda de ésta ventana", "Error");
                            decimal subTotal = (Cantidad * PrecioVenta) - Descuento;
                            Total = Total + subTotal;
                            row["IdDescuento"] = IdDescuento;
                            row["IdDetalleVenta"] = IdDetalleVenta;
                            row["IdArticulo"] = IdArticulo;
                            row["Codigo"] = Codigo;
                            row["Articulo"] = Articulo;
                            row["Cantidad"] = Convert.ToDecimal(row["Cantidad"]) + Cantidad;
                            row["PrecioVenta"] = PrecioVenta;
                            row["Descuento"] = Convert.ToDecimal(row["Descuento"]) + Convert.ToDecimal(Descuento);
                            row["Subtotal"] = Convert.ToDecimal(row["Subtotal"]) + subTotal; //Convert.ToDecimal(row["cantidad"]) * Convert.ToDecimal(row["precio_venta"]);
                            row["InsertarDescuento"] = VenderPromo;
                            row["CantidadDescuentos"] = Convert.ToInt32(row["CantidadDescuentos"]) + CantidadDescuentos;
                            decimal stockRestante = Stock - Convert.ToDecimal(row["Cantidad"], CultureInfo.InvariantCulture);
                            txtStock.Text = stockRestante.ToString("#0.####", CultureInfo.InvariantCulture);
                        }
                    }
                    if (insertarDetalle)
                    {
                        decimal subTotal = (Cantidad * PrecioVenta) - Descuento;
                        Total = Total + subTotal;
                        //Agregar detalle a dtDetalle
                        DataRow row = dtDetalleVenta.NewRow();
                        row["IdDescuento"] = IdDescuento;
                        row["IdDetalleVenta"] = IdDetalleVenta;
                        row["IdArticulo"] = IdArticulo;
                        row["Codigo"] = Codigo;
                        row["Articulo"] = Articulo;
                        row["Cantidad"] = Cantidad;
                        row["Descuento"] = Descuento;
                        row["PrecioVenta"] = PrecioVenta;
                        row["Subtotal"] = subTotal; // - Descuento;
                        row["InsertarDescuento"] = VenderPromo;
                        row["CantidadDescuentos"] = CantidadDescuentos;
                        dtDetalleVenta.Rows.Add(row);
                        decimal stockRestante = Stock - Convert.ToDecimal(row["Cantidad"], CultureInfo.InvariantCulture);
                        txtStock.Text = stockRestante.ToString("#0.####", CultureInfo.InvariantCulture);
                    }
                    lblTotal.Text = Total.ToString("#0.##", miCultureInfo);
                    ColorFilas();
                    txtCodigoBarras.Text = Codigo;
                    Descuento = 0.00m;
                    txtDescuento.Text = Descuento.ToString("$#0.#0", CultureInfo.InvariantCulture);
                    CalcularDescuentoGeneral(DescuentoGeneral);
                    Cantidad = 1.00m;
                    txtCantidad.Text = Cantidad.ToString("#0.###", CultureInfo.InvariantCulture);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                finally
                {
                    CalcularTotalFinal();
                }
            }
        }
        #endregion

        #region BOTON AGREGAR ARTICULO
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                IdDescuento = 0;
                AgregarDetalle();
                if (cmbModoPago.SelectedIndex != 0)
                {
                    CalculoDeuda();
                }
            }
            catch { }
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
                                #region NO FUNCA PRUEBA FALLIDA
                                /*
                             
                                int cantidadDeRegistrosABorrar = 0;
                                foreach (DataRow rowDetalleVenta in dtDetalleVenta.Rows)
                                {
                                    if (IdDescuento == Convert.ToInt32(rowDetalleVenta["IdDescuento"]))
                                    {
                                        cantidadDeRegistrosABorrar++;
                                    }
                                    //foreach (DataRow rowCopiaDetalleVenta in dtCopiaDetalleVenta.Rows)
                                    //{
                                    //    Total = Total - Convert.ToDecimal(rowCopiaDetalleVenta["Subtotal"].ToString());
                                    //    lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                                    //    if (IdDescuento == Convert.ToInt32(rowCopiaDetalleVenta["IdDescuento"]))
                                    //    {
                                    //        dtCopiaDetalleVenta.Rows.Remove(rowCopiaDetalleVenta);
                                    //        dtDetalleVenta = dtCopiaDetalleVenta;
                                    //        break;
                                    //    }
                                    //}
                                    //txtStock.Text = Stock.ToString("#0.####", CultureInfo.InvariantCulture);
                                }
                                int[] indicesABorrar = new int[cantidadDeRegistrosABorrar];
                                for (int i = 0; i < cantidadDeRegistrosABorrar; i++)
                                {
                                    foreach (DataGridViewRow row in dgvVenta.Rows)
                                    {
                                        if (IdDescuento == Convert.ToInt32(row.Cells["IdDescuento"].Value))
                                        {
                                            indicesABorrar[i] = row.Index;
                                        }
                                    }
                                }

                                //for (int i = 0; i < dtDetalleVenta.Rows.Count; i++)
                                //{
                                //    DataRow row = dtDetalleVenta.Rows[indicesABorrar[i]];
                                //    dtDetalleVenta.Rows.Remove(row);
                                //}

                                for (int i = 0; i < cantidadDeRegistrosABorrar; i++)
                                {
                                    foreach (DataGridViewRow row in dgvVenta.Rows)
                                    {
                                        if (Convert.ToInt32(row.Cells["IdDescuento"].Value) == IdDescuento)
                                        {
                                            foreach (DataRow rowDtDetalleVenta in dtDetalleVenta.Rows)
                                            {
                                                if (Convert.ToInt32(rowDtDetalleVenta["IdDescuento"]) == IdDescuento)
                                                {
                                                    dtDetalleVenta.Rows.Remove(rowDtDetalleVenta);
                                                }
                                            }
                                        }
                                    }
                                }

                                //dtDetalleVenta.AcceptChanges();

                                

    
                             */
                                #endregion
                                #region FUNCA MAL
                                //for (int i = 0; i <= dgvVenta.Rows.Count; i++)
                                //{
                                //    foreach (DataGridViewRow row in dgvVenta.Rows)
                                //    {
                                //        //row.Selected = true;
                                //        //IdDescuento = Convert.ToInt32(row.Cells["IdDescuento"].Value);
                                //        if (IdDescuento == Convert.ToInt32(row.Cells["IdDescuento"].Value))
                                //        {
                                //            int indiceFila = row.Index;
                                //            DataRow rowDtDetalleVenta = dtDetalleVenta.Rows[indiceFila];
                                //            //Disminuir el total pagado
                                //            Total = Total - Convert.ToDecimal(rowDtDetalleVenta["Subtotal"].ToString());
                                //            lblTotal.Text = Total.ToString("#0.##", CultureInfo.InvariantCulture);
                                //            for (int j = 0; j < dtVentaDescuento.Rows.Count; j++)
                                //            {
                                //                DataRow rowVentaDescuento = dtVentaDescuento.Rows[j];
                                //                if (IdDescuento == Convert.ToInt32(rowVentaDescuento["IdDescuento"]))
                                //                {
                                //                    dtVentaDescuento.Rows.Remove(rowVentaDescuento);
                                //                }
                                //            }
                                //            dtDetalleVenta.Rows.Remove(rowDtDetalleVenta);
                                //            txtStock.Text = Stock.ToString("#0.####", CultureInfo.InvariantCulture);
                                //        }
                                //    }
                                //}
                                #endregion

                                //Borrar registros en detalles de descuentos
                                for (int i = 0; i < dtVentaDescuento.Rows.Count; i++)
                                {
                                    if (Convert.ToInt32(dtVentaDescuento.Rows[i]["IdDescuento"]) == IdDescuento)
                                    {
                                        dtVentaDescuento.Rows.Remove(dtVentaDescuento.Rows[i]);
                                    }
                                }

                                int cantidadDeRegistrosABorrar = 0;
                                foreach (DataRow rowDetalleVenta in dtDetalleVenta.Rows)
                                {
                                    if (IdDescuento == Convert.ToInt32(rowDetalleVenta["IdDescuento"]))
                                    {
                                        cantidadDeRegistrosABorrar++;
                                    }
                                }

                                int cantidadFilas = dtDetalleVenta.Rows.Count;
                                int cantidadDeRegistrosBorrados = 0;
                                for (int i = 0; i < cantidadFilas; i++)
                                {
                                    
                                    while (Convert.ToInt32(dtDetalleVenta.Rows[i]["IdDescuento"]) == IdDescuento && cantidadFilas > 0)
                                    {
                                        dtDetalleVenta.Rows.Remove(dtDetalleVenta.Rows[i]);
                                        cantidadFilas = dtDetalleVenta.Rows.Count;
                                        cantidadDeRegistrosBorrados++;
                                        if (cantidadFilas == 0 || cantidadDeRegistrosBorrados == cantidadDeRegistrosABorrar)
                                        {
                                            break;
                                        }
                                    }
                                }
                                // CONTINUAR AQUÍ: PRUEBAS: REALIZAR VENTA - AGREGAR DETALLES Y QUITARLOS E INTENTAR REALIZAR VENTA
                            }
                            else
                            {
                                int indiceFila = dgvVenta.CurrentCell.RowIndex;
                                DataRow row = dtDetalleVenta.Rows[indiceFila];
                                //Disminuir el total pagado
                                Total = Total - Convert.ToDecimal(row["Subtotal"].ToString());
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
                            int idDetalleVenta;
                            string respuesta = "";
                            DialogResult Opcion;
                            Opcion = MessageBox.Show(
                                "¿Realmente desea eliminar el item seleccionado?",
                                "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (Opcion == DialogResult.Yes)
                            {
                                idDetalleVenta = Convert.ToInt32(dgvVenta.CurrentRow.Cells["IdDetalleVenta"].Value);
                                respuesta = NegocioIngreso.Eliminar(Convert.ToInt32(idDetalleVenta));
                                if (respuesta.Equals("OK"))
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
                IdDescuento = -1;
                RecalcularTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mensaje: " + ex.Message + " Traza: " + ex.StackTrace);
                NotificacionError("No hay ningún item añadido.", "Error");
            }
        }
        #endregion

        private void RecalcularTotal()
        {
            decimal subtotal = 0;
            if (dtDetalleVenta.Rows.Count <= 0)
            {
                Total = 0;
            }
            else
            {
                foreach (DataRow row in dtDetalleVenta.Rows)
                {
                    subtotal += Convert.ToDecimal(row["Subtotal"].ToString());
                    Total = subtotal;
                }
            }
            lblTotal.Text = Total.ToString("0#.0#", CultureInfo.InvariantCulture);
        }

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
            if (dtVentaDescuento.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region DESCUENTO GENERAL

        bool descuentoGeneralValidado = false;
        decimal DescuentoGeneral = 0;
        private void txtDescuentoGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DireccionarEventoDeControl(sender, e);
            //validaciones.IngresarNumeroDecimal(e);
            controlTeclado.DeshabilitarPegado(sender, e);
            Validacion.Validacion validacionesDescuentoGeneral = Validacion.Validacion.GetInstancia();
            descuentoGeneralValidado = validacionesDescuentoGeneral.ValidarDecimal(sender, e);
        }

        private void txtDescuentoGeneral_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (descuentoGeneralValidado)
                {
                    Validacion.Validacion validacionesDescuentoGeneral = Validacion.Validacion.GetInstancia();
                    //decimal descuentoGeneral = validacionesDescuentoGeneral.FormatearDecimal(sender, "Moneda");
                    DescuentoGeneral = validacionesDescuentoGeneral.FormatearDecimal(sender, "Moneda");
                    //lblTotalConDescuento.Text = CalcularDescuentoGeneral(descuentoGeneral).ToString("$#0.#0", miCultureInfo);

                    lblTotalConDescuento.Text = CalcularDescuentoGeneral(DescuentoGeneral).ToString("$#0.#0", miCultureInfo);

                    CalcularTotalFinal();
                }
            }
            catch { }
        }
        private void txtDescuentoGeneral_Click(object sender, EventArgs e)
        {
            txtDescuentoGeneral.SelectAll();
            Validacion.Validacion validacionesDescuentoGeneral = Validacion.Validacion.GetInstancia();
            validacionesDescuentoGeneral.LimpiarVariablesDeFormateoDecimal();
            validacionesDescuentoGeneral.DefaultPosition(sender, 0, 2);
        }

        private void txtDescuentoGeneral_Leave(object sender, EventArgs e)
        {
            validacionesDescuentoGeneral.Dispose();
            //validacionesDescuentoGeneral = null;
        }

        private decimal CalcularDescuentoGeneral(decimal descuentoGeneral)
        {
            decimal totalConDescuento = Total - descuentoGeneral;
            lblTotalConDescuento.Text = totalConDescuento.ToString("$#0.#0", CultureInfo.InvariantCulture);
            return totalConDescuento;
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            DialogResult opcion;
            opcion = MessageBox.Show("¿Concretar venta?. Seleccione 'ACEPTAR' para concretarla o 'CANCELAR' para deshacer.", 
                "VERIFICACIÓN DE LA VENTA.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.OK)
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
        }

        private void CalcularTotalDescuentoGeneral()
        {
            Total = DescuentoGeneral; // Convert.ToDecimal(lblTotalConDescuento.Text);
        }
        #endregion

        #region DESCUENTO POR ARTÍCULO

        bool descuentoPorArticuloValidado = false;
        private void txtDescuento_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DireccionarEventoDeControl(sender, e);
            //validaciones.IngresarNumeroDecimal(e);

            Validacion.Validacion validacionesDescuentoPorArticulo = Validacion.Validacion.GetInstancia();
            descuentoPorArticuloValidado = validacionesDescuentoPorArticulo.ValidarDecimal(sender, e);
        }

        private void txtDescuento_TextChanged(object sender, EventArgs e)
        {
            if (descuentoPorArticuloValidado)
            {
                Validacion.Validacion validacionesDescuentoPorArticulo = Validacion.Validacion.GetInstancia();
                Descuento = validacionesDescuentoPorArticulo.FormatearDecimal(sender, "Moneda");
            }
        }

        private void txtDescuento_Click(object sender, EventArgs e)
        {
            txtDescuento.SelectAll();
            Validacion.Validacion validacionesDescuentoPorArticulo = Validacion.Validacion.GetInstancia();
            validacionesDescuentoPorArticulo.LimpiarVariablesDeFormateoDecimal();
            validacionesDescuentoPorArticulo.DefaultPosition(sender, 0, 2);
        }

        private void txtDescuento_Leave(object sender, EventArgs e)
        {
            validacionesDescuentoPorArticulo.Dispose();
            //validacionesDescuentoPorArticulo = null;
            //if (txtDescuento.Text == string.Empty)
            //{
            //    txtDescuento.Text = "0";
            //}
        }
        #endregion

        private void InsertarVenta()
        {
            string agregarActualizar = "";
            frmPrincipal formPrincipal = frmPrincipal.GetInstancia();
            IdCaja = formPrincipal.IdCaja;
            IdEmpleado = formPrincipal.IdEmpleado;
            Fecha = dtpFecha.Value;
            TipoComprobante = cmbComprobante.Text;
            Serie = txtSerie.Text;
            Correlativo = txtCorrelativo.Text;
            IVA = Convert.ToDecimal(txtIVA.Text);
            Total = Convert.ToDecimal(lblTotal.Text, CultureInfo.InvariantCulture);
            //if (DescuentoGeneral > 0)// Convert.ToDecimal(txtDescuentoGeneral.Text) > 0)
            //{
            //    CalcularTotalDescuentoGeneral();
            //}
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
            if (txtArticulo.Text == string.Empty)
            {
                errorIcono.SetError(txtArticulo, "Ingrese un artículo");
            }
            else if (Convert.ToDecimal(txtCantidad.Text) <= 0)
            {
                errorIcono.SetError(txtCantidad, "El stock final no puede ser 0 (cero)");
            }
            else if (PrecioVenta == 0)
            {
                errorIcono.SetError(txtPrecio_Venta, "No hay establecido un precio para la venta al público de este artículo");
            }
            else
            {
                CalcularTotalFinal();
                try
                {
                    if (ValidarDetalleVenta())
                    {
                        switch (ctrlSeleccionado)
                        {
                            case 0://INSERTAR
                                if (cmbModoPago.SelectedIndex != 0)
                                {
                                    CalculoDeuda();
                                    CantidadPagos = nudCantidadPagos.Value;
                                    //TotalPagado = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                                    TotalPagado = Convert.ToDecimal(txtMontoPorCuota.Text, CultureInfo.InvariantCulture);
                                    Interes = Convert.ToDecimal(txtInteres.Text, CultureInfo.InvariantCulture);
                                    Descripcion = txtDescripcion.Text;

                                    //Agregar deuda a dtDeuda
                                    DataRow rowDeuda = dtDeuda.NewRow();
                                    rowDeuda["CantidadPagos"] = CantidadPagos;
                                    rowDeuda["TotalPagado"] = TotalPagado;
                                    rowDeuda["Interes"] = Interes;
                                    rowDeuda["Descripcion"] = Descripcion;
                                    dtDeuda.Rows.Add(rowDeuda);

                                    for (int i = 1; i <= CantidadPagos; i++)
                                    {
                                        // Agregar detalle a dtDetalle_Deuda
                                        DataRow rowDetalleDeuda = dtDetalleDeuda.NewRow();
                                        rowDetalleDeuda["NumeroPago"] = i;
                                        Monto = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                                        FechaPago = dtpFecha.Value + DateTime.Now.TimeOfDay;
                                        rowDetalleDeuda["Monto"] = Monto;
                                        rowDetalleDeuda["FechaPago"] = FechaPago;
                                        // LINEAS DESHABILITADAS PARA QUE LOS PAGOS SEAN FIJOS. // AGREGAR EN EL FUTURO POSIBILIDAD DE REFINANCIACION...
                                        // POSIBILIDAD DE REFINANCIACION COMO MANTENIMIENTO DEL SISTEMA APARTE...
                                        //if (i == 1)
                                        //{
                                        //    Monto = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                                        //    FechaPago = dtpFecha.Value + DateTime.Now.TimeOfDay;
                                        //    rowDetalleDeuda["Monto"] = Monto;
                                        //    rowDetalleDeuda["FechaPago"] = FechaPago;
                                        //}
                                        //else
                                        //{
                                        //    rowDetalleDeuda["Monto"] = 0;
                                        //    rowDetalleDeuda["FechaPago"] = DateTime.Now + DateTime.Now.TimeOfDay;
                                        //}
                                        dtDetalleDeuda.Rows.Add(rowDetalleDeuda);
                                    }
                                    if (validarVentaDescuento())
                                    {
                                        agregarActualizar = NegocioVenta.Insertar(IdCaja, IdCliente, IdEmpleado, Fecha, TipoComprobante, Serie.Trim().ToUpper(),
                                        Correlativo.Trim().ToUpper(), IVA, DescuentoGeneral, TotalFinal, cmbModoPago.Text, dtDetalleVenta, dtDeuda, dtDetalleDeuda, true, dtVentaDescuento);
                                    }
                                    else
                                    {
                                        agregarActualizar = NegocioVenta.Insertar(IdCaja, IdCliente, IdEmpleado, Fecha, TipoComprobante, Serie.Trim().ToUpper(),
                                        Correlativo.Trim().ToUpper(), IVA, DescuentoGeneral, TotalFinal, cmbModoPago.Text, dtDetalleVenta, dtDeuda, dtDetalleDeuda, true);
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
                                    //dtDeuda.Dispose();
                                    //dtDetalleDeuda.Dispose();
                                    //dtDeuda.Clear();
                                    //dtDetalle_Deuda.Clear();
                                    if (validarVentaDescuento())
                                    {
                                        agregarActualizar = NegocioVenta.Insertar(IdCaja, IdCliente, IdEmpleado, Fecha, TipoComprobante, Serie.Trim().ToUpper(),
                                            Correlativo.Trim().ToUpper(), IVA, DescuentoGeneral, TotalFinal, "PAGADA", dtDetalleVenta, dtVentaDescuento);
                                    }
                                    else if (ValidarDetalleVenta())
                                    {
                                        agregarActualizar = NegocioVenta.Insertar(IdCaja, IdCliente, IdEmpleado, Fecha, TipoComprobante, Serie.Trim().ToUpper(),
                                            Correlativo.Trim().ToUpper(), IVA, DescuentoGeneral, TotalFinal, "PAGADA", dtDetalleVenta);// Convert.ToDecimal(txtDescuentoGeneral.Text), Total, "PAGADA", dtDetalleVenta);
                                    }
                                    //if (!ValidarDetalleVenta())
                                    //{
                                    //    NotificacionError("Ingrese un artículo", "Error");
                                    //}
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
                    else
                    {
                        MessageBox.Show("Ingrese un artículo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //dtVentaDescuento.Dispose();
                    //dtDetalleVenta.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + ex.StackTrace);
                }
                finally
                {
                    DescuentoGeneral = 0;
                    Limpiar();
                    dtDeuda.Clear();
                    dtDeuda.AcceptChanges();
                    dtDetalleDeuda.Clear();
                    dtDetalleDeuda.AcceptChanges();
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

        decimal TotalConInteres = 0;

        private void CalculoDeuda()
        {
            if (Interes > 0)
            {
                TotalConInteres = Total + ((Total * Interes) / 100);
                lblTotalConInteres.Text = TotalConInteres.ToString("$#0.#0", CultureInfo.InvariantCulture);
                decimal MontoPorCuota = TotalConInteres / nudCantidadPagos.Value;
                txtMontoPorCuota.Text = MontoPorCuota.ToString("#0.##", CultureInfo.InvariantCulture);
                decimal MontoPagado = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                decimal MontoRestante = TotalConInteres - MontoPagado;
                txtMontoRestante.Text = MontoRestante.ToString("#0.##", CultureInfo.InvariantCulture);
            }
            else if (Interes == 0)
            {
                lblTotalConInteres.Text = TotalConInteres.ToString("$#0.#0", CultureInfo.InvariantCulture);
                decimal MontoPorCuota = Total / nudCantidadPagos.Value;
                txtMontoPorCuota.Text = MontoPorCuota.ToString("#0.##", CultureInfo.InvariantCulture);
                decimal MontoPagado = Convert.ToDecimal(txtMontoPagado.Text, CultureInfo.InvariantCulture);
                decimal MontoRestante = Total - MontoPagado;
                txtMontoRestante.Text = MontoRestante.ToString("#0.##", CultureInfo.InvariantCulture);
            }
            CalcularTotalFinal();
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

        bool cantidadValidada = false;
        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            //TextBox control = (TextBox)sender;
            //validaciones.DesactivarTeclasDireccionales(e);
            //validaciones.DesactivarTeclasEdicion(e);
            //validaciones.DesactivarCopiadoPegado(e);
            //ValidarCantidadMinima(control);
            Validacion.Validacion validacionesCantidad = Validacion.Validacion.GetInstancia();
            validacionesCantidad.Desactivar(e);
            if (e.KeyCode == Keys.Enter)
            {
                btnAgregar.PerformClick();
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DeshabilitarPegado(sender, e);
            Validacion.Validacion validacionesCantidad = Validacion.Validacion.GetInstancia();
            cantidadValidada = validacionesCantidad.ValidarDecimal(sender, e);
        }

        private void txtCantidad_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (cantidadValidada)
                {
                    Validacion.Validacion validacionesCantidad = Validacion.Validacion.GetInstancia();
                    validacionesCantidad.FormatearDecimal(sender, "TresDecimales");
                }
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
        
        private void txtCantidad_Click(object sender, EventArgs e)
        {
            txtCantidad.SelectAll();
            Validacion.Validacion validacionesCantidad = Validacion.Validacion.GetInstancia();
            validacionesCantidad.LimpiarVariablesDeFormateoDecimal();
            validacionesCantidad.DefaultPosition(sender, 0, 3);
        }

        private void txtCantidad_Leave(object sender, EventArgs e)
        {
            validacionesCantidad.Dispose();
            //validacionesCantidad = null;
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

        //private void ValidarCantidadMinima(TextBox control)
        //{
        //    if (control.Text == string.Empty || control.Text == "" || Convert.ToDecimal(control.Text) < 0.1m)
        //    {
        //        control.Text = "1.00";
        //    }
        //}

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
                IdDescuento = Convert.ToInt32(dgvVenta.CurrentRow.Cells["IdDescuento"].Value);
                VenderPromo = Convert.ToBoolean(dgvVenta.CurrentRow.Cells["InsertarDescuento"].Value);
                foreach (DataGridViewRow row in dgvVenta.Rows)
                {
                    if (IdDescuento > 0 && IdDescuento == Convert.ToInt32(row.Cells["IdDescuento"].Value) && VenderPromo)
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
                IdDescuento = Convert.ToInt32(row.Cells["IdDescuento"].Value);
                VenderPromo = Convert.ToBoolean(row.Cells["InsertarDescuento"].Value);
                if (IdDescuento > 0 && IdDescuento == Convert.ToInt32(row.Cells["IdDescuento"].Value) && VenderPromo)
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
        }

        private void dgvArticulos_KeyUp(object sender, KeyEventArgs e)
        {
            DgvArticulos_Click();
        }

        private void dgvArticulos_KeyDown(object sender, KeyEventArgs e)
        {
            if (controlTeclado.DireccionarEventoDeControl(sender, e))
            {
                if (lblPresentacion.Text.ToUpper() == "KG")
                {
                    txtCantidad.SelectAll();
                }
                else
                {
                    btnAgregar.PerformClick();
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            PintarControles(panel, e);
        }

        private void PintarControles(Panel panel, PaintEventArgs e)
        {
            foreach (Control control in panel.Controls)
            {
                using (SolidBrush brush = new SolidBrush(Color.WhiteSmoke))
                    e.Graphics.FillRectangle(brush, e.ClipRectangle);
            }
        }

        decimal TotalFinal = 0;

        private void CalcularTotalFinal()
        {
            TotalFinal = 0;
            if (Interes > 0)
            {
                TotalFinal = TotalConInteres - DescuentoGeneral;
            }
            else
            {
                TotalFinal = Total - DescuentoGeneral;
            }
            lblTotalFinal.Text = TotalFinal.ToString("$#0.#0", CultureInfo.InvariantCulture);
        }
    }
}