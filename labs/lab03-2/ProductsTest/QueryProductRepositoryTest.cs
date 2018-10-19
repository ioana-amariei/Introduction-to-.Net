using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;

namespace ProductsTest
{
    [TestClass]
    public class QueryProductRepositoryTest
    {
        private QueryProductRepository _productRepository;

        [TestInitialize]
        public void InitializeRepository()
        {
            _productRepository = new QueryProductRepository(new List<Product>
            {
                Product.Create("Book", "Good for improving your coding skills", DateTime.Now.AddDays(-20),
                    DateTime.Now.AddDays(10), 10.5),
                Product.Create("Washing machine", "Washes perfect", DateTime.Now.AddDays(-30), DateTime.Now.AddDays(20),
                    10.5),
                Product.Create("Some", "Some", DateTime.Now.AddDays(-5), DateTime.Now.AddDays(10), 100.5),
                Product.Create("Cat", "Good for improving", DateTime.Now.AddDays(5), DateTime.Now.AddDays(10), 24.5),
                Product.Create("Book", "Good", DateTime.Now.AddDays(4), DateTime.Now.AddDays(13), 10.5),
                Product.Create("Book", "Good", DateTime.Now.AddDays(-10), DateTime.Now.AddDays(15), 100.5),
                Product.Create("Book", "Good", DateTime.Now.AddDays(1), DateTime.Now.AddDays(3), 40.5),
                Product.Create("Book", "Good", DateTime.Now.AddDays(4), DateTime.Now.AddDays(0), 5560.5),
                Product.Create("Book", "Good", DateTime.Now.AddDays(0), DateTime.Now.AddDays(25), 130.5),
                Product.Create("Book", "Good", DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), 50.5)
            });
        }

        [TestMethod]
        public void Given_RepositoryWithActiveProducts_Then_RetrieveActiveProductsReturnsActiveProducts()
        {
            var activeProducts = _productRepository.RetrieveActiveProducts();
            Assert.IsTrue(activeProducts.Count() == 5);
        }

        [TestMethod]
        public void Given_RepositoryWithInactiveProducts_Then_RetrieveActiveProductsReturnsInactiveProducts()
        {
            var inactiveProducts = _productRepository.RetrieveInactiveProducts();
            Assert.IsTrue(inactiveProducts.Count() == 5);
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllByName_Then_ReturnsProductsByName()
        {
            var filteredResults = _productRepository.RetrieveAll("Washing machine");
            Assert.IsTrue(filteredResults.Count() == 1);
        }

        [TestMethod]
        public void
            Given_NonEmptyRepository_When_RetrievingAllByStartDateAndEndDate_Then_ReturnsProductsByStartDateAndEndDate()
        {
            var startDate = DateTime.Now.AddDays(1);
            var endDate = DateTime.Now.AddDays(2);

            var filteredResult = _productRepository.RetrieveAll(startDate, endDate);
            Assert.IsTrue(filteredResult.Count() == 1);
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllOrderByPriceDescending_Then_ReturnsOrderedProducts()
        {
            var orderedByPrice = _productRepository.RetrieveAllOrderByPriceDescending().ToArray();

            for (var i = 1; i < orderedByPrice.Count(); i++)
            {
                Assert.IsTrue(orderedByPrice[i - 1].Price >= orderedByPrice[i].Price);
            }
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllOrderByPriceAscending_Then_ReturnsOrderedProducts()
        {
            var orderedByPrice = _productRepository.RetrieveAllOrderByPriceAscending().ToArray();

            for (var i = 1; i < orderedByPrice.Count(); i++)
            {
                Assert.IsTrue(orderedByPrice[i - 1].Price <= orderedByPrice[i].Price);
            }
        }
    }
}