using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    class Themas
    {
        private Form _Formulario;

        public Form Formulario
        {
            get
            {
                return _Formulario;
            }

            set
            {
                _Formulario = value;
            }
        }

        public Themas()
        {

        }

        public Themas(Form formulario)
        {
            Formulario = formulario;
        }

        public void cambiarThema(Form formulario)
        {
            foreach (Control ctrl in formulario.Controls)
            {
                try
                {
                    ctrl.BackColor = Color.FromArgb(64, 64, 64);
                    ctrl.ForeColor = Color.FromArgb(255, 255, 255);
                }
                catch (InvalidCastException ex)
                {
                    MessageBox.Show("Excepción casteo inválido: " + ex.Message + " Trace: " + ex.StackTrace);
                }
            }
        }
    }
}
