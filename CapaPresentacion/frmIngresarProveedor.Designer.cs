namespace CapaPresentacion
{
    partial class frmIngresarProveedor
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
            this.label14 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.RichTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTelefonoCelular = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label12 = new System.Windows.Forms.Label();
            this.rtxtDocmicilio = new System.Windows.Forms.RichTextBox();
            this.txtTelefonoFijo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkPersonaFisica = new MaterialSkin.Controls.MaterialCheckBox();
            this.txtNombres = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.txtIdProveedor = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtApellidos = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblApellido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNumeroDocumento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(12, 454);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(36, 19);
            this.label14.TabIndex = 240;
            this.label14.Text = "URL:";
            // 
            // txtURL
            // 
            this.txtURL.BackColor = System.Drawing.Color.White;
            this.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtURL.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtURL.Location = new System.Drawing.Point(12, 476);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(357, 56);
            this.txtURL.TabIndex = 10;
            this.txtURL.Text = "";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(12, 421);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 19);
            this.label13.TabIndex = 238;
            this.label13.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Depth = 0;
            this.txtEmail.Hint = "e-mail";
            this.txtEmail.Location = new System.Drawing.Point(61, 417);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(308, 23);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.UseSystemPasswordChar = false;
            // 
            // txtTelefonoCelular
            // 
            this.txtTelefonoCelular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefonoCelular.Depth = 0;
            this.txtTelefonoCelular.Hint = "Tel. Celular";
            this.txtTelefonoCelular.Location = new System.Drawing.Point(195, 385);
            this.txtTelefonoCelular.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTelefonoCelular.Name = "txtTelefonoCelular";
            this.txtTelefonoCelular.PasswordChar = '\0';
            this.txtTelefonoCelular.SelectedText = "";
            this.txtTelefonoCelular.SelectionLength = 0;
            this.txtTelefonoCelular.SelectionStart = 0;
            this.txtTelefonoCelular.Size = new System.Drawing.Size(174, 23);
            this.txtTelefonoCelular.TabIndex = 8;
            this.txtTelefonoCelular.UseSystemPasswordChar = false;
            this.txtTelefonoCelular.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefonoCelular_KeyPress);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(191, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 19);
            this.label12.TabIndex = 235;
            this.label12.Text = "Teléfono celular:";
            // 
            // rtxtDocmicilio
            // 
            this.rtxtDocmicilio.BackColor = System.Drawing.Color.White;
            this.rtxtDocmicilio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtDocmicilio.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtxtDocmicilio.Location = new System.Drawing.Point(12, 302);
            this.rtxtDocmicilio.Name = "rtxtDocmicilio";
            this.rtxtDocmicilio.Size = new System.Drawing.Size(357, 49);
            this.rtxtDocmicilio.TabIndex = 6;
            this.rtxtDocmicilio.Text = "";
            // 
            // txtTelefonoFijo
            // 
            this.txtTelefonoFijo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelefonoFijo.Depth = 0;
            this.txtTelefonoFijo.Hint = "Tel. Fijo";
            this.txtTelefonoFijo.Location = new System.Drawing.Point(12, 385);
            this.txtTelefonoFijo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTelefonoFijo.Name = "txtTelefonoFijo";
            this.txtTelefonoFijo.PasswordChar = '\0';
            this.txtTelefonoFijo.SelectedText = "";
            this.txtTelefonoFijo.SelectionLength = 0;
            this.txtTelefonoFijo.SelectionStart = 0;
            this.txtTelefonoFijo.Size = new System.Drawing.Size(177, 23);
            this.txtTelefonoFijo.TabIndex = 7;
            this.txtTelefonoFijo.UseSystemPasswordChar = false;
            this.txtTelefonoFijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefonoFijo_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(12, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 19);
            this.label10.TabIndex = 232;
            this.label10.Text = "Teléfono fijo:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(12, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 19);
            this.label9.TabIndex = 230;
            this.label9.Text = "Domicilio:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 214);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 225;
            this.label3.Text = "Tipo de documento:";
            // 
            // chkPersonaFisica
            // 
            this.chkPersonaFisica.AutoSize = true;
            this.chkPersonaFisica.Depth = 0;
            this.chkPersonaFisica.Enabled = false;
            this.chkPersonaFisica.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkPersonaFisica.Location = new System.Drawing.Point(195, 84);
            this.chkPersonaFisica.Margin = new System.Windows.Forms.Padding(0);
            this.chkPersonaFisica.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkPersonaFisica.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkPersonaFisica.Name = "chkPersonaFisica";
            this.chkPersonaFisica.Ripple = true;
            this.chkPersonaFisica.Size = new System.Drawing.Size(118, 30);
            this.chkPersonaFisica.TabIndex = 212;
            this.chkPersonaFisica.Text = "Persona física";
            this.chkPersonaFisica.UseVisualStyleBackColor = true;
            this.chkPersonaFisica.CheckedChanged += new System.EventHandler(this.chkPersonaFisica_CheckedChanged);
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombres.Depth = 0;
            this.txtNombres.Hint = "Razón social";
            this.txtNombres.Location = new System.Drawing.Point(96, 117);
            this.txtNombres.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.PasswordChar = '\0';
            this.txtNombres.SelectedText = "";
            this.txtNombres.SelectionLength = 0;
            this.txtNombres.SelectionStart = 0;
            this.txtNombres.Size = new System.Drawing.Size(255, 23);
            this.txtNombres.TabIndex = 1;
            this.txtNombres.UseSystemPasswordChar = false;
            // 
            // lblNombres
            // 
            this.lblNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombres.AutoSize = true;
            this.lblNombres.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombres.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNombres.Location = new System.Drawing.Point(12, 121);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(80, 19);
            this.lblNombres.TabIndex = 222;
            this.lblNombres.Text = "Razón Social:";
            // 
            // lblProveedor
            // 
            this.lblProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.BackColor = System.Drawing.Color.Transparent;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProveedor.ForeColor = System.Drawing.Color.White;
            this.lblProveedor.Location = new System.Drawing.Point(70, 17);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(249, 47);
            this.lblProveedor.TabIndex = 221;
            this.lblProveedor.Text = "Nuevo proveedor";
            // 
            // txtIdProveedor
            // 
            this.txtIdProveedor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdProveedor.Depth = 0;
            this.txtIdProveedor.Enabled = false;
            this.txtIdProveedor.Hint = "";
            this.txtIdProveedor.Location = new System.Drawing.Point(66, 87);
            this.txtIdProveedor.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIdProveedor.Name = "txtIdProveedor";
            this.txtIdProveedor.PasswordChar = '\0';
            this.txtIdProveedor.SelectedText = "";
            this.txtIdProveedor.SelectionLength = 0;
            this.txtIdProveedor.SelectionStart = 0;
            this.txtIdProveedor.Size = new System.Drawing.Size(60, 23);
            this.txtIdProveedor.TabIndex = 220;
            this.txtIdProveedor.UseSystemPasswordChar = false;
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellidos.Depth = 0;
            this.txtApellidos.Hint = "Apellido";
            this.txtApellidos.Location = new System.Drawing.Point(96, 148);
            this.txtApellidos.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.PasswordChar = '\0';
            this.txtApellidos.SelectedText = "";
            this.txtApellidos.SelectionLength = 0;
            this.txtApellidos.SelectionStart = 0;
            this.txtApellidos.Size = new System.Drawing.Size(255, 23);
            this.txtApellidos.TabIndex = 2;
            this.txtApellidos.UseSystemPasswordChar = false;
            this.txtApellidos.Visible = false;
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblApellido.Location = new System.Drawing.Point(12, 152);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(56, 19);
            this.lblApellido.TabIndex = 219;
            this.lblApellido.Text = "Apellido:";
            this.lblApellido.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 218;
            this.label5.Text = "Código:";
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTipoDocumento.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Items.AddRange(new object[] {
            "DNI",
            "CUIL",
            "CUIT"});
            this.cmbTipoDocumento.Location = new System.Drawing.Point(157, 212);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(123, 21);
            this.cmbTipoDocumento.TabIndex = 4;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // ttMensaje
            // 
            this.ttMensaje.AutoPopDelay = 2000;
            this.ttMensaje.InitialDelay = 100;
            this.ttMensaje.IsBalloon = true;
            this.ttMensaje.ReshowDelay = 10;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.Visible = true;
            // 
            // cmbRubro
            // 
            this.cmbRubro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRubro.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Items.AddRange(new object[] {
            "Varios",
            "Salud",
            "Alimentos",
            "Bebidas",
            "Golosinas",
            "Tecnología",
            "Indumentaria",
            "Servicios",
            "Otro"});
            this.cmbRubro.Location = new System.Drawing.Point(157, 182);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(123, 21);
            this.cmbRubro.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(12, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 19);
            this.label8.TabIndex = 244;
            this.label8.Text = "Rubro:";
            // 
            // txtNumeroDocumento
            // 
            this.txtNumeroDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumeroDocumento.Depth = 0;
            this.txtNumeroDocumento.Hint = "Nº de Documento";
            this.txtNumeroDocumento.Location = new System.Drawing.Point(157, 243);
            this.txtNumeroDocumento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNumeroDocumento.Name = "txtNumeroDocumento";
            this.txtNumeroDocumento.PasswordChar = '\0';
            this.txtNumeroDocumento.SelectedText = "";
            this.txtNumeroDocumento.SelectionLength = 0;
            this.txtNumeroDocumento.SelectionStart = 0;
            this.txtNumeroDocumento.Size = new System.Drawing.Size(194, 23);
            this.txtNumeroDocumento.TabIndex = 5;
            this.txtNumeroDocumento.UseSystemPasswordChar = false;
            this.txtNumeroDocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroDocumento_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 19);
            this.label7.TabIndex = 247;
            this.label7.Text = "Número de documento:";
            // 
            // elementHost1
            // 
            this.elementHost1.Location = new System.Drawing.Point(0, 0);
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Size = new System.Drawing.Size(200, 100);
            this.elementHost1.TabIndex = 0;
            this.elementHost1.Text = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 241;
            this.pictureBox1.TabStop = false;
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
            this.btnInsertar.Location = new System.Drawing.Point(280, 530);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(89, 35);
            this.btnInsertar.TabIndex = 12;
            this.btnInsertar.Text = "Guardar";
            this.btnInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
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
            this.btnNuevo.Location = new System.Drawing.Point(12, 530);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(89, 35);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.arrows_2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(12, 530);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 35);
            this.btnCancelar.TabIndex = 13;
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
            this.btnEditar.Location = new System.Drawing.Point(280, 530);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 35);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // frmIngresarProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 577);
            this.Controls.Add(this.txtNumeroDocumento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTelefonoCelular);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.rtxtDocmicilio);
            this.Controls.Add(this.txtTelefonoFijo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkPersonaFisica);
            this.Controls.Add(this.txtNombres);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.lblProveedor);
            this.Controls.Add(this.txtIdProveedor);
            this.Controls.Add(this.txtApellidos);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresarProveedor";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmIngresarProveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RichTextBox txtURL;
        private System.Windows.Forms.Label label13;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtTelefonoCelular;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox rtxtDocmicilio;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtTelefonoFijo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombres;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblProveedor;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIdProveedor;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtApellidos;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        public MaterialSkin.Controls.MaterialCheckBox chkPersonaFisica;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.Label label8;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtNumeroDocumento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}