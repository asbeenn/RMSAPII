﻿using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PropertyRepository : RepositoryBase, IPropertyRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;
        private readonly IMapper _mapper;

        public PropertyRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<GetPropertyDto?> GetPropertyById(int id)
        {
            var property = await DBContext.Properties.FindAsync(id);
            if (property != null)
            {
                return _mapper.Map<GetPropertyDto>(property);
            }
            return null;
        }

        public async Task<bool> AddProperty(Property property)
        {
            await DBContext.Properties.AddAsync(property);
            DBContext.SaveChanges();
            return true;
        }

        public async Task<List<GetPropertyDto>> GetAllProperty()
        {
            var properties = await _dbContext.Properties.ToListAsync();
            // Use AutoMapper to map the list of entities to a list of PropertyDto
            var propertyDtoList = _mapper.Map<List<GetPropertyDto>>(properties);
            return propertyDtoList;
        }

        public async Task<PropertyDto> UpdateProperty(UpdatePropertyDto updatePropertyDto)
        {

            var property = await _dbContext.Properties.FindAsync(updatePropertyDto.propertyId);
            if (property == null)
            {
                return null;
            }
            // Use AutoMapper to map properties from `updatePropertyDto` to `property`
            //_mapper.Map(updatePropertyDto, property);
            property.PropertyType = updatePropertyDto.PropertyType;
            property.StreetAddress = updatePropertyDto.StreetAddress;
            property.StreetAddress2 = updatePropertyDto.StreetAddress2;
            property.CitySuburbTown = updatePropertyDto.CitySuburbTown;
            property.Country = updatePropertyDto.Country;
            property.StateProvienceRegion = updatePropertyDto.StateProvienceRegion;
            property.ZipPostalCode = updatePropertyDto.ZipPostalCode;
            property.PropertyName = updatePropertyDto.PropertyName;
            property.RentCost = updatePropertyDto.RentCost;
            DBContext.SaveChanges();

            // Use AutoMapper to map the updated `property` to a `PropertyDto`
            var updatedPropertyDto = _mapper.Map<PropertyDto>(property);
            return updatedPropertyDto;
        }

        public async Task<List<PropertyDto>> GetPropertiesByUserId(int userId)
        {
            var properties = await _dbContext.Properties
            .Where(p => p.UserId == userId)
            .Select(p => new PropertyDto
            {
                PropertyId = p.PropertyId,
                PropertyName = p.PropertyName,
                StreetAddress = p.StreetAddress,
                StreetAddress2 = p.StreetAddress2,
                PropertyImageUrl = p.PropertyImage??"",
                Country = p.Country,
                RentCost = p.RentCost
            })
            .ToListAsync();

            return properties;
        }



    }
}

