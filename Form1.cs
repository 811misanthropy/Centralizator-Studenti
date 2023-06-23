
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
            string[] a = ClassGlobalVar.account._Titlu.Split('.');
            label11.Text += ClassGlobalVar.account._Nume;
            if (a[0] == "Decan")
            {
                button15.Visible = true;
                button7.Visible = true;
            }
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
            Form17_MeniuProfesor f17 = new Form17_MeniuProfesor();
            f17.ShowDialog();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Form10_ViewActiExtra f10 = new Form10_ViewActiExtra();
            f10.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form11_InputPrezentaActivitati f11 = new Form11_InputPrezentaActivitati();
            f11.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form12_RaportAdmitere f12 = new Form12_RaportAdmitere();
            f12.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form13_RaportPrezentaExtra f13 = new Form13_RaportPrezentaExtra();
            f13.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form14_RaportStructuraAn f14 = new Form14_RaportStructuraAn();
            f14.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form15_RaportStructuraGrupa f15 = new Form15_RaportStructuraGrupa();
            f15.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassGlobalVar.account = new ClassAccount("","","","","","Inactiv");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form22_ViewPersonalFacultate f22 = new Form22_ViewPersonalFacultate();
            f22.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form25NrStudentiPerAn f25 = new Form25NrStudentiPerAn();
            f25.ShowDialog();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            f19.ShowDialog();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form24ReportStudentiDupaOrigine f24 = new Form24ReportStudentiDupaOrigine();
            f24.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form26ViewLicee f26 = new Form26ViewLicee();
            f26.ShowDialog();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form29RaportAnualDiscipline f29 = new Form29RaportAnualDiscipline();
            f29.ShowDialog();
        }
    }
}
