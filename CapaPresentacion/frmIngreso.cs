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

using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmIngreso : MetroForm//MaterialForm
    {
        frmIngresarIngreso formIngresarIngreso = frmIngresarIngreso.GetInstancia();
        public int IdEmpleado;
        public frmIngreso()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(dtpDesde, "Seleccione la fecha de inicio de búsqueda");
            ttMensaje.SetToolTip(dtpHasta, "Seleccione la fecha de fin de búsqueda y presione 'Enter' para seleccionar un registro de la lista");
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            formIngresarIngreso.btnInsertar.Click += new EventHandler(formIngresarIngreso_btnInsertarClick);
        }

        #region INSTANCIACION
        private static frmIngreso _Instancia = null;

        public static frmIngreso Instancia
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

        public static frmIngreso GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngreso();
            }
            return Instancia;
        }
        
        private void frmIngreso_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            dtpDesde.Select();
            Mostrar();
            //foreach (Control ctrl in this.Controls)
            //{
            //    try
            //    {
            //        if (ctrl != label1 && ctrl != pictureBox1)
            //        {
            //            ctrl.BackColor = Color.FromArgb(64, 64, 64);
            //        }
            //        ctrl.ForeColor = Color.FromArgb(255, 255, 255);
            //    }
            //    catch (InvalidCastException ex)
            //    {
            //
            //    }
            //}
            //desactivacionMenuContextual();
        }

        #region DESACTIVACION DE MENU CONTEXTUAL
        private void desactivacionMenuContextual()
        {
            ContextMenu menu = new ContextMenu();
            foreach (Control ctrl in this.Controls)
            {
                //if (e.Button == MouseButtons.Right)
                //{
                    ctrl.ContextMenu = menu;
                //}
            }
        }
        #endregion

        #region EVENTOS CAPTURADOS

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarIngreso_btnInsertarClick(object sender, EventArgs e)
        {
            //formIngresarIngreso.MostrarDetalle();
            Mostrar();
        }

        #endregion

        #region MOSTRAR

        //DOBLE CLICK EN CELDAS
        private void dgvListado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DobleClickDgvCell();
        }

        //METODO DOBLE CLICK EN CELDA
        private void DobleClickDgvCell()
        {
            try
            {
                formIngresarIngreso.ctrlSeleccionado = 2;
                formIngresarIngreso.IdIngreso = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdIngreso"].Value);
                formIngresarIngreso.Empleado = Convert.ToString(dgvListado.CurrentRow.Cells["Empleado"].Value);
                formIngresarIngreso.Proveedor = Convert.ToString(dgvListado.CurrentRow.Cells["Proveedor"].Value).Trim().ToUpper();
                formIngresarIngreso.Fecha = Convert.ToDateTime(dgvListado.CurrentRow.Cells["Fecha"].Value);
                formIngresarIngreso.TipoComprobante = Convert.ToString(dgvListado.CurrentRow.Cells["TipoComprobante"].Value).Trim().ToUpper();
                formIngresarIngreso.Serie = Convert.ToString(dgvListado.CurrentRow.Cells["Serie"].Value).Trim();
                formIngresarIngreso.Correlativo = Convert.ToString(dgvListado.CurrentRow.Cells["Correlativo"].Value).Trim();
                formIngresarIngreso.Estado = Convert.ToString(dgvListado.CurrentRow.Cells["Estado"].Value).Trim();
                formIngresarIngreso.Total = Convert.ToDecimal(dgvListado.CurrentRow.Cells["Total"].Value);
                formIngresarIngreso.btnInsertar.Click += new EventHandler(formIngresarIngreso_btnInsertarClick);
                formIngresarIngreso.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //CLICK EN CELDAS
        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEliminar.Enabled = true;
                if (e.ColumnIndex == dgvListado.Columns[0].Index)
                {
                    DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns[2].HeaderText = "Empleado";
                dgvListado.Columns[3].HeaderText = "Proveedor";
                dgvListado.Columns[4].HeaderText = "Fecha";
                dgvListado.Columns[5].HeaderText = "Tipo de Comprobante";
                dgvListado.Columns[6].HeaderText = "Serie";
                dgvListado.Columns[7].HeaderText = "Correlativo";
                dgvListado.Columns[8].HeaderText = "Estado";
                dgvListado.Columns[9].HeaderText = "Total";
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
                dgvListado.Columns[1].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //MOSTRAR
        public void Mostrar()
        {
            dgvListado.DataSource = NegocioIngreso.Mostrar();
            if (dgvListado.Rows.Count > 0)
            {
                lblSinIngresos.Visible = false;
            }
            OcultarColumnas();
            NombreColumnas();
        }
        
        #endregion

        #region AGREGAR
        //BOTON INGRESAR NUEVO INGRESO
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarIngreso formIngresarIngreso = frmIngresarIngreso.GetInstancia();
            formIngresarIngreso.ctrlSeleccionado = 0;
            formIngresarIngreso.btnInsertar.Click += new EventHandler(formIngresarIngreso_btnInsertarClick);
            formIngresarIngreso.ShowDialog();
            formIngresarIngreso.IdEmpleado = IdEmpleado;
        }
        #endregion

        #region ANULAR INGRESO

        //CHECKBOX
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idIngreso;
            string respuesta = "";
            DialogResult Opcion;
            frmIngresarCliente formIngresarCliente = new frmIngresarCliente();
            try
            {
                //SELECCION DE VARIOS REGISTROS
                if (chkEliminarVarios.Checked)
                {
                    Opcion = MessageBox.Show(
                        "¿Realmente desea anular los registros seleccionados?. Tenga en cuenta que al anular este ingreso el stock actual de los productos relacionados se restará",
                        "Anulando registro. ¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.Yes)
                    {
                        foreach (DataGridViewRow row in dgvListado.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {
                                idIngreso = Convert.ToInt32(row.Cells[1].Value);
                                respuesta = NegocioIngreso.Anular(idIngreso);
                                //DataTable Detalle = new DataTable();
                                DataTable Detalle = NegocioIngreso.Mostrar(idIngreso);
                                foreach(DataRow det in Detalle.Rows)
                                {
                                    int idArticulo = Convert.ToInt32(det["IdArticulo"]);
                                    decimal cantidad = Convert.ToDecimal(det["Cantidad"]);
                                    respuesta = NegocioArticulo.DisminuirStock(idArticulo, cantidad);
                                }
                            }
                        }
                        if (respuesta.Equals("OK"))
                        {
                            formIngresarCliente.NotificacionOk("Los registros se anularon correctamente.", "Anulando");
                        }
                        else
                        {
                            formIngresarCliente.NotificacionError("Los registros no se anularon.", "Error");
                        }
                        Mostrar();
                    }
                }
                else
                {
                    //SELECCION DE UN REGISTRO
                    Opcion = MessageBox.Show(
                        "¿Realmente desea anular los registros seleccionados?. Tenga en cuenta que al anular este ingreso el stock actual de los productos relacionados se restará",
                        "Anulando registro. ¡Advertencia!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Opcion == DialogResult.Yes)
                    {
                        idIngreso = Convert.ToInt32(dgvListado.CurrentRow.Cells[1].Value);
                        respuesta = NegocioIngreso.Anular(Convert.ToInt32(idIngreso));
                        DataTable Detalle = NegocioIngreso.Mostrar(idIngreso);
                        foreach (DataRow det in Detalle.Rows)
                        {
                            int idArticulo = Convert.ToInt32(det["IdArticulo"]);
                            decimal cantidad = Convert.ToDecimal(det["Cantidad"]);
                            respuesta = NegocioArticulo.DisminuirStock(idArticulo, cantidad);
                        }
                        if (respuesta.Equals("OK"))
                        {
                            formIngresarCliente.NotificacionOk("El registro se anuló correctamente", "Anulando");
                        }
                        else
                        {
                            formIngresarCliente.NotificacionError("El registro no se anuló", "Error");
                        }
                        Mostrar();
                    }
                }
                chkEliminarVarios.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion

        #region BUSCAR

        //METODO BUSCAR
        private void Buscar()
        {
            dgvListado.DataSource = NegocioIngreso.Buscar(dtpDesde.Value, dtpHasta.Value, null); //(dtpDesde.Value.ToString("yyyy/MM/dd"), dtpHasta.Value.ToString("yyyy/MM/dd"));
            if (dgvListado.Rows.Count == 0)
            {
                lblSinIngresos.Visible = true;
            }
            else
            {
                lblSinIngresos.Visible = false;
            }
            OcultarColumnas();
            NombreColumnas();
        }

        #endregion

        #region COMPORTAMIENTO TECLADO
        //PARA DEFINIR EL COMPORTAMIENTO DEL FORMULARIO AL PRESIONAR UNA TECLA SE DEBE ESTABLECER LA PROPIEDAD KeyPreview DEL FORM en true
        #region TECLA ESCAPE
        private void cerrarForm(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (dtpDesde.Focused)
                {
                    Close();
                }
                else
                {
                    dtpDesde.Focus();
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
                if (dtpDesde.Focused)
                {
                    dtpHasta.Focus();
                }
                else if (dtpHasta.Focus())
                {
                    btnBuscar.Focus();
                }
                else if (btnBuscar.Focused)
                {
                    dgvListado.Focus();
                }
                else if (dgvListado.Focused)
                {
                    DobleClickDgvCell();
                }
            }
        }
        #endregion

        #region EVENTOS CONTRTOLES

        #region DATETIMEPICKER BUSCAR FECHA1
        private void dtpFecha1_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterKeyPress(e);
        }
        #endregion

        #region DATETIMEPICKER BUSCAR FECHA2
        private void dtpFecha2_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterKeyPress(e);
        }
        #endregion

        #region DATAGRIDVIEW LISTADO
        //SE CONFIGURARÁ ESTE EVENTO PARA EVITAR QUE AL PRESIONAR ENTER, SE DESPLACE A LA FILA SIGUIENTE DEL DATAGRIDVIEW Y LLAME AL FORMULARIO HIJO
        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            dgvEnter(dgvListado, e);
        }
        #endregion

        #region FORMULARIO
        private void frmIngreso_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion

        #endregion

        #region DATAGRIDVIEW's
        private void dgvEnter(DataGridView control, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                control.Focus();
                control.CurrentRow.Selected = true;
                DobleClickDgvCell();
            }
        }
        #endregion

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
            btnLimpiarBusqueda.Visible = true;
        }

        private void btnMostrarIngresos_Click(object sender, EventArgs e)
        {
            btnLimpiarBusqueda.Visible = false;
            dtpDesde.Value = DateTime.Now;
            dtpHasta.Value = DateTime.Now;
            Mostrar();
            OcultarColumnas();
        }

        private void dgvListado_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnEliminar.Enabled = true;
                if (e.ColumnIndex == dgvListado.Columns[0].Index)
                {
                    DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void frmIngreso_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip menu2 = new ContextMenuStrip();
                this.ContextMenuStrip = menu2;
            }
        }
    }
}
