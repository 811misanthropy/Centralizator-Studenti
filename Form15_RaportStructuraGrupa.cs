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
    public partial class Form15_RaportStructuraGrupa : Form
    {
        public Form15_RaportStructuraGrupa()
        {
            InitializeComponent();
        }

        private void Form15_RaportStructuraGrupa_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.DataTable4' table. You can move, or remove it, as needed.
            this.dataTable4TableAdapter.Fill(this.dataSet1.DataTable4, textBox1.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
