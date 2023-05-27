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
    public partial class Form9_SitAcademiceInput : Form
    {
        bool nou=false;
        public Form9_SitAcademiceInput()
        {
            InitializeComponent();
        }
        //button cauta studenti
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            foreach(ClassStudenti stud in ClassGlobalVar.listStud)
            {
                if(stud._AnStud==textBox1.Text)
                {
                    listBox2.Items.Add(stud);
                }
                
            }
            if (listBox2.Items.Count == 0)
            {
                MessageBox.Show("Nu au fost gasiti studenti pentru valoarea introdusa!");
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (listBox2.SelectedItems.Count == 1)
            {
                textBox2.Text = $"{(listBox2.SelectedItems[0] as ClassStudenti)._Candid._Nume} {(listBox2.SelectedItems[0] as ClassStudenti)._Candid._InitTata} {(listBox2.SelectedItems[0] as ClassStudenti)._Candid._Prenume}";
                int m = int.Parse((listBox2.SelectedItems[0] as ClassStudenti)._NrMatricol);
                foreach (ClassSituatiiAcademice sita in ClassGlobalVar.listSitAca)
                {
                    if(sita._Stud._NrMatricol==m.ToString())
                    if(sita._Stud._NrMatricol==m.ToString())
                            listBox1.Items.Add(sita);
                }
            }
            if(listBox1.Items.Count == 0)
            {
                MessageBox.Show("Nu exista situatii deja definite pentru studentul ales!");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 1)
            {
                textBox3.Text = $"{(listBox1.SelectedItems[0] as ClassSituatiiAcademice)._Discipline._DDenumire}";
                textBox4.Text = $"{(listBox1.SelectedItems[0] as ClassSituatiiAcademice)._NtFin}";
                textBox5.Text = $"{(listBox1.SelectedItems[0] as ClassSituatiiAcademice)._NrAbs}";
            }
        }
        //button edit
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                textBox4.Enabled = textBox5.Enabled = true;
                listBox1.Enabled = listBox2.Enabled = false;
                button3.Visible = button6.Visible = true;
                button4.Visible = button5.Visible = false;
            }
            else
                MessageBox.Show("Selectati prima data o situatie de editat!");
        }
        //button salvare
        private void button6_Click(object sender, EventArgs e)
        {
            ClassGlobalVar.connection.Open();
            if(nou==false)
            {
                string query = $"UPDATE T_SituatiiAcademice SET NotaFinala={textBox4.Text},NrAbsente={textBox5.Text}" +
                                $" WHERE CodInregistrare={(listBox1.SelectedItems[0] as ClassSituatiiAcademice)._CodInr};";
                using (OleDbCommand comm = new OleDbCommand(query, ClassGlobalVar.connection))
                {
                    comm.ExecuteNonQuery();
                }
            }
            else
            {
                string m = (listBox2.SelectedItems[0] as ClassStudenti)._NrMatricol;
                string n = (listBox3.SelectedItems[0] as ClassDiscipline)._IdDisciplna;
                string query = $"INSERT INTO T_SituatiiAcademice (FK_NrMatricol, FK_IdDisciplina, NotaFinala, NrAbsente) VALUES ({m},{n},{textBox4.Text},{textBox5.Text})";
                OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                oleDbCommand.ExecuteNonQuery();
            }
            ClassGlobalVar.connection.Close();
            ClassGlobalVar.InitializareDate();
            button3_Click(sender, e);
        }
        //button renunta
        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = button6.Visible = false; button4.Visible = button5.Visible = true;
            listBox1.Enabled = listBox2.Enabled = true; listBox3.Visible = button2.Visible = textBox6.Visible = false;
            textBox4.Enabled = textBox5.Enabled = false;
            nou = false;
            listBox2_SelectedIndexChanged(sender, e);
            textBox3.Text = textBox5.Text = textBox4.Text = textBox6.Text = "";
            listBox3.Items.Clear();
        }
        //button nou
        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItems.Count == 1)
            {
                nou = true;
                textBox3.Text = textBox5.Text = textBox4.Text = textBox6.Text = "";
                listBox3.Visible = button2.Visible = textBox6.Visible = true;
                textBox4.Enabled = textBox5.Enabled = true;
                listBox1.Enabled = listBox2.Enabled = false;
                button3.Visible = button6.Visible = true;
                button4.Visible = button5.Visible = false;
            }
            else
                MessageBox.Show("Selectati mai intai un student!");
        }
        //button cauta discipline
        private void button2_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            foreach(ClassDiscipline disci in ClassGlobalVar.listDisci)
            {
                if(disci._AnAcaDisci==textBox6.Text)
                {
                    listBox3.Items.Add(disci);
                }
            }
            if(listBox3.Items.Count == 0)
            {
                MessageBox.Show("Nu au fost gasite discipline inregistrate pentru anul introdus!");
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count == 1)
            {
                bool vf = true;
                string n = (listBox3.SelectedItems[0] as ClassDiscipline)._IdDisciplna;
                string m = (listBox2.SelectedItems[0] as ClassStudenti)._NrMatricol;
                foreach(ClassSituatiiAcademice sita in listBox1.Items)
                {
                    if(sita._Stud._NrMatricol==m && sita._Discipline._IdDisciplna==n)
                    {
                        vf = false;break;
                    }
                }
                if (vf==false)
                {
                    MessageBox.Show("Deja exista situatie creata pentru aceasta disciplina!");
                    button2_Click(sender, e);
                }
                else
                {
                    textBox3.Text = (listBox3.SelectedItems[0] as ClassDiscipline)._DDenumire;
                }
            }
        }
    }
}
