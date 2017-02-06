    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using PropertyChanged;
    using UserApp.Services;
    using UserApp.Services.ApiWrapper;
    using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class LoginViewModel : IViewModel
    {
        private readonly IApiProvider apiProvider;
        private readonly AppSessionConfig appSessionConfig;

        public ICommand DoLoginCommand
        {
            get;
            private set;
        }
        public string UserName
        {
            get;
            set;
        }

        public bool IsLoggedIn
        {
            get;
            private set;
        }

        public LoginViewModel(IApiProvider apiProvider, AppSessionConfig appSessionConfig)
        {
            DoLoginCommand = new Command(async () => await DoLogin() );
            this.apiProvider = apiProvider;
            this.appSessionConfig = appSessionConfig;
        }

        private async Task DoLogin()
        {
            var cancelationToken = new CancellationTokenSource();
            var authViewModel = await apiProvider.MakeRequest(ct => apiProvider.UsersApi.Login(UserName, ct), cancelationToken.Token);
            appSessionConfig.LoadAuthorizationResult(authViewModel);
            IsLoggedIn = appSessionConfig.IsLoggedIn;
        }
    }
}
