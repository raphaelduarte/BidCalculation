using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Interfaces;

public interface ICalculationService
{
    Calculation CalculateFee(VehicleType vehicleType, decimal basePrice);
}