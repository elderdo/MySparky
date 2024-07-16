namespace Sparky;
public class FiboXUnitTests
{
    [Fact]
    public void FiboChecker_Input1_ReturnsFiboSeries()
    {
        List<int> expectedRange = new() { 0 };

        Fibo fibo = new();
        fibo.Range = 1;

        List<int> result = fibo.GetFiboSeries();

        result.Should().NotBeEmpty();
        result.Should().ContainInOrder(new[] { 0 });
        result.Should().BeEquivalentTo(expectedRange);
    }

    [Fact]
    public void FiboChecker_Input6_ReturnsFiboSeries()
    {
        List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };

        Fibo fibo = new();
        fibo.Range = 6;

        List<int> result = fibo.GetFiboSeries();

        result.Should().Contain(3);
        result.Should().HaveCount(6);
        result.Should().NotContain(4);
        result.Should().BeEquivalentTo(expectedRange);
    }
}
