namespace HolidayProject.Models
{
    public class PropertyDetailsModel : PropertyListingModel
    {
        public string Description { get; set; }
        public string Amenities { get; set; }
        public List<DateTime> BookedDates { get; set; }
    }
}
