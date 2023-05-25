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
    public partial class Form4_Inregistrare_tranzactii : Form
    {
        public Form4_Inregistrare_tranzactii()
        {
            InitializeComponent();
        }

        private void Form4_Inregistrare_tranzactii_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(ClassGlobalVar.IsNumeric(textBox1.Text))
            {
                listBox1.Items.Clear();
                listBox3.Items.Clear();
                foreach(ClassCandidati c in ClassGlobalVar.listCandid)
                {
                    if (c._AnCandi.ToString() == textBox1.Text)
                        listBox1.Items.Add(c);
                }
            }else
            {
                MessageBox.Show("Anul nu a fost introdus corespunzator!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ClassGlobalVar.IsNumeric(textBox2.Text))
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                foreach (ClassTaxe t in ClassGlobalVar.listTax)
                {
                    if (t._IDF.ToString() == textBox2.Text)
                        listBox2.Items.Add(t);
                }
            }
            else
            {
                MessageBox.Show("Anul nu a fost introdus corespunzator!");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count>0&&listBox2.SelectedItems.Count>0)
            {
                listBox3.Items.Clear();
                foreach(ClassTranzactii t in ClassGlobalVar.listTrans)
                {
                    if(t._cand._NrDosar==(listBox1.SelectedItem as ClassCandidati)._NrDosar && t._tax._ID == (listBox2.SelectedItem as ClassTaxe)._ID)
                    {
                        listBox3.Items.Add(t);
                    }
                }
            }else
            {
                MessageBox.Show("Trebuie sa selectati inainte modelul de taxa si achitantul!");
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox3.SelectedItem != null)
            {
                textBox3.Text = ((listBox3.SelectedItem) as ClassTranzactii)._CodTranz;
                textBox4.Text = (listBox3.SelectedItem as ClassTranzactii)._IBAN;
                textBox5.Text = (listBox3.SelectedItem as ClassTranzactii)._Data;
                textBox6.Text = (listBox3.SelectedItem as ClassTranzactii)._Suma.ToString();
                comboBox1.Text = (listBox3.SelectedItem as ClassTranzactii)._AnStud;
            }
            else MessageBox.Show("Selected item null");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = comboBox1.Enabled=true;
            listBox3.Items.Clear();
            button7.Enabled =listBox3.Enabled=button3.Enabled=button4.Enabled= false;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox3.SelectedItems.Count > 0)
            {
                textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = comboBox1.Enabled = button6.Enabled = button5.Enabled = true;
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button7.Enabled = listBox1.Enabled = listBox2.Enabled = listBox3.Enabled = false;
            }
            else MessageBox.Show("Trebuie selectata o intrare pentru a putea fi editata!");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Enabled == true)
            {
                //insert T_Tranzactii
                string query = "INSERT INTO T_Tranzactii(CodTranzactie,IBAN,Data,Suma,FK_NrDosar,FK_Model,AnStudent)" +
                    "VALUES('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + (listBox1.SelectedItem as ClassCandidati)._NrDosar.ToString() + "','" + (listBox2.SelectedItem as ClassTaxe)._ID.ToString() + "'," +
                    "'" + comboBox1.Text + "');";

                OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                oleDbCommand.ExecuteNonQuery();
                textBox3.Enabled = false;
            }
            else
            {
                //update T_Tranzactii
                string qry = $"UPDATE T_Candidati SET IBAN = {textBox4.Text}, Data = {textBox5.Text}, Suma = {textBox6.Text}, FK_NrDosar = {(listBox1.SelectedItem as ClassCandidati)._NrDosar}, " +
                        $"FK_Model = {(listBox2.SelectedItem as ClassTaxe)._ID}, AnStudent = {comboBox1.Text} " +
                        $"WHERE CodTranzactie = {textBox3.Text}";
                using (OleDbCommand comm = new OleDbCommand(qry, ClassGlobalVar.connection))
                {
                    comm.ExecuteNonQuery();
                }
            }
            ClassGlobalVar.InitializareDate();
            listBox1.Items.Clear(); listBox2.Items.Clear(); listBox3.Items.Clear(); textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = comboBox1.Text= "";
            button1.Enabled =button2.Enabled=button3.Enabled=button4.Enabled= listBox1.Enabled = listBox2.Enabled = listBox3.Enabled =true;  textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); listBox2.Items.Clear(); listBox3.Items.Clear(); textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = comboBox1.Text = "";
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = listBox1.Enabled = listBox2.Enabled = listBox3.Enabled = true; button5.Enabled =button6.Enabled= textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = false;
        }
    }
}
