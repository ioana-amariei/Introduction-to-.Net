using System;
using System.ComponentModel.DataAnnotations;

namespace Products
{
    public class Product
    {
        public Product(string name, string description, DateTime startDate, DateTime? endDate, double price, int vat)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            Vat = vat;
        }

        public Guid Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; private set; }

        [Required]
        public DateTime StartDate { get; private set; }

        public DateTime? EndDate { get; private set; }

        [Required]
        public double Price { get; private set; }

        [Required]
        public int Vat { get; private set; }

        public bool IsValid()
        {
            return EndDate > StartDate;
        }

        public double ComputeVat()
        {
            return Price * Vat / 100;
        }
    }
}
