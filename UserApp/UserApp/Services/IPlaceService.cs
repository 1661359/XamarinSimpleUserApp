using System.Collections.Generic;
using UserApp.Shared.Models;

namespace UserApp.Services
{
    public interface IPlaceService
    {
        IEnumerable<Place> GetPlaces();
        PlaceDetails GetPlaceDetails(string placeName);
    }
}
