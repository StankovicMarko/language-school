using SkolaJezikaSF53_2015.DAO;
using SkolaJezikaSF53_2015.Entiteti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {


        private Skola original, editObject;
        private CollectionViewSource cvsKor;
        private CollectionViewSource cvsNas;


        public AdminWindow()
        {

            InitializeComponent();
            txtUsername.IsEnabled = false;
            txtPassword.IsEnabled = false;

            cvsKor = new CollectionViewSource();
            cvsKor.Source = Aplikacija.Instanca.Korisnici;
            dgKorisnici.ItemsSource = cvsKor.View;
            cvsKor.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Ascending));
            dgKorisnici.IsReadOnly = true;
            dgKorisnici.SelectionMode = DataGridSelectionMode.Single;
            dgKorisnici.AutoGenerateColumns = false;

            DataGridTextColumn ime = new DataGridTextColumn();
            ime.Header = "Ime";
            ime.Binding = new Binding("Ime");
            DataGridTextColumn prezime = new DataGridTextColumn();
            prezime.Header = "Prezime";
            prezime.Binding = new Binding("Prezime");
            DataGridTextColumn jmbg = new DataGridTextColumn();
            jmbg.Header = "JMBG";
            jmbg.Binding = new Binding("Jmbg");
            DataGridCheckBoxColumn admin = new DataGridCheckBoxColumn();
            admin.Header = "Admin";
            admin.Binding = new Binding("Admin");

            dgKorisnici.Columns.Add(ime);
            dgKorisnici.Columns.Add(prezime);
            dgKorisnici.Columns.Add(jmbg);
            dgKorisnici.Columns.Add(admin);


            //skola
            original = Aplikacija.Instanca.Skola;

            this.editObject = original.DeepCopy();
            this.DataContext = editObject;


            //nastavnici

            cvsNas = new CollectionViewSource();
            cvsNas.Source = Aplikacija.Instanca.Nastavnici;
            dgNastavnici.ItemsSource = cvsNas.View;
            dgNastavnici.IsReadOnly = true;
            dgNastavnici.SelectionMode = DataGridSelectionMode.Single;
            dgNastavnici.AutoGenerateColumns = false;


            // Data Grid Nastavnika
            DataGridTextColumn dgnas = new DataGridTextColumn();
            dgnas.Header = "Ime";
            dgnas.Binding = new Binding("Ime");
            dgnas.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNastavnici.Columns.Add(dgnas);

            dgnas = new DataGridTextColumn();
            dgnas.Header = "Prezime";
            dgnas.Binding = new Binding("Prezime");
            dgnas.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNastavnici.Columns.Add(dgnas);

            dgnas = new DataGridTextColumn();
            dgnas.Header = "JMBG";
            dgnas.Binding = new Binding("Jmbg");
            dgnas.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNastavnici.Columns.Add(dgnas);

            dgnas = new DataGridTextColumn();
            dgnas.Header = "Plata";
            dgnas.Binding = new Binding("Plata");
            dgnas.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgNastavnici.Columns.Add(dgnas);


            // Data Grid Kurseva
            DataGridTextColumn col = new DataGridTextColumn();
            col.Header = "Jezik";
            col.Binding = new Binding("Jezik");
            col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(col);

            col = new DataGridTextColumn();
            col.Header = "Tip";
            col.Binding = new Binding("Tip");
            col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(col);

            col = new DataGridTextColumn();
            col.Header = "Cena";
            col.Binding = new Binding("Cena");
            col.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(col);

        }

        private void Pretraga(object sender, FilterEventArgs e)
        {

            Korisnik k = e.Item as Korisnik;
            if (k != null && rbIme.IsChecked == true)
            {
                e.Accepted = k.Ime.ToLower().Contains(txtSearch.Text.ToLower());
            }
            else if (k != null && rbPrezime.IsChecked == true)
            {
                e.Accepted = k.Prezime.ToLower().Contains(txtSearch.Text.ToLower());
            }
            else
            {
                e.Accepted = k.Usn.ToLower().Contains(txtSearch.Text.ToLower());

            }
        }


        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = new Korisnik();
            KorisniciEditWindow kew = new KorisniciEditWindow(k);
            if (kew.ShowDialog() == true)
            {
               
            }

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            Korisnik k = dgKorisnici.SelectedItem as Korisnik;
            KorisniciEditWindow kew = new KorisniciEditWindow(k, MOD.IZMENA);
            if (kew.ShowDialog() == true)
            {
               
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik k = dgKorisnici.SelectedItem as Korisnik;


                KorisniciDAO.Delete(k);

            }

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            original.setProps(editObject);
            SkolaDAO.Update(original);

            MessageBox.Show("Uspesno sacuvane izmene", "Uspeh!", MessageBoxButton.OK);


        }


        private void dgKorisnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnIzmeni.IsEnabled = true;
            btnObrisi.IsEnabled = true;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvsKor.Filter += new FilterEventHandler(Pretraga);
        }





    private void bDodajNas_Click(object sender, RoutedEventArgs e)
        {
            Nastavnik n = new Nastavnik();
            NastavniciEditWindow ne = new NastavniciEditWindow(n);
            if (ne.ShowDialog() == true)
            {

            }
        }

        private void bIzmeniNas_Click(object sender, RoutedEventArgs e)
        {
            Nastavnik n = dgNastavnici.SelectedItem as Nastavnik;
            NastavniciEditWindow ne = new NastavniciEditWindow(n, MOD.IZMENA);
            if (ne.ShowDialog() == true)
            {
              
            }
        }

        private void bObrisiNas_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Nastavnik n = dgNastavnici.SelectedItem as Nastavnik;


                NastavniciDAO.Delete(n);

            }
        }

        private void txtSearchNas_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvsNas.Filter += new FilterEventHandler(PretragaNas);
        }

        private void dgNastavnici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Nastavnik n = dgNastavnici.SelectedItem as Nastavnik;
            if (n != null)
            {

                dgKursevi.ItemsSource = n.Kursevi;
                dgKursevi.IsReadOnly = true;
                dgKursevi.SelectionMode = DataGridSelectionMode.Single;
                dgKursevi.AutoGenerateColumns = false;

            }
        }


        private void dgKursevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PretragaNas(object sender, FilterEventArgs e)
        {

            Nastavnik n = e.Item as Nastavnik;
            if (n != null && rbImeNas.IsChecked == true)
            {
                e.Accepted = n.Ime.ToLower().Contains(txtSearchNas.Text.ToLower());
            }
            else if (n != null && rbPrezimeNas.IsChecked == true)
            {
                e.Accepted = n.Prezime.ToLower().Contains(txtSearchNas.Text.ToLower());
            }
            else
            {
                e.Accepted = n.Jmbg.ToLower().Contains(txtSearchNas.Text.ToLower());

            }
        }

       
}
}