using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Services.Calculator;

public class AssociationFee : IFeeCalculation
{
    public Fee Calc(decimal basePrice)
        => new Fee() { Amount = GetAmount(basePrice), FeeType = FeeType.Association };
    private static decimal GetAmount(decimal basePrice)
        => basePrice switch
        {
            // Amount between $1 and $500
            >= 1 and <= 500 => 5,

            // Amount greater than $500 up to $1000
            > 500 and <= 1000 => 10,

            // Amount greater than $1000 up to $3000
            > 1000 and <= 3000 => 15,

            // Amount over $3000
            > 3000 => 20,

            // Default case, in case the vehicle price is 0 or negative
            _ => 0
        };
}