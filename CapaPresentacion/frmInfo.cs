using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace CapaPresentacion
{
    public partial class frmInfo : Form
    {
        bool MostrarForm;
        //int tiempoAbierto = 0;
        public frmInfo()
        {
            InitializeComponent();
        }

        private void frmInfo_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        #region INSTANCIACION
        private static frmInfo _Instancia;

        public static frmInfo Instancia
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

        public static frmInfo GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmInfo();
            }
            return Instancia;
        }

        private void frmInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        private void frmInfo_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!MostrarForm)
            {
                Opacity -= .10;
                if (Opacity == 0)
                {
                    timer1.Stop();
                    Close();
                }
            }
        }

        private void frmInfo_MouseLeave(object sender, EventArgs e)
        {
            MostrarForm = false;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void lblIdProducto_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void lblCodigo_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void lblNombre_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void lblCategoria_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void lblPresentacion_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void txtDescripcion_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void pbxImagenProducto_MouseEnter(object sender, EventArgs e)
        {
            MostrarFormulario();
        }

        private void MostrarFormulario()
        {
            Opacity = 1;
            MostrarForm = true;
        }
    }
}