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

namespace CapaPresentacion
{
    public partial class frmSeleccionarArticulo : MaterialForm
    {
        public int IdArticulo;
        public string Codigo;
        public string Articulo;
        public int IdCategoria;
        public decimal PrecioCompra;
        public decimal PrecioVenta;
        public decimal Stock;
        public int IdPresentacion;
        public string Descripcion;
        public string RutaImagen;

        public frmSeleccionarArticulo()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmSeleccionarProducto_Load(object sender, EventArgs e)
        {
            Mostrar();
            //txtBuscarCodigo.SelectAll();
            txtBuscar.Hint = "Artículo, Categoría, Código de barras";
            //txtBuscarCategoria.Hint = "Buscar por categoría";
            //txtBuscarCodigo.Hint = "Buscar por código";
        }

        #region INSTANCIACIÓN
        private static frmSeleccionarArticulo _Instancia = null;

        public static frmSeleccionarArticulo Instancia
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

        public static frmSeleccionarArticulo GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmSeleccionarArticulo();
            }
            return Instancia;
        }

        private void frmSeleccionarProducto_FormClosing(object sender, FormClosingEventArgs e)
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
                dgvListado.Columns[1].HeaderText = "Código";
                dgvListado.Columns[2].HeaderText = "Articulo";
                dgvListado.Columns[3].HeaderText = "Descripción";
                dgvListado.Columns[6].HeaderText = "Categoría";
                dgvListado.Columns[8].HeaderText = "Presentación";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        //OCULTAR COLUMNAS
        private void OcultarColumnas()
        {
            try
            {
                dgvListado.Columns[0].Visible = false;
                dgvListado.Columns[4].Visible = false;
                dgvListado.Columns[5].Visible = false;
                dgvListado.Columns[7].Visible = false;
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
            dgvListado.DataSource = NegocioArticulo.Mostrar();
            NombreColumnas();
            OcultarColumnas();
        }
        #endregion

        #region BUSQUEDA
        //METODO BUSCAR POR NOMBRE
        private void Buscar()
        {
            dgvListado.DataSource = NegocioArticulo.Buscar(txtBuscar.Text);
            OcultarColumnas();
        }

        ////METODO BUSQUEDA POR NOMBRE Y CATEGORIA - LA BUSQUEDA TRABAJA SOBRE UN OBJETO DE TIPO DATATABLE
        //private void BuscarProductoCategoria()
        //{
        //    dgvListado.DataSource = NegocioArticulo.BuscarProductoCategoria(txtBuscar.Text, txtBuscarCategoria.Text);
        //    OcultarColumnas();
        //}

        #region TEXTBOX BUSCAR
        //TEXTBOX BUSCAR POR NOMBRE
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar();
                //if (txtBuscar.TextLength > 0)
                //{
                //    btnLimpiarBusquedaNombre.Visible = true;
                //    txtBuscar.Width = 166;
                //}
                //else
                //{
                //    btnLimpiarBusquedaNombre.Visible = false;
                //    txtBuscar.Width = 190;
                //}
                //if (txtBuscarCategoria.TextLength > 0)
                //{
                //    BuscarProductoCategoria();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Error en la consulta. Contacte con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        //BOTON LIMPIAR BUSQUEDA POR NOMBRE
        private void btnLimpiarBusquedaNombre_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtBuscar.SelectAll();
        }

        ////METODO BUSCAR POR CATEGORIA
        //private void BuscarCategoria()
        //{
        //    dgvListado.DataSource = NegocioArticulo.BuscarCategoria(txtBuscarCategoria.Text);
        //    OcultarColumnas();
        //}

        //#region TEXTBOX BUSCAR CATEGORIA
        ////TEXTBOX BUSCAR CATEGORIA
        //private void txtBuscarCategoria_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        BuscarCategoria();
        //        if (txtBuscarCategoria.TextLength > 0)
        //        {
        //            btnLimpiarBusquedaCategoria.Visible = true;
        //            txtBuscarCategoria.Width = 133;
        //        }
        //        else
        //        {
        //            btnLimpiarBusquedaCategoria.Visible = false;
        //            txtBuscarCategoria.Width = 154;
        //        }
        //        if (txtBuscar.TextLength > 0)
        //        {
        //            BuscarProductoCategoria();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "Error en la consulta. Contacte con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //#endregion

        ////BOTON LIMPIAR BUSQUEDA POR CATEGORIA
        //private void btnLimpiarBusquedaCategoria_Click(object sender, EventArgs e)
        //{
        //    txtBuscarCategoria.Text = "";
        //    txtBuscarCategoria.SelectAll();
        //}

        ////METODO BUSCAR POR CODIGO DE BARRAS
        //private void BuscarCodigo()
        //{
        //    dgvListado.DataSource = NegocioArticulo.BuscarCodigo(txtBuscarCodigo.Text);
        //    OcultarColumnas();
        //}

        //#region TEXTBOX BUSCAR CODIGO DE BARRAS
        ////TEXTBOX BUSCAR POR CODIGO DE BARRAS
        //private void txtBuscarCodigo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        txtBuscar.Text = "";
        //        txtBuscarCategoria.Text = "";
        //        BuscarCodigo();
        //        if (txtBuscarCodigo.TextLength > 0)
        //        {
        //            btnLimpiarCodigo.Visible = true;
        //            txtBuscarCodigo.Width = 173;
        //        }
        //        else
        //        {
        //            btnLimpiarCodigo.Visible = false;
        //            txtBuscarCodigo.Width = 196;
        //            Mostrar();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "Error en la consulta. Contacte con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        //#endregion

        ////BOTON LIMPIAR BUSQUEDA POR CODIGO DE BARRAS
        //private void btnLimpiarCodigo_Click(object sender, EventArgs e)
        //{
        //    txtBuscarCodigo.Text = "";
        //    Mostrar();
        //    txtBuscarCodigo.SelectAll();
        //}
        #endregion

        #region METODO DOBLE CLICK EN DATAGRID
        private void DobleClickDgvCell()
        {
            try
            {
                ClickFila();
                Close();
            }
            catch
            { }
        }
        #endregion
        
        #region CLICK EN FILA
        private void ClickFila()
        {
            IdArticulo = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdArticulo"].Value);
            Codigo = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value);
            Articulo = Convert.ToString(dgvListado.CurrentRow.Cells["Articulo"].Value);
            IdCategoria = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCategoria"].Value);
            PrecioCompra = Convert.ToDecimal(dgvListado.CurrentRow.Cells["PrecioCompra"].Value);
            PrecioVenta = Convert.ToDecimal(dgvListado.CurrentRow.Cells["PrecioVenta"].Value);
            Stock = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Stock"].Value);
            IdPresentacion = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdPresentacion"].Value);
            Descripcion = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value);
            RutaImagen = Convert.ToString(dgvListado.CurrentRow.Cells["RutaImagen"].Value);
        }
        #endregion

        #region DOBLE CLICK EN DATAGRID
        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            DobleClickDgvCell();
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

        //private void txtBuscarCategoria_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    enterKeyPress(e);
        //}

        //private void txtBuscarCodigo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    enterKeyPress(e);
        //}
        #endregion

        #region DATAGRID
        //SE CONFIGURARÁ ESTE EVENTO PARA EVITAR QUE AL PRESIONAR ENTER, SE DESPLACE A LA FILA SIGUIENTE DEL DATAGRIDVIEW Y LLAME AL FORMULARIO HIJO
        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                DobleClickDgvCell();
            }
        }
        #endregion

        #region FORMULARIO
        private void frmSeleccionarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion

        #endregion

        private void dgvListado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DobleClickDgvCell();
        }

        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClickFila();
        }
    }
}
