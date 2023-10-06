using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookingClass : IBookingService
    {
        public Task<bool> CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDto> CreateBooking(BookingDto bookingDto)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDto>> GetBookingsByPropertyId(int propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDto>> GetBookingsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
