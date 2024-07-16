
namespace SparkyNUnitTest;

[TestFixture]
public class CustomerNUnitTests
{
    Customer? _customer;
    [SetUp]
    public void Setup()
    {
        _customer = new Customer();

    }

    [Test]
    public void CombineName_InputFirstAndLastName_ReturnFullName()
    {
        // Arrange
        var customer = new Customer();
        // Act
        string fullName = customer.GreetAndCombineNames("Ben", "Spark");
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(fullName, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(fullName, Does.Contain("ben Spark").IgnoreCase);
            Assert.That(fullName, Does.StartWith("Hello,"));
            Assert.That(fullName, Does.EndWith("Spark"));
            Assert.That(fullName, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
        });
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnsNull()
    {
        // Arranage
        // Act
        // Assert
        ClassicAssert.IsNull(_customer?.GreetMessage);

    }

    [Test]
    public void DiscountCheck_DefaultCustomer_ReturnsDiscountInRange()
    {
        // Arrange
        // Act
        int? result = _customer?.Discount;
        Assert.That(result, Is.InRange(10, 25));
    }

    [Test]
    public void GreetMessage_GreetedWithoutLastName_ReturnsNotNull()
    {
        _customer?.GreetAndCombineNames("ben", "");
        ClassicAssert.IsNotNull(_customer?.GreetMessage);
        ClassicAssert.IsFalse(string.IsNullOrEmpty(_customer?.GreetMessage));
    }

    [Test]
    public void GreetChecker_EmptyFirstName_ThrowsException()
    {
        var exceptionDetails =
            Assert.Throws<ArgumentException>(() =>
                _customer?.GreetAndCombineNames("", "Spark"));
        ClassicAssert.AreEqual("Empty First Name.", exceptionDetails?.Message);
        Assert.That(() => _customer?.GreetAndCombineNames("", "Spark"),
            Throws.ArgumentException.With.Message.EqualTo("Empty First Name."));
        Assert.That(() => _customer?.GreetAndCombineNames("", "Spark"),
            Throws.ArgumentException);
    }

    public int? GetOrderTotal()
    {
        return _customer?.OrderTotal;
    }

    [Test]
    public void CustomerType_CreateCustomerWithLessThan100Order_ReturnsBasicCustomer()
    {
        if (_customer != null)
        {
            _customer.OrderTotal = 10;
            var result = _customer?.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }


    }
    [Test]
    public void CustomerType_CreateCustomerWithMoreThan100Order_ReturnsBPlatinumCustomer()
    {
        _customer.OrderTotal = 101;
        var result = _customer?.GetCustomerDetails();
        Assert.That(result, Is.TypeOf<PlatinumCustomer>());

    }
}

