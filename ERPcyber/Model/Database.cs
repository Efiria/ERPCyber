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

            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
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

            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
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
            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
            string query = "INSERT INTO users (username,email,password_web,role) VALUES ('"+username+"','"+email+"','"+password+"','"+role+"')";

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
            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
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
            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
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

        public DataTable getOrders()
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
            string query = "SELECT orders.numOrder, customer.Name, customer.LastName, customer.Address, customer.Country, orders.price FROM orders LEFT JOIN customer ON orders.idcustomer = customer.id";

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
                dataTable.Columns.Add("Num Order");
                dataTable.Columns.Add("Customer Firstname");
                dataTable.Columns.Add("Customer Lastname");
                dataTable.Columns.Add("Customer Address");
                dataTable.Columns.Add("Customer Country");
                dataTable.Columns.Add("Order Price");

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        DataRow row = dataTable.NewRow();
                        row["Num Order"] = reader.GetString(0);
                        row["Customer Firstname"] = reader.GetString(1);
                        row["Customer Lastname"] = reader.GetString(2);
                        row["Customer Address"] = reader.GetString(3);
                        row["Customer Country"] = reader.GetString(4);
                        row["Order Price"] = reader.GetString(5);
                        dataTable.Rows.Add(row);
                    }
                }
                else
                {
                    MessageBox.Show("There is no Orders, please update it.");
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

        public void addOrder(int userId, string numOrder, int price)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=brubru;password=hahamdp!123;database=test;";
            string query = "INSERT INTO orders (numOrder,idcustomer,price) VALUES ('" + numOrder + "','" + userId + "','" + price + "')";

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
