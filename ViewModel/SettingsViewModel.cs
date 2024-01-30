using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Model;

public class SettingsViewModel : INotifyPropertyChanged
{
    private const string PrinterIpConfigFilePath = "printer_ip_config.txt";
    private const string ScannerConfigFilePath = "scanner_config.txt";
    private string printerIpAddress;
    private string[] availablePorts;
    private string selectedPort;
    public ICommand SaveSettingsCommand { get; }

    public string PrinterIpAddress
    {
        get => printerIpAddress;
        set
        {
            if (printerIpAddress != value)
            {
                printerIpAddress = value;
                OnPropertyChanged(nameof(PrinterIpAddress));
            }
        }
    }
    public string SelectedPort
    {
        get => selectedPort;
        set
        {
            if (selectedPort != value)
            {
                selectedPort = value;
                OnPropertyChanged(nameof(SelectedPort));
            }
        }
    }

    public string[] AvailablePorts
    {
        get
        {
            if (availablePorts == null)
            {
                availablePorts = SerialPortModel.Instance.GetAllSerialPorts();
            }
            return availablePorts;
        }
    }

    

    public SettingsViewModel()
    {
        LoadSettings();
        SaveSettingsCommand = new RelayCommand(SaveSettings);
    }


    private void SaveSettings()
    {
        File.WriteAllText(PrinterIpConfigFilePath, PrinterIpAddress);
        File.WriteAllText(ScannerConfigFilePath, SelectedPort);
        MessageBox.Show("Settings saved!");
    }

    private void LoadSettings()
    {
        if (File.Exists(PrinterIpConfigFilePath))
        {
            PrinterIpAddress = File.ReadAllText(PrinterIpConfigFilePath);
        }
        if (File.Exists(ScannerConfigFilePath))
        {
            SelectedPort = File.ReadAllText(ScannerConfigFilePath);
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
