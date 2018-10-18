using System;
using System.Collections.Generic;

namespace Products
{
    public interface IProductRepository
    {
        IEnumerable<Product> RetrieveActiveProducts();
        IEnumerable<Product> RetrieveInactiveProducts();
        IEnumerable<Product> RetrieveAllOrderByPriceDescending();
        IEnumerable<Product> RetrieveAllOrderByPriceAscending();
        IEnumerable<Product> RetrieveAll(string name);
        IEnumerable<Product> RetrieveAll(DateTime startDate, DateTime endDate);
    }
}