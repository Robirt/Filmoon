using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class DirectorsPage : Page
{
    public DirectorsPage(DirectorsPageViewModel directorsPageViewModel)
    {
        InitializeComponent();

        DataContext = directorsPageViewModel;

        Loaded += DirectorsPage_Loaded;
    }

    private async void DirectorsPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as DirectorsPageViewModel)!.GetDirectors();
    }
}
