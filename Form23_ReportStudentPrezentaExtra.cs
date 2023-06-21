using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form23_ReportStudentPrezentaExtra : Form
    {
        public Form23_ReportStudentPrezentaExtra()
        {
            InitializeComponent();
        }

        private void Form23_ReportStudentPrezentaExtra_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet4StudentReports.DataTable3' table. You can move, or remove it, as needed.
            this.dataTable3TableAdapter.Fill(this.dataSet4StudentReports.DataTable3, ClassGlobalVar.account._CompID);

            this.reportViewer1.RefreshReport();

        }
    }
}
