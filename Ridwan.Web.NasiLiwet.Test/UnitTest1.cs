using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ridwan.Web.NasiLiwet.Web.repository;

namespace Ridwan.Web.NasiLiwet.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ProductRepository repository = new ProductRepository();
            var a = repository.GetAllData();
            Assert.IsNotNull(a);
        }
    }
}
