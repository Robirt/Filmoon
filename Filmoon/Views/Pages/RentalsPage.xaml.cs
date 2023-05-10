using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class RentalsPage : Page
{
    public RentalsPage(RentalsPageViewModel rentalsPageViewModel)
    {
        InitializeComponent();

        DataContext = rentalsPageViewModel;

        Loaded += RentalsPage_Loaded;
    }

    private async void RentalsPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as RentalsPageViewModel)!.GetRentals();
    }
}
