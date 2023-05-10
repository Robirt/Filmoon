using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class GenresPage : Page
{
    public GenresPage(GenresPageViewModel genresPageViewModel)
    {
        InitializeComponent();

        DataContext = genresPageViewModel;

        Loaded += GenresPage_Loaded;
    }

    private async void GenresPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as GenresPageViewModel)!.GetGenres();
    }
}
