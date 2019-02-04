using System;

namespace Booking.Business
{
    public class BookingDetailsModel
    {
        public DateTime Date { get; set; }

        public string Route { get; set; }

        public decimal TicketPrice { get; set; }

        public int NoOfTickets { get; set; }
    }
}