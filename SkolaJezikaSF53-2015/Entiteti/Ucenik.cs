using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Ucenik:Osoba
    {
        public List<Kurs> Kursevi = new List<Kurs>();
        public List<Uplata> Uplate = new List<Uplata>();


        public Ucenik(long id, bool obrisan, string ime, string prezime, string jmbg) : base(ime, prezime, jmbg, id, obrisan)
        {
          

        }

        public Ucenik DeepCopy()
        {
            Ucenik copy = new Ucenik(this.Id, this.Obrisan, this.Ime, this.Prezime, this.Jmbg );
            copy.Kursevi = this.Kursevi;
            copy.Uplate = this.Uplate;
            return copy;
        }

        public Ucenik() { }


        public void setValues(Ucenik u)
        {
            this.Ime = u.Ime;
            this.Prezime = u.Prezime;
            this.Jmbg = u.Jmbg;
            this.Obrisan = u.Obrisan;
            this.Kursevi = u.Kursevi;
            this.Uplate = u.Uplate;
        }

        public override string ToString()
        {
            return Ime + " " + Prezime + "  (" + Jmbg + ")";
        }
    }
}
