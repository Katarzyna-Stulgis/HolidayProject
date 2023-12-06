namespace Domain.Entities
{
    public class BookedNight
    {
        public int BookedNightId { get; set; }
        public int PropertyId { get; set; }
        public DateTime Night { get; set; }
    }
}
