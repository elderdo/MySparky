using System;
namespace SparkyNUnitTest;

[TestFixture]
public class FiboNUnitTests
{
    private Fibo _fibo = new();
    [SetUp]
    public void SetUp()
    {
        _fibo = new();
    }

    [Test]
    public void Fibo_InputRange1_ReturnsOneEntryList()
    {
        // Arrange
        _fibo.Range = 1;
        // Act
        var result = _fibo.GetFiboSeries();
        // Assert
        Assert.That(result, Is.Not.Empty);
        Assert.That(result, Is.Ordered);
        var expectedResult = new List<int>() { 0 };
        Assert.That(result, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void Fibo_InputRange6_ReturnsListOf6()
    {
        // Arrange
        _fibo.Range = 6;
        // Act
        var result = _fibo.GetFiboSeries();
        // Assert
        Assert.That(result, Does.Contain(3));
        Assert.That(result, Has.Count.EqualTo(6));
        Assert.That(result, Has.No.Member(4));
        var expectedResult = new List<int>() { 0, 1, 1, 2, 3, 5 };
        Assert.That(result, Is.EquivalentTo(expectedResult));

    }

}

