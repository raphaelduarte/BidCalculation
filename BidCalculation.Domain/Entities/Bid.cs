using BidCalculation.Domain.Core;
using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.Domain.Entities;

public class Bid : Entity
{
    public Money BasePrice { get; private set; }
    public VehicleType VehicleType { get; private set; }
}