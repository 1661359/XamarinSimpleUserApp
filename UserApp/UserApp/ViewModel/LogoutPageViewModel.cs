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
        private readonly AppSessionConfig appSessionConfig;

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
        public ICommand DoLogoutCommand
        {
            get;
            private set;
        }


        public LogoutPageViewModel(AppSessionConfig appSessionConfig)
        {
            this.appSessionConfig = appSessionConfig;
            LoadUserNameCommand = new Command(LoadUserName);
            DoLogoutCommand = new Command(DoLogout);
        }

        private void LoadUserName()
        {
            UserName = appSessionConfig.UserName;
        }

        private void DoLogout()
        {
            UserName = string.Empty;
            appSessionConfig.DoLogout(); 
            Application.Current.ShowLoginPage();
        }
    }
}
