using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using IronKit.Validation;
using IronKit.Validation.Utils;
using PropertyChanged;
using UserApp.Helpers;
using UserApp.Services;
using UserApp.Shared.Contracts;
using Xamarin.Forms;

namespace UserApp.ViewModel
{
    [ImplementPropertyChanged]
    public class LoginViewModel : IViewModel, IValidatable<LoginViewModel>
    {
        private readonly IAuthorizationService authorizationService;

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string UserName { get; set; }

        public string LoginMessage { get; set; }

        public bool IsShowMessage { get; set; }

        public bool IsLoginEnabled { get; set; }

        public LoginViewModel(IAuthorizationService authorizationService)
        {
            this.authorizationService = authorizationService;

            ValidationInfo = new ValidationInfo<LoginViewModel>(this);
            ValidationInfo.PropertyValidationOccurred += PropertyValidationHandler;
        }

        private void PropertyValidationHandler(object sender, PropertyValidationOccurredEventArgs e)
        {
            if (e.PropertyName == nameof(UserName))
            {
                IsLoginEnabled = e.IsValid;
            }
        }

        public async Task DoLogin()
        {
            if (!this.IsValid())
                return;
            IsLoginEnabled = false;
            ShowMessage(AppResources.Message_WaitAnswer);
            try
            {
                await authorizationService.Login(UserName);
                if (AppSessionConfig.LastAuthorizationAnswer == AuthorizationAnswer.WrongUserName)
                {
                    ShowMessage(AppResources.Message_WrongUserName);
                }
                NavigateToMainPageWhenLoggedIn();
            }
            catch (Exception e)
            {
                ShowMessage(e.Message);
            }
        }

        private void ShowMessage(string message)
        {
            IsShowMessage = true;
            LoginMessage = message;
        }
        
        public void NavigateToMainPageWhenLoggedIn()
        {
            if (!AppSessionConfig.IsLoggedIn) return;
            UserName = string.Empty;
            HideMessage();
            Application.Current.ShowMainPage();
        }

        public void HideMessage()
        {
            IsShowMessage = false;
        }

        public ValidationInfo<LoginViewModel> ValidationInfo { get; }
    }
}
