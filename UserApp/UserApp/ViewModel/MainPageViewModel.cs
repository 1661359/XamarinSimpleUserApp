using System.Windows.Input;
using PropertyChanged;
using UserApp.Pages;
using UserApp.Services;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class MainPageViewModel : IViewModel
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


        public MainPageViewModel(AppSessionConfig appSessionConfig)
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
            appSessionConfig.DoLogout(); 
            Application.Current.MainPage = new LoginPage();
        }
    }
}
