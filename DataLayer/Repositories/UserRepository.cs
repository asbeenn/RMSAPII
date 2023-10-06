using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;
        public UserRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
        }

        public async Task<UserViewModel> CreateUser(UserViewModel model)
        {

            //var passwordHash = HashPassword(model.Password);
            var entity = new User
            {
                UserId=Guid.NewGuid().ToString(),
                Email = model.Email,
                
                PasswordHash = model.Password,
                
                PhoneNumber = model.PhoneNumber,
                
                CitySuburbTown = model.CitySuburbTown,
                Country = model.Country,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhotoUrl = model.PhotoUrl,
                StreetAddress1 = model.StreetAddress1,
                StreetAddress2 = model.StreetAddress2,
                ZipCode = model.ZipCode,
            };
            await DBContext.Users.AddAsync(entity);
            DBContext.SaveChanges();
            return model;

        }
    }
}
