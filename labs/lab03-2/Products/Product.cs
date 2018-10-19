using System;

namespace Products
{
    public class Product
    {
        private Product()
        {

        }
        public Guid Id { get; private set; }
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double Price { get; private set; }
        public static Product Create(string name, string description, DateTime startDate, DateTime endDate, double price)
        {
            CheckParameters(name, description);
            return new Product
            {
                Id = Guid.NewGuid(),
                ProductName = name,
                ProductDescription = description,
                StartDate = startDate,
                EndDate = endDate,
                Price = price

            };
        }

        private static void CheckParameters(string name, string description)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException();
            }
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException();
            }
            if (name.Length > 50)
            {
                throw new ArgumentException();
            }
            if (description.Length > 300)
            {
                throw new ArgumentException();
            }
        }
    }
}
