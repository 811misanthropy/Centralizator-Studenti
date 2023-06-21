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
    public partial class Form18_MeniuStudent : Form
    {
        public Form18_MeniuStudent()
        {
            InitializeComponent();
        }

        private void Form18_MeniuStudent_Load(object sender, EventArgs e)
        {
            label11.Text += ClassGlobalVar.account._Nume;
        }
        //vizualizare tranzactii student
        private void button1_Click(object sender, EventArgs e)
        {
            Form21ReportStudentTranzactii f21 = new Form21ReportStudentTranzactii();
            f21.ShowDialog();
        }
        //vizualizare note student
        private void button2_Click(object sender, EventArgs e)
        {
            Form20_RaportStudentNote f20 = new Form20_RaportStudentNote();
            f20.ShowDialog();
        }
        //vizualizare prezenta activitati extracuriculare student
        private void button3_Click(object sender, EventArgs e)
        {
            Form23_ReportStudentPrezentaExtra f23 = new Form23_ReportStudentPrezentaExtra();
            f23.ShowDialog();
        }
    }
}
