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
                    ProductDescription = "For hair, skin and nails",
                    ProductName = "Supplements",
                    StartDate = DateTime.Now.AddDays(5)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(13),
                    Id = new Guid("CF61D2CD-E361-4785-A8CE-015218C1EFA9"),
                    Price = 50.5,
                    ProductDescription = "Laser printer",
                    ProductName = "Printer",
                    StartDate = DateTime.Now.AddDays(4)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(15),
                    Id = new Guid("A5448575-0A13-4AC9-88DE-FF103792C645"),
                    Price = 50.3,
                    ProductDescription = "Wireless",
                    ProductName = "Mouse",
                    StartDate = DateTime.Now.AddDays(-10)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(3),
                    Id = new Guid("84BDCB4D-889A-4494-9FDE-85D75F7FD153"),
                    Price = 1.5,
                    ProductDescription = "Black",
                    ProductName = "Pen",
                    StartDate = DateTime.Now.AddDays(1)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(0),
                    Id = new Guid("0844BA70-4D56-4B24-A6BB-D2887B3011ED"),
                    Price = 103.5,
                    ProductDescription = "...",
                    ProductName = "Supplements",
                    StartDate = DateTime.Now.AddDays(4)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(25),
                    Id = new Guid("724D71DB-6554-4C2A-A43C-06D8FEC612F8"),
                    Price = 100.5,
                    ProductDescription = "Multi-functional",
                    ProductName = "Blending machine",
                    StartDate = DateTime.Now.AddDays(0)
                },
                new Product
                {
                    EndDate = DateTime.Now.AddDays(2),
                    Id = new Guid("28A2612C-9627-4739-A6BD-7690D6D33771"),
                    Price = 25.5,
                    ProductDescription = "Ergonomic",
                    ProductName = "Keyboard",
                    StartDate = DateTime.Now.AddDays(1)
                }
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
        public void Given_NonEmptyRepository_When_RetrievingAllByStartDateAndEndDate_Then_ReturnsProductsByStartDateAndEndDate()
        {
            var products = _productRepository.RetrieveAll().ToArray();
            var startDate = products.ElementAt(0).StartDate;
            var endDate = products.ElementAt(0).EndDate;

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
