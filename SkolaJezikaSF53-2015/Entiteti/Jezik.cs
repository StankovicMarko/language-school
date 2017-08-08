using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Jezik:Identifikacija
    {

        public string naziv { set; get; }
        public string opis { set; get; }

        public Jezik(long id, bool obrisan, string naziv, string opis) : base(id, obrisan)
        {
            this.naziv = naziv;
            this.opis = opis;
        }
    }
}
