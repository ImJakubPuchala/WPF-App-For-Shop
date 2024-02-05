using System;
using System.Windows;

namespace WPF_App_For_Shop.View.Window;

public partial class ChangeWarehouseNumberWindow : System.Windows.Window
{
    public string NewWarehouseNumber => warehouseNumberTextBox.Text;

    public ChangeWarehouseNumberWindow()
    {
        InitializeComponent();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
        this.Close();
    }
}
