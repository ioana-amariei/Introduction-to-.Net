using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Business
{
    public interface IBookingService
    {
        Task BookFlight(Guid customerId, Guid flightId, int noOfTickets);

        Task<IEnumerable<BookingDetailsModel>> GetAllBookingsForCustomer(Guid customerId);
    }
}
