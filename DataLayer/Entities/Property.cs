﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public partial class Property
    {
        [Key]
        public int PropertyId { get; set; }
        public string? PropertyName { get; set; }
        public int? UserId { get; set; }
        public string Country { get; set; } = null!;
        public string? StreetAddress { get; set; }
        public string? StreetAddress2 { get; set; }
        public string? CitySuburbTown { get; set; }
        public string? StateProvienceRegion { get; set; }
        public int? ZipPostalCode { get; set; }
        public string? PropertyType { get; set; }
        public int? RentCost { get; set; }
        public string? PropertyImage { get; set; }   


        // Navigation property to ApplicationUser (User who owns the property)
        public virtual ApplicationUser? User { get; set; }
      
 
        // Navigation property to Booking (Bookings related to this property)
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
