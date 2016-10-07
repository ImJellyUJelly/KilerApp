using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace KilerApp
{
    public class Database
    {
        //private const string connect = "Server=mssql.fhict.local;Database=dbi299244;User Id=dbi299244;Password=hah je wactwoord piemel";
        private const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KilerApp\FunDatabaseKillerApp.mdf;Integrated Security = True";
        public List<string> Search()
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "Select * from Band";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["Naam"]));
                    }
                }
            }
            return result;
        }

        public void Insert(string watjewilinvoeren, string watjenogmeerwilinvoeren)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "INSERT INTO jetabelnaam (Je kolomnamen, volgende kolomnaam, etc)" +
                    " VALUES(@Eerstekolomnaam, @tweedekolomnaam, @derdekolomnaam, @etc)";

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("Eerstekolomnaam", watjewilinvoeren);
                        cmd.Parameters.AddWithValue("Tweedekolomnaam", watjenogmeerwilinvoeren);
                    }
                    catch (Exception e)
                    {
                        System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                    }

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                        System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                    }
                }
            }
        }

        public void Delete(string watjewilverwijderen)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "DELETE FROM Tabel " +
                                "WHERE (Kolomnaam = @Kolomnaam)";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Kolomnaam", watjewilverwijderen);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (SqlException e)
                    {

                        System.Windows.Forms.MessageBox.Show(e.Message.ToString());
                    }
                }
            }

        }

        public void Update(string watjewilveranderen)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = "UPDATE Tabelnaam " +
                            "SET Kolomnaam='Wathetnumoetzijn' " +
                            "WHERE (Kolomnaam=@Kolomnaam)";

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("Kolomnaam", watjewilveranderen);
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            }
        }

    }
}
