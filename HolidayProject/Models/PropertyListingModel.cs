namespace HolidayProject.Models
{
    public class PropertyListingModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Blurb { get; set; }
        public string Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal CostPerNight { get; set; }

        public IEnumerable<string> Images { get; set; }

        public PropertyListingModel()
        {
            Images = Enumerable.Range(1, 3)
                .Select(i => $"https://picsum.photos/200/300?random={i}")
                .ToList();
        }
    }
}
