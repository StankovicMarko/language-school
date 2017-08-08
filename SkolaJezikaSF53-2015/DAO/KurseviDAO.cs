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
    class KurseviDAO
    {
        public static Kurs Create(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
              

                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into kursevi values ( @obrisan, @jezik, @tip, @cena, @nastavnik_id);SELECT SCOPE_IDENTITY();";
                cmd.Parameters.Add("@jezik", k.Jezik);
                cmd.Parameters.Add("@tip", k.Tip);
                cmd.Parameters.Add("@cena", k.Cena);
                cmd.Parameters.Add("@nastavnik_id", k.Nastavnik.Id);
                cmd.Parameters.Add("@obrisan", k.Obrisan);

                try
                {
                    long id = long.Parse(cmd.ExecuteScalar().ToString());
                    k.Id = id;
                }
                catch (SqlException e)
                {

                    MessageBox.Show(e.Message, "greska", MessageBoxButton.OK);
                }

                return k;
            }

        }

        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from  kursevi where obrisan = 0";
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlda.Fill(ds, "kursevi");
                foreach (DataRow row in ds.Tables["kursevi"].Rows)
                {
                    Kurs k = new Kurs();
                    k.Id = (long)row["id"];
                    k.Jezik = (string)row["jezik"];
                    k.Tip = (string)row["tip"];
                    k.Cena = (float)row["cena"];
                    k.Obrisan = (bool)row["obrisan"];
                    long nastavnik_id = (long)row["nastavnik_id"];

                    bool obrisan_nas = true;
                    foreach (Nastavnik n in Aplikacija.Instanca.Nastavnici)
                    {
                        

                        if (nastavnik_id == n.Id)
                        {
                            k.Nastavnik = n;
                            obrisan_nas = false;
                            //nn.Kursevi.Add(k);
                        }
                        
                    }
                    if (obrisan_nas)
                    {
                        k.Nastavnik = new Nastavnik();
                    }
                    Aplikacija.Instanca.Kursevi.Add(k);
                }
            }

        }

        public static void Update(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update kursevi set jezik=@jezik, tip=@tip, cena=@cena, nastavnik_id=@nastavnik_id, obrisan=@obrisan where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", k.Id));
                cmd.Parameters.Add(new SqlParameter("@jezik", k.Jezik));
                cmd.Parameters.Add(new SqlParameter("@tip", k.Tip));
                cmd.Parameters.Add(new SqlParameter("@cena", k.Cena));
                cmd.Parameters.Add(new SqlParameter("@nastavnik_id", k.Nastavnik.Id));
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

        public static void Delete(Kurs k)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                Aplikacija.Instanca.Kursevi.Remove(k);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update kursevi set obrisan=@obrisan where id=@id";
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
