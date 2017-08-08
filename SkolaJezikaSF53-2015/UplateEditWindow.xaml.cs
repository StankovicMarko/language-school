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
    /// Interaction logic for UplateEditWindow.xaml
    /// </summary>
    public partial class UplateEditWindow : Window
    {
        protected Uplata original, editObject;
        protected MOD mod;

        public UplateEditWindow()
        {
            InitializeComponent();
        }

        public UplateEditWindow(Uplata uplata, MOD m = MOD.DODAVANJE) : this()
        {
            comboBoxKurs.ItemsSource = Aplikacija.Instanca.Kursevi;
            comboBoxUcenik.ItemsSource = Aplikacija.Instanca.Ucenici;

            this.original = uplata;
            this.mod = m;



            if (mod == MOD.IZMENA)
            {
                this.editObject = original.DeepCopy();
                this.DataContext = editObject;


            }
            else
            {
                
                original.Datum = DateTime.Today;
                this.DataContext = original;
            }

        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            if (mod == MOD.DODAVANJE)
            {
                original.Ucenik = comboBoxUcenik.SelectedItem as Ucenik;
                original.Kurs = comboBoxKurs.SelectedItem as Kurs;
                try
                {
                    original.Iznos = float.Parse(textBoxIznos.Text);

                }
                catch
                {
                    MessageBox.Show("Iznos mora biti broj, molimo izmenite.", "Greska", MessageBoxButton.OK);
                }

                Uplata novaUplata = UplateDAO.Create(original);
                Aplikacija.Instanca.Uplate.Add(novaUplata);

                novaUplata.Ucenik.Uplate.Add(novaUplata);

                //int indexOdUcenika = Aplikacija.Instanca.Ucenici.IndexOf(novaUplata.Ucenik);
                //Aplikacija.Instanca.Ucenici[indexOdUcenika].Uplate.Add(novaUplata);



            }
            else
            {
                original.setValues(editObject);
                UplateDAO.Update(original);

            }

            this.DialogResult = true;
            this.Close();
        
    }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
