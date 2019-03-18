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

namespace CapaPresentacion.Informes
{
    public partial class frmInformes : MetroForm
    {
        public frmInformes()
        {
            InitializeComponent();
        }

        private void frmInformes_Load(object sender, EventArgs e)
        {

            this.rvInforme.RefreshReport();
        }
    }
}
