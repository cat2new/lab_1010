using ClassLibrary1;

namespace UnitTestLab_1010;

[TestClass]
public class CookiesUnitTest
{
    [TestMethod]
    public void DefaultConstructor_InitializesCorrectly()
    {
        // Arrange
        Cookies cookie = new Cookies();

        // Act & Assert
        Assert.AreEqual("", cookie.Name);
        Assert.AreEqual(0, cookie.Price);
        Assert.IsNotNull(cookie.id);
        Assert.AreEqual("", cookie.Shape);

    }

    [TestMethod]
    public void ParametrizedConstructor_InitializesCorrectly()
    {
        // Arrange
        Cookies cookie = new Cookies("�������", 500.9, "����", 1);

        // Act & Assert
        Assert.AreEqual("�������", cookie.Name);
        Assert.AreEqual(500.9, cookie.Price);
        Assert.AreEqual("����", cookie.Shape);
        Assert.AreEqual(1, cookie.id.Number);
    }

    [TestMethod]
    public void Shape_SetValidValue_Success()
    {
        // Arrange
        Cookies cookie = new Cookies();
        cookie.Shape = "����";

        // Act & Assert
        Assert.AreEqual("����", cookie.Shape);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Shape_SetNegativeValue_ThrowsException()
    {
        Cookies cookies = new Cookies();
        cookies.Shape = "";
    }

    [TestMethod]
    public void Equals_ReturnsCorrectResult()
    {
        // Arrange
        Cookies cookie1 = new Cookies("�������", 500, "����", 1);
        Cookies cookies2 = new Cookies("�������", 500, "����", 1);
        Cookies cookies3 = new Cookies("�������", 400, "������", 4);

        // Act & Assert
        Assert.IsTrue(cookie1.Equals(cookies2));
        Assert.IsFalse(cookie1.Equals(cookies3));
    }
}
