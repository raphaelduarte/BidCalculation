using BidCalculation.Domain.Core;

namespace BidCalculation.Domain.Entities;

public class Money : Entity
{
    public decimal Amount { get; }
    public string Currency { get; }
}