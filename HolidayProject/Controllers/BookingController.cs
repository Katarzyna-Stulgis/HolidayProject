using Domain.Entities;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HolidayProject.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
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
        public IActionResult SubmitBooking(int propertyId, DateTime startDate, DateTime endDate, string UserEmail, string BillingAddress)
        {
            var booking = new Booking
            {
                PropertyId = propertyId,
                StartDate = startDate,
                EndDate = endDate,
                UserEmail = UserEmail,
                BillingAddress = BillingAddress
            };

            var bk = _bookingRepository.MakeBooking(booking);

            if (bk != null)
            {
                return View("BookingSuccess", bk);
            }
            else
            {
                return View("BookingFailure");
            }


            return View();
        }
    }
}
