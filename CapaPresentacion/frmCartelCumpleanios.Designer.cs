namespace CapaPresentacion
{
    partial class frmCartelCumpleanios
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
            this.pbxImagen = new System.Windows.Forms.PictureBox();
            this.rtxtMensajeCumpleanios = new System.Windows.Forms.RichTextBox();
            this.btnAgradecer = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxImagen
            // 
            this.pbxImagen.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbxImagen.Location = new System.Drawing.Point(84, 60);
            this.pbxImagen.Name = "pbxImagen";
            this.pbxImagen.Size = new System.Drawing.Size(147, 132);
            this.pbxImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxImagen.TabIndex = 375;
            this.pbxImagen.TabStop = false;
            // 
            // rtxtMensajeCumpleanios
            // 
            this.rtxtMensajeCumpleanios.Enabled = false;
            this.rtxtMensajeCumpleanios.Location = new System.Drawing.Point(12, 12);
            this.rtxtMensajeCumpleanios.Name = "rtxtMensajeCumpleanios";
            this.rtxtMensajeCumpleanios.Size = new System.Drawing.Size(294, 49);
            this.rtxtMensajeCumpleanios.TabIndex = 374;
            this.rtxtMensajeCumpleanios.Text = "Felíz cumpleaños!!!";
            // 
            // btnAgradecer
            // 
            this.btnAgradecer.Location = new System.Drawing.Point(238, 168);
            this.btnAgradecer.Name = "btnAgradecer";
            this.btnAgradecer.Size = new System.Drawing.Size(68, 23);
            this.btnAgradecer.TabIndex = 376;
            this.btnAgradecer.Text = "Gracias!!";
            this.btnAgradecer.UseVisualStyleBackColor = true;
            this.btnAgradecer.Click += new System.EventHandler(this.btnAgradecer_Click);
            // 
            // frmCartelCumpleanios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 204);
            this.Controls.Add(this.btnAgradecer);
            this.Controls.Add(this.pbxImagen);
            this.Controls.Add(this.rtxtMensajeCumpleanios);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmCartelCumpleanios";
            this.Load += new System.EventHandler(this.frmCartelCumpleanios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxImagen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbxImagen;
        public System.Windows.Forms.RichTextBox rtxtMensajeCumpleanios;
        private System.Windows.Forms.Button btnAgradecer;
    }
}