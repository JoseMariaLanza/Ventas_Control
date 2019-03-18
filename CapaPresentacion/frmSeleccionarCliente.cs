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

namespace CapaPresentacion
{
    public partial class frmSeleccionarCliente : MaterialForm
    {
        frmIngresarVenta formIngresarVenta = frmIngresarVenta.GetInstancia();
        public int IdCliente;
        public string Cliente;

        public frmSeleccionarCliente()
        {
            InitializeComponent();
            var skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        private void frmSeleccionarCliente_Load(object sender, EventArgs e)
        {
            Mostrar();
            txtBuscar.SelectAll();
            txtBuscar.Hint = "Nombres, Apellidos, Nº de documento";
            //txtBuscarNumero.Hint = "Nº de Documento del cliente";
        }

        #region INSTANCIACIÓN
        private static frmSeleccionarCliente _Instancia = null;

        public static frmSeleccionarCliente Instancia
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

        public static frmSeleccionarCliente GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmSeleccionarCliente();
            }
            return Instancia;
        }

        private void frmSeleccionarCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region MOSTRAR

        //DOBLE CLICK EN CELDAS
        private void dgvListado_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DobleClickDgv();
        }

        //METODO DOBLE CLICK EN CELDA
        private void DobleClickDgv()
        {
            try
            {
                ClickFila();
                if (Convert.ToString(dgvListado.CurrentRow.Cells["Estado"].Value).Equals("MOROSO"))
                {
                    MessageBox.Show("La clasificación para este cliente es MOROSO. No puede ser seleccionado para contraer deudas nuevas.",
                        "Cliente moroso.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    formIngresarVenta.SetCliente();
                }
                Close();// Se deshabilita ya que al cerrar el formulario, éste no pasa parametros nuevos a menos que se cree una nueva instancia en el formulario padre
            }
            catch
            {
            }
        }

        private void ClickFila()
        {
            formIngresarVenta.IdCliente = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCliente"].Value);
            formIngresarVenta.Cliente = Convert.ToString(dgvListado.CurrentRow.Cells["RazonSocial"].Value); // VER CODIGO DE frmIngresarIngreso
            // SI PIERDO EL HILO
            formIngresarVenta.EstadoCliente = Convert.ToString(dgvListado.CurrentRow.Cells["Estado"].Value);
        }

        //NOMENCLACION DE COLUMNAS
        private void NombreColumnas()
        {
            try
            {
                dgvListado.Columns["RazonSocial"].HeaderText = "Razón Social";
                dgvListado.Columns[5].HeaderText = "Sexo";
                dgvListado.Columns[6].HeaderText = "Fecha de Nac.";
                dgvListado.Columns[7].HeaderText = "Tipo de documento";
                dgvListado.Columns[8].HeaderText = "Nº de documento";
                dgvListado.Columns[9].HeaderText = "Domicilio";
                dgvListado.Columns[10].HeaderText = "Telefono fijo";
                dgvListado.Columns[11].HeaderText = "Celular";
                dgvListado.Columns[12].HeaderText = "email";
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
            OcultarColumnas();
            foreach (DataGridViewRow row in dgvListado.Rows)
            {
                cantidadRegistros++;
            }
            lblCantidadClientes.Text = "Cantidad de clientes: " + cantidadRegistros;
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
                    DobleClickDgv();
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

        #region TEXTBOX BUSCAR NUMERO DE DOCUMENTO
        private void txtBuscarNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                DobleClickDgv();
            }
        }
        #endregion

        #region FORMULARIO
        private void frmSeleccionarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            cerrarForm(e);
        }
        #endregion

        #endregion

        #endregion

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            DobleClickDgv();
        }
    }
}
