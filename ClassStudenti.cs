using Microsoft.ReportingServices.ReportProcessing.OnDemandReportObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Centralizator_Studenti
{
    public class ClassStudenti : IComparable
    {
        public string _NrMatricol { get; private set; }
        public string _AnStud { get; private set; }
        public string _EmailInst { get; private set; }
        public int _Grupa { get; private set; }
        public ClassCandidati _Candid { get; private set; }

        public ClassStudenti(string nrMatricol, string anStud, string emailInst, int grupa, ClassCandidati cand)
        {
            _NrMatricol = nrMatricol;
            _AnStud = anStud;
            _EmailInst = emailInst;
            _Grupa = grupa;
            _Candid = new ClassCandidati(cand);
        }

        public ClassStudenti(string nrMatricol, ClassCandidati cand)
        {
            _NrMatricol = nrMatricol;
            _AnStud = "0";
            _EmailInst = "PLACEHOLDER";
            _Grupa = 0;
            _Candid = new ClassCandidati(cand);
        }

        public ClassStudenti(ClassStudenti stud)
        {
            _NrMatricol = stud._NrMatricol;
            _AnStud=stud._AnStud;
            _EmailInst = stud._EmailInst;
            _Grupa = stud._Grupa;
            _Candid = new ClassCandidati(stud._Candid);
        }

        public int CompareTo(object b)
        {
            return _NrMatricol.CompareTo((b as ClassStudenti)._NrMatricol);
        }

        public override string ToString()
        {
            return $"{_NrMatricol}: {_Candid._Nume} {_Candid._InitTata} {_Candid._Prenume}";
        }
    }
}
