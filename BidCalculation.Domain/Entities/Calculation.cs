namespace BidCalculation.Domain.Entities;

public class Calculation
{
    public decimal TotalCost  { get; set; }
    public List<Fee> Fees { get; set; } = new List<Fee>();
}