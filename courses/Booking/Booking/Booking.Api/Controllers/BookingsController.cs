using System;
using System.Net;
using System.Threading.Tasks;
using Booking.Business;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/customers/{customerId:guid}/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingsController(IBookingService bookingService) => this.bookingService = bookingService;

        [HttpGet]
        public async Task<IActionResult> GetBookings(Guid customerId)
        {
            var bookings = await this.bookingService.GetAllBookingsForCustomer(customerId);
            return Ok(bookings);
        }

        [HttpPost("{flightId:guid}")]
        public async Task<IActionResult> BookAFlight(Guid customerId, Guid flightId, [FromBody]BookFlightModel model)
        {
            await this.bookingService.BookFlight(customerId, flightId, model.NoOfTickets);

            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
