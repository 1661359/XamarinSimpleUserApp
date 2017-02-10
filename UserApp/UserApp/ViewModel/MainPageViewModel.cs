using PropertyChanged;
using UserApp.Helpers;
using UserApp.Services;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class MainPageViewModel : IViewModel
    {
        private readonly AppSessionConfig appSessionConfig;

        public MainPageViewModel(AppSessionConfig appSessionConfig)
        {
            this.appSessionConfig = appSessionConfig;
        }

        public void LoadLoginPageWhenNotLogged()
        {
            if (!appSessionConfig.IsLoggedIn)
                Application.Current.ShowLoginPage();
        }

    }
}
