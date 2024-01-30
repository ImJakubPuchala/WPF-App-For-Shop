using System.Windows.Controls;
using WPF_App_For_Shop.Model;
using WPF_App_For_Shop.ViewModel;

namespace WPF_App_For_Shop.View.Pages;

public partial class AddProductPage : Page
{
    public AddProductPage()
    {
        InitializeComponent();
        DataContext = new AddProductViewModel();
    }
}
