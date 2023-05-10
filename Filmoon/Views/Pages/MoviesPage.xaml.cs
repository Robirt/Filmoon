using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class MoviesPage : Page
{
    public MoviesPage(MoviesPageViewModel moviesPageViewModel)
    {
        InitializeComponent();

        DataContext = moviesPageViewModel;

        Loaded += MoviesPage_Loaded;
    }

    private async void MoviesPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as MoviesPageViewModel)!.GetMovies();
        await (DataContext as MoviesPageViewModel)!.GetGenres();
        await (DataContext as MoviesPageViewModel)!.GetScreenwriters();
        await (DataContext as MoviesPageViewModel)!.GetDirectors();
    }
}
