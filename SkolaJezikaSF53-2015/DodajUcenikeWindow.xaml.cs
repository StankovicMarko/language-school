using SkolaJezikaSF53_2015.DAO;
using SkolaJezikaSF53_2015.Entiteti;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SkolaJezikaSF53_2015
{
    /// <summary>
    /// Interaction logic for DodajUcenikeWindow.xaml
    /// </summary>
    public partial class DodajUcenikeWindow : Window
    {
        private Kurs izabraniKurs;
        private ObservableCollection<Ucenik> uceniciNaKursu = new ObservableCollection<Ucenik>();
        private ObservableCollection<Ucenik> sviUcenici = new ObservableCollection<Ucenik>();


        public DodajUcenikeWindow()
        {
            InitializeComponent();
        }


        public DodajUcenikeWindow(List<Ucenik> uceniciNaKursu, Kurs izabraniKur) : this()
        {
            this.izabraniKurs = izabraniKur;

            foreach (Ucenik uc in uceniciNaKursu)
            {
                this.uceniciNaKursu.Add(uc);

            }


            var copyUcenici = Aplikacija.Instanca.KopijaUcenika();
            this.sviUcenici = copyUcenici;

            foreach (Ucenik uc in this.uceniciNaKursu)
            {
                if (this.sviUcenici.Contains(uc))
                {
                    this.sviUcenici.Remove(uc);

                }
            }


            listBoxNaKursu.ItemsSource = this.uceniciNaKursu;
            listBoxSviUcenici.ItemsSource = this.sviUcenici;


        }

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {

            Ucenik selectedUcenik = listBoxNaKursu.SelectedItem as Ucenik;

            if (selectedUcenik != null)
            {

                this.uceniciNaKursu.Remove(selectedUcenik);
                this.sviUcenici.Add(selectedUcenik);


                int indexOdKursa = Aplikacija.Instanca.Kursevi.IndexOf(izabraniKurs);
                Aplikacija.Instanca.Kursevi[indexOdKursa].Ucenici.Remove(selectedUcenik);

                int indexOdUcenika = Aplikacija.Instanca.Ucenici.IndexOf(selectedUcenik);
                Aplikacija.Instanca.Ucenici[indexOdUcenika].Kursevi.Remove(izabraniKurs);


                PohadjaDAO.Delete(selectedUcenik.Id, izabraniKurs.Id);
            }
            else
            {
                MessageBox.Show("Izaberite Ucenika!", "Greska!!!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


        }


        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {

            Ucenik selectedUcenik = listBoxSviUcenici.SelectedItem as Ucenik;

           // Console.WriteLine(izabraniKurs);

            if (selectedUcenik != null)
            {
                if (!this.uceniciNaKursu.Contains(selectedUcenik))
                {

                    this.uceniciNaKursu.Add(selectedUcenik);
                    this.sviUcenici.Remove(selectedUcenik);

                    //Console.WriteLine(selectedUcenik);

                    selectedUcenik.Kursevi.Add(izabraniKurs);


                    int indexOdKursa = Aplikacija.Instanca.Kursevi.IndexOf(izabraniKurs);
                    Aplikacija.Instanca.Kursevi[indexOdKursa].Ucenici.Add(selectedUcenik);

                    PohadjaDAO.Create(selectedUcenik.Id, izabraniKurs.Id);


                }
            }
            else
            {
                MessageBox.Show("Izaberite Ucenika!", "Greska!!!", MessageBoxButton.OK, MessageBoxImage.Warning);

            }


        }
    }
}
