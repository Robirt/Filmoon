using Filmoon.Commands.Directors;
using Filmoon.Entities;
using Filmoon.Requests;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class AdministratorsPageViewModel : ViewModelBase
{
    public AdministratorsPageViewModel(AdministratorsService administratorsService)
    {
        AdministratorsService = administratorsService;

        AddAdministratorCommand = new AddAdministratorCommand(AddAdministratorAsync);
    }

    private AdministratorsService AdministratorsService { get; }

    private List<AdministratorEntity>? administrators = new();
    public List<AdministratorEntity>? Administrators
    {
        get { return administrators; }
        set { SetProperty(ref administrators, value); }
    }

    private AdministratorEntity administrator = new();
    public AdministratorEntity Administrator
    {
        get { return administrator; }
        set { SetProperty(ref administrator, value); }
    }

    private SignUpRequest signUpRequest = new();
    public SignUpRequest SignUpRequest
    {
        get { return signUpRequest; }
        set { SetProperty(ref signUpRequest, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    public async Task GetAdministrators()
    {
        Administrators = await AdministratorsService.GetAsync();
    }

    public ICommand AddAdministratorCommand { get; set; }

    private async void AddAdministratorAsync(object? parameter)
    {
        ActionResponse = await AdministratorsService.AddAsync((parameter as SignUpRequest)!);

        await GetAdministrators();

        SignUpRequest = new SignUpRequest();
    }
}
