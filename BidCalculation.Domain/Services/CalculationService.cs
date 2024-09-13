using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Interfaces;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Domain.Services;

public class CalculationService : ICalculationService
{
    private const decimal MaxBasePrice = 100000000000M;
    public Calculation CalculateFee(VehicleType vehicleType, decimal basePrice)
    {
        if (basePrice is <= 0 or > MaxBasePrice)
        {
            return new Calculation
            {
                TotalCost = 0,
                Fees = new List<Fee>
                {
                    new Fee { FeeType = FeeType.Basic, Amount = 0 },
                    new Fee { FeeType = FeeType.Special, Amount = 0 },
                    new Fee { FeeType = FeeType.Association, Amount = 0 },
                    new Fee { FeeType = FeeType.Storage, Amount = 0 }
                }
            };
        }

        var calc = CalculationFactory.GetCalculation(vehicleType);
        var result = calc.Calc(basePrice);

        return result;
    }
}