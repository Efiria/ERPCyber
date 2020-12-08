using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ERPcyber.Model
{
    class Database
    {
        public List<String> getStock ()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
            string query = "Select * from stocks";
            List<String> row = new List<string>();

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                // Open the database
                databaseConnection.Open();

                // Execute the query
                reader = commandDatabase.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        row.Add(reader.GetString(0));
                        row.Add(reader.GetString(1));
                        row.Add(reader.GetString(2));
                        row.Add(reader.GetString(3));
                        Console.WriteLine(reader.GetString(0));
                        Console.WriteLine(row.ToArray());
                    }
                }
                else
                {
                    MessageBox.Show("There is no Stock, please update it.");
                }

                // Finally close the connection
                databaseConnection.Close();

                return row;
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }



            return null;
        }
    }
}
