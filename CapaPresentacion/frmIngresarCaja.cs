using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using CapaNegocio;

using CapaPresentacion.Teclado;
using CapaPresentacion.Properties;

namespace CapaPresentacion
{
    public partial class frmIngresarCaja : MaterialForm
    {
        ControlTeclado controlTeclado = new ControlTeclado();
        Settings Configuracion = new Settings();

        public int ctrlSeleccionado;
        public int IdCategoriaCaja;
        public int IdCaja;
        public string Caja;
        public string FormaCobro;
        public string Estado;
        public int IdCategoria;
        public bool AperturaAutomatica;

        string Terminal = Environment.MachineName;

        DataTable dtDetallesCaja; // Detalles de la caja - Categorías que se venden en la caja

        public frmIngresarCaja()
        {
            InitializeComponent();
        }

        private void frmIngresarCaja_Load(object sender, EventArgs e)
        {
            HabilitarBotones();
            listaCategoria();
            if (ctrlSeleccionado == 2)
            {
                Mostrar();
            }
            else
            {
                CrearDetalleCaja();
            }
        }

        #region INSTANCIACION
        private static frmIngresarCaja _Instancia;

        public static frmIngresarCaja Instancia
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

        public static frmIngresarCaja GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmIngresarCaja();
            }
            return Instancia;
        }

        private void frmIngresarCaja_FormClosing(object sender, FormClosingEventArgs e)
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

        #region MOSTRAR
        private void Mostrar()
        {
            CrearDetalleCaja();
            dtDetallesCaja = NegocioDetalleCaja.Mostrar(IdCaja);
            dgvListado.DataSource = dtDetallesCaja;
            NombreColumnas();
            OcultarColumnas();
        }
        #endregion

        //LIMPIAR TODOS LOS CONTROLES
        public void Limpiar()
        {
            txtIdCaja.Text = string.Empty;
            txtCaja.Text = string.Empty;
            cmbCategoria.SelectedIndex = -1;
            dtDetallesCaja.Clear();
        }

        #region HABILITAR

        //HABILITAR CONTROLES
        private void Habilitar(bool valor)
        {
            txtCaja.Enabled = !valor;
            cmbFormaCobro.Enabled = !valor;
            cmbCategoria.Enabled = !valor;
            btnIngresar.Enabled = !valor;
            dgvListado.Enabled = !valor;
            btnEliminar.Enabled = !valor;
            chkAperturaAutomatica.Enabled = !valor;
        }

        //HABILITAR TODOS LOS CONTROLES, INCLUYENDO BOTONES
        private void HabilitarBotones()
        {
            switch (ctrlSeleccionado)
            {
                case 0: //NUEVO
                    Habilitar(false);
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnEditar.Visible = false;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = false;
                    //IdCaja = Convert.ToInt32(txtIdCaja.Text);
                    Caja = txtCaja.Text;
                    IdCategoria = cmbCategoria.SelectedIndex;
                    lblCaja.Text = "Nueva Caja";
                    txtCaja.SelectAll();
                    break;
                case 1: //EDITAR
                    Habilitar(false);
                    btnInsertar.Enabled = false;
                    btnEditar.Visible = false;
                    btnInsertar.Enabled = true;
                    btnInsertar.Visible = true;
                    btnNuevo.Visible = false;
                    btnCancelar.Visible = true;
                    lblCaja.Text = "Detalles";
                    txtCaja.SelectAll();
                    break;
                case 2: //CONSULTAR
                    Habilitar(true);
                    btnEditar.Visible = true;
                    btnNuevo.Visible = true;
                    lblCaja.Text = "Detalles";
                    txtIdCaja.Text = IdCaja.ToString();
                    txtCaja.Text = Caja;
                    cmbFormaCobro.Text = FormaCobro;
                    txtEstado.Text = Estado;
                    cmbCategoria.SelectedValue = IdCategoria;
                    chkAperturaAutomatica.Checked = AperturaAutomatica;
                    break;
                case 3: //CANCELAR
                    Habilitar(true);
                    btnCancelar.Visible = false;
                    btnNuevo.Visible = true;
                    txtCaja.Text = Caja;
                    cmbCategoria.SelectedValue = IdCategoria;
                    btnInsertar.Visible = false;
                    btnEditar.Visible = true;
                    lblCaja.Text = "Detalles";
                    dgvListado.DataSource = dtDetallesCaja;
                    break;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 0;
            HabilitarBotones();
            btnCancelar.Visible = true;
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 1;
            HabilitarBotones();
        }

        #endregion

        #region BOTÓN CANCELAR
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ctrlSeleccionado = 3;
            txtIdCaja.Text = IdCaja.ToString();
            txtCaja.Text = Caja;
            cmbCategoria.SelectedIndex = IdCategoria;
            HabilitarBotones();
        }
        #endregion

        #region LLENADO DE COMBOBOX CATEGORÍAS
        private void listaCategoria()
        {
            cmbCategoria.DataSource = NegocioCategoria.Mostrar();
            cmbCategoria.ValueMember = "IdCategoria";
            cmbCategoria.DisplayMember = "Categoria";
            cmbCategoria.SelectedValue = 0;
        }
        #endregion

        #region CREACION DE DATATABLE dtCategorias
        public void CrearDetalleCaja()
        {
            dtDetallesCaja = new DataTable("DetallesCaja");
            dtDetallesCaja.Columns.Add("IdDetalleCaja", Type.GetType("System.Int32"));
            dtDetallesCaja.Columns.Add("IdCaja", Type.GetType("System.Int32"));
            //dtDetallesCaja.Columns.Add("Caja", Type.GetType("System.String"));
            //dtDetallesCaja.Columns.Add("FormaCobro", Type.GetType("System.String"));
            //dtDetallesCaja.Columns.Add("Estado", Type.GetType("System.String"));
            dtDetallesCaja.Columns.Add("IdCategoria", Type.GetType("System.Int32"));
            dtDetallesCaja.Columns.Add("Categoria", Type.GetType("System.String"));
            //dtDetallesCaja.Columns.Add("AperturaAutomatica", Type.GetType("System.Boolean"));
            //dtDetallesCaja.Columns.Add("Terminal", Type.GetType("System.String"));
            dgvListado.DataSource = dtDetallesCaja;
            NombreColumnas();
            OcultarColumnas();
        }

        public void CrearDetalleCaja(DataTable dtDetallesCaja)
        {
            dtDetallesCaja = new DataTable("DetallesCaja");
            dtDetallesCaja.Columns.Add("IdDetalleCaja", Type.GetType("System.Int32"));
            dtDetallesCaja.Columns.Add("IdCaja", Type.GetType("System.Int32"));
            //dtDetallesCaja.Columns.Add("Caja", Type.GetType("System.String"));
            //dtDetallesCaja.Columns.Add("FormaCobro", Type.GetType("System.String"));
            //dtDetallesCaja.Columns.Add("Estado", Type.GetType("System.String"));
            dtDetallesCaja.Columns.Add("IdCategoria", Type.GetType("System.Int32"));
            dtDetallesCaja.Columns.Add("Categoria", Type.GetType("System.String"));
            dgvListado.DataSource = dtDetallesCaja;
            NombreColumnas();
            OcultarColumnas();
        }

        #region COLUMNAS

        #region NOMBRES
        private void NombreColumnas()
        {
            dgvListado.Columns["Categoria"].HeaderText = "Esta caja vende las siguientes categorías:";
        }
        #endregion

        #region VISIBILIDAD
        private void OcultarColumnas()
        {
            dgvListado.Columns["IdDetalleCaja"].Visible = false;
            dgvListado.Columns["IdCaja"].Visible = false;
            //dgvListado.Columns["Caja"].Visible = false;
            dgvListado.Columns["IdCategoria"].Visible = false;
        }
        #endregion

        #endregion
        #endregion

        #region DATAGRIDVIEW
        
        #endregion

        #region AGREGAR CATEGORÍA A DATATABLE

        private void AgregarCategoria()
        {
            IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
            if (IdCategoria < 1)
            {
                errorIcono.SetError(cmbCategoria, "Seleccione una categoría");
                cmbCategoria.Focus();
            }
            else
            {
                bool insertarDetalle = true;
                foreach (DataRow row in dtDetallesCaja.Rows)
                {
                    if (Convert.ToInt32(row["IdCategoria"]) == IdCategoria)
                    {
                        insertarDetalle = false;
                    }
                }
                if (insertarDetalle)
                {
                    //Agregar detalle a dtCategorias
                    DataRow row = dtDetallesCaja.NewRow();
                    row["IdDetalleCaja"] = IdCategoriaCaja;
                    //row["IdCaja"] = IdCaja;
                    row["IdCategoria"] = IdCategoria;
                    row["Categoria"] = cmbCategoria.Text;
                    dtDetallesCaja.Rows.Add(row);
                }
            }
        }

        #region ELIMINACION DE CATEGORÍA
        private void Eliminar()
        {
            DialogResult Opcion;
            try
            {
                int idDetalleCaja;
                string respuesta = "";
                switch (ctrlSeleccionado)
                {
                    case 0://INSERTAR
                        int indiceFila = dgvListado.CurrentCell.RowIndex;
                        DataRow row = dtDetallesCaja.Rows[indiceFila];
                        dtDetallesCaja.Rows.Remove(row);
                        dgvListado.DataSource = dtDetallesCaja;
                        break;
                    case 1://EDITAR
                           //SELECCION DE UN REGISTRO
                        Opcion = MessageBox.Show(
                            "¿Realmente desea eliminar el registro seleccionado?",
                            "Eliminando registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (Opcion == DialogResult.Yes)
                        {
                            idDetalleCaja = Convert.ToInt32(dgvListado.CurrentRow.Cells[0].Value);
                            respuesta = NegocioDetalleCaja.Eliminar(idDetalleCaja);
                            if (respuesta.Equals("OK"))
                            {
                                NotificacionOk("Registro eliminado", "Eliminando");
                            }
                            else
                            {
                                NotificacionError("El registro no se eliminó.", "Error");
                            }
                            Mostrar();
                        }
                        break;
                    default:
                        NotificacionError(respuesta, "Error");
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
            if (dgvListado.RowCount > 0)
            {
                btnEliminar.Visible = true;
            }
            else
            {
                btnEliminar.Visible = false;
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.RowCount > 0)
            {
                Eliminar();
            }
        }
        #endregion

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            AgregarCategoria();
        }
        #endregion

        #region INSERTAR - EDITAR

        //#region OBTENER ID DE CAJA RECIÉN INSERTADA
        //private int ObtenerId()
        //{
        //    return NegocioCaja.ObtenerId();
        //}
        //#endregion

        #region METODO INSERTAR REGISTRO - EDITAR REGISTRO
        private void InsertarEditar()
        {
            Caja = txtCaja.Text;
            FormaCobro = cmbFormaCobro.Text;
            string agregarActualizar = "";
            if (txtCaja.Text == string.Empty)
            {
                errorIcono.SetError(txtCaja, "Ingrese el nombre de la caja.");
                txtCaja.SelectAll();
            }
            else if (dtDetallesCaja.Rows.Count < 1)
            {
                errorIcono.SetError(cmbCategoria, "Ingrese la categoría de productos que se venderán en esta caja");
                cmbCategoria.PerformLayout();
            }
            else if (cmbFormaCobro.Text == string.Empty)
            {
                errorIcono.SetError(cmbFormaCobro, "Ingrese la forma de cobro.");
                cmbFormaCobro.PerformLayout();
            }
            else
            {
                try
                {
                    switch (ctrlSeleccionado)
                    {
                        case 0://INSERTAR
                            agregarActualizar = NegocioCaja.Insertar(Caja, FormaCobro, AperturaAutomatica, Terminal, dtDetallesCaja);
                            if (agregarActualizar.Equals("OK"))
                            {
                                NotificacionOk("Caja guardada correctamente", "Guardando");
                                //Configuracion.IdCaja = Convert.ToInt32(agregarActualizar); // No retorna parámetro, retorna respuesta string
                                //Configuracion.Save();
                                HabilitarBotones();
                                txtCaja.SelectAll();
                                Limpiar();
                            }
                            else
                            {
                                NotificacionError("Error al intentar guardar la Caja", "Error");
                                MessageBox.Show(agregarActualizar, "Error");
                            }
                            break;
                        case 1://EDITAR
                            agregarActualizar = NegocioCaja.Editar(IdCaja, Caja, FormaCobro, AperturaAutomatica, Terminal, dtDetallesCaja);
                            if (agregarActualizar.Equals("OK"))
                            {
                                //Configuracion.IdCaja = IdCaja;
                                //Configuracion.Save();
                                txtCaja.Enabled = false;
                                cmbCategoria.Enabled = false;
                                btnEditar.Visible = true;
                                btnInsertar.Visible = false;
                                btnCancelar.Visible = false;
                                btnNuevo.Visible = true;
                                NotificacionOk("Caja editada correctamente", "Editando");
                            }
                            else
                            {
                                NotificacionError("Error al intentar editar la caja", "Error");
                                MessageBox.Show(agregarActualizar, "Error");
                            }
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
            }
        }
        #endregion

        #region BOTÓN GUARDAR
        private void btnInsertar_Click(object sender, EventArgs e)
        {
            InsertarEditar();
        }
        #endregion

        #endregion

        #region TECLADO

        #endregion

        private void frmIngresarCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            //controlTeclado.PasarAlControlSiguiente(e);
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void dgvListado_Enter(object sender, EventArgs e)
        {
            if (dgvListado.RowCount > 0)
            {
                btnEliminar.Enabled = true;
            }
            else
            {
                btnEliminar.Enabled = false;
            }
        }

        private void chkAperturaAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAperturaAutomatica.Checked)
            {
                AperturaAutomatica = true;
            }
            else
            {
                AperturaAutomatica = false;
            }
        }

        private void txtCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void cmbFormaCobro_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void cmbCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void frmIngresarCaja_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }
    }
}
