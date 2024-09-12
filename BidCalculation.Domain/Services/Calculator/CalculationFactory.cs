using BidCalculation.Domain.Enums;

namespace BidCalculation.Domain.Services.Calculator;

public static class CalculationFactory
{
    public static ICalculation GetCalculation(VehicleType vehicleType)
        => vehicleType switch
        {
            VehicleType.Common => new Calculator()
                .AddFee(new CommonBasicFee())
                .AddFee(new CommonSpecialFee())
                .AddFee(new AssociationFee())
                .AddFee(new StorageFee())
                .Build(),
            VehicleType.Luxury => new Calculator()
                .AddFee(new LuxuryBasicFee())
                .AddFee(new LuxurySpecialFee())
                .AddFee(new AssociationFee())
                .AddFee(new StorageFee())
                .Build(),
            _ => throw new NotImplementedException()
        };
}