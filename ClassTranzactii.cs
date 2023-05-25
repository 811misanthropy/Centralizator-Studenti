using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassTranzactii : IComparable
    {
        public string _CodTranz { get; private set; }
        public string _IBAN { get; private set; }
        public string _Data { get; private set; }
        public double _Suma { get; private set; }
        public string _SumaStr { get; private set; }
        public ClassCandidati _cand { get; private set; }
        public ClassTaxe _tax { get; private set; }
        public string _AnStud { get; private set; }

        public ClassTranzactii(string Cod, string Ibn, string data, string sum, ClassCandidati cand, ClassTaxe tax, string anstud)
        {
            _SumaStr = sum;

            while (sum.Contains(','))
            {
                sum = sum.Replace(",", "");
            }
            sum = sum.Replace("€", "");
            _Suma = double.Parse(sum);

            _CodTranz = Cod;
            _IBAN = Ibn;
            _Data = data;
            _cand = new ClassCandidati(cand);
            _tax = new ClassTaxe(tax);
            _AnStud = anstud;
        }

        public int CompareTo(object b)
        {
            return _CodTranz.CompareTo((b as ClassTranzactii)._CodTranz);
        }

        public override string ToString()
        {
            return $"Tranzactia {_CodTranz}: (anul {_AnStud}) a platit €{_SumaStr} din €{_tax._AchStr} pe data de {_Data}.";
        }
    }
}
