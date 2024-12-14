using CommunityToolkit.Mvvm.Input;
using CV.Models;
using CV.Services;
using CV.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV.ViewModels
{
    public class MovieDetailViewModel : ViewModelBase
    {
        private readonly Data _dataService;
        private ICommand _goBackCommand;
        private ICommand _viewVideoCommand;

        private Movie _selectedMovie;
        private ObservableCollection<Movie> _movies;


        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set => SetProperty(ref _selectedMovie, value);
        }

        public ObservableCollection<Movie> Movies
        {
            get => _movies;
            set => SetProperty(ref _movies, value);
        }


        public MovieDetailViewModel()
        {
            _dataService = new Data();
            Movies = new ObservableCollection<Movie>();
            LoadMoviesCommand = new AsyncRelayCommand(LoadMoviesAsync);
        }

        public IAsyncRelayCommand LoadMoviesCommand { get; }
        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(GoBack));
        public ICommand ViewVideoCommand => _viewVideoCommand ?? (_viewVideoCommand = new RelayCommand(ViewVideo));

        private void GoBack()
        {
            NavigationService.GoBack();
        }

        private void ViewVideo()
        {
            NavigationService.Navigate<VideoView>();
        }

        private async Task LoadMoviesAsync()
        {
            try
            {
                List<string> urls = new List<string>
                {
                    "https://api.jsonbin.io/v3/b/6670b6abe41b4d34e404c0bd",
                    "https://api.jsonbin.io/v3/b/6670b60cad19ca34f87a78d2",
                    "https://api.jsonbin.io/v3/b/6670b60cad19ca34f87a78d2",
                    "https://api.jsonbin.io/v3/b/6670b55be41b4d34e404c04d"
                };

                Random random = new Random();
                string selectedUrl = urls[random.Next(urls.Count)];

                var movieResponse = await _dataService.ObtenerDatosAsync(selectedUrl);
                Movies = new ObservableCollection<Movie>(movieResponse.Record.Response.Groups);
            }
            catch (Exception ex)
            {

            }
            finally
            {
            }
        }
    }
}
