using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassDiscipline :IComparable
    {
        public string _IdDisciplna { get; private set; }    
        public string _DDenumire {  get; private set; }
        public string _PuncteCredit { get; private set; }
        public string _NrOre { get; private set; }
        public string _AnAcaDisci { get; private set; }
        public string _AnStudDisci { get; private set; }
        public string _SemStudDisci { get; private set; }


        public ClassDiscipline(string id,string denumire, string punctcred, string nrore, string anaca, string anstud, string semstud)
        {
            _IdDisciplna = id;
            _DDenumire = denumire;
            _PuncteCredit = punctcred;
            _NrOre = nrore;
            _AnAcaDisci = anaca;
            _AnStudDisci = anstud;
            _SemStudDisci= semstud;
        }

        public ClassDiscipline(ClassDiscipline dis)
        {
            _IdDisciplna = dis._IdDisciplna;
            _DDenumire = dis._DDenumire;
            _PuncteCredit = dis._PuncteCredit;
            _NrOre = dis._NrOre;
            _AnAcaDisci= dis._AnAcaDisci;
            _AnStudDisci=dis._AnStudDisci;
            _SemStudDisci = dis._SemStudDisci;
        }

        public int CompareTo(object b)
        {
            return _IdDisciplna.CompareTo((b as ClassDiscipline)._IdDisciplna);
        }

        public override string ToString()
        {
            return $"{_DDenumire};{_NrOre} ore;{_PuncteCredit} puncte credit;in anul {_AnAcaDisci}";
        }
    }
}
