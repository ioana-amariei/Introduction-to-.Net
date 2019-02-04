using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Booking.Domain;
using Microsoft.EntityFrameworkCore;

namespace Booking.Business
{
    public sealed class FlightService : IFlightService
    {
        private readonly IRepository repository;

        public FlightService(IRepository repository) => this.repository = repository;

        public async Task<List<FlightDetailsModel>> GetAllActiveFlights() => await GetAllFlightsDetails()
                    .Where(f => f.Date > DateTime.Now)
                    .ToListAsync();

        public async Task<FlightDetailsModel> FindById(Guid id) => await GetAllFlightsDetails().SingleOrDefaultAsync(f => f.Id == id);

        public async Task<Guid> CreateNew(CreatingFlightModel newFlight)
        {
            var flight = Flight.Create(
                to: newFlight.To,
                @from: newFlight.From,
                price: newFlight.Price,
                date: newFlight.Date);

            await this.repository.AddNewAsync(flight);
            await this.repository.SaveAsync();

            return flight.Id;
        }

        private IQueryable<FlightDetailsModel> GetAllFlightsDetails() => repository.GetAll<Flight>()
                             .Select(f => new FlightDetailsModel
                             {
                                 Id = f.Id,
                                 To = f.To,
                                 From = f.From,
                                 Price = f.Price,
                                 Date = f.Date
                             });
    }
}