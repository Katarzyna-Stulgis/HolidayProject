using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class EfPropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EfPropertyRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Property> GetAllProperties()
        {
            return _dbContext.Properties
                .Include(p => p.BookedNights)
                .Include(p => p.Images)
                .ToList();
        }

        public IEnumerable<Property> GetAvailableProperties(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Properties
                .Include(p => p.BookedNights)
                .Include(p => p.Images)
                .Where(p => !p.BookedNights.Any(bn => bn.Night >= startDate && bn.Night <= endDate))
                .ToList();
        }

        public void AddProperty(Property property)
        {
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();
        }

        public void AddPropertyImage(int propertyId, string imageUrl)
        {
            var property = _dbContext.Properties.Include(p => p.Images).FirstOrDefault(p => p.PropertyId == propertyId);

            if (property != null)
            {
                var propertyImage = new PropertyImage
                {
                    Property = property,
                    ImageUrl = imageUrl
                };

                property.Images.Add(propertyImage);
                _dbContext.SaveChanges();
            }
        }
    }
}
