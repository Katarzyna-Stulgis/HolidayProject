using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<Property> properties = new List<Property>
            {
                new Property
                {
                    PropertyId = 1,
                    Name = "Rose Cottage",
                    Blurb = "Beautiful cottage on the Cornwall coast",
                    Location = "Cornwall",
                    NumberOfBedrooms = 3,
                    CostPerNight = 350,
                    Description = "Rose cottage has a wonderful sea view, being only a 5-minute walk from the beach and with access to many local amenities.",
                    BookedNights = new List<BookedNight>()
                },
                new Property
                {
                    PropertyId = 2,
                    Name = "Saffron House",
                    Blurb = "Stately home on the Devon moors",
                    Location = "Devon",
                    NumberOfBedrooms = 7,
                    CostPerNight = 730,
                    Description = "Whether it's for birthday gatherings or a family getaway, Saffron House has all the creature comforts you need.",
                    BookedNights = new List<BookedNight>()
                }
            };

            builder.Entity<Property>().HasData(properties);
        }
    }
}
