using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
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
        public Task<bool> CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateBooking(Booking booking)
        {
            
             _dbContext.Bookings.AddAsync(booking);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public Task<List<BookingDto>> GetBookingsByPropertyId(int propertyId)
        {
            throw new NotImplementedException();
        }

        public Task<List<BookingDto>> GetBookingsByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto)
        {
            throw new NotImplementedException();
        }
    }
}
