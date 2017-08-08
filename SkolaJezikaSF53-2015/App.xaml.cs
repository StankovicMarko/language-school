using SkolaJezikaSF53_2015.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezikaSF53_2015
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public App()
        {

            KorisniciDAO.Read();
            Aplikacija.Instanca.Skola = SkolaDAO.Read();
            NastavniciDAO.Read();
            KurseviDAO.Read();
            UceniciDAO.Read();
            PredajeDAO.Read();
            PohadjaDAO.Read();
            UplateDAO.Read();


        }
    }
}
