using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IRoleService
    {
        Task<RoleDto> CreateRole(RoleDto model);
        Task<RoleDto?> GetById(int userId);
        Task<RoleDto?> GetByName(string name);

    }
}
