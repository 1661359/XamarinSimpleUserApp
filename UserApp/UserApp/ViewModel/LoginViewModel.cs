using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using IronKit.Validation;
using IronKit.Validation.Utils;
using PropertyChanged;
using UserApp.Helpers;
using UserApp.Services;
using UserApp.Services.ApiWrapper;
using UserApp.Shared.Contracts;
using UserApp.Shared.ViewModels;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class LoginViewModel : IViewModel, IValidatable<LoginViewModel>, INotifyPropertyChanged
    {
        private readonly IApiProvider apiProvider;
        private readonly AppSessionConfig appSessionConfig;

        private bool canLogin;

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

        public bool IsShowMessage
        {
            get;
            set;
        }


        public LoginViewModel(IApiProvider apiProvider, AppSessionConfig appSessionConfig)
        {
            this.apiProvider = apiProvider;
            this.appSessionConfig = appSessionConfig;
            ValidationInfo = new ValidationInfo<LoginViewModel>(this);
            DoLoginCommand = new Command(async () => await DoLogin(),() => canLogin);
            this.AddPropertyChangeHandler(ValidateUserName, m => m.UserName);
        }

        public void ValidateUserName()
        {
            var isUserNameValid = ValidationInfo.GetInvalidProperties().All(x => x != nameof(UserName));
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
            IsShowMessage = true;
            LoginMessage = message;
        }
        
        public void NavigateToMainPageWhenLoggedIn()
        {
            if (appSessionConfig.IsLoggedIn)
            {
                UserName = string.Empty;
                IsShowMessage = false;
                Application.Current.ShowMainPage();
            }
        }
        
        public void EnableDoLoginCommand(bool state)
        {
            canLogin = state;
            ((Command)DoLoginCommand).ChangeCanExecute();
        }
        public void HideMessage()
        {
            IsShowMessage = false;
        }

        public ValidationInfo<LoginViewModel> ValidationInfo { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        [Annotations.NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
