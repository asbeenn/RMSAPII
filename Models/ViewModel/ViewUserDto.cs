using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public  class ViewUserDto
    {
        public int UserId { get; set; }

        [MaxLength(50)]

        public string FirstName { get; set; }
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        [MaxLength(50)]

        public string LastName { get; set; }

        [EmailAddress]
        public String Email { get; set; }
    


        [MaxLength(100)]
        public string PhotoUrl { get; set; }

        [MaxLength(100)]
        public string IDUrl { get; set; }


        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(255)]

        public string StreetAddress1 { get; set; }
        [MaxLength(255)]
        public string? StreetAddress2 { get; set; }
        [MaxLength(255)]
        public string CitySuburbTown { get; set; }

        public int? ZipCode { get; set; }

        public string RoleName { get; set; }
    }
}
