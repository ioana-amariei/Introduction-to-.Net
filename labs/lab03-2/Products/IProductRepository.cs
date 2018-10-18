using System;
using System.Collections.Generic;

namespace Products
{
    interface IProductRepository
    {
        IEnumerable<Product> RetrieveActiveProducts();
        IEnumerable<Product> RetrieveInactiveProducts();
        IEnumerable<Product> RetrieveAllOrderByPriceDescending();
        IEnumerable<Product> RetrieveAllOrderByPriceAscending();
        void RetrieveAll(string name);
        void RetrieveAll(DateTime startDate, DateTime endDate);
    }
}