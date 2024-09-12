namespace BidCalculation.Domain.Services.Calculator;

public interface ICalculationBuilder
{
    ICalculationBuilder AddFee(IFeeCalculation fee);

    ICalculationBuilder RemoveFee(IFeeCalculation fee);

    ICalculation Build();
}