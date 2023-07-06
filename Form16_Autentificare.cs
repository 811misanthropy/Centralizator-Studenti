using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public partial class Form16_Autentificare : Form
    {
        public Form16_Autentificare()
        {
            InitializeComponent();
        }

        private void Form16_Autentificare_Load(object sender, EventArgs e)
        {
            ClassGlobalVar.InitializareDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                foreach (ClassAccount acc in ClassGlobalVar.listAcc)
                {
                    if (acc._Email == textBox1.Text && acc._Pword == textBox2.Text)
                    {
                        ClassGlobalVar.account = new ClassAccount(acc);

                        break;
                    }
                }
                if (ClassGlobalVar.account._Email != "")
                {   if (ClassGlobalVar.account._Activ == "Activ")
                    {
                        string[] a = ClassGlobalVar.account._Titlu.Split('.');
                        if (ClassGlobalVar.account._Titlu == "Student")
                        {
                            //Meniu Student
                            Form18_MeniuStudent f18 = new Form18_MeniuStudent();
                            Hide();
                            f18.ShowDialog();
                            Show();
                        }
                        else if (ClassGlobalVar.account._Titlu == "Secretar")
                        {
                            //Meniu Secretariat
                            Form1 f1 = new Form1();
                            Hide();
                            f1.ShowDialog();
                            Show();
                        }
                        else if (a[0] == "Decan")
                        {
                            //Meniu Decan
                            Form1 f1 = new Form1();
                            Hide();
                            f1.ShowDialog();
                            Show();
                        }
                        else
                        {
                            //Meniu Profesor 
                            Form17_MeniuProfesor f17 = new Form17_MeniuProfesor();
                            Hide();
                            f17.ShowDialog();
                            Show();
                        }
                        textBox1.Text = textBox2.Text = "";
                    }
                    else
                        MessageBox.Show("Contul este dezactivat, adresativa administratorilor!");
                }
                else
                    MessageBox.Show("Informatiile introduse nu sunt corecte!");
            }
            else
                MessageBox.Show("Completati campurile de autentificare!");            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClassGlobalVar.account = new ClassAccount("4", "cd4@rau.ro", "CadDP4", "CadruDid4", "Decan.Conf.univ.dr.", "Activ");
            Form1 f1 = new Form1();
            Hide();
            f1.ShowDialog();
            Show();
        }
    }
}
