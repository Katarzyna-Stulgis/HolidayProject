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

        public Booking MakeBooking(int propertyId, DateTime startDate, DateTime endDate, string userId, string userEmail, string billingAddress)
        {
            int numberOfNights = (int)(endDate - startDate).TotalDays;

            var property = _context.Properties
                .Include(p => p.BookedNights)
                .FirstOrDefault(p => p.PropertyId == propertyId);

            if (property == null || !IsPropertyAvailable(property, startDate, numberOfNights))
            {
                return null;
            }

            for (int i = 0; i < numberOfNights; i++)
            {
                property.BookedNights.Add(new BookedNight { Night = startDate.AddDays(i) });
            }

            var booking = new Booking
            {
                StartDate = startDate,
                EndDate = endDate,
                CostPerNight = property.CostPerNight,
                UserId = userId,
                UserEmail = userEmail,
                BillingAddress = billingAddress
            };

            _context.Bookings.Add(booking);

            _context.SaveChangesAsync();

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