using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop.ViewModel;

public class WarehouseViewModel
{
    public ObservableCollection<WarehouseProduct> Products { get; set; }
    private ApiService ProductApi = new ApiService();
    public PrinterService PrinterService { get; private set; }

    public WarehouseViewModel(SettingsViewModel settingsViewModel)
    {
        Products = new ObservableCollection<WarehouseProduct>();
        LoadProducts();
        PrinterService = new PrinterService(settingsViewModel);
    }

    private async void LoadProducts()
    {
        var products = await ProductApi.GetAllWarehouseProductsAsync();
        foreach (var product in products)
        {
            Products.Add(product);
        }
    }
    public void PrintLabel(WarehouseProduct selectedProduct)
    {
        if (selectedProduct != null)
        {
            PrinterService.PrintWarehouseLabel(selectedProduct);
        }
        else
        {
            MessageBox.Show("Wybierz produkt z listy.");
        }
    }
}
