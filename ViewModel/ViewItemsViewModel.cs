using System.Collections.ObjectModel;
using System.Windows;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop.ViewModel;

public class ViewItemsViewModel
{
    public ObservableCollection<ProductInformation> Products { get; set; }
    private ApiService ProductApi = new ApiService();
    public PrinterService PrinterService { get; private set; }

    public ViewItemsViewModel(SettingsViewModel settingsViewModel)
    {
        Products = new ObservableCollection<ProductInformation>();
        LoadProducts();
        PrinterService = new PrinterService(settingsViewModel);
    }

    private async void LoadProducts()
    {
        var products = await ProductApi.GetAllProductsAsync();
        foreach (var product in products)
        {
            Products.Add(product);
        }
    }

    public void PrintLabel(ProductInformation selectedProduct)
    {
        if (selectedProduct != null)
        {
            PrinterService.PrintLabel(selectedProduct);
        }
        else
        {
            MessageBox.Show("Wybierz produkt z listy.");
        }
    }
}