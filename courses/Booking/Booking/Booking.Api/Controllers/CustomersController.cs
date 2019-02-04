using System;
using System.Threading.Tasks;
using Booking.Business;
using Microsoft.AspNetCore.Mvc;

namespace Booking.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;

        public CustomersController(ICustomerService customerService) => this.customerService = customerService;

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var customers = await this.customerService.GetAll();
            return Ok(customers);
        }

        [HttpGet("{id:guid}", Name = "FindCustomerById")]
        public async Task<IActionResult> FindCustomerById(Guid id)
        {
            var customer = await this.customerService.FindById(id);
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreatingCustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customerId = await this.customerService.CreateNew(model);
            return CreatedAtRoute("FindCustomerById", new { id = customerId }, model);
        }
    }
}
