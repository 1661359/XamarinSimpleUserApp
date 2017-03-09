using PropertyChanged;
using UserApp.Helpers;
using UserApp.Services;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class LogoutPageViewModel : IViewModel
    {
        private readonly IAuthorizationService authorizationService;

        public string UserName
        {
            get;
            set;
        }

        public LogoutPageViewModel(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;
        }

        public void LoadUserName()
        {
            UserName = AppSessionConfig.UserName;
        }

        public void DoLogout()
        {
            UserName = string.Empty;
            authorizationService.Logout(); 
            Application.Current.ShowLoginPage();
        }
    }
}
