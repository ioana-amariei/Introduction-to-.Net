using System;
using System.ComponentModel.DataAnnotations;

namespace Products
{
    public class Customer
    {
        public Customer(string name, string address, string phoneNumber, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public string Address { get; private set; }
        
        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }
    }
}