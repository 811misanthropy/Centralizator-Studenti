using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassActivitatiextra : IComparable
    {
        public string _IdActivExtra { get; private set; }
        public string _AEDenumire { get; private set; }
        public string _DataStart { get; private set; }
        public string _DataEnd { get; private set; }
        public string _Org { get; private set; }
        public string _Tip { get; private set; }
        public string _AnAcadAplicabil { get; private set; }
        public string  _SemAE { get; private set; }

        public ClassActivitatiextra(string id, string denum, string ds, string de, string org, string tip, string an, string sem)
        {
            _IdActivExtra = id;
            _AEDenumire = denum;
            _DataStart = ds;
            _DataEnd = de;
            _Org = org;
            _Tip = tip;
            _AnAcadAplicabil = an;
            _SemAE = sem;
        }

        public ClassActivitatiextra(ClassActivitatiextra actextr) 
        {
            _IdActivExtra = actextr._IdActivExtra;
            _AEDenumire = actextr._AEDenumire;
            _DataStart = actextr._DataStart;
            _DataEnd = actextr._DataEnd;
            _Org = actextr._Org;
            _Tip = actextr._Tip;
            _AnAcadAplicabil = actextr._AnAcadAplicabil;
            _SemAE = actextr._SemAE;
        }

        public int CompareTo(object b)
        {
            return _IdActivExtra.CompareTo((b as ClassActivitatiextra)._IdActivExtra);
        }

        public override string ToString()
        {
            return $"{_AEDenumire}, {_Tip}: {_DataStart} - {_DataEnd}, Organizator: {_Org}";
        }
    }
}
