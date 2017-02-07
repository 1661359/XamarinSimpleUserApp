using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Polly;
using Refit;

namespace UserApp.Services.ApiWrapper
{
    public class ApiProvider : IApiProvider
    {
        public IUsersApi UsersApi { get; }

        public ApiProvider()
        {
            UsersApi = RestService.For<IUsersApi>("http://192.168.168.2/userapi/users");
        }
        
        public async Task<T> MakeRequest<T>(Func<CancellationToken, Task<T>> loadingFunction, CancellationToken cancellationToken)
        {
            Exception exception = null;
            T result = default(T);

            try
            {
                result = await Policy.Handle<WebException>().Or<HttpRequestException>()
                    .WaitAndRetryAsync(3, i => TimeSpan.FromMilliseconds(500), (ex, span) => exception = ex)
                    .ExecuteAsync(loadingFunction, cancellationToken);
            }
            catch (Exception e)
            {
                exception = e;
            }           
            return result;
        }
    }
}
