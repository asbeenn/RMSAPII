using DataLayer.Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> CreateBooking(Booking booking);
        
        Task<List<BookingDto>> GetBookingsByPropertyId(int propertyId);
        Task<bool> CancelBooking(int bookingId);
        Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto);

    }
}
