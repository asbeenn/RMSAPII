using AutoMapper;
using Common;
using DataLayer.Entities;
using DataLayer.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class BookingService : IBookingService
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IWebHostEnvironment _env;
        //private readonly string _imageDirectory;
        private readonly IMapper _mapper;
        public BookingService(IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _appSettings = appSettings.Value;
            _unitOfWork = unitOfWork;
           
            _mapper = mapper;
          
        }
        public Task<bool> CancelBooking(int bookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CreateBooking(BookingDto bookingDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingDto);
            await _unitOfWork.BookingRepository.CreateBooking(bookingEntity);
            return true;
        }

        public Task<List<BookingDto>> GetBookingsByPropertyId(int propertyId)
        {
            throw new NotImplementedException();
        }

      
        public Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto)
        {
            throw new NotImplementedException();
        }
    }
}
