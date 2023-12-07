namespace Domain.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int PropertyId { get; set; }
        public decimal CostPerNight { get; set; }
        public string? UserId { get; set; }
        public string UserEmail { get; set; }
        public string BillingAddress { get; set; }

        public Property property { get; set; }
    }
}