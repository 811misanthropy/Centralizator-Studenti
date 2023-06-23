using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace Centralizator_Studenti
{
    public partial class Form7_Tranzactii_Report : Form
    {
        public Form7_Tranzactii_Report()
        {
            InitializeComponent();
        }

        private void Form7_Tranzactii_Report_Load(object sender, EventArgs e)
        {}

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Clear();
                foreach(ClassCandidati cand in ClassGlobalVar.listCandid)
                {
                    if(cand._AnCandi.ToString() == textBox1.Text)
                    {
                        listBox1.Items.Add(cand);
                    }
                }
            }
            else
                MessageBox.Show("Introduceti anul academic!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 1)
            {
                this.dataTable1TableAdapter.Fill(this.dataSet2.DataTable1, (listBox1.SelectedItems[0] as ClassCandidati)._NrDosar);
                this.dataTable11TableAdapter.Fill(this.dataSet2.DataTable11, (listBox1.SelectedItems[0] as ClassCandidati)._NrDosar);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
