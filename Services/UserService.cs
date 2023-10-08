using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;
using Models.ViewModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateUser(UserDto userDto)
        {
            return await _unitOfWork.UserRepository.CreateUser(userDto);
        }

        public async Task<UserDto> GetUserById(int userId)
        {
            return await _unitOfWork.UserRepository.GetUserById(userId);
        }

        public async Task<ApplicationUser> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = _mapper.Map<ApplicationUser>(userLoginDto);
            var founduser = await _unitOfWork.UserRepository.LoginUserAsync(user);
            return founduser;
        }

        //public async Task<ApplicationUser> Login(string email, string password)
        //{
        //    return await _unitOfWork.UserRepository.Login(email,password);
        //}
    }
}
