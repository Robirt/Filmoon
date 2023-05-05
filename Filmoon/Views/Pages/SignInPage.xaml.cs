using Filmoon.ViewModels.Pages;
using System.Windows.Controls;

namespace Filmoon.Views.Pages;

public partial class SignInPage : Page
{
    public SignInPage(SignInPageViewModel signInPageViewModel)
    {
        DataContext = signInPageViewModel;

        InitializeComponent();
    }
}
