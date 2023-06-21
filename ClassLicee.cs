using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Centralizator_Studenti
{
    public class ClassLicee:IComparable
    {
        public string _index { get; private set; }
        public string _denumire { get; private set; }
        public string _adresa { get; private set; }
        
        public ClassLicee(string i, string d, string a)
        {
            _index = i;
            _denumire = d;
            _adresa = a;
        }

        public ClassLicee(ClassLicee cl)
        { 
            _index = cl._index;
            _denumire = cl._denumire;
            _adresa = cl._adresa;
        }

        public int CompareTo(object b)
        {
            return _index.CompareTo((b as ClassLicee)._index);
        }

        public override string ToString()
        {
            return $"{_denumire}";
        }

    }
}
