namespace CapaPresentacion
{
    partial class frmTrabajador
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.chkEliminar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.lblCantidadClientes = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chkEliminarVarios = new MaterialSkin.Controls.MaterialCheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarNumero = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ttMensaje = new System.Windows.Forms.ToolTip(this.components);
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnLimpiarNDocumento = new System.Windows.Forms.Button();
            this.btnLimpiarBusquedaNombre = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.AllowUserToDeleteRows = false;
            this.dgvListado.AllowUserToOrderColumns = true;
            this.dgvListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvListado.BackgroundColor = System.Drawing.Color.LightSlateGray;
            this.dgvListado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.chkEliminar});
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.Location = new System.Drawing.Point(12, 129);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(542, 356);
            this.dgvListado.TabIndex = 157;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvListado_CellMouseDoubleClick);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // chkEliminar
            // 
            this.chkEliminar.HeaderText = "Eliminar";
            this.chkEliminar.Name = "chkEliminar";
            this.chkEliminar.ReadOnly = true;
            this.chkEliminar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.chkEliminar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Hint = "Buscar Nombre o Apellido";
            this.txtBuscar.Location = new System.Drawing.Point(82, 69);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(233, 23);
            this.txtBuscar.TabIndex = 149;
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblCantidadClientes
            // 
            this.lblCantidadClientes.AutoSize = true;
            this.lblCantidadClientes.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadClientes.Location = new System.Drawing.Point(224, 103);
            this.lblCantidadClientes.Name = "lblCantidadClientes";
            this.lblCantidadClientes.Size = new System.Drawing.Size(186, 23);
            this.lblCantidadClientes.TabIndex = 162;
            this.lblCantidadClientes.Text = "Cantidad de trabajadores:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 155;
            this.label2.Text = "Búsqueda:";
            // 
            // chkEliminarVarios
            // 
            this.chkEliminarVarios.AutoSize = true;
            this.chkEliminarVarios.Depth = 0;
            this.chkEliminarVarios.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkEliminarVarios.Location = new System.Drawing.Point(12, 96);
            this.chkEliminarVarios.Margin = new System.Windows.Forms.Padding(0);
            this.chkEliminarVarios.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkEliminarVarios.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkEliminarVarios.Name = "chkEliminarVarios";
            this.chkEliminarVarios.Ripple = true;
            this.chkEliminarVarios.Size = new System.Drawing.Size(179, 30);
            this.chkEliminarVarios.TabIndex = 158;
            this.chkEliminarVarios.Text = "Eliminar varios registros";
            this.chkEliminarVarios.UseVisualStyleBackColor = true;
            this.chkEliminarVarios.CheckedChanged += new System.EventHandler(this.chkEliminarVarios_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(70, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 47);
            this.label1.TabIndex = 154;
            this.label1.Text = "Trabajadores";
            // 
            // txtBuscarNumero
            // 
            this.txtBuscarNumero.Depth = 0;
            this.txtBuscarNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarNumero.Hint = "Buscar Nº de documento";
            this.txtBuscarNumero.Location = new System.Drawing.Point(321, 69);
            this.txtBuscarNumero.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscarNumero.Name = "txtBuscarNumero";
            this.txtBuscarNumero.PasswordChar = '\0';
            this.txtBuscarNumero.SelectedText = "";
            this.txtBuscarNumero.SelectionLength = 0;
            this.txtBuscarNumero.SelectionStart = 0;
            this.txtBuscarNumero.Size = new System.Drawing.Size(233, 23);
            this.txtBuscarNumero.TabIndex = 150;
            this.txtBuscarNumero.UseSystemPasswordChar = false;
            this.txtBuscarNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarNumero_KeyPress);
            this.txtBuscarNumero.TextChanged += new System.EventHandler(this.txtBuscarNumero_TextChanged);
            // 
            // ttMensaje
            // 
            this.ttMensaje.AutoPopDelay = 2000;
            this.ttMensaje.InitialDelay = 100;
            this.ttMensaje.IsBalloon = true;
            this.ttMensaje.ReshowDelay = 10;
            this.ttMensaje.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEliminar.BackColor = System.Drawing.Color.White;
            this.btnEliminar.Enabled = false;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnEliminar.Image = global::CapaPresentacion.Properties.Resources.circle;
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(12, 483);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(89, 35);
            this.btnEliminar.TabIndex = 156;
            this.btnEliminar.Text = "&Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = false;
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
            this.btnSalir.Location = new System.Drawing.Point(465, 483);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(89, 35);
            this.btnSalir.TabIndex = 153;
            this.btnSalir.Text = "&Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImprimir.BackColor = System.Drawing.Color.White;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnImprimir.Image = global::CapaPresentacion.Properties.Resources.printer;
            this.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImprimir.Location = new System.Drawing.Point(244, 483);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(89, 35);
            this.btnImprimir.TabIndex = 152;
            this.btnImprimir.Text = "&Imprimir";
            this.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarNDocumento
            // 
            this.btnLimpiarNDocumento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiarNDocumento.BackColor = System.Drawing.Color.White;
            this.btnLimpiarNDocumento.BackgroundImage = global::CapaPresentacion.Properties.Resources.circle;
            this.btnLimpiarNDocumento.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarNDocumento.FlatAppearance.BorderSize = 0;
            this.btnLimpiarNDocumento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarNDocumento.Location = new System.Drawing.Point(530, 69);
            this.btnLimpiarNDocumento.Name = "btnLimpiarNDocumento";
            this.btnLimpiarNDocumento.Size = new System.Drawing.Size(24, 23);
            this.btnLimpiarNDocumento.TabIndex = 161;
            this.btnLimpiarNDocumento.UseVisualStyleBackColor = false;
            this.btnLimpiarNDocumento.Visible = false;
            this.btnLimpiarNDocumento.Click += new System.EventHandler(this.btnLimpiarNDocumento_Click);
            // 
            // btnLimpiarBusquedaNombre
            // 
            this.btnLimpiarBusquedaNombre.BackColor = System.Drawing.Color.White;
            this.btnLimpiarBusquedaNombre.BackgroundImage = global::CapaPresentacion.Properties.Resources.circle;
            this.btnLimpiarBusquedaNombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarBusquedaNombre.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusquedaNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusquedaNombre.Location = new System.Drawing.Point(291, 69);
            this.btnLimpiarBusquedaNombre.Name = "btnLimpiarBusquedaNombre";
            this.btnLimpiarBusquedaNombre.Size = new System.Drawing.Size(24, 23);
            this.btnLimpiarBusquedaNombre.TabIndex = 159;
            this.btnLimpiarBusquedaNombre.UseVisualStyleBackColor = false;
            this.btnLimpiarBusquedaNombre.Visible = false;
            this.btnLimpiarBusquedaNombre.Click += new System.EventHandler(this.btnLimpiarBusquedaNombre_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.curriculum__1_;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 160;
            this.pictureBox1.TabStop = false;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIngresar.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIngresar.Image = global::CapaPresentacion.Properties.Resources.add_to_list_hand_drawn_interface_symbol;
            this.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIngresar.Location = new System.Drawing.Point(463, 98);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(91, 33);
            this.btnIngresar.TabIndex = 151;
            this.btnIngresar.Text = "&Agregar";
            this.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // frmTrabajador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 530);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.lblCantidadClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkEliminarVarios);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnLimpiarNDocumento);
            this.Controls.Add(this.btnLimpiarBusquedaNombre);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.txtBuscarNumero);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmTrabajador";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTrabajador_FormClosing);
            this.Load += new System.EventHandler(this.frmTrabajador_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTrabajador_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chkEliminar;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
        private System.Windows.Forms.Label lblCantidadClientes;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialCheckBox chkEliminarVarios;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscarNumero;
        private System.Windows.Forms.ToolTip ttMensaje;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnLimpiarNDocumento;
        private System.Windows.Forms.Button btnLimpiarBusquedaNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button btnIngresar;
    }
}