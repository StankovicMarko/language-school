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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SkolaJezikaSF53_2015.Entiteti;

namespace SkolaJezikaSF53_2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            bool logged = false;
            bool admin = false;
            foreach (Korisnik kor in Aplikacija.Instanca.Korisnici)
            {

                if (kor.Usn == tbUsn.Text && kor.Psw == pbPsw.Password)
                {
                    logged = true;

                    if (kor.Admin == true) {
                        admin = true;
                    }
                   
                }
                
           }
            if (!logged)
            {
                MessageBox.Show("Pogresni podaci");
            }
            else
            {
                if (admin) {
                    AdminWindow adminWindow = new AdminWindow();
                    adminWindow.ShowDialog();
                }
                
            
            else{

                    ZaposleniWindow zw = new ZaposleniWindow();
                    zw.ShowDialog();
                }
            }
        }


    }
    }

