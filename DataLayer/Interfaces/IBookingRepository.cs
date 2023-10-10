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
        Task<List<BookingDto>?> GetBookingsByPropertyId(int propertyId);
        Task<List<BookingDto>?> GetAll();
        Task<bool> CancelBooking(int bookingId);
        Task<bool> ConfirmBooking(int bookingId);
        Task<bool> DeleteBooking(int bookingId);
        Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto);
        Task<BookingDto?> GetById(int bookingId);

    }
}
