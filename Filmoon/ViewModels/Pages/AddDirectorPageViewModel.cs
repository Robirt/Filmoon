using Filmoon.Commands;
using Filmoon.Entities;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class AddDirectorPageViewModel : ViewModelBase
{
    public AddDirectorPageViewModel(DirectorsService directorsService)
    {
        DirectorsService = directorsService;

        Director = new DirectorEntity();

        AddDirectorCommand = new AddDirectorCommand(AddDirectorAsync);
    }

    private DirectorsService DirectorsService { get; }
    private DirectorEntity director;

    public DirectorEntity Director
    {
        get { return director; }
        set { SetProperty(ref director, value); }
    }

    public ICommand AddDirectorCommand { get; set; }

    private async void AddDirectorAsync(object? parameter)
    {
        await DirectorsService.AddDirectorAsync(parameter as DirectorEntity);
    }
}
