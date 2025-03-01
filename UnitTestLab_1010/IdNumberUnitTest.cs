using ConfLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestLab_1010
{
    [TestClass]
    public class IdNumberUnitTest
    {
        [TestMethod]
        public void DefaultConstructor_InitializesCorrectly()
        {
            // Arrange & Act
            IdNumber id = new IdNumber();

            // Assert
            Assert.AreEqual(0, id.Number);

        }

        [TestMethod]
        public void ParametrizedConstructor_InitializesCorrectly()
        {
            // Arrange & Act
            IdNumber id = new IdNumber(10);

            // Assert
            Assert.AreEqual(10, id.Number);
        }

        [TestMethod]
        public void Number_SetValidValue_Success()
        {
            // Arrange
            IdNumber id = new IdNumber();

            // Act
            id.Number = 5;

            // Assert
            Assert.AreEqual(5, id.Number);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Number_SetNegativeValue_ThrowsException()
        {
            // Arrange
            IdNumber id = new IdNumber();

            // Act
            id.Number = -1;
        }

        [TestMethod]
        public void Equals_WithSameValues_ReturnsTrue()
        {
            // Arrange
            IdNumber id1 = new IdNumber(5);
            IdNumber id2 = new IdNumber(5);

            // Act & Assert
            Assert.IsTrue(id1.Equals(id2));
        }
    }
}
