using BidCalculation.Domain.Entities;
using BidCalculation.Domain.Repositories;
using BidCalculation.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BidCalculation.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly BidCalculationDbContext _context;

    public VehicleRepository(BidCalculationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Vehicle vehicle)
    {
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync();
    }

    public async Task<Vehicle> FindByIdAsync(Guid id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync()
    {
        return await _context.Vehicles.ToListAsync();
    }

    public async Task UpdateAsync(Vehicle vehicle)
    {
        _context.Vehicles.Update(vehicle);
        await _context.SaveChangesAsync();
    }
}