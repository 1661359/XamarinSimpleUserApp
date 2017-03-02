using System;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using UserApp.Shared.Models;

namespace UserApp.Services.ApiWrapper
{
    public interface IPlaceDetailsApi
    {
        [Get("/get")]
        Task<PlaceDetails> GetPlaceDetails(Guid id, CancellationToken ctx);
    }
}
