namespace BidCalculation.API.Responses;

public class AuctionResponse
{
    public Guid Id { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<VehicleResponse> Vehicles { get; set; }
    public List<BidResponse> Bids { get; set; }
}