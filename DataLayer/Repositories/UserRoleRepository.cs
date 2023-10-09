using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class UserRoleRepository : RepositoryBase, IUserRoleRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;
        private readonly IMapper _mapper;

        public UserRoleRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<RoleDto?>> GetUserRolesByUserId(int userId)
        {
            var userRoles = await _dbContext.UserRoles.Where(x => x.UserId == userId).ToListAsync();

            if (userRoles != null)
            {
                List<int> roleIds = userRoles.Select(x => (int)x.RoleId).ToList<int>();
                var userRoleNames = await _dbContext.Roles.Where(x => roleIds.Contains(x.RoleId)).ToListAsync();
               // var userRoleNames = await _dbContext.Roles.Where(x => x.RoleId == 1).ToListAsync();
                return _mapper.Map<List<RoleDto>>(userRoleNames);
            }
            return null;
        } 


    }
}
