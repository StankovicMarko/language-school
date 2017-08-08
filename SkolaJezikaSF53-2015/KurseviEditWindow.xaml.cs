using SkolaJezikaSF53_2015.DAO;
using SkolaJezikaSF53_2015.Entiteti;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for KurseviEditWindow.xaml
    /// </summary>
    public partial class KurseviEditWindow : Window
    {

        protected Kurs original, editObject;
        protected MOD mod;
        

        public KurseviEditWindow()
        {
            InitializeComponent();
        }


        public KurseviEditWindow(Kurs n, MOD m = MOD.DODAVANJE) : this()
        {

            this.original = n;
            this.mod = m;
            this.editObject = original.DeepCopy();
            this.DataContext = editObject;

            //SelectedItem = "{Binding ElementName=dgKursevi, Path=SelectedItem.Nastavnik}"
            comboBoxNastavnik.ItemsSource = Aplikacija.Instanca.Nastavnici;


        }
        private void btnOk_Click(Object sender, RoutedEventArgs e)
        {

            original.Jezik = tbJezik.Text;
            original.Tip = tbTip.Text;
            // original.Cena = tbCena.Text;

            Nastavnik nas = comboBoxNastavnik.SelectedItem as Nastavnik;
            foreach (Nastavnik n in Aplikacija.Instanca.Nastavnici) {
                if (n.Id == nas.Id) {

                    original.Nastavnik = n;
                }
            }
            

            try
            {
                original.Cena = float.Parse(tbCena.Text);

            }
            catch
            {
                MessageBox.Show("Cena kursa treba da bude broj.", "Greska", MessageBoxButton.OK);
            }


            original.setValues(editObject);
            //Console.WriteLine(original);


            if (mod == MOD.DODAVANJE)
            {
                Aplikacija.Instanca.Kursevi.Add(original);
                
                Kurs ori = KurseviDAO.Create(original);

                int indexOdNastavnik = Aplikacija.Instanca.Nastavnici.IndexOf(nas);
                Aplikacija.Instanca.Nastavnici[indexOdNastavnik].Kursevi.Add(ori);


                PredajeDAO.Create(nas.Id, ori.Id);
            }
            else
            {

                KurseviDAO.Update(original);

            }

            this.DialogResult = true;
            this.Close();
        }

        private void comboBoxNastavnik_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
        }

        private void btnCancel_Click(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
