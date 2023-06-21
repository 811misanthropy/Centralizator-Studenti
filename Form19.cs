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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }

        private void Form19_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet5DataPerFacultate.DataTableCastiguriAnuale' table. You can move, or remove it, as needed.
            this.dataTableCastiguriAnualeTableAdapter.Fill(this.dataSet5DataPerFacultate.DataTableCastiguriAnuale);

            this.reportViewer1.RefreshReport();
        }
    }
}
