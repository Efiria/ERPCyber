using ERPcyber.Model;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Logique d'interaction pour CustomerPage.xaml
    /// </summary>
    public partial class CustomerPage : Window
    {
        public CustomerPage()
        {
            InitializeComponent();

            Database database = new Database();

            DataTable customers = database.getCustomer();
            dataGrid1.ItemsSource = customers.DefaultView;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }


        private void home_click(object sender, RoutedEventArgs e)
        {
            Home window = new Home();
            window.Show();
            this.Close();
        }
    }
}
