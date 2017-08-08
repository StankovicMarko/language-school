using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Kurs:Identifikacija
    {

        private string jezik;
        private string tip;
        private float cena;
        public List<Ucenik> Ucenici = new List<Ucenik>();
        private Nastavnik nastavnik;


        public string Jezik {
            set {
                jezik = value;
                OnPropertyChanged("Jezik");
            }
            get
            { return jezik;
               
            } }
        public string Tip
        {
            set
            {
                tip = value;
                OnPropertyChanged("Tip");
            }
            get
            {
                return tip;

            }
        }
        public float Cena
        {
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
            get
            {
                return cena;

            }
        }
        
        public Nastavnik Nastavnik
        {
            set
            {
                nastavnik = value;
                OnPropertyChanged("Nastavnik");
            }
            get
            {
                return nastavnik;

            }
        }

        public Kurs(long id, bool obrisan, string jezik, string tip, float cena, List<Ucenik> ucenici, Nastavnik nastavnik) : base(id, obrisan)
        {
            this.Jezik = jezik;
            this.Tip = tip;
            this.Cena = cena;
            this.Ucenici = ucenici;
            this.Nastavnik = nastavnik;
            
        }

        public Kurs() { }


        public Kurs DeepCopy()
        {
            Kurs copy = new Kurs(this.Id, this.Obrisan, this.Jezik, this.Tip, this.Cena, this.Ucenici, this.Nastavnik);
            return copy;
        }

        internal void setValues(Kurs copyObj)
        {
            this.Id = copyObj.Id;
            this.Obrisan = copyObj.Obrisan;
            this.Jezik = copyObj.Jezik;
            this.Tip = copyObj.Tip;
            this.Cena = copyObj.Cena;
            this.Ucenici = copyObj.Ucenici;
            this.Nastavnik = copyObj.Nastavnik;
           
        }


        public override string ToString()
        {
            return "Jezik: " + this.Jezik + "\nTip kursa: " + this.Tip + "\nCena " + this.Cena + "\nNastavnik " + this.Nastavnik + "\n";
        }

    }
}
