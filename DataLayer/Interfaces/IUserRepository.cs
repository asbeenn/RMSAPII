using DataLayer.Entities;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateUser(UserRegisterDto model);
        Task<UserDto> GetUserById(int userId);
        Task<UserDto?> GetByEmail(string email);
    }
}

