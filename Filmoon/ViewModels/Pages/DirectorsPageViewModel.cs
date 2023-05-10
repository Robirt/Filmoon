using Filmoon.Commands.Directors;
using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class DirectorsPageViewModel : ViewModelBase
{
    public DirectorsPageViewModel(DirectorsService directorsService)
    {
        DirectorsService = directorsService;

        AddDirectorCommand = new AddDirectorCommand(AddDirectorAsync);
        UpdateDirectorCommand = new UpdateDirectorCommand(UpdateDirectorAsync);
        RemoveDirectorCommand = new RemoveDirectorCommand(RemoveDirectorAsync);
    }

    private DirectorsService DirectorsService { get; }

    private List<DirectorEntity>? directors = new();
    public List<DirectorEntity>? Directors
    {
        get { return directors; }
        set { SetProperty(ref directors, value); }
    }

    private DirectorEntity director = new();
    public DirectorEntity Director
    {
        get { return director; }
        set { SetProperty(ref director, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    public async Task GetDirectors()
    {
        Directors = await DirectorsService.GetAsync();
    }

    public ICommand AddDirectorCommand { get; set; }
    public ICommand UpdateDirectorCommand { get; set; }
    public ICommand RemoveDirectorCommand { get; set; }

    private async void AddDirectorAsync(object? parameter)
    {
        (parameter as DirectorEntity)!.Id = 0;

        ActionResponse = await DirectorsService.AddAsync((parameter as DirectorEntity)!);

        await GetDirectors();

        Director = new DirectorEntity();
    }

    private async void UpdateDirectorAsync(object? parameter)
    {
        ActionResponse = await DirectorsService.UpdateAsync((parameter as DirectorEntity)!);

        await GetDirectors();

        Director = new DirectorEntity();
    }

    private async void RemoveDirectorAsync(object? parameter)
    {
        ActionResponse = await DirectorsService.RemoveAsync((parameter as DirectorEntity)!);

        await GetDirectors();

        Director = new DirectorEntity();
    }
}
