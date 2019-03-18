using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;
using System.Windows.Forms.DataVisualization.Charting;
using CapaNegocio;
using System.Globalization;

using CapaPresentacion.Teclado;

namespace CapaPresentacion
{
    public partial class frmEstadisticas : MetroForm
    {
        DataTable dtSeries;
        DataTable dtGastos;
        string[] series;
        double[] puntos;
        DateTime Desde, Hasta;
        string Serie = "Articulos";
        string Punto = "Cantidad";
        bool Activar3D = false;

        #region DETALLES
        string Articulo = "";
        double Cantidad = 0;
        double PrecioCompra = 0;
        double PrecioVenta = 0;
        double TotalGananciasArticulo = 0;
        double TotalGanacias = 0;
        double TotalGastos = 0;
        double TotalGananciasFinal = 0;

        ControlTeclado controlTeclado = new ControlTeclado();

        #endregion
        public frmEstadisticas()
        {
            InitializeComponent();
        }

        private void frmEstadisticas_Load(object sender, EventArgs e)
        {
            chrtPersonalizado.Palette = ChartColorPalette.BrightPastel;
            Cargar(Serie, Punto);
        }

        #region INSTANCIACION
        private static frmEstadisticas _Instancia = null;

        public static frmEstadisticas Instancia
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

        public static frmEstadisticas GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new frmEstadisticas();
            }
            return Instancia;
        }

        private void frmEstadisticas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Instancia = null;
        }
        #endregion

        #region DATAGRIDVIEW
        private void OcultarColumnas()
        {
            dgvListado.Columns["Fecha"].Visible = false;
            dgvListado.Columns["IdVenta"].Visible = false;
            dgvListado.Columns["Total"].Visible = false;
            dgvListado.Columns["IdArticulo"].Visible = false;
            OcultarColumnas(Serie);
            dgvListado.Columns["IdCategoria"].Visible = false;
        }

        private void OcultarColumnas(string consulta)
        {
            if (consulta == "Articulos")
            {
                dgvListado.Columns["Articulos"].Visible = true;
                dgvListado.Columns["Presentacion"].Visible = true;
                dgvListado.Columns["PrecioCompra"].Visible = true;
                dgvListado.Columns["PrecioVenta"].Visible = true;
                dgvListado.Columns["GananciaArticulo"].Visible = true;
            }
            else if (consulta == "Categorias")
            {
                dgvListado.Columns["Articulos"].Visible = false;
                dgvListado.Columns["Presentacion"].Visible = false;
                dgvListado.Columns["PrecioCompra"].Visible = false;
                dgvListado.Columns["PrecioVenta"].Visible = false;
                dgvListado.Columns["GananciaArticulo"].Visible = false;
            }
        }

        private void NombreColumnas()
        {
            dgvListado.Columns["Fecha"].HeaderText = "Fecha y hora de la venta";

            dgvListado.Columns["Articulos"].HeaderText = "Artículo";

            dgvListado.Columns["Categorias"].HeaderText = "Categoría";

            dgvListado.Columns["Cantidad"].DefaultCellStyle.Format = "0.###";

            dgvListado.Columns["Presentacion"].HeaderText = "";

            dgvListado.Columns["Total"].HeaderText = "Total de la venta";
            dgvListado.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["Total"].DefaultCellStyle.Format = "$ 0.###";

            dgvListado.Columns["TotalPagado"].HeaderText = "Pagado";
            dgvListado.Columns["TotalPagado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["TotalPagado"].DefaultCellStyle.Format = "$ 0.###";

            dgvListado.Columns["TotalRestante"].HeaderText = "Saldo a pagar";
            dgvListado.Columns["TotalRestante"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["TotalRestante"].DefaultCellStyle.Format = "$ 0.###";

            dgvListado.Columns["PrecioCompra"].HeaderText = "Compra";
            dgvListado.Columns["PrecioCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["PrecioCompra"].DefaultCellStyle.Format = "$ 0.###";

            dgvListado.Columns["PrecioVenta"].HeaderText = "Venta";
            dgvListado.Columns["PrecioVenta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["PrecioVenta"].DefaultCellStyle.Format = "$ 0.###";

            dgvListado.Columns["GananciaArticulo"].HeaderText = "Ganancia x artículo";
            dgvListado.Columns["GananciaArticulo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["GananciaArticulo"].DefaultCellStyle.Format = "$ 0.###";

            dgvListado.Columns["GananciasTotales"].HeaderText = "Ganancias totales";
            dgvListado.Columns["GananciasTotales"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvListado.Columns["GananciasTotales"].DefaultCellStyle.Format = "$ 0.###";
        }
        #endregion

        #region CARGA DE DATOS

        private void Limpiar()
        {
            // DETALLES
            // Variables
            Articulo = "";
            Cantidad = 0;
            PrecioCompra = 0;
            PrecioVenta = 0;
            TotalGananciasArticulo = 0;
            TotalGanacias = 0;
            TotalGastos = 0;
            TotalGananciasFinal = 0;
            // Labels
            lblArticulo.Text = string.Empty;
            lblCantidad.Text = string.Empty;
            lblPrecioCompra.Text = string.Empty;
            lblPrecioVenta.Text = string.Empty;
            lblGananciaArticulo.Text = string.Empty;
            lblTotalGanancias.Text = string.Empty;
            lblTotalGananciasFinal.Text = string.Empty;

            // GRÁFICO
            chrtPersonalizado.Titles.Clear();
            chrtPersonalizado.Series.Clear();
            chrtPersonalizado.Palette = ChartColorPalette.None;
        }
        private void Cargar(string ParametroSerie, string ParametroPunto)
        {
            Limpiar();
            Desde = new DateTime(dtpDesde.Value.Year, dtpDesde.Value.Month, dtpDesde.Value.Day, 00, 00, 00);
            Hasta = new DateTime(dtpHasta.Value.Year, dtpHasta.Value.Month, dtpHasta.Value.Day, 23, 59, 59);

            dtSeries = NegocioEstadisticas.Mostrar(Desde, Hasta, ParametroSerie, ParametroPunto);
            dgvListado.DataSource = dtSeries;

            chrtPersonalizado.Titles.Add(dgvListado.RowCount.ToString() + " " + ParametroSerie + " - " + ParametroPunto);
            series = new string[dgvListado.RowCount];
            puntos = new double[dgvListado.RowCount];
            
            //CALCULAR
            foreach (DataRow row in dtSeries.Rows)
            {
                TotalGanacias += Convert.ToDouble(row["GananciasTotales"]);
                lblTotalGanancias.Text = TotalGanacias.ToString("$0.##", CultureInfo.InvariantCulture);
            }
            if (dtSeries.Rows.Count > 0)
            {
                dtGastos = NegocioGastos.Mostrar(Desde, Hasta);
                foreach (DataRow row in dtGastos.Rows)
                {
                    TotalGastos += Convert.ToDouble(row["Monto"]);
                    TotalGananciasFinal = TotalGanacias - TotalGastos;
                    lblTotalGananciasFinal.Text = TotalGananciasFinal.ToString("$0.##", CultureInfo.InvariantCulture);
                }
            }

            EstadisticasTipo(ParametroPunto, Activar3D);

            OcultarColumnas();
            NombreColumnas();
        }

        #region TIPO
        private void EstadisticasTipo(string ParametroPunto, bool activar3D)
        {
            if (activar3D)
            {
                chrtPersonalizado.ChartAreas[0].Area3DStyle.Enable3D = true;
            }
            else
            {
                chrtPersonalizado.ChartAreas[0].Area3DStyle.Enable3D = false;
            }
            chrtPersonalizado.ChartAreas[0].AxisX.Interval = 1;

            if (dgvListado.RowCount > 0)
            {
                for (int i = 0; i < series.Length; i++)
                {
                    // SERIES A VECTOR
                    series[i] = dgvListado.Rows[i].Cells[Serie].Value.ToString();
                    // PUNTOS A VECTOR ($/UN/KG...)
                    puntos[i] = Convert.ToDouble(dgvListado.Rows[i].Cells[ParametroPunto].Value);

                    // NOMBRES EN LA SERIE - Establece los valores para los items "Series" en
                    // la esquina superior derecha del chart, los cuales se diferencian por color
                    chrtPersonalizado.Series[i] = chrtPersonalizado.Series.Add(Convert.ToString(i + 1) + ") " + series[i]);
                    
                    // GRÁFICO TIPO COLUMNAS
                    chrtPersonalizado.Series[0].ChartType = SeriesChartType.Column;

                    // COLOR DE LA PALETA
                    chrtPersonalizado.Series[0].Palette = ChartColorPalette.BrightPastel;

                    //PUNTOS DEL GRÁFICO - Establece los valores en el eje de las X e Y
                    chrtPersonalizado.Series[0].Points.AddXY(i+1, puntos[i]);  // Muestra el valor de i+1 en el eje de las x
                    //chrtPersonalizado.Series[0].Points.AddXY(series[i], puntos[i]); // Muestra el nombre en el eje de las x
                    // ANCHO DE BARRAS
                    chrtPersonalizado.Series[0]["PointWidth"] = "0.8";

                    // FORMATEANDO COMPONENTE LABEL
                    // CAMBIANDO EL FONDO DEL COMPONENTE LABEL
                    chrtPersonalizado.Series[0].Points[i].LabelBackColor = Color.WhiteSmoke;
                    // CAMBIANDO EL COLOR DEL BORDE DEL COMPONENTE LABEL
                    //chrtPersonalizado.Series[0].Points[i].LabelBorderColor = Color.Black;
                    // CAMBIANDO EL ESTILO DE BORDE DEL COMPONENTE LABEL
                    chrtPersonalizado.Series[0].Points[i].LabelBorderDashStyle = ChartDashStyle.Solid;
                    // CAMBIANDO LA FUENTE DEL COMPONENTE LABEL
                    chrtPersonalizado.Series[0].Points[i].Font = new Font(chrtPersonalizado.Series[0].Points[i].Font, FontStyle.Bold);
                    if (ParametroPunto == "Cantidad")
                    {
                        // CAMBIANDO EL LABEL DE LA BARRA EN EL PUNTO ESPECIFICADO DE LA SERIE (Series[0])
                        chrtPersonalizado.Series[0].Points[i].Label = puntos[i].ToString();
                    }
                    else
                    {
                        chrtPersonalizado.Series[0].Points[i].Label = "$" + puntos[i].ToString();
                    }
                    chrtPersonalizado.Update();
                }
            }
        }
        #endregion

        #region CALCULAR
        private double Calcular(double[] ParametroPuntos)
        {
            double resultado = 0;
            for (int i = 0; i < puntos.Length; i++)
            {
                resultado = resultado + ParametroPuntos[i];
            }
            return resultado;
        }
        #endregion

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            Cargar(Serie, Punto);
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            Cargar(Serie, Punto);
        }

        private void chkEstablecerFechas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstablecerFechas.Checked)
            {
                dtpDesde.Enabled = true;
                dtpHasta.Enabled = true;
            }
            else
            {
                dtpDesde.Enabled = false;
                dtpHasta.Enabled = false;
            }
        }

        private void rbtnProducto_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
            Serie = "Articulos";
            Cargar(Serie, Punto);
        }

        private void rbtnCategoria_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
            Serie = "Categorias";
            Cargar(Serie, Punto);
        }

        private void rbtnCantidad_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
            Punto = "Cantidad";
            Cargar(Serie, Punto);
        }

        private void rbtnGanancia_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
            Punto = "GananciasTotales";
            Cargar(Serie, Punto);
        }
        
        private void rbtnGananciaProducto_CheckedChanged(object sender, EventArgs e)
        {
            Habilitar();
            Punto = "GananciaArticulo";
            Cargar(Serie, Punto);
        }

        private void rbtnVenta_CheckedChanged(object sender, EventArgs e)
        {
            Punto = "TotalVendido";
            Cargar(Serie, Punto);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkActivar3D_CheckedChanged(object sender, EventArgs e)
        {
            if (chkActivar3D.Checked)
            {
                Activar3D = true;
            }
            else
            {
                Activar3D = false;
            }
            Cargar(Serie, Punto);
        }

        private void dgvListado_Click(object sender, EventArgs e)
        {
            ClicDataGridView();
        }

        #endregion

        #region DATAGRIVIEW
        private void ClicDataGridView()
        {
            try
            {
                if (Serie == "Articulos")
                {
                    Articulo = dgvListado.CurrentRow.Cells["Articulos"].Value.ToString();
                    lblArticulo.Text = Articulo;
                    PrecioCompra = Convert.ToDouble(dgvListado.CurrentRow.Cells["PrecioCompra"].Value);
                    lblPrecioCompra.Text = PrecioCompra.ToString("$0..##", CultureInfo.InvariantCulture);
                    PrecioVenta = Convert.ToDouble(dgvListado.CurrentRow.Cells["PrecioVenta"].Value);
                    lblPrecioVenta.Text = PrecioVenta.ToString("$0..##", CultureInfo.InvariantCulture);
                    Cantidad = Convert.ToDouble(dgvListado.CurrentRow.Cells["Cantidad"].Value);
                    lblCantidad.Text = Cantidad.ToString("0..##", CultureInfo.InvariantCulture) + dgvListado.CurrentRow.Cells["Presentacion"].Value.ToString();
                    TotalGananciasArticulo = Convert.ToDouble(dgvListado.CurrentRow.Cells["GananciaArticulo"].Value);
                    lblGananciaArticulo.Text = TotalGananciasArticulo.ToString("$0..##", CultureInfo.InvariantCulture);
                }
            }
            catch { }
        }
        #endregion

        #region HABILITACIÓN DE OPCIONES
        private void Habilitar()
        {
            if (rbtnGananciaProducto.Checked)
            {
                rbtnCategoria.Enabled = false;
                rbtnCategoria.Checked = false;
            }
            else if (rbtnCategoria.Checked)
            {
                rbtnGananciaProducto.Enabled = false;
                rbtnGananciaProducto.Checked = false;
            }
            else
            {
                rbtnCategoria.Enabled = true;
                rbtnGananciaProducto.Enabled = true;
            }
        }
        #endregion

        #region TECLADO

        private void frmEstadisticas_KeyDown(object sender, KeyEventArgs e)
        {
            controlTeclado.CerrarForm(e, this);
        }

        private void dgvListado_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView control = (DataGridView)sender;
            if (controlTeclado.TeclaEnterEnDataGridView(control, e) == true)
                ClicDataGridView();
        }
        #endregion
    }
}