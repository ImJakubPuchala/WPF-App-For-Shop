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
        Products.Clear();
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

    public async void UpdateWarehouseNumber(WarehouseProduct product, string newWarehouseNumber)
    {
        product.WarehouseNumber = newWarehouseNumber;
        if(await ProductApi.UpdateWarehouseNumberAsync(product.WarehouseItemId, newWarehouseNumber))
        {
            MessageBox.Show("Zaktualizowano numer magazynu.");
        }
        else
        {
            MessageBox.Show("Wystąpił błąd podczas aktualizacji numeru magazynu.");
        }
        LoadProducts();
    }

}
