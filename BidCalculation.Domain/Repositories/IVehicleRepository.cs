using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Repositories;

public interface IVehicleRepository
{
    Task AddAsync(Vehicle vehicle);                   
    Task<Vehicle?> FindByIdAsync(Guid id);               
    Task<IEnumerable<Vehicle>> GetAllAsync();         
    Task UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(Vehicle vehicle);
}