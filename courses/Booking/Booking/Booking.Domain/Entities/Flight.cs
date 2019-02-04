using System;

namespace Booking.Domain
{
    public class Flight : Entity
    {
        /// <summary>
        /// An empty constructor is needed for EF.
        /// </summary>
        private Flight()
        {
        }

        public string To { get; private set; }

        public string From { get; private set; }

        public decimal Price { get; private set; }

        public DateTime Date { get; private set; }

        public static Flight Create(string to, string from, decimal price, DateTime date) => new Flight
        {
            To = to,
            From = from,
            Price = price,
            Date = date
        };

        public bool CanBeBooked() => Date >= DateTime.Now.AddDays(1);
    }
}