using System;
using System.ComponentModel.DataAnnotations;

namespace Employees
{
    public class Customer
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Address { get; private set; }

        [RegularExpression("(00|\\+)40\\d{10}")]
        public string PhoneNumber { get; private set; }

        [RegularExpression("[a-zA-Z0-9_.-]+@[a-z]+.[a-z]+")]
        public string Email { get; private set; }

        private Customer()
        {
            // Entity Framework
        }

        public Customer(string name, string address, string phoneNumber, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Update(Customer customer)
        {
            Name = customer.Name;
            Address = customer.Address;
            PhoneNumber = customer.PhoneNumber;
            Email = customer.Email;
        }
    }
}