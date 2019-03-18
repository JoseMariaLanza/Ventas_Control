namespace CapaPresentacion
{
    partial class frmNota
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNota));
            this.txtNota = new System.Windows.Forms.RichTextBox();
            this.mtbOpcionesNota = new DevComponents.DotNetBar.Metro.MetroToolbar();
            this.btnGuardar = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem3 = new DevComponents.DotNetBar.LabelItem();
            this.btnEliminar = new DevComponents.DotNetBar.ButtonItem();
            this.labelItem2 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem4 = new DevComponents.DotNetBar.LabelItem();
            this.labelItem1 = new DevComponents.DotNetBar.LabelItem();
            this.SuspendLayout();
            // 
            // txtNota
            // 
            resources.ApplyResources(this.txtNota, "txtNota");
            this.txtNota.BackColor = System.Drawing.Color.Goldenrod;
            this.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNota.Name = "txtNota";
            this.txtNota.BackColorChanged += new System.EventHandler(this.txtNota_BackColorChanged);
            this.txtNota.TextChanged += new System.EventHandler(this.txtNota_TextChanged);
            // 
            // mtbOpcionesNota
            // 
            this.mtbOpcionesNota.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.mtbOpcionesNota.BackgroundStyle.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.mtbOpcionesNota.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.mtbOpcionesNota.ContainerControlProcessDialogKey = true;
            resources.ApplyResources(this.mtbOpcionesNota, "mtbOpcionesNota");
            this.mtbOpcionesNota.DragDropSupport = true;
            this.mtbOpcionesNota.ExtraItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.btnGuardar,
            this.labelItem3,
            this.btnEliminar,
            this.labelItem2});
            this.mtbOpcionesNota.ForeColor = System.Drawing.Color.Black;
            this.mtbOpcionesNota.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.labelItem4,
            this.labelItem1});
            this.mtbOpcionesNota.Name = "mtbOpcionesNota";
            this.mtbOpcionesNota.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mtbOpcionesNota_MouseMove);
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.NotificationMarkColor = System.Drawing.Color.White;
            resources.ApplyResources(this.btnGuardar, "btnGuardar");
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // labelItem3
            // 
            this.labelItem3.Name = "labelItem3";
            resources.ApplyResources(this.labelItem3, "labelItem3");
            // 
            // btnEliminar
            // 
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Name = "btnEliminar";
            resources.ApplyResources(this.btnEliminar, "btnEliminar");
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // labelItem2
            // 
            this.labelItem2.Name = "labelItem2";
            resources.ApplyResources(this.labelItem2, "labelItem2");
            // 
            // labelItem4
            // 
            this.labelItem4.Name = "labelItem4";
            resources.ApplyResources(this.labelItem4, "labelItem4");
            // 
            // labelItem1
            // 
            this.labelItem1.ForeColor = System.Drawing.Color.White;
            this.labelItem1.Name = "labelItem1";
            resources.ApplyResources(this.labelItem1, "labelItem1");
            this.labelItem1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // frmNota
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Goldenrod;
            this.ControlBox = false;
            this.Controls.Add(this.mtbOpcionesNota);
            this.Controls.Add(this.txtNota);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNota";
            this.Load += new System.EventHandler(this.frmNota_Load);
            this.SizeChanged += new System.EventHandler(this.frmNota_SizeChanged);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmNota_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtNota;
        private DevComponents.DotNetBar.Metro.MetroToolbar mtbOpcionesNota;
        private DevComponents.DotNetBar.ButtonItem btnGuardar;
        private DevComponents.DotNetBar.ButtonItem btnEliminar;
        private DevComponents.DotNetBar.LabelItem labelItem1;
        private DevComponents.DotNetBar.LabelItem labelItem3;
        private DevComponents.DotNetBar.LabelItem labelItem4;
        private DevComponents.DotNetBar.LabelItem labelItem2;
    }
}