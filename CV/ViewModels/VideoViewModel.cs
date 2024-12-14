using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

namespace CV.ViewModels
{

    public class VideoViewModel : ViewModelBase
    {
        private ICommand _goBackCommand;

        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(GoBack));


        private void GoBack()
        {
            NavigationService.GoBack();
        }

    }

}
