using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserApp.Shared.Models;

namespace UserApp.Services
{
    public interface IPlaceService
    {
        Task<IEnumerable<Place>> GetPlaces();
        Task<PlaceDetails> GetPlaceDetails(Guid id);
    }
}
