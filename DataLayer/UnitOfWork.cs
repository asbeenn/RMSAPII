using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(RMSDbContext _dbContext, IOptions<AppSettings> _appSettings, IMapper _mapper)
        {
            PropertyRepository = new PropertyRepository(_appSettings, _dbContext, this, _mapper);
            UserRepository = new UserRepository(_appSettings, _dbContext, this, _mapper);
            RoleRepository = new RoleRepository(_appSettings, _dbContext, this, _mapper);
            UserRoleRepository = new UserRoleRepository(_appSettings, _dbContext, this, _mapper);
            
        }
        public IPropertyRepository? PropertyRepository { get; set; }
        public IUserRepository? UserRepository { get; set; }
        public IRoleRepository? RoleRepository { get; set; }
        public IUserRoleRepository? UserRoleRepository { get; set; }

        public void Dispose()
        {
            PropertyRepository = null;
            UserRepository = null;
            RoleRepository = null;
            UserRoleRepository = null;
            
        }
    }
}
