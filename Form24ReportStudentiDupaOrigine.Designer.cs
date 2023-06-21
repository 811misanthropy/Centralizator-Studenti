namespace Centralizator_Studenti
{
    partial class Form24ReportStudentiDupaOrigine
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSet5DataPerFacultate = new Centralizator_Studenti.DataSet5DataPerFacultate();
            this.dataTableNrCandidPerLiceuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableNrCandidPerLiceuTableAdapter = new Centralizator_Studenti.DataSet5DataPerFacultateTableAdapters.DataTableNrCandidPerLiceuTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableNrCandidPerLiceuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableNrCandidPerLiceuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Centralizator_Studenti.Report12NrStudentiDupaProvenienta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(632, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet5DataPerFacultate
            // 
            this.dataSet5DataPerFacultate.DataSetName = "DataSet5DataPerFacultate";
            this.dataSet5DataPerFacultate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableNrCandidPerLiceuBindingSource
            // 
            this.dataTableNrCandidPerLiceuBindingSource.DataMember = "DataTableNrCandidPerLiceu";
            this.dataTableNrCandidPerLiceuBindingSource.DataSource = this.dataSet5DataPerFacultate;
            // 
            // dataTableNrCandidPerLiceuTableAdapter
            // 
            this.dataTableNrCandidPerLiceuTableAdapter.ClearBeforeFill = true;
            // 
            // Form24ReportStudentiDupaOrigine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form24ReportStudentiDupaOrigine";
            this.Text = "Form24ReportStudentiDupaOrigine";
            this.Load += new System.EventHandler(this.Form24ReportStudentiPerAnAcademic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableNrCandidPerLiceuBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTableNrCandidPerLiceuBindingSource;
        private DataSet5DataPerFacultate dataSet5DataPerFacultate;
        private DataSet5DataPerFacultateTableAdapters.DataTableNrCandidPerLiceuTableAdapter dataTableNrCandidPerLiceuTableAdapter;
    }
}