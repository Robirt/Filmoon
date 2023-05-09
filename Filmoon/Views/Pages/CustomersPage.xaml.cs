using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class CustomersPage : Page
{
    public CustomersPage(CustomersPageViewModel directorsPageViewModel)
    {
        InitializeComponent();

        DataContext = directorsPageViewModel;

        Loaded += CustomersPage_Loaded;
    }

    private async void CustomersPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as CustomersPageViewModel)!.GetCustomers();
    }
}
