using DataLayer.Entities;
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
            Task<UserDto> GetUserById(int userId);
            Task<ApplicationUser> LoginUserAsync(UserLoginDto userLoginDto);
    }
    
}
