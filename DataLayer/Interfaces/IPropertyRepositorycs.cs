using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IPropertyRepository
    {
        Task<PropertyDto> GetPropertyById(int id);
        Task<List<PropertyDto>> GetAllProperty();
        Task<PropertyDto> AddProperty(PropertyDto property);
        Task<PropertyDto> UpdateProperty(int propertyId, UpdatePropertyDto updatePropertyDto);
        Task<List<PropertyDto>> GetPropertiesByUserId(int userId);

    }
}
