using DataLayer.Entities;
using Models.PropertyModel;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> CreateUser(UserDto model);
        Task<UserDto?> GetByEmail(string email);
        Task<UserDto> GetUserById(int userId);
        Task<UserDto?> ValidateUser(UserDto user, string userPassword);
        Task<List<RoleDto>?> GetUserRolesByUserId(int userId);
        Task<object> GenerateJwtToken( UserDto user);


    }
    
}
