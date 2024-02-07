using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Service;

namespace WPF_App_For_Shop.ViewModel;

public class ProductStatisticsViewModel : INotifyPropertyChanged
{ 
    private ApiService _apiService;
    private string _ean;
    private string _productName;
    private int _totalSales;
    private double _averageRating;
    public ICommand FindProductCommand { get; }
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

    public string ProductName
    {
        get => _productName;
        set
        {
            if (_productName != value)
            {
                _productName = value;
                OnPropertyChanged(nameof(TotalSales));
            }
        }
    }

    public int TotalSales
    {
        get => _totalSales;
        set
        {
            if (_totalSales != value)
            {
                _totalSales = value;
                OnPropertyChanged(nameof(TotalSales));
            }
        }
    }

    public double AverageRating
    {
        get => _averageRating;
        set
        {
            if(_averageRating != value)
            {
                _averageRating = value;
                OnPropertyChanged(nameof(AverageRating));
            }  
        }
    }

    public ProductStatisticsViewModel()
    {
        _apiService = new ApiService();
        FindProductCommand = new RelayCommand(FindProduct);

        SerialPortService.Instance.DataReceived += OnDataReceived;
    }

    private void OnDataReceived(string data)
    {
        EAN = data;
    }

    public async void FindProduct()
    {
        try
        {
            var product = await _apiService.GetProductStatisticsByEANAsync(EAN);
            ProductName = product.Name;
            TotalSales = product.TotalSales;
            AverageRating = product.AverageRating;
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
