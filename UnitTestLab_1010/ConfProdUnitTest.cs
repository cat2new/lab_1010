using ClassLibrary1;
using ConfLib;

namespace UnitTestLab_1010;

[TestClass]
public sealed class ConfProdUnitTest
{
    [TestMethod]
    public void DefaultConstructor_InitializesCorrectly()
    {
        // Arrange
        ConfProd confProd = new ConfProd();

        // Act & Assert
        Assert.AreEqual("", confProd.Name);
        Assert.AreEqual(0, confProd.Price);
        Assert.IsNotNull(confProd.id);
    }

    [TestMethod]
    public void ParametrizedConstructor_InitializesCorrectly()
    {
        // Arrange
        ConfProd confProd = new ConfProd("Торт", 500.9, 1);

        // Act & Assert
        Assert.AreEqual("Торт", confProd.Name);
        Assert.AreEqual(500.9, confProd.Price);
        Assert.AreEqual(1, confProd.id.Number);
    }

    [TestMethod]
    public void Name_SetValidValue_Success()
    {
        // Arrange
        ConfProd confProd = new ConfProd();
        confProd.Name = "Изделие";

        // Act & Assert
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
        // Arrange
        ConfProd confProd = new ConfProd();
        confProd.Price = 300.0;

        // Act & Assert
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
        // Arrange
        ConfProd confProd1 = new ConfProd("Изделие 1", 500, 1);
        ConfProd confProd2 = new ConfProd("Изделие 2", 400, 2);

        // Act & Assert
        Assert.IsTrue(confProd1.CompareTo(confProd2) > 0);
        Assert.IsTrue(confProd2.CompareTo(confProd1) < 0);
        Assert.AreEqual(0, confProd1.CompareTo(confProd1));
    }
    [TestMethod]
    public void Compare_ReturnsCorrectResult()
    {
        // Arrange
        ConfProd confProd1 = new ConfProd("Изделие 1", 500, 1);
        ConfProd confProd2 = new ConfProd("Изделие 2", 400, 2);
        ConfProdComparer sc = new();

        // Act & Assert
        Assert.IsTrue(sc.Compare(confProd1, confProd2) < 0);
        Assert.IsTrue(sc.Compare(confProd2, confProd1) > 0);
        Assert.AreEqual(0, sc.Compare(confProd1, confProd1));
    }
    [TestMethod]
    public void Clone_CreatesDeepCopy()
    {
        // Arrange
        ConfProd confProd1 = new ConfProd("Торт", 500, 2);
        ConfProd confProd2 = (ConfProd)confProd1.Clone();

        // Act & Assert
        Assert.AreEqual(confProd1.Name, confProd2.Name);
        Assert.AreEqual(confProd1.Price, confProd2.Price);
        Assert.AreEqual(confProd1.id.Number, confProd2.id.Number);
        Assert.AreNotSame(confProd1, confProd2);
    }
    [TestMethod]
    public void ShallowCopy_CreatesShallowCopy()
    {
        // Arrange
        ConfProd confProd1 = new ConfProd("Торт", 500, 2);
        ConfProd confProd2 = (ConfProd)confProd1.ShallowCopy();

        // Act & Assert
        Assert.AreEqual(confProd1.Name, confProd2.Name);
        Assert.AreEqual(confProd1.Price, confProd2.Price);
        Assert.AreEqual(confProd1.id.Number, confProd2.id.Number);
        Assert.AreNotSame(confProd1, confProd2);
    }
    [TestMethod]
    public void Equals_ReturnsCorrectResult()
    {
        // Arrange
        ConfProd confProd1 = new ConfProd("Торт", 500, 2);
        ConfProd confProd2 = new ConfProd("Торт", 500, 2);
        ConfProd confProd3 = new ConfProd("Пирожное", 400, 1);

        // Act & Assert
        Assert.IsTrue(confProd1.Equals(confProd2));
        Assert.IsFalse(confProd1.Equals(confProd3));
    }

    [TestMethod]
    public void Clone_ModifyingCopy_DoesNotAffectOriginal()
    {
        // Arrange
        ConfProd confProd1 = new ConfProd("Торт", 500, 1);
        ConfProd confProd2 = (ConfProd)confProd1.Clone();

        // Act
        confProd2.Name = "Пирожное";
        confProd2.Price = 300;

        // Assert
        Assert.AreEqual("Торт", confProd1.Name);
        Assert.AreEqual(500, confProd1.Price);
        Assert.AreEqual("Пирожное", confProd2.Name);
        Assert.AreEqual(300, confProd2.Price);
    }

    [TestMethod]
    public void ShallowCopy_ModifyingCopy_DoesNotAffectOriginal()
    {
        // Arrange
        ConfProd confProd1 = new ConfProd("Торт", 500, 1);
        ConfProd confProd2 = (ConfProd)confProd1.ShallowCopy();

        // Act
        confProd2.Name = "Пирожное";
        confProd2.Price = 300;

        // Assert
        Assert.AreEqual("Торт", confProd1.Name);
        Assert.AreEqual(500, confProd1.Price);
        Assert.AreEqual("Пирожное", confProd2.Name);
        Assert.AreEqual(300, confProd2.Price);
    }

    [TestMethod]
    public void CompareTo_WithNull_ReturnsOne()
    {
        // Arrange
        ConfProd confProd = new ConfProd("Торт", 500, 1);

        // Act & Assert
        Assert.AreEqual(1, confProd.CompareTo(null));
    }
}
