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
        string holdID = "";
        bool nou = false;
        public void Incarcare()
        {
            textBox2.Text = (listBox1.SelectedItem as ClassTaxe)._IDF;
            comboBox1.Text = (listBox1.SelectedItem as ClassTaxe)._Scop;
            textBox4.Text = (listBox1.SelectedItem as ClassTaxe)._AchStr;
        }

        bool Verificare()
        {
            
            if (textBox2.Text == "" || textBox4.Text=="" || comboBox1.Text == "") { MessageBox.Show("Campurile nu pot fi goale!"); return false; }
            if (!double.TryParse(textBox4.Text, out double result)) { MessageBox.Show("Valoarea Taxa: trebuie sa fie un numer mai mare decat 0 (egal in cazul bursei)!"); return false; }
            else if (double.Parse(textBox4.Text) < 0) { MessageBox.Show("Valoarea Taxa: trebuie sa fie un numer mai mare decat 0 (egal in cazul bursei)!"); return false; }
            if (!(comboBox1.SelectedIndex > -1)) { MessageBox.Show("Scopul: trebuie ales din campul specific!"); return false; }
            if (comboBox1.Text != comboBox1.SelectedItem.ToString()) { MessageBox.Show("Scopul: trebuie ales din camp!"); return false; }
            if (textBox2.Text.Length != 4) { MessageBox.Show("Anul Efect Taxei: Trebuie sa fie un an de la 1900 pana la 2300"); return false; }
            else if (!int.TryParse(textBox2.Text, out int result2)) { MessageBox.Show("Anul Efect Taxei: Trebuie sa fie un an de la 1900 pana la 2300"); return false; }
            else if (int.Parse(textBox2.Text)<1900 || int.Parse(textBox2.Text) > 2300) { MessageBox.Show("Anul Efect Taxei: Trebuie sa fie un an de la 1900 pana la 2300"); return false; }

            return true;
        }

        public Form6_VizualizareTaxe()
        {
            InitializeComponent();
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

        //button renunta
        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear(); textBox1.Clear(); textBox2.Clear(); comboBox1.Text =""; textBox4.Clear();
            button3.Visible = button4.Visible = button5.Visible = textBox2.Enabled = comboBox1.Enabled = textBox4.Enabled = false;

            button4.Visible = button6.Visible = textBox1.Enabled = button1.Enabled = listBox1.Enabled = true;
            holdID = "";
            nou = false;
        }
        //button edit
        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                Incarcare();
                holdID = (listBox1.SelectedItem as ClassTaxe)._ID;
                listBox1.Enabled = button1.Enabled = textBox1.Enabled = button4.Visible = button6.Visible = false;
                textBox2.Enabled =textBox4.Enabled = comboBox1.Enabled =button3.Visible = button5.Visible = true;
            }
            else
            {
                MessageBox.Show("Trebuie selectat un model de taxa pentru a putea fi editat!");
            }


        }
        //button salvare
        private void button5_Click(object sender, EventArgs e)
        {
            if (Verificare())
            {
                ClassGlobalVar.connection.Open();
                if (ClassGlobalVar.IsNumeric(textBox2.Text))
                {
                    if (comboBox1.Text == "" || textBox4.Text == "")
                    {
                        MessageBox.Show("Scopul si valoarea taxei nu pot fi nule!");
                    }
                    else
                    {

                        if (!nou)
                        {
                            //Editare T_ModeleDeTaxa
                            string query = $"UPDATE T_ModeleDeTaxa SET SumaDeAchitat='{textBox4.Text}',Scop='{comboBox1.Text}'," +
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
                                $"VALUES('{textBox4.Text}','{comboBox1.Text}','{textBox2.Text}');";

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

        //button nou
        private void button6_Click(object sender, EventArgs e)
        {
            button3.Visible = button5.Visible = true;
            button6.Visible = button4.Visible = false;
            textBox2.Enabled = textBox4.Enabled = comboBox1.Enabled = true;
            listBox1.Enabled = textBox1.Enabled = button1.Enabled = false;
            nou = true;
        }
    }
}
