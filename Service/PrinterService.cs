using System.Net.Sockets;
using System.Text;
using System.Windows;
using WPF_App_For_Shop.Model;

public class PrinterService
{
    private readonly SettingsViewModel _settingsViewModel;

    public PrinterService(SettingsViewModel settingsViewModel)
    {
        _settingsViewModel = settingsViewModel;
    }

    public void PrintLabel(ProductInformation product)
    {
        string printerIp = _settingsViewModel.PrinterIpAddress;
        int printerPort = 9100;
        string zplData = GenerateZpl(product);

        SendDataToPrinter(printerIp, printerPort, zplData);
    }
    private string GenerateZpl(ProductInformation product)
    {
        return $"""

            ^XA
                ^FO50,100^A0N,50,50^FDProduct Name: {product.Name}^FS
                ^FO50,150^A0N,50,50^FDPrice: {product.Price}^FS
                ^FO50,200^A0N,50,50^FDEAN Code: {product.EAN}^FS
                ^FO50,300^B3N,N,50,Y,N^FD{product.EAN}^FS
            ^XZ

         """;
    }

    public void PrintWarehouseLabel(WarehouseProduct product)
    {
        string printerIp = _settingsViewModel.PrinterIpAddress;
        int printerPort = 9100;
        string zplData = GenerateWarehouseZpl(product);

        SendDataToPrinter(printerIp, printerPort, zplData);
    }
    
    private string GenerateWarehouseZpl(WarehouseProduct product)
    {
        return $"""
            ^XA
                ^FO50,50^A0N,50,50^FDProduct ID: {product.ProductId}^FS
                ^FO50,100^A0N,50,50^FDProduct Name: {product.ProductName}^FS
                ^FO50,150^A0N,50,50^FDEAN Code: {product.EANCode}^FS
                ^FO50,200^A0N,50,50^FDQuantity: {product.Quantity}^FS
                ^FO50,250^A0N,50,50^FDWarehouse Number: {product.WarehouseNumber}^FS
                ^FO50,300^A0N,50,50^FDPrinting time: ^FS
                ^FO320,300^A0N,50,35^FD{DateTime.Now}^FS
                ^FO50,350^B3N,N,50,Y,N^FD{product.EANCode}^FS
            ^XZ
        """;
    }

    private void SendDataToPrinter(string ip, int port, string zplData)
    {
        //Using a thread to be able to continue to operate on the application regardless of whether the printer works or not
        Thread thread = new Thread(() => {
            try
            {
                using (var client = new TcpClient(ip, port))
                using (var stream = client.GetStream())
                {
                    byte[] zplBytes = Encoding.UTF8.GetBytes(zplData);
                    stream.Write(zplBytes, 0, zplBytes.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd: " + ex.Message);
            }
        });

        thread.Start();
    }
}
