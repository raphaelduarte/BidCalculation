using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.API.Requests;

public class BidRequest
{
    public Money BasePrice { get; set; }
    public VehicleType VehicleType { get; set; }
    public Guid AuctionId { get; set; }
}