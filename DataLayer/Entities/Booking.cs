//using Common;
//using DataLayer.IdentityDbContextModel;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataLayer.Entities
//{
//    public partial class Booking
//    {
//        [Key]
//        public string BookingId { get; set; }

       
//        public string UserId { get; set; } // Reference to the user who made the booking

       
//        public int PropertyId { get; set; } // Reference to the booked property

      
//        public DateTime BookingStartDate { get; set; }

       
//        public DateTime BookingEndDate { get; set; }

      
//        public Enums.BookingStatus Status { get; set; }

//        // Additional properties you might need, such as comments, price, etc.

//        [ForeignKey("UserId")]
//        public ApplicationUser User { get; set; }

//        // Navigation property to represent the property that was booked
      
//        public Property Property { get; set; } = null!;
//        public Invoice Invoice { get; set; }
//    }
//}
