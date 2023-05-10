using Filmoon.Commands.Movies;
using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class MoviesPageViewModel : ViewModelBase
{
    public MoviesPageViewModel(MoviesService moviesService, GenresService genresService, ScreenwritersService screenwritersService, DirectorsService directorsService)
    {
        MoviesService = moviesService;
        GenresService = genresService;
        ScreenwritersService = screenwritersService;
        DirectorsService = directorsService;

        AddMovieCommand = new AddMovieCommand(AddMovieAsync);
        UpdateMovieCommand = new UpdateMovieCommand(UpdateMovieAsync);
        RemoveMovieCommand = new RemoveMovieCommand(RemoveMovieAsync);
    }

    private MoviesService MoviesService { get; }
    private GenresService GenresService { get; }
    private ScreenwritersService ScreenwritersService { get; }
    private DirectorsService DirectorsService { get; }

    private List<MovieEntity>? movies = new();
    public List<MovieEntity>? Movies
    {
        get { return movies; }
        set { SetProperty(ref movies, value); }
    }

    private MovieEntity movie = new();
    public MovieEntity Movie
    {
        get { return movie; }
        set { SetProperty(ref movie, value); }
    }

    private ActionResponse? actionResponse = new();
    public ActionResponse? ActionResponse
    {
        get { return actionResponse; }
        set { SetProperty(ref actionResponse, value); }
    }

    private List<GenreEntity>? genres = new();
    public List<GenreEntity>? Genres
    {
        get { return genres; }
        set { SetProperty(ref genres, value); }
    }

    private List<ScreenwriterEntity>? screenwriters = new();
    public List<ScreenwriterEntity>? Screenwriters
    {
        get { return screenwriters; }
        set { SetProperty(ref screenwriters, value); }
    }

    private List<DirectorEntity>? directors = new();
    public List<DirectorEntity>? Directors
    {
        get { return directors; }
        set { SetProperty(ref directors, value); }
    }

    public async Task GetMovies()
    {
        Movies = await MoviesService.GetAsync();
    }

    public async Task GetGenres()
    {
        Genres = await GenresService.GetAsync();
    }

    public async Task GetScreenwriters()
    {
        Screenwriters = await ScreenwritersService.GetAsync();
    }

    public async Task GetDirectors()
    {
        Directors = await DirectorsService.GetAsync();
    }

    public ICommand AddMovieCommand { get; set; }
    public ICommand UpdateMovieCommand { get; set; }
    public ICommand RemoveMovieCommand { get; set; }

    private async void AddMovieAsync(object? parameter)
    {
        (parameter as MovieEntity)!.Id = 0;
        (parameter as MovieEntity)!.GenreId = (parameter as MovieEntity)!.Genre!.Id;
        (parameter as MovieEntity)!.ScreenwriterId = (parameter as MovieEntity)!.Screenwriter!.Id;
        (parameter as MovieEntity)!.DirectorId = (parameter as MovieEntity)!.Director!.Id;
        (parameter as MovieEntity)!.Genre = null;
        (parameter as MovieEntity)!.Screenwriter = null;
        (parameter as MovieEntity)!.Director = null;

        ActionResponse = await MoviesService.AddAsync((parameter as MovieEntity)!);

        await GetMovies();

        Movie = new MovieEntity();
    }

    private async void UpdateMovieAsync(object? parameter)
    {
        (parameter as MovieEntity)!.GenreId = (parameter as MovieEntity)!.Genre!.Id;
        (parameter as MovieEntity)!.ScreenwriterId = (parameter as MovieEntity)!.Screenwriter!.Id;
        (parameter as MovieEntity)!.DirectorId = (parameter as MovieEntity)!.Director!.Id;
        (parameter as MovieEntity)!.Genre = null;
        (parameter as MovieEntity)!.Screenwriter = null;
        (parameter as MovieEntity)!.Director = null;

        ActionResponse = await MoviesService.UpdateAsync((parameter as MovieEntity)!);

        await GetMovies();

        Movie = new MovieEntity();
    }

    private async void RemoveMovieAsync(object? parameter)
    {
        ActionResponse = await MoviesService.RemoveAsync((parameter as MovieEntity)!);

        await GetMovies();

        Movie = new MovieEntity();
    }
}
