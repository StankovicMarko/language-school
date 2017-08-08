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
    /// Interaction logic for NastavniciEditWindow.xaml
    /// </summary>
    public partial class NastavniciEditWindow : Window
    {
        protected Nastavnik original, editObject;
        protected MOD mod;

        public NastavniciEditWindow()
        {
            InitializeComponent();
        }
        public NastavniciEditWindow(Nastavnik n, MOD m = MOD.DODAVANJE) : this()
        {

            this.original = n;
            this.mod = m;
            this.editObject = original.DeepCopy();
            this.DataContext = editObject;

        }

        private void btnOk_Click(Object sender, RoutedEventArgs e)
        {
           
            original.Ime = tbImeNas.Text;
            original.Prezime = tbPrezimeNas.Text;
            original.Jmbg = tbJmbgNas.Text;

            
            try {
                original.Plata = float.Parse(tbPlata.Text);
                  
            }
            catch
            {
                MessageBox.Show("Plata mora biti broj, molimo izmenite.", "Greska", MessageBoxButton.OK);
            } 
           

            original.setValues(editObject);
            if (mod == MOD.DODAVANJE)
            {
                Aplikacija.Instanca.Nastavnici.Add(original);
                NastavniciDAO.Create(original);
            }
            else
            {

                NastavniciDAO.Update(original);
            }

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancel_Click(Object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
