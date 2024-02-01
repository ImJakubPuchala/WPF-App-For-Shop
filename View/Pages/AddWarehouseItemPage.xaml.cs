﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages;

/// <summary>
/// Logika interakcji dla klasy AddWarehouseItemPage.xaml
/// </summary>
public partial class AddWarehouseItemPage : Page
{
    public AddWarehouseItemPage()
    {
        InitializeComponent();
        DataContext = new AddWarehouseItemViewModel();
    }
}