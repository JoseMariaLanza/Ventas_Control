namespace CapaPresentacion
{
    partial class frmAperturaCierreCaja
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnIngresarCierreCaja = new System.Windows.Forms.Button();
            this.btnIngresarAperturaCaja = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tpAperturasPredefinidas = new System.Windows.Forms.TabControl();
            this.tpAperturasCierres = new System.Windows.Forms.TabPage();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnProgramarApertura = new System.Windows.Forms.Button();
            this.btnAperturaPredefinida = new System.Windows.Forms.Button();
            this.dgvListadoAperturasPredefinidas = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCajas = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tpAperturasPredefinidas.SuspendLayout();
            this.tpAperturasCierres.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoAperturasPredefinidas)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(77, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 47);
            this.label3.TabIndex = 326;
            this.label3.Text = "Arqueo de cajas";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(156, 42);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(119, 27);
            this.dtpHasta.TabIndex = 2;
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(7, 42);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(119, 27);
            this.dtpDesde.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 19);
            this.label1.TabIndex = 330;
            this.label1.Text = "Hasta:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 19);
            this.label2.TabIndex = 329;
            this.label2.Text = "Desde:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpHasta);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpDesde);
            this.groupBox1.Location = new System.Drawing.Point(310, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 77);
            this.groupBox1.TabIndex = 333;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Búsqueda";
            // 
            // lblInfo
            // 
            this.lblInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInfo.Location = new System.Drawing.Point(3, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(411, 44);
            this.lblInfo.TabIndex = 337;
            this.lblInfo.Text = "Seleccione un registro para mostrar la información rápida o haga doble clic para " +
    "ver más detalles";
            // 
            // btnIngresarCierreCaja
            // 
            this.btnIngresarCierreCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIngresarCierreCaja.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnIngresarCierreCaja.FlatAppearance.BorderSize = 0;
            this.btnIngresarCierreCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarCierreCaja.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarCierreCaja.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngresarCierreCaja.Image = global::CapaPresentacion.Properties.Resources.coins_stacks_of_dollars_hand_drawn_commercial_symbol;
            this.btnIngresarCierreCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarCierreCaja.Location = new System.Drawing.Point(420, 3);
            this.btnIngresarCierreCaja.Name = "btnIngresarCierreCaja";
            this.btnIngresarCierreCaja.Size = new System.Drawing.Size(104, 38);
            this.btnIngresarCierreCaja.TabIndex = 6;
            this.btnIngresarCierreCaja.Text = "&Cerrar caja";
            this.btnIngresarCierreCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresarCierreCaja.UseVisualStyleBackColor = true;
            this.btnIngresarCierreCaja.Click += new System.EventHandler(this.btnIngresarCierreCaja_Click);
            // 
            // btnIngresarAperturaCaja
            // 
            this.btnIngresarAperturaCaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIngresarAperturaCaja.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnIngresarAperturaCaja.FlatAppearance.BorderSize = 0;
            this.btnIngresarAperturaCaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresarAperturaCaja.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresarAperturaCaja.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngresarAperturaCaja.Image = global::CapaPresentacion.Properties.Resources.paper;
            this.btnIngresarAperturaCaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresarAperturaCaja.Location = new System.Drawing.Point(174, 3);
            this.btnIngresarAperturaCaja.Name = "btnIngresarAperturaCaja";
            this.btnIngresarAperturaCaja.Size = new System.Drawing.Size(104, 38);
            this.btnIngresarAperturaCaja.TabIndex = 4;
            this.btnIngresarAperturaCaja.Text = "&Abrir caja";
            this.btnIngresarAperturaCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresarAperturaCaja.UseVisualStyleBackColor = true;
            this.btnIngresarAperturaCaja.Click += new System.EventHandler(this.btnIngresarAperturaCaja_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.BackColor = System.Drawing.Color.White;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSalir.Image = global::CapaPresentacion.Properties.Resources.exit_hand_drawn_interface_symbol;
            this.btnSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalir.Location = new System.Drawing.Point(743, 415);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 35);
            this.btnSalir.TabIndex = 10;
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
            this.btnImprimir.Location = new System.Drawing.Point(12, 415);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(89, 35);
            this.btnImprimir.TabIndex = 335;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.Registradora_contabilidad;
            this.pictureBox2.Location = new System.Drawing.Point(13, 14);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 327;
            this.pictureBox2.TabStop = false;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.Text = "notifyIcon1";
            this.iconoNotificacion.Visible = true;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(12, 95);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 320);
            this.panel1.TabIndex = 340;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.tpAperturasPredefinidas, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvCajas, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(820, 320);
            this.tableLayoutPanel1.TabIndex = 340;
            this.tableLayoutPanel1.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // tpAperturasPredefinidas
            // 
            this.tpAperturasPredefinidas.Controls.Add(this.tpAperturasCierres);
            this.tpAperturasPredefinidas.Controls.Add(this.tabPage2);
            this.tpAperturasPredefinidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tpAperturasPredefinidas.Location = new System.Drawing.Point(290, 53);
            this.tpAperturasPredefinidas.Name = "tpAperturasPredefinidas";
            this.tpAperturasPredefinidas.SelectedIndex = 0;
            this.tpAperturasPredefinidas.Size = new System.Drawing.Size(527, 264);
            this.tpAperturasPredefinidas.TabIndex = 5;
            this.tpAperturasPredefinidas.Click += new System.EventHandler(this.tpAperturasPredefinidas_Click);
            // 
            // tpAperturasCierres
            // 
            this.tpAperturasCierres.Controls.Add(this.dgvListado);
            this.tpAperturasCierres.Location = new System.Drawing.Point(4, 28);
            this.tpAperturasCierres.Name = "tpAperturasCierres";
            this.tpAperturasCierres.Padding = new System.Windows.Forms.Padding(3);
            this.tpAperturasCierres.Size = new System.Drawing.Size(519, 232);
            this.tpAperturasCierres.TabIndex = 0;
            this.tpAperturasCierres.Text = "Aperturas/Cierres";
            this.tpAperturasCierres.UseVisualStyleBackColor = true;
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvListado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvListado.Location = new System.Drawing.Point(3, 3);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(513, 226);
            this.dgvListado.TabIndex = 5;
            this.dgvListado.Click += new System.EventHandler(this.dgvListado_Click);
            this.dgvListado.DoubleClick += new System.EventHandler(this.dgvListado_DoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnProgramarApertura);
            this.tabPage2.Controls.Add(this.btnAperturaPredefinida);
            this.tabPage2.Controls.Add(this.dgvListadoAperturasPredefinidas);
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(519, 232);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Aperturas predefinidas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnProgramarApertura
            // 
            this.btnProgramarApertura.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProgramarApertura.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnProgramarApertura.FlatAppearance.BorderSize = 0;
            this.btnProgramarApertura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProgramarApertura.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProgramarApertura.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProgramarApertura.Image = global::CapaPresentacion.Properties.Resources.add_to_list_hand_drawn_interface_symbol;
            this.btnProgramarApertura.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProgramarApertura.Location = new System.Drawing.Point(361, 3);
            this.btnProgramarApertura.Name = "btnProgramarApertura";
            this.btnProgramarApertura.Size = new System.Drawing.Size(155, 38);
            this.btnProgramarApertura.TabIndex = 9;
            this.btnProgramarApertura.Text = "&Programar apertura";
            this.btnProgramarApertura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProgramarApertura.UseVisualStyleBackColor = true;
            this.btnProgramarApertura.Click += new System.EventHandler(this.btnProgramarApertura_Click_1);
            // 
            // btnAperturaPredefinida
            // 
            this.btnAperturaPredefinida.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnAperturaPredefinida.FlatAppearance.BorderSize = 0;
            this.btnAperturaPredefinida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAperturaPredefinida.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAperturaPredefinida.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAperturaPredefinida.Image = global::CapaPresentacion.Properties.Resources.add_to_list_hand_drawn_interface_symbol;
            this.btnAperturaPredefinida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAperturaPredefinida.Location = new System.Drawing.Point(3, 3);
            this.btnAperturaPredefinida.Name = "btnAperturaPredefinida";
            this.btnAperturaPredefinida.Size = new System.Drawing.Size(201, 38);
            this.btnAperturaPredefinida.TabIndex = 8;
            this.btnAperturaPredefinida.Text = "&Nueva apertura predefinida";
            this.btnAperturaPredefinida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAperturaPredefinida.UseVisualStyleBackColor = true;
            this.btnAperturaPredefinida.Click += new System.EventHandler(this.btnProgramarApertura_Click);
            // 
            // dgvListadoAperturasPredefinidas
            // 
            this.dgvListadoAperturasPredefinidas.AllowUserToAddRows = false;
            this.dgvListadoAperturasPredefinidas.AllowUserToDeleteRows = false;
            this.dgvListadoAperturasPredefinidas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListadoAperturasPredefinidas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListadoAperturasPredefinidas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListadoAperturasPredefinidas.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListadoAperturasPredefinidas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListadoAperturasPredefinidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoAperturasPredefinidas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvListadoAperturasPredefinidas.Location = new System.Drawing.Point(3, 42);
            this.dgvListadoAperturasPredefinidas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListadoAperturasPredefinidas.Name = "dgvListadoAperturasPredefinidas";
            this.dgvListadoAperturasPredefinidas.ReadOnly = true;
            this.dgvListadoAperturasPredefinidas.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvListadoAperturasPredefinidas.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListadoAperturasPredefinidas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListadoAperturasPredefinidas.Size = new System.Drawing.Size(513, 187);
            this.dgvListadoAperturasPredefinidas.TabIndex = 7;
            this.dgvListadoAperturasPredefinidas.Click += new System.EventHandler(this.dgvListadoAperturasPredefinidas_Click);
            this.dgvListadoAperturasPredefinidas.DoubleClick += new System.EventHandler(this.dgvListadoAperturasPredefinidas_DoubleClick);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel3.Controls.Add(this.lblInfo, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnIngresarCierreCaja, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(290, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(527, 44);
            this.tableLayoutPanel3.TabIndex = 341;
            this.tableLayoutPanel3.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // dgvCajas
            // 
            this.dgvCajas.AllowUserToAddRows = false;
            this.dgvCajas.AllowUserToDeleteRows = false;
            this.dgvCajas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCajas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCajas.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCajas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvCajas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCajas.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvCajas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCajas.Location = new System.Drawing.Point(4, 55);
            this.dgvCajas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvCajas.Name = "dgvCajas";
            this.dgvCajas.ReadOnly = true;
            this.dgvCajas.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            this.dgvCajas.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvCajas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCajas.Size = new System.Drawing.Size(279, 260);
            this.dgvCajas.TabIndex = 3;
            this.dgvCajas.Click += new System.EventHandler(this.dgvCajas_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.Controls.Add(this.btnIngresarAperturaCaja, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(281, 44);
            this.tableLayoutPanel2.TabIndex = 340;
            this.tableLayoutPanel2.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tableLayoutPanel1_CellPaint);
            // 
            // frmAperturaCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 462);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "frmAperturaCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAperturaCierreCaja_FormClosing);
            this.Load += new System.EventHandler(this.frmAperturaCierreCaja_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tpAperturasPredefinidas.ResumeLayout(false);
            this.tpAperturasCierres.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoAperturasPredefinidas)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCajas)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        public System.Windows.Forms.Button btnIngresarAperturaCaja;
        private System.Windows.Forms.Label lblInfo;
        public System.Windows.Forms.Button btnIngresarCierreCaja;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvCajas;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.TabControl tpAperturasPredefinidas;
        private System.Windows.Forms.TabPage tpAperturasCierres;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvListadoAperturasPredefinidas;
        public System.Windows.Forms.Button btnAperturaPredefinida;
        public System.Windows.Forms.Button btnProgramarApertura;
    }
}