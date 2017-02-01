using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intelektika1.DuomenuParuosimas.Klases
{
    class Reiksmes
    {
        public List<PlanuProperty> Properties { get; set; }
        public Reiksmes(List<PlanuProperty> Properties)
        {
            this.Properties = Properties;
        }
    }
}
