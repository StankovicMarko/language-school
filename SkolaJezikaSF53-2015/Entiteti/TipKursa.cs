using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class TipKursa
    {
        public string naziv { set; get; }
        public string opis { set; get; }

        public TipKursa(string naziv, string opis)
        {
            this.naziv = naziv;
            this.opis = opis;
        }

    }
}
