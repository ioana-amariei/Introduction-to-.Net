using System;

namespace Product.Data
{
    public class Product
    {
        private long Id { get; }
        private string Name { get; }
        private string Description { get; }
        private DateTime StartDate { get; }
        private DateTime EndDate { get; }
        public float Price { get; }
        private readonly float VAT;

        public Product(long id, string name, string description, DateTime startDate, DateTime endDate, float price)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            VAT = 0.19f;
        }

        public bool IsValid(DateTime StartDate, DateTime EndDate){
            if(StartDate.CompareTo(EndDate) >= 0){
                throw new ArgumentException();
            }

            return true;
        }

        public float ComputeVAT(){
            return VAT * Price;
        }

        public float GetVAT()
        {
            return VAT;
        }
    }
}
