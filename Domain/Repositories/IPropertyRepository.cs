using Domain.Entities;

namespace Domain.Repositories
{
    public interface IPropertyRepository
    {
        IEnumerable<Property> GetAllProperties();
        void AddProperty(Property property);
    }
}
