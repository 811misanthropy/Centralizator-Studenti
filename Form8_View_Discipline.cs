using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form8_View_Discipline : Form
    {
        bool nou = false;
        public Form8_View_Discipline()
        {
            InitializeComponent();
        }

        bool Verificare()
        {
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "") { MessageBox.Show("Campurile nu pot fi goale!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox2.Text, "cifre")) { MessageBox.Show("Puncte Credit: trebuie sa fie un numar intreg intre 1 si 10!"); return false; }
            if (int.Parse(textBox2.Text) < 1 || int.Parse(textBox2.Text) > 10) { MessageBox.Show("Puncte Credit: trebuie sa fie un numar intreg intre 1 si 10!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox5.Text, "cifre")) { MessageBox.Show("Numar Ore: trebuie sa fie un numar intreg intre 1 si 40!"); return false; }
            if (int.Parse(textBox5.Text) < 1 || int.Parse(textBox5.Text) > 10) { MessageBox.Show("Numar Ore: trebuie sa fie un numar intreg intre 1 si 40!"); return false; }
            if (textBox6.Text != "1" || textBox6.Text != "2" || textBox6.Text != "3") { MessageBox.Show("Anul Studentesc: poate fi doar 1, 2 sau 3!"); return false; }
            if (textBox7.Text != "1" || textBox7.Text != "2") { MessageBox.Show("Semestrul: poate fi doar 1 sau 2!"); return false; }
            if (int.TryParse(textBox4.Text, out int result)) { MessageBox.Show("Anul Academic: poate sa fie doar un numar intreg intre 1900 si 2300 inclusiv!"); return false; }
            if(int.Parse(textBox4.Text)<1900 || int.Parse(textBox4.Text)>2300){ MessageBox.Show("Anul Academic: poate sa fie doar un numar intreg intre 1900 si 2300 inclusiv!"); return false; }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            foreach(ClassDiscipline disci in ClassGlobalVar.listDisci)
            {
                if(textBox1.Text==disci._AnAcaDisci && disci._CF._IDCF == ClassGlobalVar.account._CompID)
                    listBox1.Items.Add(disci);
            }
            if (listBox1.Items.Count == 0)
                MessageBox.Show("Nu existe discipline inregistrate pentru anul academic cautat!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count > 0) 
            {
                textBox3.Text = (listBox1.SelectedItems[0] as ClassDiscipline)._DDenumire;
                textBox2.Text = (listBox1.SelectedItems[0] as ClassDiscipline)._PuncteCredit;
                textBox5.Text = (listBox1.SelectedItems[0] as ClassDiscipline)._NrOre;
                textBox4.Text = (listBox1.SelectedItems[0] as ClassDiscipline)._AnAcaDisci;
                textBox6.Text = (listBox1.SelectedItems[0] as ClassDiscipline)._AnStudDisci;
                textBox7.Text = (listBox1.SelectedItems[0] as ClassDiscipline)._SemStudDisci;
            }
        }
        //button activare
        private void button2_Click(object sender, EventArgs e)
        {

                button4.Enabled =button6.Enabled= true;
                button6.Visible = button4.Visible = true;

            
        }
        //button renunta
        private void button3_Click(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = false;
            button3.Visible = button4.Visible = button5.Visible = button4.Visible = false;
            textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = false;
            button2.Visible = button1.Visible = true;
            listBox1.Enabled = true;
        }
        //button editare
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                button1.Visible = button2.Visible = button4.Visible = button6.Visible = false;
                button3.Visible = button5.Visible = true;
                listBox1.Enabled = false;
                textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = true;

            }
            else
                MessageBox.Show("Pentru a putea edita selectati mai intai o disciplina deja existenta!");
        }
        //button nou
        private void button6_Click(object sender, EventArgs e)
        {
            button1.Visible = button2.Visible = button4.Visible = button6.Visible = false;
            button3.Visible = button5.Visible = true;
            listBox1.Enabled = false;
            textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled = true;
            textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = "";
            nou = true;
        }
        //button salvare
        private void button5_Click(object sender, EventArgs e)
        {
            if (Verificare())
            {
                ClassGlobalVar.connection.Open();
                if (nou == true)
                {
                    int m = int.Parse(ClassGlobalVar.listDisci[ClassGlobalVar.listDisci.Count() - 1]._IdDisciplna) + 1;
                    string query = $"INSERT INTO T_Discipline (IdDisciplina, DDenumire, PuncteCredit, NrOre, AnAcaDisci, AnStudDisci, SemStudDisci, FK_IDCF) VALUES ({m},'{textBox3.Text}',{textBox2.Text},{textBox5.Text},{textBox4.Text},{textBox6.Text},{textBox7.Text},{ClassGlobalVar.account._CompID})";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();
                    nou = false;
                }
                else
                {
                    string query = $"UPDATE T_Discipline SET DDenumire='{textBox3.Text}',PuncteCredit={textBox2.Text}," +
                                    $"NrOre={textBox5.Text}, AnAcaDisci={textBox4.Text}, AnStudDisci={textBox6.Text}, SemStudDisci={textBox7.Text} WHERE IdDisciplina={(listBox1.SelectedItems[0] as ClassDiscipline)._IdDisciplna};";
                    using (OleDbCommand comm = new OleDbCommand(query, ClassGlobalVar.connection))
                    {
                        comm.ExecuteNonQuery();
                    }
                    listBox1.Items.Clear();
                }
                ClassGlobalVar.connection.Close();
                ClassGlobalVar.InitializareDate();
                button3_Click(sender, e);
            }
        }
    }
}
