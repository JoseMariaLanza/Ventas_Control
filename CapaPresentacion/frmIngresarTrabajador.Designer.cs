namespace CapaPresentacion
{
    partial class frmIngresarTrabajador
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
            this.txtDomicilio = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.dtpFecha_Nacimiento = new System.Windows.Forms.DateTimePicker();
            this.txtNum_Documento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbSexo = new System.Windows.Forms.ComboBox();
            this.lblSexo = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtTel_Cel = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTel_Fijo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblTrabajador = new System.Windows.Forms.Label();
            this.txtIdTrabajador = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtApellido = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblApellido = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbAcceso = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUsuario = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtConfirmarPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblConfirmarPassword = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDomicilio
            // 
            this.txtDomicilio.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomicilio.Location = new System.Drawing.Point(12, 291);
            this.txtDomicilio.Name = "txtDomicilio";
            this.txtDomicilio.Size = new System.Drawing.Size(339, 54);
            this.txtDomicilio.TabIndex = 6;
            this.txtDomicilio.Text = "";
            this.txtDomicilio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDomicilio_KeyPress);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 19);
            this.label1.TabIndex = 307;
            this.label1.Text = "Fecha de nacimiento:";
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.Visible = true;
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
            // dtpFecha_Nacimiento
            // 
            this.dtpFecha_Nacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha_Nacimiento.Location = new System.Drawing.Point(157, 200);
            this.dtpFecha_Nacimiento.Name = "dtpFecha_Nacimiento";
            this.dtpFecha_Nacimiento.Size = new System.Drawing.Size(123, 20);
            this.dtpFecha_Nacimiento.TabIndex = 4;
            this.dtpFecha_Nacimiento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_Nacimiento_KeyPress);
            // 
            // txtNum_Documento
            // 
            this.txtNum_Documento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNum_Documento.Depth = 0;
            this.txtNum_Documento.Hint = "Nº de Documento";
            this.txtNum_Documento.Location = new System.Drawing.Point(157, 232);
            this.txtNum_Documento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNum_Documento.Name = "txtNum_Documento";
            this.txtNum_Documento.PasswordChar = '\0';
            this.txtNum_Documento.SelectedText = "";
            this.txtNum_Documento.SelectionLength = 0;
            this.txtNum_Documento.SelectionStart = 0;
            this.txtNum_Documento.Size = new System.Drawing.Size(194, 23);
            this.txtNum_Documento.TabIndex = 5;
            this.txtNum_Documento.UseSystemPasswordChar = false;
            this.txtNum_Documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNum_Documento_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 236);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(139, 19);
            this.label7.TabIndex = 306;
            this.label7.Text = "Número de documento:";
            // 
            // cmbSexo
            // 
            this.cmbSexo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbSexo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSexo.FormattingEnabled = true;
            this.cmbSexo.Items.AddRange(new object[] {
            "M",
            "F",
            "Otro"});
            this.cmbSexo.Location = new System.Drawing.Point(157, 167);
            this.cmbSexo.Name = "cmbSexo";
            this.cmbSexo.Size = new System.Drawing.Size(123, 21);
            this.cmbSexo.TabIndex = 3;
            this.cmbSexo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbSexo_KeyPress);
            // 
            // lblSexo
            // 
            this.lblSexo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSexo.AutoSize = true;
            this.lblSexo.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSexo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSexo.Location = new System.Drawing.Point(12, 169);
            this.lblSexo.Name = "lblSexo";
            this.lblSexo.Size = new System.Drawing.Size(37, 19);
            this.lblSexo.TabIndex = 305;
            this.lblSexo.Text = "Sexo:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(12, 410);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 19);
            this.label13.TabIndex = 303;
            this.label13.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Depth = 0;
            this.txtEmail.Hint = "e-mail";
            this.txtEmail.Location = new System.Drawing.Point(61, 406);
            this.txtEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PasswordChar = '\0';
            this.txtEmail.SelectedText = "";
            this.txtEmail.SelectionLength = 0;
            this.txtEmail.SelectionStart = 0;
            this.txtEmail.Size = new System.Drawing.Size(290, 23);
            this.txtEmail.TabIndex = 9;
            this.txtEmail.UseSystemPasswordChar = false;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // txtTel_Cel
            // 
            this.txtTel_Cel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel_Cel.Depth = 0;
            this.txtTel_Cel.Hint = "Tel. Celular";
            this.txtTel_Cel.Location = new System.Drawing.Point(195, 374);
            this.txtTel_Cel.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTel_Cel.Name = "txtTel_Cel";
            this.txtTel_Cel.PasswordChar = '\0';
            this.txtTel_Cel.SelectedText = "";
            this.txtTel_Cel.SelectionLength = 0;
            this.txtTel_Cel.SelectionStart = 0;
            this.txtTel_Cel.Size = new System.Drawing.Size(156, 23);
            this.txtTel_Cel.TabIndex = 8;
            this.txtTel_Cel.UseSystemPasswordChar = false;
            this.txtTel_Cel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_Cel_KeyPress);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(191, 352);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(98, 19);
            this.label12.TabIndex = 302;
            this.label12.Text = "Teléfono celular:";
            // 
            // txtTel_Fijo
            // 
            this.txtTel_Fijo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTel_Fijo.Depth = 0;
            this.txtTel_Fijo.Hint = "Tel. Fijo";
            this.txtTel_Fijo.Location = new System.Drawing.Point(12, 374);
            this.txtTel_Fijo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtTel_Fijo.Name = "txtTel_Fijo";
            this.txtTel_Fijo.PasswordChar = '\0';
            this.txtTel_Fijo.SelectedText = "";
            this.txtTel_Fijo.SelectionLength = 0;
            this.txtTel_Fijo.SelectionStart = 0;
            this.txtTel_Fijo.Size = new System.Drawing.Size(156, 23);
            this.txtTel_Fijo.TabIndex = 7;
            this.txtTel_Fijo.UseSystemPasswordChar = false;
            this.txtTel_Fijo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_Fijo_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(12, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 19);
            this.label10.TabIndex = 301;
            this.label10.Text = "Teléfono fijo:";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(12, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 19);
            this.label9.TabIndex = 300;
            this.label9.Text = "Domicilio:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Depth = 0;
            this.txtNombre.Hint = "Nombre";
            this.txtNombre.Location = new System.Drawing.Point(74, 102);
            this.txtNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PasswordChar = '\0';
            this.txtNombre.SelectedText = "";
            this.txtNombre.SelectionLength = 0;
            this.txtNombre.SelectionStart = 0;
            this.txtNombre.Size = new System.Drawing.Size(277, 23);
            this.txtNombre.TabIndex = 1;
            this.txtNombre.UseSystemPasswordChar = false;
            this.txtNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombre_KeyPress);
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNombre.Location = new System.Drawing.Point(12, 106);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 19);
            this.lblNombre.TabIndex = 298;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblTrabajador
            // 
            this.lblTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTrabajador.AutoSize = true;
            this.lblTrabajador.BackColor = System.Drawing.Color.Transparent;
            this.lblTrabajador.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTrabajador.ForeColor = System.Drawing.Color.White;
            this.lblTrabajador.Location = new System.Drawing.Point(70, 17);
            this.lblTrabajador.Name = "lblTrabajador";
            this.lblTrabajador.Size = new System.Drawing.Size(260, 47);
            this.lblTrabajador.TabIndex = 297;
            this.lblTrabajador.Text = "Nuevo trabajador";
            // 
            // txtIdTrabajador
            // 
            this.txtIdTrabajador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIdTrabajador.Depth = 0;
            this.txtIdTrabajador.Enabled = false;
            this.txtIdTrabajador.Hint = "";
            this.txtIdTrabajador.Location = new System.Drawing.Point(74, 72);
            this.txtIdTrabajador.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIdTrabajador.Name = "txtIdTrabajador";
            this.txtIdTrabajador.PasswordChar = '\0';
            this.txtIdTrabajador.SelectedText = "";
            this.txtIdTrabajador.SelectionLength = 0;
            this.txtIdTrabajador.SelectionStart = 0;
            this.txtIdTrabajador.Size = new System.Drawing.Size(60, 23);
            this.txtIdTrabajador.TabIndex = 296;
            this.txtIdTrabajador.UseSystemPasswordChar = false;
            // 
            // txtApellido
            // 
            this.txtApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellido.Depth = 0;
            this.txtApellido.Hint = "Apellido";
            this.txtApellido.Location = new System.Drawing.Point(74, 133);
            this.txtApellido.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.PasswordChar = '\0';
            this.txtApellido.SelectedText = "";
            this.txtApellido.SelectionLength = 0;
            this.txtApellido.SelectionStart = 0;
            this.txtApellido.Size = new System.Drawing.Size(277, 23);
            this.txtApellido.TabIndex = 2;
            this.txtApellido.UseSystemPasswordChar = false;
            this.txtApellido.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtApellido_KeyPress);
            // 
            // lblApellido
            // 
            this.lblApellido.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApellido.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblApellido.Location = new System.Drawing.Point(12, 137);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(56, 19);
            this.lblApellido.TabIndex = 295;
            this.lblApellido.Text = "Apellido:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 294;
            this.label5.Text = "Código:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 304;
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
            this.btnInsertar.Location = new System.Drawing.Point(280, 532);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(89, 35);
            this.btnInsertar.TabIndex = 14;
            this.btnInsertar.Text = "&Guardar";
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
            this.btnNuevo.Location = new System.Drawing.Point(12, 532);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(89, 35);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "&Nuevo";
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
            this.btnCancelar.Location = new System.Drawing.Point(12, 532);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 35);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "&Cancelar";
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
            this.btnEditar.Location = new System.Drawing.Point(280, 532);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 35);
            this.btnEditar.TabIndex = 15;
            this.btnEditar.Text = "&Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 442);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 19);
            this.label2.TabIndex = 308;
            this.label2.Text = "Acceso:";
            // 
            // cmbAcceso
            // 
            this.cmbAcceso.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAcceso.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAcceso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAcceso.FormattingEnabled = true;
            this.cmbAcceso.Items.AddRange(new object[] {
            "Administrador",
            "Encargado",
            "Vendedor"});
            this.cmbAcceso.Location = new System.Drawing.Point(12, 464);
            this.cmbAcceso.Name = "cmbAcceso";
            this.cmbAcceso.Size = new System.Drawing.Size(129, 21);
            this.cmbAcceso.TabIndex = 10;
            this.cmbAcceso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbAcceso_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(143, 440);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 19);
            this.label3.TabIndex = 310;
            this.label3.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsuario.Depth = 0;
            this.txtUsuario.Hint = "Usuario";
            this.txtUsuario.Location = new System.Drawing.Point(147, 462);
            this.txtUsuario.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.Size = new System.Drawing.Size(204, 23);
            this.txtUsuario.TabIndex = 11;
            this.txtUsuario.UseSystemPasswordChar = false;
            this.txtUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUsuario_KeyPress);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 488);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 19);
            this.label4.TabIndex = 312;
            this.label4.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Depth = 0;
            this.txtPassword.Hint = "Contraseña";
            this.txtPassword.Location = new System.Drawing.Point(12, 510);
            this.txtPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.Size = new System.Drawing.Size(166, 23);
            this.txtPassword.TabIndex = 12;
            this.txtPassword.UseSystemPasswordChar = true;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmarPassword.Depth = 0;
            this.txtConfirmarPassword.Hint = "Confirme contraseña";
            this.txtConfirmarPassword.Location = new System.Drawing.Point(184, 510);
            this.txtConfirmarPassword.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '\0';
            this.txtConfirmarPassword.SelectedText = "";
            this.txtConfirmarPassword.SelectionLength = 0;
            this.txtConfirmarPassword.SelectionStart = 0;
            this.txtConfirmarPassword.Size = new System.Drawing.Size(167, 23);
            this.txtConfirmarPassword.TabIndex = 13;
            this.txtConfirmarPassword.UseSystemPasswordChar = true;
            this.txtConfirmarPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConfirmarPassword_KeyPress);
            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmarPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblConfirmarPassword.Location = new System.Drawing.Point(180, 488);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new System.Drawing.Size(133, 19);
            this.lblConfirmarPassword.TabIndex = 315;
            this.lblConfirmarPassword.Text = "Confirmar contraseña:";
            this.lblConfirmarPassword.Visible = false;
            // 
            // frmIngresarTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 579);
            this.Controls.Add(this.lblConfirmarPassword);
            this.Controls.Add(this.txtConfirmarPassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbAcceso);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDomicilio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFecha_Nacimiento);
            this.Controls.Add(this.txtNum_Documento);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cmbSexo);
            this.Controls.Add(this.lblSexo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtTel_Cel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTel_Fijo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblTrabajador);
            this.Controls.Add(this.txtIdTrabajador);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresarTrabajador";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmIngresarTrabajador_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIngresarTrabajador_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtDomicilio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.DateTimePicker dtpFecha_Nacimiento;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtNum_Documento;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbSexo;
        private System.Windows.Forms.Label lblSexo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label13;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtEmail;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtTel_Cel;
        private System.Windows.Forms.Label label12;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtTel_Fijo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblTrabajador;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIdTrabajador;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ToolTip ttMensaje;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtPassword;
        private System.Windows.Forms.Label label4;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAcceso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblConfirmarPassword;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtConfirmarPassword;
    }
}