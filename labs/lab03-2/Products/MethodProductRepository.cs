using System;
using System.Collections.Generic;
using System.Linq;

namespace Products
{
    public class MethodProductRepository : IProductRepository
    {
        private readonly IEnumerable<Product> _products;

        public MethodProductRepository(IEnumerable<Product> products)
        {
            _products = products;
        }

        public IEnumerable<Product> RetrieveActiveProducts()
        {
            return _products.Where(p => p.StartDate < DateTime.Now && p.EndDate > DateTime.Now);
        }

        public IEnumerable<Product> RetrieveInactiveProducts()
        {
            return _products.Where(p => p.StartDate >= DateTime.Now || p.EndDate <= DateTime.Now);
        }

        public IEnumerable<Product> RetrieveAllOrderByPriceDescending()
        {
            return _products.OrderByDescending(p => p.Price);
        }

        public IEnumerable<Product> RetrieveAllOrderByPriceAscending()
        {
            return _products.OrderBy(p => p.Price);
        }

        public IEnumerable<Product> RetrieveAll(string name)
        {
            return _products.Where(p => p.ProductName == name);
        }

        public IEnumerable<Product> RetrieveAll(DateTime startDate, DateTime endDate)
        {
            return _products.Where(p => p.StartDate == startDate && p.EndDate == endDate);
        }

        public object RetrieveAll()
        {
            throw new NotImplementedException();
        }
    }
}