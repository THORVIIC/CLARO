using Windows.UI.Xaml.Controls;

namespace CV
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;

        public void Initialize(Frame frame)
        {
            _frame = frame;
        }

        public void Navigate<T>(object parameter = null) where T : Page
        {
            _frame.Navigate(typeof(T), parameter);
        }

        public void GoBack()
        {
            if (_frame.CanGoBack)
            {
                _frame.GoBack();
            }
        }
    }
}
