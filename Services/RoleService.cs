using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;
using Models.PropertyModel;
using Models.ViewModel;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RoleService : IRoleService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
        }
        public async Task<RoleDto> CreateRole(RoleDto roleDto)
        {
            return await _unitOfWork.RoleRepository.Create(roleDto);
        }

        public async Task<RoleDto?> GetById(int roleId)
        {
            return await _unitOfWork.RoleRepository.GetById(roleId);
        }

        public async Task<RoleDto?> GetByName(string roleName)
        {
            return await _unitOfWork.RoleRepository.GetByName(roleName);
        }

    }
}
