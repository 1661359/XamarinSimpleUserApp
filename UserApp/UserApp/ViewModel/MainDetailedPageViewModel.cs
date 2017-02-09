using PropertyChanged;
using UserApp.Pages;
using UserApp.Services;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class MainDetailedPageViewModel
    {
        private readonly AppSessionConfig appSessionConfig;

        public MainDetailedPageViewModel(AppSessionConfig appSessionConfig)
        {
            this.appSessionConfig = appSessionConfig;
        }

        public void LoadLoginPageWhenNotLogged()
        {
            if (!appSessionConfig.IsLoggedIn)
                Application.Current.MainPage = new LoginPage();
        }

    }
}
