﻿using System.Net.Sockets;
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

             ^FO20,50^ADN,36,20^FD{product.Name}^FS
             ^BY2,1,60
             ^FO20,100^BC^FD{product.EAN}^FS

             ^XZ
         """;
    }

    private void SendDataToPrinter(string ip, int port, string zplData)
    {
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
    }
}
