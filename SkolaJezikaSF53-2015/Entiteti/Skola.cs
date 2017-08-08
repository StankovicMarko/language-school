using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    class Skola : INotifyPropertyChanged
    {
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string website;
        private string pib;
        private string maticniBroj;
        private string ziroRacun;

        public event PropertyChangedEventHandler PropertyChanged;

        public long Id { set; get; }

        public string Naziv
        {
            get
            {
                return naziv;
            }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        public string Adresa
        {
            get
            {
                return adresa;
            }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }
        public string Telefon
        {
            get
            {
                return telefon;
            }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Website
        {
            get
            {
                return website;
            }
            set
            {
                website = value;
                OnPropertyChanged("Website");
            }
        }
        public string Pib
        {
            get
            {
                return pib;
            }
            set
            {
                pib = value;
                OnPropertyChanged("Pib");
            }
        }
        public string MaticniBroj
        {
            get
            {
                return maticniBroj;
            }
            set
            {
                maticniBroj = value;
                OnPropertyChanged("MaticniBroj");
            }
        }
        public string ZiroRacun
        {
            get
            {
                return ziroRacun;
            }
            set
            {
                ziroRacun = value;
                OnPropertyChanged("ZiroRacun");
            }
        }

        public Skola(long id, string naziv, string adresa, string telefon, string email, string website, string pib, string maticniBroj, string ziroRacun)
        {
            this.Id = id;
            this.naziv = naziv;
            this.adresa = adresa;
            this.telefon = telefon;
            this.email = email;
            this.website = website;
            this.pib = pib;
            this.maticniBroj = maticniBroj;
            this.ziroRacun = ziroRacun;
    }

        public Skola() { }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler h = PropertyChanged;

            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propName));
            }

        }

        public Skola DeepCopy()
        {
            Skola copy = new Skola(this.Id, this.Naziv, this.Adresa, this.Telefon, this.Email, this.Website, this.MaticniBroj, this.ZiroRacun, this.Pib);
            return copy;
        }

        public void setProps(Skola s)
        {
            this.Id = s.Id;
            this.Naziv = s.Naziv;
            this.Adresa = s.Adresa;
            this.Email = s.Email;
            this.Website = s.Website;
            this.Telefon = s.Telefon;
            this.ZiroRacun = s.ZiroRacun;
            this.Pib = s.Pib;
            this.MaticniBroj = s.MaticniBroj;

        }

    }
    
}
