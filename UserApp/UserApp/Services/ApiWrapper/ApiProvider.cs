using System;
using System.Diagnostics;
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
        private const string ApiHostUrl = "http://192.168.168.2/userapi/";

        public IUsersApi UsersApi { get; }
        public IPlaceApi PlaceApi { get; }
        public IPlaceDetailsApi PlaceDetailsApi { get; }

        public ApiProvider()
        {
            UsersApi = RestService.For<IUsersApi>(GetApiUrl("users"));
            PlaceApi = RestService.For<IPlaceApi>(GetApiUrl("place"));
            PlaceDetailsApi = RestService.For<IPlaceDetailsApi>(GetApiUrl("placedetails"));
        }

        private static string GetApiUrl(string api)
        {
            return ApiHostUrl + api;
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
            if (exception != null)
            {
                Debug.WriteLine(exception.Message);
            }           
            return result;
        }

    }
}
