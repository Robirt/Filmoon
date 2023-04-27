using Filmoon.Commands;
using Filmoon.Requests;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages
{
    public class SignUpPageViewModel: ViewModelBase
    {
        public SignUpPageViewModel(UsersService usersService)
        {
            UsersService = usersService;

            SignUpRequest = new UserSignUpRequest();

            SignUpCommand = new SignUpCommand(SignUpAsync);
        }
        private UsersService UsersService { get; }

        private UserSignUpRequest signUpRequest;

        public UserSignUpRequest SignUpRequest
        {
            get { return signUpRequest; }
            set { SetProperty(ref signUpRequest, value); }
        }

        public ICommand SignUpCommand { get; set; }

        private async void SignUpAsync(object? parameter)
        {
            await UsersService.SignUpAsync(parameter as UserSignUpRequest);
        }
    }
}
