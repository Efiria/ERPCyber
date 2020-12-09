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
    /// Logique d'interaction pour UsersPage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
        public EmployeePage()
        {
            InitializeComponent();

            display_User();
        }

        private void display_User()
        {
            Database database = new Database();

            DataTable employee = database.getEmployee();
            dataGrid1.ItemsSource = employee.DefaultView;
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

        private void adduser_click(object sender, RoutedEventArgs e)
        {
            AddEmployee win = new AddEmployee();
            win.Show();
        }

        private void refresh_click(object sender, RoutedEventArgs e)
        {
            display_User();
        }
        

    }
}
