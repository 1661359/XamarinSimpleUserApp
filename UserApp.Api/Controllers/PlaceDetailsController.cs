using System;
using System.Collections.Generic;
using System.Web.Http;
using UserApp.Shared.Models;

namespace UserApp.Api.Controllers
{
    public class PlaceDetailsController : ApiController
    {
        [HttpGet]
        public PlaceDetails Get(Guid id)
        {
            return new PlaceDetails()
            {
                Address = "1 N. Cactus Ave.Green Bay,WI 54302",
                AverageCost = 2.2,
                Description =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex",
                Id = id,
                Name = "Where can I get some",
                PhoneNumber = "(283) 843-9772",
                PicturesUrls = new List<string> {"http://netdna.webdesignerdepot.com/uploads/2013/12/featured5.jpg"},
                Text =
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna",
                WorkDays = new List<WorkingTime>
                {
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Monday,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Tuesday,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Wednesday,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Thursday,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Friday,
                        StartTime = new TimeSpan(8, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Saturday,
                        StartTime = new TimeSpan(10, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },
                    new WorkingTime
                    {
                        DayOfWeek = DayOfWeek.Sunday,
                        StartTime = new TimeSpan(10, 0, 0),
                        EndTime = new TimeSpan(16, 0, 0)
                    },

                }
            };
        }

    }
}
