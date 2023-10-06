using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyDto> GetPropertyById(int id);
        Task<PropertyDto> AddProperty(PropertyDto model);
    }
}
