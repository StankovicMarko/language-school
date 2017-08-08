using SkolaJezikaSF53_2015.Entiteti;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezikaSF53_2015.DAO
{
    class UceniciDAO
    {
        public static void Create(Ucenik u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into ucenici values ( @obrisan, @ime, @prezime, @jmbg)";
                cmd.Parameters.Add("@ime", u.Ime);
                cmd.Parameters.Add("@prezime", u.Prezime);
                cmd.Parameters.Add("@jmbg", u.Jmbg);
                cmd.Parameters.Add("@obrisan", u.Obrisan);
         
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
                cmd.CommandText = "select * from  ucenici where obrisan = 0";
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlda.Fill(ds, "ucenici");
                foreach (DataRow row in ds.Tables["ucenici"].Rows)
                {
                    Ucenik u = new Ucenik();
                    u.Id = (long)row["id"];
                    u.Ime = (string)row["ime"];
                    u.Prezime = (string)row["prezime"];
                    u.Jmbg = (string)row["jmbg"];
                    u.Obrisan = (bool)row["obrisan"];
                    Aplikacija.Instanca.Ucenici.Add(u);
                }
            }

        }

        public static void Update(Ucenik u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update ucenici set ime=@ime, prezime=@prezime, jmbg=@jmbg, obrisan=@obrisan where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", u.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", u.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", u.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", u.Jmbg));
                cmd.Parameters.Add(new SqlParameter("@obrisan", u.Obrisan));

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

        public static void Delete(Ucenik u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Ucenici.Remove(u);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update ucenici set obrisan=@obrisan where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", u.Id));
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
