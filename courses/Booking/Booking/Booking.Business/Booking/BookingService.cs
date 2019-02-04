using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Booking.Business
{
    public sealed class BookingService : IBookingService
    {
        private readonly IRepository repository;

        public BookingService(IRepository repository) => this.repository = repository;

        public async Task<IEnumerable<BookingDetailsModel>> GetAllBookingsForCustomer(Guid customerId)
        {
            var customer = await repository
                    .GetAll<Customer>().Include(c => c.Bookings)
                    .SingleOrDefaultAsync(c => c.Id == customerId);

            return customer.FindFutureFlights().Select(b => new BookingDetailsModel
            {
                Date = b.Date,
                Route = b.Route,
                TicketPrice = b.TicketPrice,
                NoOfTickets = b.NoOfTickets
            });
        }

        public async Task BookFlight(Guid customerId, Guid flightId, int noOfTickets)
        {
            var customer = await repository.FindByIdAsync<Customer>(customerId);
            var flight = await repository.FindByIdAsync<Flight>(flightId);

            customer.BookFlight(flight, noOfTickets);

            await repository.SaveAsync();
        }
    }
}