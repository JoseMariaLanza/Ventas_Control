using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace CapaPresentacion
{
    public partial class frmCartelCumpleanios : DevComponents.DotNetBar.Metro.MetroForm
    {
        public frmCartelCumpleanios()
        {
            InitializeComponent();
        }

        private void frmCartelCumpleanios_Load(object sender, EventArgs e)
        {

        }

        private void btnAgradecer_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}