using System.Windows.Input;
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

        public ICommand LoadUserNameCommand
        {
            get;
            private set;
        }

        public LogoutPageViewModel(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;

            LoadUserNameCommand = new Command(LoadUserName);
        }

        private void LoadUserName()
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
