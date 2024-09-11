using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.API.Requests;

public class VehicleRequest
{
    public decimal BasePrice { get; set; }
    public VehicleType VehicleType { get; set; }
}