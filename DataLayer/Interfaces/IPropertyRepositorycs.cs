using Models.Property;
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
        Task<PropertyDto> AddProperty(PropertyDto property);
    }
}
