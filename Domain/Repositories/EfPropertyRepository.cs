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
            return _dbContext.Properties.Include(p => p.BookedNights).ToList();
        }

        public IEnumerable<Property> GetAvailableProperties(DateTime startDate, DateTime endDate)
        {
            return _dbContext.Properties
                .Include(p => p.BookedNights)
                .Where(p => !p.BookedNights.Any(bn => bn.Night >= startDate && bn.Night <= endDate))
                .ToList();
        }

        public void AddProperty(Property property)
        {
            _dbContext.Properties.Add(property);
            _dbContext.SaveChanges();
        }
    }
}
