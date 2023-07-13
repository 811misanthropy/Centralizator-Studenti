using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Threading;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;

namespace Centralizator_Studenti
{
    public partial class Form2_Inscrieri_Editare_Candidati : Form
    {
        public bool CheckForNrDosar(string nrDos)
        {
            foreach(ClassCandidati cd in ClassGlobalVar.listCandid)
            {
                if (cd._NrDosar == nrDos)
                    return true;
            }
            return false;
        }


        //functie de verificare la scrierea in bza de date
        bool Verificare()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "" || textBox11.Text == "" || textBox12.Text == "" || textBox13.Text == "" || textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "" || textBox18.Text == "" || textBox19.Text == "" || textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "" || textBox23.Text == "" || textBox24.Text == "" || textBox25.Text == "" || textBox26.Text == "" || textBox27.Text == "" || textBox28.Text == "") { MessageBox.Show("Campurile nu pot fi goale!"); return false; }
            if (radioButton1.Checked==false && radioButton2.Checked==false && radioButton3.Checked==false) { MessageBox.Show("Genul candidatului trbuie mentionat!"); return false; }
            if (listBox1.SelectedItems.Count != 1) { MessageBox.Show("Trebuie selectat un liceu!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox6.Text, "telefon")) { MessageBox.Show("Telefon: trebuie sa fie format din 10 cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox10.Text, "CNP")) { MessageBox.Show("CNP: trebuie sa fie format din 13 cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox26.Text, "data")) { MessageBox.Show("Data Nastere: trebuie sa fie \n dupa formatul \"ZZ\\MM\\YYYY\"!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox27.Text, "data")) { MessageBox.Show("Buletin Eliberat La: trebuie sa fie \n dupa formatul \"ZZ\\MM\\YYYY\"!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox28.Text, "data")) { MessageBox.Show("Buletin Expira La: trebuie sa fie \n dupa formatul \"ZZ\\MM\\YYYY\"!"); return false; }
            if (!(textBox5.Text.Contains("@"))) { MessageBox.Show("Adresa de E-mail trebuie sa contina @!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox2.Text + textBox3.Text + textBox4.Text, "litere")) { MessageBox.Show("Numele candidatului nu poate contine cifre"); return false; }
            if (!(textBox3.Text.Contains("."))) { MessageBox.Show("Initiala nu este corespunzatoare!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox8.Text,"litere")) { MessageBox.Show("Buletin Serie: nu poate contine cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox7.Text, "cifre")) { MessageBox.Show("Buletin Numar: nu poate contine litere!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox9.Text,"litere")) { MessageBox.Show("Buletin Nationaliate: nu poate contine cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox14.Text, "litere")) { MessageBox.Show("Buletin Tara: nu poate contine cifre!"); return false;  }
            if (ClassGlobalVar.VerificareProt(textBox15.Text, "cifre")) { MessageBox.Show("Buletin Numar Strada: poate contine doar cifre!"); return false;  }
            if (ClassGlobalVar.VerificareProt(textBox16.Text, "cifre")) { MessageBox.Show("Buletin Cod Postal: poate contine doar cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox23.Text, "litere")) { MessageBox.Show("Serie Diploma: nu poate contine cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox25.Text, "cifre")) { MessageBox.Show("Numar Diploma: poate contine doar cifre!"); return false; }
            if (!double.TryParse(textBox21.Text, out double result)) { MessageBox.Show("Media Bac: Trebuie sa fie un numar intreg \n de la 6 pana la 10 inclusiv!"); return false; }
            else
                if (double.Parse(textBox21.Text) < 6 || double.Parse(textBox21.Text) > 10) { MessageBox.Show("Media Bac: Trebuie sa fie un numar intreg \n de la 6 pana la 10 inclusiv!"); return false; }
            if (!double.TryParse(textBox19.Text, out double result2)) { MessageBox.Show("Nota Secundara: Trebuie sa fie un numar intreg \n de la 6 pana la 10 inclusiv!"); return false; }
            else
                if (double.Parse(textBox19.Text) < 6 || double.Parse(textBox19.Text) > 10) { MessageBox.Show("Nota Secundara: Trebuie sa fie un numar intreg \n de la 6 pana la 10 inclusiv!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox20.Text, "cifre")) { MessageBox.Show("Dosar Foaie Matricola: poate contine doar cifre!"); return false; }
            if (ClassGlobalVar.VerificareProt(textBox18.Text, "AnAbs")) { MessageBox.Show("Dosar An Absolvire: trebuie sa fie sub forma \'2000-2001\'"); return false; }
            if (!int.TryParse(textBox24.Text, out int result3)) { MessageBox.Show("DOsar An Candidatura: Trebuie sa fie un numar intreg \n de la 1900 pana la 2300 inclusiv!"); return false; }
            else
                if (int.Parse(textBox24.Text) < 1900 || double.Parse(textBox24.Text) > 2300) { MessageBox.Show("DOsar An Candidatura: Trebuie sa fie un numar intreg \n de la 1900 pana la 2300 inclusiv!"); return false; }

            return true;
        }

        //functie pentru a incarca informatiile unui candidat in form
        public void Incarca(ClassCandidati cd)
        {
            textBox1.Text = cd._NrDosar;
            textBox2.Text = cd._Nume;
            textBox3.Text = cd._InitTata;
            textBox4.Text = cd._Prenume;
            textBox5.Text = cd._Email;
            textBox6.Text = cd._Telefon;
            textBox7.Text = cd._NrBlt.ToString();
            textBox8.Text = cd._SerieBlt;
            textBox9.Text = cd._Nationalitate;
            textBox10.Text = cd._CNP;
            textBox11.Text = cd._Strada;
            textBox12.Text = cd._Localitate;
            textBox13.Text = cd._Judet;
            textBox14.Text = cd._Tara;
            textBox15.Text = cd._NrStrada.ToString();
            textBox16.Text = cd._CodPostal;
            textBox17.Text = cd._BltElibDe;
            textBox18.Text = cd._AnAbs;
            textBox19.Text = cd._NotaSec.ToString();
            textBox20.Text = cd._FoaieMatricola.ToString();
            textBox21.Text = cd._MedieBac.ToString();
            textBox22.Text = cd._Profil;
            textBox23.Text = cd._SerieDiploma;
            textBox24.Text = cd._AnCandi.ToString();
            textBox25.Text = cd._NrDiploma.ToString();
            textBox26.Text = cd._DataNastere;
            textBox27.Text = cd._BltElibLa;
            textBox28.Text = cd._BltExpLa;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (cd._LiceuDenum == listBox1.Items[i].ToString())
                    listBox1.SelectedIndex = i;
            }

            switch (cd._Sex)
            {
                case "Masculin":radioButton1.Checked = true; break;
                case "Feminin":radioButton2.Checked=true; break;
                default:radioButton3.Checked=true; break;
            }
        }

        public void massEnb()
        {
            textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled
                = textBox8.Enabled = textBox9.Enabled = textBox10.Enabled = textBox11.Enabled = textBox12.Enabled = textBox13.Enabled = textBox14.Enabled = textBox15.Enabled = textBox16.Enabled = textBox17.Enabled = textBox18.Enabled = textBox19.Enabled = textBox20.Enabled = textBox21.Enabled = textBox22.Enabled = textBox23.Enabled = textBox24.Enabled = textBox25.Enabled = textBox26.Enabled
            = textBox27.Enabled = textBox28.Enabled = radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = listBox1.Enabled = true;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        public void massDisb()
        {
            textBox1.Enabled = textBox2.Enabled = textBox3.Enabled = textBox4.Enabled = textBox5.Enabled = textBox6.Enabled = textBox7.Enabled
                  = textBox8.Enabled = textBox9.Enabled = textBox10.Enabled = textBox11.Enabled = textBox12.Enabled = textBox13.Enabled = textBox14.Enabled = textBox15.Enabled = textBox16.Enabled = textBox17.Enabled = textBox18.Enabled = textBox19.Enabled = textBox20.Enabled = textBox21.Enabled = textBox22.Enabled = textBox23.Enabled = textBox24.Enabled = textBox25.Enabled = textBox26.Enabled = textBox27.Enabled = textBox28.Enabled
            = radioButton1.Enabled = radioButton2.Enabled = radioButton3.Enabled = listBox1.Enabled = false;
            comboBox1.Enabled = true;
            comboBox2.Enabled = false;
        }
        

        public int ct = 0;

        public Form2_Inscrieri_Editare_Candidati()
        {
            InitializeComponent();
            
        }

        private void Form2_Inscrieri_Editare_Candidati_Load(object sender, EventArgs e)
        {
            
            
            // Pun in ListBox1 Denumiriile liceelor din DB
            string query = "SELECT Denumire FROM T_Licee;";
            OleDbCommand command = new OleDbCommand(query, ClassGlobalVar.connection);
            ClassGlobalVar.connection.Open();
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader.GetString(0));
            }
            reader.Close();
            ClassGlobalVar.connection.Close();

            // Folosind lista globala pentru a incarca in form
            Incarca(ClassGlobalVar.listCandid[0]);
            foreach(ClassCandidati candid in ClassGlobalVar.listCandid)
            {
                if(candid._AnCandi.ToString() != "" && !comboBox1.Items.Contains(candid._AnCandi))
                {
                    comboBox1.Items.Add(candid._AnCandi);
                }
            }
        }

        //trecerea la urmatorul candidat
        private void button2_Click(object sender, EventArgs e)
        {
            ct++;
            Incarca(ClassGlobalVar.listCandid[ct]);
            if (ct == ClassGlobalVar.listCandid.Count - 1 )
            {
                button2.Enabled = false;

            }
            button1.Enabled = true;
        }

        //trecerea la precedentul candidat
        private void button1_Click(object sender, EventArgs e)
        {
            ct--;
            Incarca(ClassGlobalVar.listCandid[ct]);
            if (ct ==0)
            {
                button1.Enabled = false;

            }
            button2.Enabled = true;
        }

        //enable introducerea unui nou candidat
        private void button6_Click(object sender, EventArgs e)
        {
            massEnb();
            textBox1.Text = (ClassGlobalVar.listCandid.Count + 1).ToString();
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "0700000000";
            textBox5.Text = "AAA@email.com";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "0000000000000";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "aaaa-aaaa";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "aaaa";
            textBox25.Text = "";
            textBox26.Text = "zz/ll/aaaa";
            textBox27.Text = "zz/ll/aaaa";
            textBox28.Text = "zz/ll/aaaa";

            radioButton1.Checked = radioButton2.Checked = radioButton3.Checked = false; 
 
            button1.Enabled = button6.Enabled = button3.Enabled = button2.Enabled = false;

             button4.Enabled = button5.Enabled = true;
    

        }

        //enable editarea candidatului actual
        private void button3_Click(object sender, EventArgs e)
        {
            massEnb();
            button1.Enabled = button2.Enabled = button3.Enabled = button6.Enabled = false;

            button4.Enabled = button5.Enabled = true;

        }

        //abort crearea unui nou candidat in DB sau abort editarea candidatului
        private void button5_Click(object sender, EventArgs e)
        {
            Incarca(ClassGlobalVar.listCandid[0]);
            ct = 0;
            massDisb();
            button2.Enabled = button3.Enabled = button6.Enabled = true;

            button4.Enabled = button5.Enabled = false;

        }

        //salvarea editarilor candidatului actual sau introducerea in BD candidat nou
        private void button4_Click(object sender, EventArgs e)
        {
            if (Verificare())
            {
                ClassGlobalVar.connection.Open();

                //variabile pentru ajutor
                string codLiceu;
                int NrDos = int.Parse(textBox1.Text);
                string sex;
                if (radioButton1.Checked == true)
                    sex = "Masculin";
                else
                    if (radioButton2.Checked == true)
                    sex = "Feminin";
                else
                    sex = "Nespecificat";
                string qr = $"SELECT CodLiceu FROM T_Licee WHERE Denumire = '{listBox1.Items[listBox1.SelectedIndex]}';";
                OleDbCommand command = new OleDbCommand(qr, ClassGlobalVar.connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    codLiceu = reader["CodLiceu"].ToString();
                    //candidat nou
                    if (!CheckForNrDosar(textBox1.Text))
                    {
                        //insert T_Candidati
                        string query = "INSERT INTO T_Candidati(NrDosar,Nume,InitialaTata,Prenume,Sex,DataNastere,Email,Telefon,FK_CodLiceu)" +
                            "VALUES('" + NrDos + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + sex + "','" + textBox26.Text + "'," +
                            "'" + textBox5.Text + "','" + textBox6.Text + "','" + codLiceu + "');";

                        OleDbCommand oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                        oleDbCommand.ExecuteNonQuery();

                        //insert T_Dosare
                        query = "INSERT INTO T_Dosare(NrDosar,SerieDiploma,NrDiploma,MedieBac,NotaSecundara,Profil,AnAbsolvire,FoaieMatricola,AnulCandi)" +
                            "VALUES('" + NrDos + "','" + textBox23.Text + "','" + textBox25.Text + "','" + textBox21.Text + "','" + textBox19.Text + "','" + textBox22.Text + "'" +
                            ",'" + textBox18.Text + "','" + textBox20.Text + "','" + textBox24.Text + "');";
                        oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                        oleDbCommand.ExecuteNonQuery();

                        //insert T_Buletine
                        query = "INSERT INTO T_Buletine(Serie,Numar,CNP,Tara,Judet,Localitate,Strada,NrStrada,CodPostal,Nationalitate,EliberatDe,EliberatLa,ExpiraLa,FK_NrDosar)" +
                            "VALUES('" + textBox8.Text + "','" + textBox7.Text + "','" + textBox10.Text + "','" + textBox14.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + textBox11.Text + "'," +
                            "'" + textBox15.Text + "','" + textBox16.Text + "','" + textBox9.Text + "','" + textBox17.Text + "','" + textBox27.Text + "','" + textBox28.Text + "','" + NrDos + "');";
                        oleDbCommand = new OleDbCommand(query, ClassGlobalVar.connection);
                        oleDbCommand.ExecuteNonQuery();

                        ClassCandidati cnd = new ClassCandidati(NrDos.ToString(), textBox2.Text, textBox3.Text, textBox4.Text, sex, textBox26.Text, textBox5.Text, textBox6.Text, textBox8.Text,
                            int.Parse(textBox7.Text), textBox10.Text, textBox14.Text, textBox13.Text, textBox12.Text, textBox11.Text, int.Parse(textBox15.Text), textBox16.Text, textBox9.Text, textBox17.Text, textBox27.Text, textBox28.Text,
                            textBox23.Text, int.Parse(textBox25.Text), double.Parse(textBox21.Text), double.Parse(textBox19.Text), textBox22.Text, textBox18.Text, int.Parse(textBox20.Text), int.Parse(textBox24.Text), listBox1.Items[listBox1.SelectedIndex].ToString());
                        ClassGlobalVar.listCandid.Add(cnd);

                        Incarca(ClassGlobalVar.listCandid[ClassGlobalVar.listCandid.Count - 1]);
                        ct = ClassGlobalVar.listCandid.Count - 1;
                        massDisb();
                        button1.Enabled = true;
                        button2.Enabled = false;
                        MessageBox.Show("Candidat adaugat cu succes!");
                        if (!comboBox1.Items.Contains(int.Parse(textBox24.Text)))
                        {
                            comboBox1.Items.Add(int.Parse(textBox24.Text));
                        }
                        if (comboBox1.Text != "")
                        {
                            if (!comboBox2.Items.Contains(cnd) && int.Parse(comboBox1.Text) == cnd._AnCandi)
                            {
                                comboBox2.Items.Add(cnd);
                            }
                        }
                    }
                    else
                    //salvarea editarilor candidatului
                    {
                        ClassCandidati c = new ClassCandidati(NrDos.ToString(), textBox2.Text, textBox3.Text, textBox4.Text, sex, textBox26.Text, textBox5.Text, textBox6.Text, textBox8.Text,
                            int.Parse(textBox7.Text), textBox10.Text, textBox14.Text, textBox13.Text, textBox12.Text, textBox11.Text, int.Parse(textBox15.Text), textBox16.Text, textBox9.Text, textBox17.Text, textBox27.Text, textBox28.Text,
                            textBox23.Text, int.Parse(textBox25.Text), double.Parse(textBox21.Text), double.Parse(textBox19.Text), textBox22.Text, textBox18.Text, int.Parse(textBox20.Text), int.Parse(textBox24.Text), listBox1.Items[listBox1.SelectedIndex].ToString());
                        ClassGlobalVar.listCandid[ct] = new ClassCandidati(c);


                        string qry = "UPDATE T_Candidati SET Nume = @Nume, InitialaTata = @InitialaTata, Prenume = @Prenume, Sex = @Sex, " +
                            "DataNastere = @DataNastere, Email = @Email, Telefon = @Telefon, FK_CodLiceu = @FK_CodLiceu " +
                            "WHERE NrDosar = @NrDosar";
                        using (OleDbCommand comm = new OleDbCommand(qry, ClassGlobalVar.connection))
                        {
                            comm.Parameters.AddWithValue("@Nume", textBox2.Text);
                            comm.Parameters.AddWithValue("@InitialaTata", textBox3.Text);
                            comm.Parameters.AddWithValue("@Prenume", textBox4.Text);
                            comm.Parameters.AddWithValue("@Sex", sex);
                            comm.Parameters.AddWithValue("@DataNastere", textBox26.Text);
                            comm.Parameters.AddWithValue("@Email", textBox5.Text);
                            comm.Parameters.AddWithValue("@Telefon", textBox6.Text);
                            comm.Parameters.AddWithValue("@FK_CodLiceu", codLiceu);
                            comm.Parameters.AddWithValue("@NrDosar", NrDos);
                            comm.ExecuteNonQuery();
                        }

                        qry = "UPDATE T_Dosare SET SerieDiploma = @SerDip, NrDiploma = @NrDp, MedieBac = @MdBac, NotaSecundara = @NS, Profil = @Prd, " +
                            "AnAbsolvire = @AnAbs, FoaieMatricola = @FM, AnulCandi = @AnCnd WHERE NrDosar = @NrDs";
                        using (OleDbCommand comm = new OleDbCommand(qry, ClassGlobalVar.connection))
                        {
                            comm.Parameters.AddWithValue("@SerDip", textBox23.Text);
                            comm.Parameters.AddWithValue("@NrDp", textBox25.Text);
                            comm.Parameters.AddWithValue("@MdBac", textBox21.Text);
                            comm.Parameters.AddWithValue("@NS", textBox19.Text);
                            comm.Parameters.AddWithValue("@Prd", textBox22.Text);
                            comm.Parameters.AddWithValue("@AnAbs", textBox18.Text);
                            comm.Parameters.AddWithValue("@FM", textBox20.Text);
                            comm.Parameters.AddWithValue("@AnCnd", textBox24.Text);
                            comm.Parameters.AddWithValue("@NrDs", NrDos.ToString());
                            comm.ExecuteNonQuery();
                        }

                        qry = "UPDATE T_Buletine SET Serie = @Ser, Numar = @NrBl, CNP = @CNP, Tara = @Tr, Judet = @Jd, Localitate = @Loc, Strada = @St, " +
                            "NrStrada = @NrS, CodPostal = @CP, Nationalitate = @Nt, EliberatDe = @ElibDe, EliberatLa = @ElibLa, ExpiraLa = @ExpLa " +
                            "WHERE FK_NrDosar = @NrDs";
                        using (OleDbCommand comm = new OleDbCommand(qry, ClassGlobalVar.connection))
                        {
                            comm.Parameters.AddWithValue("@Ser", textBox8.Text);
                            comm.Parameters.AddWithValue("@NrBl", textBox7.Text);
                            comm.Parameters.AddWithValue("@CNP", textBox10.Text);
                            comm.Parameters.AddWithValue("@Tr", textBox14.Text);
                            comm.Parameters.AddWithValue("@Jd", textBox13.Text);
                            comm.Parameters.AddWithValue("@Loc", textBox12.Text);
                            comm.Parameters.AddWithValue("@St", textBox11.Text);
                            comm.Parameters.AddWithValue("@NrS", textBox15.Text);
                            comm.Parameters.AddWithValue("@CP", textBox16.Text);
                            comm.Parameters.AddWithValue("@Nt", textBox9.Text);
                            comm.Parameters.AddWithValue("@ElibDe", textBox17.Text);
                            comm.Parameters.AddWithValue("@ElibLa", textBox27.Text);
                            comm.Parameters.AddWithValue("@ExpLa", textBox28.Text);
                            comm.Parameters.AddWithValue("@NrDs", NrDos.ToString());
                            comm.ExecuteNonQuery();
                        }

                        MessageBox.Show("Candidat actualizat cu succes!");
                        Incarca(ClassGlobalVar.listCandid[ct]);
                        massDisb();
                        if (ct > 0 && ct < ClassGlobalVar.listCandid.Count - 1)
                        {
                            button1.Enabled = button2.Enabled = true;
                        }
                        else if (ct > 0)
                        {
                            button1.Enabled = true;
                        }
                        else
                            button2.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("Erroare, trebuie selectat un liceu din list box care se regaseste si in baza de date!");
                }
                reader.Close();
                button3.Enabled = button6.Enabled = true;
                button4.Enabled = button5.Enabled = false;
                ClassGlobalVar.connection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Items.Contains(int.Parse(comboBox1.Text))) 
            {
                comboBox2.Items.Clear();
                foreach(ClassCandidati cand in ClassGlobalVar.listCandid)
                {
                    if(cand._AnCandi == int.Parse(comboBox1.Text))
                    {
                        comboBox2.Items.Add(cand);
                    }
                }
                comboBox2.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Incarca(comboBox2.Items[comboBox2.SelectedIndex] as ClassCandidati);
            ct = 0;
            foreach(ClassCandidati cd in ClassGlobalVar.listCandid)
            {
                if (cd._NrDosar == (comboBox2.Items[comboBox2.SelectedIndex] as ClassCandidati)._NrDosar)
                    break;
                ct++;
            }
            if (ct == 0 && ct == (ClassGlobalVar.listCandid.Count() - 1))
            {
                button1.Enabled = false;
                button2.Enabled = false;
            }
            else
            if (ct == 0)
            {
                button1.Enabled = false;
                button2.Enabled = true;
            }
            else
                if (ct == (ClassGlobalVar.listCandid.Count() - 1))
            {
                button2.Enabled = false;
                button1.Enabled = true;
            }
            else 
            {
                button1.Enabled = true;
                button2.Enabled = true;
            }
        }
    }
}
