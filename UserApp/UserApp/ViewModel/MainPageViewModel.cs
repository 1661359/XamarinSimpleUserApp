using PropertyChanged;
using UserApp.Helpers;
using UserApp.Services;
using UserApp.Shared.Contracts;
using UserApp.Shared.ViewModels;
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
            //clear
            //appSessionConfig.LoadAuthorizationResult(new UserAuthorizationViewModel() {AuthorizationAnswer = AuthorizationAnswer.Ok, UserName = "LOL"});
            if (!appSessionConfig.IsLoggedIn)
                Application.Current.ShowLoginPage();
        }

    }
}
