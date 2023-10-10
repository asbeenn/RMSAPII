using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class BookingRepository : RepositoryBase,IBookingRepository
    {
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        private readonly RMSDbContext _dbContext;
        private readonly IMapper _mapper;

        public BookingRepository(IOptions<AppSettings> appSettings, RMSDbContext dbContext, IUnitOfWork unitOfWork, IMapper mapper) : base(appSettings, dbContext, unitOfWork)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> CancelBooking(int bookingId)
        {
            var booking = await _dbContext.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
            if(booking != null)
            {
                booking.BookingStatus = Enums.BookingStatus.Canceled.ToString();
                _dbContext.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<bool> ConfirmBooking(int bookingId)
        {
            var booking = await _dbContext.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
            if(booking != null)
            {
                booking.BookingStatus = Enums.BookingStatus.Confirmed.ToString();
                _dbContext.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<bool> DeleteBooking(int bookingId)
        {
            var booking = await _dbContext.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
            if(booking != null)
            {
                booking.BookingStatus = Enums.BookingStatus.Deleted.ToString();
                _dbContext.SaveChanges();
                return true;
            }
            return false;

        }

        public async Task<bool> CreateBooking(Booking booking)
        {            
            await _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<List<BookingDto>?> GetBookingsByPropertyId(int propertyId)
        {
            var bookings = await _dbContext.Bookings.Where(x => x.PropertyId == propertyId).ToListAsync();
            if(bookings != null)    
                return _mapper.Map<List<BookingDto>>(bookings);
            return null;
        }

    
        public Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingDto?> GetById(int bookingId)
        {
            var booking = await _dbContext.Bookings.Where(x => x.BookingId == bookingId).FirstOrDefaultAsync();
            if(booking != null)
                return _mapper.Map<BookingDto>(booking);
            return null;
        }

        public async Task<List<BookingDto>?> GetAll()
        {
            List<string> validBookingStatus = new List<string> { 
                Enums.BookingStatus.Pending.ToString(),
                Enums.BookingStatus.Canceled.ToString() };
            var bookings = await _dbContext.Bookings.Where(x=> validBookingStatus.Contains(x.BookingStatus)).ToListAsync();
            if (bookings != null)
                return _mapper.Map<List<BookingDto>>(bookings);
            return null;
        }




    }
}
