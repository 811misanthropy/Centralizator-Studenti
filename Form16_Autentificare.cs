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
                {                    
                    string[] a = ClassGlobalVar.account._Titlu.Split('.');
                    if (ClassGlobalVar.account._Titlu == "Student")
                    {
                        //Meniu Student
                        Form18_MeniuStudent f18 = new Form18_MeniuStudent();
                        f18.ShowDialog();
                    }
                    else if (ClassGlobalVar.account._Titlu == "Secretar")
                    {
                        //Meniu Secretariat
                        Form1 f1 = new Form1();
                        f1.ShowDialog();
                    }
                    else if (a[0] == "Decan")
                    {
                        //Meniu Decan
                        Form1 f1 = new Form1();
                        f1.ShowDialog();
                    }
                    else
                    {
                        //Meniu Profesor 
                        Form17_MeniuProfesor f17 = new Form17_MeniuProfesor();
                        f17.ShowDialog();
                    }
                }
                else
                    MessageBox.Show("Informatiile introduse nu sunt corecte!");
            }
            else
                MessageBox.Show("Completati campurile de autentificare!");            
        }
    }
}
