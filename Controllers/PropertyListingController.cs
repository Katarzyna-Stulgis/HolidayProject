using HolidayProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private List<PropertyDetailsModel> properties = new List<PropertyDetailsModel>
        {
            new PropertyDetailsModel
            {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350,
                Description = "A charming cottage with stunning views.",
                Amenities = "WiFi",
                BookedDates = new List<DateTime> { DateTime.Now.AddDays(5), DateTime.Now.AddDays(10) }
            },
            new PropertyDetailsModel
            {
                Id = 2,
                Name = "Saffron House",
                Blurb = "Stately home on the Devon moors",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730,
                Description = "A grand stately home with luxurious amenities.",
                Amenities = "Pool",
                BookedDates = new List<DateTime> { DateTime.Now.AddDays(8), DateTime.Now.AddDays(15) }
            }
        };

        public IActionResult ListAll()
        {
            return View("ListProperties", properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            var availableProperties = properties
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
            var propertyDetails = properties.FirstOrDefault(p => p.Id == id);

            if (propertyDetails == null)
            {
                return NotFound();
            }

            return View("PropertyDetails", propertyDetails);
        }
    }
}
