using CV.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
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
    public sealed partial class VideoView : Page
    {
        public VideoView()
        {
            this.InitializeComponent();
            this.DataContext = new VideoViewModel();
            Loaded += VideoView_Loaded;
            Unloaded += VideoView_Unloaded;
        }
        private void VideoView_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationView.GetForCurrentView();
        }

        private void VideoView_Unloaded(object sender, RoutedEventArgs e)
        {
            mediaPlayer.MediaPlayer.Pause();
            mediaPlayer.MediaPlayer.Source = null;
        }
    }
}
