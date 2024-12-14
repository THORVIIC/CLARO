using CommunityToolkit.Mvvm.Input;
using CV.Models;
using CV.Services;
using CV.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.Windows.Input;
using System.ComponentModel;

namespace CV.ViewModels
{
    public class MovieViewModel : ViewModelBase
    {
        private readonly Data _dataService;
        public ICommand NavigateToDetailCommand { get; }

        private ObservableCollection<Movie> _movies;
        private ObservableCollection<Movie> _moviesDos;
        private ObservableCollection<Movie> _moviesTres;
        private ObservableCollection<Movie> _moviesCuatro;


        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }
        public ObservableCollection<Movie> MoviesDos
        {
            get => _moviesDos;
            set => SetProperty(ref _moviesDos, value);
        }
        public ObservableCollection<Movie> MoviesTres
        {
            get => _moviesTres;
            set => SetProperty(ref _moviesTres, value);
        }
        public ObservableCollection<Movie> MoviesCuatro
        {
            get => _moviesCuatro;
            set => SetProperty(ref _moviesCuatro, value);
        }

        public MovieViewModel()
        {
            _dataService = new Data();
            Movies = new ObservableCollection<Movie>();
            MoviesDos = new ObservableCollection<Movie>();
            MoviesTres = new ObservableCollection<Movie>();
            MoviesCuatro = new ObservableCollection<Movie>();
            LoadMoviesCommand = new AsyncRelayCommand(LoadMoviesAsync);
            NavigateToDetailCommand = new RelayCommand<Movie>(NavigateToDetail);
        }


        //private ICommand _navigateToDetailCommand;

        public IAsyncRelayCommand LoadMoviesCommand { get; }
        //public ICommand NavigateToDetailCommand => _navigateToDetailCommand = new RelayCommand(NavigateToDetail);



        private async Task LoadMoviesAsync()
        {
            try
            {
                var movieResponse = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b6abe41b4d34e404c0bd");
                Movies = Descripcion(new ObservableCollection<Movie>(movieResponse.Record.Response.Groups));


                var movieResponse2 = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b60cad19ca34f87a78d2");
                MoviesDos = Descripcion(new ObservableCollection<Movie>(movieResponse2.Record.Response.Groups));

                var movieResponse3 = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b67cad19ca34f87a78ed");
                MoviesTres = Descripcion(new ObservableCollection<Movie>(movieResponse3.Record.Response.Groups));

                var movieResponse4 = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b55be41b4d34e404c04d");
                MoviesCuatro = Descripcion(new ObservableCollection<Movie>(movieResponse4.Record.Response.Groups));

            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }

        private void NavigateToDetail(Movie selectedMovie)
        {
            NavigationService.Navigate<MovieDetailView>(selectedMovie);
        }

        protected ObservableCollection<Movie> Descripcion(ObservableCollection<Movie> Mo)
        {
            foreach (var movie in Mo)
            {
                if (movie.Description_Large.Length > 150)
                    movie.Description_Large = movie.Description_Large.Substring(0, 150)+"...";
            }

            return Mo;
        }
    }
}