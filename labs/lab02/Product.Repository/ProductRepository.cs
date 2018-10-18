using System;
using System.Collections.Generic;
using System.Linq;

namespace Product.Repository
{
    public class ProductRepository
    {
        readonly private List<Data.Product> _products;
        public ProductRepository()
        {
            _products = new List<Data.Product>();
         }

        public Data.Product GetPoductByName(string productName)
        {
            if(productName == null)
            {
                throw new ArgumentException("Product name cannot have null value.");
            }

            foreach (Data.Product product in _products)
            {
                if (product.Name.Equals(productName))
                {
                    return product;
                }
            }

            return null;
        }

        public List<Data.Product> FindAllProducts()
        {
            return _products;
        }

        public void AddProduct(Data.Product product)
        {
            if(product == null)
            {
                throw new ArgumentException("Product cannot have a null value.");
            }

            if(_products.Contains(product))
            {
                return;
            }

            _products.Add(product);
        }

        public Data.Product GetProductByPosition(int position)
        {
            if (position < 0 || position >= _products.Count)
            {
                throw new IndexOutOfRangeException("Invalid position");
            }

            return _products.ElementAt(position);
        }

        public void RemoveProductByName(string productName)
        {
            if(productName == null)
            {
                throw new ArgumentException("Product name cannot have null value.");
            }

            Data.Product product = GetPoductByName(productName);
            _products.Remove(product);        
        }

    }
}
