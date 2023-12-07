using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBookingRepository
    {
        Booking MakeBooking(Booking booking);
    }
}
