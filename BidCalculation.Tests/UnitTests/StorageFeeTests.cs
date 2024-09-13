using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Tests.UniTests;

public class StorageFeeTests
{
    [Theory]
    [InlineData(100)]       // Test with basePrice of 100
    [InlineData(500)]       // Test with basePrice of 500
    [InlineData(1000)]      // Test with basePrice of 1000
    [InlineData(0)]         // Test with basePrice of 0
    [InlineData(-100)]      // Test with negative basePrice (-100)
    public void Calc_ShouldReturnCorrectAmount_WhenBasePriceIsGiven(decimal basePrice)
    {
        // Arrange
        var storageFee = new StorageFee();

        // Act
        var fee = storageFee.Calc(basePrice);

        // Assert
        Assert.Equal(100.00m, fee.Amount); // Always expect the fee to be 100.00
        Assert.Equal(FeeType.Storage, fee.FeeType); // FeeType should be Storage
    }
}