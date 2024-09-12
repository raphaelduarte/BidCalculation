using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Entities;

public class Fee
{
    public FeeType FeeType { get; set; }
    public decimal Amount { get; set; }
}