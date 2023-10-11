﻿using System;
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
            Pending=1,    // The booking is pending approval
            Confirmed,  // The booking is confirmed
            Canceled, // The booking is canceled
            Deleted 
        }
        public enum RoleNames
        {
            Admin=1,
            Tenant,
            User
        }
    }
}
