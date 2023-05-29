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
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1, textBox1.Text);
            // TODO: This line of code loads data into the 'dataSet1.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.dataSet1.DataTable2, textBox1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
