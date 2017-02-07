using System.Threading;
using System.Threading.Tasks;
using Refit;
using UserApp.Shared.ViewModels;

namespace UserApp.Services.ApiWrapper
{
    [Headers("Accept: application/json")]
    public interface IUsersApi
    {
        [Post("/login")]
        Task<UserAuthorizationViewModel> Login([Body(BodySerializationMethod.UrlEncoded)] UserAuthorizationViewModel userAuthorizationViewModel, CancellationToken ctx);
    }
}
