using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IdentityDbContextModel
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(50)]
        [NotNull]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string? MiddleName { get; set; }
        [MaxLength(50)]
        [NotNull]
        public string LastName { get; set; }

        [NotNull]
        [MaxLength(100)]
        public string PhotoUrl { get; set; }
        [NotNull]
        [MaxLength(100)]
        public string IDUrl { get; set; }

        [NotNull]
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(255)]
        [NotNull]
        public string StreetAddress1 { get; set; }
        [MaxLength(255)]
        public string? StreetAddress2 { get; set; }
        [MaxLength(255)]
        public string CitySuburbTown { get; set; }
        [MaxLength(15)]
        public string? ZipCode { get; set; }



    }
}
