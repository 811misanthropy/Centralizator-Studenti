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
    public partial class Form24ReportStudentiDupaOrigine : Form
    {
        public Form24ReportStudentiDupaOrigine()
        {
            InitializeComponent();
        }

        private void Form24ReportStudentiPerAnAcademic_Load(object sender, EventArgs e)
        {
            foreach(ClassCandidati cand in ClassGlobalVar.listCandid)
            {
                if(cand._AnCandi != 0 && !comboBox1.Items.Contains(cand._AnCandi.ToString()))
                {
                    comboBox1.Items.Add(cand._AnCandi.ToString());
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Items.Contains(comboBox1.Text))
            {
                this.dataTableNrCandidPerLiceuTableAdapter.Fill(this.dataSet5DataPerFacultate.DataTableNrCandidPerLiceu, comboBox1.Text);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
