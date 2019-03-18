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
//
//using DevComponents.DotNetBar;
//using DevComponents.DotNetBar.Metro.ColorTables;

namespace CapaPresentacion
{
    public partial class frmProveedor : MetroForm//MaterialForm
    {

        public frmProveedor()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            Mostrar();
            dgvListado.ClearSelection();
            txtBuscar.SelectAll();
        }

        #region INSTANCIACION
        private static frmProveedor _Instancia = null;

        public static frmProveedor Instancia
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

        public static frmProveedor GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmProveedor();
                //Instancia.Disposed += new EventHandler(formProveedor_Disposed); BORRAR LUEGO
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmProveedor_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region EVENTOS CAPTURADOS

        //EVENTO FORM CLOSED, CUANDO SE CIERRA EL FORMULARIO HIJO, EL FORMULARIO PADRE ACTUALIZA SU dgvListado
        private void formIngresarProveedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            Mostrar();
            dgvListado.ClearSelection();
            btnIngresar.Enabled = true;
        }

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarProveedor_btnInsertarClick(object sender, EventArgs e)
        {
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
                frmIngresarProveedor formIngresarProveedor = new frmIngresarProveedor();
                formIngresarProveedor.ctrlSeleccionado = 2;
                formIngresarProveedor.IdProveedor = Convert.ToString(dgvListado.CurrentRow.Cells["IdProveedor"].Value).Trim();
                Convert.ToString(dgvListado.CurrentRow.Cells["RazonSocial"].Value);
                formIngresarProveedor.Nombres = Convert.ToString(dgvListado.CurrentRow.Cells["Nombres"].Value).Trim().ToUpper();
                formIngresarProveedor.Apellidos = Convert.ToString(dgvListado.CurrentRow.Cells["Apellidos"].Value).Trim().ToUpper();
                if (formIngresarProveedor.Apellidos == string.Empty)
                {
                    formIngresarProveedor.chkPersonaFisica.Checked = false;
                }
                else
                {
                    formIngresarProveedor.chkPersonaFisica.Checked = true;
                }
                formIngresarProveedor.TipoDocumento = Convert.ToString(dgvListado.CurrentRow.Cells["TipoDocumento"].Value).Trim().ToUpper();
                formIngresarProveedor.NumeroDocumento = Convert.ToString(dgvListado.CurrentRow.Cells["NumeroDocumento"].Value).Trim();
                formIngresarProveedor.Rubro = Convert.ToString(dgvListado.CurrentRow.Cells["Rubro"].Value).Trim();
                formIngresarProveedor.Domicilio = Convert.ToString(dgvListado.CurrentRow.Cells["Domicilio"].Value).Trim();
                formIngresarProveedor.TelefonoFijo = Convert.ToString(dgvListado.CurrentRow.Cells["TelefonoFijo"].Value).Trim();
                formIngresarProveedor.TelefonoCelular = Convert.ToString(dgvListado.CurrentRow.Cells["TelefonoCelular"].Value).Trim();
                formIngresarProveedor.Email = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value).Trim();
                formIngresarProveedor.URL = Convert.ToString(dgvListado.CurrentRow.Cells["URL"].Value).Trim();
                formIngresarProveedor.FormClosed += new FormClosedEventHandler(formIngresarProveedor_FormClosed);
                formIngresarProveedor.btnInsertar.Click += new EventHandler(formIngresarProveedor_btnInsertarClick);
                btnIngresar.Enabled = false;
                formIngresarProveedor.ShowDialog();
            }
            catch
            {
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
                dgvListado.Columns[2].HeaderText = "Razón Social";
                dgvListado.Columns[5].HeaderText = "Rubro";
                dgvListado.Columns[6].HeaderText = "Tipo de documento";
                dgvListado.Columns[7].HeaderText = "Nº de documento";
                dgvListado.Columns[8].HeaderText = "Domicilio";
                dgvListado.Columns[9].HeaderText = "Telefono fijo";
                dgvListado.Columns[10].HeaderText = "Celular";
                dgvListado.Columns[11].HeaderText = "email";
                dgvListado.Columns[12].HeaderText = "URL";
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
                dgvListado.Columns[3].Visible = false;
                dgvListado.Columns[4].Visible = false;
                dgvListado.Columns[6].Visible = false;
                dgvListado.Columns[7].Visible = false;
                dgvListado.Columns[8].Visible = false;
                dgvListado.Columns[11].Visible = false;
                dgvListado.Columns[12].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        //MOSTRAR
        public void Mostrar()
        {
            dgvListado.DataSource = NegocioProveedor.Mostrar();
            NombreColumnas();
            if (!chkEliminarVarios.Checked)
            {
                OcultarColumnas();
            }
        }


        #endregion

        #region AGREGAR
        //BOTON INGRESAR NUEVO PROVEEDOR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarProveedor formIngresarProveedor = new frmIngresarProveedor();
            formIngresarProveedor.ctrlSeleccionado = 0;
            //CAPTURADOR DE EVENTO FORM CLOSED
            formIngresarProveedor.FormClosed += new FormClosedEventHandler(formIngresarProveedor_FormClosed);
            //CAPTURADOR DE EVENTO CLICK EN BOTON INSERTAR
            formIngresarProveedor.btnInsertar.Click += new EventHandler(formIngresarProveedor_btnInsertarClick);
            btnIngresar.Enabled = false;
            formIngresarProveedor.ShowDialog();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string idProveedor = "";
            string Respuesta = "";
            DialogResult Opcion;
            frmIngresarProveedor formIngresarProveedor = new frmIngresarProveedor();
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
                                idProveedor = Convert.ToString(row.Cells[1].Value);
                                Respuesta = NegocioProveedor.Eliminar(Convert.ToInt32(idProveedor));
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarProveedor.NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            formIngresarProveedor.NotificacionError("Los registros no se eliminaron.", "Error");
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
                        idProveedor = Convert.ToString(dgvListado.CurrentRow.Cells[1].Value);
                        Respuesta = NegocioProveedor.Eliminar(Convert.ToInt32(idProveedor));
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarProveedor.NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            formIngresarProveedor.NotificacionError("El registro no se eliminó", "Error");
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
            dgvListado.DataSource = NegocioProveedor.Buscar(txtBuscar.Text);
            OcultarColumnas();
        }

        //private void BuscarNum_Documento()
        //{
        //    dgvListado.DataSource = NegocioProveedor.BuscarNum_Documento(txtBuscarNumero.Text);
        //    OcultarColumnas();
        //}

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
            btnLimpiarBusqueda.Visible = true;
        }
        
        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            btnLimpiarBusqueda.Visible = false;
        }

        //private void txtBuscarNumero_TextChanged(object sender, EventArgs e)
        //{
        //    BuscarNum_Documento();
        //    btnLimpiarNDocumento.Visible = true;
        //}

        //private void btnLimpiarNDocumento_Click(object sender, EventArgs e)
        //{
        //    txtBuscarNumero.Text = string.Empty;
        //    btnLimpiarNDocumento.Visible = false;
        //}

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region COMPORTAMIENTO DE TECLADO
        //PARA DEFINIR EL COMPORTAMIENTO DEL FORMULARIO AL PRESIONAR UNA TECLA SE DEBE ESTABLECER LA PROPIEDAD KeyPreview DEL FORM en true
        #region TECLA ESCAPE
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

        #region EVENTOS CONTRTOLES

        #region TEXTBOX BUSCAR
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            enterKeyPress(e);
        }
        #endregion

        //#region TEXTBOX BUSCAR NUMERO DE DOCUMENTO
        //private void txtBuscarNumero_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    enterKeyPress(e);
        //}
        //#endregion

        #region DATAGRIDVIEW
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
        private void frmProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }

        #endregion

        #endregion
        #endregion
    }
}
