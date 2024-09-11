namespace BidCalculation.Domain.Strategies;

public class LuxuryVehicleFeeCalculator : IFeeCalculator
{
    public decimal CalculateFee(decimal basePrice)
    {
        return basePrice * 0.05m;
    }
}