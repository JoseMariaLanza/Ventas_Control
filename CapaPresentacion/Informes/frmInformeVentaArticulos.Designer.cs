namespace CapaPresentacion.Informes
{
    partial class frmInformeVentaArticulos
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dsInformes = new CapaPresentacion.Informes.dsInformes();
            this.rvVentaArticulos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spArticulosVendidosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spArticulosVendidosTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spArticulosVendidosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spArticulosVendidosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dsInformes
            // 
            this.dsInformes.DataSetName = "dsInformes";
            this.dsInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvVentaArticulos
            // 
            this.rvVentaArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "DataSetVentaArticulos";
            reportDataSource2.Value = this.spArticulosVendidosBindingSource;
            this.rvVentaArticulos.LocalReport.DataSources.Add(reportDataSource2);
            this.rvVentaArticulos.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.rptVentaArticulos.rdlc";
            this.rvVentaArticulos.Location = new System.Drawing.Point(0, 0);
            this.rvVentaArticulos.Name = "rvVentaArticulos";
            this.rvVentaArticulos.Size = new System.Drawing.Size(814, 561);
            this.rvVentaArticulos.TabIndex = 1;
            // 
            // spArticulosVendidosBindingSource
            // 
            this.spArticulosVendidosBindingSource.DataMember = "spArticulosVendidos";
            this.spArticulosVendidosBindingSource.DataSource = this.dsInformes;
            // 
            // spArticulosVendidosTableAdapter
            // 
            this.spArticulosVendidosTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeVentaArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 561);
            this.Controls.Add(this.rvVentaArticulos);
            this.DoubleBuffered = true;
            this.Name = "frmInformeVentaArticulos";
            this.Load += new System.EventHandler(this.frmInformeVentaArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spArticulosVendidosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvVentaArticulos;
        private System.Windows.Forms.BindingSource spArticulosVendidosBindingSource;
        private dsInformes dsInformes;
        private dsInformesTableAdapters.spArticulosVendidosTableAdapter spArticulosVendidosTableAdapter;
    }
}