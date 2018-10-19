using Microsoft.VisualStudio.TestTools.UnitTesting;
using Products;

namespace ProductsTest
{
    [TestClass]
    public class QueryProductRepositoryTest : ProductRepositoryTest
    {
        public QueryProductRepositoryTest() : base(new QueryProductRepository(Products))
        {
        }
    }
}