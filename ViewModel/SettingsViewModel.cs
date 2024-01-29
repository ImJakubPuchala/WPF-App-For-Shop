using System.ComponentModel;
using System.IO;

public class SettingsViewModel : INotifyPropertyChanged
{
    private const string PrinterIpConfigFilePath = "printer_ip_config.txt";
    private string printerIpAddress;

    public string PrinterIpAddress
    {
        get => printerIpAddress;
        set
        {
            if (printerIpAddress != value)
            {
                printerIpAddress = value;
                OnPropertyChanged(nameof(PrinterIpAddress));
                SavePrinterIpAddress();
            }
        }
    }

    public SettingsViewModel()
    {
        LoadPrinterIpAddress();
    }

    private void SavePrinterIpAddress()
    {
        File.WriteAllText(PrinterIpConfigFilePath, PrinterIpAddress);
    }

    private void LoadPrinterIpAddress()
    {
        if (File.Exists(PrinterIpConfigFilePath))
        {
            PrinterIpAddress = File.ReadAllText(PrinterIpConfigFilePath);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
