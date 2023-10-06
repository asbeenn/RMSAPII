using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserRoleDto
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string RoleName { get; set; }
    }
}
