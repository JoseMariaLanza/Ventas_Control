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

using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmCliente : MetroForm //MaterialForm
    {
        public frmCliente()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtBuscar, "Presione 'Enter' al finalizar de escribir para seleccionar un registro de la lista");
            //ttMensaje.SetToolTip(txtBuscarNumero, "Presione 'Enter' al finalizar de escribir para seleccionar un registro de la lista");
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        #region INSTANCIACION
        private static frmCliente _Instancia = null;

        public static frmCliente Instancia
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

        public static frmCliente GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmCliente();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
            txtBuscar.SelectAll();
        }

        #region EVENTOS CAPTURADOS

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarCliente_btnInsertarClick(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                Buscar();
            }
            //else if (txtBuscarNumero.TextLength > 0)
            //{
            //    BuscarNum_Documento();
            //}
            else
            {
                Mostrar();
            }
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
                frmIngresarCliente formIngresarCliente = new frmIngresarCliente();
                formIngresarCliente.ctrlSeleccionado = 2;
                formIngresarCliente.IdCliente = Convert.ToString(dgvListado.CurrentRow.Cells["IdCliente"].Value).Trim();
                Convert.ToString(dgvListado.CurrentRow.Cells["Apellidos"].Value).Trim().ToUpper();
                formIngresarCliente.Nombres = Convert.ToString(dgvListado.CurrentRow.Cells["Nombres"].Value).Trim().ToUpper();
                formIngresarCliente.Apellidos = Convert.ToString(dgvListado.CurrentRow.Cells["Apellidos"].Value).Trim().ToUpper();
                if (formIngresarCliente.Apellidos == string.Empty)
                {
                    formIngresarCliente.chkPersonaFisica.Checked = false;
                }
                else
                {
                    formIngresarCliente.chkPersonaFisica.Checked = true;
                }
                formIngresarCliente.Sexo = Convert.ToString(dgvListado.CurrentRow.Cells["sexo"].Value).Trim();
                formIngresarCliente.FechaNacimiento = Convert.ToDateTime(dgvListado.CurrentRow.Cells["FechaNacimiento"].Value);
                formIngresarCliente.TipoDocumento = Convert.ToString(dgvListado.CurrentRow.Cells["TipoDocumento"].Value).Trim().ToUpper();
                formIngresarCliente.NumeroDocumento = Convert.ToString(dgvListado.CurrentRow.Cells["NumeroDocumento"].Value).Trim();
                formIngresarCliente.Domicilio = Convert.ToString(dgvListado.CurrentRow.Cells["Domicilio"].Value).Trim();
                formIngresarCliente.TelefonoFijo = Convert.ToString(dgvListado.CurrentRow.Cells["TelefonoFijo"].Value).Trim();
                formIngresarCliente.TelefonoCelular = Convert.ToString(dgvListado.CurrentRow.Cells["TelefonoCelular"].Value).Trim();
                formIngresarCliente.Email = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value).Trim();
                formIngresarCliente.btnInsertar.Click += new EventHandler(formIngresarCliente_btnInsertarClick);
                formIngresarCliente.ShowDialog();
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
                dgvListado.Columns["RazonSocial"].HeaderText = "Razón Social";
                dgvListado.Columns["Sexo"].HeaderText = "Sexo";
                dgvListado.Columns["FechaNacimiento"].HeaderText = "Fecha de Nac.";
                dgvListado.Columns["TipoDocumento"].HeaderText = "Tipo de documento";
                dgvListado.Columns["NumeroDocumento"].HeaderText = "Nº de documento";
                dgvListado.Columns["Domicilio"].HeaderText = "Domicilio";
                dgvListado.Columns["TelefonoFijo"].HeaderText = "Telefono fijo";
                dgvListado.Columns["TelefonoCelular"].HeaderText = "Celular";
                dgvListado.Columns["Email"].HeaderText = "Email";
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
                dgvListado.Columns[5].Visible = false;
                dgvListado.Columns[6].Visible = false;
                dgvListado.Columns[7].Visible = false;
                dgvListado.Columns[8].Visible = false;
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
            int cantidadRegistros = 0;
            dgvListado.DataSource = NegocioCliente.Mostrar();
            NombreColumnas();
            if (!chkEliminarVarios.Checked)
            {
                OcultarColumnas();
            }
            foreach (DataGridViewRow row in dgvListado.Rows)
            {
                cantidadRegistros++;
            }
            lblCantidadClientes.Text = "Cantidad de clientes: " + cantidadRegistros;
        }

        private void CargarGrilla()
        {
            frmCliente formCliente = new frmCliente();
            if (formCliente.txtBuscar.TextLength > 0)
            {
                Buscar();
            }
            else
            {
                Mostrar();
                //if (formCliente.txtBuscarNumero.TextLength > 0)
                //{
                //    BuscarNum_Documento();
                //}
                //else
                //{
                //    Mostrar();
                //}
            }
        }
        #endregion

        #region AGREGAR
        //BOTON INGRESAR NUEVO PROVEEDOR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarCliente formIngresarCliente = new frmIngresarCliente();
            formIngresarCliente.ctrlSeleccionado = 0;
            //CAPTURADOR DE EVENTO CLICK EN BOTON INSERTAR
            formIngresarCliente.btnInsertar.Click += new EventHandler(formIngresarCliente_btnInsertarClick);
            formIngresarCliente.ShowDialog();
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
            int idCliente;
            string Respuesta = "";
            DialogResult Opcion;
            frmIngresarCliente formIngresarCliente = new frmIngresarCliente();
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
                                idCliente = Convert.ToInt32(row.Cells["IdCliente"].Value);
                                if (idCliente > 1)
                                {
                                    Respuesta = NegocioCliente.Eliminar(idCliente);
                                }
                                else if (idCliente <= 0)
                                {
                                    MessageBox.Show("Seleccione un cliente.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("No puede eliminar a este cliente.", "Acción no permitida.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarCliente.NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            formIngresarCliente.NotificacionError("Los registros no se eliminaron.", "Error");
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
                        idCliente = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCliente"].Value);
                        if (idCliente > 1)
                        {
                            Respuesta = NegocioCliente.Eliminar(idCliente);
                        }
                        else if (idCliente <= 0)
                        {
                            MessageBox.Show("Seleccione un cliente.", "Acción no permitida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No puede eliminar a este cliente.", "Acción no permitida.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarCliente.NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            formIngresarCliente.NotificacionError("El registro no se eliminó", "Error");
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
            dgvListado.DataSource = NegocioCliente.Buscar(txtBuscar.Text);
            OcultarColumnas();
        }

        //private void BuscarNum_Documento()
        //{
        //    dgvListado.DataSource = NegocioCliente.BuscarNum_Documento(txtBuscarNumero.Text);
        //    OcultarColumnas();
        //}

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            Buscar();
            btnLimpiarBusqueda.Visible = true;
            if (txtBuscar.Text == "")
            {
                btnLimpiarBusqueda.Visible = false;
            }
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
        //    if (txtBuscarNumero.Text == "")
        //    {
        //        btnLimpiarNDocumento.Visible = false;
        //    }
        //    if (txtBuscar.TextLength > 0)
        //    {
        //        txtBuscar.Text = string.Empty;
        //    }
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

        #region COMPORTAMIENTO TECLADO
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
                if (dgvListado.Focused)
                {
                    DobleClickDgvCell();
                }
                else
                {
                    dgvListado.Focus();
                }
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
        private void frmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion

        #endregion

        #endregion

    }
}
