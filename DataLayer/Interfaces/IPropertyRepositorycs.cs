﻿using DataLayer.Entities;
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
        Task<GetPropertyDto> GetPropertyById(int id);
        Task<List<GetPropertyDto>> GetAllProperty();
        Task<bool> AddProperty(Property property);
        Task<PropertyDto> UpdateProperty( UpdatePropertyDto updatePropertyDto);
        Task<List<PropertyDto>> GetPropertiesByUserId(int userId);
        
    }
}
