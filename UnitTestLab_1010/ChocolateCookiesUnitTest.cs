using ClassLibrary1;
using System.Net;

namespace UnitTestLab_1010;

[TestClass]
public class ChocolateCookiesUnitTest
{
    [TestMethod]
    public void DefaultConstructor_InitializesCorrectly()
    {
        ChocolateCookies cookies = new ChocolateCookies();

        Assert.AreEqual("", cookies.Name);
        Assert.AreEqual(0, cookies.Price);
        Assert.IsNotNull(cookies.id);
        Assert.AreEqual("", cookies.Chocoolate);

    }

    [TestMethod]
    public void ParametrizedConstructor_InitializesCorrectly()
    {
        ChocolateCookies cookies = new ChocolateCookies("�������", 500.9, "�����", "�������", 1);

        Assert.AreEqual("�������", cookies.Name);
        Assert.AreEqual(500.9, cookies.Price);
        Assert.AreEqual("�������", cookies.Chocoolate);
        Assert.AreEqual(1, cookies.id.Number);
    }
    [TestMethod]
    public void Chocolate_SetValidValue_Success()
    {
        ChocolateCookies cookies = new ChocolateCookies();
        cookies.Chocoolate = "��������";

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
        ChocolateCookies cookies1 = new ChocolateCookies("�������", 500, "�����", "�������", 1);
        ChocolateCookies cookies2 = new ChocolateCookies("�������", 500, "�����", "�������", 1);
        ChocolateCookies cookies3 = new ChocolateCookies("�������", 400, "�����", "�������", 2);


        Assert.IsTrue(cookies1.Equals(cookies2));
        Assert.IsFalse(cookies1.Equals(cookies3));
    }
    [TestMethod]
    public void Equals_WithDifferentObject_ReturnsFalse()
    {

        ChocolateCookies cookies = new ChocolateCookies("�������", 500, "�����", "�������", 1);
        object otherObject = new object();


        Assert.IsFalse(cookies.Equals(otherObject));
    }
    [TestMethod]
    public void Equals_WithNull_ReturnsFalse()
    {
       
        ChocolateCookies cookies = new ChocolateCookies("�������", 500, "�����", "�������", 1);

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
    [TestMethod]
    public void RandomInit_SetsChocolateCorrectly()
    {
        // Arrange
        ChocolateCookies cookies = new ChocolateCookies();

        // Act
        cookies.RandomInit();

        // Assert
        Assert.IsTrue(cookies.Chocoolate == "��������" || cookies.Chocoolate == "������" || cookies.Chocoolate == "�����");
    }

}
