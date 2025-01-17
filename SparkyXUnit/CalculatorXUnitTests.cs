﻿namespace Sparky;

public class CalculatorXUnitTests
{
    [Fact]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        //Arrange
        Calculator calc = new();

        //Act
        int result = calc.AddNumbers(10, 20);


        //Assert
        Assert.Equal(30, result);
    }

    [Fact]
    public void IsOddChecker_InputEvenNumber_ReturnFalse()
    {
        Calculator calc = new();

        bool isOdd = calc.IsOddNumber(10);
        //Assert.That(isOdd, Is.EqualTo(false));
        Assert.False(isOdd);
    }

    [Theory]
    [InlineData(11)]
    [InlineData(13)]
    public void IsOddChecker_InputOddNumber_ReturnTrue(int a)
    {
        Calculator calc = new();

        bool isOdd = calc.IsOddNumber(a);
        //Assert.That(isOdd, Is.EqualTo(true));
        Assert.True(isOdd);
    }

    [Theory]
    [InlineData(10, false)]
    [InlineData(11, true)]
    public void IsOddChecker_InputNumber_ReturnTrueIfOdd(int a, bool expectedResult)
    {
        Calculator calc = new();
        var result = calc.IsOddNumber(a);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(5.4, 10.5)] //15.9
    [InlineData(5.43, 10.53)] // 15.93
    [InlineData(5.49, 10.59)] // 16.08
    public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
    {
        //Arrange
        Calculator calc = new();

        //Act
        double result = calc.AddNumbersDouble(a, b);


        //Assert
        Assert.Equal(15.9, result, .2);
        //15.7-16.1
    }


    [Fact]
    public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
    {
        Calculator calc = new();
        List<int> expectedOddRange = new() { 5, 7, 9 }; //5-10

        //act
        List<int> result = calc.GetOddRanage(5, 10);

        //Assert
        result.Should().NotBeEmpty()
            .And.HaveCount(3)
            .And.Contain(7)
            .And.OnlyHaveUniqueItems()
            .And.ContainInOrder()
            .And.NotContain(6)
            .And.Equal(expectedOddRange);

    }
}
