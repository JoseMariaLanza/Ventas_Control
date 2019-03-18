namespace CapaPresentacion
{
    partial class frmIngresarArticulo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngresarArticulo));
            this.lblABMProducto = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtStock = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPrecioVenta = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtPrecioCompra = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.RichTextBox();
            this.btnAgregarPresentacion = new System.Windows.Forms.Button();
            this.btnAgregarCategoria = new System.Windows.Forms.Button();
            this.cmbPresentacion = new System.Windows.Forms.ComboBox();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.btnQuitarImagen = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCodigoBarras = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.txtIdArticulo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtArticulo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.lblPresentacion = new System.Windows.Forms.Label();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.chkEditarStock = new MaterialSkin.Controls.MaterialCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // lblABMProducto
            // 
            this.lblABMProducto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblABMProducto.AutoSize = true;
            this.lblABMProducto.BackColor = System.Drawing.Color.Transparent;
            this.lblABMProducto.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblABMProducto.ForeColor = System.Drawing.Color.Transparent;
            this.lblABMProducto.Location = new System.Drawing.Point(70, 17);
            this.lblABMProducto.Name = "lblABMProducto";
            this.lblABMProducto.Size = new System.Drawing.Size(217, 47);
            this.lblABMProducto.TabIndex = 104;
            this.lblABMProducto.Text = "Nuevo artículo";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 242;
            this.pictureBox1.TabStop = false;
            // 
            // txtStock
            // 
            this.txtStock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtStock.Depth = 0;
            this.txtStock.Enabled = false;
            this.txtStock.Hint = "";
            this.txtStock.Location = new System.Drawing.Point(256, 232);
            this.txtStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtStock.Name = "txtStock";
            this.txtStock.PasswordChar = '\0';
            this.txtStock.SelectedText = "";
            this.txtStock.SelectionLength = 0;
            this.txtStock.SelectionStart = 0;
            this.txtStock.Size = new System.Drawing.Size(79, 23);
            this.txtStock.TabIndex = 376;
            this.txtStock.Text = "0";
            this.txtStock.UseSystemPasswordChar = false;
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrecioVenta.Depth = 0;
            this.txtPrecioVenta.Enabled = false;
            this.txtPrecioVenta.Hint = "";
            this.txtPrecioVenta.Location = new System.Drawing.Point(112, 232);
            this.txtPrecioVenta.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.PasswordChar = '\0';
            this.txtPrecioVenta.SelectedText = "";
            this.txtPrecioVenta.SelectionLength = 0;
            this.txtPrecioVenta.SelectionStart = 0;
            this.txtPrecioVenta.Size = new System.Drawing.Size(90, 23);
            this.txtPrecioVenta.TabIndex = 8;
            this.txtPrecioVenta.Text = "0.00";
            this.txtPrecioVenta.UseSystemPasswordChar = false;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // txtPrecioCompra
            // 
            this.txtPrecioCompra.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrecioCompra.Depth = 0;
            this.txtPrecioCompra.Enabled = false;
            this.txtPrecioCompra.Hint = "";
            this.txtPrecioCompra.Location = new System.Drawing.Point(16, 232);
            this.txtPrecioCompra.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrecioCompra.Name = "txtPrecioCompra";
            this.txtPrecioCompra.PasswordChar = '\0';
            this.txtPrecioCompra.SelectedText = "";
            this.txtPrecioCompra.SelectionLength = 0;
            this.txtPrecioCompra.SelectionStart = 0;
            this.txtPrecioCompra.Size = new System.Drawing.Size(90, 23);
            this.txtPrecioCompra.TabIndex = 7;
            this.txtPrecioCompra.Text = "0.00";
            this.txtPrecioCompra.UseSystemPasswordChar = false;
            this.txtPrecioCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioCompra_KeyPress);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(208, 232);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 19);
            this.label10.TabIndex = 373;
            this.label10.Text = "Stock:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(108, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 372;
            this.label2.Text = "$ Venta:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 210);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 371;
            this.label1.Text = "$ Compra:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(16, 283);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(257, 128);
            this.txtDescripcion.TabIndex = 9;
            this.txtDescripcion.Text = "";
            // 
            // btnAgregarPresentacion
            // 
            this.btnAgregarPresentacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarPresentacion.BackColor = System.Drawing.Color.White;
            this.btnAgregarPresentacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarPresentacion.BackgroundImage")));
            this.btnAgregarPresentacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarPresentacion.FlatAppearance.BorderSize = 0;
            this.btnAgregarPresentacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPresentacion.Location = new System.Drawing.Point(302, 179);
            this.btnAgregarPresentacion.Name = "btnAgregarPresentacion";
            this.btnAgregarPresentacion.Size = new System.Drawing.Size(24, 23);
            this.btnAgregarPresentacion.TabIndex = 6;
            this.btnAgregarPresentacion.UseVisualStyleBackColor = false;
            this.btnAgregarPresentacion.Click += new System.EventHandler(this.btnAgregarPresentacion_Click);
            // 
            // btnAgregarCategoria
            // 
            this.btnAgregarCategoria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarCategoria.BackColor = System.Drawing.Color.White;
            this.btnAgregarCategoria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAgregarCategoria.BackgroundImage")));
            this.btnAgregarCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarCategoria.FlatAppearance.BorderSize = 0;
            this.btnAgregarCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCategoria.Location = new System.Drawing.Point(158, 181);
            this.btnAgregarCategoria.Name = "btnAgregarCategoria";
            this.btnAgregarCategoria.Size = new System.Drawing.Size(24, 23);
            this.btnAgregarCategoria.TabIndex = 4;
            this.btnAgregarCategoria.UseVisualStyleBackColor = false;
            this.btnAgregarCategoria.Click += new System.EventHandler(this.btnAgregarCategoria_Click);
            // 
            // cmbPresentacion
            // 
            this.cmbPresentacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbPresentacion.FormattingEnabled = true;
            this.cmbPresentacion.Location = new System.Drawing.Point(234, 181);
            this.cmbPresentacion.Name = "cmbPresentacion";
            this.cmbPresentacion.Size = new System.Drawing.Size(62, 21);
            this.cmbPresentacion.TabIndex = 5;
            this.cmbPresentacion.TextChanged += new System.EventHandler(this.cmbPresentacion_TextChanged);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAgregarImagen.BackColor = System.Drawing.Color.White;
            this.btnAgregarImagen.BackgroundImage = global::CapaPresentacion.Properties.Resources.add_image;
            this.btnAgregarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarImagen.Enabled = false;
            this.btnAgregarImagen.FlatAppearance.BorderSize = 0;
            this.btnAgregarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarImagen.Location = new System.Drawing.Point(279, 376);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(35, 35);
            this.btnAgregarImagen.TabIndex = 10;
            this.btnAgregarImagen.UseVisualStyleBackColor = false;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // btnQuitarImagen
            // 
            this.btnQuitarImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuitarImagen.BackColor = System.Drawing.Color.White;
            this.btnQuitarImagen.BackgroundImage = global::CapaPresentacion.Properties.Resources.image;
            this.btnQuitarImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitarImagen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuitarImagen.Enabled = false;
            this.btnQuitarImagen.FlatAppearance.BorderSize = 0;
            this.btnQuitarImagen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitarImagen.Location = new System.Drawing.Point(331, 376);
            this.btnQuitarImagen.Name = "btnQuitarImagen";
            this.btnQuitarImagen.Size = new System.Drawing.Size(35, 35);
            this.btnQuitarImagen.TabIndex = 11;
            this.btnQuitarImagen.UseVisualStyleBackColor = false;
            this.btnQuitarImagen.Click += new System.EventHandler(this.btnQuitarImagen_Click);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(276, 261);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 19);
            this.label9.TabIndex = 370;
            this.label9.Text = "Imagen:";
            // 
            // pbxImagen
            // 
            this.pbxImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxImagen.Location = new System.Drawing.Point(279, 283);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(87, 87);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxImagen.TabIndex = 369;
            this.pbxImagen.TabStop = false;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(16, 181);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(136, 21);
            this.cmbCategoria.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(230, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 19);
            this.label8.TabIndex = 368;
            this.label8.Text = "Presentación:";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 19);
            this.label7.TabIndex = 367;
            this.label7.Text = "Categoría:";
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCodigoBarras.Depth = 0;
            this.txtCodigoBarras.Hint = "Código de barras";
            this.txtCodigoBarras.Location = new System.Drawing.Point(122, 99);
            this.txtCodigoBarras.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.PasswordChar = '\0';
            this.txtCodigoBarras.SelectedText = "";
            this.txtCodigoBarras.SelectionLength = 0;
            this.txtCodigoBarras.SelectionStart = 0;
            this.txtCodigoBarras.Size = new System.Drawing.Size(232, 23);
            this.txtCodigoBarras.TabIndex = 1;
            this.txtCodigoBarras.UseSystemPasswordChar = false;
            this.txtCodigoBarras.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoBarras_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 366;
            this.label6.Text = "Código de barras:";
            // 
            // txtIdArticulo
            // 
            this.txtIdArticulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtIdArticulo.Depth = 0;
            this.txtIdArticulo.Enabled = false;
            this.txtIdArticulo.Hint = "";
            this.txtIdArticulo.Location = new System.Drawing.Point(122, 70);
            this.txtIdArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIdArticulo.Name = "txtIdArticulo";
            this.txtIdArticulo.PasswordChar = '\0';
            this.txtIdArticulo.SelectedText = "";
            this.txtIdArticulo.SelectionLength = 0;
            this.txtIdArticulo.SelectionStart = 0;
            this.txtIdArticulo.Size = new System.Drawing.Size(60, 23);
            this.txtIdArticulo.TabIndex = 365;
            this.txtIdArticulo.UseSystemPasswordChar = false;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtArticulo.Depth = 0;
            this.txtArticulo.Hint = "Nombre del artículo";
            this.txtArticulo.Location = new System.Drawing.Point(122, 128);
            this.txtArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.PasswordChar = '\0';
            this.txtArticulo.SelectedText = "";
            this.txtArticulo.SelectionLength = 0;
            this.txtArticulo.SelectionStart = 0;
            this.txtArticulo.Size = new System.Drawing.Size(232, 23);
            this.txtArticulo.TabIndex = 2;
            this.txtArticulo.UseSystemPasswordChar = false;
            this.txtArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtArticulo_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 261);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 364;
            this.label3.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 19);
            this.label4.TabIndex = 363;
            this.label4.Text = "Nombre artículo:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 362;
            this.label5.Text = "Código artículo:";
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnInsertar.BackColor = System.Drawing.Color.White;
            this.btnInsertar.FlatAppearance.BorderSize = 0;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInsertar.Image = global::CapaPresentacion.Properties.Resources.symbols_1;
            this.btnInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertar.Location = new System.Drawing.Point(280, 417);
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
            this.btnNuevo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNuevo.BackColor = System.Drawing.Color.White;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNuevo.Image = global::CapaPresentacion.Properties.Resources.add_to_list_hand_drawn_interface_symbol;
            this.btnNuevo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new System.Drawing.Point(12, 417);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(89, 35);
            this.btnNuevo.TabIndex = 359;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Visible = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.arrows_2;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(12, 417);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 35);
            this.btnCancelar.TabIndex = 361;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.editing;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(280, 417);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 35);
            this.btnEditar.TabIndex = 360;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // lblPresentacion
            // 
            this.lblPresentacion.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPresentacion.AutoSize = true;
            this.lblPresentacion.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresentacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblPresentacion.Location = new System.Drawing.Point(341, 232);
            this.lblPresentacion.Name = "lblPresentacion";
            this.lblPresentacion.Size = new System.Drawing.Size(0, 19);
            this.lblPresentacion.TabIndex = 377;
            // 
            // errorIcono
            // 
            this.errorIcono.ContainerControl = this;
            // 
            // iconoNotificacion
            // 
            this.iconoNotificacion.Visible = true;
            // 
            // chkEditarStock
            // 
            this.chkEditarStock.AutoSize = true;
            this.chkEditarStock.Depth = 0;
            this.chkEditarStock.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkEditarStock.Location = new System.Drawing.Point(223, 202);
            this.chkEditarStock.Margin = new System.Windows.Forms.Padding(0);
            this.chkEditarStock.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkEditarStock.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkEditarStock.Name = "chkEditarStock";
            this.chkEditarStock.Ripple = true;
            this.chkEditarStock.Size = new System.Drawing.Size(103, 30);
            this.chkEditarStock.TabIndex = 378;
            this.chkEditarStock.Text = "Editar stock";
            this.chkEditarStock.UseVisualStyleBackColor = true;
            this.chkEditarStock.CheckedChanged += new System.EventHandler(this.chkEditarStock_CheckedChanged);
            // 
            // frmIngresarArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 464);
            this.Controls.Add(this.chkEditarStock);
            this.Controls.Add(this.lblPresentacion);
            this.Controls.Add(this.txtStock);
            this.Controls.Add(this.txtPrecioVenta);
            this.Controls.Add(this.txtPrecioCompra);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.btnAgregarPresentacion);
            this.Controls.Add(this.btnAgregarCategoria);
            this.Controls.Add(this.cmbPresentacion);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.btnQuitarImagen);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pbxImagen);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCodigoBarras);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdArticulo);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblABMProducto);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngresarArticulo";
            this.Sizable = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIngresarArticulo_FormClosing);
            this.Load += new System.EventHandler(this.frmIngresarArticulo_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIngresarArticulo_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblABMProducto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtStock;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioVenta;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioCompra;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtDescripcion;
        private System.Windows.Forms.Button btnAgregarPresentacion;
        private System.Windows.Forms.Button btnAgregarCategoria;
        private System.Windows.Forms.ComboBox cmbPresentacion;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Button btnQuitarImagen;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pbxImagen;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtCodigoBarras;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtIdArticulo;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label lblPresentacion;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        private MaterialSkin.Controls.MaterialCheckBox chkEditarStock;
    }
}