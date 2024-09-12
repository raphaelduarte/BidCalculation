using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Services.Calculator;

public class CommonSpecialFee : IFeeCalculation
{
    public Fee Calc(decimal basePrice)
        => new Fee() { Amount = GetAmount(basePrice), FeeType = FeeType.Special };
    private static decimal GetAmount(decimal basePrice)
        => basePrice * 0.02m;
}