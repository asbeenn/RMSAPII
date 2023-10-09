using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.PropertyModel;
using Models.ViewModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateUser(UserRegisterDto userDto)
        {
            return await _unitOfWork.UserRepository.CreateUser(userDto);
        }

        public async Task<UserDto?> GetByEmail(string email)
        {
            return await _unitOfWork.UserRepository.GetByEmail(email);
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            return await _unitOfWork.UserRepository.GetUserById(userId);
        }

        public async Task<UserDto?> ValidateUser(UserDto userDto, string userPassword)
        {
            string userPasswordHash = await Task.FromResult(BCrypt.Net.BCrypt.HashPassword(userPassword));
            if (!BCrypt.Net.BCrypt.Verify(userDto.Password, userPasswordHash))
                return null;
            return userDto;
        }

        public async Task<List<RoleDto>?> GetUserRolesByUserId(int userId)
        {
            var userRoles = await _unitOfWork.UserRoleRepository.GetUserRolesByUserId(userId);
            return userRoles;
        }

        public async Task<object> GenerateJwtToken(UserDto user)
        {
            IList<RoleDto> userRoles = await GetUserRolesByUserId(user.UserId);

            var roleNames = userRoles.Select(role => role.RoleName);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role,string.Join(",", roleNames)),
                new Claim("UserId", user.UserId.ToString()),
                new Claim("FirstName", user.FirstName?? ""),
                new Claim("MiddleName", user.MiddleName?? ""),
                new Claim("LastName", user.LastName?? ""),
                //new Claim("Roles", string.Join(",", roleNames))
            };
            //if (userRoles != null)
            //    claims.Add(new Claim("Roles", string.Join(",", userRoles)));


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JwtKey));
            var key_phrase = _appSettings.JwtKey;
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_appSettings.JwtExpireDays));
            var token = new JwtSecurityToken(
                _appSettings.JwtIssuer,
                _appSettings.JwtAudience,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            //try
            //{
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var jwt = jwtSecurityTokenHandler.WriteToken(token);
            return jwt;
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }

    }
}
