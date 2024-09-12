using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Services.Calculator;

public class Calculator : ICalculation, ICalculationBuilder
{
    private List<IFeeCalculation> _fees = new List<IFeeCalculation>();

    public ICalculationBuilder AddFee(IFeeCalculation fee)
    {
        _fees.Add(fee);

        return this;
    }

    public ICalculationBuilder RemoveFee(IFeeCalculation fee)
    {
        _fees.Remove(fee);

        return this;
    }

    public Calculation Calc(decimal basePrice)
    {
        var result = new Calculation
        {
            TotalCost = basePrice
        };

        foreach (var fee in _fees)
        {
            var feeResult = fee.Calc(basePrice);
            result.Fees.Add(feeResult);
            result.TotalCost += feeResult.Amount;
        }

        return result;
    }

    public ICalculation Build()
        => this;
}