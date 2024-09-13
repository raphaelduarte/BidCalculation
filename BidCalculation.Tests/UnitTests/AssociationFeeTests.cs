using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Tests.UniTests;

public class AssociationFeeTests
{
    [Theory]
    [InlineData(1, 5)]       // Test for basePrice between 1 and 500
    [InlineData(500, 5)]     // Test lower limit 500
    [InlineData(501, 10)]    // Test upper limit of 500, with basePrice > 500 up to 1000
    [InlineData(1000, 10)]   // Test limit of 1000
    [InlineData(1001, 15)]   // Test upper limit of 1000, with basePrice > 1000 up to 3000
    [InlineData(3000, 15)]   // Test limit of 3000
    [InlineData(3001, 20)]   // Test for basePrice greater than 3000
    [InlineData(0, 0)]       // Test for basePrice equal to 0 (invalid)
    [InlineData(-100, 0)]    // Test for negative basePrice (invalid)
    public void Calc_ShouldReturnCorrectAmount_WhenBasePriceIsGiven(decimal basePrice, decimal expectedFee)
    {
        // Arrange
        var associationFee = new AssociationFee();

        // Act
        var fee = associationFee.Calc(basePrice);

        // Assert
        Assert.Equal(expectedFee, fee.Amount);
        Assert.Equal(FeeType.Association, fee.FeeType);
    }
}