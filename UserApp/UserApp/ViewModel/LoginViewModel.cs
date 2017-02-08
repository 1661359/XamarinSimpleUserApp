using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using IronKit.Validation;
using IronKit.Validation.Utils;
using PropertyChanged;
using UserApp.Pages;
using UserApp.Services;
using UserApp.Services.ApiWrapper;
using UserApp.Shared.ViewModels;
using Xamarin.Forms;


namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class LoginViewModel : IViewModel, IValidatable<LoginViewModel>
    {
        private readonly IApiProvider apiProvider;
        private readonly AppSessionConfig appSessionConfig;

        private bool canLogin = true;

        public ICommand DoLoginCommand
        {
            get;
        }

        [Required]
        [MinLength(4)]
        public string UserName
        {
            get;
            set;
        }


        public LoginViewModel(IApiProvider apiProvider, AppSessionConfig appSessionConfig)
        {
            ValidationInfo = new ValidationInfo<LoginViewModel>(this);
            ValidationInfo.AddValidator(m => m.UserName.Length < 8, nameof(UserName));
            DoLoginCommand = new Command(async () => await DoLogin(),() => canLogin );
            this.apiProvider = apiProvider;
            this.appSessionConfig = appSessionConfig;
        }

        private async Task DoLogin()
        {
            if (!this.IsValid())
                return;
            SetCanLoginState(false);
            var cancelationToken = new CancellationTokenSource();
            var authViewModel = await apiProvider.MakeRequest(ct => apiProvider.UsersApi.Login(new UserAuthorizationViewModel {UserName = UserName}, ct), cancelationToken.Token);
            appSessionConfig.LoadAuthorizationResult(authViewModel);
            await NavigateToMainPageWhenLoggedIn();
            SetCanLoginState(true);
        }

        private void SetCanLoginState(bool state)
        {
            canLogin = state;
            ((Command)DoLoginCommand).ChangeCanExecute();
        }

        public async Task NavigateToMainPageWhenLoggedIn()
        {
            if (appSessionConfig.IsLoggedIn)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
        }

        public ValidationInfo<LoginViewModel> ValidationInfo { get; }
    }
}
