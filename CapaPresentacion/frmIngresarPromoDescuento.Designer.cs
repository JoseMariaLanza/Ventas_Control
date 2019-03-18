namespace CapaPresentacion
{
    partial class frmIngresarPromoDescuento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtIdDescuento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtArticulo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.errorIcono = new System.Windows.Forms.ErrorProvider(this.components);
            this.iconoNotificacion = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCantidad = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioVentaDescuento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label5 = new System.Windows.Forms.Label();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.chkEliminarVarios = new MaterialSkin.Controls.MaterialCheckBox();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.clmnEliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtNombreDescuento = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPorcentajeGanancia = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMontoInversion = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label8 = new System.Windows.Forms.Label();
            this.chkActualizacionAutomatica = new MaterialSkin.Controls.MaterialCheckBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.chkEstablecerPorcentajeGanancia = new MaterialSkin.Controls.MaterialCheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.SuspendLayout();
            // 
            // txtIdDescuento
            // 
            this.txtIdDescuento.Depth = 0;
            this.txtIdDescuento.Enabled = false;
            this.txtIdDescuento.Hint = "";
            this.txtIdDescuento.Location = new System.Drawing.Point(74, 70);
            this.txtIdDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtIdDescuento.Name = "txtIdDescuento";
            this.txtIdDescuento.PasswordChar = '\0';
            this.txtIdDescuento.SelectedText = "";
            this.txtIdDescuento.SelectionLength = 0;
            this.txtIdDescuento.SelectionStart = 0;
            this.txtIdDescuento.Size = new System.Drawing.Size(60, 23);
            this.txtIdDescuento.TabIndex = 47;
            this.txtIdDescuento.UseSystemPasswordChar = false;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Depth = 0;
            this.txtArticulo.Enabled = false;
            this.txtArticulo.Hint = "Artículo";
            this.txtArticulo.Location = new System.Drawing.Point(74, 128);
            this.txtArticulo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.PasswordChar = '\0';
            this.txtArticulo.SelectedText = "";
            this.txtArticulo.SelectionLength = 0;
            this.txtArticulo.SelectionStart = 0;
            this.txtArticulo.Size = new System.Drawing.Size(203, 23);
            this.txtArticulo.TabIndex = 46;
            this.txtArticulo.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 322);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 19);
            this.label3.TabIndex = 41;
            this.label3.Text = "Descripción:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "Articulo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "Código:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.White;
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(12, 344);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(265, 60);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.BackColor = System.Drawing.Color.Transparent;
            this.lblDescuento.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.ForeColor = System.Drawing.Color.White;
            this.lblDescuento.Location = new System.Drawing.Point(58, 17);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(183, 43);
            this.lblDescuento.TabIndex = 37;
            this.lblDescuento.Text = "Nueva Promo";
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
            this.btnCancelar.Location = new System.Drawing.Point(12, 449);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 33);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditar.BackColor = System.Drawing.Color.White;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEditar.Image = global::CapaPresentacion.Properties.Resources.editing;
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(217, 449);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(90, 33);
            this.btnEditar.TabIndex = 44;
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
            this.btnNuevo.Location = new System.Drawing.Point(12, 449);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(90, 33);
            this.btnNuevo.TabIndex = 43;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnInsertar
            // 
            this.btnInsertar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInsertar.BackColor = System.Drawing.Color.White;
            this.btnInsertar.FlatAppearance.BorderSize = 0;
            this.btnInsertar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInsertar.Image = global::CapaPresentacion.Properties.Resources.symbols_1;
            this.btnInsertar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInsertar.Location = new System.Drawing.Point(217, 449);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(90, 33);
            this.btnInsertar.TabIndex = 9;
            this.btnInsertar.Text = "Guardar";
            this.btnInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.add;
            this.pictureBox1.Location = new System.Drawing.Point(12, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Depth = 0;
            this.txtCantidad.Hint = "0.000";
            this.txtCantidad.Location = new System.Drawing.Point(16, 183);
            this.txtCantidad.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.PasswordChar = '\0';
            this.txtCantidad.SelectedText = "";
            this.txtCantidad.SelectionLength = 0;
            this.txtCantidad.SelectionStart = 0;
            this.txtCantidad.Size = new System.Drawing.Size(95, 23);
            this.txtCantidad.TabIndex = 3;
            this.txtCantidad.UseSystemPasswordChar = false;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 19);
            this.label4.TabIndex = 48;
            this.label4.Text = "Cantidad:";
            // 
            // txtPrecioVentaDescuento
            // 
            this.txtPrecioVentaDescuento.Depth = 0;
            this.txtPrecioVentaDescuento.Hint = "0";
            this.txtPrecioVentaDescuento.Location = new System.Drawing.Point(182, 266);
            this.txtPrecioVentaDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPrecioVentaDescuento.Name = "txtPrecioVentaDescuento";
            this.txtPrecioVentaDescuento.PasswordChar = '\0';
            this.txtPrecioVentaDescuento.SelectedText = "";
            this.txtPrecioVentaDescuento.SelectionLength = 0;
            this.txtPrecioVentaDescuento.SelectionStart = 0;
            this.txtPrecioVentaDescuento.Size = new System.Drawing.Size(95, 23);
            this.txtPrecioVentaDescuento.TabIndex = 51;
            this.txtPrecioVentaDescuento.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(178, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 50;
            this.label5.Text = "Precio venta:";
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.BackColor = System.Drawing.Color.White;
            this.btnBuscarArticulo.BackgroundImage = global::CapaPresentacion.Properties.Resources.loupe;
            this.btnBuscarArticulo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarArticulo.FlatAppearance.BorderSize = 0;
            this.btnBuscarArticulo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarArticulo.Location = new System.Drawing.Point(283, 128);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(24, 23);
            this.btnBuscarArticulo.TabIndex = 2;
            this.btnBuscarArticulo.UseVisualStyleBackColor = false;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            this.btnBuscarArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnBuscarArticulo_KeyPress);
            // 
            // chkEliminarVarios
            // 
            this.chkEliminarVarios.AutoSize = true;
            this.chkEliminarVarios.BackColor = System.Drawing.Color.Transparent;
            this.chkEliminarVarios.Depth = 0;
            this.chkEliminarVarios.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkEliminarVarios.Location = new System.Drawing.Point(313, 66);
            this.chkEliminarVarios.Margin = new System.Windows.Forms.Padding(0);
            this.chkEliminarVarios.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkEliminarVarios.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkEliminarVarios.Name = "chkEliminarVarios";
            this.chkEliminarVarios.Ripple = true;
            this.chkEliminarVarios.Size = new System.Drawing.Size(179, 30);
            this.chkEliminarVarios.TabIndex = 55;
            this.chkEliminarVarios.Text = "Eliminar varios registros";
            this.chkEliminarVarios.UseVisualStyleBackColor = false;
            this.chkEliminarVarios.CheckedChanged += new System.EventHandler(this.chkEliminarVarios_CheckedChanged);
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.LightSlateGray;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmnEliminar});
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.Location = new System.Drawing.Point(313, 99);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(289, 305);
            this.dgvListado.TabIndex = 10;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            // 
            // clmnEliminar
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.NullValue = false;
            this.clmnEliminar.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmnEliminar.HeaderText = "Eliminar";
            this.clmnEliminar.Name = "clmnEliminar";
            this.clmnEliminar.ReadOnly = true;
            this.clmnEliminar.Width = 74;
            // 
            // txtNombreDescuento
            // 
            this.txtNombreDescuento.Depth = 0;
            this.txtNombreDescuento.Hint = "Nombre de la promo";
            this.txtNombreDescuento.Location = new System.Drawing.Point(74, 99);
            this.txtNombreDescuento.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtNombreDescuento.Name = "txtNombreDescuento";
            this.txtNombreDescuento.PasswordChar = '\0';
            this.txtNombreDescuento.SelectedText = "";
            this.txtNombreDescuento.SelectionLength = 0;
            this.txtNombreDescuento.SelectionStart = 0;
            this.txtNombreDescuento.Size = new System.Drawing.Size(203, 23);
            this.txtNombreDescuento.TabIndex = 1;
            this.txtNombreDescuento.UseSystemPasswordChar = false;
            this.txtNombreDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreDescuento_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 19);
            this.label6.TabIndex = 56;
            this.label6.Text = "Nombre:";
            // 
            // txtPorcentajeGanancia
            // 
            this.txtPorcentajeGanancia.Depth = 0;
            this.txtPorcentajeGanancia.Enabled = false;
            this.txtPorcentajeGanancia.Hint = "%";
            this.txtPorcentajeGanancia.Location = new System.Drawing.Point(16, 266);
            this.txtPorcentajeGanancia.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtPorcentajeGanancia.Name = "txtPorcentajeGanancia";
            this.txtPorcentajeGanancia.PasswordChar = '\0';
            this.txtPorcentajeGanancia.SelectedText = "";
            this.txtPorcentajeGanancia.SelectionLength = 0;
            this.txtPorcentajeGanancia.SelectionStart = 0;
            this.txtPorcentajeGanancia.Size = new System.Drawing.Size(95, 23);
            this.txtPorcentajeGanancia.TabIndex = 5;
            this.txtPorcentajeGanancia.Text = "0";
            this.txtPorcentajeGanancia.UseSystemPasswordChar = false;
            this.txtPorcentajeGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcentajeGanancia_KeyPress);
            this.txtPorcentajeGanancia.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(140, 19);
            this.label7.TabIndex = 58;
            this.label7.Text = "Porcentaje de ganancia:";
            // 
            // txtMontoInversion
            // 
            this.txtMontoInversion.Depth = 0;
            this.txtMontoInversion.Enabled = false;
            this.txtMontoInversion.Hint = "0";
            this.txtMontoInversion.Location = new System.Drawing.Point(182, 183);
            this.txtMontoInversion.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMontoInversion.Name = "txtMontoInversion";
            this.txtMontoInversion.PasswordChar = '\0';
            this.txtMontoInversion.SelectedText = "";
            this.txtMontoInversion.SelectionLength = 0;
            this.txtMontoInversion.SelectionStart = 0;
            this.txtMontoInversion.Size = new System.Drawing.Size(95, 23);
            this.txtMontoInversion.TabIndex = 61;
            this.txtMontoInversion.UseSystemPasswordChar = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(152, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 19);
            this.label8.TabIndex = 60;
            this.label8.Text = "Costo de la inversión:";
            // 
            // chkActualizacionAutomatica
            // 
            this.chkActualizacionAutomatica.AutoSize = true;
            this.chkActualizacionAutomatica.BackColor = System.Drawing.Color.Transparent;
            this.chkActualizacionAutomatica.Checked = true;
            this.chkActualizacionAutomatica.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActualizacionAutomatica.Depth = 0;
            this.chkActualizacionAutomatica.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkActualizacionAutomatica.Location = new System.Drawing.Point(9, 292);
            this.chkActualizacionAutomatica.Margin = new System.Windows.Forms.Padding(0);
            this.chkActualizacionAutomatica.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkActualizacionAutomatica.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkActualizacionAutomatica.Name = "chkActualizacionAutomatica";
            this.chkActualizacionAutomatica.Ripple = true;
            this.chkActualizacionAutomatica.Size = new System.Drawing.Size(274, 30);
            this.chkActualizacionAutomatica.TabIndex = 6;
            this.chkActualizacionAutomatica.Text = "Actualizar promoción automáticamente";
            this.chkActualizacionAutomatica.UseVisualStyleBackColor = false;
            this.chkActualizacionAutomatica.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkActualizacionAutomatica_KeyPress);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAgregar.BackColor = System.Drawing.Color.White;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregar.Image = global::CapaPresentacion.Properties.Resources.addarrow;
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.Location = new System.Drawing.Point(218, 410);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(89, 35);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "&Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuitar.BackColor = System.Drawing.Color.White;
            this.btnQuitar.Enabled = false;
            this.btnQuitar.FlatAppearance.BorderSize = 0;
            this.btnQuitar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQuitar.Image = global::CapaPresentacion.Properties.Resources.arrows_1;
            this.btnQuitar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new System.Drawing.Point(313, 410);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(89, 35);
            this.btnQuitar.TabIndex = 11;
            this.btnQuitar.Text = "&Quitar";
            this.btnQuitar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQuitar.UseVisualStyleBackColor = false;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
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
            this.btnSalir.Location = new System.Drawing.Point(513, 451);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 31);
            this.btnSalir.TabIndex = 331;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(313, 451);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(91, 31);
            this.btnImprimir.TabIndex = 332;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // chkEstablecerPorcentajeGanancia
            // 
            this.chkEstablecerPorcentajeGanancia.BackColor = System.Drawing.Color.Transparent;
            this.chkEstablecerPorcentajeGanancia.Depth = 0;
            this.chkEstablecerPorcentajeGanancia.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkEstablecerPorcentajeGanancia.Location = new System.Drawing.Point(16, 215);
            this.chkEstablecerPorcentajeGanancia.Margin = new System.Windows.Forms.Padding(0);
            this.chkEstablecerPorcentajeGanancia.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkEstablecerPorcentajeGanancia.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkEstablecerPorcentajeGanancia.Name = "chkEstablecerPorcentajeGanancia";
            this.chkEstablecerPorcentajeGanancia.Ripple = true;
            this.chkEstablecerPorcentajeGanancia.Size = new System.Drawing.Size(261, 19);
            this.chkEstablecerPorcentajeGanancia.TabIndex = 4;
            this.chkEstablecerPorcentajeGanancia.Text = "Establecer porcentaje de ganancia";
            this.chkEstablecerPorcentajeGanancia.UseVisualStyleBackColor = false;
            this.chkEstablecerPorcentajeGanancia.CheckedChanged += new System.EventHandler(this.chkEstablecerPorcentajeGanancia_CheckedChanged);
            this.chkEstablecerPorcentajeGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.chkEstablecerPorcentajeGanancia_KeyPress);
            // 
            // frmIngresarPromoDescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 494);
            this.Controls.Add(this.chkEstablecerPorcentajeGanancia);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnQuitar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.chkActualizacionAutomatica);
            this.Controls.Add(this.txtMontoInversion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPorcentajeGanancia);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNombreDescuento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkEliminarVarios);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.btnBuscarArticulo);
            this.Controls.Add(this.txtPrecioVentaDescuento);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIdDescuento);
            this.Controls.Add(this.txtArticulo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.lblDescuento);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnInsertar);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1061, 494);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(614, 0);
            this.Name = "frmIngresarPromoDescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmIngresarPromoDescuento_FormClosing);
            this.Load += new System.EventHandler(this.frmIngresarPromoDescuento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmIngresarPromoDescuento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorIcono)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialSingleLineTextField txtIdDescuento;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtArticulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.ErrorProvider errorIcono;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        public System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NotifyIcon iconoNotificacion;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtPrecioVentaDescuento;
        private System.Windows.Forms.Label label5;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtCantidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private MaterialSkin.Controls.MaterialCheckBox chkEliminarVarios;
        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmnEliminar;
        private MaterialSkin.Controls.MaterialCheckBox chkActualizacionAutomatica;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtMontoInversion;
        private System.Windows.Forms.Label label8;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtPorcentajeGanancia;
        private System.Windows.Forms.Label label7;
        public MaterialSkin.Controls.MaterialSingleLineTextField txtNombreDescuento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private MaterialSkin.Controls.MaterialCheckBox chkEstablecerPorcentajeGanancia;
    }
}