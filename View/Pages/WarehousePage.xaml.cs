using System.Windows;
using System.Windows.Controls;
using WPF_App_For_Shop.Model;
using WPF_App_For_Shop.View.Window;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages
{
    public partial class WarehousePage : Page
    {
        private WarehouseViewModel _viewModel;

        public WarehousePage()
        {
            InitializeComponent();
            SettingsViewModel settingsViewModel = new SettingsViewModel();
            _viewModel = new WarehouseViewModel(settingsViewModel);
            this.DataContext = _viewModel;
        }

        private void PrintLabelButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is WarehouseProduct selectedProduct)
            {
                _viewModel.PrintLabel(selectedProduct);
            }
            else
            {
                MessageBox.Show("Wybierz produkt z listy.");
            }
        }

        private void ChangeLocationButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem is WarehouseProduct selectedProduct)
            {
                var changeWindow = new ChangeWarehouseNumberWindow();
                if (changeWindow.ShowDialog() == true)
                {
                    var newWarehouseNumber = changeWindow.NewWarehouseNumber;
                    _viewModel.UpdateWarehouseNumber(selectedProduct, newWarehouseNumber);
                }
            }
            else
            {
                MessageBox.Show("Wybierz produkt z listy.");
            }
        }
    }
}
