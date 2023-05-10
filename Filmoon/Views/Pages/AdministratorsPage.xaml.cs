using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class AdministratorsPage : Page
{
    public AdministratorsPage(AdministratorsPageViewModel administratorsPageViewModel)
    {
        InitializeComponent();

        DataContext = administratorsPageViewModel;

        Loaded += AdministratorsPage_Loaded;
    }

    private async void AdministratorsPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as AdministratorsPageViewModel)!.GetAdministrators();
    }
}
