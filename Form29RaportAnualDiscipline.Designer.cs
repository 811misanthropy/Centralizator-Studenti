namespace Centralizator_Studenti
{
    partial class Form29RaportAnualDiscipline
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label1 = new System.Windows.Forms.Label();
            this.dataSet5DataPerFacultate = new Centralizator_Studenti.DataSet5DataPerFacultate();
            this.dataTableRaportProfesorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTableRaportProfesorTableAdapter = new Centralizator_Studenti.DataSet5DataPerFacultateTableAdapters.DataTableRaportProfesorTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRaportProfesorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(99, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(329, 12);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.dataTableRaportProfesorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Centralizator_Studenti.Report3RaportProfesor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(897, 644);
            this.reportViewer1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Anul Academic:";
            // 
            // dataSet5DataPerFacultate
            // 
            this.dataSet5DataPerFacultate.DataSetName = "DataSet5DataPerFacultate";
            this.dataSet5DataPerFacultate.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataTableRaportProfesorBindingSource
            // 
            this.dataTableRaportProfesorBindingSource.DataMember = "DataTableRaportProfesor";
            this.dataTableRaportProfesorBindingSource.DataSource = this.dataSet5DataPerFacultate;
            // 
            // dataTableRaportProfesorTableAdapter
            // 
            this.dataTableRaportProfesorTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Anul Studentesc:";
            // 
            // Form29RaportAnualDiscipline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(921, 695);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form29RaportAnualDiscipline";
            this.Text = "Form29RaportAnualDiscipline";
            this.Load += new System.EventHandler(this.Form29RaportAnualDiscipline_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet5DataPerFacultate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableRaportProfesorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dataTableRaportProfesorBindingSource;
        private DataSet5DataPerFacultate dataSet5DataPerFacultate;
        private DataSet5DataPerFacultateTableAdapters.DataTableRaportProfesorTableAdapter dataTableRaportProfesorTableAdapter;
        private System.Windows.Forms.Label label2;
    }
}