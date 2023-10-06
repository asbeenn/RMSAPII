using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;
using Models.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class PropertyRepository : RepositoryBase, IPropertyRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;

        public PropertyRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task<PropertyDto?> GetPropertyById(int id)
        {
            var property = await DBContext.Properties.FindAsync(id);
            if (property != null)
            {
                return new PropertyDto
                {
                    PropertyId = property.PropertyId,
                    PropertyName = property.PropertyName,
                    UserId = property.UserId,
                    Country = property.Country,
                    StreetAddress = property.StreetAddress,
                    StreetAddress2 = property.StreetAddress2,
                    CitySuburbTown = property.CitySuburbTown,
                    StateProvienceRegion = property.StateProvienceRegion,
                    ZipPostalCode = property.ZipPostalCode,
                    PropertyType = property.PropertyType
                };
            }
            return null;
        }

        public async Task<PropertyDto> AddProperty(PropertyDto model)
        {
            var entity = new DataLayer.Entities.Property
            {
                PropertyName = model.PropertyName,
                UserId = model.UserId,
                Country = model.Country,
                StreetAddress = model.StreetAddress,
                StreetAddress2 = model.StreetAddress2,
                CitySuburbTown = model.CitySuburbTown,
                StateProvienceRegion = model.StateProvienceRegion,
                ZipPostalCode = model.ZipPostalCode,
                PropertyType = model.PropertyType,
            };
            await DBContext.Properties.AddAsync(entity);
            DBContext.SaveChanges();
            model.PropertyId = entity.PropertyId;
            return model;

        }
    }
}
