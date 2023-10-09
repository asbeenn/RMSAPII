using DataLayer.Entities;
using DataLayer;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    

        public class ApplicationUser
        {
            public ApplicationUser()
            {
                Properties = new HashSet<Property>();
             
                //UserRoles = new HashSet<UserRoles>();
            }

            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

            [MaxLength(50)]
            [Required]
            public string FirstName { get; set; }

            [MaxLength(50)]
            public string? MiddleName { get; set; }

            [MaxLength(50)]
            [Required]
            public string LastName { get; set; }

            [Required]
            [MaxLength(100)]
            public string Email { get; set; }

            [Required]
            public string PasswordHash { get; set; }

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
            public int? ZipCode { get; set; }
          public virtual Booking Booking { get; set; }
 
        // Navigation property to Property (Properties owned by this user)
        public virtual ICollection<Property> Properties { get; set; }

            // Navigation property to UserRole (Roles associated with this user)
            public virtual ICollection<UserRoles> UserRoles { get; set; }
        }

    }
