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
    class UplateDAO
    {
        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from uplate";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "uplate");

                foreach (DataRow row in ds.Tables["uplate"].Rows)
                {

                    Uplata u = new Uplata();
                    u.Id = (long)row["id"];
                    long kurs_id = (long)row["kurs_id"];
                    long ucenik_id = (long)row["ucenik_id"];


                    foreach (Kurs ku in Aplikacija.Instanca.Kursevi)
                    {

                        if (ku.Id == kurs_id)
                        {
                            u.Kurs = ku;
                           // Aplikacija.Instanca.Uplate.Add(u);
                        }
                    }


                    foreach (Ucenik ucen in Aplikacija.Instanca.Ucenici)
                    {
                        if (ucen.Id == ucenik_id)
                        {
                            u.Ucenik = ucen;
                            ucen.Uplate.Add(u);

                        }
                    }


                    u.Iznos = (float)row["iznos"];
                    u.Datum = (DateTime)row["datum"];

                    Aplikacija.Instanca.Uplate.Add(u);


                }
            }
        }



        public static Uplata Create(Uplata u)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into uplate values(@obrisan, @kurs_id, @ucenik_id, @iznos, @datum);SELECT SCOPE_IDENTITY()";
                cmd.Parameters.Add(new SqlParameter("@obrisan", u.Obrisan));
                cmd.Parameters.Add(new SqlParameter("@kurs_id", u.Kurs.Id));
                cmd.Parameters.Add(new SqlParameter("@ucenik_id", u.Ucenik.Id));
                cmd.Parameters.Add(new SqlParameter("@iznos", u.Iznos));
                cmd.Parameters.Add(new SqlParameter("@datum", u.Datum));
               


                try
                {
                  
                    long id = long.Parse(cmd.ExecuteScalar().ToString());
                    u.Id = id;

                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "greska", MessageBoxButton.OK);
                }

                return u;

            }

        }



        public static void Update(Uplata u)
        {

            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update uplate set kurs_id=@kurs_id, ucenik_id=@ucenik_id, iznos=@iznos, datum=@datum where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", u.Id));
                cmd.Parameters.Add(new SqlParameter("@kurs_id", u.Kurs.Id));
                cmd.Parameters.Add(new SqlParameter("@ucenik_id", u.Ucenik.Id));
                cmd.Parameters.Add(new SqlParameter("@cena", u.Iznos));
                cmd.Parameters.Add(new SqlParameter("@datum", u.Datum));

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
