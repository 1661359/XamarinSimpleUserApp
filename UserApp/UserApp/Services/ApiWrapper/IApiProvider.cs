using System;
using System.Threading;
using System.Threading.Tasks;

namespace UserApp.Services.ApiWrapper
{
    public interface IApiProvider
    {
        IUsersApi UsersApi
        {
            get;
        }

        Task<T> MakeRequest<T>(Func<CancellationToken, Task<T>> loadingFunction,
            CancellationToken cancellationToken);
    }
}
