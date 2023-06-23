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
    public partial class Form13_RaportPrezentaExtra : Form
    {
        public Form13_RaportPrezentaExtra()
        {
            InitializeComponent();
        }

        private void Form13_RaportPrezentaExtra_Load(object sender, EventArgs e)
        { }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                listBox1.Items.Clear();
                foreach(ClassActivitatiextra ae in ClassGlobalVar.listActExtr)
                {
                    if(ae._AnAcadAplicabil == textBox1.Text)
                        listBox1.Items.Add(ae);
                }
            }
            else
                MessageBox.Show("Introduceti anul academic in caseta!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 1)
            {
                this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1, (listBox1.SelectedItems[0] as ClassActivitatiextra)._IdActivExtra);
                this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2, (listBox1.SelectedItems[0] as ClassActivitatiextra)._IdActivExtra);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
