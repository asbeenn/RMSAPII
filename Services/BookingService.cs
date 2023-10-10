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
            return _unitOfWork.BookingRepository.CancelBooking(bookingId);
        }
        public Task<bool> ConfirmBooking(int bookingId)
        {
            return _unitOfWork.BookingRepository.ConfirmBooking(bookingId);
        }

        public Task<bool> DeleteBooking(int bookingId)
        {
            return _unitOfWork.BookingRepository.DeleteBooking(bookingId);
        }

        public async Task<bool> CreateBooking(BookingDto bookingDto)
        {
            var bookingEntity = _mapper.Map<Booking>(bookingDto);
            await _unitOfWork.BookingRepository.CreateBooking(bookingEntity);
            return true;
        }

        public async Task<List<BookingDto>?> GetBookingsByPropertyId(int propertyId)
        {
            return await _unitOfWork.BookingRepository.GetBookingsByPropertyId(propertyId);
        }
      
        public Task<BookingDto> UpdateBooking(int bookingId, UpdateBookingDto updateBookingDto)
        {
            throw new NotImplementedException();
        }

        public async Task<BookingDto?> GetById(int bookingId)
        {
            return await _unitOfWork.BookingRepository.GetById(bookingId);
        }
        public async Task<List<BookingDto>?> GetAll()
        {
            return await _unitOfWork.BookingRepository.GetAll();
        }


    }
}
