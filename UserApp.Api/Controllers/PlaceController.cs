using System;
using System.Collections.Generic;
using System.Web.Http;
using UserApp.Shared.Models;

namespace UserApp.Api.Controllers
{
    public class PlaceController : ApiController
    {
        [HttpPost]
        public IEnumerable<Place> GetAll([FromBody]Place queryParameter)
        {
            var places = new List<Place>
            {
                new Place() {Name = "1", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "1"},
                new Place() {Name = "2", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "1"},
                new Place() {Name = "3", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "2"},
                new Place() {Name = "5", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "2"},
                new Place() {Name = "6", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "3"},
                new Place() {Name = "4", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "3"},
                new Place() {Name = "7", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid(), ZipCode = "3"}
            };
            if (queryParameter != null)
            {
                return places.FindAll(p => p.ZipCode.Contains(queryParameter.ZipCode ?? string.Empty));
            }
            return places;
        }
    }
}
