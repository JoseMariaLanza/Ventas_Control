namespace CapaPresentacion.Informes
{
    partial class frmInformes
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
            this.rvInforme = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rvInforme
            // 
            this.rvInforme.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rvInforme.Location = new System.Drawing.Point(0, 0);
            this.rvInforme.Name = "rvInforme";
            this.rvInforme.Size = new System.Drawing.Size(814, 561);
            this.rvInforme.TabIndex = 0;
            // 
            // frmInformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 561);
            this.Controls.Add(this.rvInforme);
            this.DoubleBuffered = true;
            this.Name = "frmInformes";
            this.Load += new System.EventHandler(this.frmInformes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvInforme;
    }
}