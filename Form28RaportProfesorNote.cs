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
    public partial class Form28RaportProfesorNote : Form
    {
        public Form28RaportProfesorNote()
        {
            InitializeComponent();
        }

        private void Form28RaportProfesorNote_Load(object sender, EventArgs e)
        {
            foreach (ClassDiscipline disc in ClassGlobalVar.listDisci)
            {
                if (ClassGlobalVar.account._CompID == disc._CF._IDCF && !comboBox2.Items.Contains(disc._AnAcaDisci))
                {
                    comboBox2.Items.Add(disc._AnAcaDisci);
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = (comboBox1.SelectedItem as ClassDiscipline)._IdDisciplna;
            this.dataTable1TableAdapter.Fill(this.dataSet6Profesor.DataTable1,a);

            this.reportViewer1.RefreshReport();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (ClassDiscipline disc in ClassGlobalVar.listDisci)
            {
                if (ClassGlobalVar.account._CompID == disc._CF._IDCF && disc._AnAcaDisci == comboBox2.SelectedItem as string)
                {
                    comboBox1.Items.Add(disc);
                }
            }
        }
    }
}
