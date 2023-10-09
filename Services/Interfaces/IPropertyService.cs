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
        Task<List<GetPropertyDto>> GetAllProperty();
        Task<GetPropertyDto> GetPropertyById(int id);
        Task<bool> AddProperty(PropertyDto propertyDto);
        Task<PropertyDto> UpdateProperty(int propertyId, UpdatePropertyDto updatePropertyDto);
        Task<List<PropertyDto>> GetPropertiesByUserId(int userId);
    }
}
