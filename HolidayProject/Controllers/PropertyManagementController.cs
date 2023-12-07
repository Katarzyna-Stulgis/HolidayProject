using AutoMapper;
using Domain.Entities;
using Domain.Repositories;
using HolidayProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class PropertyManagementController : Controller
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;


        public PropertyManagementController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }
        public IActionResult AddProperty()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProperty(PropertyDetailsModel propertyDetails)
        {
            var property = _mapper.Map<Property>(propertyDetails);
            _propertyRepository.AddProperty(property);
            return RedirectToAction("ListAll", "PropertyListing");
        }
    }
}
