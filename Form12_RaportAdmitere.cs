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
    public partial class Form12_RaportAdmitere : Form
    {
        public Form12_RaportAdmitere()
        {
            InitializeComponent();
        }

        private void Form12_RaportAdmitere_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet3.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet3.DataTable1, int.Parse(textBox1.Text));

            this.reportViewer1.RefreshReport();
        }
    }
}
