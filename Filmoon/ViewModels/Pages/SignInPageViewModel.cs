using Filmoon.Commands;
using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages
{
    public class SignInPageViewModel: ViewModelBase
    {
        public SignInPageViewModel(UsersService usersService) 
        {
            UsersService = usersService;

            SignInRequest = new UserSignInRequest();

            SignInCommand = new SignInCommand(SignInAsync);
        }
        private UsersService UsersService { get; }

        private UserSignInRequest signInRequest;

        public UserSignInRequest SignInRequest
        { 
            get { return signInRequest; }
            set{ SetProperty(ref signInRequest, value); }
        }

        public ICommand SignInCommand { get; set; }

        private async void SignInAsync(object? parameter)
        {
            await UsersService.SignInAsync(parameter as UserSignInRequest);
        }
    }
}
