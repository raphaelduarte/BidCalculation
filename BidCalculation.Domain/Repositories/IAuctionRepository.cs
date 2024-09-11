using BidCalculation.Domain.Entities;

namespace BidCalculation.Domain.Repositories;

public interface IAuctionRepository
{
    Task AddAsync(Auction auction);                    
    Task<Auction> FindByIdAsync(Guid id);                
    Task<IEnumerable<Auction>> GetAllAsync();          
    Task UpdateAsync(Auction auction);                
}