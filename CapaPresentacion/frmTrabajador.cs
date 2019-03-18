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

using DevComponents.DotNetBar.Metro;

namespace CapaPresentacion
{
    public partial class frmTrabajador : MetroForm //MaterialForm
    {
        public frmTrabajador()
        {
            InitializeComponent();
            ttMensaje.SetToolTip(txtBuscar, "Presione 'Enter' al finalizar de escribir para seleccionar un registro de la lista");
            ttMensaje.SetToolTip(txtBuscarNumero, "Presione 'Enter' al finalizar de escribir para seleccionar un registro de la lista");
            var skinManager = MaterialSkinManager.Instance;
            //skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            //skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmTrabajador_Load(object sender, EventArgs e)
        {
            Mostrar();
            txtBuscar.SelectAll();
        }

        #region INSTANCIACION
        private static frmTrabajador _Instancia = null;

        public static frmTrabajador Instancia
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

        public static frmTrabajador GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmTrabajador();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmTrabajador_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region EVENTOS CAPTURADOS

        //EVENTO CLICK EN BOTÓN INSERTAR, ACTUALIZACIÓN DE CONTROL dgvListado
        private void formIngresarTrabajador_btnInsertarClick(object sender, EventArgs e)
        {
            if (txtBuscar.TextLength > 0)
            {
                BuscarNombre();
            }
            else if (txtBuscarNumero.TextLength > 0)
            {
                BuscarNum_Documento();
            }
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
                frmIngresarTrabajador formIngresarTrabajador = new frmIngresarTrabajador();
                formIngresarTrabajador.ctrlSeleccionado = 2;
                formIngresarTrabajador.idtrabajador = Convert.ToString(dgvListado.CurrentRow.Cells["idtrabajador"].Value).Trim();
                formIngresarTrabajador.nombre = Convert.ToString(dgvListado.CurrentRow.Cells["nombre"].Value).Trim().ToUpper();
                formIngresarTrabajador.apellido = Convert.ToString(dgvListado.CurrentRow.Cells["apellido"].Value).Trim().ToUpper();
                formIngresarTrabajador.sexo = Convert.ToString(dgvListado.CurrentRow.Cells["sexo"].Value).Trim();
                formIngresarTrabajador.fecha_nacimiento = Convert.ToDateTime(dgvListado.CurrentRow.Cells["fecha_nacimiento"].Value);
                formIngresarTrabajador.num_documento = Convert.ToString(dgvListado.CurrentRow.Cells["num_documento"].Value).Trim();
                formIngresarTrabajador.domicilio = Convert.ToString(dgvListado.CurrentRow.Cells["domicilio"].Value).Trim();
                formIngresarTrabajador.tel_fijo = Convert.ToString(dgvListado.CurrentRow.Cells["tel_fijo"].Value).Trim();
                formIngresarTrabajador.tel_cel = Convert.ToString(dgvListado.CurrentRow.Cells["tel_cel"].Value).Trim();
                formIngresarTrabajador.email = Convert.ToString(dgvListado.CurrentRow.Cells["email"].Value).Trim();
                formIngresarTrabajador.acceso = Convert.ToString(dgvListado.CurrentRow.Cells["acceso"].Value).Trim().ToUpper();
                formIngresarTrabajador.usuario = Convert.ToString(dgvListado.CurrentRow.Cells["usuario"].Value).Trim();
                formIngresarTrabajador.password = Convert.ToString(dgvListado.CurrentRow.Cells["password"].Value).Trim();
                formIngresarTrabajador.btnInsertar.Click += new EventHandler(formIngresarTrabajador_btnInsertarClick);
                formIngresarTrabajador.ShowDialog();
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
                dgvListado.Columns[2].HeaderText = "Trabajador";
                dgvListado.Columns[7].HeaderText = "Nº de documento";
                dgvListado.Columns[9].HeaderText = "Teléfono fijo";
                dgvListado.Columns[10].HeaderText = "Celular";
                dgvListado.Columns[12].HeaderText = "Acceso";
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
                dgvListado.Columns[8].Visible = false;
                dgvListado.Columns[11].Visible = false;
                dgvListado.Columns[13].Visible = false;
                dgvListado.Columns[14].Visible = false;
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
            dgvListado.DataSource = NegocioTrabajador.Mostrar();
            NombreColumnas();
            if (!chkEliminarVarios.Checked)
            {
                OcultarColumnas();
            }
            foreach (DataGridViewRow row in dgvListado.Rows)
            {
                cantidadRegistros++;
            }
            lblCantidadClientes.Text = "Cantidad de trabajadores: " + cantidadRegistros;
        }

        private void CargarGrilla()
        {
            frmTrabajador formTrabajador = new frmTrabajador();
            if (formTrabajador.txtBuscar.TextLength > 0)
            {
                BuscarNombre();
            }
            else
            {
                if (formTrabajador.txtBuscarNumero.TextLength > 0)
                {
                    BuscarNum_Documento();
                }
                else
                {
                    Mostrar();
                }
            }
        }


        #endregion

        #region AGREGAR
        //BOTON INGRESAR NUEVO PROVEEDOR
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmIngresarTrabajador formIngresarTrabajador = new frmIngresarTrabajador();
            formIngresarTrabajador.ctrlSeleccionado = 0;
            //CAPTURADOR DE EVENTO CLICK EN BOTON INSERTAR
            formIngresarTrabajador.btnInsertar.Click += new EventHandler(formIngresarTrabajador_btnInsertarClick);
            formIngresarTrabajador.ShowDialog();
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
            string idtrabajador = "";
            string Respuesta = "";
            DialogResult Opcion;
            frmIngresarTrabajador formIngresarTrabajdor = new frmIngresarTrabajador();
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
                                idtrabajador = Convert.ToString(row.Cells[1].Value);
                                Respuesta = NegocioTrabajador.Eliminar(Convert.ToInt32(idtrabajador));
                            }
                        }
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarTrabajdor.NotificacionOk("Los registros se eliminaron correctamente.", "Eliminando");
                        }
                        else
                        {
                            formIngresarTrabajdor.NotificacionError("Los registros no se eliminaron.", "Error");
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
                        idtrabajador = Convert.ToString(dgvListado.CurrentRow.Cells[1].Value);
                        Respuesta = NegocioTrabajador.Eliminar(Convert.ToInt32(idtrabajador));
                        if (Respuesta.Equals("OK"))
                        {
                            formIngresarTrabajdor.NotificacionOk("El registro se eliminó correctamente", "Eliminando");
                        }
                        else
                        {
                            formIngresarTrabajdor.NotificacionError("El registro no se eliminó", "Error");
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
        private void BuscarNombre()
        {
            dgvListado.DataSource = NegocioTrabajador.BuscarNombre(txtBuscar.Text);
            OcultarColumnas();
        }

        private void BuscarNum_Documento()
        {
            dgvListado.DataSource = NegocioTrabajador.BuscarNum_Documento(txtBuscarNumero.Text);
            OcultarColumnas();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            BuscarNombre();
            btnLimpiarBusquedaNombre.Visible = true;
            if (txtBuscar.Text == "")
            {
                btnLimpiarBusquedaNombre.Visible = false;
            }
        }

        private void btnLimpiarBusquedaNombre_Click(object sender, EventArgs e)
        {
            txtBuscar.Text = string.Empty;
            btnLimpiarBusquedaNombre.Visible = false;
        }

        private void txtBuscarNumero_TextChanged(object sender, EventArgs e)
        {
            BuscarNum_Documento();
            btnLimpiarNDocumento.Visible = true;
            if (txtBuscarNumero.Text == "")
            {
                btnLimpiarNDocumento.Visible = false;
            }
            if (txtBuscar.TextLength > 0)
            {
                txtBuscar.Text = string.Empty;
            }
        }

        private void btnLimpiarNDocumento_Click(object sender, EventArgs e)
        {
            txtBuscarNumero.Text = string.Empty;
            btnLimpiarNDocumento.Visible = false;
        }

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

        #region SOLO NUMEROS
        private void ingresarNumero(KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
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

        #region TEXTBOX BUSCAR NUMERO DE DOCUMENTO
        private void txtBuscarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            ingresarNumero(e);
            enterKeyPress(e);
        }
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
        private void frmTrabajador_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion

        #endregion

        #endregion

        
    }
}
