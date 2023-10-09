using Models.PropertyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IRoleRepository
    {
        Task<RoleDto> Create(RoleDto model);
        Task<RoleDto?> GetById(int userId);
        Task<RoleDto?> GetByName(string name);
    }
}
