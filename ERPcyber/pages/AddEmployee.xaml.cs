using ERPcyber.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ERPcyber.pages
{
    /// <summary>
    /// Logique d'interaction pour AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee()
        {
            InitializeComponent();
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
            string username = UserName.Text;
            string email = UserEmail.Text;
            string password1 = Password.Password;
            string password2 = Password2.Password;
            string value = null;

            ComboBoxItem typeItem = (ComboBoxItem)user_role.SelectedItem;
            if (typeItem != null)
            {
                 value = typeItem.Content.ToString();

            }

            if(password1 == password2)
            {
                if(username != null && Regex.IsMatch(email, @"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$") && value != null)
                {
                    Database database = new Database();
                    string key = Encrypt.getKey();
                    string encryptedpass = Encrypt.EncryptText(password1, key);
                    database.addEmployee(username, email, encryptedpass, value);

                    MessageBox.Show("User "+username+" added to the ERP");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("You need to fill the form with valid information");
                }
                
            }
            else
            {
                MessageBox.Show("Password doesn't match");
            }
            
        }
    }
}
