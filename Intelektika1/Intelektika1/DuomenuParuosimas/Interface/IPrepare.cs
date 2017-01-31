using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelektika1.DuomenuParuosimas.Interface
{
    interface IPrepare
    {
        List<Klases.PlanuProperty> GetAllProperties(string keliasIkiExcelio);
        List<Klases.Reiksmes> Uzpildymas(string keliasIkiExcelio, List<Klases.PlanuProperty> Properties);
    }
}
