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
                Amenities = new List<string> { "WiFi", "Parking", "Garden" },
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
                Amenities = new List<string> { "Pool", "Tennis Court", "Sauna" },
                BookedDates = new List<DateTime> { DateTime.Now.AddDays(8), DateTime.Now.AddDays(15) }
            }
        };

        public IActionResult ListAll()
        {
            return View("ListProperties", properties);
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            return View("ListProperties", properties);
        }

        [HttpGet]
        public IActionResult ViewPropertyDetails([FromRoute] int id)
        {
            return View();
        }
    }
}
