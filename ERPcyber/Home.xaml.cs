using ERPcyber.pages;
using System.Windows;
using System.Windows.Input;

namespace ERPcyber
{
    /// <summary>
    /// Logique d'interaction pour Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }

        private void stock_page(object sender, RoutedEventArgs e)
        {
            StockPage win = new StockPage();
            win.Show();
            this.Close();
        }

        private void customer_page(object sender, RoutedEventArgs e)
        {
            CustomerPage win = new CustomerPage();
            win.Show();
            this.Close();
        }

        private void shipping_page(object sender, RoutedEventArgs e)
        {
            OrderPage win = new OrderPage();
            win.Show();
            this.Close();
        }

        private void user_page(object sender, RoutedEventArgs e)
        {
            EmployeePage win = new EmployeePage();
            win.Show();
            this.Close();
        }

        private void logout_click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }  

    }
}
