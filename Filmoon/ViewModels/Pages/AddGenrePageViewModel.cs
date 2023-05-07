using Filmoon.Commands;
using Filmoon.Entities;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class AddGenrePageViewModel: ViewModelBase
{
    public AddGenrePageViewModel(GenresService genresService)
    {
        GenresService = genresService;

        Genre = new GenreEntity();

        AddGenreCommand = new AddGenreCommand(AddGenreAsync);
    }

    private GenresService GenresService { get; }
    private GenreEntity genre;

    public GenreEntity Genre
    {
        get { return genre; }
        set { SetProperty(ref genre, value); }
    }

    public ICommand AddGenreCommand { get; set; }

    private async void AddGenreAsync(object? parameter)
    {
        await GenresService.AddAsync(parameter as GenreEntity);
    }
}
