
namespace SparkyNUnitTest;
[TestFixture]
public class CalculatorNUnitTests
{
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange
        Calculator calc = new();
        // Act
        int result = calc.AddNumbers(10, 20);
        // Assert
        ClassicAssert.AreEqual(30, result);
    }

    [Test]
    [TestCase(5.4, 10.5)] // 10.9
    [TestCase(5.43, 10.53)] // 10.96
    [TestCase(5.49, 10.59)] // 16.08
    public void AddNumbersDouble_InputTwoDoubles_GetCorrectAddition(double a, double b)
    {
        // Arrange
        Calculator calc = new();
        // Act
        double result = calc.AddNumbersDouble(a, b);
        // Assert
        ClassicAssert.AreEqual(15.9, result, 1);
    }

    [Test]
    [TestCase(11)]
    [TestCase(13)]
    public void IsOdd_InputOneOddInt_ReturnTrue(int a)
    {
        // Arrange
        Calculator calc = new();
        // Act
        bool result = calc.IsOddNumber(a);
        // Assert
        ClassicAssert.IsTrue(result);
    }

    [Test]
    [TestCase(11, ExpectedResult = true)]
    [TestCase(13, ExpectedResult = true)]
    [TestCase(14, ExpectedResult = false)]
    public bool IsOdd_ReturnTrueIfOdd(int a)
    {
        // Arrange
        Calculator calc = new();
        // Act & Assert
        return calc.IsOddNumber(a);
    }


    [Test]
    public void IsOdd_InputOneEvenInt_ReturnFalse()
    {
        // Arrange
        Calculator calc = new();
        // Act
        bool result = calc.IsOddNumber(2);
        // Assert
        ClassicAssert.IsFalse(result);
    }

    [Test]
    public void OddRanger_InputMixMaxRanage_ReturnsValidOddNumberRanage()
    {
        // Arrange
        Calculator calc = new();
        List<int> expectedOddRange = new() { 5, 7, 9 }; // 5-10
        // Act
        List<int> result = calc.GetOddRanage(5, 10);
        // Assert
        Assert.That(result, Is.EquivalentTo(expectedOddRange));
        // Assert.Contains(7,result);
        Assert.That(result, Does.Contain(7));
        Assert.That(result, Is.Not.Empty);
        Assert.That(result.Count, Is.EqualTo(3));
        Assert.That(result, Has.No.Member(6));
        Assert.That(result, Is.Ordered);
        Assert.That(result, Is.Unique);
    }
}