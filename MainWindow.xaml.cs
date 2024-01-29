using System.Text;
using System.Windows;
using WPF_App_For_Shop.View;
using WPF_App_For_Shop.View.Pages;

namespace WPF_App_For_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_ViewItems_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ViewItemsPage());
        }

        private void MenuItem_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AddProductPage());
        }

        private void MenuItem_ChangePrice_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ChangePricePage());
        }
        private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new SettingsPage());
        }
    }
}