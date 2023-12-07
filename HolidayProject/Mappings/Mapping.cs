using AutoMapper;
using Domain.Entities;
using HolidayProject.Models;

namespace HolidayProject.Mappings
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<PropertyListingModel,Property >().ReverseMap();
            CreateMap<PropertyDetailsModel,Property> ().ReverseMap();
            CreateMap<BookedNight, PropertyDetailsModel>().ReverseMap();
        }
    }
}
