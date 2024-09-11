using BidCalculation.Application.Factories;
using BidCalculation.Domain.Repositories;
using BidCalculation.Domain.Strategies;
using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.Application.UseCases;

public class FeeCalculationUseCase
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly FeeCalculatorFactory _feeCalculatorFactory;

    public FeeCalculationUseCase(
        IVehicleRepository vehicleRepository,
        FeeCalculatorFactory feeCalculatorFactory
    )
    {
        _vehicleRepository = vehicleRepository;
        _feeCalculatorFactory = feeCalculatorFactory;
    }

    public async Task<decimal> Execute(Guid vehicleId)
    {
        var vehicle = await _vehicleRepository.FindByIdAsync(vehicleId);
        if (vehicle == null)
        {
            throw new ArgumentException("Vehicle not found");
        }

        var feeCalculator = _feeCalculatorFactory.Create(vehicle.VehicleType);

        return feeCalculator.CalculateFee(vehicle.BasePrice);
    }
}