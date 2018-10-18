using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ProductRepository.Data.Test
{
    [TestClass]
    class ProductRepositoryTest
    {
        private List<Product> products = new List<Product>{
            new Product(1, "Rice", "Full in carbs", new DateTime(), new DateTime(), 13.0),
            new Product(2, "Cake", "Is delicious", new DateTime(), new DateTime(), 12.0),
            new Product(3, "Phone", "New and innovative", new DateTime(), new DateTime(), 100.0)
            };

        private ProductRepository sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new ProductRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            sut = null;
        }

        [TestMethod]
        public void When_ExistingProductName_Then_GetProductByNameReturnProduct()
        {
            string existingProductName = "Rice";
            Product actual = products.ElementAt(0);
            Product expected = sut.GetPoductByName(existingProductName);

            actual.Should().Be(expected);
        }
          
    }
}
