namespace CapaPresentacion.Informes
{
    partial class frmInformeAperturasCierres
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
            this.spMostrarInformeAperturasCierresBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsInformes = new CapaPresentacion.Informes.dsInformes();
            this.DatosGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvAperturasCierres = new Microsoft.Reporting.WinForms.ReportViewer();
            this.spMostrarInformeAperturasCierresTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spMostrarInformeAperturasCierresTableAdapter();
            this.spMostrarDetallesAperturaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spMostrarDetallesAperturaTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spMostrarDetallesAperturaTableAdapter();
            this.spMostrarDetallesCierreBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spMostrarDetallesCierreTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spMostrarDetallesCierreTableAdapter();
            this.CalcularGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spCalcularGastosTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spCalcularGastosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarInformeAperturasCierresBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatosGastosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarDetallesAperturaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarDetallesCierreBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcularGastosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // spMostrarInformeAperturasCierresBindingSource
            // 
            this.spMostrarInformeAperturasCierresBindingSource.DataMember = "spMostrarInformeAperturasCierres";
            this.spMostrarInformeAperturasCierresBindingSource.DataSource = this.dsInformes;
            // 
            // dsInformes
            // 
            this.dsInformes.DataSetName = "dsInformes";
            this.dsInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DatosGastosBindingSource
            // 
            this.DatosGastosBindingSource.DataSource = typeof(CapaPresentacion.Informes.DatosGastos);
            // 
            // rvAperturasCierres
            // 
            this.rvAperturasCierres.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "dsAperturasCierres";
            reportDataSource1.Value = this.spMostrarInformeAperturasCierresBindingSource;
            this.rvAperturasCierres.LocalReport.DataSources.Add(reportDataSource1);
            this.rvAperturasCierres.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.rptAperturasCierres.rdlc";
            this.rvAperturasCierres.Location = new System.Drawing.Point(0, 0);
            this.rvAperturasCierres.Name = "rvAperturasCierres";
            this.rvAperturasCierres.ShowExportButton = false;
            this.rvAperturasCierres.Size = new System.Drawing.Size(814, 561);
            this.rvAperturasCierres.TabIndex = 0;
            // 
            // spMostrarInformeAperturasCierresTableAdapter
            // 
            this.spMostrarInformeAperturasCierresTableAdapter.ClearBeforeFill = true;
            // 
            // spMostrarDetallesAperturaBindingSource
            // 
            this.spMostrarDetallesAperturaBindingSource.DataMember = "spMostrarDetallesApertura";
            this.spMostrarDetallesAperturaBindingSource.DataSource = this.dsInformes;
            // 
            // spMostrarDetallesAperturaTableAdapter
            // 
            this.spMostrarDetallesAperturaTableAdapter.ClearBeforeFill = true;
            // 
            // spMostrarDetallesCierreBindingSource
            // 
            this.spMostrarDetallesCierreBindingSource.DataMember = "spMostrarDetallesCierre";
            this.spMostrarDetallesCierreBindingSource.DataSource = this.dsInformes;
            // 
            // spMostrarDetallesCierreTableAdapter
            // 
            this.spMostrarDetallesCierreTableAdapter.ClearBeforeFill = true;
            // 
            // CalcularGastosBindingSource
            // 
            this.CalcularGastosBindingSource.DataMember = "spCalcularGastos";
            this.CalcularGastosBindingSource.DataSource = this.dsInformes;
            // 
            // spCalcularGastosTableAdapter
            // 
            this.spCalcularGastosTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeAperturasCierres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 561);
            this.Controls.Add(this.rvAperturasCierres);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmInformeAperturasCierres";
            this.Load += new System.EventHandler(this.frmInformeAperutrasCierres_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarInformeAperturasCierresBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DatosGastosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarDetallesAperturaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarDetallesCierreBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalcularGastosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvAperturasCierres;
        private System.Windows.Forms.BindingSource spMostrarInformeAperturasCierresBindingSource;
        private dsInformes dsInformes;
        private dsInformesTableAdapters.spMostrarInformeAperturasCierresTableAdapter spMostrarInformeAperturasCierresTableAdapter;
        private System.Windows.Forms.BindingSource spMostrarDetallesAperturaBindingSource;
        private dsInformesTableAdapters.spMostrarDetallesAperturaTableAdapter spMostrarDetallesAperturaTableAdapter;
        private System.Windows.Forms.BindingSource spMostrarDetallesCierreBindingSource;
        private dsInformesTableAdapters.spMostrarDetallesCierreTableAdapter spMostrarDetallesCierreTableAdapter;
        private System.Windows.Forms.BindingSource CalcularGastosBindingSource;
        private dsInformesTableAdapters.spCalcularGastosTableAdapter spCalcularGastosTableAdapter;
        private System.Windows.Forms.BindingSource DatosGastosBindingSource;
    }
}