using Filmoon.Commands.Rentals;
using Filmoon.Entities;
using Filmoon.Responses;
using Filmoon.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Filmoon.ViewModels.Pages;

public class CatalogPageViewModel : ViewModelBase
{
    public CatalogPageViewModel(RentalsService rentalsService, MoviesService moviesService)
    {
        RentalsService = rentalsService;
        MoviesService = moviesService;

        AddRentalCommand = new AddRentalCommand(AddRentAsync);
    }

    private RentalsService RentalsService { get; }
    private MoviesService MoviesService { get; }

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

    public async Task GetMovies()
    {
        Movies = await MoviesService.GetAsync();
    }

    public ICommand AddRentalCommand { get; set; }

    private async void AddRentAsync(object? parameter)
    {
        ActionResponse = await RentalsService.AddAsync(new RentalEntity() { MovieId = ((parameter as MovieEntity)!).Id});

        await GetMovies();

        Movie = new MovieEntity();
    }
}
