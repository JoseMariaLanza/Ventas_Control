using CapaNegocio;
using CapaPresentacion.Teclado;
using DevComponents.DotNetBar.Metro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmDeudores : MetroForm
    {
        public int IdCliente;
        string Cliente;
        int IdDeuda;
        string Descripcion;
        bool HabilitarControles;

        ControlTeclado controlTeclado = new ControlTeclado();

        public frmDeudores()
        {
            InitializeComponent();
        }

        private void frmDeudores_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        #region INSTANCIACION
        private static frmDeudores _Instancia = null;

        public static frmDeudores Instancia
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

        public static frmDeudores GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmDeudores();
            }
            return Instancia;
        }

        //METODO FORM CLOSING PARA ELIMINAR LA REFERENCIA DE LA INSTANCIA
        private void frmDeudores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region MOSTRAR
        public void Mostrar()
        {
            dgvListado.DataSource = NegocioDeuda.Mostrar();
            OcultarColumnas();
        }

        private void OcultarColumnas()
        {
            dgvListado.Columns["IdDeuda"].Visible = false;
            dgvListado.Columns["IdCliente"].Visible = false;
            dgvListado.Columns["IdVenta"].Visible = false;
        }
        #endregion

        private void dgvListado_Click(object sender, EventArgs e)
        {
            try
            {
                AsignarValorAVariablesGlobales();
                HabilitarControles = false;
            }
            catch { }
        }

        private void AsignarValorAVariablesGlobales()
        {
            IdDeuda = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdDeuda"].Value);
            IdCliente = Convert.ToInt32(dgvListado.CurrentRow.Cells["IdCliente"].Value);
            Cliente = dgvListado.CurrentRow.Cells["Cliente"].Value.ToString();
            Descripcion = dgvListado.CurrentRow.Cells["Descripcion"].Value.ToString();
        }

        private void dgvListado_DoubleClick(object sender, EventArgs e)
        {
            AbrirFormularioDetallesDeuda();
        }

        private void AbrirFormularioDetallesDeuda()
        {
            frmIngresarPago formIngresarPago = frmIngresarPago.GetInstancia();
            AsignarValorAVariablesGlobalesDeFormularioDeDetallesDeuda(formIngresarPago);
            HabilitarControlesDeFormularioDetallesDeuda(formIngresarPago, HabilitarControles);
            formIngresarPago.ShowDialog();
            formIngresarPago.BringToFront();
        }

        private void AsignarValorAVariablesGlobalesDeFormularioDeDetallesDeuda(frmIngresarPago formIngresarPago)
        {
            formIngresarPago.IdDeuda = IdDeuda;
            formIngresarPago.IdCliente = IdCliente;
            formIngresarPago.Cliente = Cliente;
            formIngresarPago.Descripcion = Descripcion;
        }

        private void HabilitarControlesDeFormularioDetallesDeuda(frmIngresarPago formIngresarPago, bool habilitarControles)
        {
            formIngresarPago.HabilitarControles(habilitarControles);
        }

        private void ComprobarSiHayDeudaSeleccionada()
        {
            if (IdDeuda > 0)
            {
                AbrirFormularioDetallesDeuda();
            }
            else
            {
                MessageBox.Show("Seleccione un registro", "OPERACIÓN NO ADMITIDA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            HabilitarControles = true;
            ComprobarSiHayDeudaSeleccionada();
        }

        private void tbpDeudores_Click(object sender, EventArgs e)
        {
            try
            {
                IdCliente = 0;
                lblTitulo.Text = "Deudores";
                MostrarClientesConDeudas();
            }
            catch { }
        }

        public void MostrarClientesConDeudas()
        {
            dgvDeudores.DataSource = NegocioDeuda.MostrarDeudores();
            OcultarColumnasDeudores();
        }

        private void OcultarColumnasDeudores()
        {
            dgvDeudores.Columns["IdCliente"].Visible = false;
        }

        private void tbpDeudas_Click(object sender, EventArgs e)
        {
            try
            {
                lblTitulo.Text = "Deudas";
                Mostrar();
            }
            catch { }
        }

        private void dgvDeudores_Click(object sender, EventArgs e)
        {
            try
            {
                IdCliente = Convert.ToInt32(dgvDeudores.CurrentRow.Cells["IdCliente"].Value);
            }
            catch { }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pintarCeldas_CellPaint(TableLayoutPanel control, TableLayoutCellPaintEventArgs e)
        {
            for (int i = 0; i <= control.ColumnCount; i++)
            {
                for (int j = 0; j <= control.RowCount; j++)
                {
                    using (SolidBrush brush = new SolidBrush(Color.WhiteSmoke))
                        e.Graphics.FillRectangle(brush, e.ClipRectangle);
                }
            }
        }

        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutPanel control = (TableLayoutPanel)sender;
            pintarCeldas_CellPaint(control, e);
        }

        private void tabControl_Click(object sender, EventArgs e)
        {
            Mostrar();
            MostrarClientesConDeudas();
        }

        private void btnCambiarEstado_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirFormularioCambiarEstado();
            }
            catch { }
        }

        private void AbrirFormularioCambiarEstado()
        {
            frmCambiarEstadoCliente formCambiarEstadoCliente = frmCambiarEstadoCliente.GetInstancia();
            formCambiarEstadoCliente.Show();
        }

        private void frmDeudores_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            controlTeclado.DireccionarEventoDeControl(sender, e);
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            if (controlTeclado.DireccionarEventoDeControl(sender, e))
            {
                AsignarValorAVariablesGlobales();
                AbrirFormularioDetallesDeuda();
            }
        }
    }
}
