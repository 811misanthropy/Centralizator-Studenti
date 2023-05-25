using System;
using System.Collections;
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
    public partial class Form5IstoricCandidati : Form
    {
        public int ct = 0;

        //functie de Incarcare informatii
        public void Incarcare()
        {
            textBox6.Text = ((listBox1.SelectedItem) as ClassCandidati)._Telefon;
            textBox5.Text = ((listBox1.SelectedItem) as ClassCandidati)._Email;
            textBox26.Text = ((listBox1.SelectedItem) as ClassCandidati)._DataNastere;
            textBox3.Text = ((listBox1.SelectedItem) as ClassCandidati)._Sex;
            textBox2.Text = ((listBox1.SelectedItem) as ClassCandidati)._LiceuDenum;
            textBox23.Text = ((listBox1.SelectedItem) as ClassCandidati)._SerieDiploma;
            textBox25.Text = (((listBox1.SelectedItem) as ClassCandidati)._NrDiploma).ToString();
            textBox20.Text = (((listBox1.SelectedItem) as ClassCandidati)._FoaieMatricola).ToString();
            textBox22.Text = ((listBox1.SelectedItem) as ClassCandidati)._Profil;
            textBox18.Text = ((listBox1.SelectedItem) as ClassCandidati)._AnAbs;
            textBox21.Text = (((listBox1.SelectedItem) as ClassCandidati)._MedieBac).ToString();
            textBox19.Text = (((listBox1.SelectedItem) as ClassCandidati)._NotaSec).ToString();
            textBox8.Text = ((listBox1.SelectedItem) as ClassCandidati)._SerieBlt;
            textBox7.Text = (((listBox1.SelectedItem) as ClassCandidati)._NrBlt).ToString();
            textBox10.Text = ((listBox1.SelectedItem) as ClassCandidati)._CNP;
            textBox9.Text = ((listBox1.SelectedItem) as ClassCandidati)._Nationalitate;
            textBox14.Text = ((listBox1.SelectedItem) as ClassCandidati)._Tara;
            textBox13.Text = ((listBox1.SelectedItem) as ClassCandidati)._Judet;
            textBox12.Text = ((listBox1.SelectedItem) as ClassCandidati)._Localitate;
            textBox11.Text = ((listBox1.SelectedItem) as ClassCandidati)._Strada;
            textBox15.Text = (((listBox1.SelectedItem) as ClassCandidati)._NrStrada).ToString();
            textBox16.Text = ((listBox1.SelectedItem) as ClassCandidati)._CodPostal;
            textBox17.Text = ((listBox1.SelectedItem) as ClassCandidati)._BltElibDe;
            textBox27.Text = ((listBox1.SelectedItem) as ClassCandidati)._BltElibLa;
            textBox28.Text = ((listBox1.SelectedItem) as ClassCandidati)._BltExpLa;
        }
        public Form5IstoricCandidati()
        {
            InitializeComponent();
        }

        private void Form5IstoricCandidati_Load(object sender, EventArgs e){}

        private void button1_Click(object sender, EventArgs e)
        {
            //Incarcarea intrarilor din anul respectiv
            if(!ClassGlobalVar.IsNumeric(textBox1.Text) )
            {
                MessageBox.Show("Anul trebuie sa fie complet numeric, de 4 cifre si sa nu inceapa cu cifra 0!");
            }
            else
            {
                listBox1.Items.Clear();
                foreach(ClassCandidati cand in ClassGlobalVar.listCandid)
                {
                    if(cand._AnCandi == int.Parse(textBox1.Text))
                    {
                        listBox1.Items.Add(cand);
                    }
                }
                if(listBox1.Items.Count==0)
                {
                   MessageBox.Show("Nu exista candidati pentru anul selectat!");
                }
            }
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Incarcare();
        }
    }
}
