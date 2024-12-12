using ClaroVideoJVSR.ViewModels;
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

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClaroVideoJVSR.Views
{
    public sealed partial class MovieView : UserControl
    {
        public MovieView()
        {
            this.InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext == null)
            {
                DataContext = new MovieViewModel();
            }

            if (DataContext is MovieViewModel viewModel)
            {
                await viewModel.LoadMoviesCommand.ExecuteAsync(null);
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

        private void LeftButton2_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer2.ChangeView(MovieScrollViewer2.HorizontalOffset - 200, null, null);
        }

        private void RightButton2_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer2.ChangeView(MovieScrollViewer2.HorizontalOffset + 200, null, null);
        }

        private void MovieScrollViewer2_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            MovieScrollViewer2.ChangeView(MovieScrollViewer2.HorizontalOffset - e.Delta.Translation.X, null, null);
        }


        private void LeftButton3_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer3.ChangeView(MovieScrollViewer3.HorizontalOffset - 200, null, null);
        }

        private void RightButton3_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer3.ChangeView(MovieScrollViewer3.HorizontalOffset + 200, null, null);
        }

        private void MovieScrollViewer3_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            MovieScrollViewer3.ChangeView(MovieScrollViewer3.HorizontalOffset - e.Delta.Translation.X, null, null);
        }

        private void LeftButton4_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer4.ChangeView(MovieScrollViewer4.HorizontalOffset - 200, null, null);
        }

        private void RightButton4_Click(object sender, RoutedEventArgs e)
        {
            MovieScrollViewer4.ChangeView(MovieScrollViewer4.HorizontalOffset + 200, null, null);
        }

        private void MovieScrollViewer4_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            MovieScrollViewer4.ChangeView(MovieScrollViewer4.HorizontalOffset - e.Delta.Translation.X, null, null);
        }
    }
}
