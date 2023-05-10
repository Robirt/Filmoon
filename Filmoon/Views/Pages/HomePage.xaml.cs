using Filmoon.ViewModels.Pages;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class HomePage : Page
{
    public HomePage(HomePageViewModel homePageViewModel)
    {
        DataContext = homePageViewModel;

        InitializeComponent();
    }
}
