using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class UserRoles
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual Roles Role { get; set; }
    }

}
