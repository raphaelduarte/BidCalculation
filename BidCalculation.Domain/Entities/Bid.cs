using System.ComponentModel.DataAnnotations.Schema;
using BidCalculation.Domain.Core;
using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.Domain.Entities;

public class Bid : Entity
{
    public Bid()
    {
            
    }

    public Bid(Money basePrice, VehicleType vehicleType, Guid auctionId)
    {
        BasePrice = basePrice;
        VehicleType = vehicleType;
        AuctionId = auctionId;
    }
    public Money BasePrice { get; set; }
    public VehicleType VehicleType { get; set; }


    [ForeignKey("AuctionId")]
    public Guid AuctionId { get; set; }
    public Auction Auction { get; set; }
    
}