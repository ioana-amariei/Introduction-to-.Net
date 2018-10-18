using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductRepository.Data
{
    public class ProductRepository
    {
        readonly private List<Product> _products;
        public ProductRepository()
        {
            _products = new List<Product>();
            _products.Add(new Product(1, "Rice", "Full in carbs", new DateTime(), new DateTime(), 13.0));
            _products.Add(new Product(2, "Cake", "Is delicious", new DateTime(), new DateTime(), 12.0));
            _products.Add(new Product(3, "Phone", "New and innovative", new DateTime(), new DateTime(), 100.0));
           
        }

        public Product GetPoductByName(string productName)
        {
            foreach (Product product in _products)
            {
                if (product.Name.Equals(productName))
                {
                    return product;
                }
            }
            return null;
        }

        public List<Product> FindAllProducts()
        {
            return _products;
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public Product GetProductByPosition(int position)
        {
            if (position < 0 || position >= _products.Count)
            {
                throw new IndexOutOfRangeException();
            }
            return _products.ElementAt(position);
        }

        public void RemoveProductByName(string productName)
        {
            foreach(Product product in _products)
            {
                if (product.Name.Equals(productName))
                {
                    _products.Remove(product);
                }
            }
        }

    }
}
