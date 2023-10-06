using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.ViewModel
{
    public class UserViewModel
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)]
        public string? Email { get; set; }
       

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;


        public string? PhoneNumber { get; set; }
        [Required]
        [MaxLength(255)]
        public string CitySuburbTown { get; set; } = null!;

        [NotNull]
        [MaxLength(100)]
        public string PhotoUrl { get; set; } = null!;
        public string Country { get; set; }
        [MaxLength(255)]
        [NotNull]
        public string StreetAddress1 { get; set; }
        [MaxLength(255)]
        public string? StreetAddress2 { get; set; }
       
        [MaxLength(15)]
        public string? ZipCode { get; set; }

    }
}
