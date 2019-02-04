using System;
using System.Threading.Tasks;
using Booking.Business;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/flights")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService flightService;

        public FlightsController(IFlightService flightService) => this.flightService = flightService;

        [HttpGet]
        public async Task<IActionResult> GetFlights()
        {
            var customers = await this.flightService.GetAllActiveFlights();
            return Ok(customers);
        }

        [HttpGet("{id:guid}", Name = "FindFlightById")]
        public async Task<IActionResult> FindFlightById(Guid id)
        {
            var flight = await this.flightService.FindById(id);
            return Ok(flight);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFlight([FromBody] CreatingFlightModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightId = await this.flightService.CreateNew(model);
            return CreatedAtRoute("FindFlightById", new { id = flightId }, model);
        }
    }
}
