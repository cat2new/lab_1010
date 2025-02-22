using ClassLibrary1;

namespace TestProject4
{
    [TestClass]
    public sealed class ConfProdUnitTest
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
        public void ParametrizedConstructor_InitializesCorrectly()
        {
            ConfProd confProd = new ConfProd("Торт", 500.9, 1);

            Assert.AreEqual("Торт", confProd.Name);
            Assert.AreEqual(500.9, confProd.Price);
            Assert.AreEqual(1, confProd.id.Number);
        }
        [TestMethod]
        public void Name_SetValidValue_Success()
        {
            ConfProd confProd = new ConfProd();
            confProd.Name = "Изделие";

            Assert.AreEqual("Изделие", confProd.Name);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Name_SetEmptyValue_ThrowsException()
        {
            ConfProd confProd = new ConfProd();
            confProd.Name = "";
        }
        [TestMethod]
        public void Price_SetValidValue_Success()
        {
            ConfProd confProd = new ConfProd();
            confProd.Price = 300.0;

            Assert.AreEqual(300.0, confProd.Price);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Price_SetNegativeValue_ThrowsException()
        {
            ConfProd confProd = new ConfProd();
            confProd.Price = -300.0;
        }
        [TestMethod]
        public void CompareTo_ReturnsCorrectResult()
        {
            ConfProd confProd1 = new ConfProd("Изделие 1", 500, 1);
            ConfProd confProd2 = new ConfProd("Изделие 2", 400, 2);

            Assert.IsTrue(confProd1.CompareTo(confProd2) > 0);
            Assert.IsTrue(confProd2.CompareTo(confProd1) < 0);
            Assert.AreEqual(0, confProd1.CompareTo(confProd1));
        }
        [TestMethod]
        public void Compare_ReturnsCorrectResult()
        {
            ConfProd confProd1 = new ConfProd("Изделие 1", 500, 1);
            ConfProd confProd2 = new ConfProd("Изделие 2", 400, 2);

            Assert.IsTrue(confProd1.Compare(confProd1, confProd2) < 0);
            Assert.IsTrue(confProd1.Compare(confProd2, confProd1) > 0);
            Assert.AreEqual(0, confProd1.Compare(confProd1, confProd1));
        }
        [TestMethod]
        public void Clone_CreatesDeepCopy()
        {
            ConfProd confProd1 = new ConfProd("Торт", 500, 2);
            ConfProd confProd2 = (ConfProd)confProd1.Clone();

            Assert.AreEqual(confProd1.Name, confProd2.Name);
            Assert.AreEqual(confProd1.Price, confProd2.Price);
            Assert.AreEqual(confProd1.id.Number, confProd2.id.Number);
            Assert.AreNotSame(confProd1, confProd2);
        }
        [TestMethod]
        public void ShallowCopy_CreatesShallowCopy()
        {
            ConfProd confProd1 = new ConfProd("Торт", 500, 2);
            ConfProd confProd2 = (ConfProd)confProd1.ShallowCopy();

            Assert.AreEqual(confProd1.Name, confProd2.Name);
            Assert.AreEqual(confProd1.Price, confProd2.Price);
            Assert.AreEqual(confProd1.id.Number, confProd2.id.Number);
            Assert.AreNotSame(confProd1, confProd2);
        }
        [TestMethod]
        public void Equals_ReturnsCorrectResult()
        {
            ConfProd confProd1 = new ConfProd("Торт", 500, 2);
            ConfProd confProd2 = new ConfProd("Торт", 500, 2);
            ConfProd confProd3 = new ConfProd("Пирожное", 400, 1);

            Assert.IsTrue(confProd1.Equals(confProd2));
            Assert.IsFalse(confProd1.Equals(confProd3));
        }
    }
}
