using Windows.UI.Xaml.Controls;

namespace CV
{
    public interface INavigationService
    {
        void Navigate<T>(object parameter = null) where T : Page;
        void GoBack();
    }
}
