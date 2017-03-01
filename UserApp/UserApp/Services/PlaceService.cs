using System.Collections.Generic;
using UserApp.Shared.Models;

namespace UserApp.Services
{
    public class PlaceService : IPlaceService
    {
        public IEnumerable<Place> GetPlaces()
        {
            return new List<Place>
            {
                new Place() {Name = "1", AverageCost = 3, Address = "Some Address"},
                new Place() {Name = "2", AverageCost = 3, Address = "Some Address"},
                new Place() {Name = "3", AverageCost = 3, Address = "Some Address"},
                new Place() {Name = "5", AverageCost = 3, Address = "Some Address"},
                new Place() {Name = "6", AverageCost = 3, Address = "Some Address"},
                new Place() {Name = "4", AverageCost = 3, Address = "Some Address"},
                new Place() {Name = "7", AverageCost = 3, Address = "Some Address"}
            };
        }

        public PlaceDetails GetPlaceDetails(string productName)
        {
            return new PlaceDetails() { Name = productName };
        }
    }
}
