using BidCalculation.Domain.Strategies;
using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.Application.Factories;

public class FeeCalculatorFactory
{
    private readonly CommonVehicleFeeCalculator _commonFeeCalculator;
    private readonly LuxuryVehicleFeeCalculator _luxuryFeeCalculator;

    public FeeCalculatorFactory(
        CommonVehicleFeeCalculator commonFeeCalculator,
        LuxuryVehicleFeeCalculator luxuryFeeCalculator)
    {
        _commonFeeCalculator = commonFeeCalculator;
        _luxuryFeeCalculator = luxuryFeeCalculator;
    }

    public IFeeCalculator Create(VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.Luxury => _luxuryFeeCalculator,
            VehicleType.Common => _commonFeeCalculator,
            _ => throw new ArgumentException("Invalid vehicle type")
        };
    }
}