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
    /// Interaction logic for ZaposleniWindow.xaml
    /// </summary>
    public partial class ZaposleniWindow : Window
    {

        private CollectionViewSource cvsKur;
        private CollectionViewSource cvsUce;
        private CollectionViewSource cvsUpl;
       // private Kurs trenutniKurs;

        public ZaposleniWindow()
        {

            InitializeComponent();

            cvsKur = new CollectionViewSource();
            cvsKur.Source = Aplikacija.Instanca.Kursevi;
            dgKursevi.ItemsSource = cvsKur.View;
            cvsKur.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Ascending));
            dgKursevi.IsReadOnly = true;
            dgKursevi.SelectionMode = DataGridSelectionMode.Single;
            dgKursevi.AutoGenerateColumns = false;

            DataGridTextColumn dgkur = new DataGridTextColumn();
            dgkur.Header = "Jezik";
            dgkur.Binding = new Binding("Jezik");
            dgkur.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(dgkur);

            dgkur = new DataGridTextColumn();
            dgkur.Header = "Tip";
            dgkur.Binding = new Binding("Tip");
            dgkur.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(dgkur);

            dgkur = new DataGridTextColumn();
            dgkur.Header = "Iznos(Cena)";
            dgkur.Binding = new Binding("Cena");
            dgkur.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(dgkur);

            dgkur = new DataGridTextColumn();
            dgkur.Header = "Nastavnik";
            dgkur.Binding = new Binding("Nastavnik");
            dgkur.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgKursevi.Columns.Add(dgkur);



          ///ucenicii

            cvsUce = new CollectionViewSource();
            cvsUce.Source = Aplikacija.Instanca.Ucenici;
            dgUcenici.ItemsSource = cvsUce.View;
            dgUcenici.IsReadOnly = true;
            dgUcenici.SelectionMode = DataGridSelectionMode.Single;
            dgUcenici.AutoGenerateColumns = false;

            DataGridTextColumn dgUce = new DataGridTextColumn();
            dgUce.Header = "Ime";
            dgUce.Binding = new Binding("Ime");
            dgUce.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUcenici.Columns.Add(dgUce);

            dgUce = new DataGridTextColumn();
            dgUce.Header = "Prezime";
            dgUce.Binding = new Binding("Prezime");
            dgUce.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUcenici.Columns.Add(dgUce);

            dgUce = new DataGridTextColumn();
            dgUce.Header = "JMBG";
            dgUce.Binding = new Binding("Jmbg");
            dgUce.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUcenici.Columns.Add(dgUce);


            //uplate
            cvsUpl = new CollectionViewSource();
            cvsUpl.Source = Aplikacija.Instanca.Uplate;
            dgUplate.ItemsSource = cvsUpl.View;
            dgUplate.IsReadOnly = true;
            dgUplate.SelectionMode = DataGridSelectionMode.Single;
            dgUplate.AutoGenerateColumns = false;

            DataGridTextColumn dgUpl = new DataGridTextColumn();
            dgUpl.Header = "Ucenik";
            dgUpl.Binding = new Binding("Ucenik");
            dgUpl.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(dgUpl);

            dgUpl = new DataGridTextColumn();
            dgUpl.Header = "Iznos";
            dgUpl.Binding = new Binding("Iznos");
            dgUpl.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(dgUpl);

            dgUpl = new DataGridTextColumn();
            dgUpl.Header = "Kurs";
            dgUpl.Binding = new Binding("Kurs");
            dgUpl.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(dgUpl);

            dgUpl = new DataGridTextColumn();
            dgUpl.Header = "Datum";
            dgUpl.Binding = new Binding("Datum");
            dgUpl.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            dgUplate.Columns.Add(dgUpl);





        }

        private void txtSearchKur_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvsKur.Filter += new FilterEventHandler(PretragaKur);
        }

        private void dgKursevi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (tabControl.SelectedIndex == 0)
            {
                Kurs k = dgKursevi.SelectedItem as Kurs;
                try { listBoxUcenici.ItemsSource = k.Ucenici; }
                catch { }

            }
            
          


        }

        private void PretragaKur(object sender, FilterEventArgs e)
        {

            Kurs k = e.Item as Kurs;
            if (k != null && rbJezik.IsChecked == true)
            {
                e.Accepted = k.Jezik.ToLower().Contains(txtSearchKur.Text.ToLower());
            }  
            else
            {
                e.Accepted = k.Tip.ToLower().Contains(txtSearchKur.Text.ToLower());

            }
        }

        private void btnDodajKur_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = new Kurs();
            KurseviEditWindow kew = new KurseviEditWindow(k);
            if (kew.ShowDialog() == true)
            {

            }
        }

        private void btnIzmeniKur_Click(object sender, RoutedEventArgs e)
        {
            Kurs k = dgKursevi.SelectedItem as Kurs;
            KurseviEditWindow kew = new KurseviEditWindow(k, MOD.IZMENA);
            if (kew.ShowDialog() == true)
            {

            }

        }

        private void btnObrisiKur_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Kurs k = dgKursevi.SelectedItem as Kurs;


                KurseviDAO.Delete(k);

            }
        }

        private void txtSearchUce_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvsUce.Filter += new FilterEventHandler(PretragaUce);
        }

        private void PretragaUce(object sender, FilterEventArgs e)
        {

            Ucenik u = e.Item as Ucenik;
            if (u != null && rbImeUce.IsChecked == true)
            {
                e.Accepted = u.Ime.ToLower().Contains(txtSearchUce.Text.ToLower());
            }
            else if (u != null && rbPrezimeUce.IsChecked == true)
            {
                e.Accepted = u.Prezime.ToLower().Contains(txtSearchUce.Text.ToLower());
            }
            else
            {
                e.Accepted = u.Jmbg.ToLower().Contains(txtSearchUce.Text.ToLower());

            }
        }

        private void bDodajUce_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = new Ucenik();
            UceniciEditWindow uew = new UceniciEditWindow(u);
            if (uew.ShowDialog() == true)
            {

            }
        }

        private void bIzmeniUce_Click(object sender, RoutedEventArgs e)
        {
            Ucenik u = dgUcenici.SelectedItem as Ucenik;
            UceniciEditWindow uew = new UceniciEditWindow(u, MOD.IZMENA);
            if (uew.ShowDialog() == true)
            {

            }
        }

        private void bObrisiUce_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Da li ste sigurni?", "Potvrda", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Ucenik u = dgUcenici.SelectedItem as Ucenik;


                UceniciDAO.Delete(u);

            }

        }

        private void dgUcenici_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(tabControl.SelectedIndex == 1)
            {
                Ucenik u = dgUcenici.SelectedItem as Ucenik;
                try { listBoxKursevi.ItemsSource = u.Kursevi; }
                catch { }
                
            }
           
        }

        private void txtSearchUpl_TextChanged(object sender, TextChangedEventArgs e)
        {
            cvsUpl.Filter += new FilterEventHandler(PretragaUpl);
        }

        private void PretragaUpl(object sender, FilterEventArgs e)
        {

            Uplata u = e.Item as Uplata;
            if (u != null && rbKurs.IsChecked == true)
            {
                string sadrzaj = u.Kurs.Jezik.ToLower() + u.Kurs.Tip.ToLower() + u.Kurs.Cena.ToString().ToLower();
                e.Accepted = sadrzaj.Contains(txtSearchUpl.Text.ToLower());
            }  
            else
            {
                string sadrzaj = u.Ucenik.Ime.ToLower() + u.Ucenik.Prezime.ToLower() + u.Ucenik.Jmbg.ToLower();
                e.Accepted = sadrzaj.Contains(txtSearchUpl.Text.ToLower());

            }
        }

        private void bDodajUpl_Click(object sender, RoutedEventArgs e)
        {
            Uplata uplata = new Uplata();

            UplateEditWindow uew = new UplateEditWindow(uplata);
            uew.ShowDialog();
        }

        private void bIzmeniUpl_Click(object sender, RoutedEventArgs e)
        {
            Uplata selectedUplata = dgUplate.SelectedItem as Uplata;

            UplateEditWindow uew = new UplateEditWindow(selectedUplata, MOD.IZMENA);
            uew.ShowDialog();
        }

        private void bObrisiUpl_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnDodajUcenika_Click(object sender, RoutedEventArgs e)
        {

            //Kurs k = dgKursevi.SelectedItem as Kurs;

            DodajUcenikeWindow duw = new DodajUcenikeWindow(listBoxUcenici.Items.Cast<Ucenik>().ToList(), dgKursevi.SelectedItem as Kurs);
            duw.ShowDialog();
        }
    }
}