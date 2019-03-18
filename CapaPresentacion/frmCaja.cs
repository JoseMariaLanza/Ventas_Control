using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

using CapaNegocio;
using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmCaja : MetroForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();
        public bool AperturaAutomatica;
        DataTable dtCajas = new DataTable();
        DataTable dtDetallesCaja = new DataTable();
        public frmCaja()
        {
            InitializeComponent();
        }

        private void frmCaja_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        #region INSTANCIACION
        private static frmCaja _Instancia = null;

        public static frmCaja Instancia
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

        public static frmCaja GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmCaja();
            }
            return Instancia;
        }
        private void frmCaja_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

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

        #region EVENTOS CAPTURADOS

        //EVENTO FORM CLOSED, CUANDO SE CIERRA EL FORMULARIO HIJO, EL FORMULARIO PADRE ACTUALIZA SU dgvListado
        private void formIngresarCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mostrar();
            btnIngresar.Enabled = true;
        }

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarCaja_btnInsertarClick(object sender, EventArgs e)
        {
            Mostrar();
            OcultarColumnas();
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

        //// CREACION DE DATATABLE dtDetallesCaja
        //private void CrearDetalleCaja()
        //{
        //    dtDetallesCaja = new DataTable("DetallesCaja");
        //    dtDetallesCaja.Columns.Add("IdDetalleCaja", Type.GetType("System.Int32"));
        //    dtDetallesCaja.Columns.Add("IdCaja", Type.GetType("System.Int32"));
        //    dtDetallesCaja.Columns.Add("Caja", Type.GetType("System.String"));
        //    dtDetallesCaja.Columns.Add("IdCategoria", Type.GetType("System.Int32"));
        //    dtDetallesCaja.Columns.Add("Categoria", Type.GetType("System.String"));
        //    dtDetallesCaja.Columns.Add("FormaCobro", Type.GetType("System.Decimal"));
        //    dtDetallesCaja.Columns.Add("Estado", Type.GetType("System.String"));
        //    dgvListado.DataSource = dtDetallesCaja;
        //}

        private void CrearCajas()
        {
            dtCajas = new DataTable("DetallesCaja");
            dtCajas.Columns.Add("IdCaja", Type.GetType("System.Int32"));
            dtCajas.Columns.Add("Caja", Type.GetType("System.String"));
            dtCajas.Columns.Add("FormaCobro", Type.GetType("System.String"));
            dtCajas.Columns.Add("Estado", Type.GetType("System.String"));
            dtCajas.Columns.Add("AperturaAutomatica", Type.GetType("System.Boolean"));
            dtCajas.Columns.Add("Terminal", Type.GetType("System.String"));
            dtCajas = NegocioCaja.Mostrar();
            //dgvListado.DataSource = dtCajas;
        }

        // CLIC EN DATAGRIDvIEW
        private void DgvClic()
        {
            frmIngresarCaja formIngresarCaja = frmIngresarCaja.GetInstancia();
            formIngresarCaja.ctrlSeleccionado = 2;
            formIngresarCaja.IdCaja = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCaja"].Value);
            formIngresarCaja.Caja = Convert.ToString(dgvListado.CurrentRow.Cells["Caja"].Value);
            formIngresarCaja.FormaCobro = Convert.ToString(dgvListado.CurrentRow.Cells["FormaCobro"].Value);
            formIngresarCaja.Estado = Convert.ToString(dgvListado.CurrentRow.Cells["Estado"].Value);
            //formIngresarCaja.AperturaAutomatica = Convert.ToBoolean(dgvListado.CurrentRow.Cells["AperturaAutomatica"].Value);
            //dtCategorias = new DataTable();
            //formIngresarCaja.CrearDetalleCaja(dtDetallesCaja);
            dtDetallesCaja = NegocioDetalleCaja.Mostrar(formIngresarCaja.IdCaja);
        }

        //DOBLE CLICK EN DATAGRID
        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                DgvClic();
                AbrirFormularioIngresoCaja();
            }
            catch
            {
            }
        }

        private void AbrirFormularioIngresoCaja()
        {
            frmIngresarCaja formIngresarCaja = frmIngresarCaja.GetInstancia();
            formIngresarCaja.FormClosed += new FormClosedEventHandler(formIngresarCaja_FormClosed);
            formIngresarCaja.btnInsertar.Click += new EventHandler(formIngresarCaja_btnInsertarClick);
            btnIngresar.Enabled = false;
            formIngresarCaja.ShowDialog();
        }

        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns["Caja"].HeaderText = "Nombre/Nº de caja";
                dgvListado.Columns["FormaCobro"].HeaderText = "Cobro";
                //dgvListado.Columns["AperturaAutomatica"].HeaderText = "Abrir automáticamente";
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
                dgvListado.Columns["IdCaja"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //MOSTRAR
        public void Mostrar()
        {
            //dgvListado.DataSource = NegocioCaja.Mostrar();
            CrearCajas();
            //dtCajas = NegocioCaja.Mostrar();
            dgvListado.DataSource = dtCajas;
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
            frmIngresarCaja formIngresarCaja = frmIngresarCaja.GetInstancia();
            formIngresarCaja.ctrlSeleccionado = 0;
            formIngresarCaja.FormClosed += new FormClosedEventHandler(formIngresarCaja_FormClosed);
            formIngresarCaja.btnInsertar.Click += new EventHandler(formIngresarCaja_btnInsertarClick);
            btnIngresar.Enabled = false;
            formIngresarCaja.ShowDialog();
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
            int idCaja;
            string Respuesta = "";
            DialogResult Opcion;
            frmIngresarCaja formIngresarCaja = frmIngresarCaja.GetInstancia();
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
                                idCaja = Convert.ToInt32(row.Cells[1].Value);
                                Respuesta = NegocioCaja.Eliminar(idCaja, dtDetallesCaja);
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("Los registros no se eliminaron.", "Error");
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
                        idCaja = Convert.ToInt32(dgvListado.CurrentRow.Cells[1].Value);
                        Respuesta = NegocioCaja.Eliminar(idCaja, dtDetallesCaja);
                        if (Respuesta.Equals("OK"))
                        {
                            NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            NotificacionError("El registro no se eliminó", "Error");
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
            dgvListado.DataSource = NegocioCaja.Buscar(txtBuscar.Text);
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
                DgvClic();
                AbrirFormularioIngresoCaja();
            }
        }
    }
}