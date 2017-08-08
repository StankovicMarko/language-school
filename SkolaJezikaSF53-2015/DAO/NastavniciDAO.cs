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
    class NastavniciDAO
    {
        public static void Create(Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into nastavnici values (@obrisan, @ime, @prezime, @jmbg, @plata)";
                cmd.Parameters.Add("@ime", n.Ime);
                cmd.Parameters.Add("@prezime", n.Prezime);
                cmd.Parameters.Add("@jmbg", n.Jmbg);
       
                cmd.Parameters.Add("@obrisan", n.Obrisan);
                cmd.Parameters.Add("@plata", n.Plata);
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
                cmd.CommandText = "select * from  nastavnici where obrisan = 0";
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlda.Fill(ds, "nastavnici");
                foreach (DataRow row in ds.Tables["nastavnici"].Rows)
                {
                    Nastavnik n = new Nastavnik();
                    n.Id = (long)row["id"];
                    n.Ime = (string)row["ime"];
                    n.Prezime = (string)row["prezime"];
                    n.Jmbg = (string)row["jmbg"];
                    n.Plata = (float)row["plata"];
                    n.Obrisan = (bool)row["obrisan"];
                    Aplikacija.Instanca.Nastavnici.Add(n);
                }
            }

           
            

        }

        public static void Update(Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update nastavnici set obrisan=@obrisan, ime=@ime, prezime=@prezime, jmbg=@jmbg, plata=@plata where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", n.Id));
                cmd.Parameters.Add(new SqlParameter("@ime", n.Ime));
                cmd.Parameters.Add(new SqlParameter("@prezime", n.Prezime));
                cmd.Parameters.Add(new SqlParameter("@jmbg", n.Jmbg));
                cmd.Parameters.Add(new SqlParameter("@plata", n.Plata));
                cmd.Parameters.Add(new SqlParameter("@obrisan", n.Obrisan));

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

        public static void Delete(Nastavnik n)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Nastavnici.Remove(n);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update nastavnici set obrisan=@obrisan where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", n.Id));
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

