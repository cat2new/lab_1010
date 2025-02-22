using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DefaultConstructor_InitializesCorrectly()
        {
            ConfProd confProd = new ConfProd();

            Assert.AreEqual("", confProd.Name);
            Assert.AreEqual(0, confProd.Price);
            Assert.IsNotNull(confProd.id);
        }
    }
}
