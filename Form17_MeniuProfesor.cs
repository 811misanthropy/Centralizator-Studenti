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
    public partial class Form17_MeniuProfesor : Form
    {
        public Form17_MeniuProfesor()
        {
            InitializeComponent();
        }

        private void Form17_MeniuProfesor_Load(object sender, EventArgs e)
        {
            label1.Text += ClassGlobalVar.account._Nume;
        }
        //button Discipline
        private void button1_Click(object sender, EventArgs e)
        {
            Form8_View_Discipline f8 = new Form8_View_Discipline();
            f8.ShowDialog();
        }
        //button Note
        private void button2_Click(object sender, EventArgs e)
        {
            Form9_SitAcademiceInput f9 = new Form9_SitAcademiceInput();
            f9.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form28RaportProfesorNote f28 = new Form28RaportProfesorNote();
            f28.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form27RaportProfesorPrezenta f27 = new Form27RaportProfesorPrezenta();
            f27.ShowDialog();
        }
    }
}
