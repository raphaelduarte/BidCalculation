using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Services;
using Xunit;

namespace BidCalculation.Tests.UniTests;

public class CalculationServiceTests
{
    [Theory]
    [InlineData(VehicleType.Common, 398, 550.76, 39.80, 7.96, 5.00, 100.00)]
    [InlineData(VehicleType.Common, 501, 671.02, 50.00, 10.02, 10.00, 100.00)]
    [InlineData(VehicleType.Common, 57, 173.14, 10.00, 1.14, 5.00, 100.00)]
    [InlineData(VehicleType.Luxury, 1800, 2167.00, 180.00, 72.00, 15.00, 100.00)]
    [InlineData(VehicleType.Common, 1100, 1287.00, 50.00, 22.00, 15.00, 100.00)]
    [InlineData(VehicleType.Luxury, 1000000, 1040320.00, 200.00, 40000.00, 20.00, 100.00)]
    public void Calculate_ShouldReturnValid_WhenParametersIsValid(
        VehicleType vehicleType, 
        decimal basePrice, 
        decimal totalCost,
        decimal basicFee,
        decimal specialFee,
        decimal associationFee,
        decimal storageFee
    )
    {
        // Arrange
        var service = new CalculationService();

        // Act
        var result = service.CalculateFee(vehicleType, basePrice);

        // Assert
        Assert.Equal(totalCost, result.TotalCost);
        Assert.Equal(basicFee, result.Fees.Single(x => x.FeeType == FeeType.Basic).Amount);
        Assert.Equal(specialFee, result.Fees.Single(x => x.FeeType == FeeType.Special).Amount);
        Assert.Equal(associationFee, result.Fees.Single(x => x.FeeType == FeeType.Association).Amount);
        Assert.Equal(storageFee, result.Fees.Single(x => x.FeeType == FeeType.Storage).Amount);
    }


    [Theory]
    [MemberData(nameof(CalculationServiceTests.GetInvalidData), MemberType = typeof(CalculationServiceTests))]
    public void Calculate_ShouldReturnInvalid_WhenParametersIsInvalid(
        VehicleType vehicleType,
        decimal basePrice,
        decimal totalCost,
        decimal basicFee,
        decimal specialFee,
        decimal associationFee,
        decimal storageFee
    )
    {
        // Arrange
        var service = new CalculationService();

        // Act
        var result = service.CalculateFee(vehicleType, basePrice);

        // Assert
        //Assert.Equal(totalCost, result.TotalCost);
        //Assert.Equal(basicFee, result.Fees.Single(x => x.FeeType == FeeType.Basic).Amount);
        //Assert.Equal(specialFee, result.Fees.Single(x => x.FeeType == FeeType.Special).Amount);
        //Assert.Equal(associationFee, result.Fees.Single(x => x.FeeType == FeeType.Association).Amount);
        //Assert.Equal(storageFee, result.Fees.Single(x => x.FeeType == FeeType.Storage).Amount);
        
        //Assert.False(Equals(totalCost, result.TotalCost));
        //Assert.False(Equals(basicFee, result.Fees.Single(x => x.FeeType == FeeType.Basic).Amount));
        //Assert.False(Equals(specialFee, result.Fees.Single(x => x.FeeType == FeeType.Special).Amount));
        //Assert.False(Equals(associationFee, result.Fees.Single(x => x.FeeType == FeeType.Association).Amount));
        //Assert.False(Equals(storageFee, result.Fees.Single(x => x.FeeType == FeeType.Storage).Amount));

        Assert.NotEqual(totalCost , result.TotalCost);
        Assert.NotEqual(basicFee , result.Fees.Single(x => x.FeeType == FeeType.Basic).Amount);
        Assert.NotEqual(specialFee, result.Fees.Single(x => x.FeeType == FeeType.Special).Amount);

        Assert.NotEqual(associationFee, result.Fees.Single(x => x.FeeType == FeeType.Association).Amount);
        Assert.NotEqual(storageFee, result.Fees.Single(x => x.FeeType == FeeType.Storage).Amount);
    }
        


    public static IEnumerable<object[]> GetInvalidData()
    {
        yield return new object[] { VehicleType.Common, 0, 550.76M, 39.80M, 7.96M, 5.00M, 100.00M };
        yield return new object[] { VehicleType.Common, 0, 550.76M, 39.80M, 7.96M, 5.00M, 100.00M };
        yield return new object[] { VehicleType.Common, -1100, 671.02M, 50.00M, 10.02M, 10.00M, 100.00M };
        yield return new object[] { VehicleType.Common, decimal.MinValue, 173.14, 10.00, 1.14, 5.00, 100.00 };
        yield return new object[] { VehicleType.Luxury, decimal.MaxValue, 2167.00, 180.00, 72.00, 15.00, 100.00 };
    }
}