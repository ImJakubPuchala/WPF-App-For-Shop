using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop.ViewModel;

public class AddProductViewModel : INotifyPropertyChanged
{
    private ApiService _apiService;
    private string _name;
    private double _price;
    private string _ean;
    public ICommand AddProductCommand { get; }
    public event PropertyChangedEventHandler PropertyChanged;

    public string EAN
    {
        get => _ean;
        set
        {
            _ean = value;
            OnPropertyChanged(nameof(EAN));
        }
    }
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

    

    public AddProductViewModel()
    {
        _apiService = new ApiService();
        AddProductCommand = new RelayCommand(AddProduct);

        SerialPortModel.Instance.DataReceived += OnDataReceived;
    }

    private void OnDataReceived(string data)
    {
        EAN = data;
    }

    private async void AddProduct()
    { 
        try
        {
            var product = new ProductInformation
            {
                Name = this.Name,
                Price = this.Price,
                EAN = this.EAN
            };
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

    ~AddProductViewModel()
    {
        SerialPortModel.Instance.DataReceived -= OnDataReceived;
    }
}