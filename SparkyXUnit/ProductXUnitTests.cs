﻿namespace Sparky;

public class ProductXUnitTests
{
    [Fact]
    public void GetProductPrice_PlatinumCustomer_ReturnPriceWith20Discount()
    {
        Product product = new Product() { Price = 50 };

        var result = product.GetPrice(new Customer() { IsPlatinum = true });

        result.Should().Be(40);
    }

    [Fact]
    public void GetProductPriceMOQAbuse_PlatinumCustomer_ReturnPriceWith20Discount()
    {
        var customer = new Mock<ICustomer>();
        customer.Setup(u => u.IsPlatinum).Returns(true);

        Product product = new Product() { Price = 50 };

        var result = product.GetPrice(customer.Object);

        result.Should().Be(40);
    }
}
