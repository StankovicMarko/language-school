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
using SkolaJezikaSF53_2015.Entiteti;
using SkolaJezikaSF53_2015.DAO;

namespace SkolaJezikaSF53_2015
{
    /// <summary>
    /// Interaction logic for KorisniciEditWindow.xaml
    /// </summary>
    public enum MOD { DODAVANJE, IZMENA };

    public partial class KorisniciEditWindow : Window
    {

        protected Korisnik original, editObject;
        protected MOD mod;

        public KorisniciEditWindow()
        {
            InitializeComponent();
        }

        public KorisniciEditWindow(Korisnik k, MOD m = MOD.DODAVANJE) : this()
        {

            this.original = k;
            this.mod = m;
            this.editObject = original.DeepCopy();
            this.DataContext = editObject;
     
        }

      private void btnOk_Click(Object sender, RoutedEventArgs e)
      {
            original.Ime = tbIme.Text;
            original.Prezime = tbPrezime.Text;
            original.Jmbg = tbJMBG.Text;
            original.Usn = tbKorisnickoIme.Text;
            original.Psw = tbLozinka.Text;
            original.Admin = (bool)cbAdmin.IsChecked;

            original.setValues(editObject);
            if (mod == MOD.DODAVANJE)
            {
                Aplikacija.Instanca.Korisnici.Add(original);
                KorisniciDAO.Create(original);
            }
            else
            {
               
                KorisniciDAO.Update(original);
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
