using System.ComponentModel.DataAnnotations.Schema;
using BidCalculation.Domain.Core;
using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.Domain.Entities;

public class Bid : Entity
{
    public Money BasePrice { get; private set; }
    public VehicleType VehicleType { get; private set; }


    [ForeignKey("AuctionId")]
    public Guid AuctionId { get; set; }
    public Auction Auction { get; set; }
    
}