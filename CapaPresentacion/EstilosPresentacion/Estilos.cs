using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Estilos_de_presentación
{
    class Estilos
    {
        #region PINTAR CELDAS DE TABLE LAYOUTPANEL
        public void pintarCeldas_CellPaint(TableLayoutPanel control, TableLayoutCellPaintEventArgs e)
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

        // EVENTO CELLPAINT DE TABLE LAYOUTPANEL
        public void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            TableLayoutPanel tlPanel = sender as TableLayoutPanel;
            pintarCeldas_CellPaint(tlPanel, e);
        }
        #endregion
    }
}
