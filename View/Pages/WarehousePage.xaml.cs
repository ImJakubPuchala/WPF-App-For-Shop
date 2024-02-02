using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF_App_For_Shop.Model;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages;

/// <summary>
/// Logika interakcji dla klasy WarehousePage.xaml
/// </summary>
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
}
