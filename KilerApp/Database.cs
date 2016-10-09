using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KilerApp
{
    public class Database
    {
        //private const string connect = "Server=mssql.fhict.local;Database=dbi299244;User Id=dbi299244;Password=Schrader01";
        private const string connect = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\KilerApp\FunDatabaseKillerApp.mdf;Integrated Security = True";
        public List<string> Search(string table, string B)
        {
            List<string> result = new List<string>();
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = $"Select * from { table }";
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader[B]));
                    }
                }
            }
            return result;
        }

        public void Insert(string value1, string value2, string value3, string value4, string value5)
        {
            using (SqlConnection conn = new SqlConnection(connect))
            {
                string query = $"INSERT INTO Adres (ID, Straatnaam, Huisnummer, Postcode, Stad)" + 
                               $" VALUES (@{value1}, @{value2}, @{value3}, @{value4}, @{value5})";

                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("ID", Convert.ToInt32(value1));
                        cmd.Parameters.AddWithValue("Straatnaam", value2);
                        cmd.Parameters.AddWithValue("Huisnummer", Convert.ToInt32(value3));
                        cmd.Parameters.AddWithValue("Postcode", value4);
                        cmd.Parameters.AddWithValue("Stad", value5);
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
