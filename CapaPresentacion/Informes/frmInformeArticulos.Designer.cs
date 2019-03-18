namespace CapaPresentacion.Informes
{
    partial class frmInformeArticulos
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
            this.mostrar_productoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new CapaPresentacion.Informes.dsPrincipal();
            this.rvArticulos = new Microsoft.Reporting.WinForms.ReportViewer();
            this.mostrar_productoTableAdapter = new CapaPresentacion.Informes.dsPrincipalTableAdapters.mostrar_productoTableAdapter();
            this.dsInformes = new CapaPresentacion.Informes.dsInformes();
            this.spMostrarArticulosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spMostrarArticulosTableAdapter = new CapaPresentacion.Informes.dsInformesTableAdapters.spMostrarArticulosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_productoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarArticulosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mostrar_productoBindingSource
            // 
            this.mostrar_productoBindingSource.DataMember = "mostrar_producto";
            this.mostrar_productoBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rvArticulos
            // 
            this.rvArticulos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetArticulos";
            reportDataSource1.Value = this.spMostrarArticulosBindingSource;
            this.rvArticulos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvArticulos.LocalReport.ReportEmbeddedResource = "CapaPresentacion.Informes.rptArticulos.rdlc";
            this.rvArticulos.Location = new System.Drawing.Point(0, 0);
            this.rvArticulos.Name = "rvArticulos";
            this.rvArticulos.Size = new System.Drawing.Size(814, 561);
            this.rvArticulos.TabIndex = 0;
            // 
            // mostrar_productoTableAdapter
            // 
            this.mostrar_productoTableAdapter.ClearBeforeFill = true;
            // 
            // dsInformes
            // 
            this.dsInformes.DataSetName = "dsInformes";
            this.dsInformes.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spMostrarArticulosBindingSource
            // 
            this.spMostrarArticulosBindingSource.DataMember = "spMostrarArticulos";
            this.spMostrarArticulosBindingSource.DataSource = this.dsInformes;
            // 
            // spMostrarArticulosTableAdapter
            // 
            this.spMostrarArticulosTableAdapter.ClearBeforeFill = true;
            // 
            // frmInformeArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 561);
            this.Controls.Add(this.rvArticulos);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(830, 600);
            this.Name = "frmInformeArticulos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmInformeArticulos_FormClosing);
            this.Load += new System.EventHandler(this.frmInformeArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mostrar_productoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsInformes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spMostrarArticulosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvArticulos;
        private System.Windows.Forms.BindingSource mostrar_productoBindingSource;
        private dsPrincipal dsPrincipal;
        private dsPrincipalTableAdapters.mostrar_productoTableAdapter mostrar_productoTableAdapter;
        private dsInformes dsInformes;
        private System.Windows.Forms.BindingSource spMostrarArticulosBindingSource;
        private dsInformesTableAdapters.spMostrarArticulosTableAdapter spMostrarArticulosTableAdapter;
    }
}