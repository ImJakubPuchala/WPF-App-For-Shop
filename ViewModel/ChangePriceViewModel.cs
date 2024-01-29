using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop.ViewModel;

public class ChangePriceViewModel
{
    private readonly ApiService _apiService;
    public ICommand ChangePriceCommand { get; }

    public ChangePriceViewModel()
    {
        _apiService = new ApiService();
        ChangePriceCommand = new RelayCommand(ChangePrice);
    }

    public ProductNewPrice ProductNewPrice { get; set; } = new ProductNewPrice();


    private async void ChangePrice()
    {
        try
        {
            await _apiService.ChangeProductPriceAsync(ProductNewPrice);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }
}
