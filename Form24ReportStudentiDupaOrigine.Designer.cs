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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.dataTableNrCandidPerLiceuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet5DataPerFacultate = new Centralizator_Studenti.DataSet5DataPerFacultate();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTableNrCandidPerLiceuTableAdapter = new Centralizator_Studenti.DataSet5DataPerFacultateTableAdapters.DataTableNrCandidPerLiceuTableAdapter();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableNrCandidPerLiceuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).BeginInit();
            this.SuspendLayout();
            // 
            // dataTableNrCandidPerLiceuBindingSource
            // 
            this.dataTableNrCandidPerLiceuBindingSource.DataMember = "DataTableNrCandidPerLiceu";
            this.dataTableNrCandidPerLiceuBindingSource.DataSource = this.dataSet5DataPerFacultate;
            // 
            // dataSet5DataPerFacultate
            // 
            this.dataSet5DataPerFacultate.DataSetName = "DataSet5DataPerFacultate";
            this.dataSet5DataPerFacultate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.dataTableNrCandidPerLiceuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Centralizator_Studenti.Report12NrStudentiDupaProvenienta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(840, 561);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataTableNrCandidPerLiceuTableAdapter
            // 
            this.dataTableNrCandidPerLiceuTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(90, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alegeti un an:";
            // 
            // Form24ReportStudentiDupaOrigine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(864, 603);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form24ReportStudentiDupaOrigine";
            this.Text = "Form24ReportStudentiDupaOrigine";
            this.Load += new System.EventHandler(this.Form24ReportStudentiPerAnAcademic_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataTableNrCandidPerLiceuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource dataTableNrCandidPerLiceuBindingSource;
        private DataSet5DataPerFacultate dataSet5DataPerFacultate;
        private DataSet5DataPerFacultateTableAdapters.DataTableNrCandidPerLiceuTableAdapter dataTableNrCandidPerLiceuTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
    }
}