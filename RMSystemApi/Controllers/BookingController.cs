using DataLayer.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Models;
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
    }
}
