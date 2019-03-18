using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace CapaPresentacion.Scripts.Formateo
{
    public class Formatear
    {
        public decimal DevolverDecimal(string valorAConvertir, string desdeFormato)
        {
            try
            {
                return ConvertirADecimal(valorAConvertir, desdeFormato);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw;
            }
        }

        private decimal ConvertirADecimal(string valorAConvertir, string desdeFormato)
        {
            decimal valorEnDecimal;
            switch (desdeFormato)
            {
                case "Moneda":
                    valorEnDecimal = Moneda(valorAConvertir);
                    break;
                default:
                    valorEnDecimal = Convert.ToDecimal(valorAConvertir);
                    break;
            }
            return valorEnDecimal;
        }

        private decimal Moneda(string valorAConvertir)
        {
            decimal valorDecimal;
            if (valorAConvertir.Contains("$"))
            {
                valorDecimal = Convert.ToDecimal(valorAConvertir.Substring(1, valorAConvertir.Length - 1));
            }
            else
            {
                valorDecimal = Convert.ToDecimal(valorAConvertir);
            }
            return valorDecimal;
        }

        #region FORMATEO DE CONTROLES

        public DataTable CrearDtFormatear() // Formateo básico
        {
            DataTable dtFormatear = new DataTable("Formatear");
            dtFormatear.Columns.Add("NombresColumnas");
            dtFormatear.Columns.Add("OcultarColumnas");
            dtFormatear.Columns.Add("FormatearAMoneda");
            return dtFormatear;
        }

        public void AgregarFilasADtFormatear()
        {

        }

        public DataTable CrearDtFormatear(string[] operacionesFormateo) // Formateo Personalizado
        {
            DataTable dtFormatear = new DataTable("Formatear");
            for (int i = 0; i < operacionesFormateo.Length; i++)
            {
                dtFormatear.Columns.Add(operacionesFormateo[i]);
            }
            return dtFormatear;
        }

        #region DATAGRIDVIEW
        
        public void FormatearDataGridView(DataGridView controlDGV, DataTable dtFormatear)
        {
            foreach (DataColumn operacion in dtFormatear.Columns)
            {
                foreach (DataRow aplicarEn in dtFormatear.Rows)
                {
                    switch (operacion.ColumnName)
                    {
                        case "NombresColumnas":
                            NombresColumnas(controlDGV, (string[])aplicarEn.ItemArray);
                            break;
                        case "OcultarColumnas":
                            OcultarColumnas(controlDGV, (string[])aplicarEn.ItemArray);
                            break;
                        case "FormatearAMoneda":
                            FormatearAMoneda(controlDGV, (string[])aplicarEn.ItemArray);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private void NombresColumnas(DataGridView controlDGV, string[] cabecera)
        {
            for (int i = 0; i < cabecera.Length; i++)
            {
                controlDGV.Columns[i].HeaderText = cabecera[i];
            }
        }

        private void OcultarColumnas(DataGridView controlDGV, string[] columnas)
        {
            for (int i = 0; i < columnas.Length; i++)
            {
                foreach (DataGridViewColumn columna in controlDGV.Columns)
                {
                    if (columna.Name == columnas[i])
                    {
                        columna.Visible = false;
                    }
                }
            }
        }

        private void FormatearAMoneda(DataGridView controlDGV, string[] campos)
        {
            for (int i = 0; i < campos.Length; i++)
            {
                foreach (DataGridViewColumn columna in controlDGV.Columns)
                {
                    if (columna.Name == campos[i])
                    {
                        columna.DefaultCellStyle.Format = "$#0.#0";
                    }
                }
            }
        }
        
        #endregion



        #endregion
    }
}
