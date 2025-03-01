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
        ChocolateCookies cookies = new ChocolateCookies("�������", 500.9, "�����", "�������", 1);

        // Act & Assert
        Assert.AreEqual("�������", cookies.Name);
        Assert.AreEqual(500.9, cookies.Price);
        Assert.AreEqual("�������", cookies.Chocoolate);
        Assert.AreEqual(1, cookies.id.Number);
    }

    [TestMethod]
    public void Chocolate_SetValidValue_Success()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();
        cookies.Chocoolate = "��������";

        // Act & Assert
        Assert.AreEqual("��������", cookies.Chocoolate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Chocolate_SetInvalidValue_ThrowsException()
    {
        ChocolateCookies cookies = new ChocolateCookies();
        cookies.Chocoolate = "�������";
    }

    [TestMethod]
    public void Equals_ReturnsCorrectResult()
    {
        // Arrange
        ChocolateCookies cookies1 = new ChocolateCookies("�������", 500, "�����", "�������", 1);
        ChocolateCookies cookies2 = new ChocolateCookies("�������", 500, "�����", "�������", 1);
        ChocolateCookies cookies3 = new ChocolateCookies("�������", 400, "�����", "�������", 2);

        // Act & Assert
        Assert.IsTrue(cookies1.Equals(cookies2));
        Assert.IsFalse(cookies1.Equals(cookies3));
    }
    [TestMethod]
    public void Equals_WithDifferentObject_ReturnsFalse()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies("�������", 500, "�����", "�������", 1);
        object otherObject = new object();

        // Act & Assert
        Assert.IsFalse(cookies.Equals(otherObject));
    }
    [TestMethod]
    public void Equals_WithNull_ReturnsFalse()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies("�������", 500, "�����", "�������", 1);

        // Act & Assert
        Assert.IsFalse(cookies.Equals(null));
    }
    [TestMethod]
    public void Chocolate_SetDarkChocolate_Success()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();

        // Act
        cookies.Chocoolate = "������";

        // Assert
        Assert.AreEqual("������", cookies.Chocoolate);
    }

    [TestMethod]
    public void Chocolate_SetWhiteChocolate_Success()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();

        // Act
        cookies.Chocoolate = "�����";

        // Assert
        Assert.AreEqual("�����", cookies.Chocoolate);
    }
}
