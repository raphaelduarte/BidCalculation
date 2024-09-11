using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.API.Responses;

public class VehicleResponse
{
    public Guid Id { get; set; }
    public decimal BasePrice { get; set; }
    public VehicleType VehicleType { get; set; }
    public Guid AuctionId { get; set; }
}