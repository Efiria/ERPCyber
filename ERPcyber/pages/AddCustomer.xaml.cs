using ERPcyber.Model;
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
    /// Logique d'interaction pour AddCustomer.xaml
    /// </summary>
    public partial class AddCustomer : Window
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void closepop_click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void addpop_click(object sender, RoutedEventArgs e)
        {
            //ADD NEW CUSTOMER
            string firtname = Firstname.Text;
            string lastname = Lastname.Text;
            string address = Address.Text;
            string country = Country.Text;

            if (firtname != null && lastname != null && address != null && country != null)
            {
                
                Database database = new Database();
                database.addCustomer(firtname, lastname, address, country);

                MessageBox.Show("Customer " + firtname + " "+ lastname + " added to the ERP");
                this.Close();
                
            }
            else
            {
                MessageBox.Show("You need to fill all the informations");
            }
        }
    }
}
