using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.PropertyModel
{
    public class UpdatePropertyDto
    {
        public int? propertyId { get; set; }
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
    }
}
