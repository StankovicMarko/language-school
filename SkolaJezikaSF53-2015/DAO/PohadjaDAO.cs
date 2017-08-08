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
    public class PohadjaDAO
    {

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from pohadja";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "pohadja");

                foreach (DataRow row in ds.Tables["pohadja"].Rows)
                {


                    long ucenik_Id = (long)row["ucenik_id"];
                    long kurs_Id = (long)row["kurs_id"];


                    Ucenik foundUcenik = null;
                    Kurs foundKurs = null;


                    foreach (Ucenik u in Aplikacija.Instanca.Ucenici)
                    {
                        if (u.Id == ucenik_Id)
                        {
                            foundUcenik = u;
                            break;
                        }
                    }

                    foreach (Kurs k in Aplikacija.Instanca.Kursevi)
                    {
                        if (k.Id == kurs_Id)
                        {
                            foundKurs = k;
                            break;
                        }
                    }

                  

                    int indexOfUcenika = Aplikacija.Instanca.Ucenici.IndexOf(foundUcenik);
                    Aplikacija.Instanca.Ucenici[indexOfUcenika].Kursevi.Add(foundKurs);

                  
                    int indexOfKursa = Aplikacija.Instanca.Kursevi.IndexOf(foundKurs);
                    Aplikacija.Instanca.Kursevi[indexOfKursa].Ucenici.Add(foundUcenik);



                }

            }
        }


        public static void Create(long ucenik_id, long kurs_id)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into pohadja values(@ucenik_id, @kurs_id)";
                cmd.Parameters.Add(new SqlParameter("@ucenik_id", ucenik_id));
                cmd.Parameters.Add(new SqlParameter("@kurs_id", kurs_id));


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


        public static void Delete(long ucenik_id, long kurs_id)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from pohadja where ucenik_id=@ucenik_id and kurs_id=@kurs_id";
                cmd.Parameters.Add(new SqlParameter("@ucenik_id", ucenik_id));
                cmd.Parameters.Add(new SqlParameter("@kurs_id", kurs_id));


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
