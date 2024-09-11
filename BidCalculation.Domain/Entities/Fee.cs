using BidCalculation.Domain.Core;

namespace BidCalculation.Domain.Entities;

public class Fee : Entity
{
    public decimal BuyerFee { get; private set; }
    public decimal SellerFee { get; private set; }
    public decimal AssociationFee { get; private set; }
    public decimal StorageFee { get; private set; }
}