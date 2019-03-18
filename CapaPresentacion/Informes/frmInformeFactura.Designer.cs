namespace CapaPresentacion.Informes
{
    partial class frmInformeFactura
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.spreportefacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.Informes.dsPrincipal();
            this.rvFactura = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spreporte_facturaTableAdapter = new CapaPresentacion.Informes.dsPrincipalTableAdapters.spreporte_facturaTableAdapter();
            this.dsInformes = new CapaPresentacion.Informes.dsInformes();
            this.spFacturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spFacturaTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spFacturaTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spreportefacturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFacturaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spreportefacturaBindingSource
            // 
            this.spreportefacturaBindingSource.DataMember = "spreporte_factura";
            this.spreportefacturaBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvFactura
            // 
            this.rvFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetFactura";
            reportDataSource1.Value = this.spFacturaBindingSource;
            this.rvFactura.LocalReport.DataSources.Add(reportDataSource1);
            this.rvFactura.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.rptFactura.rdlc";
            this.rvFactura.Location = new System.Drawing.Point(0, 0);
            this.rvFactura.Name = "rvFactura";
            this.rvFactura.Size = new System.Drawing.Size(814, 561);
            this.rvFactura.TabIndex = 0;
            // 
            // spreporte_facturaTableAdapter
            // 
            this.spreporte_facturaTableAdapter.ClearBeforeFill = true;
            // 
            // dsInformes
            // 
            this.dsInformes.DataSetName = "dsInformes";
            this.dsInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spFacturaBindingSource
            // 
            this.spFacturaBindingSource.DataMember = "spFactura";
            this.spFacturaBindingSource.DataSource = this.dsInformes;
            // 
            // spFacturaTableAdapter
            // 
            this.spFacturaTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 561);
            this.Controls.Add(this.rvFactura);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(830, 600);
            this.Name = "frmInformeFactura";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInformeFactura_FormClosing);
            this.Load += new System.EventHandler(this.frmInformeFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spreportefacturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spFacturaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvFactura;
        private System.Windows.Forms.BindingSource spreportefacturaBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.spreporte_facturaTableAdapter spreporte_facturaTableAdapter;
        private System.Windows.Forms.BindingSource spFacturaBindingSource;
        private dsInformes dsInformes;
        private dsInformesTableAdapters.spFacturaTableAdapter spFacturaTableAdapter;
    }
}