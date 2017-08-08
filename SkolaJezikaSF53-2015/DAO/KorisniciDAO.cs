using SkolaJezikaSF53_2015.Entiteti;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;

namespace SkolaJezikaSF53_2015.DAO
{
    class KorisniciDAO
    {
        public static void Create(Korisnik korisnik)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into korisnici values ( @obrisan, @ime, @prezime, @jmbg, @usn, @psw, @isAdmin)";
                cmd.Parameters.Add("@ime", korisnik.Ime);
                cmd.Parameters.Add("@prezime", korisnik.Prezime);
                cmd.Parameters.Add("@jmbg", korisnik.Jmbg);
                cmd.Parameters.Add("@usn", korisnik.Usn);
                cmd.Parameters.Add("@psw", korisnik.Psw);
                
                cmd.Parameters.Add("@obrisan", korisnik.Obrisan);
                cmd.Parameters.Add("@isAdmin", korisnik.Admin);
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {

                    MessageBox.Show(e.Message, "greska", MessageBoxButton.OK);
                }

            }

        }

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from  korisnici where obrisan = 0";
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlda.Fill(ds, "korisnici");
                foreach (DataRow row in ds.Tables["korisnici"].Rows)
                {
                    Korisnik k = new Korisnik();
                    k.Id = (long)row["id"];
                    k.Ime = (string)row["ime"];
                    k.Prezime = (string)row["prezime"];
                    k.Usn = (string)row["usn"];
                    k.Psw = (string)row["psw"];
                    k.Jmbg = (string)row["jmbg"];
                    k.Admin = (bool)row["isAdmin"];
                    k.Obrisan = (bool)row["obrisan"];
                    Aplikacija.Instanca.Korisnici.Add(k);
                }
            }

        }

        public static void Update(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update korisnici set ime=@ime, prezime=@prezime, jmbg=@jmbg, usn=@usn, psw=@psw, isAdmin=@isAdmin, obrisan=@obrisan where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", k.Jmbg));
                cmd.Parameters.Add(new SqlParameter("@usn", k.Usn));
                cmd.Parameters.Add(new SqlParameter("@psw", k.Psw));
                cmd.Parameters.Add(new SqlParameter("@isAdmin", k.Admin));
                cmd.Parameters.Add(new SqlParameter("@obrisan", k.Obrisan));
            
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "greska", MessageBoxButton.OK);
            }
            }

        }

        public static void Delete(Korisnik k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Korisnici.Remove(k);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update korisnici set obrisan=@obrisan where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@obrisan", 1));

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "greska", MessageBoxButton.OK);
                }

            }
        }
    }
}
