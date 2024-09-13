using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Tests.UniTests;

public class CommonBasicFeeTests
{
    [Theory]
    [InlineData(50, 10)]      // Test where 10% of basePrice is less than the minimum fee (10)
    [InlineData(100, 10)]     // Test where 10% of basePrice equals the minimum fee (10)
    [InlineData(500, 50)]     // Test where 10% of basePrice exceeds the maximum fee (50)
    [InlineData(300, 30)]     // Test where 10% of basePrice is between the minimum (10) and maximum (50)
    [InlineData(600, 50)]     // Test where 10% of basePrice would exceed 50, but is capped at 50
    [InlineData(0, 10)]       // Test for basePrice of 0, should return minimum fee (10)
    [InlineData(-100, 10)]    // Test for negative basePrice, should still return minimum fee (10)
    public void Calc_ShouldReturnCorrectAmount_WhenBasePriceIsGiven(decimal basePrice, decimal expectedFee)
    {
        // Arrange
        var commonBasicFee = new CommonBasicFee();

        // Act
        var fee = commonBasicFee.Calc(basePrice);

        // Assert
        Assert.Equal(expectedFee, fee.Amount);
        Assert.Equal(FeeType.Basic, fee.FeeType);
    }
}