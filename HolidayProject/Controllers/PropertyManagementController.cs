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
        private readonly IWebHostEnvironment _environment;


        public PropertyManagementController(IPropertyRepository propertyRepository, IMapper mapper, IWebHostEnvironment environment)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _environment = environment;
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

        [HttpGet]
        public IActionResult AddImage(int id)
        {
            var addImageModel = new AddImageModel { PropertyId = id };
            return View(addImageModel);
        }

        [HttpPost]
        public IActionResult UploadImage(AddImageModel model)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(model.Image.FileName)}";

            var urlPath = $"/images/{fileName}";
            var filePath = $"{_environment.ContentRootPath}/wwwroot{urlPath}";
            using (var stream = System.IO.File.Create(filePath))
            {
                model.Image.CopyTo(stream);
            }

            _propertyRepository.AddPropertyImage(model.PropertyId, urlPath);

            return RedirectToAction("ListAll", "PropertyListing");
        }

    }
}
