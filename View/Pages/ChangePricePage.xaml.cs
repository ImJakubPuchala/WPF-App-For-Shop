using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages;

public partial class ChangePricePage : Page
{
    public ChangePricePage()
    {
        InitializeComponent();
        DataContext = new ChangePriceViewModel();
    }
}

