using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using UserApp.Shared.ViewModels;

namespace UserApp.Services.ApiWrapper
{
    public interface IUsersApi
    {
        [Post("/login")]
        Task<UserAuthorizationViewModel> Login([Body(BodySerializationMethod.UrlEncoded)] string userName, CancellationToken ctx);
    }
}
