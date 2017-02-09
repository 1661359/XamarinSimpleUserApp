using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using IronKit.Validation;
using IronKit.Validation.Utils;
using PropertyChanged;
using UserApp.Pages;
using UserApp.Services;
using UserApp.Services.ApiWrapper;
using UserApp.Shared.Contracts;
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
        [StringLength(8, MinimumLength = 4)]
        public string UserName
        {
            get;
            set;
        }

        public string LoginMessage
        {
            get;
            set;
        }

        public bool IsMessageVisible
        {
            get;
            set;
        }


        public LoginViewModel(IApiProvider apiProvider, AppSessionConfig appSessionConfig)
        {
            this.apiProvider = apiProvider;
            this.appSessionConfig = appSessionConfig;
            ValidationInfo = new ValidationInfo<LoginViewModel>(this);
            ValidationInfo.ValidationOccurred += ValidationOccurredEventHandler;
            DoLoginCommand = new Command(async () => await DoLogin(),() => canLogin);
            
        }

        private void ValidationOccurredEventHandler(object sender, ValidationOccurredEventArgs e)
        {
            var isUserNameValid = e.InvalidProperties.Any(x => x == nameof(UserName));
            EnableDoLoginCommand(isUserNameValid);
        }

        private async Task DoLogin()
        {
            if (!this.IsValid())
                return;
            EnableDoLoginCommand(false);
            ShowMessage(AppResources.Message_WaitAnswer);
            var authViewModel = await GetUserAuthorizationViewModel();
            if (authViewModel != null)
            {
                appSessionConfig.LoadAuthorizationResult(authViewModel);
                if (authViewModel.AuthorizationAnswer == AuthorizationAnswer.WrongUserName)
                {
                    ShowMessage(AppResources.Message_WrongUserName);
                }
                NavigateToMainPageWhenLoggedIn();
            }
            else
            {
                ShowMessage(AppResources.Message_ProblemWithConnection);
            }
            EnableDoLoginCommand(true);
        }

        private async Task<UserAuthorizationViewModel> GetUserAuthorizationViewModel()
        {
            var cancelationToken = new CancellationTokenSource();
            var authViewModel =
                await
                    apiProvider.MakeRequest(
                        ct => apiProvider.UsersApi.Login(new UserAuthorizationViewModel {UserName = UserName}, ct),
                        cancelationToken.Token);
            return authViewModel;
        }

        private void ShowMessage(string message)
        {
            IsMessageVisible = true;
            LoginMessage = message;
        }

        public void NavigateToMainPageWhenLoggedIn()
        {
            if (appSessionConfig.IsLoggedIn)
            {
                UserName = string.Empty;
                IsMessageVisible = false;
                Application.Current.MainPage = new MainDetailedPage();
            }
        }

        public void EnableDoLoginCommand(bool state)
        {
            canLogin = state;
            ((Command)DoLoginCommand).ChangeCanExecute();
        }

        public ValidationInfo<LoginViewModel> ValidationInfo { get; }
    }
}
