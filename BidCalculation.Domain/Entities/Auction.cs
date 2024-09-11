using BidCalculation.Domain.Core;

namespace BidCalculation.Domain.Entities;

public class Auction : Entity
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    private readonly HashSet<Vehicle> _vehicles = new HashSet<Vehicle>();
}