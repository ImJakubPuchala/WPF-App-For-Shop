using System;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using WPF_App_For_Shop.Model;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages;

public partial class ViewItemsPage : Page
{
    private ViewItemsViewModel _viewModel;

    public ViewItemsPage()
    {
        InitializeComponent();
        SettingsViewModel settingsViewModel = new SettingsViewModel();
        _viewModel = new ViewItemsViewModel(settingsViewModel);
        this.DataContext = _viewModel;
    }

    private void PrintLabelButton_Click(object sender, RoutedEventArgs e)
    {
        if (dataGrid.SelectedItem is ProductInformation selectedProduct)
        {
            _viewModel.PrintLabel(selectedProduct);
        }
        else
        {
            MessageBox.Show("Wybierz produkt z listy.");
        }
    }
    //private ViewItemsViewModel _viewModel;

    //public ViewItemsPage()
    //{
    //    InitializeComponent();

    //    _viewModel = new ViewItemsViewModel();
    //    this.DataContext = _viewModel;
    //}

    //private void PrintLabelButton_Click(object sender, RoutedEventArgs e)
    //{
    //    if (dataGrid.SelectedItem is ProductInformation selectedProduct)
    //    {
    //        string zplData = GenerateZpl(selectedProduct);
    //        SendDataToPrinter("192.168.1.26", 9100, zplData);
    //    }
    //    else
    //    {
    //        MessageBox.Show("Wybierz produkt z listy.");
    //    }
    //}

    //private string GenerateZpl(ProductInformation product)
    //{
    //    return $"""
    //        ^XA

    //             ^FO20,50^ADN,36,20^FD{product.Name}^FS
    //             ^BY2,1,60
    //             ^FO20,100^BC^FD{product.EAN}^FS

    //             ^XZ
    //         """;
    //}

    //private void SendDataToPrinter(string ip, int port, string zplData)
    //{
    //    try
    //    {
    //        using (var client = new TcpClient(ip, port))
    //        using (var stream = client.GetStream())
    //        {
    //            byte[] zplBytes = Encoding.UTF8.GetBytes(zplData);
    //            stream.Write(zplBytes, 0, zplBytes.Length);
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show("Błąd: " + ex.Message);
    //    }
    //}
}
