using HolidayProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class PropertyManagementController : Controller
    {
        public IActionResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProperty(PropertyDetailsModel propertyDetails)
        {

            return RedirectToAction("ListAll", "PropertyListing");
        }
    }
}
