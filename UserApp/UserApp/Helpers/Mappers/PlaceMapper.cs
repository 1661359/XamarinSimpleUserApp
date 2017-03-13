using System;
using System.Linq;
using AutoMapper;
using UserApp.Shared.Models;
using UserApp.Shared.ViewModels;

namespace UserApp.Helpers.Mappers
{
    public static class PlaceMapper
    {
        public static void CreateMap()
        {
            Mapper.CreateMap<Place, PlaceViewModel>();
        }

        public static PlaceViewModel MapToPlaceViewModel(Place place)
        {
            var result = Mapper.Map<PlaceViewModel>(place);
            MapWorkingTime(place, result);
            return result;
        }


        private static void MapWorkingTime(Place place, PlaceViewModel result)
        {
            var currentDay = DateTime.Now.DayOfWeek;
            var workingTime = place.WorkDays?.FirstOrDefault(m => m.DayOfWeek == currentDay);
            result.WorkingTimeToday = workingTime == null
                ? "Not working today"
                : $"{workingTime.StartTime} - {workingTime.EndTime}";
        }
    }
}
