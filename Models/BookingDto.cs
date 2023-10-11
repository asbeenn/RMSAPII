using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookingDto
    {
        
        public int PropertyId { get; set; }
        public int UserId { get; set; }
        public DateTime BookingDate { get; set; }
      
        public string? BookingStatus { get; set; }
    }
}
