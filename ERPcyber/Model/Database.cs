using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ERPcyber.Model
{
    class Database
    {
        public DataTable getStock ()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
            string query = "Select * from stocks";

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

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Price");
                dataTable.Columns.Add("Quantity");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Id"] = reader.GetString(0);
                        row["Name"] = reader.GetString(1);
                        row["Price"] = reader.GetString(2);
                        row["Quantity"] = reader.GetString(3);
                        dataTable.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("There is no Stock, please update it.");
                }

                // Finally close the connection
                databaseConnection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }



            return null;
        }

        public DataTable getEmployee()
        {

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
            string query = "Select * from users";

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

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id");
                dataTable.Columns.Add("Name");
                dataTable.Columns.Add("Email");
                dataTable.Columns.Add("Role");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Id"] = reader.GetString(0);
                        row["Name"] = reader.GetString(1);
                        row["Email"] = reader.GetString(2);
                        row["Role"] = reader.GetString(4);
                        dataTable.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("There is no Stock, please update it.");
                }

                // Finally close the connection
                databaseConnection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }


            return null;
        }

        public void addEmployee(string username, string email, string password, string role)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
            string query = "INSERT INTO users (username,email,password,role) VALUES ('"+username+"','"+email+"','"+password+"','"+role+"')";

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


                // Finally close the connection
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }

        public DataTable getCustomer()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
            string query = "Select * from customer";

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

                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("Id");
                dataTable.Columns.Add("Firstname");
                dataTable.Columns.Add("Lastname");
                dataTable.Columns.Add("Address");
                dataTable.Columns.Add("Country");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Id"] = reader.GetString(0);
                        row["Firstname"] = reader.GetString(1);
                        row["Lastname"] = reader.GetString(2);
                        row["Address"] = reader.GetString(3);
                        row["Country"] = reader.GetString(4);
                        dataTable.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("There is no Customers, please update it.");
                }

                // Finally close the connection
                databaseConnection.Close();

                return dataTable;
            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }


            return null;
        }

        public void addCustomer(string firstname, string lastname, string address, string country)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
            string query = "INSERT INTO customer (Name,LastName,Address,Country) VALUES ('" + firstname + "','" + lastname + "','" + address + "','" + country + "')";

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


                // Finally close the connection
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }
        }
        
    }
}
