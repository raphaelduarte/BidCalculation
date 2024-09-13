using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Tests.UniTests;

public class LuxurySpecialFeeTests
{
    [Theory]
    [InlineData(100, 4)]      // Test where basePrice is 100, 4% of 100 is 4
    [InlineData(500, 20)]     // Test where basePrice is 500, 4% of 500 is 20
    [InlineData(1000, 40)]    // Test where basePrice is 1000, 4% of 1000 is 40
    [InlineData(50, 2)]       // Test where basePrice is 50, 4% of 50 is 2
    [InlineData(0, 0)]        // Test for basePrice of 0, should return 0 fee
    [InlineData(-100, -4)]    // Test for negative basePrice, should return -4 (4% of basePrice)
    public void Calc_ShouldReturnCorrectAmount_WhenBasePriceIsGiven(decimal basePrice, decimal expectedFee)
    {
        // Arrange
        var luxurySpecialFee = new LuxurySpecialFee();

        // Act
        var fee = luxurySpecialFee.Calc(basePrice);

        // Assert
        Assert.Equal(expectedFee, fee.Amount);
        Assert.Equal(FeeType.Special, fee.FeeType);
    }
}