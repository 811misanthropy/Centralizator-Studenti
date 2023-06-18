using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassCadreFacultate : IComparable
    {
        public string _IDCF { get; private set; }
        public string _CFNume { get; private set; }
        public string _CFTitlu { get; private set; }
        public string _CFTelefon { get; private set; }
        public string _CFEmail { get; private set; }
        public string _CFPassw { get; private set; }
        public string _Activ { get;private set; }

        public ClassCadreFacultate (string iDCF, string cFNume, string cFTitlu, string cFTelefon, string cFEmail,  string cFPassw, string activ)
        {
            _IDCF = iDCF;
            _CFNume = cFNume;
            _CFTitlu = cFTitlu;
            _CFTelefon = cFTelefon;
            _CFEmail = cFEmail;
            _CFPassw = cFPassw;
            _Activ = activ;
        }

        public ClassCadreFacultate (ClassCadreFacultate CF)
        {
            _IDCF = CF._IDCF;
            _CFNume = CF._CFNume;
            _CFTitlu = CF._CFTitlu;
            _CFTelefon= CF._CFTelefon;
            _CFEmail = CF._CFEmail;
            _CFPassw = CF._CFPassw;
            _Activ= CF._Activ;
        }

        public int CompareTo(object b)
        {
            return _IDCF.CompareTo((b as ClassCadreFacultate)._IDCF);
        }

        public override string ToString()
        {
            return $"{_CFTitlu} {_CFNume}";
        }
    }
}
