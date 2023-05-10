using Filmoon.Commands.Screenwriters;
using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class ScreenwritersPageViewModel : ViewModelBase
{
    public ScreenwritersPageViewModel(ScreenwritersService screenwritersService)
    {
        ScreenwritersService = screenwritersService;

        AddScreenwriterCommand = new AddScreenwriterCommand(AddScreenwriterAsync);
        UpdateScreenwriterCommand = new UpdateScreenwriterCommand(UpdateScreenwriterAsync);
        RemoveScreenwriterCommand = new RemoveScreenwriterCommand(RemoveScreenwriterAsync);
    }

    private ScreenwritersService ScreenwritersService { get; }

    private List<ScreenwriterEntity>? screenwriters = new();
    public List<ScreenwriterEntity>? Screenwriters
    {
        get { return screenwriters; }
        set { SetProperty(ref screenwriters, value); }
    }

    private ScreenwriterEntity screenwriter = new();
    public ScreenwriterEntity Screenwriter
    {
        get { return screenwriter; }
        set { SetProperty(ref screenwriter, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    public async Task GetScreenwriters()
    {
        Screenwriters = await ScreenwritersService.GetAsync();
    }

    public ICommand AddScreenwriterCommand { get; set; }
    public ICommand UpdateScreenwriterCommand { get; set; }
    public ICommand RemoveScreenwriterCommand { get; set; }

    private async void AddScreenwriterAsync(object? parameter)
    {
        (parameter as ScreenwriterEntity)!.Id = 0;

        ActionResponse = await ScreenwritersService.AddAsync((parameter as ScreenwriterEntity)!);

        await GetScreenwriters();

        Screenwriter = new ScreenwriterEntity();
    }

    private async void UpdateScreenwriterAsync(object? parameter)
    {
        ActionResponse = await ScreenwritersService.UpdateAsync((parameter as ScreenwriterEntity)!);

        await GetScreenwriters();

        Screenwriter = new ScreenwriterEntity();
    }

    private async void RemoveScreenwriterAsync(object? parameter)
    {
        ActionResponse = await ScreenwritersService.RemoveAsync((parameter as ScreenwriterEntity)!);

        await GetScreenwriters();

        Screenwriter = new ScreenwriterEntity();
    }
}
