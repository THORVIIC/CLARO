using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ClaroVideoJVSR.Models;
using ClaroVideoJVSR.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System;
using System.ComponentModel;

namespace ClaroVideoJVSR.ViewModels
{
    public class MovieViewModel : ObservableObject, INotifyPropertyChanged
    {
        private readonly Data _dataService;
        private ObservableCollection<Movie> _movies;
        private ObservableCollection<Movie> _moviesDos;
        private ObservableCollection<Movie> _moviesTres;
        private ObservableCollection<Movie> _moviesCuatro;
        private bool _isLoading;

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

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public IAsyncRelayCommand LoadMoviesCommand { get; }

        public MovieViewModel()
        {
            _dataService = new Data();
            LoadMoviesCommand = new AsyncRelayCommand(LoadMoviesAsync);
            Movies = new ObservableCollection<Movie>();
            MoviesDos = new ObservableCollection<Movie>();
            MoviesTres = new ObservableCollection<Movie>();
            MoviesCuatro = new ObservableCollection<Movie>();
        }

        private async Task LoadMoviesAsync()
        {
            try
            {
                IsLoading = true;
                var movieResponse = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b55be41b4d34e404c04d");
                Movies = new ObservableCollection<Movie>(movieResponse.Record.Response.Groups);

                var movieResponse2 = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b60cad19ca34f87a78d2");
                MoviesDos = new ObservableCollection<Movie>(movieResponse2.Record.Response.Groups);

                var movieResponse3 = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b67cad19ca34f87a78ed");
                MoviesTres = new ObservableCollection<Movie>(movieResponse3.Record.Response.Groups);

                var movieResponse4 = await _dataService.ObtenerDatosAsync("https://api.jsonbin.io/v3/b/6670b6abe41b4d34e404c0bd");
                MoviesCuatro = new ObservableCollection<Movie>(movieResponse4.Record.Response.Groups);
            }
            catch (Exception ex)
            {
                // Manejo de errores
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
