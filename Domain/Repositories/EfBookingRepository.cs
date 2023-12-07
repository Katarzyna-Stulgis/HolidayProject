using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class EfBookingRepository : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public EfBookingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Booking MakeBooking(Booking booking)
        {
            int numberOfNights = (int)(booking.EndDate - booking.StartDate).TotalDays;

            var property = _context.Properties
                .Include(p => p.BookedNights)
                .FirstOrDefault(p => p.PropertyId == booking.PropertyId);

            if (property == null || !IsPropertyAvailable(property, booking.StartDate, numberOfNights))
            {
                return null;
            }

            for (int i = 0; i <= numberOfNights; i++)
            {
                property.BookedNights.Add(new BookedNight { Night = booking.StartDate.AddDays(i) });
            }
            
            booking.property = property;

            _context.Bookings.Add(booking);

            _context.SaveChanges();

            return booking;
        }

        private bool IsPropertyAvailable(Property property, DateTime startDate, int numberOfNights)
        {
            var bookedDates = property.BookedNights.Select(bn => bn.Night);
            var targetDates = Enumerable.Range(0, numberOfNights).Select(offset => startDate.AddDays(offset));

            return !bookedDates.Intersect(targetDates).Any();
        }
    }
}