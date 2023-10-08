using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.PropertyModel;
using Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class RoleRepository : RepositoryBase, IRoleRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoleRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<RoleDto> Create(RoleDto model)
        {
            Role _role = new Role { RoleName = model.RoleName };
            await _dbContext.Roles.AddAsync(_role);
            await _dbContext.SaveChangesAsync();
            model.RoleId = _role.RoleId;
            return model;
        }
        
        public async Task<RoleDto?> GetById(int roleId)
        {
            var role = await _dbContext.Roles.Where(x => x.RoleId == roleId).FirstOrDefaultAsync();
            if(role != null)
                return new RoleDto { RoleId = role.RoleId, RoleName = role.RoleName };
            return null;
        }

        public async Task<RoleDto?> GetByName(string roleName)
        {
            var role = await _dbContext.Roles.Where(x=>x.RoleName == roleName).FirstOrDefaultAsync();
            if(role != null)
                return new RoleDto { RoleId = role.RoleId, RoleName = role.RoleName };
            return null;
        }
    }
}
