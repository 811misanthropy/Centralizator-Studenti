
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Centralizator_Studenti
{

    

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassGlobalVar.InitializareDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2_Inscrieri_Editare_Candidati Form2 = new Form2_Inscrieri_Editare_Candidati();
            Form2.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4_Inregistrare_tranzactii Form4 = new Form4_Inregistrare_tranzactii();
            Form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3_Inmatriculare_Editare_Studenti Form3 = new Form3_Inmatriculare_Editare_Studenti();
            Form3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5IstoricCandidati Form5 = new Form5IstoricCandidati();
            Form5.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6_VizualizareTaxe Form6 = new Form6_VizualizareTaxe();
            Form6.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7_Tranzactii_Report Form7 = new Form7_Tranzactii_Report();
            Form7.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8_View_Discipline f8 = new Form8_View_Discipline();
            f8.ShowDialog();
        }
    }
}
