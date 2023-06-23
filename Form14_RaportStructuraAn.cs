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
    public partial class Form14_RaportStructuraAn : Form
    {
        public Form14_RaportStructuraAn()
        {
            InitializeComponent();
        }

        private void Form14_RaportStructuraAn_Load(object sender, EventArgs e)
        { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Items.Contains(comboBox1.Text))
            {
                // TODO: This line of code loads data into the 'dataSet1.DataTable3' table. You can move, or remove it, as needed.
                this.dataTable3TableAdapter.Fill(this.dataSet1.DataTable3, comboBox1.Text);

                this.reportViewer1.RefreshReport();
            }
        }
    }
}
