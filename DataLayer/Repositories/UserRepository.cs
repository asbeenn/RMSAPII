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

            // Check if a user with the same email already exists
            var existingUser = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.Email == userDto.Email);

            if (existingUser != null)
            {
                return false; //BadRequest( "User with this email already exists" );
            }

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

            // Add the user to the database
            _dbContext.ApplicationUsers.Add(user);
            await _dbContext.SaveChangesAsync();

            // Return a success response
            return true;
        }



        public async Task<UserDto> GetUserById(int userId)
        {
            var userEntity = await _dbContext.ApplicationUsers.FirstOrDefaultAsync(u => u.UserId == userId);

            if (userEntity == null)
            {
                return null; // User not found
            }

            // Map the user entity to UserDto
            return _mapper.Map<UserDto>(userEntity);
        }



        //public Task<ApplicationUser> Login(UserDto userDto)
        //{
        //    string passwordHash = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        //    // Find a user with the given email
        //    var user =  _dbContext.ApplicationUsers
        //        .FirstOrDefault(u => u.Email == userDto.Email);

        //    if (user == null)
        //    {
        //        // User with the given email doesn't exist
        //        return null;
        //    }

        //    // Validate the password (you need to implement password hashing)
        //    if (!BCrypt.Net.BCrypt.Verify(userDto.Password, user.PasswordHash))
        //        return BadRequest("Username or password incorrect.");

            

        //    return Ok(new { token });
        //}

       
        //{
        //    throw new NotImplementedException();
        //}
    }
}
