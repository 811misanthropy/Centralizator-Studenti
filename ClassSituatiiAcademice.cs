using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Centralizator_Studenti
{
    public class ClassSituatiiAcademice: IComparable
    {
        public string _CodInr { get; private set; }
        public ClassStudenti _Stud { get; private set; }
        public ClassDiscipline _Discipline { get; private set;}
        public string _NtFin { get; private set; }
        public string _NrAbs { get; private set; }
        
        

        public ClassSituatiiAcademice(ClassSituatiiAcademice sit)
        {
            _CodInr = sit._CodInr;
            _Stud = new ClassStudenti( sit._Stud);
            _Discipline = new ClassDiscipline( sit._Discipline);
            _NtFin = sit._NtFin;
            _NrAbs = sit._NrAbs;
        }

        public ClassSituatiiAcademice(string cod, ClassStudenti stud, ClassDiscipline disp, string ntfin, string nrabs)
        {
            _CodInr = cod;
            _Stud = new ClassStudenti(stud);
            _Discipline = new ClassDiscipline(disp);
            _NtFin = ntfin;
            _NrAbs = nrabs;
        }

        public int CompareTo(object b)
        {
            return _CodInr.CompareTo((b as ClassSituatiiAcademice)._CodInr);
        }

        public override string ToString()
        {
            return $"{_Discipline._DDenumire}:Anul {_Discipline._AnAcaDisci}, Semestrul {_Discipline._SemStudDisci}, Nota {_NtFin}";
        }
    }
}
