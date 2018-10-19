using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;

namespace ProductsTest
{
    [TestClass]
    public class MethodProductRepositoryTest : ProductRepositoryTest
    {
        public MethodProductRepositoryTest() : base(new MethodProductRepository(Products))
        {
        }
    }
}