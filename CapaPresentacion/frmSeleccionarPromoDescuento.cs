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

namespace CapaPresentacion
{
    public partial class frmSeleccionarPromoDescuento : MaterialForm
    {
        frmIngresarVenta formIngresarVenta = frmIngresarVenta.GetInstancia();
        public int IdDescuento;
        public string NombreDescuento;
        public string Descripcion;

        public int IdArticulo;
        public string Codigo;
        public string Articulo;
        public decimal Cantidad;
        public decimal PrecioVenta;
        public decimal PrecioVentaDescuento;
        public decimal Stock;
        public int CantidadDescuentos;

        //frmIngresarVenta formIngresarVenta = frmIngresarVenta.GetInstancia();
        DataTable dtDetalleDescuento = new DataTable();
        DataTable dtArticulos = new DataTable();

        public frmSeleccionarPromoDescuento()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmSeleccionarPromoDescuento_Load(object sender, EventArgs e)
        {
            Mostrar();
            txtBuscar.SelectAll();
            txtBuscar.Hint = "Artículo";
        }

        #region INSTANCIACIÓN
        private static frmSeleccionarPromoDescuento _Instancia = null;

        public static frmSeleccionarPromoDescuento Instancia
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

        public static frmSeleccionarPromoDescuento GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmSeleccionarPromoDescuento();
            }
            return Instancia;
        }

        private void frmSeleccionarPromoDescuento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region COLUMNAS DE DATAGRIDVIEW
        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns["IdDescuento"].HeaderText = "Id";
                dgvListado.Columns["NombreDescuento"].HeaderText = "Promo";
                dgvListado.Columns["Descripcion"].HeaderText = "Descripción";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region METODO MOSTRAR
        //MOSTRAR
        public void Mostrar()
        {
            dgvListado.DataSource = NegocioDescuento.MostrarPromosHabilitadas();
            NombreColumnas();
        }
        #endregion

        #region BUSQUEDA

        #region BUSQUEDA DETALLE DEL DESCUENTO
        public DataTable LlenarDetalleDescuento()
        {
            dtDetalleDescuento = NegocioDetalleDescuento.Mostrar(IdDescuento);
            CrearDetalleArticulos();
            foreach (DataRow row in dtDetalleDescuento.Rows)
            {
                IdArticulo = Convert.ToInt32(row["IdArticulo"]);
                Cantidad = Convert.ToDecimal(row["Cantidad"]);
                PrecioVentaDescuento = Convert.ToDecimal(row["PrecioVentaDescuento"]);
                CantidadDescuentos = Convert.ToInt32(txtCantidad_Descuentos.Text);
                DataTable dtArticulosTemp = NegocioArticulo.Buscar(IdArticulo);
                DataRow rowArt = dtArticulos.NewRow();
                foreach (DataRow rowTemp in dtArticulosTemp.Rows)
                {
                    rowArt["IdDescuento"] = IdDescuento;
                    rowArt["IdArticulo"] = rowTemp["IdArticulo"];
                    rowArt["Codigo"] = rowTemp["Codigo"];
                    rowArt["Articulo"] = rowTemp["Articulo"];
                    rowArt["Cantidad"] = Cantidad;
                    rowArt["PrecioCompra"] = rowTemp["PrecioCompra"];
                    rowArt["PrecioVenta"] = rowTemp["PrecioVenta"];
                    rowArt["PrecioVentaDescuento"] = PrecioVentaDescuento;
                    rowArt["Stock"] = rowTemp["Stock"];
                    rowArt["CantidadDescuentos"] = CantidadDescuentos;
                    //rowArt["en_promo"] = true;
                }
                dtArticulos.Rows.Add(rowArt);
            }
            return dtArticulos;
        }
        #endregion

        #region COLUMNAS DATATABLE ARTICULOS
        private void CrearDetalleArticulos()
        {
            dtArticulos = new DataTable("DetalleArticulos");
            dtArticulos.Locale = CultureInfo.InvariantCulture;
            dtArticulos.Columns.Add("IdDescuento", Type.GetType("System.Int32"));
            dtArticulos.Columns.Add("IdArticulo", Type.GetType("System.Int32"));
            dtArticulos.Columns.Add("Codigo", Type.GetType("System.String"));
            dtArticulos.Columns.Add("Articulo", Type.GetType("System.String"));
            dtArticulos.Columns.Add("Cantidad", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("PrecioCompra", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("PrecioVenta", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("PrecioVentaDescuento", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("Stock", Type.GetType("System.Decimal"));
            dtArticulos.Columns.Add("InsertarPromo", Type.GetType("System.Boolean"));
            dtArticulos.Columns.Add("CantidadDescuentos", Type.GetType("System.Int32"));
        }
        #endregion

        //METODO BUSCAR POR NOMBRE
        private void Buscar()
        {
            dgvListado.DataSource = NegocioDescuento.BuscarDescuentosHabilitados(txtBuscar.Text);
        }

        #region TEXTBOX BUSCAR
        //TEXTBOX BUSCAR POR NOMBRE
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar();
                if (txtBuscar.TextLength > 0)
                {
                    //txtBuscar.Width = 166;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error en la consulta. Contacte con el administrador del sistema", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #endregion

        #region METODO DOBLE CLICK EN DATAGRID
        private void DobleClickDgv()
        {
            try
            {
                ClickFila();
                //formIngresarVenta.SetPromo(LlenarDetalleDescuento());
                LlenarDetalleDescuento();
            }
            catch
            { }
        }
        #endregion

        #region CLICK EN FILA
        private void ClickFila()
        {
            IdDescuento = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdDescuento"].Value);
            formIngresarVenta.IdDescuento = IdDescuento;
            formIngresarVenta.NombreDescuento = Convert.ToString(dgvListado.CurrentRow.Cells["NombreDescuento"].Value);
            //formIngresarVenta.DescripcionDescuento = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value);
        }

        #endregion

        #region DOBLE CLICK EN DATAGRID
        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            DobleClickDgv();
        }
        #endregion

        #region COMPORTAMIENTO TECLADO
        //PARA DEFINIR EL COMPORTAMIENTO DEL FORMULARIO AL PRESIONAR UNA TECLA SE DEBE ESTABLECER LA PROPIEDAD KeyPreview DEL FORM en true
        #region TECLA ESCAPE
        private void cerrarForm(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtBuscar.Focus())
                {
                    Close();
                }
                else
                {
                    txtBuscar.SelectAll();
                }
            }
        }
        #endregion

        #region TECLA ENTER
        private void enterKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                dgvListado.Focus();
            }
        }
        #endregion

        #region EVENTOS KEYPRESS CONTRTOLES
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterKeyPress(e);
        }
        #endregion

        #region DATAGRID
        //SE CONFIGURARÁ ESTE EVENTO PARA EVITAR QUE AL PRESIONAR ENTER, SE DESPLACE A LA FILA SIGUIENTE DEL DATAGRIDVIEW Y LLAME AL FORMULARIO HIJO
        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DobleClickDgv();
            }
        }
        #endregion

        #region FORMULARIO
        private void frmSeleccionarPromoDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion

        #endregion

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //ClickFila();
        }

        
    }
}
