using Microsoft.AspNetCore.Mvc;
using examtask.Models;
using examtask.Services;

namespace examtask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingsController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: api/Bookings/clinic/{clinicName}
        [HttpGet("clinic/{clinicName}")]
        public IActionResult GetBookingsByClinic(string clinicName)
        {
            try
            {
                var bookings = _bookingService.GetBookingsByClinic(clinicName);
                return Ok(bookings);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // GET: api/Bookings/patient/{patientName}
        [HttpGet("patient/{patientName}")]
        public IActionResult GetBookingsByPatient(string patientName)
        {
            try
            {
                var bookings = _bookingService.GetBookingsByPatient(patientName);
                return Ok(bookings);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/Bookings/add
        [HttpPost("add")]
        public IActionResult AddBooking(int cId, int pId, DateTime bookingDate, bool isBooked)
        {
            var booking = new Bookings
            {
                CId = cId,
                PId = pId,
                BookingDate = bookingDate,
                IsBooked = isBooked
            };

            try
            {
                _bookingService.AddAppointment(booking);
                return Created();
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
