using Filmoon.ViewModels.Pages;
using System.Windows.Controls;

namespace Filmoon.Views.Pages
{
    public partial class SignUpPage : Page
    {
        public SignUpPage(SignUpPageViewModel signUpPageViewModel)
        {
            InitializeComponent();

            DataContext = signUpPageViewModel;
        }
    }
}
