using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingStatus { get; set; }

        // Navigation property to Property (Property associated with this booking)
        public virtual Property Property { get; set; }

        // Navigation property to ApplicationUser (User who made the booking)
        public virtual ApplicationUser User { get; set; }
    }
}
