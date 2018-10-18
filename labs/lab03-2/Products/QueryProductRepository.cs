using System;
using System.Collections.Generic;
using System.Linq;

namespace Products
{
    public class QueryProductRepository : IProductRepository
    {
        private readonly IEnumerable<Product> _products;

        public QueryProductRepository(IEnumerable<Product> products)
        {
            this._products = products;
        }

        public IEnumerable<Product> RetrieveActiveProducts()
        {
            return (from product in _products
                where product.StartDate < DateTime.Now && product.EndDate > DateTime.Now
                select product);
        }

        public IEnumerable<Product> RetrieveInactiveProducts()
        {
            return (from product in _products
                where product.StartDate >= DateTime.Now || product.EndDate <= DateTime.Now
                select product);
        }

        public IEnumerable<Product> RetrieveAllOrderByPriceDescending()
        {
            return (from product in _products
                orderby product.Price descending
                select product);
        }

        public IEnumerable<Product> RetrieveAllOrderByPriceAscending()
        {
            return (from product in _products
                orderby product.Price
                select product);
        }

        public IEnumerable<Product> RetrieveAll(string name)
        {
            return (from product in _products
                where product.ProductName == name
                select product);
        }

        public IEnumerable<Product> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            return (from product in _products
                where product.StartDate == startDate && product.EndDate == endDate
                select product);
        }

        public IEnumerable<Product> RetrieveAll()
        {
            return _products;
        }
    }
}