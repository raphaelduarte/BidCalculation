using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BidCalculation.Domain.Strategies
{
    public interface IFeeCalculator
    {
        decimal CalculateFee(decimal basePrice);
    }
}
