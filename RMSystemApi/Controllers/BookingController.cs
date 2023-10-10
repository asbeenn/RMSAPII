using DataLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Models;
using Models.ViewModel;
using Services.Interfaces;

namespace RMSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IUnitOfWork _unitOfWork;
        public BookingController(IBookingService bookingService, IUnitOfWork unitOfWork)
        {
            _bookingService = bookingService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost("createBooking")]
        public async Task<IActionResult> CreateBooking(BookingDto bookingDto)
        {
            await _bookingService.CreateBooking(bookingDto);
            return Ok();
        }

        [HttpGet("GetBookingsByPropertyId/{propertyId}")] 
        public async Task<IActionResult> GetBookingsByPropertyId(int propertyId )
        {
            var booking = await _bookingService.GetBookingsByPropertyId(propertyId);
            return Ok(booking);
        }

        [HttpGet("GetAll")] 
        public async Task<IActionResult> GetAll()
        {
            var bookings = await _bookingService.GetAll();
            return Ok(bookings);
        }


        [HttpPost("CancelBooking/{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var bookingDto = await _bookingService.GetById(bookingId);
            if (bookingDto == null)
                return BadRequest(new { ErrorMessage = $"Unable to find booking for {bookingId}" });
            var isCancelled = await _bookingService.CancelBooking(bookingId);
            if (!isCancelled)
                return BadRequest(new BadRequestModel { ErrorMessage = "Unable to cancel a booking." });
            return Ok();
        }

        [HttpPost("ConfirmBooking/{bookingId}")]
        public async Task<IActionResult> ConfirmBooking(int bookingId)
        {
            var bookingDto = await _bookingService.GetById(bookingId);
            if (bookingDto == null)
                return BadRequest(new { ErrorMessage = $"Unable to find booking for {bookingId}" });
            var isCancelled = await _bookingService.ConfirmBooking(bookingId);
            if (!isCancelled)
                return BadRequest(new BadRequestModel { ErrorMessage = "Unable to confirm a booking." });
            return Ok();
        }

        [HttpPost("DeleteBooking/{bookingId}")]
        public async Task<IActionResult> DeleteBooking(int bookingId)
        {
            var bookingDto = await _bookingService.GetById(bookingId);
            if (bookingDto == null)
                return BadRequest(new { ErrorMessage = $"Unable to find booking for {bookingId}" });
            var isCancelled = await _bookingService.DeleteBooking(bookingId);
            if (!isCancelled)
                return BadRequest(new BadRequestModel { ErrorMessage = "Unable to delete booking." });
            return Ok();
        }
    }
}
