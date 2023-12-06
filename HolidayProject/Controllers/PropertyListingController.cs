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
