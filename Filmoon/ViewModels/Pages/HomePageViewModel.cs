using Filmoon.Entities;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Filmoon.ViewModels.Pages;

public class HomePageViewModel : ViewModelBase
{
    public HomePageViewModel(MoviesService moviesService)
    {
        MoviesService = moviesService;
    }

    private MoviesService MoviesService { get; }

    private List<MovieEntity>? movies = new();
    public List<MovieEntity>? Movies
    {
        get { return movies; }
        set { SetProperty(ref movies, value); }
    }

    public async Task GetMovies()
    {
        Movies = await MoviesService.GetAsync();
    }
}
