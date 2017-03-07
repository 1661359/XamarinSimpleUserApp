using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Refit;
using UserApp.Shared.Models;

namespace UserApp.Services.ApiWrapper
{
    public interface IPlaceApi
    {
        [Post("/getall")]
        Task<IEnumerable<Place>> GetAll([Body]Place queryParameter, CancellationToken ctx);
    }
}
