using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyListingController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public IActionResult ListAll()
        {
            return View("ListProperties", _propertyRepository.GetAllProperties());
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = _propertyRepository
                .GetAllProperties()
                .Where(
                    property => property.BookedNights == null ||
                    !property.BookedNights.Any(
                        bookedDate =>
                            (start <= bookedDate.Night && bookedDate.Night <= end) ||
                            (bookedDate.Night <= start && end <= bookedDate.Night)))
                 .ToList();

            return View("ListProperties", availableProperties);
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
