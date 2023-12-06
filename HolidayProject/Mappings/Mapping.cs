using AutoMapper;
using Domain.Entities;
using HolidayProject.Models;

namespace HolidayProject.Mappings
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Property, PropertyListingModel>().ReverseMap();
            CreateMap<BookedNight, PropertyDetailsModel>().ReverseMap();
        }
    }
}
