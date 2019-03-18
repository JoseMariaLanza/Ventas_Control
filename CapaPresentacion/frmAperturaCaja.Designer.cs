namespace CapaPresentacion
{
    partial class frmAperturaCaja
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
            this.lblApertura = new System.Windows.Forms.Label();
            this.dtpFechaHoraApertura = new System.Windows.Forms.DateTimePicker();
            this.cmbCaja = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDenominacion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFormaCobro = new System.Windows.Forms.ComboBox();
            this.txtMontoInicial = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.tFechaHora = new System.Windows.Forms.Timer(this.components);
            this.lblCajero = new System.Windows.Forms.Label();
            this.txtEmpleado = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblFechaHoraApertura = new System.Windows.Forms.Label();
            this.txtEstado = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblEstado = new System.Windows.Forms.Label();
            this.chkAperturaPorDefecto = new MaterialSkin.Controls.MaterialCheckBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // lblApertura
            // 
            this.lblApertura.AutoSize = true;
            this.lblApertura.BackColor = System.Drawing.Color.Transparent;
            this.lblApertura.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApertura.ForeColor = System.Drawing.Color.Black;
            this.lblApertura.Location = new System.Drawing.Point(91, 16);
            this.lblApertura.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblApertura.Name = "lblApertura";
            this.lblApertura.Size = new System.Drawing.Size(145, 47);
            this.lblApertura.TabIndex = 328;
            this.lblApertura.Text = "Apertura";
            // 
            // dtpFechaHoraApertura
            // 
            this.dtpFechaHoraApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHoraApertura.Location = new System.Drawing.Point(475, 32);
            this.dtpFechaHoraApertura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaHoraApertura.Name = "dtpFechaHoraApertura";
            this.dtpFechaHoraApertura.Size = new System.Drawing.Size(197, 27);
            this.dtpFechaHoraApertura.TabIndex = 332;
            // 
            // cmbCaja
            // 
            this.cmbCaja.Enabled = false;
            this.cmbCaja.FormattingEnabled = true;
            this.cmbCaja.Location = new System.Drawing.Point(272, 32);
            this.cmbCaja.Name = "cmbCaja";
            this.cmbCaja.Size = new System.Drawing.Size(177, 27);
            this.cmbCaja.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(272, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 19);
            this.label5.TabIndex = 337;
            this.label5.Text = "Caja:";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::CapaPresentacion.Properties.Resources.open_wallet;
            this.pictureBox2.Location = new System.Drawing.Point(14, 16);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(64, 64);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 329;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.nudCantidad);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbDenominacion);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbMoneda);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbFormaCobro);
            this.groupBox2.Controls.Add(this.txtMontoInicial);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnIngresar);
            this.groupBox2.Controls.Add(this.dgvListado);
            this.groupBox2.Controls.Add(this.btnEliminar);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(660, 211);
            this.groupBox2.TabIndex = 343;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalles";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 19);
            this.label7.TabIndex = 350;
            this.label7.Text = "Cantidad:";
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(101, 128);
            this.nudCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(126, 27);
            this.nudCantidad.TabIndex = 3;
            this.nudCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 348;
            this.label4.Text = "Denominación:";
            // 
            // cmbDenominacion
            // 
            this.cmbDenominacion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDenominacion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDenominacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDenominacion.FormattingEnabled = true;
            this.cmbDenominacion.Items.AddRange(new object[] {
            "$0,05",
            "$0,10",
            "$0,25",
            "$0,50",
            "$1",
            "$2",
            "$5",
            "$10",
            "$20",
            "$50",
            "$100",
            "$200",
            "$500",
            "$1000"});
            this.cmbDenominacion.Location = new System.Drawing.Point(101, 94);
            this.cmbDenominacion.Name = "cmbDenominacion";
            this.cmbDenominacion.Size = new System.Drawing.Size(126, 27);
            this.cmbDenominacion.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 346;
            this.label3.Text = "Moneda:";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbMoneda.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbMoneda.Enabled = false;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] {
            "Pesos",
            "Dólares",
            "Euros"});
            this.cmbMoneda.Location = new System.Drawing.Point(66, 61);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(161, 27);
            this.cmbMoneda.TabIndex = 345;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 19);
            this.label2.TabIndex = 344;
            this.label2.Text = "Cobro:";
            // 
            // cmbFormaCobro
            // 
            this.cmbFormaCobro.Enabled = false;
            this.cmbFormaCobro.FormattingEnabled = true;
            this.cmbFormaCobro.Items.AddRange(new object[] {
            "Efectivo",
            "Cheques",
            "Tarjetas",
            "Todos"});
            this.cmbFormaCobro.Location = new System.Drawing.Point(66, 28);
            this.cmbFormaCobro.Name = "cmbFormaCobro";
            this.cmbFormaCobro.Size = new System.Drawing.Size(161, 27);
            this.cmbFormaCobro.TabIndex = 343;
            // 
            // txtMontoInicial
            // 
            this.txtMontoInicial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMontoInicial.Depth = 0;
            this.txtMontoInicial.Enabled = false;
            this.txtMontoInicial.Hint = "";
            this.txtMontoInicial.Location = new System.Drawing.Point(527, 182);
            this.txtMontoInicial.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMontoInicial.Name = "txtMontoInicial";
            this.txtMontoInicial.PasswordChar = '\0';
            this.txtMontoInicial.SelectedText = "";
            this.txtMontoInicial.SelectionLength = 0;
            this.txtMontoInicial.SelectionStart = 0;
            this.txtMontoInicial.Size = new System.Drawing.Size(127, 23);
            this.txtMontoInicial.TabIndex = 341;
            this.txtMontoInicial.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(418, 186);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 19);
            this.label1.TabIndex = 340;
            this.label1.Text = "Total Monto Inicial:";
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngresar.Image = global::CapaPresentacion.Properties.Resources.paper;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(137, 172);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(90, 33);
            this.btnIngresar.TabIndex = 4;
            this.btnIngresar.Text = "&Agregar";
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgvListado.Location = new System.Drawing.Point(234, 28);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(69)))), ((int)(((byte)(79)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(419, 146);
            this.dgvListado.TabIndex = 5;
            this.dgvListado.Enter += new System.EventHandler(this.dgvListado_Enter);
            this.dgvListado.Leave += new System.EventHandler(this.dgvListado_Leave);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.circle;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(234, 172);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 33);
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "&Quitar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnSalir.Location = new System.Drawing.Point(582, 321);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(90, 33);
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
            this.btnImprimir.Location = new System.Drawing.Point(245, 321);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(90, 33);
            this.btnImprimir.TabIndex = 9;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.Text = "notifyIcon1";
            this.iconoNotificacion.Visible = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.arrows_2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(11, 321);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 33);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.editing;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(148, 321);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 33);
            this.btnEditar.TabIndex = 347;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Visible = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.add_to_list_hand_drawn_interface_symbol;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(11, 321);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 33);
            this.btnNuevo.TabIndex = 348;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertar.BackColor = System.Drawing.Color.White;
            this.btnInsertar.FlatAppearance.BorderSize = 0;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInsertar.Image = global::CapaPresentacion.Properties.Resources.symbols_1;
            this.btnInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertar.Location = new System.Drawing.Point(148, 321);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(90, 33);
            this.btnInsertar.TabIndex = 7;
            this.btnInsertar.Text = "Guardar";
            this.btnInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Visible = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // tFechaHora
            // 
            this.tFechaHora.Enabled = true;
            this.tFechaHora.Tick += new System.EventHandler(this.tFechaHora_Tick);
            // 
            // lblCajero
            // 
            this.lblCajero.AutoSize = true;
            this.lblCajero.Location = new System.Drawing.Point(356, 62);
            this.lblCajero.Name = "lblCajero";
            this.lblCajero.Size = new System.Drawing.Size(48, 19);
            this.lblCajero.TabIndex = 338;
            this.lblCajero.Text = "Cajero:";
            this.lblCajero.Visible = false;
            // 
            // txtEmpleado
            // 
            this.txtEmpleado.Depth = 0;
            this.txtEmpleado.Enabled = false;
            this.txtEmpleado.Hint = "";
            this.txtEmpleado.Location = new System.Drawing.Point(360, 84);
            this.txtEmpleado.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmpleado.Name = "txtEmpleado";
            this.txtEmpleado.PasswordChar = '\0';
            this.txtEmpleado.SelectedText = "";
            this.txtEmpleado.SelectionLength = 0;
            this.txtEmpleado.SelectionStart = 0;
            this.txtEmpleado.Size = new System.Drawing.Size(312, 23);
            this.txtEmpleado.TabIndex = 339;
            this.txtEmpleado.UseSystemPasswordChar = false;
            this.txtEmpleado.Visible = false;
            // 
            // lblFechaHoraApertura
            // 
            this.lblFechaHoraApertura.AutoSize = true;
            this.lblFechaHoraApertura.Location = new System.Drawing.Point(471, 9);
            this.lblFechaHoraApertura.Name = "lblFechaHoraApertura";
            this.lblFechaHoraApertura.Size = new System.Drawing.Size(154, 19);
            this.lblFechaHoraApertura.TabIndex = 350;
            this.lblFechaHoraApertura.Text = "Fecha y hora de apertura:";
            // 
            // txtEstado
            // 
            this.txtEstado.Depth = 0;
            this.txtEstado.Enabled = false;
            this.txtEstado.Hint = "";
            this.txtEstado.Location = new System.Drawing.Point(272, 84);
            this.txtEstado.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.PasswordChar = '\0';
            this.txtEstado.SelectedText = "";
            this.txtEstado.SelectionLength = 0;
            this.txtEstado.SelectionStart = 0;
            this.txtEstado.Size = new System.Drawing.Size(82, 23);
            this.txtEstado.TabIndex = 352;
            this.txtEstado.UseSystemPasswordChar = false;
            this.txtEstado.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(272, 62);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(49, 19);
            this.lblEstado.TabIndex = 351;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Visible = false;
            // 
            // chkAperturaPorDefecto
            // 
            this.chkAperturaPorDefecto.AutoSize = true;
            this.chkAperturaPorDefecto.Depth = 0;
            this.chkAperturaPorDefecto.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkAperturaPorDefecto.Location = new System.Drawing.Point(338, 327);
            this.chkAperturaPorDefecto.Margin = new System.Windows.Forms.Padding(0);
            this.chkAperturaPorDefecto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkAperturaPorDefecto.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkAperturaPorDefecto.Name = "chkAperturaPorDefecto";
            this.chkAperturaPorDefecto.Ripple = true;
            this.chkAperturaPorDefecto.Size = new System.Drawing.Size(169, 30);
            this.chkAperturaPorDefecto.TabIndex = 353;
            this.chkAperturaPorDefecto.Text = "Establecer por defecto";
            this.chkAperturaPorDefecto.UseVisualStyleBackColor = true;
            this.chkAperturaPorDefecto.Visible = false;
            this.chkAperturaPorDefecto.CheckedChanged += new System.EventHandler(this.chkAperturaAutomatica_CheckedChanged);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(354, 65);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescripcion.Size = new System.Drawing.Size(318, 50);
            this.txtDescripcion.TabIndex = 354;
            this.txtDescripcion.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(272, 65);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(76, 19);
            this.lblDescripcion.TabIndex = 355;
            this.lblDescripcion.Text = "Descripción:";
            this.lblDescripcion.Visible = false;
            // 
            // frmAperturaCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 366);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.chkAperturaPorDefecto);
            this.Controls.Add(this.txtEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblFechaHoraApertura);
            this.Controls.Add(this.txtEmpleado);
            this.Controls.Add(this.cmbCaja);
            this.Controls.Add(this.lblCajero);
            this.Controls.Add(this.dtpFechaHoraApertura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lblApertura);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnEditar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAperturaCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAperturaCaja_FormClosing);
            this.Load += new System.EventHandler(this.frmAperturaCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblApertura;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dtpFechaHoraApertura;
        private System.Windows.Forms.ComboBox cmbCaja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.Button btnIngresar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMontoInicial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDenominacion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFormaCobro;
        private System.Windows.Forms.Timer tFechaHora;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEmpleado;
        private System.Windows.Forms.Label lblCajero;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblFechaHoraApertura;
        private MaterialSkin.Controls.MaterialCheckBox chkAperturaPorDefecto;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        public System.Windows.Forms.DataGridView dgvListado;
    }
}