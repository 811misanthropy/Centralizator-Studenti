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
    public partial class Form27RaportProfesorPrezenta : Form
    {
        public Form27RaportProfesorPrezenta()
        {
            InitializeComponent();
        }

        private void Form27RaportProfesorPrezenta_Load(object sender, EventArgs e)
        {
            foreach(ClassDiscipline disc in ClassGlobalVar.listDisci)
            {
                if(ClassGlobalVar.account._CompID==disc._CF._IDCF)
                {
                    comboBox1.Items.Add(disc);
                }
            }


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = (comboBox1.SelectedItem as ClassDiscipline)._IdDisciplna;
            // TODO: This line of code loads data into the 'dataSet6Profesor.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.dataSet6Profesor.DataTable1,a);
            this.reportViewer1.RefreshReport();
        }
    }
}
