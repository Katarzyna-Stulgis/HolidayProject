using Domain.Entities;

namespace Domain.Repositories
{
    public class DummyPropertyRepository : IPropertyRepository
    {
        private List<Property> properties;

        public DummyPropertyRepository()
        {
            properties = new List<Property>
            {
                new Property
                {
                    Id = 1,
                    Name = "Rose Cottage",
                    Blurb = "Beautiful cottage on the Cornwall coast",
                    Location = "Cornwall",
                    NumberOfBedrooms = 3,
                    CostPerNight = 350,
                    Description = "A charming cottage with stunning views.",
                    Amenities = "WiFi",
                    BookedDates = new List<DateTime> { DateTime.Now.AddDays(5), DateTime.Now.AddDays(10) }
                },
                new Property
                {
                    Id = 2,
                    Name = "Saffron House",
                    Blurb = "Stately home on the Devon moors",
                    Location = "Devon",
                    NumberOfBedrooms = 7,
                    CostPerNight = 730,
                    Description = "A grand stately home with luxurious amenities.",
                    Amenities = "Pool",
                    BookedDates = new List<DateTime> { DateTime.Now.AddDays(8), DateTime.Now.AddDays(15) }
                }
            };
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return properties;
        }

        public void AddProperty(Property property)
        {
            properties.Add(property);
        }
    }
}