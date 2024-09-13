using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Tests.UniTests;

public class CommonSpecialFeeTests
{
    [Theory]
    [InlineData(100, 2)]      // Test where basePrice is 100, 2% of 100 is 2
    [InlineData(500, 10)]     // Test where basePrice is 500, 2% of 500 is 10
    [InlineData(1000, 20)]    // Test where basePrice is 1000, 2% of 1000 is 20
    [InlineData(50, 1)]       // Test where basePrice is 50, 2% of 50 is 1
    [InlineData(0, 0)]        // Test for basePrice of 0, should return 0 fee
    [InlineData(-100, -2)]    // Test for negative basePrice, should return -2 (2% of basePrice)
    public void Calc_ShouldReturnCorrectAmount_WhenBasePriceIsGiven(decimal basePrice, decimal expectedFee)
    {
        // Arrange
        var commonSpecialFee = new CommonSpecialFee();

        // Act
        var fee = commonSpecialFee.Calc(basePrice);

        // Assert
        Assert.Equal(expectedFee, fee.Amount);
        Assert.Equal(FeeType.Special, fee.FeeType);
    }
}