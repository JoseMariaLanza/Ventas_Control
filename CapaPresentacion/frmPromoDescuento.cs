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

using CapaPresentacion.Teclado;

using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmPromoDescuento : MetroForm//MaterialForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();
        int IdDescuento;
        public frmPromoDescuento()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Mostrar();
        }

        private void frmPromoDescuento_Load(object sender, EventArgs e)
        {
            Mostrar();
            dgvListado.ClearSelection();
            txtBuscar.SelectAll();
        }

        #region INSTANCIACION
        private static frmPromoDescuento _Instancia = null;

        public static frmPromoDescuento Instancia
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

        public static frmPromoDescuento GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmPromoDescuento();
            }
            return Instancia;
        }
        private void frmPromoDescuento_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region EVENTOS CAPTURADOS

        //EVENTO FORM CLOSED, CUANDO SE CIERRA EL FORMULARIO HIJO, EL FORMULARIO PADRE ACTUALIZA SU dgvListado
        private void formIngresarPromoDescuento_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mostrar();
            btnIngresar.Enabled = true;
        }

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarPromoDescuento_btnInsertarClick(object sender, EventArgs e)
        {
            Mostrar();
        }

        #endregion

        #region MOSTRAR

        //CLICK EN DATAGRID - EVENTO QUE SE PRODUCE AL HACER CLICK EN EL DATAGRIDVIEW "dgvListado" - FOCO EN EL REGISTRO
        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdDescuento = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdDescuento"].Value);
            try
            {
                btnEliminar.Enabled = true;
                if (e.ColumnIndex == dgvListado.Columns[0].Index)
                {
                    DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                    chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
                }
                if (e.ColumnIndex == dgvListado.Columns["Habilitado"].Index)
                {
                    DataGridViewCheckBoxCell chkHabilitar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Habilitado"];
                    chkHabilitar.Value = !Convert.ToBoolean(chkHabilitar.Value);
                    string respuesta = NegocioDescuento.Habilitar(IdDescuento, Convert.ToBoolean(chkHabilitar.Value));
                    if (respuesta.Equals("OK"))
                    {
                        string estadoActualDeLaPromocion = "";
                        if (Convert.ToBoolean(chkHabilitar.Value))
                        {
                            estadoActualDeLaPromocion = "Habilitada";
                        }
                        else
                        {
                            estadoActualDeLaPromocion = "Deshabilitada";
                        }
                        MessageBox.Show("La promoción está " + estadoActualDeLaPromocion, "Estado de la promoción:", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch { }
        }

        //DOBLE CLICK EN DATAGRID
        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            DgvDobleClic();
        }

        //METODO DOBLE CLIC
        private void DgvDobleClic()
        {
            try
            {
                //frmIngresarPromoDescuento formIngresarPromoDescuento = frmIngresarPromoDescuento.GetInstancia();
                frmIngresarPromoDescuento formIngresarPromoDescuento = new frmIngresarPromoDescuento();
                formIngresarPromoDescuento.ctrlSeleccionado = 2;
                formIngresarPromoDescuento.txtNombreDescuento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["NombreDescuento"].Value);
                formIngresarPromoDescuento.IdDescuento = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdDescuento"].Value);
                //formIngresarPromoDescuento.IdArticulo = Convert.ToInt32(dgvListado.CurrentRow.Cells["idproducto"].Value);
                //formIngresarPromoDescuento.Articulo = Convert.ToString(dgvListado.CurrentRow.Cells["Articulo"].Value).Trim().ToUpper();
                //formIngresarPromoDescuento.Cantidad = Convert.ToDecimal(dgvListado.CurrentRow.Cells["cantidad"].Value);
                //formIngresarPromoDescuento.Precio_Inversion = Convert.ToDecimal(dgvListado.CurrentRow.Cells["precio_inversion"].Value);
                //formIngresarPromoDescuento.Porcentaje_Ganancia = Convert.ToDecimal(dgvListado.CurrentRow.Cells["porcentaje_ganancia"].Value);
                //formIngresarPromoDescuento.Precio_Venta_Descuento = Convert.ToDecimal(dgvListado.CurrentRow.Cells["precio_venta_descuento"].Value);
                //formIngresarPromoDescuento.Actualizacion_Automatica = Convert.ToByte(dgvListado.CurrentRow.Cells["actualizacion_automatica"].Value);
                formIngresarPromoDescuento.Descripcion = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value).Trim();
                formIngresarPromoDescuento.FormClosed += new FormClosedEventHandler(formIngresarPromoDescuento_FormClosed);
                formIngresarPromoDescuento.btnInsertar.Click += new EventHandler(formIngresarPromoDescuento_btnInsertarClick);
                btnIngresar.Enabled = false;
                formIngresarPromoDescuento.ShowDialog();
            }
            catch { }
        }

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
        //OCULTAR COLUMNAS
        private void OcultarColumnas()
        {
            try
            {
                dgvListado.Columns[0].Visible = false;
                //dgvListado.Columns[1].Visible = false;
                //dgvListado.Columns[2].Visible = false;
                //dgvListado.Columns[8].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        DataTable dtListaDescuentos;
        private void CrearListaDescuentos()
        {
            dtListaDescuentos = new DataTable("DetallesDescuento");
            dtListaDescuentos.Columns.Add("IdDescuento", Type.GetType("System.Int32"));
            dtListaDescuentos.Columns.Add("NombreDescuento", Type.GetType("System.String"));
            dtListaDescuentos.Columns.Add("Descripcion", Type.GetType("System.String"));
            dtListaDescuentos.Columns.Add("Habilitado", Type.GetType("System.Boolean"));
            dtListaDescuentos = NegocioDescuento.Mostrar();
            //dgvListado.DataSource = dtListaDescuentos;
        }

        //MOSTRAR
        public void Mostrar()
        {
            CrearListaDescuentos();
            //dgvListado.DataSource = NegocioDescuento.Mostrar();
            dgvListado.DataSource = dtListaDescuentos;
            NombreColumnas();
            if (!chkEliminarVarios.Checked)
            {
                OcultarColumnas();
            }
        }
        #endregion

        #region AGREGAR
        //BOTON INGRESAR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarPromoDescuento formIngresarPromoDescuento = frmIngresarPromoDescuento.GetInstancia();
            formIngresarPromoDescuento.ctrlSeleccionado = 0;
            //CAPTURADOR DE EVENTO FORM CLOSED
            formIngresarPromoDescuento.FormClosed += new FormClosedEventHandler(formIngresarPromoDescuento_FormClosed);
            //CAPTURADOR DE EVENTO CLICK EN BOTON INSERTAR
            formIngresarPromoDescuento.btnInsertar.Click += new EventHandler(formIngresarPromoDescuento_btnInsertarClick);
            formIngresarPromoDescuento.ShowDialog();
        }
        #endregion

        #region ELIMINAR

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

        //BOTON ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int idDescuento;
            string respuesta = "";
            DialogResult Opcion;
            frmIngresarPromoDescuento formIngresarPromoDescuento = frmIngresarPromoDescuento.GetInstancia();
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
                                idDescuento = Convert.ToInt32(row.Cells[1].Value);
                                respuesta = NegocioDescuento.Eliminar(idDescuento);
                            }
                        }
                        if (respuesta.Equals("OK"))
                        {
                            formIngresarPromoDescuento.NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            formIngresarPromoDescuento.NotificacionError("Los registros no se eliminaron.", "Error");
                        }
                        Mostrar();
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
                        idDescuento = Convert.ToInt32(dgvListado.CurrentRow.Cells[1].Value);
                        respuesta = NegocioDescuento.Eliminar(idDescuento);
                        if (respuesta.Equals("OK"))
                        {
                            formIngresarPromoDescuento.NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            formIngresarPromoDescuento.NotificacionError("El registro no se eliminó", "Error");
                        }
                    }
                }
                chkEliminarVarios.Checked = false;
                Mostrar();
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
            dgvListado.DataSource = NegocioDescuento.Buscar(txtBuscar.Text);
            OcultarColumnas();
        }

        //TEXTBOX BUSCAR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }
        #endregion

        #region TECLADO
        private void frmPromoDescuento_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (controlTeclado.TeclaEnterEnDataGridView((DataGridView)sender, e))
            {
                DgvDobleClic();
            }
        }
        #endregion
    }
}
