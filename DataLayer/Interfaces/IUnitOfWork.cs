using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPropertyRepository PropertyRepository { get; set; }
        IUserRepository UserRepository { get; set; }

    }
}
