using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Booking.Business
{
    public interface IFlightService
    {
        Task<List<FlightDetailsModel>> GetAllActiveFlights();

        Task<FlightDetailsModel> FindById(Guid id);

        Task<Guid> CreateNew(CreatingFlightModel newFlight);
    }
}