namespace BidCalculation.Domain.Strategies;

public class CommonVehicleFeeCalculator : IFeeCalculator
{
    public decimal CalculateFee(decimal basePrice)
    {
        return basePrice * 0.02m;
    }
}