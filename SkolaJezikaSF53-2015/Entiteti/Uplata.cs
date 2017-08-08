using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Uplata : Identifikacija
    {
        private Ucenik ucenik;
        private float iznos;
        private Kurs kurs;
        private DateTime datum;



        public Ucenik Ucenik {
            set
            {
                ucenik = value;
                OnPropertyChanged("Ucenik");
            }
            get {
                return ucenik;
            } }
        public float Iznos
        {
            set
            {
                iznos = value;
                OnPropertyChanged("Iznos");
            }
            get
            {
                return iznos;
            }
        }
        public Kurs Kurs
        {
            set
            {
                kurs = value;
                OnPropertyChanged("Ucenik");
            }
            get
            {
                return kurs;
            }
        }
        public DateTime Datum
        {
            set
            {
                datum = value;
                OnPropertyChanged("Datum");
            }
            get
            {
                return datum;
            }
        }


        public Uplata(long id, bool obrisan, Ucenik ucenik, float iznos, Kurs kurs, DateTime datum) : base(id, obrisan)
        {

            this.Ucenik = ucenik;
            this.Iznos = iznos;
            this.Kurs = kurs;
            this.Datum = datum;
        }

        public Uplata() { }

        public Uplata DeepCopy()
        {
            Uplata copy = new Uplata(this.Id, this.Obrisan, this.Ucenik, this.Iznos, this.Kurs, this.Datum);
            return copy;

        }

        public void setValues(Uplata u)
        {
            this.Id = u.Id;
            this.Obrisan = u.Obrisan;
            this.Kurs = u.Kurs;
            this.Ucenik = u.Ucenik;
            this.Iznos = u.Iznos;
            this.Datum = u.Datum;

        }
    }
}
