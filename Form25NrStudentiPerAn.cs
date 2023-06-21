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
    public partial class Form25NrStudentiPerAn : Form
    {
        public Form25NrStudentiPerAn()
        {
            InitializeComponent();
        }

        private void Form25NrStudentiPerAn_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet5DataPerFacultate.DataTableNrStudenti' table. You can move, or remove it, as needed.
            this.dataTableNrStudentiTableAdapter.Fill(this.dataSet5DataPerFacultate.DataTableNrStudenti);

            this.reportViewer1.RefreshReport();

        }
    }
}
