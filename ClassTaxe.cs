using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassTaxe : IComparable
    {
        public string _ID { get; private set; }
        public  double _DeAchitat { get; private set; }
        public string _AchStr { get; private set; }
        public string _Scop { get; private set; }
        public string _IDF { get; private set; }

        public ClassTaxe(string ID, string deAchitat, string scop, string idf) 
        {


            _AchStr = string.Copy(deAchitat);
            while (deAchitat.Contains(','))
            {
                deAchitat = deAchitat.Replace(",", "");
            }
            deAchitat = deAchitat.Replace("€", "");
            _DeAchitat =double.Parse(deAchitat);
            _ID = ID;
            _Scop = scop;
            _IDF = idf;

        }

        public ClassTaxe(ClassTaxe tax)
        {
            _ID = tax._ID;
            _DeAchitat = tax._DeAchitat;
            _Scop = tax._Scop;
            _IDF = tax._IDF;
            _AchStr= tax._AchStr;
        }

        public int CompareTo(object b)
        {
            return _ID.CompareTo((b as ClassTaxe)._ID);
        }

        public override string ToString()
        {
            return $"{_Scop} {_IDF}: €{_AchStr}";
        }
    }
}
