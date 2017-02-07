using UserApp.Shared.Contracts;
using UserApp.Shared.ViewModels;

namespace UserApp.Services
{
    public class AppSessionConfig
    {
        private string userName;
        private string token;

        public string UserName => IsLoggedIn ? userName : null;

        public string Token => IsLoggedIn ? token : null;

        public bool IsLoggedIn { get; private set; }

        public void LoadAuthorizationResult(UserAuthorizationViewModel model)
        {
            if (model == null)
            {
                IsLoggedIn = false;
                return;
            }
            userName = model.UserName;
            token = model.Token;
            IsLoggedIn = model.AuthorizationAnswer == AuthorizationAnswer.Ok;
        }

        public void DoLogout()
        {
            IsLoggedIn = false;
        }
    }
}
