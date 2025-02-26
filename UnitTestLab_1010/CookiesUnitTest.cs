using ClassLibrary1;

namespace UnitTestLab_1010;

[TestClass]
public class CookiesUnitTest
{
    [TestMethod]
    public void DefaultConstructor_InitializesCorrectly()
    {
        Cookies cookie = new Cookies();

        Assert.AreEqual("", cookie.Name);
        Assert.AreEqual(0, cookie.Price);
        Assert.IsNotNull(cookie.id);
        Assert.AreEqual("", cookie.Shape);

    }

    [TestMethod]
    public void ParametrizedConstructor_InitializesCorrectly()
    {
        Cookies cookie = new Cookies("�������", 500.9, "����", 1);

        Assert.AreEqual("�������", cookie.Name);
        Assert.AreEqual(500.9, cookie.Price);
        Assert.AreEqual("����", cookie.Shape);
        Assert.AreEqual(1, cookie.id.Number);
    }
    [TestMethod]
    public void Shape_SetValidValue_Success()
    {
        Cookies cookie = new Cookies();
        cookie.Shape = "����";

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
        Cookies cookie1 = new Cookies("�������", 500, "����", 1);
        Cookies cookies2 = new Cookies("�������", 500, "����", 1);
        Cookies cookies3 = new Cookies("�������", 400, "������", 4);


        Assert.IsTrue(cookie1.Equals(cookies2));
        Assert.IsFalse(cookie1.Equals(cookies3));
    }
}
