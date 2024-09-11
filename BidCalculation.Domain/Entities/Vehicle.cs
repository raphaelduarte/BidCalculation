using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BidCalculation.Domain.Core;
using BidCalculation.Domain.ValueObjects;

namespace BidCalculation.Domain.Entities
{
    public class Vehicle : Entity
    {
        public Vehicle(decimal basePrice, VehicleType vehicleType)
        {
            BasePrice = basePrice;
            VehicleType = vehicleType;
        }

        public decimal BasePrice { get; private set; }
        public VehicleType VehicleType { get; private set; }
    }
}