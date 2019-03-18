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
using MaterialSkin.Controls;

using CapaPresentacion.Teclado;

using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmCategoria : MetroForm//MaterialForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();

        public frmCategoria()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            Mostrar();
        }

        #region INSTANCIACION
        private static frmCategoria _Instancia = null;

        public static frmCategoria Instancia
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

        public static frmCategoria GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmCategoria();
            }
            return Instancia;
        }
        private void frmCategoria_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void frmCategoria_Load(object sender, EventArgs e)
        {
            Mostrar();
            dgvListado.ClearSelection();
            txtBuscar.SelectAll();
        }

        #region EVENTOS CAPTURADOS

        //EVENTO FORM CLOSED, CUANDO SE CIERRA EL FORMULARIO HIJO, EL FORMULARIO PADRE ACTUALIZA SU dgvListado
        private void formIngresarCategoria_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mostrar();
            btnIngresar.Enabled = true;
        }

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarCategoria_btnInsertarClick(object sender, EventArgs e)
        {
            Mostrar();
        }

        #endregion

        #region MOSTRAR

        //CLICK EN DATAGRID - EVENTO QUE SE PRODUCE AL HACER CLICK EN EL DATAGRIDVIEW "dgvListado" - FOCO EN EL REGISTRO
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
            catch
            {

            }
        }

        //DOBLE CLICK EN DATAGRID
        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                VerDetalles();
            }
            catch
            {
            }
        }

        private void VerDetalles()
        {
            frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria();
            formIngresarCategoria.ctrlSeleccionado = 2;
            formIngresarCategoria.IdCategoria = Convert.ToString(dgvListado.CurrentRow.Cells["IdCategoria"].Value).Trim().ToUpper();
            formIngresarCategoria.Categoria = Convert.ToString(dgvListado.CurrentRow.Cells["Categoria"].Value).Trim().ToUpper();
            formIngresarCategoria.Descripcion = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value).Trim();
            formIngresarCategoria.FormClosed += new FormClosedEventHandler(formIngresarCategoria_FormClosed);
            formIngresarCategoria.btnInsertar.Click += new EventHandler(formIngresarCategoria_btnInsertarClick);
            btnIngresar.Enabled = false;
            formIngresarCategoria.ShowDialog();
        }

        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns["Categoria"].HeaderText = "Categoria";
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
                dgvListado.Columns["IdCategoria"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //MOSTRAR
        public void Mostrar()
        {
            dgvListado.DataSource = NegocioCategoria.Mostrar();
            NombreColumnas();
            if (!chkEliminarVarios.Checked)
            {
                OcultarColumnas();
            }
        }
        #endregion

        #region AGREGAR

        /*METODO GUARDAR - NO SE UTILIZA YA QUE SE GUARDA AL HACER CLICK EN EL BOTON GUARDAR DEL FORMULARIO
        frmIngresarCategoria

        public void Insertar()
        {
            frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria();
            string agregarActualizar = "";
            agregarActualizar = NegocioCategoria.Insertar(
            formIngresarCategoria.nombre,
            formIngresarCategoria.descripcion);
            formIngresarCategoria.MensajeOk("Categoría guardada exitosamente");
            formIngresarCategoria.Limpiar();
            dgvListado.DataSource = NegocioCategoria.Mostrar();
            Mostrar();
        }
        */

        //BOTON INGRESAR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria();
            formIngresarCategoria.ctrlSeleccionado = 0;
            //CAPTURADOR DE EVENTO FORM CLOSED
            formIngresarCategoria.FormClosed += new FormClosedEventHandler(formIngresarCategoria_FormClosed);
            //CAPTURADOR DE EVENTO CLICK EN BOTON INSERTAR
            formIngresarCategoria.btnInsertar.Click += new EventHandler(formIngresarCategoria_btnInsertarClick);
            btnIngresar.Enabled = false;
            formIngresarCategoria.ShowDialog();
        }
        #endregion

        #region EDITAR
        /*METODO EDITAR - NO SE UTILIZA YA QUE SE EDITA AL HACER CLICK EN EL BOTON GUARDAR DEL FORMULARIO
        frmIngresarCategoria
        public void Editar()
        {
            frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria();
            string agregarActualizar = "";
            agregarActualizar = NegocioCategoria.Editar(
            Convert.ToInt32(formIngresarCategoria.idcategoria),
            formIngresarCategoria.nombre,
            formIngresarCategoria.descripcion);
            formIngresarCategoria.MensajeOk("Categoría actualizada exitosamente.");
            Mostrar();
        }
        */
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
            string idCategoria = "";
            string Respuesta = "";
            DialogResult Opcion;
            frmIngresarCategoria formIngresarCategoria = new frmIngresarCategoria();
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
                                idCategoria = Convert.ToString(row.Cells["IdCategoria"].Value);
                                Respuesta = NegocioCategoria.Eliminar(Convert.ToInt32(idCategoria));
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarCategoria.NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            formIngresarCategoria.NotificacionError("Los registros no se eliminaron.", "Error");
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
                        idCategoria = Convert.ToString(dgvListado.CurrentRow.Cells["IdCategoria"].Value);
                        Respuesta = NegocioCategoria.Eliminar(Convert.ToInt32(idCategoria));
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarCategoria.NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            formIngresarCategoria.NotificacionError("El registro no se eliminó", "Error");
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
            dgvListado.DataSource = NegocioCategoria.Buscar(txtBuscar.Text);
            OcultarColumnas();
        }

        //TEXTBOX BUSCAR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
        }

        #endregion

        #region CONTROL TECLADO

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void chkEliminarVarios_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void frmCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        #endregion
        
        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (controlTeclado.DireccionarEventoDeControl(sender, e))
            {
                VerDetalles();
            }
        }
    }
}
