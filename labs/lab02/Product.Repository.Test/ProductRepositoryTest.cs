using System;
using System.Collections.Generic;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Product.Repository.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        private List<Data.Product> products = new List<Product.Data.Product>{
            new Data.Product(1, "Rice", "Full in carbs", new DateTime(), new DateTime(), 13.0),
            new Data.Product(2, "Cake", "Is delicious", new DateTime(), new DateTime(), 12.0),
            new Data.Product(3, "Phone", "New and innovative", new DateTime(), new DateTime(), 100.0)
            };

        private ProductRepository sut;

        [TestInitialize]
        public void TestInitialize()
        {
            sut = new ProductRepository();

            foreach (Data.Product product in products)
            {
                sut.AddProduct(product);   
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            sut = null;
        }

        [TestMethod]
        public void Given_ExistingProductName_Then_GetPoductByNameWillReturnProduct()
        {
            string existingProductName = "Rice";
            Data.Product expected = products.ElementAt(0);
            Data.Product actual = sut.GetPoductByName(existingProductName);

            actual.Should().Be(expected);
        }

        [TestMethod]
        public void Given_NonExistentProductName_Then_GetPoductByNameWillReturnNull()
        {
            Data.Product expected = null;
            Data.Product actual = sut.GetPoductByName("Book");

            actual.Should().Be(expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Product name cannot have null value.")]
        public void Given_NullProductName_Then_GetPoductByNameWillThrowException()
        {
            sut.GetPoductByName(null);
        }
        
        [TestMethod]
        public void Given_NotEmptyRepository_Then_FindAllProductsWillReturnProductList()
        {
            sut.FindAllProducts().Should().NotBeEmpty();
        }

        [TestMethod]
        public void Given_ValidProduct_When_AddingProduct_Then_RepositoryContainsTheProduct()
        {
            //Given
            ProductRepository sut = new ProductRepository();
            Data.Product product = new Data.Product(3, "Book", "New", new DateTime(), new DateTime(), 100.0);

            //When
            sut.AddProduct(product);

            //Then
            sut.FindAllProducts().Contains(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Product cannot have null value.")]
        public void Given_NullProduct_Then_AddProductWillThrowException()
        {
            sut.AddProduct(null);
        }

        [TestMethod]
        public void Given_ExistingProduct_When_AddingProduct_Then_NothingHappens()
        {
            Data.Product product = new Data.Product(1, "Rice", "Full in carbs", new DateTime(), new DateTime(), 13.0);
            sut.AddProduct(product);
        }

        [TestMethod]
        public void Given_ValidPosition_Then_GetProductByPositionReturnsProduct()
        {
            Data.Product actual = sut.GetProductByPosition(2);
            Data.Product expected = products.ElementAt(2);

            actual.Should().Be(expected);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "Invalid position")]
        public void Given_InvalidPosition_Then_GetProductByPositionThrowsException()
        {
            sut.GetProductByPosition(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Product name cannot have null value.")]
        public void Given_NullProductName_Then_RemoveProductByNameThrowsException()
        {
            sut.RemoveProductByName(null);
        }

        [TestMethod]
        public void Given_ProductWithNameExistsInRepository_When_RemoveProductByName_Then_ProductIsRemoved()
        {
            Data.Product removedProduct = sut.GetPoductByName("Rice");
            sut.RemoveProductByName("Rice");

            sut.FindAllProducts().Should().NotContain(removedProduct);
        }
    }
}
