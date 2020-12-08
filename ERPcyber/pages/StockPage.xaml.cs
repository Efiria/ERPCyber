using ERPcyber.Model;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace ERPcyber.pages
{
    /// <summary>
    /// Logique d'interaction pour HomePage.xaml
    /// </summary>
    public partial class StockPage : Window
    {
        public StockPage()
        {
            InitializeComponent();

            Database database = new Database();

            DataTable stock = database.getStock();
            dataGrid1.ItemsSource = stock.DefaultView;

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
