﻿namespace Centralizator_Studenti
{
    partial class Form19
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
            this.dataTableCastiguriAnualeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableCastiguriAnualeTableAdapter = new Centralizator_Studenti.DataSet5DataPerFacultateTableAdapters.DataTableCastiguriAnualeTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableCastiguriAnualeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.dataTableCastiguriAnualeBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Centralizator_Studenti.Report11IncomePerAnAcademic.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(631, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSet5DataPerFacultate
            // 
            this.dataSet5DataPerFacultate.DataSetName = "DataSet5DataPerFacultate";
            this.dataSet5DataPerFacultate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableCastiguriAnualeBindingSource
            // 
            this.dataTableCastiguriAnualeBindingSource.DataMember = "DataTableCastiguriAnuale";
            this.dataTableCastiguriAnualeBindingSource.DataSource = this.dataSet5DataPerFacultate;
            // 
            // dataTableCastiguriAnualeTableAdapter
            // 
            this.dataTableCastiguriAnualeTableAdapter.ClearBeforeFill = true;
            // 
            // Form19
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form19";
            this.Text = "Form19_RaportStudentTaxe";
            this.Load += new System.EventHandler(this.Form19_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableCastiguriAnualeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSet5DataPerFacultate dataSet5DataPerFacultate;
        private System.Windows.Forms.BindingSource dataTableCastiguriAnualeBindingSource;
        private DataSet5DataPerFacultateTableAdapters.DataTableCastiguriAnualeTableAdapter dataTableCastiguriAnualeTableAdapter;
    }
}