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
        public UnitOfWork(RMSDbContext _dbContext, IOptions<AppSettings> _appSettings)
        {
            PropertyRepository = new PropertyRepository(_appSettings, _dbContext, this);
            UserRepository = new UserRepository(_appSettings,_dbContext, this);
        }
        public IPropertyRepository? PropertyRepository { get; set; }
        public IUserRepository UserRepository { get; set; }

        public void Dispose()
        {
            PropertyRepository = null;
            UserRepository = null;
        }
    }
}
