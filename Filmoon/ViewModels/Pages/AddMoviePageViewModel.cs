using Filmoon.Commands;
using Filmoon.Entities;
using Filmoon.Services;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class AddMoviePageViewModel : ViewModelBase
{
    public AddMoviePageViewModel(MoviesService moviesService)
    {
        MoviesService = moviesService;

        Movie = new MovieEntity();

        AddMovieCommand = new AddMovieCommand(AddMovieAsync);
    }

    private MoviesService MoviesService { get; }
    private MovieEntity movie;

    public MovieEntity Movie 
    { 
        get { return movie; }
        set { SetProperty(ref movie, value); }
    }

    public ICommand AddMovieCommand { get; set; }

    private async void AddMovieAsync(object? parameter)
    {
        await MoviesService.AddMovieAsync(parameter as MovieEntity);
    }
}
