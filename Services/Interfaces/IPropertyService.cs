using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPropertyService
    {
        Task<List<PropertyDto>> GetAllProperty();
        Task<PropertyDto> GetPropertyById(int id);
        Task<PropertyDto> AddProperty(PropertyDto model);
        Task<PropertyDto> UpdateProperty(int propertyId, UpdatePropertyDto updatePropertyDto);
        Task<List<PropertyDto>> GetPropertiesByUserId(int userId);
    }
}
