using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CapaPresentacion.Teclado;

using CapaNegocio;

using MaterialSkin;
using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmPresentacion : MetroForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();

        public int ctrlSeleccionado = 0;
        public int IdPresentacion;
        public string Presentacion;
        public string Descripcion;
        public frmPresentacion()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void frmPresentacion2_Load(object sender, EventArgs e)
        {
            Mostrar();
            dgvListado.ClearSelection();
            txtBuscar.SelectAll();
        }

        #region INSTANCIACION
        private static frmPresentacion _Instancia;

        public static frmPresentacion Instancia
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

        public static frmPresentacion GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmPresentacion();
            }
            return Instancia;
        }

        private void frmPresentacion2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region MOSTRAR
        //ICONOS DE NOTIFICACIÓN
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

        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns[2].HeaderText = "Presentacion";
                dgvListado.Columns[3].HeaderText = "Descripción";
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
            dgvListado.DataSource = NegocioPresentacion.Mostrar();
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

        #region DATAGRIDVIEW
        //PASA LOS DATOS DE LAS COLUMNAS DEL DATAGRID A LOS TEXBOX PARA VER SU DETALLE O EDITARLOS
        private void dgvListado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clickEnCelda();
            btnEliminar.Enabled = true;
            if (e.ColumnIndex == dgvListado.Columns[0].Index)
            {
                DataGridViewCheckBoxCell chkEliminar = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells[0];
                chkEliminar.Value = !Convert.ToBoolean(chkEliminar.Value);
            }
        }

        private void clickEnCelda()
        {
            try
            {
                ctrlSeleccionado = 2;
                IdPresentacion = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdPresentacion"].Value);
                Presentacion = Convert.ToString(dgvListado.CurrentRow.Cells["Presentacion"].Value).Trim().ToUpper();
                Descripcion = Convert.ToString(dgvListado.CurrentRow.Cells["Descripcion"].Value).Trim();
            }
            catch
            {
            }
        }

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

        #region DOBLE CLIC DGV
        private void DobleClicEnCelda()
        {
            frmIngresarPresentacion formIngresarPresentacion = frmIngresarPresentacion.GetInstancia();
            formIngresarPresentacion.ctrlSeleccionado = 2;
            //clickEnCelda();
            formIngresarPresentacion.ShowDialog();
        }
        #endregion
        #endregion

        #region BUSCAR
        //METODO BUSCAR
        private void Buscar()
        {
            dgvListado.DataSource = NegocioPresentacion.Buscar(txtBuscar.Text);
            OcultarColumnas();
        }

        //TEXTBOX BUSCAR
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
            if (txtBuscar.TextLength > 0)
            {
                btnLimpiarBusqueda.Visible = true;
                txtBuscar.Width = 345;
            }
            else
            {
                btnLimpiarBusqueda.Visible = false;
                txtBuscar.Width = 373;
            }
        }
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = "";
            txtBuscar.SelectAll();
        }
        #endregion

        #region ELIMINAR
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string idPresentacion = "";
            string respuesta = "";
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
                                idPresentacion = Convert.ToString(row.Cells[1].Value);
                                respuesta = NegocioPresentacion.Eliminar(Convert.ToInt32(idPresentacion));
                            }
                        }
                        if (respuesta.Equals("OK"))
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
                        idPresentacion = Convert.ToString(dgvListado.CurrentRow.Cells[1].Value);
                        respuesta = NegocioPresentacion.Eliminar(Convert.ToInt32(idPresentacion));
                        if (respuesta.Equals("OK"))
                        {
                            NotificacionOk("Registro eliminado", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("El registro no se eliminó.", "Error");
                            MessageBox.Show(respuesta);
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
            ctrlSeleccionado = 0;
        }
        #endregion
        
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarPresentacion formIngresarPresentacion = frmIngresarPresentacion.GetInstancia();
            formIngresarPresentacion.ctrlSeleccionado = 0;
            formIngresarPresentacion.ShowDialog();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            //clickEnCelda();
            DobleClicEnCelda();
        }

        private void frmPresentacion_KeyDown(object sender, KeyEventArgs e)
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
                clickEnCelda();
                DobleClicEnCelda();
            }
        }
    }
}
