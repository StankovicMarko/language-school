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
    public class PredajeDAO
    {


        public static void Read()
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from predaje";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "predaje");

                foreach (DataRow row in ds.Tables["predaje"].Rows)
                {


                    long nastavnik_id = (long)row["nastavnik_id"];
                    long kurs_Id = (long)row["kurs_id"];


                    Nastavnik foundNastavnik = null;
                    Kurs foundKurs = null;

                    
                    foreach (Nastavnik n in Aplikacija.Instanca.Nastavnici)
                    {
                        if (n.Id == nastavnik_id)
                        {
                            foundNastavnik = n;
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

                    
                    int indexOfNastavnika = Aplikacija.Instanca.Nastavnici.IndexOf(foundNastavnik);
                    Aplikacija.Instanca.Nastavnici[indexOfNastavnika].Kursevi.Add(foundKurs);

                   
                    int indexOfKursa = Aplikacija.Instanca.Kursevi.IndexOf(foundKurs);
                    Aplikacija.Instanca.Kursevi[indexOfKursa].Nastavnik = foundNastavnik;



                }

            }
        }


        public static void Create(long nastavnik_id, long kurs_id)
        {
            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "insert into predaje values(@nastavnik_id, @kurs_id)";
                cmd.Parameters.Add(new SqlParameter("@nastavnik_id", nastavnik_id));
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

        //public static void Update(long nastavnik_id, long kurs_id)
        //{
        //    using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
        //    {
        //        conn.Open();

        //        SqlCommand cmd = conn.CreateCommand();
        //        cmd.CommandText = "update predaje set nastavnik_id=@nastavnik_id, prezime=@prezime, jmbg=@jmbg, usn=@usn, psw=@psw, isAdmin=@isAdmin, obrisan=@obrisan where id=@id";
        //        cmd.Parameters.Add(new SqlParameter("@id", k.Id));
        //        cmd.Parameters.Add(new SqlParameter("@ime", k.Ime));
        //        cmd.Parameters.Add(new SqlParameter("@prezime", k.Prezime));
        //        cmd.Parameters.Add(new SqlParameter("@jmbg", k.Jmbg));
        //        cmd.Parameters.Add(new SqlParameter("@usn", k.Usn));
        //        cmd.Parameters.Add(new SqlParameter("@psw", k.Psw));
        //        cmd.Parameters.Add(new SqlParameter("@isAdmin", k.Admin));
        //        cmd.Parameters.Add(new SqlParameter("@obrisan", k.Obrisan));

        //        try
        //        {
        //            cmd.ExecuteNonQuery();
        //        }
        //        catch (SqlException e)
        //        {
        //            MessageBox.Show(e.Message, "greska", MessageBoxButton.OK);
        //        }
        //    }

        //}


        public static void Delete(long nastavnik_id, long kurs_id)
        {

            using (SqlConnection conn = new SqlConnection(Aplikacija.CONN_STR))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "delete from predaje where nastavnik_id=@nastavnik_id and kurs_id=@kurs_id";
                cmd.Parameters.Add(new SqlParameter("@nastavnik_id", nastavnik_id));
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

