
namespace SparkyNUnitTest;

[TestFixture]
public class GradingCalculatorNUnitTests
{
    private GradingCalculator? _gradingCalculator = null;
    [SetUp]
    public void SetUp()
    {
        _gradingCalculator = new GradingCalculator();
    }
    [Test]
    [TestCase(95, 90, ExpectedResult = "A")]
    [TestCase(85, 90, ExpectedResult = "B")]
    [TestCase(65, 90, ExpectedResult = "C")]
    [TestCase(95, 65, ExpectedResult = "B")]
    [TestCase(95, 55, ExpectedResult = "F")]
    [TestCase(65, 55, ExpectedResult = "F")]
    [TestCase(50, 90, ExpectedResult = "F")]
    public string? GradingCalculator_ScoreAttendance_ReturnsGrade(int score, int attendance)
    {
        // Arrange
        if (_gradingCalculator != null)
        {
            _gradingCalculator.AttendancePercentage = attendance;
            _gradingCalculator.Score = score;
        }
        // Act
        return _gradingCalculator?.GetGrade();
    }

}

