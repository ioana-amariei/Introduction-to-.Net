using System;
using System.Collections.Generic;
using System.Linq;

namespace Booking.Domain
{
    public class Customer : Entity
    {
        /// <summary>
        /// An empty constructor is needed for EF.
        /// </summary>
        private Customer() => Bookings = new List<FlightBooking>();

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public decimal MoneySpent { get; private set; }

        public ICollection<FlightBooking> Bookings { get; private set; }

        public static Customer Create(string firstName, string lastName, string email) => new Customer
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email
        };

        public void BookFlight(Flight flight, int noOfTockets)
        {
            if (!flight.CanBeBooked())
            {
                return;
            }

            var flightBooking = FlightBooking.Create(this, flight, noOfTockets);
            Bookings.Add(flightBooking);

            MoneySpent += flightBooking.GetTotalPrice();
        }

        public IEnumerable<FlightBooking> FindFutureFlights() => Bookings.Where(b => b.Date >= DateTime.Now);
    }
}