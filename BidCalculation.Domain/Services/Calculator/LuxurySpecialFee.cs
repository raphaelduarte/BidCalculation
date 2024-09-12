using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Services.Calculator;

public class LuxurySpecialFee : IFeeCalculation
{
    public Fee Calc(decimal basePrice)
        => new Fee() { Amount = GetAmount(basePrice), FeeType = FeeType.Special };
    private static decimal GetAmount(decimal basePrice)
        => basePrice * 0.04m;
}