using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class HomePage : Page
{
    public HomePage(HomePageViewModel homePageViewModel)
    {
        InitializeComponent();

        DataContext = homePageViewModel;

        Loaded += HomePage_Loaded;
    }

    private async void HomePage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as HomePageViewModel)!.GetMovies();
    }
}
