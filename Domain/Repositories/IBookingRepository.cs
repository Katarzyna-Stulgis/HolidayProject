using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookingRepository
    {
        Booking MakeBooking(int propertyId, DateTime startDate, DateTime endDate, string userId, string userEmail, string billingAddress);
    }
}
