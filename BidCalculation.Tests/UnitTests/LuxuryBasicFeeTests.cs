using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Tests.UniTests;

public class LuxuryBasicFeeTests
{
    [Theory]
    [InlineData(100, 25)]     // Test where 10% of basePrice is less than the minimum fee (25)
    [InlineData(250, 25)]     // Test where 10% of basePrice equals the minimum fee (25)
    [InlineData(300, 30)]     // Test where 10% of basePrice is between 25 and 200
    [InlineData(500, 50)]     // Test where 10% of basePrice is 50, valid between limits
    [InlineData(2500, 200)]   // Test where 10% of basePrice exceeds the maximum fee (200)
    [InlineData(5000, 200)]   // Test where basePrice exceeds the max limit, should be capped at 200
    [InlineData(0, 25)]       // Test for basePrice of 0, should return the minimum fee (25)
    [InlineData(-100, 25)]    // Test for negative basePrice, should still return the minimum fee (25)
    public void Calc_ShouldReturnCorrectAmount_WhenBasePriceIsGiven(decimal basePrice, decimal expectedFee)
    {
        // Arrange
        var luxuryBasicFee = new LuxuryBasicFee();

        // Act
        var fee = luxuryBasicFee.Calc(basePrice);

        // Assert
        Assert.Equal(expectedFee, fee.Amount);
        Assert.Equal(FeeType.Basic, fee.FeeType);
    }
}