using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy ChangePricePage.xaml
    /// </summary>
    public partial class ChangePricePage : Page
    {
        private ChangePriceViewModel _viewModel;

        public ChangePricePage()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            CultureInfo.CurrentUICulture = CultureInfo.InvariantCulture;

            _viewModel = new ChangePriceViewModel();
            this.DataContext = _viewModel;
        }

        private void ChangePriceButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(NewPriceTextBox.Text, NumberStyles.Any, CultureInfo.CurrentCulture, out double newPrice))
            {
                _viewModel.ProductNewPrice.NewPrice = newPrice;
                _viewModel.ChangePriceCommand.Execute(null);
            }
            else
            {
                MessageBox.Show("Please enter a valid price");
            }
        }
    }
}
