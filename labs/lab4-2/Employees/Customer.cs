using System;
using System.ComponentModel.DataAnnotations;

namespace Employees
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        [RegularExpression("(00|\\+)40\\d{10}")]
        public string PhoneNumber { get; set; }

        [RegularExpression("[a-zA-Z0-9_.-]+@[a-z]+.[a-z]+")]
        public string Email { get; set; }

        public Customer(string name, string address, string phoneNumber, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
