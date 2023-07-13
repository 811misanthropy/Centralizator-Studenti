using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form10_ViewActiExtra : Form
    {
        bool nou = false;
        bool Verificare (string[] a, string[] a2, string[] b, string[] b2)
        {
            if (int.Parse(a2[2]) > int.Parse(a[2]) && int.Parse(b2[2]) < int.Parse(b[2]))
                return true;
            if (int.Parse(a2[2]) > int.Parse(a[2]) && int.Parse(b2[2]) == int.Parse(b[2]) && int.Parse(b2[1]) < int.Parse(b[1]))
                return true;
            if (int.Parse(a2[2]) > int.Parse(a[2]) && int.Parse(b2[2]) == int.Parse(b[2]) && int.Parse(b2[1]) == int.Parse(b[1]) && int.Parse(b2[0]) <= int.Parse(b[0]))
                return true;

            if (int.Parse(a2[2]) == int.Parse(a[2]) && int.Parse(a2[1]) > int.Parse(a[1]) && int.Parse(b2[2]) < int.Parse(b[2]))
                return true;
            if (int.Parse(a2[2]) == int.Parse(a[2]) && int.Parse(a2[1]) > int.Parse(a[1]) && int.Parse(b2[2]) == int.Parse(b[2]) && int.Parse(b2[1]) < int.Parse(b[1]))
                return true;
            if (int.Parse(a2[2]) == int.Parse(a[2]) && int.Parse(a2[1]) > int.Parse(a[1]) && int.Parse(b2[2]) == int.Parse(b[2]) && int.Parse(b2[1]) == int.Parse(b[1]) && int.Parse(b2[0]) <= int.Parse(b[0]))
                return true;

            if (int.Parse(a2[2]) == int.Parse(a[2]) && int.Parse(a2[1]) == int.Parse(a[1]) && int.Parse(a2[0]) >= int.Parse(a[0]) && int.Parse(b2[2]) < int.Parse(b[2]))
                return true;
            if (int.Parse(a2[2]) == int.Parse(a[2]) && int.Parse(a2[1]) == int.Parse(a[1]) && int.Parse(a2[0]) >= int.Parse(a[0]) && int.Parse(b2[2]) == int.Parse(b[2]) && int.Parse(b2[1]) < int.Parse(b[1]))
                return true;
            if (int.Parse(a2[2]) == int.Parse(a[2]) && int.Parse(a2[1]) == int.Parse(a[1]) && int.Parse(a2[0]) >= int.Parse(a[0]) && int.Parse(b2[2]) == int.Parse(b[2]) && int.Parse(b2[1]) == int.Parse(b[1]) && int.Parse(b2[0]) <= int.Parse(b[0]))
                return true;

            return false;
        }

        bool Verificare2()
        {
            if ( textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text=="" || textBox7.Text=="" || textBox8.Text=="" ) { MessageBox.Show("Toate campurile trebuiesc completate!"); return false; }
            if (radioButton1.Checked != true && radioButton2.Checked != true && radioButton3.Checked != true) { MessageBox.Show("Tipul activitatii trebuie selectat!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox2.Text, "data") || ClassGlobalVar.VerificareProt(textBox3.Text, "data")) { MessageBox.Show("Data de start si data de final ale evenimetului trebuie sa fie pe formatul \"zz/ll/aaaa\"!"); return false; }
            if (textBox8.Text != "1" && textBox2.Text != "2") { MessageBox.Show("Semestrul poate sa fie doar 1 sau 2!"); return false; }
            if (textBox7.Text.Length != 4) { MessageBox.Show("Anul Academic Aplicabil: Trebuie sa fie un an de la 1900 pana la 2300"); return false; }
            else if (!int.TryParse(textBox7.Text, out int result2)) { MessageBox.Show("Anul Academic Aplicabil: Trebuie sa fie un an de la 1900 pana la 2300"); return false; }
            else if (int.Parse(textBox7.Text) < 1900 || int.Parse(textBox7.Text) > 2300) { MessageBox.Show("Anul Academic Aplicabil: Trebuie sa fie un an de la 1900 pana la 2300"); return false; }

            return true;
        }

        public Form10_ViewActiExtra()
        {
            InitializeComponent();
        }
        //button cauta in interval
        private void button5_Click(object sender, EventArgs e)
        {
            if(textBox5.Text!="" && textBox6.Text!="")
            {
                if (!ClassGlobalVar.VerificareProt(textBox5.Text, "data") && !ClassGlobalVar.VerificareProt(textBox6.Text, "data"))
                {
                    listBox1.Items.Clear();
                    string[] a = textBox5.Text.Split('/');
                    string[] b = textBox6.Text.Split('/');
                    foreach (ClassActivitatiextra acte in ClassGlobalVar.listActExtr)
                    {
                        string[] a2 = acte._DataStart.Split('/');
                        string[] b2 = acte._DataEnd.Split('/');
                        if (Verificare(a, a2, b, b2))
                        {
                            listBox1.Items.Add(acte);
                        }
                    }

                }
                else
                    MessageBox.Show("Datele de cautare introduse nu corespund criteriului (\"zz/ll/aaaa\")!");
            }
            else
            {
                MessageBox.Show("Completati ambele capete ale intervalului!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1) 
            {
                textBox1.Text = (listBox1.SelectedItems[0] as ClassActivitatiextra)._AEDenumire;
                textBox2.Text = (listBox1.SelectedItems[0] as ClassActivitatiextra)._DataStart;
                textBox3.Text = (listBox1.SelectedItems[0] as ClassActivitatiextra)._DataEnd;
                textBox4.Text = (listBox1.SelectedItems[0] as ClassActivitatiextra)._Org;
                switch((listBox1.SelectedItems[0] as ClassActivitatiextra)._Tip)
                {
                    case "Activitate Extracuriculara": 
                        radioButton2.Checked = true;
                        break;
                    case "Sesiune de Comunicari":
                        radioButton1.Checked = true;
                        break;
                    case "Curs cu profesori straini":
                        radioButton3.Checked = true;
                        break;
                }
                textBox7.Text = (listBox1.SelectedItems[0] as ClassActivitatiextra)._AnAcadAplicabil;
                textBox8.Text = (listBox1.SelectedItems[0] as ClassActivitatiextra)._SemAE;
            }
        }
        //button edit
        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 1)
            {
                button1.Visible = button4.Visible = true;
                button2.Visible = button3.Visible = false;
                textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox7.Enabled = textBox8.Enabled = radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = true;
                textBox5.Enabled = textBox6.Enabled = button5.Enabled = listBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Alegeti prima data un eveniment!");
            }
        }
        //button renunta
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = button4.Visible = false;
            button2.Visible = button3.Visible = true;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox7.Enabled = textBox8.Enabled = radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = false;
            textBox5.Enabled = textBox6.Enabled = button5.Enabled = listBox1.Enabled = true;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox7.Text = textBox8.Text = "";
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
            button5_Click(sender, e);
        }
        //button nou
        private void button3_Click(object sender, EventArgs e)
        {
            nou = true;
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox7.Text = textBox8.Text = "";
            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false;
            button1.Visible = button4.Visible = true;
            button2.Visible = button3.Visible = false;
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox7.Enabled = textBox8.Enabled = radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = true;
            textBox5.Enabled = textBox6.Enabled = button5.Enabled = listBox1.Enabled = false;
        }
        //button salvare
        private void button4_Click(object sender, EventArgs e)
        {
            if (Verificare2())
            {
                ClassGlobalVar.connection.Open();
                string m = "";
                if (radioButton1.Checked)
                    m = "Sesiune de Comunicari";
                if (radioButton2.Checked)
                    m = "Activitate Extracuriculara";
                if (radioButton3.Checked)
                    m = "Curs cu profesori straini";
                if (nou == true)
                {
                    string query = $"INSERT INTO T_ActivitatiExtracuriculare (AEDenumire, DataS, DataE, Organizator, Tip, AnAcadAplicabil, SemAE) " +
                        $"VALUES ('{textBox1.Text}','{textBox2.Text}','{textBox3.Text}','{textBox4.Text}','{m}',{textBox7.Text},{textBox8.Text});";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();
                }
                else
                {
                    string n = (listBox1.SelectedItems[0] as ClassActivitatiextra)._IdActivExtra;
                    string query = $"UPDATE T_ActivitatiExtracuriculare SET AEDenumire='{textBox1.Text}', DataS='{textBox2.Text}', DataE='{textBox3.Text}', Organizator='{textBox4.Text}', Tip='{m}', AnAcadAplicabil={textBox7.Text}, SemAE={textBox8.Text} WHERE " +
                        $"IdActivExtra = {n};";
                    using (OleDbCommand comm = new OleDbCommand(query, ClassGlobalVar.connection))
                    {
                        comm.ExecuteNonQuery();
                    }
                }
                ClassGlobalVar.connection.Close();
                ClassGlobalVar.InitializareDate();
                nou = false;
                button1_Click(sender, e);
            }
        }


    }
}
