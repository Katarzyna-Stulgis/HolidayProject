using AutoMapper;
using Domain.Entities;
using HolidayProject.Models;

namespace HolidayProject.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<PropertyListingModel, Property>()
                 .ForMember(dest => dest.PropertyId, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();
            CreateMap<PropertyDetailsModel, Property>()
                 .ForMember(dest => dest.Images, opt => opt.Ignore())
                 .ReverseMap();
            CreateMap<BookedNight, PropertyDetailsModel>().ReverseMap();
        }
    }
}
