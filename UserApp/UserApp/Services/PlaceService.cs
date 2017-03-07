using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UserApp.Services.ApiWrapper;
using UserApp.Shared.Models;

namespace UserApp.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IApiProvider apiProvider;
        public PlaceService(IApiProvider apiProvider)
        {
            this.apiProvider = apiProvider;
        }
        public async Task<IEnumerable<Place>> GetPlaces(Place queryParameter)
        {
            var cancelationToken = new CancellationTokenSource();
            return await apiProvider.MakeRequest(ct => apiProvider.PlaceApi.GetAll(queryParameter, ct), cancelationToken.Token);
        }

        public async Task<PlaceDetails> GetPlaceDetails(Guid id)
        {
            var cancelationToken = new CancellationTokenSource();
            return await apiProvider.MakeRequest(ct => apiProvider.PlaceDetailsApi.GetPlaceDetails(id, ct), cancelationToken.Token);
        }
    }
}
