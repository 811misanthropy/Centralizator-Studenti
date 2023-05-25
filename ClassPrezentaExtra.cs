using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassPrezentaExtra : IComparable
    {
        public string _codP { get;private set; }
        public ClassActivitatiextra _AcEx { get;private set;}
        public ClassStudenti _stud { get;private set;}

        public ClassPrezentaExtra(string codP, ClassActivitatiextra acEx, ClassStudenti stud)
        {
            _codP = codP;
            _AcEx = new ClassActivitatiextra(acEx);
            _stud = new ClassStudenti(stud);
        }

        public ClassPrezentaExtra(ClassPrezentaExtra prezentaExtra)
        {
            _codP = prezentaExtra._codP;
            _AcEx = new ClassActivitatiextra(prezentaExtra._AcEx);
            _stud = new ClassStudenti(prezentaExtra._stud);
        }

        public int CompareTo(object b)
        {
            return _codP.CompareTo((b as ClassPrezentaExtra)._codP);
        }

        public override string ToString()
        {
            return $"{_AcEx._AEDenumire}: {_stud._Candid._Nume} {_stud._Candid._InitTata} {_stud._Candid._Prenume}";
        }
    }
}
