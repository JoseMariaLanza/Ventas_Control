namespace CapaPresentacion
{
    partial class frmEstadisticas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbtnCategoria = new System.Windows.Forms.RadioButton();
            this.rbtnArticulo = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnCantidad = new System.Windows.Forms.RadioButton();
            this.rbtnGananciaTotal = new System.Windows.Forms.RadioButton();
            this.rbtnVenta = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnGananciaProducto = new System.Windows.Forms.RadioButton();
            this.chrtPersonalizado = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.chkEstablecerFechas = new MaterialSkin.Controls.MaterialCheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLimpiarBusquedaNombre = new System.Windows.Forms.Button();
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTotalGanancias = new System.Windows.Forms.Label();
            this.chkActivar3D = new MaterialSkin.Controls.MaterialCheckBox();
            this.lblGananciaArticulo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPrecioCompra = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTotalGananciasFinal = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpPersonalizado = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPersonalizado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tbpPersonalizado.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtnCategoria
            // 
            this.rbtnCategoria.AutoSize = true;
            this.rbtnCategoria.Location = new System.Drawing.Point(7, 31);
            this.rbtnCategoria.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnCategoria.Name = "rbtnCategoria";
            this.rbtnCategoria.Size = new System.Drawing.Size(79, 23);
            this.rbtnCategoria.TabIndex = 0;
            this.rbtnCategoria.Text = "Categoría";
            this.rbtnCategoria.UseVisualStyleBackColor = true;
            this.rbtnCategoria.CheckedChanged += new System.EventHandler(this.rbtnCategoria_CheckedChanged);
            // 
            // rbtnArticulo
            // 
            this.rbtnArticulo.AutoSize = true;
            this.rbtnArticulo.Checked = true;
            this.rbtnArticulo.Location = new System.Drawing.Point(7, 64);
            this.rbtnArticulo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnArticulo.Name = "rbtnArticulo";
            this.rbtnArticulo.Size = new System.Drawing.Size(72, 23);
            this.rbtnArticulo.TabIndex = 1;
            this.rbtnArticulo.TabStop = true;
            this.rbtnArticulo.Text = "Artículo";
            this.rbtnArticulo.UseVisualStyleBackColor = true;
            this.rbtnArticulo.CheckedChanged += new System.EventHandler(this.rbtnProducto_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnArticulo);
            this.groupBox1.Controls.Add(this.rbtnCategoria);
            this.groupBox1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(117, 159);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Consultar";
            // 
            // rbtnCantidad
            // 
            this.rbtnCantidad.AutoSize = true;
            this.rbtnCantidad.Checked = true;
            this.rbtnCantidad.Location = new System.Drawing.Point(7, 31);
            this.rbtnCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnCantidad.Name = "rbtnCantidad";
            this.rbtnCantidad.Size = new System.Drawing.Size(76, 23);
            this.rbtnCantidad.TabIndex = 2;
            this.rbtnCantidad.TabStop = true;
            this.rbtnCantidad.Text = "Cantidad";
            this.rbtnCantidad.UseVisualStyleBackColor = true;
            this.rbtnCantidad.CheckedChanged += new System.EventHandler(this.rbtnCantidad_CheckedChanged);
            // 
            // rbtnGananciaTotal
            // 
            this.rbtnGananciaTotal.AutoSize = true;
            this.rbtnGananciaTotal.Location = new System.Drawing.Point(7, 64);
            this.rbtnGananciaTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnGananciaTotal.Name = "rbtnGananciaTotal";
            this.rbtnGananciaTotal.Size = new System.Drawing.Size(124, 23);
            this.rbtnGananciaTotal.TabIndex = 3;
            this.rbtnGananciaTotal.TabStop = true;
            this.rbtnGananciaTotal.Text = "Ganancias Totales";
            this.rbtnGananciaTotal.UseVisualStyleBackColor = true;
            this.rbtnGananciaTotal.CheckedChanged += new System.EventHandler(this.rbtnGanancia_CheckedChanged);
            // 
            // rbtnVenta
            // 
            this.rbtnVenta.AutoSize = true;
            this.rbtnVenta.Enabled = false;
            this.rbtnVenta.Location = new System.Drawing.Point(7, 126);
            this.rbtnVenta.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnVenta.Name = "rbtnVenta";
            this.rbtnVenta.Size = new System.Drawing.Size(59, 23);
            this.rbtnVenta.TabIndex = 4;
            this.rbtnVenta.TabStop = true;
            this.rbtnVenta.Text = "Venta";
            this.rbtnVenta.UseVisualStyleBackColor = true;
            this.rbtnVenta.CheckedChanged += new System.EventHandler(this.rbtnVenta_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnGananciaProducto);
            this.groupBox2.Controls.Add(this.rbtnVenta);
            this.groupBox2.Controls.Add(this.rbtnGananciaTotal);
            this.groupBox2.Controls.Add(this.rbtnCantidad);
            this.groupBox2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(132, 69);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(202, 159);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tipo";
            // 
            // rbtnGananciaProducto
            // 
            this.rbtnGananciaProducto.AutoSize = true;
            this.rbtnGananciaProducto.Location = new System.Drawing.Point(7, 95);
            this.rbtnGananciaProducto.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rbtnGananciaProducto.Name = "rbtnGananciaProducto";
            this.rbtnGananciaProducto.Size = new System.Drawing.Size(154, 23);
            this.rbtnGananciaProducto.TabIndex = 5;
            this.rbtnGananciaProducto.TabStop = true;
            this.rbtnGananciaProducto.Text = "Ganancia por producto";
            this.rbtnGananciaProducto.UseVisualStyleBackColor = true;
            this.rbtnGananciaProducto.CheckedChanged += new System.EventHandler(this.rbtnGananciaProducto_CheckedChanged);
            // 
            // chrtPersonalizado
            // 
            chartArea2.Name = "ChartArea1";
            this.chrtPersonalizado.ChartAreas.Add(chartArea2);
            this.chrtPersonalizado.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chrtPersonalizado.Legends.Add(legend2);
            this.chrtPersonalizado.Location = new System.Drawing.Point(3, 4);
            this.chrtPersonalizado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chrtPersonalizado.Name = "chrtPersonalizado";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chrtPersonalizado.Series.Add(series2);
            this.chrtPersonalizado.Size = new System.Drawing.Size(585, 310);
            this.chrtPersonalizado.TabIndex = 0;
            this.chrtPersonalizado.Text = "chart1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.presentation__1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.dgvListado.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvListado.Location = new System.Drawing.Point(12, 264);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(430, 231);
            this.dgvListado.TabIndex = 112;
            this.dgvListado.Click += new System.EventHandler(this.dgvListado_Click);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(69, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 47);
            this.label1.TabIndex = 111;
            this.label1.Text = "Estadísticas";
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalir.Image = global::CapaPresentacion.Properties.Resources.exit_hand_drawn_interface_symbol;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(353, 501);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 35);
            this.btnSalir.TabIndex = 114;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(12, 501);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(89, 35);
            this.btnImprimir.TabIndex = 115;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // chkEstablecerFechas
            // 
            this.chkEstablecerFechas.AutoSize = true;
            this.chkEstablecerFechas.Depth = 0;
            this.chkEstablecerFechas.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkEstablecerFechas.Location = new System.Drawing.Point(341, 87);
            this.chkEstablecerFechas.Margin = new System.Windows.Forms.Padding(0);
            this.chkEstablecerFechas.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkEstablecerFechas.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkEstablecerFechas.Name = "chkEstablecerFechas";
            this.chkEstablecerFechas.Ripple = true;
            this.chkEstablecerFechas.Size = new System.Drawing.Size(66, 30);
            this.chkEstablecerFechas.TabIndex = 116;
            this.chkEstablecerFechas.Text = "Filtrar";
            this.chkEstablecerFechas.UseVisualStyleBackColor = true;
            this.chkEstablecerFechas.CheckedChanged += new System.EventHandler(this.chkEstablecerFechas_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 117;
            this.label2.Text = "Desde:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 19);
            this.label3.TabIndex = 118;
            this.label3.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(340, 137);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(102, 27);
            this.dtpDesde.TabIndex = 119;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(340, 189);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(102, 27);
            this.dtpHasta.TabIndex = 120;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 19);
            this.label4.TabIndex = 121;
            this.label4.Text = "Búsqueda:";
            // 
            // btnLimpiarBusquedaNombre
            // 
            this.btnLimpiarBusquedaNombre.BackColor = System.Drawing.Color.White;
            this.btnLimpiarBusquedaNombre.BackgroundImage = global::CapaPresentacion.Properties.Resources.circle;
            this.btnLimpiarBusquedaNombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarBusquedaNombre.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusquedaNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusquedaNombre.Location = new System.Drawing.Point(418, 235);
            this.btnLimpiarBusquedaNombre.Name = "btnLimpiarBusquedaNombre";
            this.btnLimpiarBusquedaNombre.Size = new System.Drawing.Size(24, 23);
            this.btnLimpiarBusquedaNombre.TabIndex = 123;
            this.btnLimpiarBusquedaNombre.UseVisualStyleBackColor = false;
            this.btnLimpiarBusquedaNombre.Visible = false;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Hint = "Buscar por nombre";
            this.txtBuscar.Location = new System.Drawing.Point(82, 235);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(360, 23);
            this.txtBuscar.TabIndex = 122;
            this.txtBuscar.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(465, 476);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(295, 19);
            this.label5.TabIndex = 124;
            this.label5.Text = "Total de ganancias en el rango de fechas establecido:";
            // 
            // lblTotalGanancias
            // 
            this.lblTotalGanancias.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalGanancias.AutoSize = true;
            this.lblTotalGanancias.Location = new System.Drawing.Point(766, 476);
            this.lblTotalGanancias.Name = "lblTotalGanancias";
            this.lblTotalGanancias.Size = new System.Drawing.Size(0, 19);
            this.lblTotalGanancias.TabIndex = 125;
            // 
            // chkActivar3D
            // 
            this.chkActivar3D.AutoSize = true;
            this.chkActivar3D.Depth = 0;
            this.chkActivar3D.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkActivar3D.Location = new System.Drawing.Point(263, 27);
            this.chkActivar3D.Margin = new System.Windows.Forms.Padding(0);
            this.chkActivar3D.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkActivar3D.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkActivar3D.Name = "chkActivar3D";
            this.chkActivar3D.Ripple = true;
            this.chkActivar3D.Size = new System.Drawing.Size(166, 30);
            this.chkActivar3D.TabIndex = 126;
            this.chkActivar3D.Text = "Activar gráficos en 3D";
            this.chkActivar3D.UseVisualStyleBackColor = true;
            this.chkActivar3D.CheckedChanged += new System.EventHandler(this.chkActivar3D_CheckedChanged);
            // 
            // lblGananciaArticulo
            // 
            this.lblGananciaArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGananciaArticulo.AutoSize = true;
            this.lblGananciaArticulo.Location = new System.Drawing.Point(538, 457);
            this.lblGananciaArticulo.Name = "lblGananciaArticulo";
            this.lblGananciaArticulo.Size = new System.Drawing.Size(0, 19);
            this.lblGananciaArticulo.TabIndex = 128;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(465, 457);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 19);
            this.label7.TabIndex = 127;
            this.label7.Text = "Ganancias:";
            // 
            // lblArticulo
            // 
            this.lblArticulo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(538, 378);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(0, 19);
            this.lblArticulo.TabIndex = 130;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(465, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 19);
            this.label8.TabIndex = 129;
            this.label8.Text = "Artículo:";
            // 
            // lblPrecioCompra
            // 
            this.lblPrecioCompra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrecioCompra.AutoSize = true;
            this.lblPrecioCompra.Location = new System.Drawing.Point(581, 397);
            this.lblPrecioCompra.Name = "lblPrecioCompra";
            this.lblPrecioCompra.Size = new System.Drawing.Size(0, 19);
            this.lblPrecioCompra.TabIndex = 132;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(465, 397);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(110, 19);
            this.label9.TabIndex = 131;
            this.label9.Text = "Precio de compra:";
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(581, 416);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(0, 19);
            this.lblPrecioVenta.TabIndex = 134;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(465, 419);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 19);
            this.label11.TabIndex = 133;
            this.label11.Text = "Precio de venta:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(538, 438);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(0, 19);
            this.lblCantidad.TabIndex = 136;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(465, 438);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 19);
            this.label10.TabIndex = 135;
            this.label10.Text = "Cantidad:";
            // 
            // lblTotalGananciasFinal
            // 
            this.lblTotalGananciasFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalGananciasFinal.AutoSize = true;
            this.lblTotalGananciasFinal.Location = new System.Drawing.Point(634, 495);
            this.lblTotalGananciasFinal.Name = "lblTotalGananciasFinal";
            this.lblTotalGananciasFinal.Size = new System.Drawing.Size(0, 19);
            this.lblTotalGananciasFinal.TabIndex = 138;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(465, 495);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(163, 19);
            this.label12.TabIndex = 137;
            this.label12.Text = "Total de ganancias - Gastos:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tbpPersonalizado);
            this.tabControl1.Location = new System.Drawing.Point(448, 13);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(599, 350);
            this.tabControl1.TabIndex = 2;
            // 
            // tbpPersonalizado
            // 
            this.tbpPersonalizado.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbpPersonalizado.Controls.Add(this.chrtPersonalizado);
            this.tbpPersonalizado.Location = new System.Drawing.Point(4, 28);
            this.tbpPersonalizado.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpPersonalizado.Name = "tbpPersonalizado";
            this.tbpPersonalizado.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpPersonalizado.Size = new System.Drawing.Size(591, 318);
            this.tbpPersonalizado.TabIndex = 0;
            this.tbpPersonalizado.Text = "Personalizado";
            // 
            // frmEstadisticas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1062, 548);
            this.Controls.Add(this.lblTotalGananciasFinal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblPrecioVenta);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblPrecioCompra);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblArticulo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblGananciaArticulo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkActivar3D);
            this.Controls.Add(this.lblTotalGanancias);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLimpiarBusquedaNombre);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEstablecerFechas);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "frmEstadisticas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEstadisticas_FormClosing);
            this.Load += new System.EventHandler(this.frmEstadisticas_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmEstadisticas_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chrtPersonalizado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tbpPersonalizado.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnCategoria;
        private System.Windows.Forms.RadioButton rbtnArticulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnCantidad;
        private System.Windows.Forms.RadioButton rbtnGananciaTotal;
        private System.Windows.Forms.RadioButton rbtnVenta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chrtPersonalizado;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private MaterialSkin.Controls.MaterialCheckBox chkEstablecerFechas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLimpiarBusquedaNombre;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
        private System.Windows.Forms.RadioButton rbtnGananciaProducto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTotalGanancias;
        private MaterialSkin.Controls.MaterialCheckBox chkActivar3D;
        private System.Windows.Forms.Label lblGananciaArticulo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPrecioCompra;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTotalGananciasFinal;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpPersonalizado;
    }
}