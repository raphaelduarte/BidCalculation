using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Services.Calculator;

public class StorageFee : IFeeCalculation
{
    public Fee Calc(decimal basePrice)
        => new Fee() { Amount = 100.00m, FeeType = FeeType.Storage };
}