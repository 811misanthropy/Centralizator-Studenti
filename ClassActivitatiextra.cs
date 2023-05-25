using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassActivitatiextra : IComparable
    {
        public string _AEDenumire { get; private set; }
        public string _DataStart { get; private set; }
        public string _DataEnd { get; private set; }
        public string _Org { get; private set; }
        public string _Tip { get; private set; }

        public ClassActivitatiextra(string denum, string ds, string de, string org, string tip)
        {
            _AEDenumire = denum;
            _DataStart = ds;
            _DataEnd = de;
            _Org = org;
            _Tip = tip;
        }

        public ClassActivitatiextra(ClassActivitatiextra actextr) 
        {
            _AEDenumire = actextr._AEDenumire;
            _DataStart = actextr._DataStart;
            _DataEnd = actextr._DataEnd;
            _Org = actextr._Org;
            _Tip = actextr._Tip;
        }

        public int CompareTo(object b)
        {
            return _AEDenumire.CompareTo((b as ClassActivitatiextra)._AEDenumire);
        }

        public override string ToString()
        {
            return $"{_AEDenumire}, {_Tip}: {_DataStart} - {_DataEnd}, Organizator: {_Org}";
        }
    }
}
