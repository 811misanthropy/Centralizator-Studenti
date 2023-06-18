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
    public partial class Form20_RaportStudentNote : Form
    {
        public Form20_RaportStudentNote()
        {
            InitializeComponent();
        }

        private void Form20_RaportStudentNote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet4StudentReports.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet4StudentReports.DataTable1, ClassGlobalVar.account._CompID);

            this.reportViewer1.RefreshReport();
        }
    }
}
