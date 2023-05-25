using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;


namespace Centralizator_Studenti 
{
    public class ClassCandidati : IComparable
    {
       
        // variabile/atribute tabela T_Candidati 
        public string _NrDosar { get; private set; }
        public string _Nume { get; private set; }
        public string _InitTata { get; private set;}
        public string _Prenume { get; private set; }
        public string _Sex { get; private set; }
        public string _DataNastere { get; private set; }
        public string _Email { get; private set; }
        public string _Telefon { get; private set; }

        // variabile/atribute tabela T_Buletine
        public string _SerieBlt { get; private set; }
        public int _NrBlt { get; private set; }
        public string _CNP { get; private set; }
        public string _Tara { get; private set; }
        public string _Judet { get; private set; }
        public string _Localitate { get; private set; }
        public string _Strada { get; private set; }
        public int _NrStrada { get; private set; }
        public string _CodPostal { get; private set; }
        public string _Nationalitate { get; private set; }
        public string _BltElibDe { get; private set; }
        public string _BltElibLa { get; private set; }
        public string _BltExpLa { get; private set; }

        // variabile/atribute tabela T_Dosare
        public string _SerieDiploma { get; private set; }
        public int _NrDiploma { get; private set; }
        public double _MedieBac { get; private set; } 
        public double _NotaSec { get; private set; }
        public string _Profil { get; private set; }
        public string _AnAbs { get; private set; }
        public int _FoaieMatricola { get; private set; }
        public int _AnCandi { get; private set; }

        // variabile/atribute tabela T_Licee
        public string _LiceuDenum { get; private set; }

        //variabile proprii
        public double _MedieFinala { get; private set; }

        // functii constructor
        public ClassCandidati (string NrDosar, string Nume, string InitialaTata, string Prenume, string Sex, string DataNastere, string Email,
            string Telefon, string SerieBlt, int NrBlt, string CNP, string Tara, string Judet, string Localitate, string Strada, int NrStrada,
            string CodPostal, string Nationalitate, string BltElibDe, string BltElibLa, string BltExpLa, string SerieDiploma, int NrDiploma,
            double MedieBac, double NotaSec, string Profil, string AnAbs, int FoaieMatricola, int AnCandi, string LiceuDenum)
        {
           _NrDosar= NrDosar;
           _Nume= Nume;
           _InitTata = InitialaTata;
           _Prenume= Prenume;
           _Sex= Sex;
           _DataNastere= DataNastere;
           _Email= Email;
           _Telefon= Telefon;
           _SerieBlt= SerieBlt;
           _CNP= CNP;
           _NrBlt= NrBlt;
            _Tara= Tara;
            _Judet= Judet;
            _Localitate= Localitate;
            _Strada= Strada;
            _NrStrada= NrStrada;
            _CodPostal= CodPostal;
            _Nationalitate= Nationalitate;
            _BltElibDe=BltElibDe;
            _BltElibLa=BltElibLa;
            _BltExpLa=BltExpLa;
            _SerieDiploma= SerieDiploma;
            _NrDiploma= NrDiploma;
            _MedieBac = MedieBac;
            _NotaSec = NotaSec;
            _Profil= Profil;
            _AnAbs= AnAbs;
            _FoaieMatricola= FoaieMatricola;
            _AnCandi= AnCandi;
            _LiceuDenum= LiceuDenum;

            _MedieFinala = (_MedieBac+_NotaSec) / 2;


        }
        public ClassCandidati()
        {
            _NrDosar = "-1";
            _Nume = new string(char.MaxValue, 10);
            _InitTata = new string(char.MaxValue, 10);
            _Prenume = new string(char.MaxValue, 10);
            _MedieFinala = 0;
        }

        public ClassCandidati(ClassCandidati c)
        {
            _NrDosar = c._NrDosar; 
            _Nume = c._Nume;
            _InitTata = c._InitTata;
            _Prenume = c._Prenume;
            _Sex = c._Sex;
            _DataNastere = c._DataNastere;
            _Email = c._Email;
            _Telefon = c._Telefon;
            _SerieBlt = c._SerieBlt;
            _NrBlt= c._NrBlt;
            _CNP = c._CNP;
            _Tara= c._Tara;
            _Judet = c._Judet;
            _Localitate = c._Localitate;
            _Strada = c._Strada;
            _NrStrada= c._NrStrada;
            _CodPostal= c._CodPostal;
            _Nationalitate = c._Nationalitate;
            _BltElibDe = c._BltElibDe;
            _BltElibLa = c._BltElibLa;
            _BltExpLa= c._BltExpLa;
            _SerieDiploma= c._SerieDiploma;
            _NrDiploma = c._NrDiploma;
            _MedieBac = c._MedieBac;
            _NotaSec= c._NotaSec;
            _Profil= c._Profil;
            _AnAbs= c._AnAbs;
            _FoaieMatricola= c._FoaieMatricola;
            _AnCandi= c._AnCandi;
            _LiceuDenum= c._LiceuDenum;

            _MedieFinala = (_MedieBac + _NotaSec) / 2;
        }




        // functie de ordonare
        public int CompareTo(object b)
        {
            return _NrDosar.CompareTo((b as ClassCandidati)._NrDosar);
        }

        public override string ToString()
        {
            return $"{_NrDosar};{_Nume} {_InitTata} {_Prenume}";
        }
    }
}
