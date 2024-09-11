using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BidCalculation.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    private readonly IVehicleRepository _vehicleRepository;

    public VehicleController(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVehicleById(Guid id)
    {
        var vehicle = await _vehicleRepository.FindByIdAsync(id);
        if (vehicle == null)
        {
            return NotFound("Vehicle not found.");
        }
        return Ok(vehicle);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle(Vehicle vehicle)
    {
        await _vehicleRepository.AddAsync(vehicle);
        return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
    }
}