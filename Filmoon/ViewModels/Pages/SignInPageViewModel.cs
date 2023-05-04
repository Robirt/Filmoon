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

            SignInRequest = new SignInRequest();

            SignInCommand = new SignInCommand(SignInAsync);
        }
        private UsersService UsersService { get; }

        private SignInRequest signInRequest;

        public SignInRequest SignInRequest
        { 
            get { return signInRequest; }
            set{ SetProperty(ref signInRequest, value); }
        }

        public ICommand SignInCommand { get; set; }

        private async void SignInAsync(object? parameter)
        {
            await UsersService.SignInAsync(parameter as SignInRequest);
        }
    }
}
