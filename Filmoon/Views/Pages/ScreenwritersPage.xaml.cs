using Filmoon.ViewModels.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class ScreenwritersPage : Page
{
    public ScreenwritersPage(ScreenwritersPageViewModel screenwritersPageViewModel)
    {
        InitializeComponent();

        DataContext = screenwritersPageViewModel;

        Loaded += ScreenwritersPage_Loaded;
    }

    private async void ScreenwritersPage_Loaded(object sender, RoutedEventArgs e)
    {
        await (DataContext as ScreenwritersPageViewModel)!.GetScreenwriters();
    }
}
