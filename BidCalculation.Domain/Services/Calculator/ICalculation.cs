using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Services.Calculator;

public interface ICalculation
{
    Calculation Calc(decimal basePrice);
}