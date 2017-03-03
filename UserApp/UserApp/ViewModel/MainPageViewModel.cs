using PropertyChanged;
using UserApp.Helpers;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class MainPageViewModel : IViewModel
    {
        public MainPageViewModel()
        {
            
        }

        public void LoadLoginPageWhenNotLogged()
        {
            if (!AppSessionConfig.IsLoggedIn)
                Application.Current.ShowLoginPage();
        }

    }
}
