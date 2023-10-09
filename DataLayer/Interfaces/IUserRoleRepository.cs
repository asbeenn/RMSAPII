using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserRoleRepository
    {
        Task<List<RoleDto?>> GetUserRolesByUserId(int userId);
    }
}
