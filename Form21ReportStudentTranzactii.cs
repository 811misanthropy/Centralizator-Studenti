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
    public partial class Form21ReportStudentTranzactii : Form
    {
        public Form21ReportStudentTranzactii()
        {
            InitializeComponent();
        }

        private void Form21ReportStudentTranzactii_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet4StudentReports.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.dataSet4StudentReports.DataTable2, ClassGlobalVar.account._CompID);

            this.reportViewer1.RefreshReport();
        }
    }
}
