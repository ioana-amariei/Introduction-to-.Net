using System;

namespace Booking.Domain
{
    public class FlightBooking : Entity
    {
        private FlightBooking() => NoOfTickets = 1;

        public DateTime Date { get; private set; }

        public string Route { get; private set; }

        public decimal TicketPrice { get; private set; }

        public int NoOfTickets { get; private set; }

        public Customer Customer { get; private set; }

        public Flight Flight { get; private set; }

        // instances of Booking should only be created internally 
        // and not from outside of the Domain layer.
        internal static FlightBooking Create(Customer customer, Flight flight, int noOfTickets) => new FlightBooking
        {
            Route = $"{flight.From} - {flight.To},",
            TicketPrice = flight.Price,
            Date = flight.Date,
            NoOfTickets = noOfTickets,
            Customer = customer,
            Flight = flight
        };

        internal decimal GetTotalPrice() => TicketPrice * NoOfTickets;
    }
}