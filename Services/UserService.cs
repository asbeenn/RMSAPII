//using Common;
//using DataLayer.Interfaces;
//using Microsoft.Extensions.Options;
//using Models.Property;
//using Models.ViewModel;
//using Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Services
//{
//    public class UserService : IUserService
//    {
//        private readonly AppSettings _appSettings;
//        private readonly IUnitOfWork _unitOfWork;
//        public UserService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
//        {
//            _appSettings = appSettings.Value;
//            _unitOfWork = unitOfWork;
//        }

//        public async Task<UserViewModel> CreateUser(UserViewModel model)
//        {
//            return await _unitOfWork.UserRepository.CreateUser(model);
//        }
//    }
//}