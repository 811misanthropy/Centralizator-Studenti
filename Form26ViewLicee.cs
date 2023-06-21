using Microsoft.ReportingServices.Diagnostics.Internal;
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
    public partial class Form26ViewLicee : Form
    {
        ClassTemplateList<ClassLicee> listlicee = new ClassTemplateList<ClassLicee> ();
        int lastIndex = 1;
        bool nou = false;
        public Form26ViewLicee()
        {
            InitializeComponent();
        }

        void IncarcareLista()
        {
            listlicee.Clear();
            ClassGlobalVar.connection.Open();
            string query = "Select CodLiceu, Denumire, Adresa from T_Licee order by CodLiceu ASC;";
            OleDbCommand command = new OleDbCommand(query, ClassGlobalVar.connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClassLicee cl = new ClassLicee(reader["CodLiceu"].ToString(), reader["Denumire"].ToString(), reader["Adresa"].ToString());
                listlicee.Add(cl);
                listBox1.Items.Add(cl);
                lastIndex = lastIndex + 1;
            }
            reader.Close();
            ClassGlobalVar.connection.Close();
        }

        bool VerificareSalvare()
        {
            if (textBox1.Text == "" || textBox2.Text == "") { MessageBox.Show("Campurile nu pot fi goale"); return false; }
            return true;
        }

        private void Form26ViewLicee_Load(object sender, EventArgs e)
        {
            IncarcareLista();
        }
        //button edit
        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 1)
            {
                textBox1.Enabled = textBox2.Enabled = button3.Visible = button4.Visible = true;
                button1.Visible = button2.Visible = listBox1.Enabled = false;
            }
            else
                MessageBox.Show("Selectati mai intai un liceu din lista!");
        }
        //button renunta
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = textBox2.Enabled = button3.Visible = button4.Visible = false;
            button1.Visible = button2.Visible = listBox1.Enabled = true;
            nou = false;
            listBox1_SelectedIndexChanged(sender,e);
        }
        //select liceu
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedItems.Count == 1)
            {
                textBox1.Text = (listBox1.SelectedItems[0] as ClassLicee)._denumire;
                textBox2.Text = (listBox1.SelectedItems[0] as ClassLicee)._adresa;
            }
            else
            {
                textBox1.Text = textBox2.Text = "";
            }
        }
        //button nou
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = textBox2.Enabled = button3.Visible = button4.Visible = true;
            button1.Visible = button2.Visible = listBox1.Enabled = false;
            textBox1.Text = textBox2.Text = "";
            nou = true;
        }
        //button salvare
        private void button4_Click(object sender, EventArgs e)
        {
            if(VerificareSalvare())
            {
                ClassGlobalVar.connection.Open();
                string query = "";
                if(nou)
                {
                    //inregistrare noua
                    query = $"INSERT INTO T_Licee (Denumire, Adresa) VALUES ('{textBox1.Text}','{textBox2.Text}');";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();

                    nou = false;
                }
                else
                {
                    //update
                    query = $"UPDATE T_Licee SET Denumire='{textBox1.Text}', Adresa='{textBox2.Text}' Where CodLiceu = {(listBox1.SelectedItems[0] as ClassLicee)._index};";
                    OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                    oleDbCommand.ExecuteNonQuery();

                }
                ClassGlobalVar.connection.Close();
                ClassGlobalVar.InitializareDate();
                IncarcareLista();
                button3_Click(sender, e);
            }

        }
    }
}
