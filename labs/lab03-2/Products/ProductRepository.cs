using System.Collections.Generic;

namespace Products
{
    public abstract class ProductRepository
    {
        private readonly IEnumerable<Product> _products;

        protected ProductRepository(IEnumerable<Product> products)
        {
            _products = products;
        }
    }
}
