using BidCalculation.API.Requests;
using BidCalculation.API.Responses;
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

        var response = new VehicleResponse
        {
            Id = vehicle.Id,
            BasePrice = vehicle.BasePrice,
            VehicleType = vehicle.VehicleType,
            AuctionId = vehicle.AuctionId
        };

        return Ok(response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVehicle(Guid id, Vehicle updatedVehicle)
    {
        var vehicle = await _vehicleRepository.FindByIdAsync(id);
        if (vehicle == null)
        {
            return NotFound("Vehicle not found.");
        }

        vehicle.BasePrice = updatedVehicle.BasePrice;
        vehicle.VehicleType = updatedVehicle.VehicleType;

        await _vehicleRepository.UpdateAsync(vehicle);
        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAllVehicles()
    {
        var vehicles = await _vehicleRepository.GetAllAsync();
        return Ok(vehicles);
    }

    [HttpPost]
    public async Task<IActionResult> CreateVehicle([FromBody] VehicleRequest request)
    {
        var vehicle = new Vehicle(request.BasePrice, request.VehicleType);

        await _vehicleRepository.AddAsync(vehicle);
        return CreatedAtAction(nameof(GetVehicleById), new { id = vehicle.Id }, vehicle);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVehicle(Guid id)
    {
        var vehicle = await _vehicleRepository.FindByIdAsync(id);
        if (vehicle == null)
        {
            return NotFound("Vehicle not found.");
        }

        await _vehicleRepository.DeleteAsync(vehicle);
        return NoContent();
    }
}