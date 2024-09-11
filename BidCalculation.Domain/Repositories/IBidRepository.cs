using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Repositories;

public interface IBidRepository
{
    Task AddAsync(Bid bid);                           
    Task<Bid> GetByIdAsync(int id);                   
    Task<IEnumerable<Bid>> GetAllAsync();
    Task UpdateAsync(Bid bid);
}