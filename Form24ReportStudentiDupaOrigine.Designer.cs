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
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableNrCandidPerLiceuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Centralizator_Studenti.Report12NrStudentiDupaProvenienta.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(16, 48);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1119, 690);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataTableNrCandidPerLiceuTableAdapter
            // 
            this.dataTableNrCandidPerLiceuTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(120, 15);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 24);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Alegeti un an:";
            // 
            // Form24ReportStudentiDupaOrigine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1152, 742);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.reportViewer1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form24ReportStudentiDupaOrigine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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