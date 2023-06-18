using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form3_Inmatriculare_Editare_Studenti : Form
    {
        public Form3_Inmatriculare_Editare_Studenti()
        {
            InitializeComponent();
        }

        public void Incarcare()
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            if (listBox1.SelectedItems.Count == 1)
            {
                foreach (ClassStudenti stud in ClassGlobalVar.listStud)
                {
                    if ((listBox1.SelectedItem as ClassCandidati)._NrDosar == stud._Candid._NrDosar)
                    {
                        textBox2.Text = "Inmatriculat";
                        textBox3.Text = stud._NrMatricol;
                        textBox4.Text = stud._AnStud;
                        textBox5.Text = stud._EmailInst;
                        textBox6.Text = stud._Grupa.ToString();
                        if (stud._StudActiv == "Activ")
                            radioButton1.Checked = true;
                        else
                            radioButton2.Checked = true;
                        break;
                    }
                }
                if (textBox2.Text == "")
                    textBox2.Text = "Neinmatriculat";
            }
            else
                textBox2.Text = "";
        }

        public bool VerificareInmatriculare(ClassCandidati cand, string str)
        {
            bool vf1=true , vf2=false ;
            foreach(ClassStudenti s in ClassGlobalVar.listStud)
            {
                if (s._Candid._NrDosar == cand._NrDosar)
                {
                    vf1 = false;
                    break;
                }
            }
            foreach(ClassTranzactii t in ClassGlobalVar.listTrans)
            {
                if(t._cand._NrDosar==cand._NrDosar && t._cand._AnCandi.ToString()==str && (t._tax._Scop=="Taxa completa"||t._tax._Scop=="Taxa prima transa"))
                {
                    vf2 = true; break;
                }
            }
            if (vf1==true && vf2==true)
                return true;
            else
                return false;
        }
        //buton cautare candidati/studenti
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (ClassCandidati cand in ClassGlobalVar.listCandid)
            {
                if (cand._AnCandi.ToString() == textBox1.Text)
                    listBox1.Items.Add(cand);
            }
            label8.Text = "Numar Candidati: "+listBox1.Items.Count.ToString();
            if(listBox1.Items.Count>0)
            {
                button6.Enabled = true;
            }
            else
                button6.Enabled=false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Incarcare();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Easter Egg!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                Incarcare();
            }
            else
                MessageBox.Show("Selectati un candidat!");
            listBox1.Enabled = button1.Enabled = button2.Enabled = true;
            textBox2.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = button3.Enabled = button4.Enabled = false;
            listBox2.Items.Clear();
            button1_Click(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "Inmatriculat" && listBox1.SelectedItems.Count == 1)
            {
                listBox1.Enabled = button1.Enabled = button2.Enabled = false;
                textBox2.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = button3.Enabled = button4.Enabled = true;
            }
            else
                MessageBox.Show("Selectati un candidat deja inmatriculat!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a;
            ClassGlobalVar.connection.Open();
            if (radioButton1.Checked == true)
                a = "Activ";
            else a = "Inactiv";
                string query = $"UPDATE T_Studenti SET An='{textBox4.Text}',EmailInstitutional='{textBox5.Text}'," +
                                $"Grupa='{textBox6.Text}', STUDActiv='{a}' WHERE NrMatricol='{textBox3.Text}';";
            using (OleDbCommand comm = new OleDbCommand(query, ClassGlobalVar.connection))
            {
                comm.ExecuteNonQuery();
            }
            listBox1.Items.Clear();
            ClassGlobalVar.connection.Close();
            ClassGlobalVar.InitializareDate();

            button1_Click(sender, e);
            button3_Click(sender, e);

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (uint.TryParse(textBox7.Text, out uint d))
            {
                if (int.Parse(textBox7.Text) > 0 && int.Parse(textBox7.Text) <= listBox1.Items.Count)
                {

                    for (int i = 0; i < int.Parse(textBox7.Text); i++)
                    {//Verificare medie + alfabetica
                        ClassCandidati cand = new ClassCandidati();
                        int k = -1;

                        
                        for (int j = 0; j < listBox1.Items.Count; j++)
                        {  
                            if(VerificareInmatriculare(listBox1.Items[j] as ClassCandidati,textBox1.Text))
                            {
                                if (cand._MedieFinala < (listBox1.Items[j] as ClassCandidati)._MedieFinala)
                                {
                                    k = j;
                                    cand = new ClassCandidati(listBox1.Items[j] as ClassCandidati);
                                }
                                else
                                    if (cand._MedieFinala == (listBox1.Items[j] as ClassCandidati)._MedieFinala)
                                {
                                    if (String.Compare((listBox1.Items[j] as ClassCandidati)._Nume, cand._Nume) < 0)
                                    {
                                        k = j;
                                        cand = new ClassCandidati(listBox1.Items[j] as ClassCandidati);
                                    }
                                    else
                                        if (String.Compare((listBox1.Items[j] as ClassCandidati)._Nume, cand._Nume) == 0)
                                    {
                                        if (String.Compare((listBox1.Items[j] as ClassCandidati)._Prenume, cand._Prenume) < 0)
                                        {
                                            k = j;
                                            cand = new ClassCandidati(listBox1.Items[j] as ClassCandidati);
                                        }
                                        else
                                            if (String.Compare((listBox1.Items[j] as ClassCandidati)._Prenume, cand._Prenume) == 0)
                                        {
                                            if (String.Compare((listBox1.Items[j] as ClassCandidati)._InitTata, cand._InitTata) < 0)
                                            {
                                                k = j;
                                                cand = new ClassCandidati(listBox1.Items[j] as ClassCandidati);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (k != -1)
                        {
                            listBox1.Items.Remove(listBox1.Items[k]);
                            listBox2.Items.Add(cand);
                        }
                        else
                        {
                            MessageBox.Show("Numarul tinta de studenti nu a fost atins!");
                            break;
                        }

                    }

                }
                else
                    MessageBox.Show("Numarul de studenti tinta trebuie sa se afle intre 1 si numarul de studenti din lista!");
                button6.Enabled =button1.Enabled = false;
                button5.Enabled = button3.Enabled = true;
                 
            }
            else
            {
                MessageBox.Show("In casuta trebuie scris un numar natural nenul!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.Items.Count > 0)
            {
                ClassGlobalVar.connection.Open();
                foreach (ClassCandidati cand in listBox2.Items)
                {
                    ClassStudenti stud = new ClassStudenti((int.Parse(ClassGlobalVar.listStud[ClassGlobalVar.listStud.Count - 1]._NrMatricol)+1).ToString(), cand);
                    ClassGlobalVar.listStud.Add(stud);
                    string query = $"INSERT INTO T_Studenti(NrMatricol, An, EmailInstitutional, Grupa, FK_NrDosar, STUDActiv) VALUES ('{stud._NrMatricol}','{stud._AnStud}','{stud._EmailInst}','{stud._Grupa}','{stud._Candid._NrDosar}','{stud._StudActiv}')";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();
                }
                listBox2.Items.Clear();
                ClassGlobalVar.connection.Close();

            }
            else
                MessageBox.Show("Nu exista candidati in lista de inmatriculare!");
        }

        private void Form3_Inmatriculare_Editare_Studenti_Load(object sender, EventArgs e)
        {

        }
    }
}
