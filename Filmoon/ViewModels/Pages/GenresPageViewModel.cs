using Filmoon.Commands.Genres;
using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class GenresPageViewModel : ViewModelBase
{
    public GenresPageViewModel(GenresService directorsService)
    {
        GenresService = directorsService;

        AddGenreCommand = new AddGenreCommand(AddGenreAsync);
        UpdateGenreCommand = new UpdateGenreCommand(UpdateGenreAsync);
        RemoveGenreCommand = new RemoveGenreCommand(RemoveGenreAsync);
    }

    private GenresService GenresService { get; }

    private List<GenreEntity>? directors = new();
    public List<GenreEntity>? Genres
    {
        get { return directors; }
        set { SetProperty(ref directors, value); }
    }

    private GenreEntity director = new();
    public GenreEntity Genre
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

    public async Task GetGenres()
    {
        Genres = await GenresService.GetAsync();
    }

    public ICommand AddGenreCommand { get; set; }
    public ICommand UpdateGenreCommand { get; set; }
    public ICommand RemoveGenreCommand { get; set; }

    private async void AddGenreAsync(object? parameter)
    {
        (parameter as GenreEntity)!.Id = 0;

        ActionResponse = await GenresService.AddAsync((parameter as GenreEntity)!);

        await GetGenres();

        Genre = new GenreEntity();
    }

    private async void UpdateGenreAsync(object? parameter)
    {
        ActionResponse = await GenresService.UpdateAsync((parameter as GenreEntity)!);

        await GetGenres();

        Genre = new GenreEntity();
    }

    private async void RemoveGenreAsync(object? parameter)
    {
        ActionResponse = await GenresService.RemoveAsync((parameter as GenreEntity)!);

        await GetGenres();

        Genre = new GenreEntity();
    }
}
