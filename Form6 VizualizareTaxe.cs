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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Centralizator_Studenti
{
    public partial class Form6_VizualizareTaxe : Form
    {
        public string holdID = "";
        public void Incarcare()
        {
            textBox2.Text = (listBox1.SelectedItem as ClassTaxe)._IDF;
            textBox3.Text = (listBox1.SelectedItem as ClassTaxe)._Scop;
            textBox4.Text = (listBox1.SelectedItem as ClassTaxe)._AchStr;
        }


        public Form6_VizualizareTaxe()
        {
            InitializeComponent();
        }

        private void Form6_VizualizareTaxe_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Incarcarea taxelor din anul respectiv
            if (!ClassGlobalVar.IsNumeric(textBox1.Text))
            {
                MessageBox.Show("Anul trebuie sa fie complet numeric, de 4 cifre si sa nu inceapa cu cifra 0!");
            }
            else
            {
                listBox1.Items.Clear();
                foreach (ClassTaxe tax in ClassGlobalVar.listTax)
                {
                    if (tax._IDF == textBox1.Text)
                    {
                        listBox1.Items.Add(tax);
                    }
                }
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("Nu exista taxe pentru anul selectat!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Activare metode de adaugare
            button3.Visible = button4.Visible = button5.Visible = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = true;

            button2.Enabled = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear();
            button3.Visible = button4.Visible = button5.Visible = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = false;

            button2.Enabled = textBox1.Enabled = button1.Enabled = listBox1.Enabled = true;
            holdID = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                Incarcare();
                holdID = (listBox1.SelectedItem as ClassTaxe)._ID;
                listBox1.Enabled = button1.Enabled = textBox1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Trebuie selectat un model de taxa pentru a putea fi editat!");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClassGlobalVar.connection.Open();
            if (ClassGlobalVar.IsNumeric(textBox2.Text))
            {
                if (textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Scopul si valoarea taxei nu pot fi nule!");
                }
                else {

                    if (holdID != "")
                    {
                        //Editare T_ModeleDeTaxa
                        string query = $"UPDATE T_ModeleDeTaxa SET SumaDeAchitat={textBox4.Text},Scop='{textBox3.Text}'," +
                            $"IndexFormat={textBox2.Text} WHERE CodFormat={holdID};";
                        using (OleDbCommand comm = new OleDbCommand(query, ClassGlobalVar.connection))
                        {
                            comm.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        //insert T_ModeleDeTaxa

                        string query = "INSERT INTO T_ModeleDeTaxa(SumaDeAchitat,Scop,IndexFormat)" +
                            $"VALUES('{textBox4.Text}','{textBox3.Text}','{textBox2.Text}');";

                        OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                        oleDbCommand.ExecuteNonQuery();

                    }
                    button3_Click(sender, e);
                    
                } 
             } 
            else MessageBox.Show("Anul nu a fost introdus corespunzator!");
            ClassGlobalVar.connection.Close();
            ClassGlobalVar.InitializareDate();
        }
    }
}
