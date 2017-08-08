using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Korisnik : Osoba
    {

        private string usn;
        private string psw;
        private bool admin;

        public string Usn {
            get
            {
                return usn;
            }
            set
            {
                usn = value;
                OnPropertyChanged("Usn");
            }
        }
        public string Psw {
             get
            {
                return psw;
            }
            set
            {
                psw = value;
                OnPropertyChanged("Psw");
            }
        }
        public bool Admin { 
                 get
            {
                return admin;
            }
            set
            {
                admin = value;
                OnPropertyChanged("Admin");
            }
        }

        public Korisnik() : base()
        {

        }

        public Korisnik(string usn, string psw, bool admin, string ime, string  prezime, string jmbg, long id, bool obrisan) : base(ime, prezime, jmbg, id, obrisan)
        {
            this.usn = usn;
            this.psw = psw;
            this.admin = admin;
        }


        public Korisnik DeepCopy()
        {
            Korisnik copy = new Korisnik (this.Usn, this.Psw, this.Admin, this.Ime, this.Prezime, this.Jmbg, this.Id, this.Obrisan);
            return copy;
        }

        internal void setValues(Korisnik copyObj)
        {
            this.Ime = copyObj.Ime;
            this.Prezime = copyObj.Prezime;
            this.Jmbg = copyObj.Jmbg;
            this.Usn = copyObj.Usn;
            this.psw = copyObj.Psw;
            this.Id = copyObj.Id;
            this.Obrisan = copyObj.Obrisan;
            this.Admin = copyObj.Admin;
        }
    }
}
