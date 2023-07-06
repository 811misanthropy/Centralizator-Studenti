namespace Centralizator_Studenti
{
    partial class Form25NrStudentiPerAn
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
            this.dataTableNrStudentiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet5DataPerFacultate = new Centralizator_Studenti.DataSet5DataPerFacultate();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTableNrStudentiTableAdapter = new Centralizator_Studenti.DataSet5DataPerFacultateTableAdapters.DataTableNrStudentiTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableNrStudentiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTableNrStudentiBindingSource
            // 
            this.dataTableNrStudentiBindingSource.DataMember = "DataTableNrStudenti";
            this.dataTableNrStudentiBindingSource.DataSource = this.dataSet5DataPerFacultate;
            // 
            // dataSet5DataPerFacultate
            // 
            this.dataSet5DataPerFacultate.DataSetName = "DataSet5DataPerFacultate";
            this.dataSet5DataPerFacultate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableNrStudentiBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Centralizator_Studenti.Report10NrStudentiPerAnAcademic.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1175, 743);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataTableNrStudentiTableAdapter
            // 
            this.dataTableNrStudentiTableAdapter.ClearBeforeFill = true;
            // 
            // Form25NrStudentiPerAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1175, 743);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form25NrStudentiPerAn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form25NrStudentiPerAn";
            this.Load += new System.EventHandler(this.Form25NrStudentiPerAn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableNrStudentiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet5DataPerFacultate dataSet5DataPerFacultate;
        private System.Windows.Forms.BindingSource dataTableNrStudentiBindingSource;
        private DataSet5DataPerFacultateTableAdapters.DataTableNrStudentiTableAdapter dataTableNrStudentiTableAdapter;
    }
}