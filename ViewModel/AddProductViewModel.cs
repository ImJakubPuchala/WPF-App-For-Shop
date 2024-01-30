using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop.ViewModel;

public class AddProductViewModel : INotifyPropertyChanged
{
    private string _name;
    private double _price;
    private string _ean;
    private ApiService _apiService;
    public ICommand AddProductCommand { get; }
    public event PropertyChangedEventHandler PropertyChanged;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged(nameof(Name));
        }
    }

    public double Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged(nameof(Price));
        }
    }

    public string EAN
    {
        get => _ean;
        set
        {
            _ean = value;
            OnPropertyChanged(nameof(EAN));
        }
    }

    public AddProductViewModel()
    {
        _apiService = new ApiService();
        AddProductCommand = new RelayCommand(AddProduct);
    }

    private async void AddProduct()
    {
        var product = new ProductInformation
        {
            Name = this.Name,
            Price = this.Price,
            EAN = this.EAN
        };

        try
        {
            await _apiService.AddProductAsync(product);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}