namespace CapaPresentacion
{
    partial class frmFechaHora
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
            this.dtpFechaHoraApertura = new System.Windows.Forms.DateTimePicker();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.chkAperturaPorDefecto = new MaterialSkin.Controls.MaterialCheckBox();
            this.SuspendLayout();
            // 
            // dtpFechaHoraApertura
            // 
            this.dtpFechaHoraApertura.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHoraApertura.Location = new System.Drawing.Point(4, 13);
            this.dtpFechaHoraApertura.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFechaHoraApertura.Name = "dtpFechaHoraApertura";
            this.dtpFechaHoraApertura.Size = new System.Drawing.Size(205, 27);
            this.dtpFechaHoraApertura.TabIndex = 347;
            this.dtpFechaHoraApertura.ValueChanged += new System.EventHandler(this.dtpFechaHoraApertura_ValueChanged);
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
            this.btnInsertar.Location = new System.Drawing.Point(120, 76);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(90, 33);
            this.btnInsertar.TabIndex = 348;
            this.btnInsertar.Text = "&Aceptar";
            this.btnInsertar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInsertar.UseVisualStyleBackColor = false;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.BackColor = System.Drawing.Color.White;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancelar.Image = global::CapaPresentacion.Properties.Resources.exit_hand_drawn_interface_symbol_variant;
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(4, 76);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 33);
            this.btnCancelar.TabIndex = 349;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // chkAperturaPorDefecto
            // 
            this.chkAperturaPorDefecto.AutoSize = true;
            this.chkAperturaPorDefecto.Depth = 0;
            this.chkAperturaPorDefecto.Font = new System.Drawing.Font("Roboto", 10F);
            this.chkAperturaPorDefecto.Location = new System.Drawing.Point(9, 43);
            this.chkAperturaPorDefecto.Margin = new System.Windows.Forms.Padding(0);
            this.chkAperturaPorDefecto.MouseLocation = new System.Drawing.Point(-1, -1);
            this.chkAperturaPorDefecto.MouseState = MaterialSkin.MouseState.HOVER;
            this.chkAperturaPorDefecto.Name = "chkAperturaPorDefecto";
            this.chkAperturaPorDefecto.Ripple = true;
            this.chkAperturaPorDefecto.Size = new System.Drawing.Size(169, 30);
            this.chkAperturaPorDefecto.TabIndex = 354;
            this.chkAperturaPorDefecto.Text = "Establecer por defecto";
            this.chkAperturaPorDefecto.UseVisualStyleBackColor = true;
            this.chkAperturaPorDefecto.CheckedChanged += new System.EventHandler(this.chkAperturaPorDefecto_CheckedChanged);
            // 
            // frmFechaHora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 111);
            this.ControlBox = false;
            this.Controls.Add(this.chkAperturaPorDefecto);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dtpFechaHoraApertura);
            this.Controls.Add(this.btnInsertar);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe Print", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmFechaHora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingrese la fecha y hora de apertura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFechaHora_FormClosing);
            this.Load += new System.EventHandler(this.frmFechaHora_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpFechaHoraApertura;
        public System.Windows.Forms.Button btnInsertar;
        public System.Windows.Forms.Button btnCancelar;
        private MaterialSkin.Controls.MaterialCheckBox chkAperturaPorDefecto;
    }
}