using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelektika1.DuomenuParuosimas.Klases
{
    class PlanuProperty
    {
        public string PropercioPavadinimas { get; set; }
        public string PropercioReiksme { get; set; }
        public double Atstumas { get; set; }
        public PlanuProperty(string PropercioPavadinimas,string PropercioReiksme)
        {
            this.PropercioPavadinimas = PropercioPavadinimas;
            this.PropercioReiksme = PropercioReiksme;
            Atstumas = -1111;
        }
    }
}
