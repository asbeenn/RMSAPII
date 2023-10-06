using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork)
        {
            AppSettings = appSettings.Value;
            DBContext = dbContext;
            UnitOfWork = unitOfWork;
        }
        public AppSettings AppSettings { get; }
        public RMSDbContext DBContext { get; }
        public IUnitOfWork UnitOfWork { get; }
    }
}
