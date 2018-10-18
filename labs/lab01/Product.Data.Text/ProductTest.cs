using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace Product.Data.Test
{
    [TestFixture]
    public class ProductTest
    {
        private Product CreateTestProduct()
        {
            return new Product(1, "Name", "Description", new DateTime(), new DateTime(), 10.0f);
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void When_InvalidStartDateAndEndDate_Then_isValidThrowsException()
        {
            var product = CreateTestProduct();
            product.IsValid(new DateTime(), new DateTime());
        }

        [Test]        
        public void When_ValidStartDateAndEndDate_Then_isValidReturnTrue()
        {
            var product = CreateTestProduct();
            product.IsValid(new DateTime(), new DateTime().AddDays(2)).Should().BeTrue();
        }

        [Test]
        public void Given_ProductPrice_Then_ComputeVATReturnsTotalPrice()
        {
            var product = CreateTestProduct();
            var expected = product.Price * product.GetVAT();
            var actual = product.ComputeVAT();

            actual.Should().BeApproximately(expected, 0.01f);
        }
    }
}
