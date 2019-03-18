using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaNegocio;
using MaterialSkin;
using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmArticulo : MetroForm
    {
        int IdArticulo;
        string Codigo;
        string Articulo;
        int IdCategoria;
        string Categoria;
        decimal PrecioCompra;
        decimal PrecioVenta;
        decimal Stock;
        int IdPresentacion;
        string Presentacion;
        string Descripcion;
        string RutaImagen;

        public frmArticulo()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            Mostrar();
            dgvListado.ClearSelection();
            txtBuscar.SelectAll();
        }

        #region INSTANCIACION
        private static frmArticulo _Instancia = null;

        public static frmArticulo Instancia
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

        public static frmArticulo GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmArticulo();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmArticulo_FormClosing(object sender, FormClosingEventArgs e)
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
        #endregion

        #region COLUMNAS DE DATAGRIDVIEW
        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns["Codigo"].HeaderText = "Código";
                dgvListado.Columns["Articulo"].HeaderText = "Artículo";
                dgvListado.Columns["Categoria"].HeaderText = "Categoría";
                dgvListado.Columns["PrecioVenta"].HeaderText = "Precio";
                dgvListado.Columns["PrecioVenta"].DefaultCellStyle.Format = "$#0.##";
                dgvListado.Columns["Stock"].HeaderText = "Stock";
                dgvListado.Columns["Stock"].DefaultCellStyle.Format = "#0.###";
                dgvListado.Columns["Presentacion"].HeaderText = "Presentación";
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
                dgvListado.Columns["IdArticulo"].Visible = false;
                dgvListado.Columns["IdCategoria"].Visible = false;
                dgvListado.Columns["PrecioCompra"].Visible = false;
                dgvListado.Columns["IdPresentacion"].Visible = false;
                dgvListado.Columns["Descripcion"].Visible = false;
                dgvListado.Columns["RutaImagen"].Visible = false;
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
            if (dgvListado.RowCount == 0)
            {
                chkEliminarVarios.Enabled = false;
                btnEliminar.Enabled = false;
                dgvListado.ColumnHeadersVisible = false;
            }
            else
            {
                chkEliminarVarios.Enabled = true;
                dgvListado.ColumnHeadersVisible = true;
            }
            if (!chkEliminarVarios.Checked)
            {
                OcultarColumnas();
            }
        }
        #endregion
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

        //TEXTBOX BUSCAR POR NOMBRE
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Buscar();
                if (txtBuscar.TextLength > 0)
                {
                    btnLimpiarBusqueda.Visible = true;
                    txtBuscar.Width = 166;
                }
                else
                {
                    btnLimpiarBusqueda.Visible = false;
                    txtBuscar.Width = 190;
                }
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
        //BOTON LIMPIAR BUSQUEDA POR NOMBRE
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
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
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message + "Error en la consulta. Contacte con el administrador del sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        ////BOTON LIMPIAR BUSQUEDA POR CODIGO DE BARRAS
        //private void btnLimpiarCodigo_Click(object sender, EventArgs e)
        //{
        //    txtBuscarCodigo.Text = "";
        //    Mostrar();
        //    txtBuscarCodigo.SelectAll();
        //}

        #endregion

        #region CLICK Y DOBLECLICK EN DATAGRID
        //PASA LOS DATOS DE LAS COLUMNAS DEL DATAGRID A LOS TEXBOX PARA VER SU DETALLE O EDITARLOS
        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgvListado.Columns[0].Index)
                {
                    DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
                }
            }
            catch
            {
            }
        }

        private void ClickdgvListado()
        {
            try
            {
                IdArticulo = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdArticulo"].Value);
                Codigo = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value).Trim();
                Articulo = Convert.ToString(dgvListado.CurrentRow.Cells["Articulo"].Value).Trim().ToUpper();
                IdCategoria = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCategoria"].Value);
                Categoria = Convert.ToString(dgvListado.CurrentRow.Cells["Categoria"].Value).Trim().ToUpper();
                PrecioCompra = Convert.ToDecimal(dgvListado.CurrentRow.Cells["PrecioCompra"].Value);
                PrecioVenta = Convert.ToDecimal(dgvListado.CurrentRow.Cells["PrecioVenta"].Value);
                Stock = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Stock"].Value);
                IdPresentacion = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdPresentacion"].Value);
                Presentacion = Convert.ToString(dgvListado.CurrentRow.Cells["Presentacion"].Value).Trim().ToUpper();
                Descripcion = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value).Trim();
                RutaImagen = Convert.ToString(dgvListado.CurrentRow.Cells["RutaImagen"].Value);
                btnEliminar.Enabled = true;
            }
            catch { }
        }

        private void dgvListado_Click(object sender, EventArgs e)
        {
            ClickdgvListado();
        }

        private void DobleClickdgvListado()
        {
            frmIngresarArticulo formIngresarArticulo = frmIngresarArticulo.GetInstancia();
            formIngresarArticulo.ctrlSeleccionado = 2;
            formIngresarArticulo.IdArticulo = IdArticulo;
            formIngresarArticulo.Codigo = Codigo;
            formIngresarArticulo.Articulo = Articulo;
            formIngresarArticulo.IdCategoria = IdCategoria;
            formIngresarArticulo.Categoria = Categoria;
            formIngresarArticulo.PrecioCompra = PrecioCompra;
            formIngresarArticulo.PrecioVenta = PrecioVenta;
            formIngresarArticulo.Stock = Stock;
            formIngresarArticulo.IdPresentacion = IdPresentacion;
            formIngresarArticulo.Presentacion = Presentacion;
            formIngresarArticulo.Descripcion = Descripcion;
            formIngresarArticulo.RutaImagen = RutaImagen;
            //formIngresarArticulo.HabilitarBotones();
            formIngresarArticulo.ShowDialog();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            DobleClickdgvListado();
        }
        #endregion

        #region ELIMINAR
        #region CHECKBOX ELIMINAR VARIOS
        //CHECKBOX - SOLO HABILITA CHECKS DE DATAGRIDVIEW PARA PODER SELECCIONAR LOS REGISTROS A ELIMINAR
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
                btnEliminar.Enabled = false;
                foreach (DataGridViewRow row in dgvListado.Rows)
                {
                    row.Cells[0].Value = false;
                }
            }
        }
        #endregion

        #region METODO ELIMINAR
        //METODO ELIMINAR
        private void eliminar()
        {
            string idproducto = "";
            string Respuesta = "";
            DialogResult Opcion;
            try
            {
                //SELECCION DE VARIOS REGISTROS
                if (chkEliminarVarios.Checked)
                {
                    Opcion = MessageBox.Show(
                        "¿Realmente desea eliminar los registros seleccionados?",
                        "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvListado.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                idproducto = Convert.ToString(row.Cells[1].Value);
                                Respuesta = NegocioArticulo.Eliminar(Convert.ToInt32(idproducto));
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            NotificacionOk("Registros eliminados", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("Los registros no se eliminaron.", "Error");
                        }
                    }
                }
                else
                {
                    //SELECCION DE UN REGISTRO
                    Opcion = MessageBox.Show(
                        "¿Realmente desea eliminar el registro seleccionado?",
                        "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.Yes)
                    {
                        idproducto = Convert.ToString(dgvListado.CurrentRow.Cells[1].Value);
                        Respuesta = NegocioArticulo.Eliminar(Convert.ToInt32(idproducto));
                        if (Respuesta.Equals("OK"))
                        {
                            NotificacionOk("Registro eliminado", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("El registro no se eliminó.", "Error");
                        }
                    }
                }
                chkEliminarVarios.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            Mostrar();
        }
        #endregion

        #region BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            eliminar();
        }
        #endregion

        #endregion

        #region BOTON AGREGAR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarArticulo formIngresarArticulo = frmIngresarArticulo.GetInstancia();
            formIngresarArticulo.ctrlSeleccionado = 0;
            formIngresarArticulo.ShowDialog();
        }
        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Informes.frmInformeArticulos formInformeArticulos = Informes.frmInformeArticulos.GetInstancia();
            formInformeArticulos.Show();
            formInformeArticulos.BringToFront();
        }

        private void frmArticulo_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Comprueba si la tecla presionada es la tecla Enter
            {
                e.Handled = true; // Eliminar el sonido al presionar Enter
                dgvListado.Focus(); // Entrega el foco
                dgvListado.CurrentRow.Selected = true; // Selecciona la fila actualmente resaltada
                ClickdgvListado(); // Asigna variables por medio del método
                DobleClickdgvListado(); // Muestra una instancia del formulario "frmIngresarArticulo" con los datos
                // de las variables anteriormente asignadas en sus campos.
            }
        }

        // Define el comportamiento del formulario al presionar la tecla ESC
        private void cerrarForm(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dgvListado.Focused)
                {
                    txtBuscar.SelectAll();
                }
                else
                {
                    Close();
                }
            }
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            EnfocarDGV(e);
        }

        private void txtBuscarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            EnfocarDGV(e);
        }

        private void txtBuscarCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            EnfocarDGV(e);
        }

        // Sin importar en qué control esté situado el foco, al presionar la tecla Enter, se dará el foco al control
        // DataGridView (dgvListado)
        private void EnfocarDGV(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dgvListado.Focus(); // Entrega el foco
                if (dgvListado.Rows.Count == 1) // Comprueba si la consulta devolvió alguna fila
                {
                    dgvListado.Rows[0].Selected = true; // Selecciona el primer registro del DataGridView
                    ClickdgvListado(); // Asigna variables por medio de este método
                }
            }
        }
    }
}