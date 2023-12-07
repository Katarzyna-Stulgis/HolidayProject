using AutoMapper;
using Domain.Repositories;
using HolidayProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyListingController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        public IActionResult ListAll()
        {
            var list = _mapper.Map<IEnumerable<PropertyListingModel>>(_propertyRepository.GetAllProperties());
            return View("ListProperties", list);
        }

        public IActionResult ListAvailable(DateTime StartDate, DateTime EndDate)
        {
            var availableProperties = _propertyRepository
                .GetAllProperties()
                .Where(
                    property => property.BookedNights == null ||
                    !property.BookedNights.Any(
                        bookedDate =>
                            (StartDate <= bookedDate.Night && bookedDate.Night <= EndDate) ||
                            (bookedDate.Night <= StartDate && EndDate <= bookedDate.Night)))
                 .ToList();

            var list = _mapper.Map<IEnumerable<PropertyListingModel>>(availableProperties);

            return View("ListProperties", list);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var propertyDetails = _propertyRepository
                .GetAllProperties()
                .FirstOrDefault(p => p.PropertyId == id);

            if (propertyDetails == null)
            {
                return NotFound();
            }

            return View("PropertyDetails", propertyDetails);
        }
    }
}
