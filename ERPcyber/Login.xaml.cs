using ERPcyber.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ERPcyber
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_close(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        Home home = new Home();
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxEmail.Text.Length == 0)
            {
                errormessage.Text = "Enter an email.";
                textBoxEmail.Focus();
            }
            else if (!Regex.IsMatch(textBoxEmail.Text, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"))
            {
                errormessage.Text = "Enter a valid email.";
                textBoxEmail.Select(0, textBoxEmail.Text.Length);
                textBoxEmail.Focus();
            }
            else
            {
                string email = textBoxEmail.Text;
                string password = passwordBox1.Password;


                string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=test;";
                string query = "Select * from users where Email = '" + email + "'";

                string hash = Encrypt.truc(password).ToLower();
                Console.WriteLine(hash);

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
                            string dbpassword = reader.GetString(5);
                            if (dbpassword == hash)
                            {
                                home.Show();
                                Close();
                            }
                            else
                            {
                                errormessage.Text = "No user with this email/password.";
                            }
                        }
                        
                    }
                    else
                    {
                        errormessage.Text = "No user with this email/password.";
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
        }
    }
}
