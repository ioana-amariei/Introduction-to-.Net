using System;

namespace Product.Data
{
    public class Product
    {
        public long Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public double Price { get; }
        public readonly double VAT;

        public Product(long id, string name, string description, DateTime startDate, DateTime endDate, double price)
        {
            Id = id;
            Name = name;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            Price = price;
            VAT = 0.19;
        }

        public bool IsValid(DateTime StartDate, DateTime EndDate){
            if(StartDate.CompareTo(EndDate) >= 0){
                throw new ArgumentException();
            }

            return true;
        }

        public double ComputeVAT(){
            return VAT * Price;
        }

        public double GetVAT()
        {
            return VAT;
        }

        public override bool Equals(object obj)
        {
            var product = obj as Product;
            return product != null &&
                   Id == product.Id &&
                   Name == product.Name &&
                   Description == product.Description &&
                   StartDate == product.StartDate &&
                   EndDate == product.EndDate &&
                   Price == product.Price &&
                   VAT == product.VAT;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Description, StartDate, EndDate, Price, VAT);
        }
    }
}
