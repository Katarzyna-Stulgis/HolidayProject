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
                    property => property.BookedDates == null ||
                    !property.BookedDates.Any(
                        bookedDate =>
                            (start <= bookedDate && bookedDate <= end) ||
                            (bookedDate <= start && end <= bookedDate)))
                 .ToList();

            return View("ListProperties", availableProperties);
        }

        public IActionResult ViewPropertyDetails(int id)
        {
            var propertyDetails = _propertyRepository
                .GetAllProperties()
                .FirstOrDefault(p => p.Id == id);

            if (propertyDetails == null)
            {
                return NotFound();
            }

            return View("PropertyDetails", propertyDetails);
        }
    }
}
