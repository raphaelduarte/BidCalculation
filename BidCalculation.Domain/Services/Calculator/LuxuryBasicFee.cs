using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Services.Calculator;

public class LuxuryBasicFee : IFeeCalculation
{
    public Fee Calc(decimal basePrice)
        => new Fee() { Amount = GetAmount(basePrice), FeeType = FeeType.Basic };
    private static decimal GetAmount(decimal basePrice)
        => Math.Max(25, Math.Min(basePrice * 0.10m, 200));
}