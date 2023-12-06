using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HolidayProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet]
        public IActionResult Create(int propertyId, DateTime startDate, DateTime endDate)
        {
            var model = new Booking
            {
                PropertyId = propertyId,
                StartDate = startDate,
                EndDate = endDate
            };

            return View("CreateBooking", model);
        }

        [HttpPost]
        public IActionResult SubmitBooking(Booking model)
        {
            var booking = _bookingRepository.MakeBooking(
                model.PropertyId,
                model.StartDate,
                model.EndDate,
                model.UserId,
                model.UserEmail,
                model.BillingAddress
            );

            if (booking != null)
            {
                return View("BookingSuccess", booking);
            }
            else
            {
                return View("BookingFailure");
            }
        }
    }
}
