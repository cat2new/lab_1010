using ConfLib;


namespace TestProject3
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void DefaultConstructor_InitializesCorrectly()
        {
            ConfProd confProd = new ConfProd();

            Assert.AreEqual("", confProd.Name);
            Assert.AreEqual(0, confProd.Price);
            Assert.IsNotNull(confProd.id);
        }

        [TestMethod]
        public void ParametrizedConstructor_InitializesCorrectly();
    }
}
