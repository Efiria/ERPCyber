using ERPcyber.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ERPcyber.pages
{
    /// <summary>
    /// Logique d'interaction pour AddOrder.xaml
    /// </summary>
    public partial class AddOrder : Window
    {
        public AddOrder()
        {
            InitializeComponent();

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

                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user_choose.Items.Add(reader.GetString(0) + " _ " +reader.GetString(1) +" " + reader.GetString(2));
                    }
                }
                else
                {
                    MessageBox.Show("There is no Customers, please update it.");
                }

                // Finally close the connection
                databaseConnection.Close();

            }
            catch (Exception ex)
            {
                // Show any error message.
                MessageBox.Show(ex.Message);
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void closepop_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addpop_click(object sender, RoutedEventArgs e)
        {
            //ADD NEW USER
            string ordernum = OrderNumber.Text;
            string orderprice = Price.Text;

            string typeItem = (string)user_choose.SelectedItem;
            if (typeItem != null && ordernum != null && orderprice != null)
            {
                string[] subs = typeItem.Split('_');
                int userId = Int32.Parse(subs[0]);

                Database db = new Database();
                db.addOrder(userId,ordernum, Int32.Parse(orderprice));

                this.Close();
            } 
            else
            {
                MessageBox.Show("You need to fill the form with valid information");
            }
        }
    }
}
