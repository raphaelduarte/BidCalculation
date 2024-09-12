using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Enums;
using BidCalculation.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BindCalculationController : ControllerBase
{
    private readonly ICalculationService _calculationService;
    public BindCalculationController(ICalculationService calculationService)
    {
        _calculationService = calculationService;
    }
    [HttpGet]
    public Calculation GetFee(VehicleType vehicleType, decimal basePrice) 
        => _calculationService.CalculateFee(vehicleType, basePrice);
}