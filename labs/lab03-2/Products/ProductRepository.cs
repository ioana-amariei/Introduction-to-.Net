using System;
using System.Collections.Generic;

namespace Products
{
    class ProductRepository : IProductRepository
    {
        private List<Product> _products;

        public ProductRepository(List<Product> products)
        {
            this._products = products;
        }

        public IEnumerable<Product> RetrieveActiveProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> RetrieveInactiveProducts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> RetrieveAllOrderByPriceDescending()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> RetrieveAllOrderByPriceAscending()
        {
            throw new NotImplementedException();
        }

        public void RetrieveAll(string name)
        {
            throw new NotImplementedException();
        }

        public void RetrieveAll(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
