using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Nastavnik : Osoba
    {
        private float plata;
        private List<Kurs> kursevi = new List<Kurs>();

        public float Plata {
            get {
                return plata;
            }
            set {
                plata = value;
                OnPropertyChanged("Plata");
            } }

        public List<Kurs> Kursevi
        {
            get
            {
                return kursevi;
            }
            set
            {
                kursevi = value;
                OnPropertyChanged("Kursevi");
            }
        }
        public Nastavnik(long id, bool obrisan, string ime, string prezime, string jmbg, float plata, List<Kurs> kursevi) : base(ime, prezime, jmbg, id, obrisan) {
            this.Plata = plata;
            this.Kursevi = kursevi;
        }

        public Nastavnik()
        {

        }

        public Nastavnik DeepCopy()
        {
            Nastavnik copy = new Nastavnik(this.Id, this.Obrisan, this.Ime, this.Prezime, this.Jmbg, this.Plata, this.Kursevi);
       
            return copy;
        }

        public void setValues(Nastavnik n)
        {
            this.Id = n.Id;
            this.Obrisan = n.Obrisan;
            this.Ime = n.Ime;
            this.Prezime = n.Prezime;
            this.Jmbg = n.Jmbg;
            this.Plata = n.Plata;
            this.Kursevi = n.Kursevi;
        }
        public override string ToString()
        {
     
            return Ime + " " + Prezime;
        }
    }
}
