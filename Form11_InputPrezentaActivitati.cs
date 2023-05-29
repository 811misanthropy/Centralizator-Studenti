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
    public partial class Form11_InputPrezentaActivitati : Form
    {
        public Form11_InputPrezentaActivitati()
        {
            InitializeComponent();
        }
        //button cauta studenti
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox3.Items.Clear();
            if (textBox1.Text != "")
            {
                foreach (ClassStudenti stud in ClassGlobalVar.listStud)
                {
                    if (stud._AnStud == textBox1.Text)
                    {
                        listBox1.Items.Add(stud);
                    }
                }
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Nu au fost gasiti studenti in anul introdus!");
                }
            }
            else
                MessageBox.Show("Introduceti mai intai un an!");
        }
        //button cauta activitati
        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            if (textBox2.Text != "")
            {
                foreach (ClassActivitatiextra act in ClassGlobalVar.listActExtr)
                {
                    if (act._AnAcadAplicabil == textBox2.Text)
                    {
                        listBox2.Items.Add(act);
                    }
                }
                if (listBox2.Items.Count == 0)
                {
                    MessageBox.Show("Nu exista activitati inregistrate pentru anul introdus!");
                }
            }
            else
                MessageBox.Show("Introduceti mai intai un an academic!");
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 1)
            {
                string m = (listBox1.SelectedItems[0] as ClassStudenti)._NrMatricol;
                listBox3.Items.Clear();
                foreach(ClassPrezentaExtra pre in ClassGlobalVar.listPrExtr)
                {
                    if(pre._stud._NrMatricol == m)
                    {
                        listBox3.Items.Add(pre);
                    }
                }
                if(listBox3.Items.Count == 0)
                {
                    MessageBox.Show("Studentul selectat nu are prezente inregistrate!");
                }
            }
        }
        //button prezent
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1 && listBox2.SelectedItems.Count == 1)
            {
                string m = (listBox1.SelectedItems[0] as ClassStudenti)._NrMatricol;
                string n = (listBox2.SelectedItems[0] as ClassActivitatiextra)._IdActivExtra;
                bool a = false;
                foreach(ClassPrezentaExtra pre in listBox3.Items)
                {
                    if(pre._stud._NrMatricol==m && pre._AcEx._IdActivExtra == n)
                    {
                        a = true; break;
                    }
                }
                if (a == false)
                {
                    ClassGlobalVar.connection.Open();
                    string query = $"Insert into T_PrezentaExtra (FK_IdActivExtra, FK_NrMatricol) VALUES ({n},{m});";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();
                    ClassGlobalVar.connection.Close();
                    ClassGlobalVar.InitializareDate();
                    listBox1_SelectedIndexChanged(sender, e);
                }
                else
                    MessageBox.Show("Studentul are deja prezenta inregistrata la evenimentul respectiv!");
            }
            else
                MessageBox.Show("Selectati mai intai un student si o activitate!");
        }
        //buttonul sterge prezenta
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count == 1)
            {
                string m = (listBox3.SelectedItems[0] as ClassPrezentaExtra)._codP;
                ClassGlobalVar.connection.Open();
                string query = $"Delete from T_PrezentaExtra where CodPrezenta={m};";
                OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                oleDbCommand.ExecuteNonQuery();
                ClassGlobalVar.connection.Close();
                ClassGlobalVar.InitializareDate();
                listBox1_SelectedIndexChanged(sender, e);
            }
            else
                MessageBox.Show("Selectati o prezenta mai intai pentru a o sterge!");
        }
    }
}
