using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Model;
using WPF_App_For_Shop.Service;

namespace WPF_App_For_Shop.ViewModel;

public class ChangePriceViewModel : INotifyPropertyChanged
{
    private readonly ApiService _apiService;
    private string _ean;
    private double _newPrice;
    public ICommand ChangePriceCommand { get; }
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

    public double NewPrice
    {
        get => _newPrice;
        set
        {
            _newPrice = value;
            OnPropertyChanged(nameof(NewPrice));
        }
    }

    public ChangePriceViewModel()
    {
        _apiService = new ApiService();
        ChangePriceCommand = new RelayCommand(ChangePrice);

        SerialPortService.Instance.DataReceived += OnDataReceived;
    }

    private void OnDataReceived(string data)
    {
        EAN = data;
    }

    private async void ChangePrice()
    {
        try
        {
            var productNewPrice = new ProductNewPrice
            {
                EAN = this.EAN,
                NewPrice = this.NewPrice
            };
            await _apiService.ChangeProductPriceAsync(productNewPrice);
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

    ~ChangePriceViewModel()
    {
        SerialPortService.Instance.DataReceived -= OnDataReceived;
    }
}