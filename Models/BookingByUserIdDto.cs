using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class BookingByUserIdDto
    {
        public int UserId { get; set; }
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string BookingStatus { get; set; }
    }
}
