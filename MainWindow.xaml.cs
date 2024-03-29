﻿using System.Text;
using System.Windows;
using WPF_App_For_Shop.Service;
using WPF_App_For_Shop.View;
using WPF_App_For_Shop.View.Pages;

namespace WPF_App_For_Shop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string serialPort = new SettingsViewModel().SelectedPort;
            if (serialPort != null)
            {
                var serialPortModel = SerialPortService.Instance;
                serialPortModel.InitializeSerialPort(serialPort);
                serialPortModel.Open();
            }
            else
            {
                MessageBox.Show("Please select port in settings, then restart the application!");
            }

        }

        private void MenuItem_ViewItems_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ViewItemsPage());
        }

        private void MenuItem_AddProduct_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AddProductPage());
        }

        private void MenuItem_ChangePrice_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ChangePricePage());
        }
        private void MenuItem_Settings_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new SettingsPage());
        }
        private void MenuItem_AddWarehouseItem_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new AddWarehouseItemPage());
        }
        private void MenuItem_Warehouse_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new WarehousePage());
        }
        private void MenuItem_ProductStatistics_Click(object sender, RoutedEventArgs e)
        {
            MainContentFrame.Navigate(new ProductStatisticsPage());
        }
    }
}