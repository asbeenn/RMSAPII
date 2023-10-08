using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Enums
    {
        public enum BookingStatus
        {
            Pending,    // The booking is pending approval
            Confirmed,  // The booking is confirmed
            Canceled    // The booking is canceled
        }
        public enum RoleNames
        {
            Admin = 1,
            Customer ,
            Tenant
        }
    }
}
