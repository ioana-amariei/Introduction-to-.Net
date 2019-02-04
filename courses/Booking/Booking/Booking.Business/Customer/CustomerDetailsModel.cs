using System;

namespace Booking.Business
{
    public class CustomerDetailsModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public decimal MoneySpent { get; set; }
    }
}
