using ClaroVideoJVSR.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ClaroVideoJVSR.ViewModels
{
    public class MovieDetailViewModel : INotifyPropertyChanged
    {
        private Movie _selectedMovie;
        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
