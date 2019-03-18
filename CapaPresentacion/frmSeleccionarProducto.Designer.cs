namespace CapaPresentacion
{
    partial class frmSeleccionarProducto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBuscar = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBuscarCategoria = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtBuscarCodigo = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnLimpiarCodigo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLimpiarBusquedaNombre = new System.Windows.Forms.Button();
            this.btnLimpiarBusquedaCategoria = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Depth = 0;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Hint = "";
            this.txtBuscar.Location = new System.Drawing.Point(82, 68);
            this.txtBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.PasswordChar = '\0';
            this.txtBuscar.SelectedText = "";
            this.txtBuscar.SelectionLength = 0;
            this.txtBuscar.SelectionStart = 0;
            this.txtBuscar.Size = new System.Drawing.Size(190, 23);
            this.txtBuscar.TabIndex = 98;
            this.txtBuscar.UseSystemPasswordChar = false;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.DarkRed;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvListado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvListado.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListado.Location = new System.Drawing.Point(12, 97);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersVisible = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            this.dgvListado.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(622, 282);
            this.dgvListado.TabIndex = 101;
            this.dgvListado.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListado_CellClick);
            this.dgvListado.DoubleClick += new System.EventHandler(this.dgvListado_DoubleClick);
            this.dgvListado.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvListado_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 19);
            this.label2.TabIndex = 100;
            this.label2.Text = "Búsqueda:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(69, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(316, 47);
            this.label1.TabIndex = 97;
            this.label1.Text = "Seleccione un artículo";
            // 
            // txtBuscarCategoria
            // 
            this.txtBuscarCategoria.Depth = 0;
            this.txtBuscarCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCategoria.Hint = "";
            this.txtBuscarCategoria.Location = new System.Drawing.Point(278, 68);
            this.txtBuscarCategoria.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscarCategoria.Name = "txtBuscarCategoria";
            this.txtBuscarCategoria.PasswordChar = '\0';
            this.txtBuscarCategoria.SelectedText = "";
            this.txtBuscarCategoria.SelectionLength = 0;
            this.txtBuscarCategoria.SelectionStart = 0;
            this.txtBuscarCategoria.Size = new System.Drawing.Size(154, 23);
            this.txtBuscarCategoria.TabIndex = 99;
            this.txtBuscarCategoria.UseSystemPasswordChar = false;
            this.txtBuscarCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCategoria_KeyPress);
            this.txtBuscarCategoria.TextChanged += new System.EventHandler(this.txtBuscarCategoria_TextChanged);
            // 
            // txtBuscarCodigo
            // 
            this.txtBuscarCodigo.Depth = 0;
            this.txtBuscarCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscarCodigo.Hint = "";
            this.txtBuscarCodigo.Location = new System.Drawing.Point(438, 68);
            this.txtBuscarCodigo.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtBuscarCodigo.Name = "txtBuscarCodigo";
            this.txtBuscarCodigo.PasswordChar = '\0';
            this.txtBuscarCodigo.SelectedText = "";
            this.txtBuscarCodigo.SelectionLength = 0;
            this.txtBuscarCodigo.SelectionStart = 0;
            this.txtBuscarCodigo.Size = new System.Drawing.Size(196, 23);
            this.txtBuscarCodigo.TabIndex = 105;
            this.txtBuscarCodigo.UseSystemPasswordChar = false;
            this.txtBuscarCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscarCodigo_KeyPress);
            this.txtBuscarCodigo.TextChanged += new System.EventHandler(this.txtBuscarCodigo_TextChanged);
            // 
            // btnLimpiarCodigo
            // 
            this.btnLimpiarCodigo.BackColor = System.Drawing.Color.White;
            this.btnLimpiarCodigo.BackgroundImage = global::CapaPresentacion.Properties.Resources.circle;
            this.btnLimpiarCodigo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarCodigo.FlatAppearance.BorderSize = 0;
            this.btnLimpiarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarCodigo.Location = new System.Drawing.Point(610, 68);
            this.btnLimpiarCodigo.Name = "btnLimpiarCodigo";
            this.btnLimpiarCodigo.Size = new System.Drawing.Size(24, 23);
            this.btnLimpiarCodigo.TabIndex = 106;
            this.btnLimpiarCodigo.UseVisualStyleBackColor = false;
            this.btnLimpiarCodigo.Visible = false;
            this.btnLimpiarCodigo.Click += new System.EventHandler(this.btnLimpiarCodigo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::CapaPresentacion.Properties.Resources.flour;
            this.pictureBox1.Location = new System.Drawing.Point(12, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // btnLimpiarBusquedaNombre
            // 
            this.btnLimpiarBusquedaNombre.BackColor = System.Drawing.Color.White;
            this.btnLimpiarBusquedaNombre.BackgroundImage = global::CapaPresentacion.Properties.Resources.circle;
            this.btnLimpiarBusquedaNombre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarBusquedaNombre.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusquedaNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusquedaNombre.Location = new System.Drawing.Point(248, 68);
            this.btnLimpiarBusquedaNombre.Name = "btnLimpiarBusquedaNombre";
            this.btnLimpiarBusquedaNombre.Size = new System.Drawing.Size(24, 23);
            this.btnLimpiarBusquedaNombre.TabIndex = 103;
            this.btnLimpiarBusquedaNombre.UseVisualStyleBackColor = false;
            this.btnLimpiarBusquedaNombre.Visible = false;
            this.btnLimpiarBusquedaNombre.Click += new System.EventHandler(this.btnLimpiarBusquedaNombre_Click);
            // 
            // btnLimpiarBusquedaCategoria
            // 
            this.btnLimpiarBusquedaCategoria.BackColor = System.Drawing.Color.White;
            this.btnLimpiarBusquedaCategoria.BackgroundImage = global::CapaPresentacion.Properties.Resources.circle;
            this.btnLimpiarBusquedaCategoria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiarBusquedaCategoria.FlatAppearance.BorderSize = 0;
            this.btnLimpiarBusquedaCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarBusquedaCategoria.Location = new System.Drawing.Point(408, 68);
            this.btnLimpiarBusquedaCategoria.Name = "btnLimpiarBusquedaCategoria";
            this.btnLimpiarBusquedaCategoria.Size = new System.Drawing.Size(24, 23);
            this.btnLimpiarBusquedaCategoria.TabIndex = 102;
            this.btnLimpiarBusquedaCategoria.UseVisualStyleBackColor = false;
            this.btnLimpiarBusquedaCategoria.Visible = false;
            this.btnLimpiarBusquedaCategoria.Click += new System.EventHandler(this.btnLimpiarBusquedaCategoria_Click);
            // 
            // frmSeleccionarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 391);
            this.Controls.Add(this.btnLimpiarCodigo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLimpiarBusquedaNombre);
            this.Controls.Add(this.btnLimpiarBusquedaCategoria);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvListado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBuscarCategoria);
            this.Controls.Add(this.txtBuscarCodigo);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSeleccionarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmSeleccionarProducto_FormClosing);
            this.Load += new System.EventHandler(this.frmSeleccionarProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSeleccionarProducto_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLimpiarCodigo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLimpiarBusquedaNombre;
        private System.Windows.Forms.Button btnLimpiarBusquedaCategoria;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscar;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscarCategoria;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtBuscarCodigo;
        public System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label label1;
    }
}