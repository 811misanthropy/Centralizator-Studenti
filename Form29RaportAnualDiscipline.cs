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
    public partial class Form29RaportAnualDiscipline : Form
    {
        public Form29RaportAnualDiscipline()
        {
            InitializeComponent();
        }

        private void Form29RaportAnualDiscipline_Load(object sender, EventArgs e)
        {
            foreach(ClassDiscipline dis in ClassGlobalVar.listDisci)
            {
                if(dis._AnAcaDisci != "" && !comboBox1.Items.Contains(dis._AnAcaDisci))
                {
                    comboBox1.Items.Add(dis._AnAcaDisci.ToString());
                }
                if(dis._AnStudDisci !="" && !comboBox2.Items.Contains(dis._AnStudDisci))
                {
                    comboBox2.Items.Add(dis._AnStudDisci.ToString());
                }
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Items.Contains(comboBox1.Text) && comboBox2.Items.Contains(comboBox2.Text))
            {
                dataTableRaportProfesorTableAdapter.Fill(dataSet5DataPerFacultate.DataTableRaportProfesor, comboBox1.Text, comboBox2.Text);
                this.reportViewer1.RefreshReport();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Items.Contains(comboBox1.Text) && comboBox2.Items.Contains(comboBox2.Text))
            {
                dataTableRaportProfesorTableAdapter.Fill(dataSet5DataPerFacultate.DataTableRaportProfesor, comboBox1.Text, comboBox2.Text);
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
