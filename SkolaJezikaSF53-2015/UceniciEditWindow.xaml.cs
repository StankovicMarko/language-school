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
    /// Interaction logic for UceniciEditWindow.xaml
    /// </summary>
    public partial class UceniciEditWindow : Window
    {
        protected Ucenik original, editObject;
        protected MOD mod;

        public UceniciEditWindow()
        {
            InitializeComponent();
        }
        public UceniciEditWindow(Ucenik u, MOD m = MOD.DODAVANJE) : this()
        {

            this.original = u;
            this.mod = m;
            this.editObject = original.DeepCopy();
            this.DataContext = editObject;

        }

        private void btnOk_Click(Object sender, RoutedEventArgs e)
        {

            original.Ime = tbImeUce.Text;
            original.Prezime = tbPrezimeUce.Text;
            original.Jmbg = tbJmbgUce.Text;

            original.setValues(editObject);
            if (mod == MOD.DODAVANJE)
            {
                Aplikacija.Instanca.Ucenici.Add(original);
                UceniciDAO.Create(original);
            }
            else
            {

                UceniciDAO.Update(original);
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
