using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassAccount : IComparable
    {
        public static int ID = 0;
        public int _AccTempID {  get; private set; }
        public string _CompID { get; private set; }
        public string _Email { get; private set; } 
        public string _Pword { get; private set; } 
        public string _Nume { get; private set; } 
        public string _Titlu { get; private set; } 
        public string _Activ { get; private set; }

        public ClassAccount(string compid, string email, string pword, string nume, string titlu, string activ)
        {
            _AccTempID = System.Threading.Interlocked.Increment(ref ID);
            _CompID = compid;
            _Email = email;
            _Pword = pword;
            _Nume = nume;
            _Titlu = titlu;
            _Activ = activ;
        }

        public ClassAccount(ClassAccount ac)
        {
            _AccTempID = ac._AccTempID;
            _CompID = ac._CompID;
            _Email = ac._Email;
            _Pword = ac._Pword;
            _Nume = ac._Nume;
            _Titlu = ac._Titlu;
            _Activ = ac._Activ;
        }

        public int CompareTo(object b)
        {
            
            return _AccTempID.CompareTo((b as ClassAccount)._AccTempID);
        }

        public override string ToString()
        {
            return $"{_Nume}";
        }
    }
}
