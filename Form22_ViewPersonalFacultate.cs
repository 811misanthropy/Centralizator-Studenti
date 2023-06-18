using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form22_ViewPersonalFacultate : Form
    {
        bool nou = false;
        public Form22_ViewPersonalFacultate()
        {
            InitializeComponent();
        }
        //functie incarcare linformatii din list box in form
        private void Incarcare()
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                textBox1.Text = (listBox1.SelectedItems[0] as ClassCadreFacultate)._CFNume;
                comboBox1.Text = (listBox1.SelectedItems[0] as ClassCadreFacultate)._CFTitlu;
                textBox2.Text = (listBox1.SelectedItems[0] as ClassCadreFacultate)._CFTelefon;
                textBox3.Text = (listBox1.SelectedItems[0] as ClassCadreFacultate)._CFEmail;
                textBox4.Text = (listBox1.SelectedItems[0] as ClassCadreFacultate)._CFPassw;
                if ((listBox1.SelectedItems[0] as ClassCadreFacultate)._Activ == "Activ")
                    radioButton1.Checked = true;
                else
                    radioButton2.Checked = true;
            }
        }

        //functie verificare pentru butonul salvare
        private bool Verificare()
        {
            if (radioButton1.Checked != radioButton2.Checked) { MessageBox.Show("Ati uitat sa bifati daca contul este activ sau nu!"); return false; }
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || comboBox1.Text == "") { MessageBox.Show("Toate casetele de informatii trebuie complatate!"); return false; }
            if(!comboBox1.Items.Contains(comboBox1.Text)) { MessageBox.Show("Titlul introdus trebuie selectat dintre cele inregistrate in camp!"); return false; }
            foreach(char c in textBox2.Text)
            {
                string a = "";
                a+= c;
                if(!int.TryParse(a,out int result))
                {
                    MessageBox.Show("Numarul de telefon poate sa contina doar cifre!");
                    return false;
                }
            }
            if (textBox4.Text.Length < 4) { MessageBox.Show("Parola nu poate fi mai scurta de 4 caractere!"); return false; }
            return true;
        }

        private void Form22_ViewPersonalFacultate_Load(object sender, EventArgs e)
        {
            foreach (ClassCadreFacultate cf in ClassGlobalVar.listCadre)
            {
                listBox1.Items.Add(cf);
            }
        }

        //button edit
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                if (!(listBox1.SelectedItems[0] as ClassCadreFacultate)._CFTitlu.Contains("Decan"))
                {
                    comboBox1.Enabled = true;
                    textBox1.Enabled = textBox3.Enabled = textBox2.Enabled = radioButton1.Enabled = radioButton2.Enabled = true;
                    button1.Visible = button2.Visible = listBox1.Enabled = false;
                    button3.Enabled = button4.Visible = textBox4.Visible = label5.Visible = true;
                    string[] d = (listBox1.SelectedItems[0] as ClassCadreFacultate)._CFTitlu.Split('.');
                    if (!(d[0]=="Secretar" || d[0] =="Asist" || d[0] == "Specialist"))
                        button6.Visible = true;
                }
                else
                    MessageBox.Show("Contul decan nu poate fi editat direct (mutati atributia altui cont mai intai, dupa mutati-o inapoi)!");                
            }
            else
                MessageBox.Show("Selectati mai intai un angajat!");
        }

        //select cadru
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Incarcare();
        }

        //button renunta
        private void button4_Click(object sender, EventArgs e)
        {
            button1.Visible = button2.Visible = listBox1.Enabled = true;
            button3.Visible = button4.Visible = textBox4.Visible = label5.Visible = button5.Visible = button6.Visible = false;
            textBox1.Enabled = textBox3.Enabled = textBox2.Enabled = radioButton1.Enabled = radioButton2.Enabled = comboBox1.Enabled = false;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox1.Text = ""; radioButton1.Checked = radioButton2.Checked = false;
            button6.Text = "Transfer Decan";
            if (listBox1.SelectedItems.Count == 1)
                listBox1_SelectedIndexChanged(sender,e);
        }

        //button nou
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = comboBox1.Text = ""; radioButton1.Checked = radioButton2.Checked = false;
            textBox1.Enabled = textBox3.Enabled = textBox2.Enabled = radioButton1.Enabled = radioButton2.Enabled = comboBox1.Enabled = true;
            button1.Visible = button2.Visible = listBox1.Enabled = false;
            button3.Enabled = button4.Visible = textBox4.Visible = label5.Visible = true;
            nou = true;
        }

        //button salvare
        private void button3_Click(object sender, EventArgs e)
        {
            if (Verificare())
            {
                ClassGlobalVar.connection.Open();
                string a;
                if (radioButton1.Checked == true)
                    a = "Activ";
                else
                    a = "Inactiv";
                if(nou)
                {
                    //inregistrare noua in baza de date
                    string d = (ClassGlobalVar.listCadre.Count()+1).ToString();
                    ClassCadreFacultate cf = new ClassCadreFacultate(d,textBox1.Text,comboBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text,a);
                    ClassGlobalVar.listCadre.Add(cf);
                    string query = $"Insert INTO T_CadreFacultate (CFNume,CFTitlu,CFTelefon,CFEmail,CFPassw,CFActiv) VALUES ('{cf._CFNume}','{cf._CFTitlu}','{cf._CFTelefon}','{cf._CFEmail}','{cf._CFPassw}','{cf._Activ}')";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();
                    listBox1.Items.Add(cf);
                    ClassAccount acc = new ClassAccount(d, cf._CFEmail, cf._CFPassw, cf._CFNume, cf._CFTitlu, cf._Activ);
                    ClassGlobalVar.listAcc.Add(acc);
                    ClassGlobalVar.connection.Close();
                    MessageBox.Show("Cadrul adaugat cu succes in baza de date!");
                }
                else
                {
                    //update in baza de date
                    string d = (listBox1.SelectedItems[0] as ClassCadreFacultate)._IDCF;
                    ClassCadreFacultate cfn = new ClassCadreFacultate(d, textBox1.Text, comboBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, a);
                    string query = $"UPDATE T_CadreFacultate SET CFNume='{cfn._CFNume}', CFTitlu='{cfn._CFTitlu}', CFTelefon = '{cfn._CFTelefon}', CFEmail ='{cfn._CFEmail}', CFPassw='{cfn._CFPassw}',CFActiv'{cfn._Activ}' WHERE IDCF = '{cfn._IDCF}';";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();
                    ClassGlobalVar.connection.Close();
                    ClassGlobalVar.InitializareDate();
                    listBox1.Items.Clear();
                    foreach (ClassCadreFacultate cf in ClassGlobalVar.listCadre)
                    {
                        listBox1.Items.Add(cf);
                    }
                    button4_Click(sender,e);
                    MessageBox.Show("Cadrul actualizat cu succes in baza de date!");
                }
                
            } 
        }

        //button transfer decan
        private void button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == "Transfer Decan")
            {
                MessageBox.Show("Pentru a confirma transferul pozitiei de decan va trebuii sa apasati pe butonul * de langa caseta titlu, apasati inca o data acest buton pentru a anula!");
                button5.Visible = true;
                button6.Text = "Anulare Transfer";
            }
            else
            {
                MessageBox.Show("Transferul pozitiei de decan a fost anulat!");
                button5.Visible = false;
                button6.Text = "Transfer Decan";
            }
        }

        //button * (confirmare transfer)
        private void button5_Click(object sender, EventArgs e)
        {
            ClassCadreFacultate cfdn = new ClassCadreFacultate((listBox1.SelectedItems[0] as ClassCadreFacultate));
            ClassCadreFacultate cfdv = new ClassCadreFacultate(cfdn);
            foreach(ClassCadreFacultate cf in listBox1.Items)
            {
                string[] d = cf._CFTitlu.Split('.');
                if (d[0] =="Decan")
                {
                    cfdv = new ClassCadreFacultate(cf);
                    break;
                }
            }
            if (cfdv._IDCF == cfdn._IDCF)
            {
                MessageBox.Show("Eroare imposibila DECANUL NU EXISTA pentru transfer decan!");
            }
            else
            {
                cfdn = new ClassCadreFacultate(cfdn._IDCF, cfdn._CFNume, "Decan." + cfdn._CFTitlu, cfdn._CFTelefon, cfdn._CFEmail, cfdn._CFPassw, cfdn._Activ);
                string[] f = cfdv._CFTitlu.Split();
                string b = "";
                for(int i =1; i<f.Length; i++)
                {
                    b += f[i];
                    if(i<f.Length-1)
                        b += ".";
                }
                cfdv = new ClassCadreFacultate(cfdv._IDCF,cfdv._CFNume,b,cfdv._CFTelefon,cfdv._CFEmail,cfdv._CFPassw,cfdv._Activ);

                ClassGlobalVar.connection.Open();
                string query = $"UPDATE T_CadreFacultate SET CFTitlu='{cfdv._CFTitlu}' WHERE IDCF = '{cfdv._IDCF}';";
                OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                oleDbCommand.ExecuteNonQuery();
                query = $"UPDATE T_CadreFacultate SET CFTitlu='{cfdn._CFTitlu}' WHERE IDCF = '{cfdn._IDCF}';";
                oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                oleDbCommand.ExecuteNonQuery();
                ClassGlobalVar.connection.Close();

                listBox1.Items.Clear();
                ClassGlobalVar.InitializareDate();
                foreach (ClassCadreFacultate cf in ClassGlobalVar.listCadre)
                {
                    listBox1.Items.Add(cf);
                }
                button4_Click(sender, e);
                MessageBox.Show("Pozitia de Decan a fost transferata cu succes!");

            }
        }
    }
}
