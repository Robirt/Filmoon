using Filmoon.Commands;
using Filmoon.Entities;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class AddScreenwriterPageViewModel : ViewModelBase
{
    public AddScreenwriterPageViewModel(ScreenwritersService screenwritersService)
    {
        ScreenwritersService = screenwritersService;

        Screenwriter = new ScreenwriterEntity();

        AddScreenwriterCommand = new AddScreenwriterCommand(AddScreenwriterAsync);
    }

    private ScreenwritersService ScreenwritersService { get; }
    private ScreenwriterEntity screenwriter;

    public ScreenwriterEntity Screenwriter
    {
        get { return screenwriter; }
        set { SetProperty(ref screenwriter, value); }
    }

    public ICommand AddScreenwriterCommand { get; set; }

    private async void AddScreenwriterAsync(object? parameter)
    {
        await ScreenwritersService.AddScreenwriterAsync(parameter as ScreenwriterEntity);
    }
}
