using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015.Entiteti
{
    public class Identifikacija: INotifyPropertyChanged
    {


        private bool obrisan;

        public event PropertyChangedEventHandler PropertyChanged;

        public long Id { get; set; }
        public bool Obrisan {
            get
            {
                return obrisan;
            }

            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }

        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        public Identifikacija() { }

        public Identifikacija(long id, bool obrisan)
        {
            this.Id = id;
            this.Obrisan = obrisan;


        }
    }

}
