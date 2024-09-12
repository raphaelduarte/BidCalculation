using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Interfaces;
using BidCalculation.Domain.Services.Calculator;

namespace BidCalculation.Domain.Services;

public class CalculationService : ICalculationService
{
    public Calculation CalculateFee(VehicleType vehicleType, decimal basePrice)
    {
        var calc = CalculationFactory.GetCalculation(vehicleType);
        var result = calc.Calc(basePrice);

        return result;
    }
}