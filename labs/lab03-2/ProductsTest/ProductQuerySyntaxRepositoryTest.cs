using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;

namespace ProductsTest
{
    [TestClass]
    public class ProductQuerySyntaxRepositoryTest
    {

        private ProductQuerySyntaxRepository _productRepository;

        [TestInitialize]
        public void InitializeRepository()
        {
            _productRepository = new ProductQuerySyntaxRepository(new List<Product>
            {
                new Product
                {
                    EndDate = DateTime.Now.AddDays(10),
                    Id = new Guid("5F0E1A94-79FF-4685-AEE7-8FD519D292C2"),
                    Price = 10.5,
                    ProductDescription = "Good for improving your coding skills",
                    ProductName = "Book",
                    StartDate = DateTime.Now.AddDays(-20)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(20),
                    Id = new Guid("D6F96CD8-4CF0-47DF-A65A-EA872E652DB0"),
                    Price = 200.0,
                    ProductDescription = "Washes perfect",
                    ProductName = "Washing machine",
                    StartDate = DateTime.Now.AddDays(-30)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(10),
                    Id = new Guid("A2A99E36-96BA-43CA-AAFB-0DF6CF96EA95"),
                    Price = 288.7,
                    ProductDescription = "Easy to carry around",
                    ProductName = "Laptop",
                    StartDate = DateTime.Now.AddDays(-5)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(10),
                    Id = new Guid("742C834C-8DA5-4445-AF48-796430F693B0"),
                    Price = 100.5,
                    ProductDescription = "...",
                    ProductName = "Supplements",
                    StartDate = DateTime.Now.AddDays(5)
                }
            });
        }

        [TestMethod]
        public void Given_RepositoryWithActiveProducts_Then_RetrieveActiveProductsReturnsActiveProducts()
        {
            var activeProducts = _productRepository.RetrieveActiveProducts();
            Assert.IsTrue(activeProducts.Count() == 3);
        }

        [TestMethod]
        public void Given_RepositoryWithInactiveProducts_Then_RetrieveActiveProductsReturnsInactiveProducts()
        {
            var inactiveProducts = _productRepository.RetrieveInactiveProducts();
            Assert.IsTrue(inactiveProducts.Count() == 1);
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllByName_Then_ReturnsProductsByName()
        {
            var filteredResults = _productRepository.RetrieveAll("Washing machine");
            Assert.IsTrue(filteredResults.Count() == 1);
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllByStartDateAndEndDate_Then_ReturnsProductsByStartDateAndEndDate()
        {
            var products = _productRepository.RetrieveAll();
            var enumerable = products as Product[] ?? products.ToArray();
            DateTime startDate = enumerable.ElementAt(0).StartDate;
            DateTime endDate = enumerable.ElementAt(0).EndDate;

            var filteredResult = _productRepository.RetrieveAll(startDate, endDate);
            Assert.IsTrue(filteredResult.Count() == 1);
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllOrderByPriceDescending_Then_ReturnsOrderedProducts()
        {
            var orderedProducts = _productRepository.RetrieveAllOrderByPriceDescending();
        }

        [TestMethod]
        public void Given_NonEmptyRepository_When_RetrievingAllOrderByPriceAscending_Then_ReturnsOrderedProducts()
        {
            var orderedProducts = _productRepository.RetrieveAllOrderByPriceAscending();
        }
    }
}
