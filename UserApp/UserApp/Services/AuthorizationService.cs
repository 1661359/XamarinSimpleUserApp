using System;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Services.ApiWrapper;
using UserApp.Shared.Contracts;
using UserApp.Shared.ViewModels;

namespace UserApp.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IApiProvider apiProvider;

        public AuthorizationService(IApiProvider apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        public async Task Login(string userName)
        {
            var authViewModel = await GetUserAuthorizationViewModel(userName);
            if (authViewModel == null)
            {
                throw new Exception(AppResources.Message_ProblemWithConnection);
            }
            LoadAuthorizationResult(authViewModel);
        }

        public void Logout()
        {
            AppSessionConfig.IsLoggedIn = false;
        }

        private async Task<UserAuthorizationViewModel> GetUserAuthorizationViewModel(string userName)
        {
            var cancelationToken = new CancellationTokenSource();
            var authViewModel =
                await
                    apiProvider.MakeRequest(
                        ct => apiProvider.UsersApi.Login(new UserAuthorizationViewModel { UserName = userName }, ct),
                        cancelationToken.Token);
            return authViewModel;
        }


        private void LoadAuthorizationResult(UserAuthorizationViewModel model)
        {
            if (model == null)
            {
                AppSessionConfig.IsLoggedIn = false;
                return;
            }
            AppSessionConfig.LastAuthorizationAnswer = model.AuthorizationAnswer;
            AppSessionConfig.IsLoggedIn = model.AuthorizationAnswer == AuthorizationAnswer.Ok;
            AppSessionConfig.UserName = AppSessionConfig.IsLoggedIn ? model.UserName : null;
            AppSessionConfig.Token = AppSessionConfig.IsLoggedIn ? model.Token : null;
        }
    }
}