﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_App_For_Shop.Commands;
using WPF_App_For_Shop.Model;

namespace WPF_App_For_Shop.ViewModel;

public class AddWarehouseItemViewModel : INotifyPropertyChanged
{
    private ApiService _apiService;
    private string _ean;
    private int _quantity;
    private string _warehouseName;
    public ICommand AddProductCommand { get; }
    public event PropertyChangedEventHandler PropertyChanged;

    public string EAN
    {
        get => _ean;
        set
        {
            if (_ean != value)
            {
                _ean = value;
                OnPropertyChanged(nameof(EAN));
            }
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (_quantity != value)
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }
    }

    public string WarehouseName
    {
        get => _warehouseName;
        set
        {
            if (_warehouseName != value)
            {
                _warehouseName = value;
                OnPropertyChanged(nameof(WarehouseName));
            }
        }
    }

    public AddWarehouseItemViewModel()
    {
        _apiService = new ApiService();
        AddProductCommand = new RelayCommand(AddProductToWh);

        SerialPortModel.Instance.DataReceived += OnDataReceived;
    }

    private void OnDataReceived(string data)
    {
        EAN = data;
    }

    private async void AddProductToWh()
    {
        try
        {
            //ToDo: Add product to warehouse
            throw new NotImplementedException();
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

    ~AddWarehouseItemViewModel()
    {
        SerialPortModel.Instance.DataReceived -= OnDataReceived;
    }
}