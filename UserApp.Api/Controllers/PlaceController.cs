using System;
using System.Collections.Generic;
using System.Web.Http;
using UserApp.Shared.Models;

namespace UserApp.Api.Controllers
{
    public class PlaceController : ApiController
    {
        [HttpGet]
        public IEnumerable<Place> GetAll()
        {
            return new List<Place>
            {
                new Place() {Name = "1", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()},
                new Place() {Name = "2", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()},
                new Place() {Name = "3", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()},
                new Place() {Name = "5", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()},
                new Place() {Name = "6", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()},
                new Place() {Name = "4", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()},
                new Place() {Name = "7", AverageCost = 3, Address = "Some Address", Id = Guid.NewGuid()}
            };
        }     
    }
}
