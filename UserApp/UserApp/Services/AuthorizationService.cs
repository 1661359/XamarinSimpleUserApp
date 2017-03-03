using System;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Services.ApiWrapper;
using UserApp.Shared.ViewModels;

namespace UserApp.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IApiProvider apiProvider;
        private readonly AppSessionConfig appSessionConfig;

        public AuthorizationService(IApiProvider apiProvider, AppSessionConfig appSessionConfig)
        {
            this.apiProvider = apiProvider;
            this.appSessionConfig = appSessionConfig;
        }

        public async Task Login(string userName)
        {
            var authViewModel = await GetUserAuthorizationViewModel(userName);
            if (authViewModel == null)
            {
                throw new Exception(AppResources.Message_ProblemWithConnection);
            }
            appSessionConfig.LoadAuthorizationResult(authViewModel);
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
    }
}