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
    class SkolaDAO
    {
        public static Skola Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from skola";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "skola");


                DataRow row = ds.Tables["skola"].Rows[0];

                Skola skola = new Skola();
                skola.Id = (long)row["id"];
                skola.Naziv = (string)row["naziv"];
                skola.Adresa = (string)row["adresa"];
                skola.Telefon = (string)row["telefon"];
                skola.Email = (string)row["email"];
                skola.Website = (string)row["website"];
                skola.Pib = (string)row["pib"];
                skola.MaticniBroj = (string)row["maticniBroj"];
                skola.ZiroRacun = (string)row["ziroRacun"];

                return skola;

            }
        }



        public static void Update(Skola s)
        {

            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "update skola set naziv=@naziv, adresa=@adresa, telefon=@telefon, email=@email, website=@website, pib=@pib, maticniBroj=@maticniBroj, ziroRacun=@ziroRacun where id=@id";
                cmd.Parameters.Add(new SqlParameter("@id", s.Id));
                cmd.Parameters.Add(new SqlParameter("@naziv", s.Naziv));
                cmd.Parameters.Add(new SqlParameter("@adresa", s.Adresa));
                cmd.Parameters.Add(new SqlParameter("@telefon", s.Telefon));
                cmd.Parameters.Add(new SqlParameter("@email", s.Email));
                cmd.Parameters.Add(new SqlParameter("@website", s.Website));
                cmd.Parameters.Add(new SqlParameter("@pib", s.Pib));
                cmd.Parameters.Add(new SqlParameter("@maticniBroj", s.MaticniBroj));
                cmd.Parameters.Add(new SqlParameter("@ziroRacun", s.ZiroRacun));


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
