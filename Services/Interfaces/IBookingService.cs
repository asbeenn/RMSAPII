using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IBookingService
    {
        Task<bool> CreateBooking(BookingDto bookingDto);
        Task<List<BookingDto>> GetBookingsByPropertyId(int propertyId);
        Task<bool> CancelBooking(int bookingId);
        Task<bool> ConfirmBooking(int bookingId);
        Task<bool> DeleteBooking(int bookingId);
        Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto);
        Task<BookingDto> GetById(int bookingId);
        Task<List<BookingDto>> GetAll();

    }
}
