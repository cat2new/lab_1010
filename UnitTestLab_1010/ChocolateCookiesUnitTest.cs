using ClassLibrary1;
using System.Net;

namespace UnitTestLab_1010;

[TestClass]
public class ChocolateCookiesUnitTest
{
    [TestMethod]
    public void DefaultConstructor_InitializesCorrectly()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();

        // Act & Assert
        Assert.AreEqual("", cookies.Name);
        Assert.AreEqual(0, cookies.Price);
        Assert.IsNotNull(cookies.id);
        Assert.AreEqual("", cookies.Chocoolate);

    }

    [TestMethod]
    public void ParametrizedConstructor_InitializesCorrectly()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies("Печенье", 500.9, "Форма", "Шоколад", 1);

        // Act & Assert
        Assert.AreEqual("Печенье", cookies.Name);
        Assert.AreEqual(500.9, cookies.Price);
        Assert.AreEqual("Шоколад", cookies.Chocoolate);
        Assert.AreEqual(1, cookies.id.Number);
    }

    [TestMethod]
    public void Chocolate_SetValidValue_Success()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();
        cookies.Chocoolate = "Молочный";

        // Act & Assert
        Assert.AreEqual("Молочный", cookies.Chocoolate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Chocolate_SetInvalidValue_ThrowsException()
    {
        ChocolateCookies cookies = new ChocolateCookies();
        cookies.Chocoolate = "Квадрат";
    }

    [TestMethod]
    public void Equals_ReturnsCorrectResult()
    {
        // Arrange
        ChocolateCookies cookies1 = new ChocolateCookies("Печенье", 500, "Форма", "Шоколад", 1);
        ChocolateCookies cookies2 = new ChocolateCookies("Печенье", 500, "Форма", "Шоколад", 1);
        ChocolateCookies cookies3 = new ChocolateCookies("Печенье", 400, "Форма", "Шоколад", 2);

        // Act & Assert
        Assert.IsTrue(cookies1.Equals(cookies2));
        Assert.IsFalse(cookies1.Equals(cookies3));
    }
    [TestMethod]
    public void Equals_WithDifferentObject_ReturnsFalse()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies("Печенье", 500, "Форма", "Шоколад", 1);
        object otherObject = new object();

        // Act & Assert
        Assert.IsFalse(cookies.Equals(otherObject));
    }
    [TestMethod]
    public void Equals_WithNull_ReturnsFalse()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies("Печенье", 500, "Форма", "Шоколад", 1);

        // Act & Assert
        Assert.IsFalse(cookies.Equals(null));
    }
    [TestMethod]
    public void Chocolate_SetDarkChocolate_Success()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();

        // Act
        cookies.Chocoolate = "Темный";

        // Assert
        Assert.AreEqual("Темный", cookies.Chocoolate);
    }

    [TestMethod]
    public void Chocolate_SetWhiteChocolate_Success()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();

        // Act
        cookies.Chocoolate = "Белый";

        // Assert
        Assert.AreEqual("Белый", cookies.Chocoolate);
    }
}
