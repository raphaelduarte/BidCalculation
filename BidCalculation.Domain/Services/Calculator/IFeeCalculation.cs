using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Services.Calculator;

public interface IFeeCalculation
{
    public Fee Calc(decimal basePrice);
}