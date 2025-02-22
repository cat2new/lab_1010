using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject4
{
    [TestClass]
    public class CakeUnitTest
    {
        [TestMethod]
        public void DefaultConstructor_InitializesCorrectly()
        {
            Cakes cake = new Cakes();

            Assert.AreEqual("", cake.Name);
            Assert.AreEqual(0, cake.Price);
            Assert.IsNotNull(cake.id);
            Assert.AreEqual(0, cake.Layers);

        }

        [TestMethod]
        public void ParametrizedConstructor_InitializesCorrectly()
        {
            Cakes cake = new Cakes("Торт", 500.9, 2, 1);

            Assert.AreEqual("Торт", cake.Name);
            Assert.AreEqual(500.9, cake.Price);
            Assert.AreEqual(2, cake.Layers);
            Assert.AreEqual(1, cake.id.Number);
        }
        [TestMethod]
        public void Layers_SetValidValue_Success()
        {
            Cakes cake = new Cakes();
            cake.Layers = 2;

            Assert.AreEqual(2, cake.Layers);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Layers_SetInvalidValue_ThrowsException()
        {
            Cakes cake = new Cakes();
            cake.Layers = -3;
        }
        [TestMethod]
        public void Equals_ReturnsCorrectResult()
        {
            Cakes cake1 = new Cakes("Торт", 500, 2, 1);
            Cakes cake2 = new Cakes("Торт", 500, 2, 1);
            Cakes cake3 = new Cakes("Торт", 400, 1, 2);


            Assert.IsTrue(cake1.Equals(cake2));
            Assert.IsFalse(cake1.Equals(cake3));
        }
        
    }
}
