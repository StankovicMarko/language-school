using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Osoba : Identifikacija, INotifyPropertyChanged
    {

        private string ime;
        private string prezime;
        private string jmbg;

        public string Ime{
            get
            {
                return ime;
            }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            } }
        public string Prezime {
            get
            {
                return prezime;
            }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");
            }
        }
        public string Jmbg {
            get
            {
                return jmbg;
            }
            set
            {
                jmbg = value;
                OnPropertyChanged("Jmbg");
            }
        }


        public Osoba(): base() { }

        public Osoba(string ime, string prezime, string jmbg, long id, bool obrisan) : base(id, obrisan)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;

        }



    }
}
