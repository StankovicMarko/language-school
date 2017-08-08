using SkolaJezikaSF53_2015.Entiteti;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezikaSF53_2015
{
    class Aplikacija
    {
        public const string CONN_STR = @"data source=.\SQLEXPRESS; initial catalog=SkolaJezikaSF53_2015; integrated security=true";
        public ObservableCollection<Ucenik> Ucenici { get; set; }
        public ObservableCollection<Kurs> Kursevi { get; set; }
        public ObservableCollection<Uplata> Uplate { get; set; }
        public ObservableCollection<Nastavnik> Nastavnici { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public Skola Skola;


        private static Aplikacija instanca = new Aplikacija();
        public static Aplikacija Instanca
        {
            get { return instanca; }
        }

        private Aplikacija()
        {
            Ucenici = new ObservableCollection<Ucenik>();
            Kursevi = new ObservableCollection<Kurs>();
            Uplate = new ObservableCollection<Uplata>();
            Nastavnici = new ObservableCollection<Nastavnik>();
            Korisnici = new ObservableCollection<Korisnik>();
            // korisnici.Add(new Korisnik("a", "a", true, "marko", "lepan", "123", 1, false));
            Skola = new Skola();
           
        }


        public ObservableCollection<Ucenik> KopijaUcenika()
        {
            var cu = new ObservableCollection<Ucenik>();

            foreach (Ucenik u in this.Ucenici)
            {

                cu.Add(u);
            
            }

            return cu;
        }

    }
}
