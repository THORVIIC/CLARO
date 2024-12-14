using CV.Models;
using CV.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace CV.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MovieDetailView : Page
    {
        public MovieDetailView()
        {
            this.InitializeComponent();
            this.DataContext = new MovieDetailViewModel();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
            {
                DataContext = new MovieDetailViewModel();
            }

            if (DataContext is MovieDetailViewModel viewModel)
            {
                await viewModel.LoadMoviesCommand.ExecuteAsync(null);
            }
        }



        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter is Movie selectedMovie)
            {
                (DataContext as MovieDetailViewModel).SelectedMovie = selectedMovie;
            }
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer.ChangeView(MovieScrollViewer.HorizontalOffset - 1000, null, null);
        }

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer.ChangeView(MovieScrollViewer.HorizontalOffset + 1000, null, null);
        }

        private void MovieScrollViewer_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            MovieScrollViewer.ChangeView(MovieScrollViewer.HorizontalOffset - e.Delta.Translation.X, null, null);
        }

        private void Image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is Movie selectedMovie)
            {
                DataContext = new MovieViewModel();                
                // Asumiendo que tienes acceso al ViewModel a través del DataContext de la página
                var viewModel = DataContext as MovieViewModel;
                viewModel?.NavigateToDetailCommand.Execute(selectedMovie);
            }
        }

        private void LeftButton2_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer2.ChangeView(MovieScrollViewer2.HorizontalOffset - 1000, null, null);
        }

        private void RightButton2_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer2.ChangeView(MovieScrollViewer2.HorizontalOffset + 1000, null, null);
        }

        private void MovieScrollViewer2_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            MovieScrollViewer2.ChangeView(MovieScrollViewer2.HorizontalOffset - e.Delta.Translation.X, null, null);
        }
    }
}
