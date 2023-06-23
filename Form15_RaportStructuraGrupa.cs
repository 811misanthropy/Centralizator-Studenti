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
            foreach(ClassStudenti stud in ClassGlobalVar.listStud)
            {
                if(stud._Grupa!=0 && stud._Grupa!=999 && !comboBox1.Items.Contains(stud._Grupa))
                {
                    comboBox1.Items.Add(stud._Grupa.ToString());
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Items.Contains(comboBox1.Text))
            {
                this.dataTable4TableAdapter.Fill(this.dataSet1.DataTable4, comboBox1.Text);

                this.reportViewer1.RefreshReport();
            }    
        }
    }
}
