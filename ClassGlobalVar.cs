using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Centralizator_Studenti
{
    public static class ClassGlobalVar
    {
        //pathul si conexiunea globale pentru intreg proiectul
        //public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\FACULTATE\\An3 Sem2\\Licenta\\Centralizator Studenti\\Database CS.accdb;Persist Security Info=False;";
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\FACULTATE\\ALEX\\LICENTA\\APP\\Database CS.accdb;Persist Security Info=False;";

        public static OleDbConnection connection = new OleDbConnection(connectionString: connectionString);

        //Crearea liste globale
        public static ClassTemplateList<ClassCandidati> listCandid = new ClassTemplateList<ClassCandidati>();
        public static ClassTemplateList<ClassTaxe> listTax = new ClassTemplateList<ClassTaxe>();
        public static ClassTemplateList<ClassTranzactii> listTrans = new ClassTemplateList<ClassTranzactii>();
        public static ClassTemplateList<ClassStudenti> listStud = new ClassTemplateList<ClassStudenti>();
        public static ClassTemplateList<ClassActivitatiextra> listActExtr = new ClassTemplateList<ClassActivitatiextra>();
        public static ClassTemplateList<ClassPrezentaExtra> listPrExtr = new ClassTemplateList<ClassPrezentaExtra>();
        public static ClassTemplateList<ClassDiscipline> listDisci = new ClassTemplateList<ClassDiscipline>();
        public static ClassTemplateList<ClassSituatiiAcademice> listSitAca = new ClassTemplateList<ClassSituatiiAcademice>();
        public static ClassTemplateList<ClassCadreFacultate> listCadre = new ClassTemplateList<ClassCadreFacultate>();
        public static ClassTemplateList<ClassAccount> listAcc = new ClassTemplateList<ClassAccount>();
        public static ClassAccount account = new ClassAccount("","","","","","Inactiv");
        public static void InitializareDate()
        {
            listCandid.Clear();
            listTax.Clear();
            listTrans.Clear();
            listStud.Clear();
            listActExtr.Clear();
            listPrExtr.Clear();
            listDisci.Clear();
            listSitAca.Clear();
            listCadre.Clear();

            connection.Open();
            string query = "Select IDCF, CFNume, CFTitlu, CFTelefon, CFEmail, CFPassw, CFActiv from T_CadreFacultate Order by IDCF ASC;";
            OleDbCommand command = new OleDbCommand(query, connection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClassCadreFacultate CF = new ClassCadreFacultate(reader["IDCF"].ToString(), reader["CFNume"].ToString(), reader["CFTitlu"].ToString(), reader["CFTelefon"].ToString(), reader["CFEmail"].ToString(), reader["CFPassw"].ToString(), reader["CFActiv"].ToString());
                listCadre.Add(CF);
                listAcc.Add(new ClassAccount(CF._IDCF, CF._CFEmail, CF._CFPassw, CF._CFNume, CF._CFTitlu, CF._Activ));
            }
            reader.Close();

            query = "SELECT T_Candidati.NrDosar, T_Candidati.Nume, T_Candidati.InitialaTata, T_Candidati.Prenume, T_Candidati.Sex, " +
                "T_Candidati.DataNastere, T_Candidati.Email, T_Candidati.Telefon, T_Buletine.Serie, T_Buletine.Numar, " +
                "T_Buletine.CNP, T_Buletine.Tara, T_Buletine.Judet, T_Buletine.Localitate, T_Buletine.Strada, T_Buletine.NrStrada, " +
                "T_Buletine.CodPostal, T_Buletine.Nationalitate, T_Buletine.EliberatDe, T_Buletine.EliberatLa, T_Buletine.ExpiraLa, " +
                "T_Dosare.SerieDiploma, T_Dosare.NrDiploma, T_Dosare.MedieBac, T_Dosare.NotaSecundara, T_Dosare.Profil, T_Dosare.AnAbsolvire, " +
                "T_Dosare.FoaieMatricola, T_Dosare.AnulCandi, T_Licee.Denumire " +
                "FROM (((T_Candidati " +
                "INNER JOIN T_Buletine ON T_Candidati.NrDosar = T_Buletine.FK_NrDosar) " +
                "INNER JOIN T_Dosare ON T_Candidati.NrDosar = T_Dosare.NrDosar) " +
                "INNER JOIN T_Licee ON T_Candidati.FK_CodLiceu = T_Licee.CodLiceu) order by T_Candidati.NrDosar asc;";
            command = new OleDbCommand(query, connection);
            
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int iNumar, iNrStrada, iNrDiploma, iFoaieMatricola, iAnulCandi;
                double dMedieBac, dNotaSecundara;

                if (int.TryParse(reader["Numar"].ToString(), out iNumar) && int.TryParse(reader["NrStrada"].ToString(), out iNrStrada)
                    && int.TryParse(reader["NrDiploma"].ToString(), out iNrDiploma) && int.TryParse(reader["FoaieMatricola"].ToString(), out iFoaieMatricola) && int.TryParse(reader["AnulCandi"].ToString(), out iAnulCandi)
                    && double.TryParse(reader["MedieBac"].ToString(), out dMedieBac) && double.TryParse(reader["NotaSecundara"].ToString(), out dNotaSecundara))
                {
                    ClassCandidati candidatCur = new ClassCandidati(reader["NrDosar"].ToString(), reader["Nume"].ToString(), reader["InitialaTata"].ToString(),
                    reader["Prenume"].ToString(), reader["Sex"].ToString(), reader["DataNastere"].ToString(), reader["Email"].ToString(), reader["Telefon"].ToString()
                    , reader["Serie"].ToString(), iNumar, reader["CNP"].ToString(), reader["Tara"].ToString(), reader["Judet"].ToString()
                    , reader["Localitate"].ToString(), reader["Strada"].ToString(), iNrStrada, reader["CodPostal"].ToString(), reader["Nationalitate"].ToString()
                    , reader["EliberatDe"].ToString(), reader["EliberatLa"].ToString(), reader["ExpiraLa"].ToString()
                    , reader["SerieDiploma"].ToString(), iNrDiploma, dMedieBac, dNotaSecundara
                    , reader["Profil"].ToString(), reader["AnAbsolvire"].ToString()
                    , iFoaieMatricola, iAnulCandi, reader["Denumire"].ToString());
                    listCandid.Add(candidatCur);
                }
            }
            reader.Close();

            query = "SELECT CodFormat, SumaDeAchitat, Scop, IndexFormat FROM T_ModeleDeTaxa ORDER BY CodFormat ASC;";
            command = new OleDbCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClassTaxe tax = new ClassTaxe(reader["CodFormat"].ToString(), reader["SumaDeAchitat"].ToString(), reader["Scop"].ToString(), reader["IndexFormat"].ToString());
                listTax.Add(tax);
            }
            reader.Close();

            query = "SELECT CodTranzactie, IBAN, Data, Suma, FK_NrDosar, FK_Model, AnStudent FROM T_Tranzactii ORDER BY CodTranzactie ASC;";
            command = new OleDbCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int a = -1, b = -1;
                foreach (ClassCandidati cand in listCandid)
                {
                    a++;
                    if (cand._NrDosar == reader["FK_NrDosar"].ToString())
                        break;
                }
                foreach (ClassTaxe tax in listTax)
                {
                    b++;
                    if (tax._ID == reader["FK_Model"].ToString())
                        break;
                }
                ClassTranzactii trans = new ClassTranzactii(reader["CodTranzactie"].ToString(), reader["IBAN"].ToString(), reader["Data"].ToString(), reader["Suma"].ToString(), listCandid[a], listTax[b], reader["AnStudent"].ToString());
                listTrans.Add(trans);
            }
            reader.Close();

            query = "SELECT NrMatricol, An, EmailInstitutional, Grupa, FK_NrDosar, STUDActiv FROM T_Studenti ORDER BY NrMatricol ASC;";
            command = new OleDbCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {

                foreach (ClassCandidati cand in listCandid)
                {
                    if (cand._NrDosar == reader["FK_NrDosar"].ToString())
                    {
                        ClassStudenti stud = new ClassStudenti(reader["NrMatricol"].ToString(), reader["An"].ToString(), reader["EmailInstitutional"].ToString(), int.Parse(reader["Grupa"].ToString()), cand, reader["STUDActiv"].ToString());
                        listStud.Add(stud);
                        listAcc.Add(new ClassAccount(stud._Candid._NrDosar,stud._EmailInst,stud._Candid._CNP,$"{stud._Candid._Nume} {stud._Candid._InitTata} {stud._Candid._Prenume}","Student",stud._StudActiv));
                        break;
                    }
                }
            }
            reader.Close();


            query = "SELECT IdDisciplina, DDenumire, PuncteCredit, NrOre, AnAcaDisci, AnStudDisci, SemStudDisci, FK_IDCF FROM T_Discipline ORDER BY IdDisciplina ASC;";
            command = new OleDbCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                
                foreach(ClassCadreFacultate cf in listCadre)
                {
                    if (cf._IDCF == reader["FK_IDCF"].ToString())
                    {
                        ClassDiscipline disci = new ClassDiscipline(reader["IdDisciplina"].ToString(), reader["DDenumire"].ToString(), reader["PuncteCredit"].ToString(), reader["NrOre"].ToString()
                            , reader["AnAcaDisci"].ToString(), reader["AnStudDisci"].ToString(), reader["SemStudDisci"].ToString(),cf);
                        listDisci.Add(disci);
                        break;
                    }
                }

            }
            reader.Close();

            query = "SELECT IdActivExtra, AEDenumire, DataS, DataE, Organizator, Tip, AnAcadAplicabil, SemAE FROM T_ActivitatiExtracuriculare ORDER BY IdActivExtra ASC;";
            command = new OleDbCommand(query, connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                ClassActivitatiextra actextr = new ClassActivitatiextra(reader["IdActivExtra"].ToString(),reader["AEDenumire"].ToString(), reader["DataS"].ToString(), reader["DataE"].ToString(), reader["Organizator"].ToString(), reader["Tip"].ToString(), reader["AnAcadAplicabil"].ToString(), reader["SemAE"].ToString());
                listActExtr.Add(actextr);
            }
            reader.Close();

            query = "SELECT CodInregistrare, FK_NrMatricol, FK_IdDisciplina, NotaFinala, NrAbsente FROM T_SituatiiAcademice ORDER BY CodInregistrare ASC;";
            command = new OleDbCommand(query,connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                foreach(ClassStudenti stud in  listStud)
                {
                    if(stud._NrMatricol == reader["FK_NrMatricol"].ToString())
                    {
                        foreach(ClassDiscipline dis in listDisci)
                        {
                            if(dis._IdDisciplna == reader["FK_IdDisciplina"].ToString())
                            {
                                ClassSituatiiAcademice sitaca = new ClassSituatiiAcademice(reader["CodInregistrare"].ToString(), stud, dis,reader["NotaFinala"].ToString(), reader["NrAbsente"].ToString());
                                listSitAca.Add(sitaca);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            reader.Close();

            query = "SELECT CodPrezenta, FK_IdActivExtra, FK_NrMatricol FROM T_PrezentaExtra ORDER BY CodPrezenta ASC;";
            command = new OleDbCommand (query,connection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                foreach(ClassStudenti stud in listStud)
                {
                    if(stud._NrMatricol == reader["FK_NrMatricol"].ToString())
                    {
                        foreach(ClassActivitatiextra actextr in listActExtr)
                        {
                            if(actextr._IdActivExtra == reader["FK_IdActivExtra"].ToString())
                            {
                                ClassPrezentaExtra prextr = new ClassPrezentaExtra(reader["CodPrezenta"].ToString(),actextr,stud);
                                listPrExtr.Add(prextr);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            reader.Close();
            connection.Close();
        }

        public static bool IsNumeric(string str)
        {
            int contor = 0;
            char c;
            if (str.Length == 4)
            {
                do
                {
                    c = str[str.Length - 1];
                    str = str.Substring(0, str.Length - 1);
                    if (!char.IsDigit(c))
                    {
                        contor++;
                    }
                } while (str.Length > 1);

                c = str[0];
                if (!char.IsDigit(c) || c == '0')
                {
                    contor++;
                }
                if (contor == 0)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
