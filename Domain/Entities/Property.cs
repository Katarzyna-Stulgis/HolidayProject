﻿namespace Domain.Entities
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Blurb { get; set; }
        public string Location { get; set; }
        public int NumberOfBedrooms { get; set; }
        public decimal CostPerNight { get; set; }
        public string Description { get; set; }
        public string? Amenities { get; set; }
        public List<BookedNight> BookedNights { get; set; }
        public List<PropertyImage> Images { get; set; } = new List<PropertyImage>();
    }
}
