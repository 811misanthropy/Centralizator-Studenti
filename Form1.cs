
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
            Hide();
            Form2.ShowDialog();
            Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4_Inregistrare_tranzactii Form4 = new Form4_Inregistrare_tranzactii();
            Hide();
            Form4.ShowDialog();
            Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3_Inmatriculare_Editare_Studenti Form3 = new Form3_Inmatriculare_Editare_Studenti();
            Hide();
            Form3.ShowDialog();
            Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5IstoricCandidati Form5 = new Form5IstoricCandidati();
            Hide();
            Form5.ShowDialog();
            Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6_VizualizareTaxe Form6 = new Form6_VizualizareTaxe();
            Hide();
            Form6.ShowDialog();
            Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7_Tranzactii_Report Form7 = new Form7_Tranzactii_Report();
            Hide();
            Form7.ShowDialog();
            Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form17_MeniuProfesor f17 = new Form17_MeniuProfesor();
            Hide();
            f17.ShowDialog();
            Show();
        }


        private void button9_Click(object sender, EventArgs e)
        {
            Form10_ViewActiExtra f10 = new Form10_ViewActiExtra();
            Hide();
            f10.ShowDialog();
            Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Form11_InputPrezentaActivitati f11 = new Form11_InputPrezentaActivitati();
            Hide();
            f11.ShowDialog();
            Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form12_RaportAdmitere f12 = new Form12_RaportAdmitere();
            Hide();
            f12.ShowDialog();
            Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form13_RaportPrezentaExtra f13 = new Form13_RaportPrezentaExtra();
            Hide();
            f13.ShowDialog();
            Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form14_RaportStructuraAn f14 = new Form14_RaportStructuraAn();
            Hide();
            f14.ShowDialog();
            Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form15_RaportStructuraGrupa f15 = new Form15_RaportStructuraGrupa();
            Hide(); 
            f15.ShowDialog();
            Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassGlobalVar.account = new ClassAccount("","","","","","Inactiv");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form22_ViewPersonalFacultate f22 = new Form22_ViewPersonalFacultate();
            Hide();
            f22.ShowDialog();
            Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form25NrStudentiPerAn f25 = new Form25NrStudentiPerAn();
            Hide();
            f25.ShowDialog();
            Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            Hide();
            f19.ShowDialog();
            Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form24ReportStudentiDupaOrigine f24 = new Form24ReportStudentiDupaOrigine();
            Hide();
            f24.ShowDialog();
            Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form26ViewLicee f26 = new Form26ViewLicee();
            Hide(); 
            f26.ShowDialog();
            Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Form29RaportAnualDiscipline f29 = new Form29RaportAnualDiscipline();
            Hide();
            f29.ShowDialog();
            Show();
        }
    }
}
