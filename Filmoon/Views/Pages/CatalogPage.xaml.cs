using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class CatalogPage : Page
{
    public CatalogPage(CatalogPageViewModel catalogPageViewModel)
    {
        InitializeComponent();

        DataContext = catalogPageViewModel;

        Loaded += CatalogPage_Loaded;
    }

    private async void CatalogPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as CatalogPageViewModel)!.GetMovies();
    }
}
