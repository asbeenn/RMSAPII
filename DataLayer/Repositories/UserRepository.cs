using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.PropertyModel;
using Models.ViewModel;
using System.Security.Cryptography.X509Certificates;

namespace DataLayer.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<bool> CreateUser( UserDto userDto)
        {
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);

            var user = new ApplicationUser
            {
                FirstName = userDto.FirstName,
                MiddleName = userDto.LastName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PhotoUrl = userDto.PhotoUrl,
                IDUrl = userDto.IDUrl,
                Country = userDto.Country,
                StreetAddress1 = userDto.StreetAddress1,
                StreetAddress2 = userDto.StreetAddress2,
                CitySuburbTown = userDto.CitySuburbTown,
                ZipCode = userDto.ZipCode,

            };
            var roleId = (int)Enum.Parse(typeof(Enums.RoleNames), userDto.RoleName);
            user.UserRoles = new List<UserRole>();
            user.UserRoles.Add(new UserRole
            {
                RoleId = roleId
            });

            // Add the user to the database
            _dbContext.ApplicationUsers.Add(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }



        public async Task<UserDto> GetUserById(int userId)
        {
            var userEntity = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.UserId == userId);

            if (userEntity == null)
                return null; // User not found

            // Map the user entity to UserDto
            return _mapper.Map<UserDto>(userEntity);
        }

        public async Task<UserDto?> GetByEmail(string email)
        {
            var user =  await _dbContext.ApplicationUsers.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (user != null)
                return _mapper.Map<UserDto>(user);
            return null;
        }

       
    }
}

