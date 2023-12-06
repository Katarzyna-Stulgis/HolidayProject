using HolidayProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class PropertyListingController : Controller
    {
        private List<PropertyListingModel> properties = new List<PropertyListingModel>
        {
            new PropertyListingModel
            {
                Id = 1,
                Name = "Rose Cottage",
                Blurb = "Beautiful cottage on the Cornwall coast",
                Location = "Cornwall",
                NumberOfBedrooms = 3,
                CostPerNight = 350
            },
            new PropertyListingModel
            {
                Id = 2,
                Name = "Saffron House",
                Blurb = "Stately home on the Devon moors",
                Location = "Devon",
                NumberOfBedrooms = 7,
                CostPerNight = 730
            }
        };

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAll()
        {
            return View();
        }

        public IActionResult ListAvailable(DateTime start, DateTime end)
        {
            return View();
        }
    }
}
